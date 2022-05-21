namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surname = c.String(),
                        last_name = c.String(),
                        faculty = c.String(),
                        major = c.String(),
                        degree = c.String(),
                        status = c.String(),
                        studStatus = c.String(),
                        facultyNumber = c.String(),
                        year = c.Int(nullable: false),
                        flow = c.Int(nullable: false),
                        group = c.Int(nullable: false),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        ValidDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        FacNum = c.String(),
                        role = c.Int(nullable: false),
                        ActiveTo = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Students");
        }
    }
}
