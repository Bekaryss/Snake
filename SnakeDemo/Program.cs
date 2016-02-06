using SnakeDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 1;
            int ret = 0;
            Game.LoadLevel(1);
            Game.Init();

            while (Game.isActive)
            {
                if(Game.s.body.Count == 4)
                {
                    level++;
                    if(level > 3)
                    {                        
                        if (ret == 1)
                        {
                            Game.s.syn = 'X';
                            Game.s.color = ConsoleColor.Red;
                            level = 1;
                            ret = 0;
                        }
                        if (ret == 0)
                        {
                            Game.s.syn = 'O';
                            Game.s.color = ConsoleColor.Blue;
                            level = 1;
                            ret = 1;
                        }
                    }
                    Game.up = true;
                    LevelUp(level);
                }               
                else
                {
                    Way();
                    Game.Drow();
                }

                Thread.Sleep(200);
                Game.Move();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    Direction(key.Key);
                }
                if (Game.Eat == true)
                {
                    Way();
                    Game.Drow();
                    Game.f.Drow();
                    Game.Eat = false;
                }
                if (Game.Crach == true)
                {
                    Console.SetCursorPosition(94, 14);
                    Console.WriteLine("Game over");
                    Game.isActive = false;
                }                
            }
            Console.ReadKey();

        }
        static void LevelUp(int l)
        {
            Console.Clear();
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Congratulations!!!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition(54, 14);
            Console.WriteLine("Level Up");
            Thread.Sleep(1000);           
            Game.LoadLevel(l);
            Console.Clear();
            Game.Init();
        }
        static void Way()
        {
            if (Game.s.DirectionRight == true)
            {
                if (Game.s.A == 73)
                {
                    Game.s.A = 1;
                }
                Game.s.body.Add(new Point(++Game.s.A, Game.s.B));                
            }
            else if (Game.s.DirectionLeft == true)
            {
                if (Game.s.A == 2)
                {
                    Game.s.A = 74;
                }
                Game.s.body.Add(new Point(--Game.s.A, Game.s.B));
            }
            else if (Game.s.DirectionDown == true)
            {
                if (Game.s.B == 27)
                {
                    Game.s.B = 1;
                }
                Game.s.body.Add(new Point(Game.s.A, ++Game.s.B));
            }
            else if (Game.s.DirectionUp == true)
            {
                if (Game.s.B == 2)
                {
                    Game.s.B = 28;
                }
                Game.s.body.Add(new Point(Game.s.A, --Game.s.B));                
            }
            
        }
        public static void Direction(ConsoleKey key)
        {
            if (key == ConsoleKey.RightArrow && Game.s.DirectionLeft != true)
            {
                Game.s.DirectionLeft = false;
                Game.s.DirectionRight = true;
                Game.s.DirectionDown = false;
                Game.s.DirectionUp = false;
            }
            else if (key == ConsoleKey.LeftArrow && Game.s.DirectionRight != true)
            {
                Game.s.DirectionLeft = true;
                Game.s.DirectionRight = false;
                Game.s.DirectionDown = false;
                Game.s.DirectionUp = false;
            }
            else if (key == ConsoleKey.DownArrow && Game.s.DirectionUp != true)
            {
                Game.s.DirectionLeft = false;
                Game.s.DirectionRight = false;
                Game.s.DirectionDown = true;
                Game.s.DirectionUp = false;
            }
            else if (key == ConsoleKey.UpArrow && Game.s.DirectionDown != true)
            {
                Game.s.DirectionLeft = false;
                Game.s.DirectionRight = false;
                Game.s.DirectionDown = false;
                Game.s.DirectionUp = true;
            }
            else if (key == ConsoleKey.F2)
            {
                Game.Save();
            }
            else if (key == ConsoleKey.F3)
            {
                Game.Resume();
            }
        }
    }
}
