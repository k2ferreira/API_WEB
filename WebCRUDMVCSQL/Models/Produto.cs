using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRUDMVCSQL.Models
{
    [Table ("PRODUTO")]
    public class Produto
    {
        
        [Key][Display (Name = "Código do Produto")]
        public int ID { get; set; }

        [Display(Name = "Descrição")]
        public string? NOMEPRODUTO { get; set; }
    }
}
