using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDemo.Models
{
    public class Wall : Drawer
    {
        public Wall() { }
        public Wall(char _syn, ConsoleColor _color) : base(_syn, _color) { }
    }
}
