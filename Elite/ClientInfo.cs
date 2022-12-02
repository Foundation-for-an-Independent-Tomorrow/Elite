using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite
{
    internal class ClientInfo
    {
        public int ClientinfoID { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string PrimaryPhone { get; set; }
        public bool PublicAssist { get; set; }
        public int ClientID { get; set; }
        public bool Conviction { get; set; }

        public virtual Client Client { get; set; }
    }
}
