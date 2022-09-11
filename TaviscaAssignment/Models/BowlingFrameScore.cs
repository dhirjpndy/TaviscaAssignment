namespace TaviscaAssignment.Models
{
    /// <summary>
    /// Model to represents a frame in bowling game
    /// </summary>
    public class BowlingFrameScore
    {
        /// <summary>
        /// To store how many pins down in first throw
        /// </summary>
        public int FirstThrowScore { get; set; }

        /// <summary>
        /// To store how many pins down in second throw
        /// </summary>
        public int SecondThrowScore { get; set; }

        /// <summary>
        /// In special scenario like last frame, there can be a thrd throw
        /// To store how many pins down in third throw, default is set to 0
        /// </summary>
        public int ThirdThrowScore { get; set; } = 0;

        /// <summary>
        /// A strike is when the player knocks down all 10 pins on his first throw itself.
        /// </summary>
        /// <returns> Flag indicating this frame is strike or not.</returns>
        public bool IsStrike()
        {
            return FirstThrowScore == 10 ? true : false;
        }

        /// <summary>
        /// A spare is when the player knocks down all 10 pins in two throws.
        /// We should first check if the frame is a strike or not.
        /// </summary>
        /// <returns> Flag indicating this frame is spare or not.</returns>
        public bool IsSpare()
        {
            return !IsStrike() && (FirstThrowScore + SecondThrowScore == 10) ? true : false;
        }
    }
}
