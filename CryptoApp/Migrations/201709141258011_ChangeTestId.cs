namespace CryptoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTestId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserWallet_Id", "dbo.Wallets");
            DropIndex("dbo.AspNetUsers", new[] { "UserWallet_Id" });
            AddColumn("dbo.AspNetUsers", "UserWalletId", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserWallet_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserWallet_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.AspNetUsers", "UserWalletId");
            CreateIndex("dbo.AspNetUsers", "UserWallet_Id");
            AddForeignKey("dbo.AspNetUsers", "UserWallet_Id", "dbo.Wallets", "Id");
        }
    }
}
