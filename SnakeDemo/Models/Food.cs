using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDemo.Models
{
    public class Food : Drawer
    {
        public Food() { }
        public Food(char syn, ConsoleColor color) : base(syn, color) { }
    }
}
