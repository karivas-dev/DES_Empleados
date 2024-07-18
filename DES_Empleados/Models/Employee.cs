using System.ComponentModel.DataAnnotations;

namespace DES_Empleados.Models
{
    public class Employee
    {
        //nombre, el apellido, la fecha de contratación y el puesto
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }
    }
}
