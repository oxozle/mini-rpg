// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.BuyItemActionResult.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System;
using Oxozle.MiniRPG.Engine.Actions.Base;
using Oxozle.MiniRPG.Engine.Enums;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.Engine.Actions
{
    internal sealed class BuyItemAction : ShopActionBase, IAction
    {
        private readonly ItemTypes _type;

        public BuyItemAction(ItemTypes type)
        {
            _type = type;
        }

        public ActionResultBase Process(GameState state, GameConfiguration config)
        {
            BuyItemActionResult result = new BuyItemActionResult();

            if (!CanApply(state, config))
            {
                result.IsSuccessful = false;
                return result;
            }

            ShopConfiguration shop = GetShop(config);

            Item newItem = new Item();
            newItem.ItemType = _type;
            newItem.Price = shop.Price;

            result.EffectResult = GetItemEffect(shop);

            switch (_type)
            {
                case ItemTypes.Awmor:
                    newItem.Health = result.EffectResult;
                    break;
                case ItemTypes.Weapon:
                    newItem.Damage = result.EffectResult;
                    break;
            }


            state.CurrentPlayer.ApplyItem(newItem);
            state.CurrentPlayer.DecreaseCoins(shop.Price);

            return result;
        }

        public bool CanApply(GameState state, GameConfiguration config)
        {
            ShopConfiguration shop = GetShop(config);
            if (state.CurrentPlayer.Coins < shop.Price)
            {
                return false;
            }
            return true;
        }

        public ActionTypes Type
        {
            get
            {
                switch (_type)
                {
                    case ItemTypes.Awmor:
                        return ActionTypes.BuyArmor;
                    case ItemTypes.Weapon:
                    default:
                        return ActionTypes.BuyWeapon;
                }
            }
        }

        /// <summary>
        /// Returns shop info by ItemType
        /// </summary>
        private ShopConfiguration GetShop(GameConfiguration config)
        {
            ShopConfiguration shop = null;
            switch (_type)
            {
                case ItemTypes.Awmor:
                    shop = config.Shops.Armor;
                    break;
                case ItemTypes.Weapon:
                    shop = config.Shops.Weapon;
                    break;
            }

            if (shop == null)
                throw new ArgumentOutOfRangeException("itemType", "ItemType should be Armor or Weapon");


            return shop;
        }
    }

    public sealed class BuyItemActionResult : ActionResultBase
    {
        public int EffectResult { get; set; }
    }
}