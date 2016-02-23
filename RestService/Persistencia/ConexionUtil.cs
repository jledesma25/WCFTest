using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return "Data Source=SVSQL12\\BDSERVERAP;Initial Catalog=DbAsys;UId=sql12;Pwd=Version.2012.";
            }
        }
    }
}