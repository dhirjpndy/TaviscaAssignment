using System;
using TaviscaAssignment.Contracts;
using TaviscaAssignment.Models;

namespace TaviscaAssignment.Implementations
{
    internal class UserInputService : IUserInputService
    {
        BowlingFrameScore[] IUserInputService.FetchUserInput()
        {
            Console.WriteLine("Hello User!");
            var bowlingFrameScores = new BowlingFrameScore[10];

            // Loop to fetch user score for each frame
            for (int i = 0; i < 10; i++)
            {
                bowlingFrameScores[i] = new BowlingFrameScore();
                Console.WriteLine($"Enter {i + 1} Frame score: ");

                int firstThrow = Convert.ToInt32(Console.ReadLine());
                bowlingFrameScores[i].FirstThrowScore = firstThrow;

                // If the frame is strike, then skip input for second throw and set it to default 0
                if (firstThrow == 10)
                {
                    bowlingFrameScores[i].SecondThrowScore = 0;
                }
                else
                {
                    int secondThrow = Convert.ToInt32(Console.ReadLine());
                    bowlingFrameScores[i].SecondThrowScore = secondThrow;
                }
            }

            // Handle last frame input, In case of spare one extra throw is provided 
            // And for a strike 2 extra throw are provided
            if (bowlingFrameScores[bowlingFrameScores.Length - 1].IsSpare())
            {
                Console.WriteLine("You have an extra strike, Please enter the score: ");
                bowlingFrameScores[bowlingFrameScores.Length - 1].ThirdThrowScore = Convert.ToInt32(Console.ReadLine());
            }
            if (bowlingFrameScores[bowlingFrameScores.Length - 1].IsStrike())
            {
                Console.WriteLine("You have two extra strike, Please enter the score: ");
                bowlingFrameScores[bowlingFrameScores.Length - 1].SecondThrowScore = Convert.ToInt32(Console.ReadLine());
                bowlingFrameScores[bowlingFrameScores.Length - 1].ThirdThrowScore = Convert.ToInt32(Console.ReadLine());
            }

            return bowlingFrameScores;
        }
    }
}
