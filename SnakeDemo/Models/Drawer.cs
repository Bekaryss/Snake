using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnakeDemo.Models
{
    public abstract class Drawer
    {
        public char syn;
        public ConsoleColor color;
        public List<Point> body = new List<Point>();
        public Point p = new Point();
        public Drawer() { }
        public Drawer(char _syn, ConsoleColor _color)
        {
            syn = _syn;
            color = _color;
        }
        public void Drow()
        {
            foreach(Point p in body)
            {
                Console.ForegroundColor = color;
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(syn);
            }
        }
        public void Tail()
        {
            Console.SetCursorPosition(body.ElementAt(0).x, body.ElementAt(0).y);
            Console.Write(" \b");
            body.RemoveAt(0);
        }
        public void Save()
        {
            Type t = this.GetType();
            FileStream fs = new FileStream(string.Format("{0}.xml", t.Name), FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(t);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public void Resume()
        {
            Type t = this.GetType();
            FileStream fs = new FileStream(string.Format("{0}.xml", t.Name), FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(t);
            if (t == typeof(Snake)) Game.s = xs.Deserialize(fs) as Snake;
            if (t == typeof(Food)) Game.f = xs.Deserialize(fs) as Food;
            if (t == typeof(Wall)) Game.w = xs.Deserialize(fs) as Wall;
            fs.Close();
        }
    }
}
