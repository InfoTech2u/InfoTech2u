using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoTech2u.Verithus.VO;
using InfoTech2u.Verithus.DA;

namespace InfoTech2u.Verithus.BS
{
    public class UsuariosBS
    {
        public string SelecionarUsuario(UsuariosVO param)
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

        public List<UsuariosVO> SelecionarUsuarioLista(UsuariosVO param)
        {
            UsuariosDA objRetorno = new UsuariosDA();

            try
            {
                return objRetorno.SelecionarUsuarioLista(param);
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
    }
}
