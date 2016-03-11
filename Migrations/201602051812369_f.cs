namespace Training4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "Instructor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "Instructor");
        }
    }
}
