using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoCore.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome da Tarefa")]
        [StringLength(40, ErrorMessage = "Este campo deve conter apenas 40 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Title { get; set; }
        public bool Done { get; set; }

        [ForeignKey("TodoListId")]
        public Guid TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}