using System.ComponentModel.DataAnnotations;

namespace DES_Empleados.Models
{
    public class Project
    {
        //nombre del proyecto, la descripción y la fecha de inicio
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Starting date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}
