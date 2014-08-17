using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using InfoTech2u.Verithus.BS;
using InfoTech2u.Verithus.VO;

namespace InfoTech2u.Verithus.WEB.Handler
{
    /// <summary>
    /// Summary description for DataTablesHandlerGeneric
    /// </summary>
    public class DataTablesHandlerGeneric : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            /*
            // Those parameters are sent by the plugin
            var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
            var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
            var iSortCol = int.Parse(context.Request["iSortCol_0"]);
            var iSortDir = context.Request["sSortDir_0"];

            // Fetch the data from a repository (in my case in-memory)
            var persons = Person.GetPersons();

            List<EmpresaVO> empresa = EmpresaBS.SelecionarEmpresa();

            // Define an order function based on the iSortCol parameter
            Func<EmpresaVO, object> order = p =>
            {
                if (iSortCol == 0)
                {
                    return p.Id;
                }
                return p.NomeEmpresa;


            };

            // Define the order direction based on the iSortDir parameter
            if ("desc" == iSortDir)
            {
                //empresa = empresa.OrderByDescending(order);
            }
            else
            {
                //empresa = empresa.OrderBy(order);
            }

            // prepare an anonymous object for JSON serialization


            List<EmpresaVO> newList = empresa.Where(m => m.Id > 0).ToList();

            var result = new
            {
                iTotalRecords = newList.Count(),
                iTotalDisplayRecords = newList.Count(),
                aaData = newList
                    .Select(p => new[] { p.Id.ToString(), p.NomeEmpresa, p.documentoCNPJ })
                    .Skip(iDisplayStart)
                    .Take(iDisplayLength)
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(newList);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
             * */
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public class Person
        {
            public int Seq { get; set; }

            public string Id { get; set; }
            public string NomeEmpresa { get; set; }

            public string documentoCNPJ { get; set; }


            public static IEnumerable<Person> GetPersons()
            {
                for (int i = 1; i < 57; i++)
                {
                    yield return new Person
                    {
                        Seq = i,
                        Id = i.ToString(),
                        NomeEmpresa = "Empresa " + i,
                        documentoCNPJ = "56.783.877/0001-51"
                    };
                }
            }
        }
    }
}