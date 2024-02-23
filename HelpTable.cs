namespace Task_3
{
    public class HelpTable
    {
        public static void TableCreation(List<string> moves, string[,] results)
        {
            int n = moves.Count;
            Console.WriteLine("HELP TABLE\n");
            Console.Write("╬═════════════╬"); 
            for(int i = 0; i < n; i++)
            {
                Console.Write("═════════════");
            }
            Console.WriteLine("╬");

            Console.Write("╬ v PC\\User > ╬");
            foreach(var move in moves)
            {
                Console.Write($"   {move,-5}   ╬");
            }
            Console.WriteLine();

            Console.Write("╬═════════════╬");
            for (int i = 0; i < n; i++)
            {
                Console.Write("════════════╬");
            }
            Console.WriteLine();

            for(int i = 0;i < n; i++)
            {
                Console.Write($"║   {moves[i],-5}   ║");
                for(int j = 0; j < n; j++)
                {
                    Console.Write($"   {results[i, j]  ,-5} ║");
                }
                Console.WriteLine() ;
            }

            Console.Write("╬═════════════╬");
            for(int i = 0; i < n; i++)
            {
                Console.Write("════════════╬");
            }
            Console.WriteLine();
        }
    }
}
