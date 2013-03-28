namespace InsuranceBroker.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrokerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brokers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Telephone = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brokers");
        }
    }
}
