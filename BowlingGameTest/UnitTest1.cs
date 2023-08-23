using BowlingGameV3;

namespace BowlingGameTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("X X X X X X X X X X X X", 300)]
        [TestCase("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5", 150)]
        [TestCase("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)]

        public void CalcScore(string input, int exscore)
        {
            var game = new Game();

            game.Frames(input);
            int calcFrame = game.TotalScore();

            Assert.That(calcFrame, Is.EqualTo(exscore));

        }
    }
}