// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.HealAction.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.Engine.Actions.Base;
using Oxozle.MiniRPG.Engine.Enums;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.Engine.Actions
{
    public class HealActionResult : ActionResultBase
    {
        public int HealAction { get; set; }
    }

    internal sealed class HealAction : ShopActionBase, IAction
    {
        public ActionResultBase Process(GameState state, GameConfiguration config)
        {
            HealActionResult result = new HealActionResult();
            if (!CanApply(state, config))
            {
                result.IsSuccessful = false;
                return result;
            }

            state.CurrentPlayer.DecreaseCoins(config.Shops.Heal.Price);
            result.HealAction = state.CurrentPlayer.ApplyHeal(GetItemEffect(config.Shops.Heal));
            return result;
        }

        public bool CanApply(GameState state, GameConfiguration config)
        {
            if (state.CurrentPlayer.Coins < config.Shops.Heal.Price)
                return false;

            return true;
        }

        public ActionTypes Type
        {
            get { return ActionTypes.Heal; }
        }
    }
}