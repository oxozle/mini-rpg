// *********************************************************************************
// Author:	Azarov Dmitriy
// Email:	oxozle@gmail.com
// Date: 	20.02.2015
// Project:	Oxozle.MiniRPG.Tests.GeneratorTests.cs
//  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// *********************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oxozle.MiniRPG.Engine.Utils;

namespace Oxozle.MiniRPG.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void Generator_Should_Generate_OK()
        {
            int N = 100;

            bool minValue = false;
            bool maxValue = false;

            for (int i = 0; i < 100000; i++)
            {
                int result = Generator.Next(1, N);

                if (result == 1)
                    minValue = true;

                if (result == N)
                    maxValue = true;

                Assert.IsTrue(result > 0 && result <= N);
            }

            Assert.IsTrue(minValue);
            Assert.IsTrue(maxValue);
        }
    }
}