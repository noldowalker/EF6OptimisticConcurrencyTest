
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace OldTechApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OldTechApp.DataBase.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    } 
}