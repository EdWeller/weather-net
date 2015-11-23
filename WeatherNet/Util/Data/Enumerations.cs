using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WeatherNet.Util.Data
{
    /// <summary>
    /// Extension methods for enumerations
    /// </summary>
    public class Enumerations
    {
        /// <summary>
        /// Gets the enum description value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }
}
