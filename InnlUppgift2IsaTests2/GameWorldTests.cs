using Microsoft.VisualStudio.TestTools.UnitTesting;
using InnlUppgift2Isa;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnlUppgift2Isa.Tests
{
    [TestClass()]
    public class PositionTest
    {
        [TestMethod()]
        public void PositionTests()
        {
            Position posA = new Position(15, 2);
            Position posB = new Position(15, 2);

            Assert.AreEqual(posA, posB);

            Position positionA = new Position(7, 8);
            Position positionB = new Position(13, -2);
            Position positionC = positionA + positionB;

            Assert.AreEqual(positionC.X, 20);
            Assert.AreEqual(positionC.Y, 6);

        }
    }

    [TestClass()]
    public class GameWorldTest
    {
        [TestMethod()]
        public void GameWorldListTest()
        {
            GameWorld gameWorld = new GameWorld(50, 20);


            int testResult = gameWorld.getGameObjects.Count;
            // Testresultatet blir 0 för att det är en tom lista
            Assert.AreEqual(testResult, 0);

            gameWorld.GenerateFood();
            // Efter mat generering läggs en mat in på listan
            int testResultAfterGeneration = gameWorld.getGameObjects.Count;

            Assert.AreEqual(testResultAfterGeneration, 1);
            // Gjorde dessa tester visste inte vilka mer tester som skulle kunna köras
        }
    }
}