// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.GameConfiguration.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

namespace Oxozle.MiniRPG.GameConfig.Models
{
    /// <summary>
    /// Class for initial game config
    /// </summary>
    public sealed class GameConfiguration
    {
        public GameConfiguration()
        {
            InitialPlayer = new InitialPlayerConfiguration();
            Battle = new BattleConfiguration();
            Shops = new ShopsConfiguration();
        }

        public InitialPlayerConfiguration InitialPlayer { get; set; }
        public BattleConfiguration Battle { get; set; }
        public ShopsConfiguration Shops { get; set; }
    }
}