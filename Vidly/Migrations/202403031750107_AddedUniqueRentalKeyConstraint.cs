namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUniqueRentalKeyConstraint : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                ALTER TABLE Rentals
                ADD CONSTRAINT MyCompositeKey
                UNIQUE (Customer_Id, Movie_Id)
            ");
        }
        
        public override void Down()
        {
        }
    }
}
