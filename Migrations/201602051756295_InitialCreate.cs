namespace Training4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Office = c.String(),
                        Role = c.String(),
                        Date = c.DateTime(nullable: false),
                        Topic = c.String(),
                        Course = c.String(),
                        Format = c.String(),
                        Time = c.String(),
                        Url = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CEU = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Contractor = c.String(),
                        Location = c.String(),
                        Stars = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Review = c.String(),
                        Recommend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trainings");
        }
    }
}
