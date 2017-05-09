namespace ZooRestaurant.Web.Common.Constants
{
    public class ValidationConstants
    {
        //File
        public const int MaxOriginalFileNameLength = 255;
        public const int MaxFileExtensionLength = 4;

        //Meal
        public const int MaxMealNameLength = 200;

        //Message
        public const int MaxContactNameLength = 100;
        public const int MaxMessageContentLength = 1000;

        //Customer
        public const int MaxCommentLength = 100;

        //Category
        public const int MaxLengthCategoryName = 100;

        //User
        public const int MaxUserNameLength = 20;
        public const int MaxNameLength = 20;
        public const int MinNameLength = 2;
        public const int UsernameMinLength = 4;
        public const int UsernameMaxLength = 20;
        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 6;
    }
}
