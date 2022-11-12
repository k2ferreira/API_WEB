using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebCRUDMVCSQL.Models
{
    public class Produtos
    {
        [Key][Display (Name = "Código do Produto")]
        public int ID { get; set; }

        [Display(Name = "Descrição")]
        public string? NomeProduto { get; set; }
    }
}
