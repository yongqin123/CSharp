using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSoftware
{
    internal class Account
    {
        public int Id {  get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int amount { get; set; }

        public Account() { }
     }
}
