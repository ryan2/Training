namespace Training4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainings", "Topic", c => c.String(nullable: false));
            AlterColumn("dbo.Trainings", "Course", c => c.String(nullable: false));
            AlterColumn("dbo.Trainings", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Trainings", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainings", "Location", c => c.String());
            AlterColumn("dbo.Trainings", "Url", c => c.String());
            AlterColumn("dbo.Trainings", "Course", c => c.String());
            AlterColumn("dbo.Trainings", "Topic", c => c.String());
        }
    }
}
