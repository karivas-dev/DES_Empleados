using System.ComponentModel.DataAnnotations;

namespace DES_Empleados.Models
{
    public class ProjectAssignment
    {
        // asignación de empleados a proyectos, especificando la fecha de asignación y un rol específico que desempeña el empleado en el proyecto.
        
        [Required]
        public int Id { get; set; }

        [Required]
        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        [Required]
        public int? ProjectId { get; set; }

        public Project? Project { get; set; }

        [Required]
        [Display(Name = "Assignment date")]
        [DataType(DataType.Date)]
        public DateTime AssignmentDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; }
    }
}
