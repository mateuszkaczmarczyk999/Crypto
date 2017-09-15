namespace CryptoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredWalletTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CurrencySignature = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Wallet_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wallets", t => t.Wallet_Id)
                .Index(t => t.Wallet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Currencies", "Wallet_Id", "dbo.Wallets");
            DropIndex("dbo.Currencies", new[] { "Wallet_Id" });
            DropTable("dbo.Currencies");
        }
    }
}
