using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDemo.Models
{
    public class Snake : Drawer
    {
        public int A;
        public int B;
        public Snake() { }
        public Snake(char syn, ConsoleColor color) : base(syn, color)
        { }

        public bool DirectionLeft  = false;
        public bool DirectionRight = true;
        public bool DirectionDown  = false;
        public bool DirectionUp    = false;       
    }
}
