using TaviscaAssignment.Models;

namespace TaviscaAssignment.Contracts
{
    internal interface IUserInputService
    {
        /// <summary>
        /// Contract to fetch user input and return as an array
        /// </summary>
        /// <returns> Array containing user input for 10 frames.</returns>
        BowlingFrameScore[] FetchUserInput();
    }
}
