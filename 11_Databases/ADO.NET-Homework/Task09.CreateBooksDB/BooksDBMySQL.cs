namespace Task09.CreateBooksDB
{
    using System;
    using MySql.Data.MySqlClient;

    public class BooksDBMySQL
    {
        // In order to run it you will need to have sakila db
        public static void Main()
        {
            Console.Write("Enter your pass to MySQL: ");
            string pass = Console.ReadLine();

            string connectionStr = "Server=localhost;Database=sakila;Uid=root;Pwd=" + pass + ";";

            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();

            CreateTable(connection);

            using (connection)
            {
                Book bookOne = new Book
                {
                    Title = "6.66 Euro",
                    Author = "Frederic Beigbeder",
                    PusblishDate = DateTime.Now,
                    ISBN = 123456789
                };

                Book bookTwo = new Book
                {
                    Title = "Dirty Havana Trilogy",
                    Author = "Pedro Juan Gutierrez",
                    PusblishDate = DateTime.Now,
                    ISBN = 987654321
                };

                AddBooksToDB(bookOne, connection);
                AddBooksToDB(bookTwo, connection);

                ListAllBooks(connection);

                string name = "Dirty";
                SearchBookByName(name, connection);
            }
        }

        private static void SearchBookByName(string name, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("SELECT title, author FROM books	WHERE title LIKE '%" + name + "%';", connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Books found:");
            int counter = 1;
            while (reader.Read())
            {
                Console.WriteLine("{0} -> Title \"{1}\" written by {2}", counter, reader["title"], reader["author"]);
                counter++;
            }
        }

        private static void ListAllBooks(MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("select title, author, publish, ISBN from books", connection);
            MySqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Listing all books:");
            int counter = 1;
            while (reader.Read())
            {
                var year = (DateTime)reader["publish"];
                Console.WriteLine("{0} -> Title \"{1}\" written by {2} released in {3} with ISBN {4}",
                    counter, reader["title"], reader["author"], year.Year, reader["ISBN"]);
                counter++;
            }
        }

        private static void CreateTable(MySqlConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = "CREATE TABLE books (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, title NVARCHAR(50) NOT NULL, author NVARCHAR(50) NOT NULL, publish DATE, ISBN INT);";
            command.ExecuteNonQuery();
        }

        private static void AddBooksToDB(Book book, MySqlConnection connection)
        {            
            var commandString = @"INSERT INTO Books (title, author, publish, ISBN) VALUES (@title, @author, @publishDate, @isbn)";
            var command = new MySqlCommand(commandString, connection);

            command.Parameters.AddWithValue("@title", book.Title);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@publishDate", book.PusblishDate);
            command.Parameters.AddWithValue("@isbn", book.ISBN);

            command.ExecuteNonQuery();
            var rows = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected {0}", rows);
            Console.WriteLine("Inserting book {0} written by {1} has finished", book.Title, book.Author);
        }
    }
}
