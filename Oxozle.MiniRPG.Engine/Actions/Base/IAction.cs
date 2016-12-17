// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.IAction.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.Engine.Enums;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.Engine.Actions.Base
{
    public interface IAction
    {
        /// <summary>
        /// Action Type
        /// </summary>
        ActionTypes Type { get; }

        /// <summary>
        /// Core process action
        /// </summary>
        /// <param name="state">State to change player info</param>
        /// <param name="config">Game config with settings</param>
        /// <returns>Result of action</returns>
        ActionResultBase Process(GameState state, GameConfiguration config);

        /// <summary>
        /// True if action can be processed by game
        /// </summary>
        bool CanApply(GameState state, GameConfiguration config);
    }
}