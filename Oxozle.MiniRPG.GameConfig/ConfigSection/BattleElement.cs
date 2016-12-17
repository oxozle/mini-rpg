// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.BattleElement.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System.Configuration;
using Oxozle.MiniRPG.GameConfig.Enums;

#endregion

namespace Oxozle.MiniRPG.GameConfig.ConfigSection
{
    public class BattleElement : ConfigurationElement
    {
        [ConfigurationProperty("minWinProbability", DefaultValue = "40", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int MinWinProbability
        {
            get { return (int) this["minWinProbability"]; }
            set { this["minWinProbability"] = value; }
        }

        [ConfigurationProperty("maxWinProbability", DefaultValue = "70", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 100)]
        public int MaxWinProbability
        {
            get { return (int) this["maxWinProbability"]; }
            set { this["maxWinProbability"] = value; }
        }

        [ConfigurationProperty("increasePowerProbability", DefaultValue = "5", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0, MaxValue = 100)]
        public int IncreasePowerProbability
        {
            get { return (int) this["increasePowerProbability"]; }
            set { this["increasePowerProbability"] = value; }
        }

        [ConfigurationProperty("winResult")]
        public BattleResultElement WinResult
        {
            get { return (BattleResultElement) this["winResult"]; }
            set { this["winResult"] = value; }
        }

        [ConfigurationProperty("looseResult")]
        public BattleResultElement LooseResult
        {
            get { return (BattleResultElement) this["looseResult"]; }
            set { this["looseResult"] = value; }
        }
    }

    public sealed class BattleResultElement : ConfigurationElement
    {
        [ConfigurationProperty("coinsChange", DefaultValue = "0", IsRequired = false)]
        public int CoinsChange
        {
            get { return (int) this["coinsChange"]; }
            set { this["coinsChange"] = value; }
        }

        [ConfigurationProperty("healthChange", DefaultValue = "0", IsRequired = false)]
        public int HealthChange
        {
            get { return (int) this["healthChange"]; }
            set { this["healthChange"] = value; }
        }

        [ConfigurationProperty("healthChangeType", DefaultValue = "Value", IsRequired = false)]
        public ChangeValueTypes HealthChangeType
        {
            get { return (ChangeValueTypes) this["healthChangeType"]; }
            set { this["healthChangeType"] = value; }
        }
    }
}