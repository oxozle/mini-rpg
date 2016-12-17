// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameConfig.IGameConfigReader.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.GameConfig.Models;

#endregion

namespace Oxozle.MiniRPG.GameConfig
{
    /// <summary>
    /// Should read Game config to pass to a game object
    /// </summary>
    public interface IGameConfigReader
    {
        GameConfiguration ReadConfig();
    }
}