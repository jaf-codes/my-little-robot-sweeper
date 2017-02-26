using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheLittleSweeperThatCould.Test
{
    [TestClass]
    public class GridTests
    {
        private Grid target;

        [TestInitialize]
        public void InitializeTest()
        {
            target = new Grid(10);
        }
        
        [TestMethod]
        public void RetrieveNext_North()
        {

        }


    }
}
