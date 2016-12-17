// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Tests.PlayerTests.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oxozle.MiniRPG.Engine;
using Oxozle.MiniRPG.Engine.Exceptions;

namespace Oxozle.MiniRPG.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Player_Initialize_Arguments()
        {
            Player player = new Player();
            player.Initialize(20, 10, -1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof (PlayerDataException))]
        public void Player_Double_Initialize()
        {
            Player player = new Player();
            player.Initialize(10, 20, 10, 20);
            player.Initialize(10, 20, 10, 20);
        }

        [TestMethod]
        [ExpectedException(typeof (PlayerDataException))]
        public void Player_Coins_Below_Zero()
        {
            Player player = new Player();
            player.Initialize(10, 20, 10, 20);

            player.DecreaseCoins(1000);
        }

        [TestMethod]
        public void Player_Coins()
        {
            Player player = new Player();
            player.Initialize(10, 20, 10, 20);

            player.AddCoins(10);
            Assert.AreEqual(player.Coins, 30);


            player.DecreaseCoins(20);
            Assert.AreEqual(player.Coins, 10);
        }

        [TestMethod]
        public void Player_Should_Check_Health()
        {
            Player player = new Player();
            player.Initialize(10, 20, 1, 1);

            player.ApplyHeal(40);
            Assert.AreEqual(player.Health, 20);

            player.ApplyDamage(15);
            Assert.AreEqual(player.Health, 5);

            player.ApplyDamage(10);
            Assert.AreEqual(player.Health, 0);
        }

        [TestMethod]
        public void Player_Should_Init()
        {
            Player player = new Player();
            player.Initialize(1, 2, 3, 4);

            Assert.AreEqual(player.Health, 1);
            Assert.AreEqual(player.MaxHealth, 2);
            Assert.AreEqual(player.Power, 3);
            Assert.AreEqual(player.Coins, 4);
        }
    }
}