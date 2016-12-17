// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Tests.HealActionTests.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oxozle.MiniRPG.Engine;
using Oxozle.MiniRPG.Engine.Actions;
using Oxozle.MiniRPG.Engine.Actions.Base;
using Oxozle.MiniRPG.GameConfig.Models;

namespace Oxozle.MiniRPG.Tests
{
    [TestClass]
    public class HealActionTests
    {
        private GameConfiguration config;

        [TestInitialize]
        public void Init()
        {
            config = new GameConfiguration();
            config.Shops.Heal.Price = 10;
            config.Shops.Heal.EffectFrom = 10;
            config.Shops.Heal.EffectTo = 10;
        }

        [TestMethod]
        public void Heal_Action_Should_Check_Max_Health()
        {
            GameState state = new GameState();
            state.CurrentPlayer = new Player();
            state.CurrentPlayer.Initialize(10, 15, 10, 10);


            IAction healAction = new HealAction();
            healAction.Process(state, config);
            Assert.AreEqual(state.CurrentPlayer.Health, 15);
        }

        [TestMethod]
        public void Heal_Action_Should_Add_Health_And_Decrease_Coins()
        {
            GameState state = new GameState();
            state.CurrentPlayer = new Player();
            state.CurrentPlayer.Initialize(10, 20, 10, 10);


            IAction healAction = new HealAction();
            Assert.AreEqual(healAction.CanApply(state, config), true);

            ActionResultBase actionResult = healAction.Process(state, config);
            Assert.AreEqual(actionResult.IsSuccessful, true);


            Assert.AreEqual(state.CurrentPlayer.Coins, 0);
            Assert.AreEqual(state.CurrentPlayer.Health, 20);
        }

        [TestMethod]
        public void Heal_Action_Should_Check_Player_Coins()
        {
            GameState state = new GameState();
            state.CurrentPlayer = new Player();
            state.CurrentPlayer.Initialize(10, 10, 10, 9);


            IAction healAction = new HealAction();
            Assert.AreEqual(healAction.CanApply(state, config), false);
        }
    }
}