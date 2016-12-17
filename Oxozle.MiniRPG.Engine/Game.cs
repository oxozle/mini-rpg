// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.Game.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System;
using Oxozle.MiniRPG.Engine.Actions;
using Oxozle.MiniRPG.Engine.Actions.Base;
using Oxozle.MiniRPG.Engine.AI;
using Oxozle.MiniRPG.Engine.Enums;
using Oxozle.MiniRPG.GameConfig;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.Engine
{
    /// <summary>
    /// Main game class
    /// </summary>
    public class Game
    {
        private readonly GameConfiguration _config;
        private readonly GameState _gameState;

        public Game(IGameConfigReader configReader)
        {
            if (configReader == null)
                throw new ArgumentNullException("configReader");

            _config = configReader.ReadConfig();
            _gameState = new GameState();

            _gameState.Initialize(_config.InitialPlayer);
        }

        public GameState State
        {
            get { return _gameState; }
        }

        public ActionTypes GetBestMove()
        {
            GameAI ai = new GameAI();
            return ai.GetBestAction(_gameState, _config);
        }

        private void StartFromTheBeginning()
        {
            _gameState.Initialize(_config.InitialPlayer);
        }

        #region Actions

        public BuyItemActionResult BuyItem(ItemTypes itemType)
        {
            IAction butItemAction = new BuyItemAction(itemType);
            return ProcessAction<BuyItemActionResult>(butItemAction);
        }

        public HealActionResult Heal()
        {
            IAction healAction = new HealAction();
            return ProcessAction<HealActionResult>(healAction);
        }

        public AttackActionResult Attack()
        {
            IAction attackAction = new AttackAction();
            return ProcessAction<AttackActionResult>(attackAction);
        }

        private T ProcessAction<T>(IAction action) where T : ActionResultBase
        {
            ActionResultBase result = action.Process(_gameState, _config);

            if (result.IsDead)
            {
                StartFromTheBeginning();
            }

            if (result is T)
                return (T) result;

            throw new InvalidCastException(string.Format("Invalid action processor for {0}", action));
        }

        #endregion
    }
}