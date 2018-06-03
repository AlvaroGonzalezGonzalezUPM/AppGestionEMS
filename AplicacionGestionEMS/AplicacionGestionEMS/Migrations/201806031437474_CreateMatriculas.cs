namespace AplicacionGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatriculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        IdMatricula = c.Int(nullable: false, identity: true),
                        codCurso = c.Int(nullable: false),
                        codGrupoClase = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdMatricula)
                .ForeignKey("dbo.Cursos", t => t.codCurso, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.codGrupoClase, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.codCurso)
                .Index(t => t.codGrupoClase)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "codGrupoClase", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "codCurso", "dbo.Cursos");
            DropIndex("dbo.Matriculas", new[] { "UserId" });
            DropIndex("dbo.Matriculas", new[] { "codGrupoClase" });
            DropIndex("dbo.Matriculas", new[] { "codCurso" });
            DropTable("dbo.Matriculas");
        }
    }
}
