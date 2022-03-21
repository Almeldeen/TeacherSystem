using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helper
{
   public class ResponseBody<T> where T : class
    {
        public bool message { get; set; }
        public IList<T> data { get; set; }
        public string status_code { get; set; }
        public string error { get; set; }
    }
}
