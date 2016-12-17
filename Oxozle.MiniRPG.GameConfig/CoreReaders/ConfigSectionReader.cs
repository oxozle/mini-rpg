// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.ConfigSectionReader.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System.Configuration;
using Oxozle.MiniRPG.GameConfig.ConfigSection;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.GameConfig.CoreReaders
{
    public sealed class ConfigSectionReader : IGameConfigReader
    {
        public GameConfiguration ReadConfig()
        {
            GameConfigurationSection config = (GameConfigurationSection) ConfigurationManager.GetSection("gameConfig");

            GameConfiguration gameConfig = config.Map();
            return gameConfig;
        }
    }
}