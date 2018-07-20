using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJMaze3Dprj
{
    public enum Direction
    {
        TOP, BOTTOM,
        LEFT, RIGHT,
        FRONT, BACK
    };

    public class MazeCreator
    { 
        private Maze _maze;

        private List<Wall> _wallList;

        public MazeCreator()
        {
            _wallList = new List<Wall>();
        }

        public void CreateMaze(int sizeX, int sizeY, int sizeZ)
        {
            //미로 생성 및 초기화
            _maze = new Maze(sizeX, sizeY, sizeZ);
            InitializeMaze();

            //미로생성 알고리즘 실행
            RunMazeCreateAlgorithm_vPrim();
        }

        public void CreateMaze(int sizeXYZ)
        {
            //미로 생성 및 초기화
            _maze = new Maze(sizeXYZ, sizeXYZ, sizeXYZ);
            InitializeMaze();
            
            //미로생성 알고리즘 실행
            RunMazeCreateAlgorithm_vPrim();
        }

        private void InitializeMaze()
        {
            //축 순서는 3중배열의 인덱스 순서를 따름 i, j, k 및 x, y, z 공통 (세로 가로 높이 순서)
            for(int i = 0; i < _maze.Get_xSize(); i++)
            {
                for(int j = 0; j < _maze.Get_ySize(); j++)
                {
                    for (int k = 0; k < _maze.Get_zSize(); k++)
                    {
                        Cell currentCell = _maze.Get_cell(i, j, k);
                        MappingNearByCell(currentCell);

                        currentCell.SetWall(Direction.TOP, new Wall());
                        
                        if(k == 0)
                        {
                            currentCell.SetWall(Direction.BOTTOM, new Wall());
                        }
                        else
                        {
                            currentCell.SetWall(Direction.BOTTOM, _maze.Get_cell(i, j, k - 1).GetWall(Direction.TOP));
                        }
                        
                    }
                }
            }

        }

        private void MappingNearByCell(Cell currentCell)
        {
            //축 순서는 3중배열의 인덱스 순서를 따름 i, j, k 및 x, y, z 공통 (세로 가로 높이 순서)
            int i = currentCell.GetXindex();
            int j = currentCell.GetYindex();
            int k = currentCell.GetZindex();

            if (k != _maze.Get_zSize() - 1)
                currentCell.SetNearByCell(Direction.TOP, _maze.Get_cell(i, j, k + 1));
            if (k != 0)
                currentCell.SetNearByCell(Direction.BOTTOM, _maze.Get_cell(i, j, k - 1));
            if (j != 0)
                currentCell.SetNearByCell(Direction.LEFT, _maze.Get_cell(i, j - 1, k));
            if (j != _maze.Get_ySize() - 1)
                currentCell.SetNearByCell(Direction.RIGHT, _maze.Get_cell(i, j + 1, k));
            if (i != _maze.Get_xSize() - 1)
                currentCell.SetNearByCell(Direction.FRONT, _maze.Get_cell(i + 1, j, k));
            if (i != 0)
                currentCell.SetNearByCell(Direction.BACK, _maze.Get_cell(i - 1, j, k));
        }

        private void MappingWallToCell()
        {

        }

        private void RunMazeCreateAlgorithm_vPrim()
        {
            // 1.셀을 하나 고른다 ( 0,0,0 으로 고르자 )
            Cell selectedCell = _maze.Get_cell(0, 0, 0);

            // 고른 셀을 마킹한다 ( 미로의 부분이 되었다 )
            selectedCell.SetIsVisited(true);

            // 그 셀의 벽을 벽리스트에 추가하라


            // 2. 벽들이 리스트에 있는동안 반복

            // 2-1 벽 리스트중에 벽을 하나 골라라 (벽 리스트는 현재까지 완성된미로의 외곽선을 의미함)

            // 만약 고른 벽이 나누는 두 셀중 오직 하나만 방문 됐다면
            // 벽을 통과 가능하게 만들고 그 방문되지 않은 셀을 미로의 부분으로 만들어라

            // 그 셀의 벽을 벽리스트에 추가하라

            // 2-2 그 벽을 리스트로부터 지워라
        }
    }
}
