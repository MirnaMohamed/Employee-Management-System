using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.DTOs
{
    public class DisplayEmployeeDTO
    {
        public int Id { get; set; }
        public string FullName
        {
            get; set;
        }
        public int? DepartmentId { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
    }
}
