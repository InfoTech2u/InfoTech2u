﻿using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for ManterTarefa
    /// </summary>
    public class ManterTarefa : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["Metodo"] == "Lista")
            {
                var retorno = SelecionarTarefaLista(new TipoTarefaVO());

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(retorno));
            }
            else if (context.Request.QueryString["Metodo"] == "Incluir")
            {
                TipoTarefaVO param = new TipoTarefaVO();
                param.Descricao = context.Request.QueryString["Descricao"].ToString();

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                context.Response.Write(serializer.Serialize(IncluirTipoTarefa(param)));

            }
            else if (context.Request.QueryString["Metodo"] == "Excluir")
            {
                TipoTarefaVO param = new TipoTarefaVO();
                int numconvertido = 0;

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                if (Int32.TryParse(context.Request.QueryString["Id"].ToString(), out numconvertido))
                {
                    param.CodigoTipoTarefa = numconvertido;

                    context.Response.Write(serializer.Serialize(ExcluirTipoTarefa(param)));
                }
                else
                {
                    context.Response.Write(serializer.Serialize(false));
                }
            }
        }

        private List<TipoTarefaVO> SelecionarTarefaLista(TipoTarefaVO param)
        {
            TipoTarefaBS objBS = new TipoTarefaBS();
            return objBS.SelecionarTarefaLista(param);
        }

        private bool IncluirTipoTarefa(TipoTarefaVO param)
        {
            TipoTarefaBS objBS = new TipoTarefaBS();
            return objBS.IncluirTipoTarefa(param);
        }

        private bool ExcluirTipoTarefa(TipoTarefaVO param)
        {
            TipoTarefaBS objBS = new TipoTarefaBS();
            return objBS.ExcluirTipoTarefa(param);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}