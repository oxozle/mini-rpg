// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Resolver.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using StructureMap;

#endregion

namespace Oxozle.MiniRPG.IoC
{
    internal static class PTResolver
    {
        private static IContainer _container;

        public static IContainer Current
        {
            get
            {
                if (_container == null)
                    _container = Initialize();
                return _container;
            }
        }

        private static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}