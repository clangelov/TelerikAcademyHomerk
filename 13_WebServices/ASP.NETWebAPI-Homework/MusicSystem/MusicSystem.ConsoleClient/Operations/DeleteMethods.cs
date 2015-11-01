namespace MusicSystem.ConsoleClient.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public static class DeleteMethods
    {
        public static void DeleteSomgById(HttpClient client, int id)
        {
            Console.Write("Deleting song with id {0}... ", id);

            HttpResponseMessage response = client.DeleteAsync("api/Song/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
