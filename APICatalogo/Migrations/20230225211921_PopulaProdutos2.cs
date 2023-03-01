using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    public partial class PopulaProdutos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
          "Values('Coca-Cola Diet','Refrigerante de Cola 350ml',5.45,'cocacoladiet.jpg',50,getdate(),1)");

            migrationBuilder.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('x-salada','Pão, hambúrger, salada e queijo',17.00,'xsalada.jpg',100,getdate(),2)");

            migrationBuilder.Sql("Insert into Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId) " +
                "Values('Bolo de Chocolate','Uma fatia do nosso delicioso bolo de chocolate',10.00,'bolodechocolate.jpg',15,getdate(),3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
