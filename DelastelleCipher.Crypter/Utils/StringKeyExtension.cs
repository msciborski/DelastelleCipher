using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelastelleCipher.Crypter.Utils
{
    public static class StringKeyExtension
    {
        private static string DeleteRepetitionFromKey(this string key)
        {
            return new string(key.Distinct().ToArray());
        }

        private static string ReplaceJWithI(this string key)
        {
            return key.Replace("j", "I").Replace("J", "I");
        }

        private static string RemoveWhitespaces(this string key)
        {
            return key.Replace(" ", String.Empty);
        }

        public static string UnifyKey(this string key)
        {
            return key.RemoveWhitespaces().ToUpperInvariant().ReplaceJWithI().DeleteRepetitionFromKey();
        }
    }
}
