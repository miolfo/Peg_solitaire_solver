using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TheGameCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Expected result: ");
            string resultToFind = Console.ReadLine();
            Board.CreateBoard();
            List<List<Position>> possibleMoves = Board.GetAllPossibleMoves();

            int remainingPieces = 100;
            int gamesFinished = 0;
            int bestResult = 100;
            int noOfBest = 0;
            List<Position> savedMoves = new List<Position>();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (remainingPieces > Convert.ToInt32(resultToFind))
            {
                savedMoves.Clear();
                while (possibleMoves.Count > 0)
                {
                    int MoveToComplete = new Random().Next(possibleMoves.Count);
                    List<Position> ActualMove = possibleMoves[MoveToComplete];
                    int EndPosIndex = new Random().Next(1, ActualMove.Count);
                    Board.DoMove(ActualMove[0], ActualMove[EndPosIndex]);
                    savedMoves.Add(ActualMove[0]);
                    savedMoves.Add(ActualMove[EndPosIndex]);
                    possibleMoves = Board.GetAllPossibleMoves();
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.Spacebar:
                                Console.WriteLine("Games currently played: " + gamesFinished);
                                Console.WriteLine("Best result: " + bestResult + ", happened in "+noOfBest+" games");
                                TimeSpan ts = stopWatch.Elapsed;
                                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                ts.Hours, ts.Minutes, ts.Seconds,
                                ts.Milliseconds / 10);
                                Console.WriteLine("Time elapsed: " + elapsedTime);
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                break;
                            case ConsoleKey.Escape:
                                return;
                        }
                    }
                }
                Board.FindAllPieces();
                gamesFinished++;
                remainingPieces = Board.AllPieces.Count;
                if (bestResult == remainingPieces)
                    noOfBest++;
                if (remainingPieces < bestResult)
                {
                    bestResult = remainingPieces;
                    noOfBest = 1;
                }
                    
                Board.CreateBoard();
                possibleMoves = Board.GetAllPossibleMoves();
                //Console.WriteLine("Finished game " + gamesFinished + " with result " + remainingPieces);
            }
            Console.WriteLine("Games finished: " + gamesFinished);
            Console.WriteLine("Moves used to finish: ");
            for (int i = 0; i < savedMoves.Count; i += 2)
            {
                Console.WriteLine(savedMoves[i].x + ", " + savedMoves[i].y + " to " + savedMoves[i + 1].x + ", " + savedMoves[i + 1].y);
            }
        }
        
    }
}
