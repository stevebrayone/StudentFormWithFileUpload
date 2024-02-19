using System.ComponentModel.DataAnnotations;

namespace studentform.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        [RegularExpression(@"^[a-z A-Z]*$", ErrorMessage = "Enter alphabets and space only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please enter your choice")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "please enter DOB")]
        [Display(Name = "date of birth")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1980", "31/12/2010", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Batch plzzz")]
        [Display(Name = "Batch")]
        [DataType(DataType.Time)]
        public DateTime BatchTime { get; set; }

        [Required(ErrorMessage = "please enter phNno")]
        [Display(Name = "Phone")]
        [Phone(ErrorMessage ="number only")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "please enter Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Format thettaan")]
        public string Emailid { get; set; }
        
        [Display(Name = "Emailid")]
        [EmailAddress(ErrorMessage = "Format thettaan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "onn enter cheyiii machaane")]
        [Display(Name = "Website")]
        [Url]
        public string WebSite { get; set; }

        [Required(ErrorMessage = "password onum vendee machaane")]
        [Display(Name = "Password")]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "same password aadik machane")]
        [Display(Name = "Confirm Password")]
        [StringLength(10)]
        [Compare("Password",ErrorMessage ="same aadikkkk mwone")]
        public string ConformPassword { get; set; }




    }
}
