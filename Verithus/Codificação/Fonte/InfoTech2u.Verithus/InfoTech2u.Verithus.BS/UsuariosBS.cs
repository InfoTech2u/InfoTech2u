using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;
using System.Data;

namespace InfoTech2u.Verithus.BS
{
    public class UsuariosBS
    {
        public DataTable SelecionarUsuario(UsuariosVO param)
        {

            UsuariosDA objRetorno = new UsuariosDA();

            try
            {
                return objRetorno.SelecionarUsuario(param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRetorno = null;
            }

        }

        public DataTable SelecionarUsuarioLista(UsuariosVO param)
        {
            UsuariosDA objRetorno = new UsuariosDA();

            try
            {
                return objRetorno.SelecionarUsuario(param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objRetorno = null;
            }
        }

        public DataTable VerificarUsuario(UsuariosVO param)
        {
            UsuariosDA objRetorno = new UsuariosDA();

            return objRetorno.VerificarUsuario(param);
        }

        public DataTable VerificarLogin(string login)
        {
            UsuariosDA objRetorno = new UsuariosDA();

            return objRetorno.VerificarLogin(login);
        }

        public DataTable IncluirUsuario(UsuariosVO usuario)
        {
            UsuariosDA objRetorno = new UsuariosDA();

            return objRetorno.IncluirUsuario(usuario);
        }

        public bool ExcluirUsuario(UsuariosVO usuario)
        {
            UsuariosDA objRetorno = new UsuariosDA();

            return objRetorno.ExcluirUsuario(usuario);
        }

        public DataTable AlterarUsuario(UsuariosVO usuario)
        {
            UsuariosDA objRetorno = new UsuariosDA();

            return objRetorno.AlterarUsuario(usuario);
        }
    }
}
