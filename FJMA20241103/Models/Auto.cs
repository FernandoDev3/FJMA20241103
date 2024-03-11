using System;
using System.Collections.Generic;

namespace FJMA20241103.Models
{
    public partial class Auto
    {
        public Auto()
        {
            ComponenteCarros = new HashSet<ComponenteCarro>();
        }

        public int IdAuto { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Anio { get; set; }

        public virtual ICollection<ComponenteCarro> ComponenteCarros { get; set; }
    }
}
