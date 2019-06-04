namespace Kino_tasemetöö.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pilet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pilets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PiletiNr = c.String(),
                        Film_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KinoModels", t => t.Film_Id)
                .Index(t => t.Film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pilets", "Film_Id", "dbo.KinoModels");
            DropIndex("dbo.Pilets", new[] { "Film_Id" });
            DropTable("dbo.Pilets");
        }
    }
}
