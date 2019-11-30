using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ball position
            int ballStartXPos = (Console.WindowWidth / 2) - (Console.WindowWidth / 2 / 2);
            int ballStartYPos = (Console.WindowHeight / 2) - (Console.WindowHeight / 2 / 2);

            // Racket position
            int racketStartXPos = Console.WindowWidth / 2 - 5;
            int racketYPos = Console.WindowHeight - 2;

            // Current position
            int ballXPos = ballStartXPos;
            int ballYPos = ballStartYPos;
            int racketXPos = racketStartXPos;

            // Ball speed
            int ballXSpeed = 1;
            int ballYSpeed = 1;

            int racketSpeed = 2;
            bool alive = true;
            string gameOver = "Game Over!";

            Console.CursorVisible = false;
            Console.Title = "Pong";

            DrawBall(ballStartXPos, ballStartYPos);
            DrawRacket(racketStartXPos, racketYPos);

            while (alive)
            {
                ballXPos += ballXSpeed;
                ballYPos += ballYSpeed;

                if (ballYPos == racketYPos - 1 && ballXPos >= racketXPos && ballXPos <= racketXPos + 10)
                {
                    ballYSpeed = -ballYSpeed;
                }

                if (ballXPos >= Console.WindowWidth)
                    ballXSpeed = -ballXSpeed;
                if (ballXPos <= 0)
                    ballXSpeed = -ballXSpeed;
                if (ballYPos <= 0)
                    ballYSpeed = -ballYSpeed;
                
                if (ballYPos == racketYPos)
                    alive = false;

                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.LeftArrow:
                            racketXPos -= racketSpeed;
                            break;
                        case ConsoleKey.RightArrow:
                            racketXPos += racketSpeed;
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }

                Console.Clear();
                if (racketYPos != 0 && racketYPos <= Console.WindowWidth - 10)
                    DrawRacket(racketXPos, racketYPos);

                DrawBall(ballXPos, ballYPos);
                Thread.Sleep(150);
            }

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - (gameOver.Length / 2), Console.WindowHeight / 2);
            Console.Write(gameOver);
        }

        static void DrawRacket(int fromLeft, int fromTop)
        {
            Console.SetCursorPosition(fromLeft, fromTop);

            for (int i = 0; i < 10; i++)
            {
                Console.Write("=");
            }
        }

        static void DrawBall(int fromLeft, int fromTop)
        {
            Console.SetCursorPosition(fromLeft, fromTop);
            Console.Write("O");
        }
    }
}
