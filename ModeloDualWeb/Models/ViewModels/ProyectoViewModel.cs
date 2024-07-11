using System.ComponentModel.DataAnnotations;

namespace ModeloDualWeb.Models.ViewModels
{
    public class ProyectoViewModel
    {
        public int IdProyecto { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name ="Código proyecto")]
        public string CodigoProyecto { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres")]
        [Display(Name = "Nombre proyecto")]
        public string NombreProyecto { get; set; } = null!;

        [Required]
        [Display(Name = "Código empresa")]
        public string CodigoEmpresa { get; set; } = null!;

        [Required]
        [Display(Name = "Matrícula alumno")]
        public string Matricula { get; set; } = null!;

    }
}
