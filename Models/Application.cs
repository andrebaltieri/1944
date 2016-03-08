using System.Collections.Generic;

namespace Guardian.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Display(Name="Nome")]
        public string Name { get; set; }
    }
}