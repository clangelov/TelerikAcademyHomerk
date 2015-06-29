namespace Task04.MinesweeperGame
{
    using System;
    using System.Collections.Generic;

    internal class GameEngine
    {
        private const char UnopenField = '?';
        private const char EmptyField = '-';
        private const char BombField = '*';
        private const int PlayFieldRows = 5;
        private const int PlayFieldCols = 10;
        private const int FieldsToBeCleared = 35;

        internal static void Start()
        {
            string command = string.Empty;
            char[,] playField = GenereatePlayField();
            char[,] bombPositions = AddBombsToPlayField();
            int scoreCounter = 0;
            int playerPickForRow = 0;
            int playerPickForCol = 0;
            bool hitedBomb = false;
            bool showGameIntro = true;
            bool gameIsOver = false;
            List<Player> bestPlayers = new List<Player>(6);

            do
            {
                if (showGameIntro)
                {
                    Console.WriteLine("Lets play Minesweeper!\nTry to find all fields without mines.\n" +
                        "Command 'top' shows the scoreboard.\nComand 'start' starts a new game.\n" +
                        "Command 'exit' terminates the game!\nHave fun Playing Minesweeper");
                    DisplayFieldInConsole(playField);
                    showGameIntro = false;
                }

                Console.Write("Enter row and col separated by space or a command: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out playerPickForRow) &&
                    int.TryParse(command[2].ToString(), out playerPickForCol) &&
                        playerPickForRow <= playField.GetLength(0) && playerPickForCol <= playField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        DisplayScoreBoard(bestPlayers);
                        break;
                    case "start":
                        playField = GenereatePlayField();
                        bombPositions = AddBombsToPlayField();
                        DisplayFieldInConsole(playField);
                        hitedBomb = false;
                        showGameIntro = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (bombPositions[playerPickForRow, playerPickForCol] != BombField)
                        {
                            if (bombPositions[playerPickForRow, playerPickForCol] == EmptyField)
                            {
                                FillTheNumberOfBombs(playField, bombPositions, playerPickForRow, playerPickForCol);
                                scoreCounter++;
                            }

                            if (FieldsToBeCleared == scoreCounter)
                            {
                                gameIsOver = true;
                            }
                            else
                            {
                                DisplayFieldInConsole(playField);
                            }
                        }
                        else
                        {
                            hitedBomb = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError Invalid comand\n");
                        break;
                }

                if (hitedBomb)
                {
                    DisplayFieldInConsole(bombPositions);
                    Console.WriteLine("\nBooooom! A heroic death with {0} points. Plase enter your nickname: ", scoreCounter);
                    string name = Console.ReadLine();
                    Player currentPlayer = new Player(name, scoreCounter);
                    if (bestPlayers.Count < 5)
                    {
                        bestPlayers.Add(currentPlayer);
                    }
                    else
                    {
                        for (int i = 0; i < bestPlayers.Count; i++)
                        {
                            if (bestPlayers[i].Points < currentPlayer.Points)
                            {
                                bestPlayers.Insert(i, currentPlayer);
                                bestPlayers.RemoveAt(bestPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    bestPlayers.Sort((Player first, Player second) => second.Name.CompareTo(first.Name));
                    bestPlayers.Sort((Player first, Player second) => second.Points.CompareTo(first.Points));
                    DisplayScoreBoard(bestPlayers);

                    playField = GenereatePlayField();
                    bombPositions = AddBombsToPlayField();
                    scoreCounter = 0;
                    hitedBomb = false;
                    showGameIntro = true;
                }

                if (gameIsOver)
                {
                    Console.WriteLine("\nGREAT! You managed to open all 35 cells without hitting a bomb.");
                    DisplayFieldInConsole(bombPositions);
                    Console.WriteLine("Plsease enter your nickname: ");
                    string name = Console.ReadLine();
                    Player currentPlayer = new Player(name, scoreCounter);
                    bestPlayers.Add(currentPlayer);
                    DisplayScoreBoard(bestPlayers);
                    playField = GenereatePlayField();
                    bombPositions = AddBombsToPlayField();
                    scoreCounter = 0;
                    gameIsOver = false;
                    showGameIntro = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Yeahhhhh!");
            Console.WriteLine("woW, WOW, Wow.");
            Console.Read();
        }

        private static void DisplayScoreBoard(List<Player> players)
        {
            Console.WriteLine("\nPlayers:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There are no players in the scoreboard!\n");
            }
        }

        private static void FillTheNumberOfBombs(char[,] playField, char[,] bombPositions, int row, int col)
        {
            char numberOfBombs = GetNumberOfBombs(bombPositions, row, col);
            bombPositions[row, col] = numberOfBombs;
            playField[row, col] = numberOfBombs;
        }

        private static void DisplayFieldInConsole(char[,] board)
        {
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int row = 0; row < PlayFieldRows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < PlayFieldCols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        //New method for avoiding code repetition it's used by GenereatePlayField() and AddBombsToPlayField()
        private static char[,] FieldGenrator(char symbol)
        {
            char[,] board = new char[PlayFieldRows, PlayFieldCols];

            for (int row = 0; row < PlayFieldRows; row++)
            {
                for (int col = 0; col < PlayFieldCols; col++)
                {
                    board[row, col] = symbol;
                }
            }

            return board;
        }

        private static char[,] GenereatePlayField()
        {
            return GameEngine.FieldGenrator(UnopenField);
        }

        private static char[,] AddBombsToPlayField()
        {
            Random random = new Random();

            char[,] playField = GameEngine.FieldGenrator(EmptyField);

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                int randomNumberToAdd = random.Next(50);
                if (!randomNumbers.Contains(randomNumberToAdd))
                {
                    randomNumbers.Add(randomNumberToAdd);
                }
            }

            foreach (int number in randomNumbers)
            {
                int cols = number / PlayFieldCols;
                int rows = number % PlayFieldCols;
                if (rows == 0 && number != 0)
                {
                    cols--;
                    rows = PlayFieldCols;
                }
                else
                {
                    rows++;
                }

                playField[cols, rows - 1] = BombField;
            }

            return playField;
        }

        private static void AddNumberOfBombsInPlayField(char[,] playField)
        {
            int playFieldRows = playField.GetLength(0);
            int playFieldCols = playField.GetLength(1);

            for (int row = 0; row < playFieldRows; row++)
            {
                for (int col = 0; col < playFieldCols; col++)
                {
                    if (playField[row, col] != BombField)
                    {
                        char numberOfBombs = GetNumberOfBombs(playField, row, col);
                        playField[row, col] = numberOfBombs;
                    }
                }
            }
        }

        private static char GetNumberOfBombs(char[,] fieldWithBombs, int curentRow, int curentCol)
        {
            int numberOfBombs = 0;
            int row = fieldWithBombs.GetLength(0);
            int col = fieldWithBombs.GetLength(1);

            if (curentRow - 1 >= 0)
            {
                if (fieldWithBombs[curentRow - 1, curentCol] == BombField)
                {
                    numberOfBombs++;
                }
            }

            if (curentRow + 1 < row)
            {
                if (fieldWithBombs[curentRow + 1, curentCol] == BombField)
                {
                    numberOfBombs++;
                }
            }

            if (curentCol - 1 >= 0)
            {
                if (fieldWithBombs[curentRow, curentCol - 1] == BombField)
                {
                    numberOfBombs++;
                }
            }

            if (curentCol + 1 < col)
            {
                if (fieldWithBombs[curentRow, curentCol + 1] == BombField)
                {
                    numberOfBombs++;
                }
            }

            if ((curentRow - 1 >= 0) && (curentCol - 1 >= 0))
            {
                if (fieldWithBombs[curentRow - 1, curentCol - 1] == BombField)
                {
                    numberOfBombs++;
                }
            }

            if ((curentRow - 1 >= 0) && (curentCol + 1 < col))
            {
                if (fieldWithBombs[curentRow - 1, curentCol + 1] == BombField)
                {
                    numberOfBombs++;
                }
            }

            if ((curentRow + 1 < row) && (curentCol - 1 >= 0))
            {
                if (fieldWithBombs[curentRow + 1, curentCol - 1] == BombField)
                {
                    numberOfBombs++;
                }
            }

            if ((curentRow + 1 < row) && (curentCol + 1 < col))
            {
                if (fieldWithBombs[curentRow + 1, curentCol + 1] == BombField)
                {
                    numberOfBombs++;
                }
            }

            return char.Parse(numberOfBombs.ToString());
        }
    }
}
