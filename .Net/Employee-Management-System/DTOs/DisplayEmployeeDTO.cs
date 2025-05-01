using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.DTOs
{
    public class DisplayEmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int? DepartmentId { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
    }
}
