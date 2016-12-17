// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.Generator.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System;

#endregion

namespace Oxozle.MiniRPG.Engine.Utils
{
    internal static class Generator
    {
        private static readonly Random _generator = new Random();
        private static readonly object locker = new object();

        /// <summary>
        /// Thread safe generate [min,max]
        /// </summary>
        public static int Next(int min, int maxValue)
        {
            lock (locker)
            {
                //https://msdn.microsoft.com/en-us/library/2dx6wyd4(v=vs.110).aspx
                return _generator.Next(min, maxValue + 1);
            }
        }
    }
}