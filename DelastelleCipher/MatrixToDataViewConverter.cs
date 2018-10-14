using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DelastelleCipher
{
    public class MatrixToDataViewConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var dataTable = new DataTable();
            var columns = values[0] as string[];
            var rows = values[0] as string[];

            if (values[1] == null)
            {
                return dataTable.DefaultView;
            }

            var vals = values[1] as char[,];

            var width = vals.GetLength(0);
            var height = vals.GetLength(1);

            dataTable.Columns.Add("-");
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

            var index = 0;
            for (int i = 0; i < width; i++)
            {
                List<string> rowElements = new List<string>();
                rowElements.Add(rows[index]);
                for (int j = 0; j < height; j++)
                {
                    rowElements.Add(vals[i,j].ToString());
                }

                dataTable.Rows.Add(rowElements.ToArray());
                index++;
            }

            return dataTable.DefaultView;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
