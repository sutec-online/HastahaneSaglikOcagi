using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSLibrary
{
    public class Patient
    {
        public long id { get; set; }
        public DateTime shipment { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public bool is_discharged { get; set; }
        public string identity { get; set; }
    }
}
