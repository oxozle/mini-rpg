// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.InitialPlayerElement.cs
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
    public class InitialPlayerElement : ConfigurationElement
    {
        [ConfigurationProperty("initialPlayerHealth", DefaultValue = "100", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int InitialPlayerHealth
        {
            get { return (int) this["initialPlayerHealth"]; }
            set { this["initialPlayerHealth"] = value; }
        }

        [ConfigurationProperty("initialPlayerMaxHealth", DefaultValue = "100", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int InitialPlayerMaxHealth
        {
            get { return (int) this["initialPlayerMaxHealth"]; }
            set { this["initialPlayerMaxHealth"] = value; }
        }

        [ConfigurationProperty("initialPlayerPower", DefaultValue = "1", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int InitialPlayerPower
        {
            get { return (int) this["initialPlayerPower"]; }
            set { this["initialPlayerPower"] = value; }
        }

        [ConfigurationProperty("initialPlayerCoins", DefaultValue = "2", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int InitialPlayerCoins
        {
            get { return (int) this["initialPlayerCoins"]; }
            set { this["initialPlayerCoins"] = value; }
        }
    }
}