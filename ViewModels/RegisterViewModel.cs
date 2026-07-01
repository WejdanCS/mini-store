using System.ComponentModel.DataAnnotations;

namespace mini_store.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة")]
        public string Email { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "كلمة المرور يجب أن تكون على الاقل 6 حرفًا")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "كلمة المرور يجب أن تكون على الاقل 6 حرفًا")]
        [Compare("Password", ErrorMessage = "تأكيد كلمة المرور غير مطابق")]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "الاسم الأول مطلوب")]
        [StringLength(50, ErrorMessage = "الاسم الأول يجب أن يكون بين 2 و 50 حرفًا", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "الاسم الأخير مطلوب")]
        [StringLength(50, ErrorMessage = "الاسم الأخير يجب أن يكون بين 2 و 50 حرفًا", MinimumLength = 2)]
        public string LastName { get; set; }

        // public bool RememberMe { get; set; }
        
        // public string? ReturnUrl { get; set; }
    }
}