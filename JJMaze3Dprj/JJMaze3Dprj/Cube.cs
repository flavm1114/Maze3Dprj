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

        private int _x_MazeSize;
        private int _y_MazeSize;

        private int _x_index;
        private int _y_index;

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

        public Cube(Maze3D maze3d, int xindex, int yindex, int xMazeSize,int yMazeSize)
        {
            _maze3d = maze3d;

            _x_index = xindex;
            _y_index = yindex;
            _x_MazeSize = xMazeSize;
            _y_MazeSize = yMazeSize;

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

            InitializeNearByCube();
        }

        private void InitializeNearByCube()
        {

        }
    }
}
