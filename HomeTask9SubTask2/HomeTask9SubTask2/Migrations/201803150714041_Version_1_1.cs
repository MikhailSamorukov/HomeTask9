namespace HomeTask9SubTask2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Version_1_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCard",
                c => new
                {
                    CardNumber = c.Int(nullable: false, identity: true),
                    ExpirationDate = c.DateTime(nullable: true),
                    CardHolder = c.String(nullable: true, maxLength: 30),
                    EmployeeID = c.Int(),
                })
                .PrimaryKey(t => t.CardNumber)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.CreditCard", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.CreditCard", new[] { "EmployeeID" });
            DropTable("dbo.CreditCard");
        }
    }
}
