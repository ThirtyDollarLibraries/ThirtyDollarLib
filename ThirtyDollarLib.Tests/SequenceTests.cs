namespace ThirtyDollarLib.Tests
{
    [TestClass]
    public class SequenceTests
    {
        [TestMethod]
        public void BasicGeneration()
        {
            List<Item> items = new() { new Item(ItemType.Boom), new Item(ItemType.Clap) };
            Sequence seq = new(items);

            string result = seq.ToString();
            Assert.AreEqual("boom@0|👏@0", result);
        }

        [TestMethod]
        public void Reserialisation()
        {
            List<Item> items = new() { new Item(ItemType.Boom), new Item(ItemType.Clap) };
            Sequence seq = new(items);

            string result = seq.ToString();
            Sequence seqP = Sequence.Parse(result);

            string result2 = seq.ToString();
            Assert.AreEqual("boom@0|👏@0", result2);
        }

        [TestMethod]
        public void RepeatCount()
        {
            List<Item> items = new() { new Item(ItemType.Boom, 0, ControlModifier.None, 10), new Item(ItemType.Clap, 0, ControlModifier.None, 10) };
            Sequence seq = new(items);

            string result = seq.ToString();
            Assert.AreEqual("boom=10@0|👏=10@0", result);
        }
    }
}