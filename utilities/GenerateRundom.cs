using System;

namespace Test_Automation.utilities
{
    public class GenerateRundom
    {

        public static string number()
        {
            string phone;
            Random rand = new Random();
             // 3-Digits between 100 and 999 
            int num1 = rand.Next(100, 999);
            int num2 = rand.Next(100, 999);
             // 4-Digits between 1000 and 9999 
            int num3 = rand.Next(1000, 9999);

            phone = $"{num1} {num2} {num3}";
            return phone;
        }


    }

}