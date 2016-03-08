using System.ComponentModel.DataAnnotations;

namespace Guardian.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Este campo deve conter até 50 caracteres")]
        [Display(Name="Nome")]
        public string Name { get; set; }

    }
}