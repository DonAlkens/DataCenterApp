namespace DataCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIntToString : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Departments", new[] { "user_Id" });
            DropColumn("dbo.Departments", "userid");
            RenameColumn(table: "dbo.Departments", name: "user_Id", newName: "userid");
            AlterColumn("dbo.Departments", "userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.Departments", "userid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departments", new[] { "userid" });
            AlterColumn("dbo.Departments", "userid", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Departments", name: "userid", newName: "user_Id");
            AddColumn("dbo.Departments", "userid", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "user_Id");
        }
    }
}
