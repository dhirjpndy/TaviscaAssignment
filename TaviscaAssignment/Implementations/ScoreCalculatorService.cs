using TaviscaAssignment.Contracts;
using TaviscaAssignment.Models;

namespace TaviscaAssignment.Implementations
{
    public class ScoreCalculatorService : IScoreCalculatorService
    {
        public int CalculateTotalScore(BowlingFrameScore[] frameScores)
        {
            int lastFrame = frameScores.Length - 1;
            int secondLastFrame = frameScores.Length - 2;
            int totalScore = 0;
            const int totalPins = 10;

            for (int i = 0; i < lastFrame; i++)
            {

                // If frame is Strike, score will depend on subsequent frames
                if (frameScores[i].IsStrike())
                {
                    // When next frame is also Strike & next frame is available, add 2nd bonus from subsequent frame
                    if (frameScores[i + 1].IsStrike() && i != secondLastFrame)
                        totalScore += totalPins + totalPins + frameScores[i + 2].FirstThrowScore;
                    // When next frame is Strike & next frame is the last frame, add 2nd bonus from the extra throw in last frame
                    else if (frameScores[i + 1].IsStrike() && i == secondLastFrame)
                        totalScore += totalPins + totalPins + frameScores[i + 1].SecondThrowScore;
                    // When next frame is spare, add bonus as 10
                    else if (frameScores[i + 1].IsSpare())
                        totalScore += totalPins + totalPins;
                    // For regular frame, add both throw of next frame as bouns
                    else
                        totalScore += totalPins + frameScores[i + 1].FirstThrowScore + frameScores[i + 1].SecondThrowScore;
                }
                // If frame is Spare
                else if (frameScores[i].IsSpare())
                {
                    totalScore += totalPins + frameScores[i + 1].FirstThrowScore;
                }
                // If frame is regular
                else
                {
                    totalScore += frameScores[i].FirstThrowScore + frameScores[i].SecondThrowScore;
                }
            }

            // Handle last frame as it might have extra throws
            if (frameScores[lastFrame].IsSpare())
                totalScore += totalPins + frameScores[lastFrame].ThirdThrowScore;
            else if (frameScores[lastFrame].IsStrike())
                totalScore += totalPins + frameScores[lastFrame].SecondThrowScore + frameScores[lastFrame].ThirdThrowScore;
            else
                totalScore += frameScores[lastFrame].FirstThrowScore + frameScores[lastFrame].SecondThrowScore;

            return totalScore;
        }
    }
}
