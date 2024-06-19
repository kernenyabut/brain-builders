using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DesertSandsClassLibrary
{
    public static class DesertSandsValidation
    {
        /// <summary>
        /// Capitalizes the first letter of every word of the input string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DSCapitalize(string input)
        {
            if (input == null)
            {
                return "";
            }
            else if (Char.IsUpper(input[0]))
            {
                return input;
            }
            else
            {
                input = input.ToLower().Trim();
                string[] capArray = input.Split(' ');
                string newValue = "";
                for (int i = 0; i < capArray.Length; i++)
                {
                    for (int j = 0; j < capArray[i].Length; j++)
                    {
                        if (j == 0)
                        {
                            newValue += capArray[i][j].ToString().ToUpper();
                        }
                        else
                        {
                            newValue += capArray[i][j];
                        }
                    }
                    newValue += " ";
                }
                newValue = newValue.Trim();
                return newValue;
            }
        }

        /// <summary>
        /// removes anything that isn't a number from the input string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DSKeepNumeric(string input)
        {
            if (input == null)
            {
                return "";
            }
            else
            {
                string newValue = "";
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsNumber(input[i]))
                    {
                        newValue += input[i];
                    }
                }
                return newValue;
            }
        }

        /// <summary>
        /// check if input string is a valid address
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool DSIsAddress(string input)
        {
            Regex addressCheck = new Regex(@"^\d+\s[A-z]+(\s[A-z]+)?\s[A-z]+\.?(\s[A-z]+)?$");
            if (addressCheck.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// check if input string is numeric
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool DSIsNumeric(string input)
        {
            if (input == null)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (!Char.IsNumber(input[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Check if the input string is a valid postal code
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 

        public static bool DSPostalCodeValidation(string input)
        {
            if (input == null || input == "")
            {
                return true;
            }
            Regex postalCodeCheck = new Regex(@"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$");
            if (postalCodeCheck.IsMatch(input.ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the input string is a email address
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool DSEmailValidation(string input)
        {
            if (input == null || input == "")
            {
                return true;
            }
            Regex emailCheck = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (emailCheck.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Check if the input string is a phone number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool DSPhoneValidation(string input)
        {
            if (input == null || input == "")
            {
                return true;
            }
            Regex phoneCheck = new Regex(@"^\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");
            if (phoneCheck.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Check if the input string is a strong password
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool DSStrongPassword(string input)
        {
            if (input == null || input == "")
            {
                return true;
            }
            //regex checks for 1 or more capitals, 1 or more symbols, and 1 or more numbers
            Regex passwordCheck = new Regex(@"^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9]).{6,}$");
            if (passwordCheck.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Send back a phone number in (###)-###-#### format
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DSPhoneFormat(string input)
        {
            if (input == null || input == "")
            {
                return null;
            }

            input = input.Insert(0, "(");
            input = input.Insert(4, ")");
            input = input.Insert(5, "-");
            input = input.Insert(9, "-");
            return input;
        }

        /// <summary>
        /// Formats the postal codes to be uppercase and have a space in the middle
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 

        public static string DSPostalCodeFormat(string input)
        {
            if (input == null || input == "")
            {
                return "";
            }
            else
            {
                string newValue = input.ToUpper();
                if (newValue.Length == 6)
                {
                    newValue = newValue.Insert(3, " ");
                }
                return newValue;
            }
        }

        /// <summary>
        /// Validate and format American zipcode if validation passes
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool DSZipCodeValidation(ref string input)
        {
            string newValue;
            if (input == null || input == "")
            {
                input = "";
                return true;
            }
            else
            {
                newValue = DSKeepNumeric(input);
                if (newValue.Length == 5)
                {
                    input = newValue;
                    return true;
                }
                else if (newValue.Length == 9)
                {
                    newValue = newValue.Insert(5, "-");
                    input = newValue;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}