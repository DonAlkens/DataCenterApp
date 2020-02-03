namespace DataCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDatetimeFromEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "DateCreated");
        }
    }
}
