using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FJMA20241103.Models
{
    public partial class Auto
    {
        public Auto()
        {
            ComponenteCarros = new List<ComponenteCarro>();
        }

        public int IdAuto { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string? Marca { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Modelo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Año")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Por favor, ingrese un año válido.")]
        public int? Anio { get; set; }

        public virtual ICollection<ComponenteCarro> ComponenteCarros { get; set; }
    }
}
