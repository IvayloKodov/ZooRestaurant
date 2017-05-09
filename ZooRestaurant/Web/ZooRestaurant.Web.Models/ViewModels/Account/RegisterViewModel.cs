namespace ZooRestaurant.Web.Models.ViewModels.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;

    public class RegisterViewModel 
    {
        public RegisterViewModel()
        {
            this.Neighborhoods = new List<SelectListItem>();
        }

        [Required]
        [Display(Name = "���")]
        [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "{0}�o ������ �� ���� ����� {2} �������!", MinimumLength = ValidationConstants.MinNameLength)]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "�������")]
        [StringLength(ValidationConstants.MaxNameLength, ErrorMessage = "{0}�� ������ �� ���� ����� {2} �������!", MinimumLength = ValidationConstants.UsernameMinLength)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(ValidationConstants.UsernameMaxLength, ErrorMessage = "����� ������ �� ���� ����� {2} �������!", MinimumLength = ValidationConstants.UsernameMinLength)]
        [Display(Name = "������������� ���")]
        public string UserName { get; set; }

        [Required]
        [StringLength(ValidationConstants.PasswordMaxLength, ErrorMessage = "{0}�� ������ �� ���� ����� {2} �������!", MinimumLength = ValidationConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "�������� ��������")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "������������ ������ �� �������!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "�������")]
        [RegularExpression(@"(^08[789]\d{7}$)|(^\+3598[789]\d{7}$)", ErrorMessage = "������ �������!")]
        public string Phone { get; set; }

        public int TownId { get; set; }

        [Display(Name = "����")]
        public IEnumerable<SelectListItem> Towns { get; set; }

        public int NeighborhoodId { get; set; }

        [Display(Name = "�������")]
        public IEnumerable<SelectListItem> Neighborhoods { get; set; }

        [Required]
        [Display(Name = "�����")]
        [StringLength(100, ErrorMessage = "������� �� ���� �� � ��-����� �� 100 �������")]
        public string AdditionalAddress { get; set; }

        [Display(Name = "��������")]
        public string Comment { get; set; }
    }
}