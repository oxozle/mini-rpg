// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConsoleClient.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System;
using System.Collections.Generic;
using Oxozle.MiniRPG.Engine;
using Oxozle.MiniRPG.Engine.Actions;
using Oxozle.MiniRPG.Engine.Enums;
using Oxozle.MiniRPG.GameConfig;
using Oxozle.MiniRPG.IoC;

#endregion

namespace Oxozle.MiniRPG.Client
{
    /// <summary>
    /// Клиент для игры
    /// </summary>
    internal class GameConsoleClient
    {
        private ActionTypes _expertActionType;
        private readonly Game _game;
        private readonly Dictionary<char, GameMenuItem> _menu;
        private readonly List<string> _messagesFromActions;

        public GameConsoleClient()
        {
            _menu = new Dictionary<char, GameMenuItem>();
            _messagesFromActions = new List<string>();

            _game = new Game(PTResolver.Current.GetInstance<IGameConfigReader>());


            _menu.Add('w', new GameMenuItem("Attack", Attack));
            _menu.Add('a', new GameMenuItem("Buy Weapon", BuyWeapon));
            _menu.Add('d', new GameMenuItem("Buy Armor", BuyArmor));
            _menu.Add('s', new GameMenuItem("Heal", Heal));
            _menu.Add('e', new GameMenuItem("Auto", Auto));
            _menu.Add('9', new GameMenuItem("Exit", null, true));
        }

        public void Start()
        {
            bool inGame = true;

            while (inGame)
            {
                Console.Clear();
                PrintStatus();
                PrintMenu();
                Console.Write(">");
                _expertActionType = _game.GetBestMove();
                Console.WriteLine("Expert advice: {0}", _expertActionType);


                ConsoleKeyInfo key = Console.ReadKey();
                _messagesFromActions.Clear();
                char selectedMenu = key.KeyChar;
                if (_menu.ContainsKey(selectedMenu))
                {
                    if (_menu[selectedMenu].IsExit)
                        return;

                    if (_menu[selectedMenu].Action != null)
                        _menu[selectedMenu].Action();
                }
                else
                {
                    _messagesFromActions.Add("No action with this key");
                }
            }
        }

        #region Actions

        private void BuyWeapon()
        {
            _messagesFromActions.Add("Buy Weapon");
            BuyItem(ItemTypes.Weapon);
        }

        private void BuyArmor()
        {
            _messagesFromActions.Add("Buy Armor");
            BuyItem(ItemTypes.Awmor);
        }

        private void BuyItem(ItemTypes type)
        {
            BuyItemActionResult result = _game.BuyItem(type);
            if (!result.IsSuccessful)
            {
                _messagesFromActions.Add("Fail buy (no money).");
            }
            else
            {
                _messagesFromActions.Add(string.Format("Item Effect: {0}", result.EffectResult));
            }
        }

        private void Auto()
        {
            //ActionTypes action0 = _game.GetBestMove();
            //if (action != _expertActionType)
            //    Debugger.Break();
            ActionTypes action = _expertActionType;
            switch (action)
            {
                case ActionTypes.Attack:
                    Attack();
                    break;
                case ActionTypes.BuyWeapon:
                    BuyWeapon();
                    break;
                case ActionTypes.BuyArmor:
                    BuyArmor();
                    break;
                case ActionTypes.Heal:
                    Heal();
                    break;
            }
        }

        private void Attack()
        {
            _messagesFromActions.Add("Attack");

            AttackActionResult result = _game.Attack();

            if (result.IsDead)
            {
                _messagesFromActions.Add("You dead. Game over.");
                _messagesFromActions.Add(string.Format("Your level: {0}", result.Level));
                return;
            }

            if (result.IsWin)
            {
                _messagesFromActions.Add("You win!");
            }
            else
            {
                _messagesFromActions.Add("You loose!");
            }
        }

        private void Heal()
        {
            _messagesFromActions.Add("Heal");
            HealActionResult result = _game.Heal();
            if (!result.IsSuccessful)
            {
                _messagesFromActions.Add("Heal fail (no money)");
            }
            else
            {
                _messagesFromActions.Add(string.Format("Heal action for: {0}", result.HealAction));
            }
        }

        #endregion

        #region Print

        private void PrintStatus()
        {
            Console.WriteLine("******* Player Info ********");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Health......{0}/{1}", _game.State.CurrentPlayer.Health,
                _game.State.CurrentPlayer.MaxHealth);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Power.......{0}", _game.State.CurrentPlayer.Power);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Coins.......{0}", _game.State.CurrentPlayer.Coins);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Items.......{0} total", _game.State.CurrentPlayer.Items.Count);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" Level.......{0}", _game.State.Attacks);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            foreach (string messagesFromAction in _messagesFromActions)
            {
                Console.Write(">");
                Console.WriteLine(messagesFromAction);
            }
            Console.WriteLine();
        }

        private void PrintMenu()
        {
            DrawStars();
            foreach (KeyValuePair<char, GameMenuItem> pair in _menu)
            {
                Console.WriteLine(" {0}. {1}", pair.Key, pair.Value.Title);
            }
            DrawStars();
            Console.WriteLine();
        }

        private static void DrawStars()
        {
            Console.WriteLine("****************************");
        }

        #endregion
    }
}