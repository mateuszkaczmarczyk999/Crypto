namespace CryptoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrecisionToCurrencyValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Currencies", "Value", c => c.Decimal(nullable: false, precision: 38, scale: 19));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Currencies", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
