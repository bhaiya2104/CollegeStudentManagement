using System.ComponentModel.DataAnnotations;
namespace CollegeStudentManagement.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "email is required ")]
        [EmailAddress(ErrorMessage ="enter valid email.")]
        public string Email { get; set; }=string.Empty;
        [Required(ErrorMessage = "mobile number is required ")]
        [RegularExpression(@"[0-9]{10}$",ErrorMessage ="enter 10 digit number.")]

        public string Mobile { get; set; } = string.Empty;
        [Required(ErrorMessage = "gender is required ")]

        public string Gender { get; set; } = string.Empty;
        [Required(ErrorMessage = "course is required ")]

        public string Course { get; set; } = string.Empty;
        [Required(ErrorMessage = "year is required ")]
        [Range(1, 3,ErrorMessage ="year must be between 1 and 3.")]
        public int Year { get; set; }
        [Required(ErrorMessage = "address is required ")]

        public string Address { get; set; }=string.Empty;
    }
}