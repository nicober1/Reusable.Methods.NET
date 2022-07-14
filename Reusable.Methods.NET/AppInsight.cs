namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static class ReuseAppInsightMethods
        {
            public static DataTable GetDataTableFromAppInsightApiJsonTableResponse(string content)
            {
                var result = JsonConvert.DeserializeObject<JsonTableResponseClass>(content);
                var dt = result?.tables?[0].columns.ToDataTable();
                var table = new DataTable();
                if (dt != null)
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        var c = dt.Rows[i][0] as string ?? string.Empty;
                        var dtc = new DataColumn
                        {
                            ColumnName = c.Replace("_", "")
                        };
                        table.Columns.Add(dtc);
                    }
                var rows = result?.tables[0].rows;
                if (rows == null) return table;
                {
                    foreach (var r in rows)
                    {
                        var row = table.NewRow();
                        for (var i = 0; i < r.Count; i++)
                        {
                            row[i] = r[i];
                        }
                        table.Rows.Add(row);
                    }
                }
                return table;
            }

            public class Column
            {
                public string name { get; set; }
                public string type { get; set; }
            }

            public class Table
            {
                public string name { get; set; }
                public List<Column> columns { get; set; }
                public List<List<string>> rows { get; set; }
            }

            public class JsonTableResponseClass
            {
                public List<Table>? tables { get; set; }
            }
        }
    }
}