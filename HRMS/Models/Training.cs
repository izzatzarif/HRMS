using System;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TrainingName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        [Required]
        [StringLength(100)]
        public string Location { get; set; }
    }
}
