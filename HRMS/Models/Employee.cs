using System;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama penuh diperlukan.")]
        [StringLength(100, ErrorMessage = "Nama penuh tidak boleh melebihi 100 aksara.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Jawatan diperlukan.")]
        [StringLength(50, ErrorMessage = "Jawatan tidak boleh melebihi 50 aksara.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Email diperlukan.")]
        [EmailAddress(ErrorMessage = "Format email tidak sah.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tarikh mula kerja diperlukan.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Nombor telefon diperlukan.")]
        [Phone(ErrorMessage = "Format nombor telefon tidak sah.")]
        [StringLength(15, ErrorMessage = "Nombor telefon tidak boleh melebihi 15 aksara.")]
        public string PhoneNumber { get; set; }
    }
}
