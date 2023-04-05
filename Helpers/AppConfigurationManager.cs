namespace JWT_Automapper_Project.Helpers
{
    static class AppConfigurationManager
    {
        public static IConfiguration AppSetting { get;}
        static AppConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }
}
