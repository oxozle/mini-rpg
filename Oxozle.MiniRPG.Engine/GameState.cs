// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.GameState.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.Engine
{
    public sealed class GameState
    {
        public Player CurrentPlayer { get; set; }

        /// <summary>
        /// Win attacks count
        /// </summary>
        public int Attacks { get; set; }

        public void Initialize(InitialPlayerConfiguration config)
        {
            Attacks = 0;

            CurrentPlayer = new Player();
            CurrentPlayer.Initialize(
                config.InitialPlayerHealth,
                config.InitialPlayerMaxHealth,
                config.InitialPlayerPower,
                config.InitialPlayerCoins);
        }

        public GameState DeepCopy()
        {
            return new GameState
            {
                Attacks = Attacks,
                CurrentPlayer = CurrentPlayer.DeepCopy()
            };
        }
    }
}