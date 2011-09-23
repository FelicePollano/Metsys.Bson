using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Metsys.Bson.VStest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        public class Simple
        {
            public string Name { get; set; }
            public double Value { get; set; }
        }

        [TestMethod]
        public void ArrayOrig()
        {
            var array = new byte[] { 1, 2, 3, 100, 94 };
            var input = Serializer.Serialize(array);
            var o = Deserializer.Deserialize<byte[]>(input);
            Assert.AreEqual(array, o);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var x = new Simple() { Name = "Pasta", Value = 5 };
            
            var q = new Simple[] { x,x,x,x,x,x,x,x};
            var bytes = Bson.Serializer.Serialize(q);

            var z = Bson.Deserializer.Deserialize<Simple[]>(bytes);
        }
    }
}
