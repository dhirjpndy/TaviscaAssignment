using System;
using Microsoft.Extensions.DependencyInjection;
using TaviscaAssignment.Contracts;
using TaviscaAssignment.Implementations;

namespace TaviscaAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup Dependency Injection 
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IScoreCalculatorService, ScoreCalculatorService>()
                .AddSingleton<IUserInputService,UserInputService>()
                .BuildServiceProvider();

            var userInputService = serviceProvider.GetService<IUserInputService>();
            var scoreCalculatorService = serviceProvider.GetService<IScoreCalculatorService>();

            // Fetch user input
            var bowlingFrameScores = userInputService.FetchUserInput();

            // Caculate the total score of user
            var totalScore = scoreCalculatorService.CalculateTotalScore(bowlingFrameScores);
            Console.WriteLine($"Your Total Score is : {totalScore}");
        }
    }
}
