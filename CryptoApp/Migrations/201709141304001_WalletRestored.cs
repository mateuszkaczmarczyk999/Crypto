namespace CryptoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WalletRestored : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserWallet_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "UserWallet_Id");
            AddForeignKey("dbo.AspNetUsers", "UserWallet_Id", "dbo.Wallets", "Id");
            DropColumn("dbo.AspNetUsers", "UserWalletId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserWalletId", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "UserWallet_Id", "dbo.Wallets");
            DropIndex("dbo.AspNetUsers", new[] { "UserWallet_Id" });
            DropColumn("dbo.AspNetUsers", "UserWallet_Id");
        }
    }
}
