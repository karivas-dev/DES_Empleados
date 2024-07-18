using System.ComponentModel.DataAnnotations;

namespace DES_Empleados.Models
{
    public class Employee
    {
        //nombre, el apellido, la fecha de contratación y el puesto
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Hiring date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Position { get; set; }
    }
}
