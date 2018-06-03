namespace AplicacionGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        codCurso = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.codCurso);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cursos");
        }
    }
}
