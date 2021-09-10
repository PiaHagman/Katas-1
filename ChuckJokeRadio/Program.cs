using System;
using System.Net.Http;

namespace ChuckJokeRadio
{
    class Program
    {
        //TODO plocka även ut och visa datumet för när skämtet skapades/senast uppdaterades
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            while (true)
            {
                string url = @"https://api.chucknorris.io/jokes/random";
                string json = client.GetStringAsync(url).Result;

                string startTag = "\"value\":\"";
                int start = json.IndexOf(startTag) + startTag.Length;
                int end = json.IndexOf("\"}", start);

                string joke = json.Substring(start, end - start);

                
                string startDateCreatedTag = "\"created_at\":\"";
                int startDateIndex = json.IndexOf(startDateCreatedTag) + startDateCreatedTag.Length;
                int endDateIndex = json.IndexOf(" ", startDateIndex);

                string dateCreated = json.Substring(startDateIndex, endDateIndex - startDateIndex);

                Console.WriteLine($"{joke} \nSkapat: {dateCreated}");

                Console.WriteLine();
                Console.Write("Press enter for another joke");
                Console.ReadLine();

                Console.Clear();
            }
        }
    }
}
