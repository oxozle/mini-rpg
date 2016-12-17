// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.Mapper.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using AutoMapper;
using Oxozle.MiniRPG.GameConfig.ConfigSection;
using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.GameConfig.CoreReaders
{
    public static class ConfigMapper
    {
        static ConfigMapper()
        {
            Mapper.CreateMap<GameConfigurationSection, GameConfiguration>();

            Mapper.CreateMap<InitialPlayerElement, InitialPlayerConfiguration>();

            Mapper.CreateMap<BattleElement, BattleConfiguration>();
            Mapper.CreateMap<BattleResultElement, BattleResultConfiguration>();

            Mapper.CreateMap<ShopsElement, ShopsConfiguration>();
            Mapper.CreateMap<ShopElement, ShopConfiguration>();
        }

        public static GameConfiguration Map(this GameConfigurationSection section)
        {
            return Mapper.Map<GameConfigurationSection, GameConfiguration>(section);
        }
    }
}