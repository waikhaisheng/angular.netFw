using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class EnumHelper
    {
        public static String GetEnumDescription(this Enum obj)
        {
            System.Reflection.FieldInfo fieldInfo = obj.GetType().GetField(obj.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length > 0)
            {
                var attrib = attribArray[0] as DescriptionAttribute;

                if (attrib != null)
                    return attrib.Description;
            }
            return obj.ToString();
        }
    }
}
