namespace Task_3
{
    public class GameRules
    {
        private readonly List<string> moves;
        public GameRules(List<string> moves)
        {
            this.moves = moves;
        }

        public string GetMove(int index)
        {
            return moves[index]; 
        }

        public string DefinetheWinner(int UserMoveIndex, int ComputerMoveIndex)
        {
            int HalfMoves = moves.Count / 2;
            int difference = (ComputerMoveIndex - UserMoveIndex + moves.Count) % moves.Count;
            if (difference == 0)
                return "Draw";
            else if (difference <= HalfMoves)
                return "Computer";
            else
                return "User";
        }
    }
}
