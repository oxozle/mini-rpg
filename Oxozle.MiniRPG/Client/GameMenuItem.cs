// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.GameMenuItem.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

#region Usings

using System;

#endregion

namespace Oxozle.MiniRPG.Client
{
    internal class GameMenuItem
    {
        public GameMenuItem(string title, Action action)
            : this(title, action, false)
        {
        }

        public GameMenuItem(string title, Action action, bool isExit)
        {
            Action = action;
            Title = title;
            IsExit = isExit;
        }

        public string Title { get; set; }
        public Action Action { get; set; }
        public bool IsExit { get; set; }
    }
}