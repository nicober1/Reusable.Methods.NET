using ChoETL;

namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static void WriteDataTableToFile(this DataTable table, string relativePath)
        {
            int i;
            var sw = new StreamWriter(GetExecutingAssemblyLocationPath() + relativePath, false);
            for (i = 0; i < table.Columns.Count - 1; i++)
            {
                sw.Write(table.Columns[i].ColumnName + ";");
            }
            sw.Write(table.Columns[i].ColumnName);
            sw.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                var array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    sw.Write(array[i] + ";");
                }
                sw.Write(array[i].ToString());
                sw.WriteLine();
            }
            sw.Close();
        }

        public static DataTable ConvertCsvToDataTable(string path)
        {
            var p = new ChoCSVReader(path).WithFirstLineHeader();
            return p.AsDataTable();
        }
    }
}