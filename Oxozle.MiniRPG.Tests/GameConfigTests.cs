// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Tests.GameConfigTests.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oxozle.MiniRPG.GameConfig.ConfigSection;
using Oxozle.MiniRPG.GameConfig.CoreReaders;
using Oxozle.MiniRPG.GameConfig.Enums;
using Oxozle.MiniRPG.GameConfig.Models;

namespace Oxozle.MiniRPG.Tests
{
    [TestClass]
    public class GameConfigTests
    {
        private GameConfigurationSection _config;
        private GameConfiguration _mappedConfig;

        [TestMethod]
        public void Game_Config_Sould_Map_Correct()
        {
            Assert.AreEqual(_mappedConfig.Battle.IncreasePowerProbability, _config.Battle.IncreasePowerProbability);
            Assert.AreEqual(_mappedConfig.Battle.LooseResult.CoinsChange, _config.Battle.LooseResult.CoinsChange);
            Assert.AreEqual(_mappedConfig.Battle.WinResult.HealthChangeType, _config.Battle.WinResult.HealthChangeType);
            Assert.AreEqual(
                _config.InitialPlayer.InitialPlayerCoins +
                _config.InitialPlayer.InitialPlayerHealth +
                _config.InitialPlayer.InitialPlayerMaxHealth +
                _config.InitialPlayer.InitialPlayerPower, 38
                );
            Assert.AreEqual(_mappedConfig.Shops.Armor.EffectFrom, _config.Shops.Armor.EffectFrom);
            Assert.AreEqual(_mappedConfig.Shops.Weapon.EffectTo, _config.Shops.Weapon.EffectTo);
            Assert.AreEqual(_mappedConfig.Shops.Heal.Price, _config.Shops.Heal.Price);
        }

        [TestInitialize]
        public void Init()
        {
            _config = new GameConfigurationSection();
            _config.Battle = new BattleElement();

            _config.Battle.IncreasePowerProbability = 1;
            _config.Battle.MaxWinProbability = 2;
            _config.Battle.MinWinProbability = 3;

            _config.Battle.LooseResult = new BattleResultElement();
            _config.Battle.WinResult = new BattleResultElement();
            _config.Battle.LooseResult.CoinsChange = 4;
            _config.Battle.LooseResult.HealthChange = 5;
            _config.Battle.LooseResult.HealthChangeType = ChangeValueTypes.Percent;

            _config.Battle.WinResult.CoinsChange = 6;
            _config.Battle.WinResult.HealthChange = 7;
            _config.Battle.WinResult.HealthChangeType = ChangeValueTypes.Value;


            _config.InitialPlayer = new InitialPlayerElement();
            _config.InitialPlayer.InitialPlayerCoins = 8;
            _config.InitialPlayer.InitialPlayerHealth = 9;
            _config.InitialPlayer.InitialPlayerMaxHealth = 10;
            _config.InitialPlayer.InitialPlayerPower = 11;

            _config.Shops = new ShopsElement();
            _config.Shops.Armor = new ShopElement();
            _config.Shops.Heal = new ShopElement();
            _config.Shops.Weapon = new ShopElement();

            _config.Shops.Armor.EffectFrom = 12;
            _config.Shops.Armor.EffectTo = 15;
            _config.Shops.Armor.Price = 13;

            _config.Shops.Heal.EffectFrom = 14;
            _config.Shops.Heal.EffectTo = 16;
            _config.Shops.Heal.Price = 17;

            _config.Shops.Weapon.EffectFrom = 18;
            _config.Shops.Weapon.EffectTo = 18;
            _config.Shops.Weapon.Price = 19;


            _mappedConfig = _config.Map();
        }
    }
}