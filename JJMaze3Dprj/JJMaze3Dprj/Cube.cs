using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    class Cube
    {
        private Maze3D _maze3d;

        private int _x_index;
        private int _y_index;
        private int _z_index;

        private Cube top_nearby_cube;
        private Cube bottom_nearby_cube;
        private Cube left_nearby_cube;
        private Cube right_nearby_cube;
        private Cube front_nearby_cube;
        private Cube back_nearby_cube;

        private Wall top_wall;
        private Wall bottom_wall;
        private Wall left_wall;
        private Wall right_wall;
        private Wall front_wall;
        private Wall back_wall;

        public Cube(Maze3D maze3d, int xIndex, int yIndex, int zIndex)
        {
            _maze3d = maze3d;

            _x_index = xIndex;
            _y_index = yIndex;
            _z_index = zIndex;

            InitializeCube();
        }

        private void InitializeCube()
        {
            top_nearby_cube = null;
            bottom_nearby_cube = null;
            left_nearby_cube = null;
            right_nearby_cube = null;
            front_nearby_cube = null;
            back_nearby_cube = null;

            top_wall = new Wall();
            bottom_wall = new Wall();
            left_wall = new Wall();
            right_wall = new Wall();
            front_wall = new Wall();
            back_wall = new Wall();
        }


    }
}
