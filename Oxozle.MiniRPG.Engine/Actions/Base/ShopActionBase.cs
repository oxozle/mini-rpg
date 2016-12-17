// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.ShopActionBase.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.Engine.Utils;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.Engine.Actions.Base
{
    internal abstract class ShopActionBase
    {
        protected int GetItemEffect(ShopConfiguration shop)
        {
            int delta = shop.EffectTo - shop.EffectFrom;
            if (delta == 0)
                return shop.EffectTo;

            return shop.EffectFrom + Generator.Next(0, delta);
        }
    }
}