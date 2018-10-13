using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelastelleCipher.Crypter.Models;

namespace DelastelleCipher.Crypter.Utils
{
    public static class CharPositionReadingExtension
    {
        private static readonly int matrixLength = 5;

        public static string ReadHorizontal(this CharPosition[] source)
        {
            var length = source.Length;
            var resultLength = length * 2;

            StringBuilder builder = new StringBuilder(resultLength);

            for (int i = 0; i < length; i++)
            {
                builder.Append(source[i].Column);
            }

            for (int i = 0; i < length; i++)
            {
                builder.Append(source[i].Row);
            }

            return builder.ToString();
        }

        public static string ReadUpToDown(this CharPosition[] source)
        {
            var lenght = source.Length;
            var resultLength = lenght * 2;
            
            StringBuilder builder = new StringBuilder(resultLength);

            for (int i = 0; i < lenght; i++)
            {
                builder.Append(source[i].Column);
                var rowPosition = (source[i].Row + 1) == matrixLength ? 0 : source[i].Row + 1;
                builder.Append(rowPosition);
            }

            return builder.ToString();
        }

        public static string ReadDownToUp(this CharPosition[] source)
            {
            var length = source.Length;
            var resultLength = length * 2;

            StringBuilder builder = new StringBuilder(resultLength);
             
            for (int i = 0; i < length; i++)
            {
                builder.Append(source[i].Row);
                var columnPosition = (source[i].Column + 1) == matrixLength ? 0 : source[i].Column + 1;
                builder.Append(columnPosition);
            }

            return builder.ToString();
        }
    }
}
