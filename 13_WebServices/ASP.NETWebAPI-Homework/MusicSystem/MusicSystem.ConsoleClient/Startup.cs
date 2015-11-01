namespace MusicSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Data;
    using Data.Migrations;
    using Operations;

    public class Startup
    {
        /// <summary>
        /// First Start MusicSystem.Servies than
        /// use Debug -> Start new instance to run the console app.
        /// </summary>
        public static void Main()
        {
            CreateDatabase();

            var client = new HttpClient()
            {
                // change adress if needed
                BaseAddress = new Uri("http://localhost:53441/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            PostMethods.PostAlbum(client, "2Pacalypse Now", "1991", "Atron Gregory");
            PostMethods.PostAlbum(client, "Fuck the Money", "2015", "J Dilla");
            
            PostMethods.PostArtist(client, "2pac", "USA", null);
            PostMethods.PostArtist(client, "Talib Kweli", "USA", null);
            
            PostMethods.PostSong(client, "Trapped", "1991", "Rap", "2pac", "2Pacalypse Now");
            PostMethods.PostSong(client, "Every Ghetto", "2015", "Rap", "Talib Kweli", "Fuck the Money");

            GetMethods.GetAlbumsXML(client);
            GetMethods.GetArtistsJson(client);

            PutMethods.UpdateArtist(client, 2, "Talib Kweli", "Canada", null);

            DeleteMethods.DeleteSomgById(client, 2);

            Console.ReadLine();
        }        

        private static void CreateDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemDbContext, Configuration>());
            var db = new MusicSystemDbContext();
            db.Database.CreateIfNotExists();
        }
    }
}
