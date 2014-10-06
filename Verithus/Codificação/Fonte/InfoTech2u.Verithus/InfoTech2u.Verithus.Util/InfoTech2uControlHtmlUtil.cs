using System;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Web.UI.WebControls;

namespace InfoTech2u.Verithus.Util
{
    public static class InfoTech2uControlHtmlUtil
    {
        //Incluir JavaScript ou Css Dinamicamente e em tempo de execução para resolver problema de caminhos de arquivo na master page Solution by Lex Luthor
        public static void IncludeHtmlGenericControl(Page pagina, string tipo, string caminho, string arquivo)
        {
            
            switch (tipo)
            {
                case "css":
                    HtmlGenericControl newControlCss = new HtmlGenericControl("link");
                    newControlCss.Attributes["rel"] = "stylesheet";
                    newControlCss.Attributes["href"] = caminho + arquivo;
                    newControlCss.Attributes["type"] = "text/css";
                    pagina.Header.Controls.Add(newControlCss);
                    break;
                case "js":
                    HtmlGenericControl newControlJs = new HtmlGenericControl("script");
                    newControlJs.Attributes["type"] = "text/javascript";
                    newControlJs.Attributes["src"] = caminho + arquivo;
                    pagina.Header.Controls.Add(newControlJs);
                    break;
            }
        }

        //Adicionar Url Amigavel ao Sistema e altera o HyperLink relaivo
        public static void AdicionarUrlAmigavel(string UrlAmigavel, String NomePagina,  HyperLink link)
        {
            UrlMapping urlMap = null;
            // Abre o Web.config
            Configuration config  = WebConfigurationManager.OpenWebConfiguration("~");
            // Recupera a seção urlMappings, do web.config
            UrlMappingsSection urlMapSection = (UrlMappingsSection)config.GetSection("system.web/urlMappings");
            // Adiciona a URL Amigável a seção, que é salva no Web.Config
            urlMap = new UrlMapping("~/" + UrlAmigavel, NomePagina);
            urlMapSection.UrlMappings.Remove(urlMap);
            urlMapSection.UrlMappings.Add(urlMap);
            // Grava no web.config
            config.Save();
            
            //Alterar HyperLink
            link.NavigateUrl = "~/" + UrlAmigavel;
            
        }

        public static Boolean SetSelectedValue(this DropDownList dropDownList, String selectedValue)
        {
            ListItem selectedListItem = dropDownList.Items.FindByValue(selectedValue);

            if (selectedListItem != null)
                selectedListItem.Selected = true;

            return true;

        }
    }
}
