using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooParadise.Infrastructure.Data.Constants
{
    public static class DataConstants
    {
    }
    public static class UserConstants
    {
        public const int UserFirstNameMaxLength = 25;

        public const int UserFirstNameMinLength = 3;

        public const int UserLastNameMaxLength = 25;

        public const int UserLastNameMinLength = 3;

        public const int UsernameMaxLength = 20;

        public const int UsernameMinLength = 3;

        public const int PasswordMaxLength = 14;

        public const int PasswordMinLength = 5;

        public const int EmailMaxLength = 32;

        public const int EmailMinLength = 5;

    }
    public static class GenderConstants
    {
        public const int NameMaxLength = 6;

        public const int NameMinLength = 4;

    }

    public static class ColourConstants
    {
        public const int NameMaxLength = 15;

        public const int NameMinLength = 3;

    }

    public static class AnimalTypeConstants
    {
        public const int NameMaxLength = 15;

        public const int NameMinLength = 3;

    }
    public static class PetConstants
    {
        public const int NameMaxLength = 20;
                         
        public const int NameMinLength = 3;

        public const int MaxAge = int.MaxValue;

        public const int MinAge = 0;

        public const int ImageUrlMax = 500;

        public const int ImageUrlMin = 16;

        public const int DescriptionMaxLenght = 300;

        public const int DescriptionMinLenght = 5;
    }
    public static class ManagerConstants
    {
        public const int PhoneNumberMaxLength = 14;

        public const int PhoneNumberMinLength = 10;

        public const string PhoneNumberRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
    }
}
