namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Direccions", "Sector", c => c.String(nullable: false));
            AlterColumn("dbo.Direccions", "Calle", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "Apellido", c => c.String(nullable: false));
            AlterColumn("dbo.Personas", "Genero", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personas", "Genero", c => c.String());
            AlterColumn("dbo.Personas", "Apellido", c => c.String());
            AlterColumn("dbo.Personas", "Nombre", c => c.String());
            AlterColumn("dbo.Direccions", "Calle", c => c.String());
            AlterColumn("dbo.Direccions", "Sector", c => c.String());
        }
    }
}
