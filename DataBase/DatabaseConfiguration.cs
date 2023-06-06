using System.Data.Entity;
using OldTechApp.Migrations;

namespace OldTechApp.DataBase
{
    public class DatabaseConfiguration: DbConfiguration
    {
        public DatabaseConfiguration()
        {
            SetMigrationSqlGenerator("Npgsql", () => new SqlGenerator());
        }
    }
}