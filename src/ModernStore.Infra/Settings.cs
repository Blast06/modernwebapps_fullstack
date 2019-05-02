using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra
{
    public static class Settings
    {
        //note: need to externalize it for some JSON or something like appsettings.json
        public static string ConnectionString = @"Server=(LocalDB)\\MSSQLLocalDB;Database=ModernStore;Trusted_Connection=True;";
    }
}