namespace Contacts.Data
{
    public static class DataConstants
    {
        public const int ContactFirstNameMaxLength = 50;
        public const int ContactFirstNameMinLength = 2;

        public const int ContactLastNameMaxLength = 50;
        public const int ContactLastNameMinLength = 5;

        public const int ContactEmailMaxLength = 60;
        public const int ContactEmailMinLength = 10;

        public const int ContactPhoneNumberMaxLength = 13;
        public const int ContactPhoneNumberMinLength = 10;


        public const string RequireErrorMessage = "Field {0} is required";
        public const string LengthErrorMessage = "Field {0} must be between {2} and {1} characters long!";
    }
}
