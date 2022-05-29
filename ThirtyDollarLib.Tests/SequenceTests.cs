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
    }
}