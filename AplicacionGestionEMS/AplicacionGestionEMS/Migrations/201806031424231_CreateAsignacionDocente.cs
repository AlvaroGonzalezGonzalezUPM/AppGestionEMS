namespace AplicacionGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAsignacionDocente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionDocentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        codCurso = c.Int(nullable: false),
                        codGrupoClase = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.codCurso, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.codGrupoClase, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.codCurso)
                .Index(t => t.codGrupoClase)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "codGrupoClase", "dbo.GrupoClases");
            DropForeignKey("dbo.AsignacionDocentes", "codCurso", "dbo.Cursos");
            DropIndex("dbo.AsignacionDocentes", new[] { "UserId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "codGrupoClase" });
            DropIndex("dbo.AsignacionDocentes", new[] { "codCurso" });
            DropTable("dbo.AsignacionDocentes");
        }
    }
}
