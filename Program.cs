namespace Task_3
{
    class Program
    {
        public static void Play(string[] moves)
        {
            List<string> MovesList = new List<string>(moves);
            byte[] key = KeyGenerator.GenerateKey();
            Random random = new Random();
            GameRules gameRules = new GameRules(MovesList);
            string[,] results = new string[MovesList.Count, MovesList.Count];
            for (int i = 0; i < MovesList.Count; i++)
            {
                for (int j = 0; j < MovesList.Count; j++)
                {
                    results[i, j] = gameRules.DefinetheWinner(i, j);
                }
            }
            HelpTable.TableCreation(MovesList, results);
            byte[] computerKey = KeyGenerator.GenerateKey();
            int computerMoveIndex = random.Next(MovesList.Count);
            string computerMove = gameRules.GetMove(computerMoveIndex);
            string hmac = HMACGenerator.GenerateHMAC(computerMove, key);

            Console.WriteLine($"HMAC: {hmac}");
            Console.WriteLine("Available Moves: ");
            for (int i = 0; i < MovesList.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {MovesList[i]}");
            }
            Console.WriteLine("0 - Exit");
            Console.WriteLine("? - Help");

            int userMoveIndex = -1;
            do
            {
                Console.Write("Enter your move: ");
                string input = Console.ReadLine();

                if (input == "?")
                {
                    HelpTable.TableCreation(MovesList, results);
                    continue;
                }
                if (!int.TryParse(input, out userMoveIndex) || userMoveIndex > MovesList.Count || userMoveIndex < 0)
                {
                    Console.WriteLine("Wrong Input. Please enter a valid move or '?' for help.");
                    continue;
                }
                if (userMoveIndex == 0)
                    return;

                userMoveIndex--;  //adjust the index to make sure that we get a zero
                string UserMove = gameRules.GetMove(userMoveIndex);
                Console.WriteLine($"Your move: {UserMove}");
                Console.WriteLine($"Computer move: {computerMove}");

                string winner = gameRules.DefinetheWinner(userMoveIndex, computerMoveIndex);
                if (winner == "User")
                    Console.WriteLine("You Win!");
                else if (winner == "Computer")
                    Console.WriteLine("Computer win!");
                else
                    Console.WriteLine("It's a draw");

                Console.WriteLine($"HMAC key: {BitConverter.ToString(computerKey).Replace("-", "")}");

            } while (userMoveIndex != 0);
        }

        static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0 || args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Error: Incorrect number of arguments or duplicated move");
                Console.WriteLine("Example usage: dotnet run rock paper scissors spock lizard");
            }
            Play(args);
        }
    }
}

//D:\ITRANSITION\INTERNSHIP\Intership Projects\Task-2\Task_3\\

