using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace InfoTech2u.Verithus.Util
{
    public sealed class InfoTech2uSQLUtil
    {
        #region Construtores

        public InfoTech2uSQLUtil()
        {
            InicializaComponentes();
        }

        public InfoTech2uSQLUtil(string connectionString)
        {
            _connectionString = connectionString;
            InicializaComponentes();
            Open();
        }

        private void InicializaComponentes()
        {
            this._commandTimeout = 30;
        }

        #endregion

        #region Propriedades Privadas

        private string _connectionString;
        private int _commandTimeout;
        private string _sigla = string.Empty;


        private int _resultado;

        public int Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }

        #endregion

        #region Propriedades Públicas

        /// <summary>
        /// Quando o SQL retorna uma mensagem de Warning ou de Informação.
        /// </summary>
        public event SqlInfoMessageEventHandler InfoMessage = null;

        /// <summary>
        /// String usada para abrir a conexão com o banco de dados SQL Server.
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// Tempo em segundos da duração de execução de um comando.
        /// </summary>
        public int CommandTimeout
        {
            get { return _commandTimeout; }
            set { _commandTimeout = value; }
        }

        /// <summary>
        /// Sigla do Sistema
        /// </summary>
        public string Sigla
        {
            get { return this._sigla; }
            set { this._sigla = value; }
        }

        /// <summary>
        /// Status da Conexão
        /// </summary>
        public string State
        {
            get { return this.clsSqlConnection.State.ToString(); }
        }

        #endregion

        #region Objetos

        /// <summary>
        /// Objeto de conexão com o SQL Server.
        /// </summary>
        private SqlConnection clsSqlConnection;

        /// <summary>
        /// Objeto de Comando SQL.
        /// </summary>
        private SqlCommand clsSqlCommand;

        #endregion

        #region Funções Privadas

        /// <summary>
        /// Descriptografa um valor.
        /// </summary>
        /// <param name="_Value">String a ser descriptografada.</param>
        private static string Decrypt(string _Value)
        {
            InfoTech2uCryptographyUtil oCrypt = new InfoTech2uCryptographyUtil(EncryptionAlgorithm.TripleDes);
            _Value = Encoding.ASCII.GetString(oCrypt.Decrypt(Convert.FromBase64String(_Value), InfoTech2uCryptographyUtil.Key, InfoTech2uCryptographyUtil.Vector));
            return _Value;
        }

        #endregion

        #region Funções Publicas

        /// <summary>
        /// Retorna a database está em arquivo xml
        /// </summary>
        public string GetDataBase()
        {
            string _DataBase = string.Empty;
            XmlDocument oXmlDoc = new XmlDocument();
            System.Web.UI.Page oPg = new System.Web.UI.Page();

            try
            {
                if (System.IO.File.Exists(oPg.Server.MapPath("~/include/xml/database")))
                    oXmlDoc.Load(oPg.Server.MapPath("~/include/xml/database"));
                else
                    oXmlDoc.Load(oPg.Server.MapPath("~/include/xml/database.xml"));

                XmlElement oRoot = oXmlDoc.DocumentElement;
                for (int i = 0; i < oRoot.GetElementsByTagName("ConnectionString").Count; i++)
                {
                    _DataBase = Decrypt(oRoot.GetElementsByTagName("database")[i].InnerXml.Trim());

                    break;
                }

                oRoot = null;
                return _DataBase;
            }
            catch (XmlException err)
            {
                throw err;
            }
            catch (NullReferenceException err)
            {
                throw new NullReferenceException("Erro ao tentar ler arquivo de configuração da ConnectionString! " + err.Message, err);
            }
            catch (Exception err)
            {
                throw new Exception("Erro ao tentar ler arquivo de configuração da ConnectionString! " + err.Message, err);
            }
            finally
            {
                oXmlDoc = null;
                oPg.Dispose();
            }
        }

        /// <summary>
        /// Retorna a string de conexão que está em arquivo xml
        /// </summary>
        public string GetConnectionString()
        {
            string stringConnection = string.Empty;
            XmlDocument oXmlDoc = new XmlDocument();
            System.Web.UI.Page oPg = new System.Web.UI.Page();

            try
            {
                oXmlDoc.Load(oPg.Server.MapPath("~/include/xml/database.xml"));

                XmlElement oRoot = oXmlDoc.DocumentElement;
                for (int i = 0; i < oRoot.GetElementsByTagName("ConnectionString").Count; i++)
                {
                    stringConnection = "Data Source=" + Decrypt(oRoot.GetElementsByTagName("server")[i].InnerXml.Trim());

                    if (!String.IsNullOrEmpty(oRoot.GetElementsByTagName("port")[i].InnerXml.Trim()))
                        stringConnection += "," + Decrypt(oRoot.GetElementsByTagName("port")[i].InnerXml.Trim()) + ";";
                    else
                        stringConnection += ";";

                    stringConnection += "Initial Catalog=" + Decrypt(oRoot.GetElementsByTagName("database")[i].InnerXml.Trim()) + ";";
                    stringConnection += "User ID=" + Decrypt(oRoot.GetElementsByTagName("user")[i].InnerXml.Trim()) + ";";
                    stringConnection += "Password=" + Decrypt(oRoot.GetElementsByTagName("password")[i].InnerXml.Trim()) + ";";
                    break;
                }

                oRoot = null;
                return stringConnection;
            }
            catch (XmlException err)
            {
                throw err;
            }
            catch (NullReferenceException err)
            {
                throw new NullReferenceException("Erro ao tentar ler arquivo de configuração da ConnectionString! " + err.Message, err);
            }
            catch (Exception err)
            {
                throw new Exception("Erro ao tentar ler arquivo de configuração da ConnectionString! " + err.Message, err);
            }
            finally
            {
                oXmlDoc = null;
                oPg.Dispose();
            }
        }

        /// <summary>
        /// Retorna a string de conexão que está em arquivo xml
        /// </summary>
        /// <param name="DataBase">Nome da DataBase em que se conectará</param>
        public string GetConnectionString(string DataBase)
        {
            string stringConnection = string.Empty;
            XmlDocument oXmlDoc = new XmlDocument();
            System.Web.UI.Page oPg = new System.Web.UI.Page();

            try
            {
                if (System.IO.File.Exists(oPg.Server.MapPath("~/include/xml/database")))
                    oXmlDoc.Load(oPg.Server.MapPath("~/include/xml/database"));
                else
                    oXmlDoc.Load(oPg.Server.MapPath("~/include/xml/database.xml"));

                XmlElement oRoot = oXmlDoc.DocumentElement;
                for (int i = 0; i < oRoot.GetElementsByTagName("ConnectionString").Count; i++)
                {
                    stringConnection = "Data Source=" + Decrypt(oRoot.GetElementsByTagName("server")[i].InnerXml.Trim());

                    if (!String.IsNullOrEmpty(oRoot.GetElementsByTagName("port")[i].InnerXml.Trim()))
                        stringConnection += "," + Decrypt(oRoot.GetElementsByTagName("port")[i].InnerXml.Trim()) + ";";
                    else
                        stringConnection += ";";

                    if (String.IsNullOrEmpty(oRoot.GetElementsByTagName("winapli")[i].InnerXml.Trim()))
                    {
                        stringConnection += "Initial Catalog=" + DataBase + ";";
                        stringConnection += "User ID=" + Decrypt(oRoot.GetElementsByTagName("user")[i].InnerXml.Trim()) + ";";
                        stringConnection += "Password=" + Decrypt(oRoot.GetElementsByTagName("password")[i].InnerXml.Trim()) + ";";
                    }
                    else
                    {
                        stringConnection += "Initial Catalog=" + DataBase + ";";
                        stringConnection += Decrypt(oRoot.GetElementsByTagName("winapli")[i].InnerXml.Trim());
                    }

                    break;
                }

                oRoot = null;
                return stringConnection;
            }
            catch (XmlException err)
            {
                throw err;
            }
            catch (NullReferenceException err)
            {
                throw new NullReferenceException("Erro ao tentar ler arquivo de configuração da ConnectionString! " + err.Message, err);
            }
            catch (Exception err)
            {
                throw new Exception("Erro ao tentar ler arquivo de configuração da ConnectionString! " + err.Message, err);
            }
            finally
            {
                oXmlDoc = null;
                oPg.Dispose();
            }
        }

        /// <summary>
        /// Retorna o conteúdo (nome e valor) dos parâmetros concatenados e separador por vírgula (",").
        /// Exemplo: "@PARAM1=VALOR1 , @PARAM2=VALOR1"
        /// </summary>
        /// <param name="Params">Array de parâmetros a serem concatenados "nome_do_parametro" + "=" + "valor_do_parametro".</param>
        public string ConteudoSqlParameter(SqlParameter[] Params)
        {
            string str = string.Empty;

            for (int i = 0; i < Params.Length; i++)
            {
                if (i > 0)
                {
                    str += " , ";
                }

                str = str + Params[i].ParameterName + "=" + Params[i].Value;
            }

            return str;
        }

        /// <summary>
        /// Abre a conexão com o banco de dados SQL Server.
        /// </summary>
        public void Open()
        {
            clsSqlConnection = new SqlConnection();

            try
            {
                clsSqlConnection.ConnectionString = this._connectionString;

                if (InfoMessage != null)
                {
                    clsSqlConnection.InfoMessage += new SqlInfoMessageEventHandler(InfoMessage);
                }
                clsSqlConnection.Open();
            }
            catch (SqlException sex)
            {
                throw sex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função para encerrar a conexão com o banco de dados.
        /// </summary>
        public void Close()
        {
            try
            {
                if (this.clsSqlConnection != null)
                {
                    if (this.clsSqlConnection.State == ConnectionState.Open)
                    {
                        this.clsSqlConnection.Close();
                        this.clsSqlConnection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        /// <summary>
        /// Executa procedure no banco de dados
        /// </summary>
        /// <param name="ProcedureName">Nome da Procedure</param>
        /// <param name="arrParameters">Array de Argumentos</param>
        /// <param name="Transaction">Transaction</param>
        /// <param name="dt">Retorna um objeto DataTable</param>
        public void Execute(string ProcedureName, SqlParameter[] arrParameters, SqlTransaction Transaction, ref DataTable dt)
        {
            this.clsSqlCommand = new SqlCommand();
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            if (Transaction != null)
            {
                this.clsSqlCommand.Transaction = Transaction;
            }

            this.clsSqlCommand.Connection = this.clsSqlConnection;
            this.clsSqlCommand.CommandType = CommandType.StoredProcedure;
            this.clsSqlCommand.CommandText = ProcedureName;

            foreach (SqlParameter p in arrParameters)
            {
                this.clsSqlCommand.Parameters.Add(p);
            }

            SqlDataAdapter DA = new SqlDataAdapter(this.clsSqlCommand);

            try
            {
                dt.BeginLoadData();
                DA.Fill(dt);
                dt.EndLoadData();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dt.Dispose();
                DA.Dispose();
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa procedure no banco de dados
        /// </summary>
        /// <param name="ProcedureName">Nome da Procedure</param>
        /// <param name="arrParameters">Array de Argumentos</param>
        /// <param name="Transaction">Transaction</param>
        /// <param name="ds">Retorna um objeto DataSet</param>
        public void Execute(string ProcedureName, SqlParameter[] arrParameters, SqlTransaction Transaction, ref DataSet ds)
        {
            this.clsSqlCommand = new SqlCommand();
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            if (Transaction != null)
            {
                this.clsSqlCommand.Transaction = Transaction;
            }

            this.clsSqlCommand.Connection = this.clsSqlConnection;
            this.clsSqlCommand.CommandType = CommandType.StoredProcedure;
            this.clsSqlCommand.CommandText = ProcedureName;

            foreach (SqlParameter p in arrParameters)
            {
                this.clsSqlCommand.Parameters.Add(p);
            }

            SqlDataAdapter DA = new SqlDataAdapter(this.clsSqlCommand);

            try
            {
                ds.EnforceConstraints = false;
                DA.Fill(ds);
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                DA.Dispose();
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa comando SQL no banco de dados.
        /// </summary>
        /// <param name="sSQL">String de Comando SQL.</param>
        /// <param name="dr">Retorna um objeto System.Data.DataRow[].</param>
        public void Execute(string sqlcommand, out DataRow[] dr)
        {
            dr = null;

            this.clsSqlCommand = new SqlCommand(sqlcommand, this.clsSqlConnection);
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            SqlDataAdapter da = new SqlDataAdapter(this.clsSqlCommand);
            DataTable dt = new DataTable();

            try
            {
                dt.BeginLoadData();
                da.Fill(dt);
                dt.EndLoadData();
                dr = dt.Select();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dt.Dispose();
                da.Dispose();
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa comando SQL no banco de dados.
        /// </summary>
        /// <param name="sqlcommand">String de Comando SQL.</param>
        /// <param name="dt">Retorna um objeto System.Data.DataTable</param>
        /// <returns>Retorna objeto DataTable.</returns>
        public void Execute(string sqlcommand, out DataTable dt)
        {
            dt = new DataTable();
            this.clsSqlCommand = new SqlCommand(sqlcommand, this.clsSqlConnection);

            clsSqlCommand.CommandTimeout = this._commandTimeout;
            SqlDataAdapter da = new SqlDataAdapter(this.clsSqlCommand);

            try
            {
                dt.BeginLoadData();
                da.Fill(dt);
                dt.EndLoadData();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dt.Dispose();
                da.Dispose();
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa comando SQL no banco de dados.
        /// </summary>
        /// <param name="sqlcommand">String de Comando SQL.</param>
        /// <param name="ds">Retorna objeto System.Data.DataSet.</param>
        public void Execute(string sqlcommand, out DataSet ds)
        {
            ds = new DataSet();
            this.clsSqlCommand = new SqlCommand(sqlcommand, this.clsSqlConnection);
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            SqlDataAdapter da = new SqlDataAdapter(this.clsSqlCommand);

            try
            {
                ds.EnforceConstraints = false;
                da.Fill(ds);
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                da.Dispose();
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa comando SQL no banco de dados.
        /// </summary>
        /// <param name="sqlcommand">String de Comando SQL.</param>
        /// <param name="dt">Retorna um objeto System.Data.DataTable</param>
        /// <returns>Retorna objeto DataTable.</returns>
        public void ExecuteReader(string sqlcommand, out DataTable dt)
        {
            dt = new DataTable();

            this.clsSqlCommand = new SqlCommand(sqlcommand, this.clsSqlConnection);
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            SqlDataReader dr;

            try
            {
                dr = this.clsSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                dt.BeginLoadData();
                dt.Load(dr);
                dt.EndLoadData();
                dr.Dispose();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                dt.Dispose();
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa comando SQL no banco de dados. Não Há Retorno.
        /// </summary>
        /// <param name="sSQL">String de Comando SQL.</param>
        public void ExecuteNonQuery(string sqlcommand)
        {
            this.clsSqlCommand = new SqlCommand(sqlcommand, this.clsSqlConnection);
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            try
            {
                this.clsSqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                this.clsSqlCommand.Dispose();
            }
        }

        public static int ExecutarProcedureScalarInt(SqlCommand sqlcommand)
        {
                                   
            SqlParameter retValParam = new SqlParameter("@@RETURN_VALUE", SqlDbType.VarChar);
            retValParam.Direction = ParameterDirection.ReturnValue;
            sqlcommand.Parameters.Add(retValParam);
            sqlcommand.ExecuteScalar();

            return Convert.ToInt32(sqlcommand.Parameters["@@RETURN_VALUE"].Value);
        }

        public int ExecutarProcedureScalarInt(string strConexao, SqlCommand sqlcommand)
        {

            SqlConnection conn = new SqlConnection(strConexao);


            sqlcommand.Connection = conn;
            conn.Open();

            SqlParameter retValParam = new SqlParameter("@@RETURN_VALUE", SqlDbType.VarChar);
            retValParam.Direction = ParameterDirection.ReturnValue;
            sqlcommand.Parameters.Add(retValParam);
            sqlcommand.ExecuteScalar();

            return Convert.ToInt32(sqlcommand.Parameters["@@RETURN_VALUE"].Value);
        }

        /// <summary>
        /// Executa comando SQL no banco de dados.
        /// </summary>
        /// <param name="sqlcommand">String de Comando SQL.</param>
        /// <param name="rowsAffected">Retorna quabtidade de linhas afetadas.</param>
        public void ExecuteNonQuery(string sqlcommand, out int rowsAffected)
        {
            this.clsSqlCommand = new SqlCommand(sqlcommand, this.clsSqlConnection);
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            try
            {
                rowsAffected = this.clsSqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa procedure no banco de dados
        /// </summary>
        /// <param name="ProcedureName">Nome da Procedure</param>
        /// <param name="arrParameters">Array de Argumentos</param>
        /// <param name="Transaction">Transaction</param>
        public void ExecuteNonQuery(string ProcedureName, SqlParameter[] arrParameters, SqlTransaction Transaction)
        {
            this.clsSqlCommand = new SqlCommand();
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            if (Transaction != null)
            {
                this.clsSqlCommand.Transaction = Transaction;
            }

            this.clsSqlCommand.Connection = this.clsSqlConnection;
            this.clsSqlCommand.CommandType = CommandType.StoredProcedure;
            this.clsSqlCommand.CommandText = ProcedureName;

            foreach (SqlParameter p in arrParameters)
            {
                this.clsSqlCommand.Parameters.Add(p);
            }

            try
            {
                this.clsSqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                this.clsSqlCommand.Dispose();
            }
        }

        /// <summary>
        /// Executa procedure no banco de dados
        /// </summary>
        /// <param name="ProcedureName">Nome da Procedure</param>
        /// <param name="arrParameters">Array de Argumentos</param>
        /// <param name="Transaction">Transaction</param>
        /// <param name="rowsAffected">Retorna quabtidade de linhas afetadas.</param>
        public void ExecuteNonQuery(string ProcedureName, SqlParameter[] arrParameters, SqlTransaction Transaction, out int rowsAffected)
        {
            this.clsSqlCommand = new SqlCommand();
            clsSqlCommand.CommandTimeout = this._commandTimeout;

            if (Transaction != null)
            {
                this.clsSqlCommand.Transaction = Transaction;
            }

            this.clsSqlCommand.Connection = this.clsSqlConnection;
            this.clsSqlCommand.CommandType = CommandType.StoredProcedure;
            this.clsSqlCommand.CommandText = ProcedureName;

            foreach (SqlParameter p in arrParameters)
            {
                this.clsSqlCommand.Parameters.Add(p);
            }

            try
            {
                rowsAffected = this.clsSqlCommand.ExecuteNonQuery();
            }
            catch (SqlException sex)
            { throw sex; }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                this.clsSqlCommand.Dispose();
            }
            
        }
        

        #endregion
    }
}
