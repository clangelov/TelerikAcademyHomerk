namespace MusicSystem.ConsoleClient.Operations
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public static class GetMethods
    {
        public static async void GetAlbumsXML (HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            var response = client.GetAsync("api/Album/").Result;

            Console.WriteLine("All albums in XML format");

            string msg = string.Empty;
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    msg = streamReader.ReadToEnd();
                }
                Console.WriteLine(msg);
            }

            Console.WriteLine("Done!");
        }

        public static async void GetArtistsJson(HttpClient client)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("api/Artist/").Result;

            Console.WriteLine("All Artists in Json format");

            string msg = string.Empty;
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    msg = streamReader.ReadToEnd();
                }
                Console.WriteLine(msg);
            }

            Console.WriteLine("Done!");
        }
    }
}
