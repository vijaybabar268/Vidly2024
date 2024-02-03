namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Pop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Fork')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Remix')");
        }
        
        public override void Down()
        {
        }
    }
}
