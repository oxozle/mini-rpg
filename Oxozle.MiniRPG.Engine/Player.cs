// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.Player.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Oxozle.MiniRPG.Engine.Exceptions;

#endregion

namespace Oxozle.MiniRPG.Engine
{
    public class Player
    {
        private int _health,
            _maxHealth,
            _power,
            _coins;

        //Храним информацию о вещах, чтобы можно было реализовать "снятие"
        private List<Item> _items;

        public Player()
        {
            _items = new List<Item>();
        }

        public int Health
        {
            get { return _health; }
        }

        public int MaxHealth
        {
            get { return _maxHealth; }
        }

        public int Power
        {
            get { return _power; }
        }

        public int Coins
        {
            get { return _coins; }
        }

        /// <summary>
        /// Player items
        /// </summary>
        public IReadOnlyCollection<Item> Items
        {
            get { return new ReadOnlyCollection<Item>(_items); }
        }

        public void Clear()
        {
            _items = new List<Item>();
        }

        public void Initialize(int health, int maxHealth, int power, int coins)
        {
            if (_maxHealth != 0)
                throw new PlayerDataException("Player already initialized");

            if (health > maxHealth)
                throw new ArgumentOutOfRangeException("health", "Health can't be greater than MaxHealth");

            if (coins < 0)
                throw new ArgumentOutOfRangeException("coins");

            if (power < 0)
                throw new ArgumentOutOfRangeException("power");

            _health = health;
            _maxHealth = maxHealth;
            _power = power;
            _coins = coins;
        }

        /// <summary>
        /// Copy object (not reference)
        /// </summary>
        public Player DeepCopy()
        {
            Player player = (Player) MemberwiseClone();
            player.Clear();
            foreach (Item item in Items)
            {
                player.ApplyItem(new Item(item));
            }

            return player;
        }

        #region Actions

        public void ApplyDamage(int damage)
        {
            _health -= damage;
            if (_health < 0)
                _health = 0;
        }


        public int ApplyHeal(int heal)
        {
            _health += heal;

            if (_health > _maxHealth)
            {
                heal = _health - _maxHealth;
                _health = _maxHealth;
            }

            return heal;
        }

        public void AddCoins(int coins)
        {
            _coins += coins;
        }

        public void DecreaseCoins(int coins)
        {
            if (_coins < coins)
                throw new PlayerDataException("Can't decrease");

            _coins -= coins;
        }

        /// <summary>
        /// Apply item effect and add to pocket
        /// </summary>
        public void ApplyItem(Item item)
        {
            _maxHealth += item.Health;
            _power += item.Damage;

            _items.Add(item);
        }

        #endregion
    }
}