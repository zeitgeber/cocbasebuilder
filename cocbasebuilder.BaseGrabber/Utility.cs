using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cocbasebuilder.BaseGrabber
{
    public class Utility
    {
        public static string GetHashTag(string url)
        {
            return url.Contains('#') ? url.Substring(url.IndexOf('#')+1) : null;
        }

        public static string Expand(string str)
        {
            var result = new StringBuilder();
            int length;
            for(int i=0; i<str.Length; i++)
            {

                for (length = 1; length + i < str.Length; length++)
                    if (!IsNumeric(str.Substring(i + 1, length)))
                        break;
                length--;
                int repeats = length>=1? int.Parse(str.Substring(i + 1, length))+1:1;

                result.Append(new String(str[i], repeats));

                i = i + length;

            }
            return result.ToString();
        }

        private static bool IsNumeric(string s)
        {
            int output;
            return int.TryParse(s, out output);
        }
    }
}

