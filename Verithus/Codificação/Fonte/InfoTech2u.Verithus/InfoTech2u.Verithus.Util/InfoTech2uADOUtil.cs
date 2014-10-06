using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace InfoTech2u.Verithus.Util
{
    public static class InfoTech2uADOUtil
    {

        public static String DataTableSerializer(this DataTable dt)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }

            return serializer.Serialize(rows);
        }

        public static String Serializer(this Object obj)
        {
            try
            {
                if (obj.GetType() == typeof(DataTable))
                {
                    return ((DataTable)obj).DataTableSerializer();
                }
                else
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    return serializer.Serialize(obj);
                }
            }
            catch (Exception)
            {
                return String.Empty;
            }

            
        }
    }
}
