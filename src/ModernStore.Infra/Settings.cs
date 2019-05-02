using System;
using System.Collections.Generic;
using System.Text;

namespace ModernStore.Infra
{
    public static class Settings
    {
        //note: need to externalize it for some JSON or something like appsettings.json - on deploy i'm gonna do that
        public static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ModernStore;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}