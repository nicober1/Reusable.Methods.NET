namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {
        public static async Task<DataTable> DataTableOutputSqlQueryConnectionStringOfAzureSqlDbInput(this string query,
            string connectionString)
        {
            SqlConnection connection;
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            if (connectionStringBuilder.DataSource.Contains("database.windows.net",
                    StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(connectionStringBuilder.UserID))
            {
                connection = new SqlConnection()
                {
                    ConnectionString = connectionString, AccessToken = await GetAzureSqlDbAccessToken()
                };
            }
            else
            {
                connection = new SqlConnection(connectionString);
            }

            connection.Open();
            var command = new SqlCommand(query, connection) { CommandTimeout = 600 };
            var reader = await command.ExecuteReaderAsync();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            connection.Close();
            connection.Dispose();
            await reader.DisposeAsync();
            command.Dispose();
            return dataTable;
        }

    }
}