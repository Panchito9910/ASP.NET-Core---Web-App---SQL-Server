using System;
using System.Collections.Generic;

namespace ModeloDualWeb.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string CodigoEmpresa { get; set; } = null!;

    public string NombreEmpresa { get; set; } = null!;

    public string CorreoEmpresa { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
