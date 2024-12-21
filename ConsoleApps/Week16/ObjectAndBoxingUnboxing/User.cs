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

        /// <summary>
        ///  Override ToString to display meaningful information about the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"User: {UserName}";
        }

        public User Clone()
        {
            // return cloned value using
            // MemberwiseClone() method
            return ((User)MemberwiseClone());
        }
    }


}
