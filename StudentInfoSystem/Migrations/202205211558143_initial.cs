namespace StudentInfoSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UserName", c => c.String());
            AddColumn("dbo.Students", "Password", c => c.String());
            AddColumn("dbo.Students", "SecondName", c => c.String());
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "Speciality", c => c.String());
            AddColumn("dbo.Students", "OKS", c => c.String());
            AddColumn("dbo.Students", "Course", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Potok", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Grupa", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "name");
            DropColumn("dbo.Students", "surname");
            DropColumn("dbo.Students", "last_name");
            DropColumn("dbo.Students", "major");
            DropColumn("dbo.Students", "degree");
            DropColumn("dbo.Students", "year");
            DropColumn("dbo.Students", "flow");
            DropColumn("dbo.Students", "group");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Students", "group", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "flow", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "year", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "degree", c => c.String());
            AddColumn("dbo.Students", "major", c => c.String());
            AddColumn("dbo.Students", "last_name", c => c.String());
            AddColumn("dbo.Students", "surname", c => c.String());
            AddColumn("dbo.Students", "name", c => c.String());
            DropColumn("dbo.Students", "Grupa");
            DropColumn("dbo.Students", "Potok");
            DropColumn("dbo.Students", "Course");
            DropColumn("dbo.Students", "OKS");
            DropColumn("dbo.Students", "Speciality");
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "SecondName");
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "UserName");
        }
    }
}
