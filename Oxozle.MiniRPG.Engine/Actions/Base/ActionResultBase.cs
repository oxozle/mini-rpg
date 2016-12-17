// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Engine.ActionResultBase.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

namespace Oxozle.MiniRPG.Engine.Actions.Base
{
    /// <summary>
    /// Game action result
    /// </summary>
    public abstract class ActionResultBase
    {
        protected ActionResultBase()
        {
            IsSuccessful = true;
        }

        public bool IsSuccessful { get; set; }
        public bool IsDead { get; set; }
    }
}