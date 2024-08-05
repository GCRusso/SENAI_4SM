using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyAPI_Test.Domains
{
    //Criando a tabela dos produtos no BD
    [Table(nameof(ProductsDomain))]

    public class ProductsDomain
    {
        [Key] //ID DO BD
        public Guid IdProduct { get; set; } = Guid.NewGuid(); //Guid para criar a HASH, criptografia do ID

        [Column (TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O NOME do produto é obrigatório!")]
        public string? Name { get; set; }

        [Column (TypeName = "DECIMAL(10,2)")]
        [Required(ErrorMessage = "O PREÇO do produto é obrigatório!")]
        public decimal? Price { get; set; }


    }
}
