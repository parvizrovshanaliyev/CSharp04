using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjectAndBoxingUnboxing
{
    internal class User
    {
        public string UserName { get; set; }
        
        public User Clone()
        {
            // return cloned value using
            // MemberwiseClone() method
            return ((User)MemberwiseClone());
        }
    }
}
