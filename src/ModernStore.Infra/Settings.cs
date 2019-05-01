using System;

namespace ModernStore.Infra
{
    public static class Settings
    {
        //note: Don't forget do Externalize it to a Appsettings.json or something... then Get from File or something...
        public static string ConnectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=ModernStore;Trusted_Connection=True;";
    }
}
