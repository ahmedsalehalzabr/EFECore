using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEClore.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="plese enter the Name ")]
        public string Name { get; set; }
        [MaxLength(5,ErrorMessage ="Max length can't be > 5 chrs")]
        public string? des {  get; set; }
        public ICollection<Student> Students { get; set; }  


    }
}
