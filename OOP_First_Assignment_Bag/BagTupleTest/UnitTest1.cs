using BagTuple;
namespace BagTupleTest
{
    [TestClass]
    public class UnitTest1
    {
        private Bag b = new BagTuple.Bag();
        
        [TestMethod]
        public void AddCheck()
        {
            Tuple<int, int> tup = new Tuple<int, int>(1, 1);
            b.add(tup);
            Assert.AreEqual(1, b.getElem(1));

        }

        [TestMethod]
        public  void RemoveCheck()
        {
            Tuple<int,int> tup2 = new Tuple<int,int>(1,1);
            Tuple<int, int> tup3 = new Tuple<int, int>(2, 1);
            b.add(tup2);
            b.add(tup3);
            b.remove(2);
            Assert.AreEqual(1,b.getElem(1));
            Assert.ThrowsException<Bag.ElementNotInBag>(() => b.remove(6));            

        }

        [TestMethod]
        public void FreqCheck()
        {
            Tuple<int, int> tup4 = new Tuple<int, int>(1, 1);
            Tuple<int, int> tup5 = new Tuple<int, int>(2, 1);
            b.add(tup5); b.add(tup4);
            Assert.AreEqual(1, b.freq(1));
           Assert.ThrowsException<Bag.ElementNotInBag>(() => b.freq(9));
        }

        [TestMethod]
        public void SingleFreqCheck()
        {
            Tuple<int, int> tup6 = new Tuple<int, int>(1, 1);
            Tuple<int, int> tup7 = new Tuple<int, int>(2, 1);
            b.add(tup6); b.add(tup7);
            Assert.AreEqual(2, b.singleFreq());
        }




    }
}