using Npgsql;

namespace Project.Configuration.Database.Helper
{
    public static class WaitForConnection
    {
        private const int DefaultMaxRetries = 10;
        private static readonly TimeSpan DefaultDelay = TimeSpan.FromSeconds(5);

        public static async Task<bool> Implement(
            string connectionString,
            ILogger logger,
            int maxRetries = DefaultMaxRetries,
            TimeSpan? delay = null
            )
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Connection string cannot be null or empty");

            delay ??= DefaultDelay;
            for (int i = 1; i <= maxRetries; i++)
            {
                try
                {
                    using var connection = new NpgsqlConnection(connectionString);
                    await connection.OpenAsync();
                    logger.LogInformation("Database is ready to use");
                    return true;
                }
                catch (NpgsqlException ex)
                {
                    logger.LogWarning($"Attemp {i}/{maxRetries} fails: Retry in {delay.Value.TotalSeconds} secons.. {ex.Message}");
                    await Task.Delay(delay.Value);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Unexpected error during database connection attemp {i}/{maxRetries}: {ex.Message}");
                }
            }
            logger.LogError($"Could not connect to database afeter{maxRetries} attemp");
            return false;

        }
    }
}
