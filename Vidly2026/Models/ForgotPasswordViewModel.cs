using System.ComponentModel.DataAnnotations;

namespace Vidly2026.Models
{

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
