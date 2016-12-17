// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.Node.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

using System;
using Oxozle.MiniRPG.Engine.Enums;

namespace Oxozle.MiniRPG.Engine.AI
{
    public class Node
    {
        private readonly ActionTypes _action;
        private readonly GameState _state;

        public Node()
        {
        }

        public Node(GameState state)
        {
            _state = state;
        }

        public Node(GameState state, ActionTypes action)
        {
            _state = state;
            _action = action;
        }

        public int Win { get; set; }
        public int Death { get; set; }
        public int Health { get; set; }

        public int Value
        {
            get
            {
                if (Death > Win)
                    return Int32.MinValue;
                return Win + Health - Death*5;
            }
        }

        public GameState State
        {
            get { return _state; }
        }

        public ActionTypes ActionType
        {
            get { return _action; }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", ActionType, Value);
        }
    }
}