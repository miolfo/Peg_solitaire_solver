using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGameCSharp
{
    enum MoveDirections { UP, DOWN, LEFT, RIGHT };
    struct Position
    {
        public int x, y;
    }
    class Board
    {
        private static int[][] GameBoard;
        public static List<Position> AllPieces = new List<Position>();

        //0 = empty 1 = piece 2 = no piece
        public static void CreateBoard()
        {
            GameBoard = new int[7][];
           
            GameBoard[0] = new int[7] { 0, 0, 1, 1, 1, 0, 0 };
            GameBoard[1] = new int[7] { 0, 0, 1, 1, 1, 0, 0 };
            GameBoard[2] = new int[7] { 1, 1, 1, 1, 1, 1, 1 };
            GameBoard[3] = new int[7] { 1, 1, 1, 2, 1, 1, 1 };
            GameBoard[4] = new int[7] { 1, 1, 1, 1, 1, 1, 1 };
            GameBoard[5] = new int[7] { 0, 0, 1, 1, 1, 0, 0 };
            GameBoard[6] = new int[7] { 0, 0, 1, 1, 1, 0, 0 };

                }
            }
        }

        public static void PrintBoard()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(GameBoard[i][j]);
                }
                Console.WriteLine();
            }
        }
        //Return all moves, each list has firt the piece  to move, then its possible moves
        public static List<List<Position>> GetAllPossibleMoves()
        {
            FindAllPieces();
            List<List<Position>> AllPossibleMoves = new List<List<Position>>();
            for (int i = 0; i < AllPieces.Count; i++)
            {
                AllPossibleMoves.Add(new List<Position>());
                AllPossibleMoves[i].Add(AllPieces[i]);
                AllPossibleMoves[i].AddRange(GetPossibleMoves(AllPieces[i]));
                if (AllPossibleMoves[i].Count == 1)
                    AllPossibleMoves[i].Clear();
            }
            List<List<Position>> AllPossibleMovesR = new List<List<Position>>();
            //Parse empty lists cos im lazy
            for (int i = 0; i < AllPossibleMoves.Count; i++)
            {
                if (AllPossibleMoves[i].Count != 0)
                {
                    AllPossibleMovesR.Add(new List<Position>());
                    AllPossibleMovesR[AllPossibleMovesR.Count - 1].AddRange(AllPossibleMoves[i]);
                }
            }
            return AllPossibleMovesR;
        }


        //Return coords for a random piece
        public static Position GetRandomPiece()
        {
            FindAllPieces();
            Random rnd = new Random();
            return AllPieces[rnd.Next(AllPieces.Count)];
        }
        public static void FindAllPieces()
        {
            AllPieces.Clear();
            //find indexes of all pieces
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (GameBoard[i][j] == 1)
                    {
                        Position coord;
                        coord.x = j;
                        coord.y = i;
                        AllPieces.Add(coord);
                    }

                }
            }
        }

        //Returns list of all positions a piece can move  to
        public static List<Position> GetPossibleMoves(Position pos)
        {
            List<Position> PossibleMoves = new List<Position>();
            for(int i = 0; i < 4; i++)
            {
                Position MovePos;
                Position RemovablePos;
                switch (i)
                {

                    case 0:
                        
                        MovePos.x = pos.x;
                        MovePos.y = pos.y - 2;
                        RemovablePos.x = (pos.x + MovePos.x) / 2;
                        RemovablePos.y = (pos.y + MovePos.y) / 2;
                        if (MovePos.x < 0 || MovePos.y < 0 || MovePos.x > 6 || MovePos.y > 6)
                        {
                            break;
                        }
                        else if (GetPieceInPos(MovePos) == 2 && GetPieceInPos(RemovablePos) == 1)
                        {
                            PossibleMoves.Add(MovePos);
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 1:
                        MovePos.x = pos.x;
                        MovePos.y = pos.y + 2;
                        RemovablePos.x = (pos.x + MovePos.x) / 2;
                        RemovablePos.y = (pos.y + MovePos.y) / 2;
                        if (MovePos.x < 0 || MovePos.y < 0 || MovePos.x > 6 || MovePos.y > 6)
                        {
                            break;
                        }
                        else if (GetPieceInPos(MovePos) == 2 && GetPieceInPos(RemovablePos) == 1)
                        {
                            PossibleMoves.Add(MovePos);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                        MovePos.x = pos.x - 2;
                        MovePos.y = pos.y;
                        RemovablePos.x = (pos.x + MovePos.x) / 2;
                        RemovablePos.y = (pos.y + MovePos.y) / 2;
                        if (MovePos.x < 0 || MovePos.y < 0 || MovePos.x > 6 || MovePos.y > 6)
                        {
                            break;
                        }
                        else if (GetPieceInPos(MovePos) == 2 && GetPieceInPos(RemovablePos) == 1)
                        {
                            PossibleMoves.Add(MovePos);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        MovePos.x = pos.x + 2;
                        MovePos.y = pos.y;
                        RemovablePos.x = (pos.x + MovePos.x) / 2;
                        RemovablePos.y = (pos.y + MovePos.y) / 2;
                        if (MovePos.x < 0 || MovePos.y < 0 || MovePos.x > 6 || MovePos.y > 6)
                        {
                            break;
                        }
                        else if (GetPieceInPos(MovePos) == 2 && GetPieceInPos(RemovablePos) == 1)
                        {
                            PossibleMoves.Add(MovePos);
                            break;
                        }
                        else
                        {
                            break;
                        }
                }
        }
            return PossibleMoves;
        }

        private static int GetPieceInPos(Position pos)
        {
            return GameBoard[pos.y][pos.x];
        }
        public static void DoMove(Position start, Position end)
        {
            GameBoard[start.y][start.x] = 2;
            GameBoard[end.y][end.x] = 1;
            GameBoard[(end.y + start.y)/2][(end.x + start.x)/2] = 2;
        }
    }
}
