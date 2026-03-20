namespace ITelectFinal.Utils
{
    public static class Logger
    {
        private static readonly object _lock = new();

        public static void Log(string message)
        {
            try
            {
                var line = $"{DateTime.Now:O}: {message}{Environment.NewLine}";
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
                lock (_lock)
                {
                    File.AppendAllText(path, line);
                }
            }
            catch
            {
                // never throw from logger
            }
        }
    }
}

