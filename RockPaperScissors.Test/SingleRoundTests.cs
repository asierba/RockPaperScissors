using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace RockPaperScissors.Test
{
    public class SingleRoundTests
    {
        private readonly StringWriter _output;

        public SingleRoundTests()
        {
            _output = new StringWriter();
            Console.SetOut(_output);
        }
        
        [Fact]
        public void PaperBeatsRocket()
        {
            MockConsoleInput(
                "P", 
                "R");
            
            Program.Main(new string[] {});
            
            Assert.Equal(@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player 1 wins
", _output.ToString());
        }

        [Fact]
        public void RockBeatsScissors()
        {
            MockConsoleInput(
                "R", 
                "S");
            
            Program.Main(new string[] {});
            
            Assert.Equal(@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player 1 wins
", _output.ToString());
        }

        [Fact]
        public void RockBeatsScissorsForPlayer2()
        {
            MockConsoleInput(
                "S", 
                "R");
            
            Program.Main(new string[] {});
            
            Assert.Equal(@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player 2 wins
", _output.ToString());
        }

        [Fact]
        public void ScissorsBeatsPaper()
        {
            MockConsoleInput(
                "P", 
                "S");
            
            Program.Main(new string[] {});
            
            Assert.Equal(@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player 2 wins
", _output.ToString());
        }

        [Fact]
        public void ScissorsAndScissorIsADraw()
        {
            MockConsoleInput(
                "S", 
                "S");
            
            Program.Main(new string[] {});
            
            Assert.Equal(@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
Draw
", _output.ToString());
        }

        private static void MockConsoleInput(params string[] inputs)
        {
            var input = string.Join(Environment.NewLine, inputs);
            Console.SetIn(new StringReader(input));
        }
    }
}