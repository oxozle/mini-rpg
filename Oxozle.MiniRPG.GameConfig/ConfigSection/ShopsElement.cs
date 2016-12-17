// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.ShopsElement.cs
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
    public class ShopsElement : ConfigurationElement
    {
        [ConfigurationProperty("armor")]
        public ShopElement Armor
        {
            get { return (ShopElement) this["armor"]; }
            set { this["armor"] = value; }
        }

        [ConfigurationProperty("weapon")]
        public ShopElement Weapon
        {
            get { return (ShopElement) this["weapon"]; }
            set { this["weapon"] = value; }
        }

        [ConfigurationProperty("heal")]
        public ShopElement Heal
        {
            get { return (ShopElement) this["heal"]; }
            set { this["heal"] = value; }
        }
    }

    public sealed class ShopElement : ConfigurationElement
    {
        [ConfigurationProperty("price", DefaultValue = "0", IsRequired = true)]
        public int Price
        {
            get { return (int) this["price"]; }
            set { this["price"] = value; }
        }

        [ConfigurationProperty("effectFrom", DefaultValue = "0", IsRequired = false)]
        public int EffectFrom
        {
            get { return (int) this["effectFrom"]; }
            set { this["effectFrom"] = value; }
        }

        [ConfigurationProperty("effectTo", DefaultValue = "0", IsRequired = false)]
        public int EffectTo
        {
            get { return (int) this["effectTo"]; }
            set { this["effectTo"] = value; }
        }
    }
}