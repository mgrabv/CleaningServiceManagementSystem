using CSMS.Data;

namespace CSMS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            CleaningServiceContext context = new CleaningServiceContext();
            await MyPreciousSeed.Initialize(context);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Manager_MainMenu());
        }
    }
}