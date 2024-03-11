using System;
using System.Collections.Generic;

namespace FJMA20241103.Models
{
    public partial class ComponenteCarro
    {
        public int IdComponente { get; set; }
        public int? IdAuto { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual Auto? IdAutoNavigation { get; set; }
    }
}
