using System.Text.Json;
using CopilotRequestDriven.Models;

namespace CopilotRequestDriven.Services;

public static class DbConnectionStringService
{
    public static string GetConnectionString(string secretJsonString)
    {
        var secret = JsonSerializer.Deserialize<AwsAuroraSecret>(secretJsonString);
        return
            $"User ID={secret!.username};Password={secret.password};Host={secret.host};Port={secret.port};Database={secret.dbname};";
    }
}
