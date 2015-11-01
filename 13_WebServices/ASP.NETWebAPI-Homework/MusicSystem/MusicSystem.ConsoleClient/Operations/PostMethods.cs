namespace MusicSystem.ConsoleClient.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public static class PostMethods
    {
        public static void PostArtist(HttpClient client, string name, string country, string birthdate)
        {
            Console.WriteLine("Creating artist...");

            var artist = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", name),
                new KeyValuePair<string, string>("BirthDate", birthdate),
                new KeyValuePair<string, string>("Country", country)
            });

            HttpResponseMessage response = client.PostAsync("api/Artist/", artist).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PostAlbum(HttpClient client, string title, string year, string producer)
        {
            Console.WriteLine("Creating album...");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", title),
                new KeyValuePair<string, string>("Year", year),
                new KeyValuePair<string, string>("Producer", producer)
            });

            HttpResponseMessage response = client.PostAsync("api/Album/", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PostSong(HttpClient client, string title, string year, string genre, string artist, string album)
        {
            Console.WriteLine("Creating song...");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Title", title),
                new KeyValuePair<string, string>("Year", year),
                new KeyValuePair<string, string>("Genre", genre),
                new KeyValuePair<string, string>("Artist", artist),
                new KeyValuePair<string, string>("Album", album)
            });

            HttpResponseMessage response = client.PostAsync("api/Song/", content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
