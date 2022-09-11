using System;
using TaviscaAssignment.Contracts;
using TaviscaAssignment.Implementations;
using TaviscaAssignment.Models;
using Xunit;

namespace Tests
{
    public class ScoreCalculatorServiceTest
    {
        #region Constructor

        private readonly IScoreCalculatorService scoreCalculatorService;
        public ScoreCalculatorServiceTest()
        {
            scoreCalculatorService = new ScoreCalculatorService();
        }
        #endregion

        #region Test Cases

        /// <summary>
        /// Test the Perfect Game.
        /// Frames be like: [ X ][ X ][ X ][ X ][ X ][ X ][ X ][ X ][ X ][X X X] 
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return 300 score when every throw is strike.")]
        public void Test1()
        {
            // Given below input
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = 10;
                input[i].SecondThrowScore = 0;
            }
            input[9].SecondThrowScore = 10;
            input[9].ThirdThrowScore = 10;

            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(300, response);
        }

        /// <summary>
        /// Test No ball down scenario.
        /// Frames be like: [ _ ][ _ ][ _ ][ _ ][ _ ][ _ ][ _ ][ _ ][ _ ][ _ ]
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return 0 score when every throw is gutter i.e. 0 pin down.")]
        public void Test2()
        {
            // Given below input
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = 0;
                input[i].SecondThrowScore = 0;
            }

            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(0, response);
        }

        /// <summary>
        /// Test when 1 pin down in each frame.
        /// Frames be like: [ 1 _ ][ 1 _ ][ 1 _ ][ 1 _ ][ 1 _ ][ 1 _ ][ 1 _ ][ 1 _ ][ 1 _ ][ 1 _ ]
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return N * 10 score when every frame has K pin down in first throw " +
            "& 0 in second meaning no spare/strike. N is any random number from 1 to 9.")]
        public void Test3()
        {
            Random r = new Random();
            int randomPinsDown = r.Next(0, 10);

            // Given below input
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = randomPinsDown;
                input[i].SecondThrowScore = 0;
            }

            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(randomPinsDown*10, response);
        }


        /// <summary>
        /// Test when every throw is 5 or every frame is spare.
        /// Frames be like: [ 5 / ][ 5 / ][ 5 / ][ 5 / ][ 5 / ][ 5 / ][ 5 / ][ 5 / ][ 5 / ][ 5 / 5]
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return 150 score when every throw is 5," +
            " meaning 10 pairs of 5 & spare with a final 5.")]
        public void Test4()
        {
            // Given below input
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = 5;
                input[i].SecondThrowScore = 5;
            }
            input[9].ThirdThrowScore = 5;

            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(150, response);
        }

        /// <summary>
        /// Test when each throw leads to 1 pin down.
        /// Frames be like: [1 1][1 1][1 1][1 1][1 1][1 1][1 1][1 1][1 1][1 1]
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return 20 score when every throw is 1 in each frame.")]
        public void Test5()
        {
            // Given below input
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = 1;
                input[i].SecondThrowScore = 1;
            }

            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(20, response);
        }

        /// <summary>
        /// Test single spare scenario.
        /// Frames be like: [5 5][1 _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ]
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return 12 score when one frame is spare followed by 1 pin dowm. All other frames are gutter.")]
        public void Test6()
        {
            // Given below input
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = 0;
                input[i].SecondThrowScore = 0;
            }
            input[0].FirstThrowScore = 5;
            input[0].SecondThrowScore = 5;
            input[1].FirstThrowScore = 1;

            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(12, response);
        }

        /// <summary>
        /// Test single strike scenario.
        /// Frames be like: [X][1 1][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ]
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return 14 score when one frame is strike followed by two 1 pin dowm throw. All other frames are gutter.")]
        public void Test7()
        {
            // Given below input
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = 0;
                input[i].SecondThrowScore = 0;
            }
            input[0].FirstThrowScore = 10;
            input[0].SecondThrowScore = 0;
            input[1].FirstThrowScore = 1;
            input[1].SecondThrowScore = 1;

            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(14, response);
        }

        /// <summary>
        /// Test random scenario. Mix of spare & strikes, taking example given in requirement.
        /// Frames be like: [X][1 1][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ][ _ _ ]
        /// </summary>
        [Fact(DisplayName = "CalculateTotalScore should return 187 score wheninput is based on example given in requirement.")]
        public void Test8()
        {
            // Given below input
            var input = PopulateInput();
        
            // When calculate total score
            var response = scoreCalculatorService.CalculateTotalScore(input);

            // Assert expectation
            Assert.Equal(187, response);
        }
        #endregion

        #region Input Data

        private BowlingFrameScore[] PopulateInput()
        {
            var input = new BowlingFrameScore[10];
            for (int i = 0; i < 10; i++)
            {
                input[i] = new BowlingFrameScore();
                input[i].FirstThrowScore = 0;
                input[i].SecondThrowScore = 0;
            }
            input[0].FirstThrowScore = 10;
            input[0].SecondThrowScore = 0;
            input[1].FirstThrowScore = 9;
            input[1].SecondThrowScore = 1;
            input[2].FirstThrowScore = 5;
            input[2].SecondThrowScore = 5;
            input[3].FirstThrowScore = 7;
            input[3].SecondThrowScore = 2;
            input[4].FirstThrowScore = 10;
            input[4].SecondThrowScore = 0;
            input[5].FirstThrowScore = 10;
            input[5].SecondThrowScore = 0;
            input[6].FirstThrowScore = 10;
            input[6].SecondThrowScore = 0;
            input[7].FirstThrowScore = 9;
            input[7].SecondThrowScore = 0;
            input[8].FirstThrowScore = 8;
            input[8].SecondThrowScore = 2;
            input[9].FirstThrowScore = 9;
            input[9].SecondThrowScore = 1;
            input[9].ThirdThrowScore = 10;

            return input;
        }

        #endregion

    }
}
