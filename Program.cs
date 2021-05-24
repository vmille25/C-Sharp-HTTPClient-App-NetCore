using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
namespace HTTPClient_APP
{
    class Program
    {
        public static string fileOutput = @"C:\Users\vdmil\source\repos\HTTPClient_APP\HTTPClient_APP\output.txt";
        static void Main(string[] args)
        {
            Console.Write("Enter the URL that you want an html response from: ");
            string url = Console.ReadLine();
            var awaiter = CallURL(url);
            if (awaiter.Result != "")
            {
                File.WriteAllText(fileOutput, awaiter.Result);
                Console.WriteLine("HTML Response output to " + fileOutput);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public static async Task<string> CallURL(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(url);
            return await response;
        }
    }
}
