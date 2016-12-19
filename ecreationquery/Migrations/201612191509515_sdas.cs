namespace ecreationquery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ListaAnkiets", "nazwaAnkiety", c => c.String(nullable: false));
            AlterColumn("dbo.ListaOdpowiedzis", "odpowiedz", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListaOdpowiedzis", "odpowiedz", c => c.String());
            AlterColumn("dbo.ListaAnkiets", "nazwaAnkiety", c => c.String());
        }
    }
}
