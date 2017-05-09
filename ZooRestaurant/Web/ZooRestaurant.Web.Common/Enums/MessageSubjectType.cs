namespace ZooRestaurant.Web.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum MessageSubjectType
    {
        [Display(Name = "--Избери--")]
        Default = 0,
        
        [Display(Name = "Оплаквания")]
        GeneralCustomerService = 1,

        [Display(Name = "Предложения")]
        Suggestions = 2,

        [Display(Name = "Похвали")]
        Compliment = 3,

        [Display(Name = "Друго")]
        ProductSupport = 4
    }
}