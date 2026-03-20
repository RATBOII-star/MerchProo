using System.IO;

namespace ITelectFinal.Data
{
    public static class DbPath
    {
        public static string GetDatabasePath()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Walk up until we find the project root (where ITelectFinal.csproj lives)
            var dir = new DirectoryInfo(baseDir);
            while (dir != null)
            {
                var csprojPath = Path.Combine(dir.FullName, "ITelectFinal.csproj");
                if (File.Exists(csprojPath))
                    return Path.Combine(dir.FullName, "Mydatabase.db");

                dir = dir.Parent;
            }

            // Fallback: put DB next to the executable
            return Path.Combine(baseDir, "Mydatabase.db");
        }
    }
}

