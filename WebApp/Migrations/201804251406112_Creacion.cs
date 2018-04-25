namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sector = c.String(),
                        Calle = c.String(),
                        PersonaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Genero = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Direccions", "PersonaId", "dbo.Personas");
            DropIndex("dbo.Direccions", new[] { "PersonaId" });
            DropTable("dbo.Personas");
            DropTable("dbo.Direccions");
        }
    }
}
