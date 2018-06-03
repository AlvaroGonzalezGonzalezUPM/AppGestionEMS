namespace AplicacionGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        evalContinua = c.Boolean(nullable: false),
                        nota_P1 = c.Single(nullable: false),
                        nota_P2 = c.Single(nullable: false),
                        nota_P3 = c.Single(nullable: false),
                        nota_P4 = c.Single(nullable: false),
                        nota_Practica = c.Single(nullable: false),
                        codCurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Cursos", t => t.codCurso, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.codCurso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluaciones", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluaciones", "codCurso", "dbo.Cursos");
            DropIndex("dbo.Evaluaciones", new[] { "codCurso" });
            DropIndex("dbo.Evaluaciones", new[] { "UserId" });
            DropTable("dbo.Evaluaciones");
        }
    }
}
