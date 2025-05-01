using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.DTOs
{
    public class AddEmployeeDTO
    {
        [StringLength(25, MinimumLength =3)]
        public string FirstName { get; set; }
        [StringLength(25, MinimumLength = 3)]
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }
        [MaxLength(50), RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]
        public required string Email { get; set; }
        [MaxLength(15)]
        public string Position { get; set; }
    }
}
