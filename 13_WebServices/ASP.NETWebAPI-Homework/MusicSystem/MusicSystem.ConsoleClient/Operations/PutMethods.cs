namespace MusicSystem.ConsoleClient.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public static class PutMethods
    {
        public static void UpdateArtist(HttpClient client, int id, string name, string country, string birthdate)
        {
            Console.WriteLine("Updating artist...");

            var artist = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", name),
                new KeyValuePair<string, string>("BirthDate", birthdate),
                new KeyValuePair<string, string>("Country", country)
            });

            HttpResponseMessage response = client.PutAsync("api/Artist/" + id, artist).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
