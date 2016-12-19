namespace ecreationquery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RodzajAnkiets", "ListaAnkiet_id", "dbo.ListaAnkiets");
            DropIndex("dbo.RodzajAnkiets", new[] { "ListaAnkiet_id" });
            AddColumn("dbo.ListaAnkiets", "RodzajAnkiet_id", c => c.Int());
            AlterColumn("dbo.RodzajAnkiets", "nazwa", c => c.String(nullable: false));
            CreateIndex("dbo.ListaAnkiets", "RodzajAnkiet_id");
            AddForeignKey("dbo.ListaAnkiets", "RodzajAnkiet_id", "dbo.RodzajAnkiets", "id");
            DropColumn("dbo.RodzajAnkiets", "ListaAnkiet_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RodzajAnkiets", "ListaAnkiet_id", c => c.Int());
            DropForeignKey("dbo.ListaAnkiets", "RodzajAnkiet_id", "dbo.RodzajAnkiets");
            DropIndex("dbo.ListaAnkiets", new[] { "RodzajAnkiet_id" });
            AlterColumn("dbo.RodzajAnkiets", "nazwa", c => c.String());
            DropColumn("dbo.ListaAnkiets", "RodzajAnkiet_id");
            CreateIndex("dbo.RodzajAnkiets", "ListaAnkiet_id");
            AddForeignKey("dbo.RodzajAnkiets", "ListaAnkiet_id", "dbo.ListaAnkiets", "id");
        }
    }
}
