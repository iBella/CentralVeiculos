namespace Otimiza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Imagem = c.Binary(),
                        idVeiculo = c.Int(nullable: false),
                        Veiculo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Veiculoes", t => t.Veiculo_ID)
                .Index(t => t.Veiculo_ID);
            
            CreateTable(
                "dbo.Veiculoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Tipo = c.String(),
                        Proprietario = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fotoes", "Veiculo_ID", "dbo.Veiculoes");
            DropIndex("dbo.Fotoes", new[] { "Veiculo_ID" });
            DropTable("dbo.Veiculoes");
            DropTable("dbo.Fotoes");
        }
    }
}
