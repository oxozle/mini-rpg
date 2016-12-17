// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.GameConfigurationSection.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System.Configuration;

#endregion

namespace Oxozle.MiniRPG.GameConfig.ConfigSection
{
    public sealed class GameConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("initialPlayerConfig")]
        public InitialPlayerElement InitialPlayer
        {
            get { return (InitialPlayerElement) this["initialPlayerConfig"]; }
            set { this["initialPlayerConfig"] = value; }
        }

        [ConfigurationProperty("battle")]
        public BattleElement Battle
        {
            get { return (BattleElement) this["battle"]; }
            set { this["battle"] = value; }
        }

        [ConfigurationProperty("shops")]
        public ShopsElement Shops
        {
            get { return (ShopsElement) this["shops"]; }
            set { this["shops"] = value; }
        }
    }
}