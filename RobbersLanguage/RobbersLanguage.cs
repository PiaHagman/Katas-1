using System;
using System.Collections.Generic;
using System.Linq;

namespace RobbersLanguageSim
{
    public class RobbersLanguage
    {
        public static string Encode(string message)
        {
            //Skapar en lista av alla konsonanter
            List<char> letterList = new List<char>()
                {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z'};

            //Skapar en lista av message
            List<char> messageList = new List<char>(message);

            string robberMessage = "";


            foreach (char c in messageList)
            {
                
                if (letterList.Contains(c))
                {
                    //messageList.Add('o');
                    //messageList.Add(c);

                    robberMessage += c + "o" + c;
                }
                else
                {
                    robberMessage += c;
                }
            }

            //Gör lista till string
            //string robberMessage=messageList.ToString();

            return robberMessage;
        }
    }
}
