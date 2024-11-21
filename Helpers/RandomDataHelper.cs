using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecFlowTestAutomationFramework.Helpers
{
    public static class RandomDataHelper
    {
        private static Random random = new Random();

        public static Dictionary<string, string> GenerateUserDetails()
        {
            string[] firstNames = { "John", "Jane", "Alice", "Bob", "Eve", "Tom", "Sara", "Mike" };
            string[] lastNames = { "Smith", "Doe", "Johnson", "Brown", "Taylor", "Anderson", "Thomas", "Jackson" };
            string[] streets = { "Elm St", "Maple Ave", "Oak Rd", "Pine Blvd", "Cedar Ln" };
            string[] cities = { "Springfield", "Riverside", "Greenville", "Fairview", "Madison" };
            string[] states = { "IL", "CA", "NY", "TX", "FL", "OH", "MI", "GA" };

            var userDetails = new Dictionary<string, string>
            {
                { "FirstName", firstNames[random.Next(firstNames.Length)] },
                { "LastName", lastNames[random.Next(lastNames.Length)] },
                { "Address", $"{random.Next(100, 999)} {streets[random.Next(streets.Length)]}" },
                { "City", cities[random.Next(cities.Length)] },
                { "State", states[random.Next(states.Length)] },
                { "ZipCode", random.Next(10000, 99999).ToString() },
                { "Phone", $"{random.Next(200, 999)}-{random.Next(200, 999)}-{random.Next(1000, 9999)}" },
                { "SSN", $"{random.Next(100, 999)}-{random.Next(10, 99)}-{random.Next(1000, 9999)}" },
                { "Username", $"user{GenerateRandomString("abcdefghijklmnopqrstuvwxyz0123456789", 5)}" },
                { "Password", GenerateRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()", 10) }
            };

            userDetails["Confirm"] = userDetails["Password"]; // Match confirm password with password
            return userDetails;
        }

        public static string GenerateRandomString(string characters, int length)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = characters[random.Next(characters.Length)];
            }
            return new string(result);
        }
    }
}
