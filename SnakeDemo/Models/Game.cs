using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeDemo.Models
{
    public class Game
    {
        public static bool up = false;
        public static bool isActive;
        public static bool Eat;
        public static bool Crach;
        public static Snake s = new Snake('0', ConsoleColor.Blue);
        public static Food f = new Food('$', ConsoleColor.DarkGreen);
        public static Wall w = new Wall('#', ConsoleColor.White);

        public static void Init()
        {
            Console.SetWindowSize(120, 30);
            for (int i = 1; i <= 74; i++)
            {
                for (int j = 1; j <= 28; j++)
                {
                    if (i == 1 || i == 74 || j == 1 || j == 28)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.SetCursorPosition(i, j);
                        Console.Write("@");
                    }
                }
            }
            isActive = true;
            Eat = false;
            Crach = false;
            Resume();
            f.Drow();
            w.Drow();
        }
        public static void LoadLevel(int level)
        {
            w.body.Clear();
            FileStream fs = new FileStream(string.Format(@"Levels/MapLevel{0}.txt", level), FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            int row = -1;
            int col = -1;
            while ((line = sr.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        w.body.Add(new Point { x = col, y = row });
                    }
                }
            }
            sr.Close();
            fs.Close();
            w.Save();
            if (up == true)
            {
                s.body.Clear();
                s.A = 2;
                s.B = 2;
                s.body.Add(new Point(s.A, s.B));
                s.DirectionLeft = false;
                s.DirectionRight = true;
                s.DirectionDown = false;
                s.DirectionUp = false;
                s.Save();
                
                up = false;
            }
            
        }
        public static void Resume()
        {
            s.Resume();
            f.Resume();
            w.Resume();
        }
        public static void Save()
        {
            s.Save();
            f.Save();
            w.Save();
        }
        public static void Drow()
        {
            s.Drow();
            if (Eat == false)
                s.Tail();
        }
        public static void Move()
        {
            if (s.body.Last().x == f.body[0].x && s.body.Last().y == f.body[0].y)
            {
                Eat = true;
                f.body[0].x = new Random().Next(2, 73);
                f.body[0].y = new Random().Next(2, 27);
                for (int i = 0; i < w.body.Count; i++)
                {
                    if (w.body.ElementAt(i).x == f.body[0].x && w.body.ElementAt(i).y == f.body[0].y)
                    {
                        f.body[0].x = new Random().Next(2, 73);
                        f.body[0].y = new Random().Next(2, 27);
                        i = 0;
                    }
                }
                for (int j = 0; j < s.body.Count - 1; j++)
                {
                    if (s.body.ElementAt(j).x == f.body[0].x && s.body.ElementAt(j).y == f.body[0].y)
                    {
                        f.body[0].x = new Random().Next(2, 73);
                        f.body[0].y = new Random().Next(2, 27);
                        j = 0;
                    }

                }
            }

            if (Crach == false)
            {
                for (int i = 0; i < w.body.Count; i++)
                {
                    if (w.body.ElementAt(i).x == s.A && w.body.ElementAt(i).y == s.B)
                    {
                        Crach = true;
                    }
                }
                for (int j = 0; j < s.body.Count - 1; j++)
                {
                    if (s.body.ElementAt(j).x == s.A && s.body.ElementAt(j).y == s.B)
                    {
                        Crach = true;
                    }
                }
            }
        }
    }
}
