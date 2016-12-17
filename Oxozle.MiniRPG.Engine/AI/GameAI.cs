// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.GameAI.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Oxozle.MiniRPG.Engine.Actions;
using Oxozle.MiniRPG.Engine.Actions.Base;
using Oxozle.MiniRPG.Engine.Enums;
using Oxozle.MiniRPG.GameConfig.Models;

namespace Oxozle.MiniRPG.Engine.AI
{
    /// <summary>
    /// Game AI
    /// </summary>
    internal class GameAI
    {
        /// <summary>
        /// Number of tests
        /// </summary>
        private static readonly int ProcessCount = 13;

        /// <summary>
        /// Number of test to calculate attack profit
        /// </summary>
        private static readonly int CalculateAttackCount = 10000;

        /// <summary>
        /// Steps to calculate
        /// </summary>
        private static readonly int Deep = 3;

        private GameConfiguration _config;

        /// <summary>
        /// Returns best action for selected game state and configuration
        /// </summary>
        public ActionTypes GetBestAction(GameState state, GameConfiguration config)
        {
            _config = config;

            List<Node> bestList = new List<Node>();

            Parallel.For(0, ProcessCount, index =>
            {
                Node start = new Node(state.DeepCopy());
                Node best = Iterate(start, Deep);
                bestList.Add(best);
            });

            //for (int i = 0; i < ProcessCount; i++)
            //{
            //    Node start = new Node(state.DeepCopy());
            //    Node best = Iterate(start, Deep);
            //    bestList.Add(best);
            //}

            bestList = bestList.OrderByDescending(x => x.Value).ToList();


            //medium by sum and positive value ("without" death)
            var result = bestList.Where(x => x.Value > 0).ToList();
            Node bestGroup = null;
            if (result.Count > 0)
            {
                bestGroup = result.GroupBy(x => x.ActionType)
                    .OrderByDescending(x => x.Sum(a => a.Value))
                    .First().First();
            }


            Node betsByValue = bestList.First();

            Debug.WriteLine("1 = {0}, 2 = {1}", betsByValue.ActionType,
                (bestGroup != null ? bestGroup.ActionType.ToString() : "null"));

            return (bestGroup ?? betsByValue).ActionType;
        }

        public Node Iterate(Node node, int depth)
        {
            Node best = null;
            Node childReturn = null;
            if (depth == 0 || node.State.CurrentPlayer.Health == 0)
            {
                var calcResult = Calculate(node.State);
                node.Win = calcResult.Item1;
                node.Death = calcResult.Item2;
                node.Health = node.State.CurrentPlayer.Health;
                return node;
            }

            foreach (Node child in Children(node.State))
            {
                Node iteratedNode = Iterate(child, depth - 1);

                if (best == null || iteratedNode.Value > best.Value)
                {
                    best = iteratedNode;
                    childReturn = child;
                    childReturn.Win = best.Win;
                    childReturn.Death = best.Death;
                    childReturn.Health = best.Health;
                }
            }


            if (childReturn == null)
                return node;

            return childReturn;
        }

        private List<Node> Children(GameState state)
        {
            if (state.CurrentPlayer.Health == 0)
                return new List<Node>();

            List<Node> resultNodes = new List<Node>();

            List<IAction> actions = new List<IAction>();

            actions.Add(new AttackAction());
            actions.Add(new HealAction());
            actions.Add(new BuyItemAction(ItemTypes.Weapon));
            actions.Add(new BuyItemAction(ItemTypes.Awmor));


            foreach (IAction action in actions)
            {
                GameState copy = state.DeepCopy();
                if (action.CanApply(copy, _config))
                {
                    action.Process(copy, _config);
                    resultNodes.Add(new Node(copy, action.Type));
                }
            }

            return resultNodes;
        }

        /// <summary>
        /// Calculates game stat to win
        /// Item 1 is Win Count
        /// Item 2 is Death Count
        /// </summary>
        private Tuple<int, int> Calculate(GameState state)
        {
            AttackAction action = new AttackAction();
            int win = 0;
            int death = 0;
            GameState copy;
            for (int i = 0; i < CalculateAttackCount; i++)
            {
                copy = state.DeepCopy();
                AttackActionResult result = (AttackActionResult) action.Process(copy, _config);
                if (result.IsWin)
                    win++;
                if (result.IsDead)
                    death++;
            }

            return new Tuple<int, int>(win/10, death/10);
        }
    }
}