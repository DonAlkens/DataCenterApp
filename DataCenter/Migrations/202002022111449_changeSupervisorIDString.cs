namespace DataCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeSupervisorIDString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "supervisor_Id" });
            DropColumn("dbo.Employees", "SupervisorID");
            RenameColumn(table: "dbo.Employees", name: "supervisor_Id", newName: "SupervisorID");
            AlterColumn("dbo.Employees", "SupervisorID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "SupervisorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "SupervisorID" });
            AlterColumn("dbo.Employees", "SupervisorID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "SupervisorID", newName: "supervisor_Id");
            AddColumn("dbo.Employees", "SupervisorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "supervisor_Id");
        }
    }
}
