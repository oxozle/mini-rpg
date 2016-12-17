// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.ShopsConfiguration.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

namespace Oxozle.MiniRPG.GameConfig.Models
{
    /// <summary>
    /// Все магазины в игре
    /// </summary>
    public class ShopsConfiguration
    {
        public ShopsConfiguration()
        {
            Armor = new ShopConfiguration();
            Weapon = new ShopConfiguration();
            Heal = new ShopConfiguration();
        }

        public ShopConfiguration Armor { get; set; }
        public ShopConfiguration Weapon { get; set; }
        public ShopConfiguration Heal { get; set; }
    }

    /// <summary>
    /// Магазин
    /// </summary>
    public sealed class ShopConfiguration
    {
        public int Price { get; set; }
        public int EffectFrom { get; set; }
        public int EffectTo { get; set; }
    }
}