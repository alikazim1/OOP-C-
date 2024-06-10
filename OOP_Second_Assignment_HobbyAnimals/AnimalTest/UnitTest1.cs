using SecondAssignment;
namespace AnimalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void checkCheerUp()
        {
            Fish fish = new Fish("Nemo", 50);
            int cheerAmount = 10;

            // Act
            fish.CheerUp(cheerAmount);

            // Assert
            Assert.AreEqual(50 + cheerAmount, fish.Exhilaration);
        }

        [TestMethod]
        public void checkMakeSadder()
        {
            Bird bird = new Bird("Hedwig", 30);
            int sadAmount = 10;

            //act
            bird.MakeSadder(sadAmount);

            Assert.AreEqual(30 - sadAmount, bird.Exhilaration);
        }

        [TestMethod]
        public void CheckModifyFish()
        {
            Fish fish = new Fish("fishy", 40);
            IMood goodMood = new Good();
            //act
            fish.Moodify(goodMood);
            //assert
            Assert.AreEqual(40+1, fish.Exhilaration);
        }

        [TestMethod]
        public void CheckModifyBird()
        {
            Bird b = new Bird("Sparrow", 25);
            IMood badMood = new Bad();
            b.Moodify(badMood);
            Assert.AreEqual(25 - 3, b.Exhilaration);

        }

        [TestMethod]
        public void DogCheckModify()
        {
            Dog doggy = new Dog("Rex", 60);
            IMood ordinaryMood = new Ordinary();
            doggy.Moodify(ordinaryMood);

            Assert.AreEqual(60, doggy.Exhilaration);
        }

        [TestMethod]
        public void GoodMood_changeFish()
        {
            Fish fi = new Fish("Goldie", 40);
            Good goodMood = new Good();
            goodMood.ChangeFish(fi);
            Assert.AreEqual(40 + 1, fi.Exhilaration);
        }


    }
}