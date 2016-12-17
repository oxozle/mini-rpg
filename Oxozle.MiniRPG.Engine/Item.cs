// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.Item.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.Engine.Enums;

#endregion

namespace Oxozle.MiniRPG.Engine
{
    public class Item
    {
        public Item()
        {
        }

        public Item(Item copy)
        {
            ItemType = copy.ItemType;
            Damage = copy.Damage;
            Price = copy.Price;
            Health = copy.Health;
        }

        public ItemTypes ItemType { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }
        public int Health { get; set; }
    }
}