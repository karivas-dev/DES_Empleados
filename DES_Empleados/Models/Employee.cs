using System.ComponentModel.DataAnnotations;

namespace DES_Empleados.Models
{
    public class Employee
    {
        //nombre, el apellido, la fecha de contratación y el puesto
        [Required]
        public string id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string lastname { get; set; }

        [Required]
        public DateTime hireDate { get; set; }

        [Required]
        [StringLength(50)]
        public string position { get; set; }
    }
}
