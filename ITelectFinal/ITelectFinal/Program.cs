namespace ITelectFinal
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += (_, e) => Utils.Logger.Log(e.Exception.ToString());
            AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                    Utils.Logger.Log(ex.ToString());
            };

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Data.DbInitializer.EnsureCreatedAndSeed();
            Application.Run(new Form1());
        }
    }
}