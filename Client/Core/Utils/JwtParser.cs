
using System.Security.Claims;
using System.Text.Json;

namespace Client.Core.Utils
{
    public static class JwtParser
    {
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            string? payload = jwt.Split('.')[1];
            byte[]? jsonBytes = Convert.FromBase64String(AddPadding(payload));
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs == null)
            {
                throw new InvalidOperationException("Failed to deserialize JWT payload.");
            }

            return keyValuePairs
                .Where(kvp => kvp.Value != null)
                .Select(kvp => new Claim(kvp.Key, kvp.Value!.ToString()!));
        }

        private static string AddPadding(string base64)
        {
            return base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
        }
    }
}