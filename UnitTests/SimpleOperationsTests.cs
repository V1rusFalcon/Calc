using Calc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class SimpleOperationsTests
    {
        [TestMethod]
        public void Sum()
        {
            var tree = new ExpressionEvaluator(new InputParser("3+4=").GetValues());
            Assert.AreEqual(7, tree.Eval());
            tree.Populate(new InputParser("6+9=").GetValues());
            Assert.AreEqual(15, tree.Eval());
        }
        [TestMethod]
        public void Sub()
        {
            var tree = new ExpressionEvaluator(new InputParser("3-4=").GetValues());
            Assert.AreEqual(-1, tree.Eval());
            tree.Populate(new InputParser("9-6=").GetValues());
            Assert.AreEqual(3, tree.Eval());
        }
    }
}