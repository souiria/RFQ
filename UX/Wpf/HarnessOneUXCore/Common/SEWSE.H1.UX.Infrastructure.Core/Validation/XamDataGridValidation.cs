using System;
using System.Net.Mail;

namespace SEWSE.H1.UX.Infrastructure.Core.Validation
{
    public class XamDataGridValidation
    {
        #region Properties
        private const string _messsageForBlank = "Should not be blank!";
        #endregion

        #region Public methods
        /// <summary>
        /// To check value for NULL or whitespaces
        /// </summary>
        /// <param name="str">Column name</param>
        /// <returns>Error or Null</returns>
        public static string CheckForBlank(string str)
        {
            string Result = string.Empty;
            if (string.IsNullOrWhiteSpace(str))
            {
                Result = _messsageForBlank;
                return Result;
            }
            return null;
        }
        /// <summary>
        /// To check value for NULL or whitespaces with given length long.
        /// </summary>
        /// <param name="str">Column name</param>
        /// <param name="length">Not greater than length</param>
        /// <returns>Error or Null</returns>
        public static string CheckForBlankWithMaxLength(string str, int length)
        {
            string Result = string.Empty;
            if (string.IsNullOrWhiteSpace(str))
            {
                Result = _messsageForBlank;
                return Result;
            }
            if (str.Length > length)
            {
                Result = "Can not be greater than " + NumberToWords(length) + " characters.";
                return Result;
            }
            return null;
        }
        /// <summary>
        /// To check value for NULL or whitespaces with given length long.
        /// </summary>
        /// <param name="str">Column name</param>
        /// <param name="length">Must be length</param>
        /// <returns>Error or Null</returns>
        public static string CheckForBlankWithFixedLength(string str, int length)
        {
            string Result = string.Empty;
            if (string.IsNullOrWhiteSpace(str))
            {
                Result = _messsageForBlank;
                return Result;
            }
            if (str.Length < length)
            {
                Result = "Must be " + NumberToWords(length) + " characters long.";
                return Result;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">Column name</param>
        /// <returns>Error or Null</returns>
        public static string CheckCurrency(string str)
        {
            string Result = string.Empty;
            if (string.IsNullOrWhiteSpace(str))
            {
                Result = _messsageForBlank;
                return Result;
            }
            if (str.Length != 3)
            {
                Result = "Must be three(3) characters long.";
                return Result;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">Column name</param>
        /// <returns>Error or Null</returns>
        public static string CheckPlantCode(string str)
        {
            string Result = string.Empty;
            if (string.IsNullOrEmpty(str))
            {
                Result = _messsageForBlank;
                return Result;
            }
            if (str.Length > 10)
            {
                Result = "Can not be greater than ten(10) characters.";
                return Result;
            }
            return null;
        }

        /// <summary>
        /// For multiple Email Check.
        /// </summary>
        /// <param name="strEmail">Emailid</param>
        /// <returns>Error or Null</returns>
        public static string CheckValidEmail(string strEmail)
        {
            string Result = string.Empty;
            if (string.IsNullOrEmpty(strEmail))
            {
                Result = _messsageForBlank;
                return Result;
            }
            if (strEmail.Length > 0)
            {
                string[] strArrEmail = strEmail.Split(';');
                foreach (string EmailID in strArrEmail)
                {
                    if (EmailID.ToString().Trim() != "")
                    {
                        if (IsValidEmailId(EmailID.ToString().Trim()) == false)
                        {
                            Result = "Invalid Email.";
                            break;
                        }
                    }
                    else
                    {
                        Result = "Invalid Email.";
                        break;
                    }
                }
                return Result;
            }
            return Result;
        }
        /// <summary>
        /// For Email
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public static bool IsValidEmailId(string emailId)
        {
            try
            {
                MailAddress m = new MailAddress(emailId);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// To check value for NULL or whitespaces with given length long.
        /// </summary>
        /// <param name="str">Column name</param>
        /// <param name="minLength">Not less than length</param>
        /// <param name="maxLength">Not greater than length</param>
        /// <returns>Error or Null</returns>
        public static string CheckForBlankWithMinMaxLength(string str, int minLength, int maxLength)
        {
            string Result = string.Empty;
            if (string.IsNullOrWhiteSpace(str))
            {
                Result = _messsageForBlank;
                return Result;
            }
            if (str.Length < minLength)
            {
                Result = "Can not be less than " + NumberToWords(minLength) + " characters.";
                return Result;
            }
            if (str.Length > maxLength)
            {
                Result = "Can not be greater than " + NumberToWords(maxLength) + " characters.";
                return Result;
            }
            return null;
        }

        public static string CheckForGreaterThanZero(string Value)
        {
            string Result = string.Empty;
            if (string.IsNullOrWhiteSpace(Convert.ToString(Value)))
            {
                Result = _messsageForBlank;
                return Result;
            }
            else if (Convert.ToInt32(Value) < 0)
            {
                Result = "Can not be less than Zero.";
                return Result;
            }
            return Result;
        }
        #endregion

        #region private methods
        private static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words + "(" + number + ")";
        }

        #endregion
    }
}
