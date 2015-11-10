namespace Task01.BooksApiSearch
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class ConsoleClient
    {
        private const string ApiAddress = @"https://www.googleapis.com/books/v1/volumes?q=inauthor:{0}&maxResults={1}&key=AIzaSyCP9ndmRlJUCk7fcNTxKpNuqWrfKqNOgYk";

        public static void Main()
        {
            Console.Write("Please enter name of the author: ");
            string authorName = Console.ReadLine();

            Console.Write("Please enter the number of books maximum allowed is 40: ");
            int numberOfBooks = int.Parse(Console.ReadLine());

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format(ApiAddress, authorName, numberOfBooks));

            using (var responseStream = request.GetResponse().GetResponseStream())
            {
                using (var reader = new StreamReader(responseStream))
                {
                    var booksResult = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(reader.ReadToEnd());

                    booksResult.Items
                        .ForEach(b => Console.WriteLine(
                            "Author: {0} - Title: {1} - Published in {2} \n",
                            b.VolumeInfo.Authors.FirstOrDefault(), 
                            b.VolumeInfo.Title, 
                            b.VolumeInfo.PublishedDate));             
                }
            }
        }
    }
}
