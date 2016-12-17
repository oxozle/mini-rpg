// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.InitialPlayerConfiguration.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

namespace Oxozle.MiniRPG.GameConfig.Models
{
    /// <summary>
    /// Стартовые настройки игрока
    /// </summary>
    public sealed class InitialPlayerConfiguration
    {
        /// <summary>
        /// Начальное здоровье
        /// </summary>
        public int InitialPlayerHealth { get; set; }

        /// <summary>
        /// Начальное максимальное здоровье
        /// </summary>
        public int InitialPlayerMaxHealth { get; set; }

        /// <summary>
        /// Начальная сила
        /// </summary>
        public int InitialPlayerPower { get; set; }

        /// <summary>
        /// Начальное кол-во монет
        /// </summary>
        public int InitialPlayerCoins { get; set; }
    }
}