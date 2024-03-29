﻿namespace KinoPoisk.DataAccessLayer {
    public static class Constants {
        public const string NameRoleUser = "User"; 
        public const string NameRoleAdmin = "Admin";

        public const int MaxLenOfName = 50;
        public const int MinLenOfName = 3;
        public const int MaxLenOfEmail = 50;
        public const int MinLenOfEmail = 5; 
        public const int MaxLenOfPassword = 30;
        public const int MinLenOfPassword = 6;
        public const int MaxLenOfNameAward = 100;
        public const int MaxLenOfPath = 100;
        public const int MaxLenOfTitleMovie = 100;
        public const int MaxLenOfDecriptionMovie = 500;
        public const int MaxLenOfComment = 200;
        public const uint MinMinAge = 0;
        public const uint MaxMinAge = 18;
        public const uint MaxLenOfValueAgeCategory = 100;
        public const uint MaxAllowDurationInMinutes = 1000;
        public const decimal MaxAllowBudgetInDollars = decimal.MaxValue;
        public const decimal MaxAllowWorldFeesInDollars = decimal.MaxValue;
        public const int CountValidateYear = -200;
        public const int MinValueRatingMovie = 0;
        public const int MaxValueRatingMovie = 5;
    }
}
