using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)] 
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        public string FullName { get; }
        public int? DepartmentId { get; set; }
        [MaxLength(50)]
        public required string Email { get; set; }
        [MaxLength(15)]
        public string Position { get; set; }
    }
}
