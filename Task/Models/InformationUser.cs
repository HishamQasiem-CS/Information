using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class InformationUser
    {
        public int InformationUserId { get; set; }
        [Display(Name ="Name the User")]
        [Required(ErrorMessage ="Enter the User Name")]
        public string FullName { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Enter the Phone Number")]
        
        public string PhoneNumber { get; set; }
        [Display(Name = "Guender")]
        [Required(ErrorMessage = "Choose the Guender")]
        public Guender Guender { get; set; }
        public decimal Salary { get; set; }
        public DateTime Registration { get; set; } = DateTime.Now;
        [Display(Name = "Email ")]
        [Required(ErrorMessage = "Enter the Email")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Address ")]
        [Required(ErrorMessage = "Enter the Address")]
        public string Address { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Enter the Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter the City")]
        public string City { get; set; }
    }
    public enum Guender
    {
        Male,Female
    }
}
