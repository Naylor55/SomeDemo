using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LeadingSite.PublicClass
{
    public class ModelConvertHelper<T> where T : new()  
    {
        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ConvertToModel(DataTable dt)
        {
            IList<T> ts = new List<T>();
            Type type = typeof(T);
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                ts.Add(t);
            }
            return ts;
        }
    }
}
