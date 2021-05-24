# C-Sharp-HTTPClient-App-NetCore

1. Create a project. The following code should work for both .NET Framework and .NET Core applications, but I did do this with the .NET Core. 
2. Add the following namespaces: 

```csharp
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
```

3. Create an output text file by right clicking the project and hovering over Add then clicking on New Item... In the search bar type in text and then select the Text File option. I named my output text file output.txt
4. Copy the path of the output file by right clicking on it and selecting the Copy Full Path option
5. Create a variable for the output file, mine looked like the following:

```csharp
        public static string fileOutput = @"C:\Users\vdmil\source\repos\HTTPClient_APP\HTTPClient_APP\output.txt";
```

6. Write the asynchronous call to the HTTP URL

```csharp
        public static async Task<string> CallURL(string url)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(url);
            return await response;
        }
```

7. Add the following logic to the main function to get the url from the user and then await a response from the HTTPClient

```csharp
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
 ```
 
 8. Run the program and ensure the proper functionality!
