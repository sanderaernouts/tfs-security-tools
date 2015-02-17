using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TfsSecurityTools.Models
{
    public class TeamProjectModel
    {
        public string Name { get; set; }

        public string Collection { get; set; }

        public string Url { get; set; }

        public override bool Equals(object obj)
        {
            if(!(obj is TeamProjectModel))
                return base.Equals(obj);

            TeamProjectModel other = obj as TeamProjectModel;
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach(PropertyInfo property in properties)
            {
                object thisValue = property.GetValue(this);
                object otherValue = property.GetValue(obj);

                if (!thisValue.Equals(otherValue))
                    return false;
            }

            return true;
        }
    }
}
