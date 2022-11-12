using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebCRUDMVCSQL.Models
{
    public class USUARIOS
    {
        

        [Key]
        public int ID_USUARIO { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]

        public string? NOME_USUARIO { get; set; }

        public string? Login { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]

   
        public string? Senha { get; set; }

       
      
    }
}
