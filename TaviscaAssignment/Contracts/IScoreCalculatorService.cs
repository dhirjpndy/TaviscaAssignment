using TaviscaAssignment.Models;

namespace TaviscaAssignment.Contracts
{
    public interface IScoreCalculatorService
    {
        /// <summary>
        /// Contract to calculated total score of user based on frame scores as input
        /// </summary>
        /// <param name="frameScores">Array of BowlingFrameScore type</param>
        /// <returns>Total calculated score of user</returns>
        int CalculateTotalScore(BowlingFrameScore[] frameScores);
    }
}
