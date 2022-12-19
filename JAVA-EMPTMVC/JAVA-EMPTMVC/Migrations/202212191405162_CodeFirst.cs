namespace JAVA_EMPTMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TcKimlik = c.String(),
                        SiniflarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Siniflars", t => t.SiniflarId, cascadeDelete: true)
                .Index(t => t.SiniflarId);
            
            CreateTable(
                "dbo.Siniflars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencis", "SiniflarId", "dbo.Siniflars");
            DropIndex("dbo.Ogrencis", new[] { "SiniflarId" });
            DropTable("dbo.Siniflars");
            DropTable("dbo.Ogrencis");
        }
    }
}
