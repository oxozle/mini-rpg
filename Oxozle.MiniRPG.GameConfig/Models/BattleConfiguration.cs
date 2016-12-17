// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.BattleConfiguration.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.GameConfig.Enums;

#endregion

namespace Oxozle.MiniRPG.GameConfig.Models
{
    /// <summary>
    /// Настройки битвы
    /// </summary>
    public sealed class BattleConfiguration
    {
        public int MinWinProbability { get; set; }
        public int MaxWinProbability { get; set; }
        public int IncreasePowerProbability { get; set; }
        public BattleResultConfiguration WinResult { get; set; }
        public BattleResultConfiguration LooseResult { get; set; }
    }

    /// <summary>
    /// Результат битвы с монстром
    /// </summary>
    public sealed class BattleResultConfiguration
    {
        public int CoinsChange { get; set; }
        public int HealthChange { get; set; }
        public ChangeValueTypes HealthChangeType { get; set; }
    }
}