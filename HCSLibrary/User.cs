using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSLibrary
{
    public class User
    {
        public long id { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string phone { get; set; }
        public bool admin { get; set; }
        public string title { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
    }
}
