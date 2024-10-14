using System;

namespace HRMS.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }  // Sifat untuk nama pekerja
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }  // Tarikh mula cuti
        public DateTime EndDate { get; set; }    // Tarikh akhir cuti
    }
}
