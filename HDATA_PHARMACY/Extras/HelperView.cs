using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDATA_PHARMACY.Extras
{
    public static class  HelperView
    {
        public static List<T> GetFilteredData<T>(GridControl gridControl)
        {
            var Enumerator = gridControl.VisibleItems.GetEnumerator();
            List<T> resp = new List<T>();
            while (Enumerator.MoveNext())
            {
                if (Enumerator.Current != null)
                {
                    T dataRow = (T)Enumerator.Current;
                    resp.Add(dataRow);
                }
            }
            return resp;
        }

        public static bool IsNotNull(object obj)
        {
            if (obj == null)
                return false;
            return true;
        }

        public static string FormatDouble_Money(double value)
        {
            return value.ToString("C2", CultureInfo.GetCultureInfoByIetfLanguageTag("PT-ao"));
        }

        public static string FormatDouble_MoneySimple(double value)
        {
            var result = value.ToString("C2", CultureInfo.GetCultureInfoByIetfLanguageTag("PT-ao"));
            return result.Substring(0, result.Length - 2);
        }

        public static bool IsNumber(string value)
        {
            return value.All(x => char.IsNumber(x));
        }

        public static string OrganizedName(string name)
        {
            if (name == null)
            {
                return name;
            }
            string value = name.Trim().ToLower();
            if (value == "")
            {
                return value;
            }

            string newName = (value[0] + "").ToUpper();
            char ant = '/';

            for (int i = 1; i < value.Length; ant = value[i], i++)
            {
                if (value[i] == ' ')
                {
                    if (ant != ' ')
                    {
                        newName += value[i];
                    }
                }
                else
                {
                    newName += ant == ' ' ? (value[i] + "").ToUpper() : value[i] + "";
                }
            }
            name = newName.Trim();

            return name;
        }

        public static string OrganizedText(string description)
        {
            if (description == null)
            {
                return "";
            }
            string value = description.Trim().ToLower();

            if (value == "")
            {
                return "";
            }

            string newdescription = (value[0] + "").ToUpper();
            char ant = '/';

            for (int i = 1; i < value.Length; ant = value[i], i++)
            {
                if (value[i] == ' ')
                {
                    if (ant != ' ')
                    {
                        newdescription += value[i];
                    }
                }
                else
                {
                    newdescription += value[i];
                }
            }
            newdescription = newdescription.Trim();
            return newdescription;
        }

    }
}
