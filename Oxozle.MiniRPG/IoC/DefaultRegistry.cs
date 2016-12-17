// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.DefaultRegistry.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using Oxozle.MiniRPG.GameConfig;
using Oxozle.MiniRPG.GameConfig.CoreReaders;
using StructureMap.Configuration.DSL;

#endregion

namespace Oxozle.MiniRPG.IoC
{
    internal sealed class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<IGameConfigReader>().Use<ConfigSectionReader>();
        }
    }
}