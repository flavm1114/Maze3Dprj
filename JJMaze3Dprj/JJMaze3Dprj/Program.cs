﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeCreator jjMaze = new MazeCreator();

            jjMaze.CreateMaze(50,50,50);

            Console.WriteLine(jjMaze.GetMazeCreatingTimeMilliSeconds() / 1000.0F);
        }
    }
}
