﻿namespace IntelligentUserProfileApp;

public static class DateTimeExtensions
{
    public static int GetAge(this DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
}