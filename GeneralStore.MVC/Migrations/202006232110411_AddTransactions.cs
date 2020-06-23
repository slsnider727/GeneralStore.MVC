namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            AddColumn("dbo.Products", "Transaction_TransactionID", c => c.Int());
            CreateIndex("dbo.Products", "Transaction_TransactionID");
            AddForeignKey("dbo.Products", "Transaction_TransactionID", "dbo.Transactions", "TransactionID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "Transaction_TransactionID", "dbo.Transactions");
            DropIndex("dbo.Transactions", new[] { "CustomerID" });
            DropIndex("dbo.Products", new[] { "Transaction_TransactionID" });
            DropColumn("dbo.Products", "Transaction_TransactionID");
            DropTable("dbo.Transactions");
        }
    }
}
