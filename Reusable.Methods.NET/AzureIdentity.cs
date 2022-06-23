namespace Reusable.Methods.NET
{
    public static partial class Reuse
    {

        

        public static async Task<string> GetAzureSqlDbAccessToken()
        {
            var tokenRequestContext = new TokenRequestContext(new[] { "https://database.windows.net/" });
            var tokenRequestResult = await new DefaultAzureCredential().GetTokenAsync(tokenRequestContext);
            return tokenRequestResult.Token;
        }

    }
}