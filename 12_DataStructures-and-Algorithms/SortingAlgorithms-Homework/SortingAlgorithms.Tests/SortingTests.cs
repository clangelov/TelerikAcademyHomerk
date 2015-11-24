namespace SortingAlgorithms.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void TestIfSelectionSortWorks()
        {
            var collection = new SortableCollection<int>(new[] { 10, 15, 0, 7, 22, 21, 256, 1 });

            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void TestIfQuickSortWorks()
        {
            var collection = new SortableCollection<int>(new[] { 10, 15, 0, 7, 22, 21, 256, 1 });

            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void TestIfMergeSortWorks()
        {
            var collection = new SortableCollection<int>(new[] { 10, 15, 0, 7, 22, 21, 256, 1 });

            collection.Sort(new MergeSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i] < collection.Items[i + 1]);
            }
        }

        [TestMethod]
        public void TestIfLinearSearchReturnsTrueWhenElementIsFound()
        {
            var collection = new SortableCollection<int>(new[] { 10, 15, 0, 7, 22, 21, 256, 1 });

            bool result = collection.LinearSearch(256);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIfLinearSearchReturnsFalseWhenElementIsNotFound()
        {
            var collection = new SortableCollection<int>(new[] { 10, 15, 0, 7, 22, 21, 256, 1 });

            bool result = collection.LinearSearch(777);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIfBinarySearchReturnsTrueWhenElementIsFound()
        {
            var collection = new SortableCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            bool result = collection.BinarySearch(8);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIfBinarySearchReturnsFalseWhenElementIsNotFound()
        {
            var collection = new SortableCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            bool result = collection.BinarySearch(777);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIfShuffleWorks()
        {
            var collection = new SortableCollection<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            collection.Shuffle();
            bool shuffled = false;

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                if (collection.Items[i] > collection.Items[i + 1])
                {
                    shuffled = true;
                    break;
                }
            }

            Assert.IsTrue(shuffled);
        }
    }
}
