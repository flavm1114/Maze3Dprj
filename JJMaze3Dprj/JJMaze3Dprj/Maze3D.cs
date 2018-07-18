using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    public class Maze3D
    {
        private Cube[,] _cube;
        private int _xsize;
        private int _ysize;

        public Maze3D(int xysize)
        {
            _cube = new Cube[xysize, xysize];
            _xsize = xysize;
            _ysize = xysize;
        }

        public Maze3D(int xsize,int ysize)
        {
            _cube = new Cube[xsize, ysize];
            _xsize = xsize;
            _ysize = ysize;
        }


    }
}
