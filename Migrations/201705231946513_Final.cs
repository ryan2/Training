namespace Training4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
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
                        Topic = c.String(nullable: false),
                        Course = c.String(nullable: false),
                        Format = c.String(),
                        Time = c.String(),
                        Url = c.String(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        CEU = c.Decimal(precision: 18, scale: 2),
                        Contractor = c.String(),
                        Instructor = c.String(),
                        Location = c.String(nullable: false),
                        Stars = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WReview = c.String(),
                        Recommend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trainings");
            DropTable("dbo.Reviews");
        }
    }
}
