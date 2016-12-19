namespace ecreationquery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fbf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListaOdpowiedzis", "ListaAnkiet_id", "dbo.ListaAnkiets");
            DropForeignKey("dbo.ListaAnkiets", "RodzajAnkiet_id", "dbo.RodzajAnkiets");
            DropIndex("dbo.ListaAnkiets", new[] { "RodzajAnkiet_id" });
            DropIndex("dbo.ListaOdpowiedzis", new[] { "ListaAnkiet_id" });
            CreateTable(
                "dbo.ListaPytans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Pytanie = c.String(nullable: false),
                        ListaAnkiet_id = c.Int(),
                        RodzajAnkiet_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ListaAnkiets", t => t.ListaAnkiet_id)
                .ForeignKey("dbo.RodzajAnkiets", t => t.RodzajAnkiet_id)
                .Index(t => t.ListaAnkiet_id)
                .Index(t => t.RodzajAnkiet_id);
            
            AddColumn("dbo.ListaOdpowiedzis", "listaPytans_id", c => c.Int());
            CreateIndex("dbo.ListaOdpowiedzis", "listaPytans_id");
            AddForeignKey("dbo.ListaOdpowiedzis", "listaPytans_id", "dbo.ListaPytans", "id");
            DropColumn("dbo.ListaAnkiets", "Pytanie");
            DropColumn("dbo.ListaAnkiets", "idUzyt");
            DropColumn("dbo.ListaAnkiets", "RodzajAnkiet_id");
            DropColumn("dbo.ListaOdpowiedzis", "ListaAnkiet_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListaOdpowiedzis", "ListaAnkiet_id", c => c.Int());
            AddColumn("dbo.ListaAnkiets", "RodzajAnkiet_id", c => c.Int());
            AddColumn("dbo.ListaAnkiets", "idUzyt", c => c.Int());
            AddColumn("dbo.ListaAnkiets", "Pytanie", c => c.String());
            DropForeignKey("dbo.ListaPytans", "RodzajAnkiet_id", "dbo.RodzajAnkiets");
            DropForeignKey("dbo.ListaOdpowiedzis", "listaPytans_id", "dbo.ListaPytans");
            DropForeignKey("dbo.ListaPytans", "ListaAnkiet_id", "dbo.ListaAnkiets");
            DropIndex("dbo.ListaOdpowiedzis", new[] { "listaPytans_id" });
            DropIndex("dbo.ListaPytans", new[] { "RodzajAnkiet_id" });
            DropIndex("dbo.ListaPytans", new[] { "ListaAnkiet_id" });
            DropColumn("dbo.ListaOdpowiedzis", "listaPytans_id");
            DropTable("dbo.ListaPytans");
            CreateIndex("dbo.ListaOdpowiedzis", "ListaAnkiet_id");
            CreateIndex("dbo.ListaAnkiets", "RodzajAnkiet_id");
            AddForeignKey("dbo.ListaAnkiets", "RodzajAnkiet_id", "dbo.RodzajAnkiets", "id");
            AddForeignKey("dbo.ListaOdpowiedzis", "ListaAnkiet_id", "dbo.ListaAnkiets", "id");
        }
    }
}
