// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.AttackAction.cs
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
using Oxozle.MiniRPG.Engine.Utils;
using Oxozle.MiniRPG.GameConfig.Enums;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.Engine.Actions
{
    public sealed class AttackActionResult : ActionResultBase
    {
        public bool IsWin { get; set; }
        public int Level { get; set; }
    }

    internal sealed class AttackAction : IAction
    {
        public ActionResultBase Process(GameState state, GameConfiguration config)
        {
            AttackActionResult result = new AttackActionResult();

            int winProbability =
                Math.Min(
                    config.Battle.MinWinProbability + state.CurrentPlayer.Power*config.Battle.IncreasePowerProbability,
                    config.Battle.MaxWinProbability);

            int random = Generator.Next(1, 100);

            BattleResultConfiguration battleResult = null;

            //Win
            if (random <= winProbability)
            {
                battleResult = config.Battle.WinResult;
                result.IsWin = true;
                state.Attacks++;
            }
            //Loose
            else
            {
                battleResult = config.Battle.LooseResult;
            }

            state.CurrentPlayer.ApplyDamage(-GetDamage(state.CurrentPlayer.Health, battleResult));
            state.CurrentPlayer.AddCoins(battleResult.CoinsChange);
            result.Level = state.Attacks;

            if (state.CurrentPlayer.Health <= 0)
            {
                result.IsDead = true;
            }

            return result;
        }

        public bool CanApply(GameState state, GameConfiguration config)
        {
            return true;
        }

        public ActionTypes Type
        {
            get { return ActionTypes.Attack; }
        }

        private int GetDamage(int currentHealth, BattleResultConfiguration config)
        {
            switch (config.HealthChangeType)
            {
                case ChangeValueTypes.Percent:
                    return (int) Math.Round(currentHealth*config.HealthChange/100.0);
                default:
                    return config.HealthChange;
            }
        }
    }
}