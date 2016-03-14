using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoCore.Models
{
    public class TodoList
    {
        public TodoList()
        {
            Todos = new List<TodoItem>();
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome da Lista")]
        [StringLength(40, ErrorMessage = "Este campo deve conter apenas 40 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Title { get; set; }
        public ICollection<TodoItem> Todos { get; set; }
    }
}