namespace DataCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDatetimeFromEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
