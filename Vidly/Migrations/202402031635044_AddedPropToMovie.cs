namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.Genres", "ReleaseDate");
            DropColumn("dbo.Genres", "DateAdded");
            DropColumn("dbo.Genres", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "NumberInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Genres", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
