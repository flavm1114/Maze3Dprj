using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private Stopwatch stopwatch;

        public MazeCreator()
        {
            _maze = null;
            _wallList = new List<Wall>();
            stopwatch = new Stopwatch();
        }

        public void CreateMaze(int sizeX, int sizeY, int sizeZ)
        {
            if (sizeX >= 2 && sizeY >= 2 && sizeZ >= 2)
            {
                stopwatch.Reset();
                stopwatch.Start();

                //미로 생성 및 초기화
                _maze = new Maze(sizeX, sizeY, sizeZ);
                InitializeMaze();

                //미로생성 알고리즘 실행
                RunMazeCreateAlgorithm_vPrim();

                stopwatch.Stop();
            }
        }

        public void CreateMaze(int sizeXYZ)
        {
            if (sizeXYZ >= 2)
            {
                stopwatch.Reset();
                stopwatch.Start();

                //미로 생성 및 초기화
                _maze = new Maze(sizeXYZ, sizeXYZ, sizeXYZ);
                InitializeMaze();

                //미로생성 알고리즘 실행
                RunMazeCreateAlgorithm_vPrim();

                stopwatch.Stop();
            }
        }

        public long GetMazeCreatingTimeMilliSeconds()
        {
            return stopwatch.ElapsedMilliseconds;
        }

        private void InitializeMaze()
        {
            MappingNearByCell();

            MappingWallToCell();
        }

        private void MappingNearByCell()
        {
            //축 순서는 3중배열의 인덱스 순서를 따름 i, j, k 및 x, y, z 공통 (세로 가로 높이 순서)
            for (int i = 0; i < _maze.Get_xSize(); i++)
            {
                for (int j = 0; j < _maze.Get_ySize(); j++)
                {
                    for (int k = 0; k < _maze.Get_zSize(); k++)
                    {
                        Cell currentCell = _maze.Get_cell(i, j, k);

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
                }
            }
        }

        private void MappingWallToCell()
        {
            //축 순서는 3중배열의 인덱스 순서를 따름 i, j, k 및 x, y, z 공통 (세로 가로 높이 순서)
            for (int i = 0; i < _maze.Get_xSize(); i++)
            {
                for (int j = 0; j < _maze.Get_ySize(); j++)
                {
                    for (int k = 0; k < _maze.Get_zSize(); k++)
                    {
                        Cell currentCell = _maze.Get_cell(i, j, k);


                        Wall topWall = new Wall();
                        topWall.Add_dividedCells(currentCell);
                        if(k != _maze.Get_zSize() - 1)
                            topWall.Add_dividedCells(currentCell.GetNearByCell(Direction.TOP));
                        currentCell.SetWall(Direction.TOP, topWall);
                        if (k == 0)
                        {
                            Wall bottomWall = new Wall();
                            bottomWall.Add_dividedCells(currentCell);
                            currentCell.SetWall(Direction.BOTTOM, bottomWall);
                        }
                        else
                        {
                            currentCell.SetWall(Direction.BOTTOM, currentCell.GetNearByCell(Direction.BOTTOM).GetWall(Direction.TOP));
                        }


                        Wall rightWall = new Wall();
                        rightWall.Add_dividedCells(currentCell);
                        if(j != _maze.Get_ySize() - 1)
                            rightWall.Add_dividedCells(currentCell.GetNearByCell(Direction.RIGHT));
                        currentCell.SetWall(Direction.RIGHT, rightWall);
                        if (j == 0)
                        {
                            Wall leftWall = new Wall();
                            leftWall.Add_dividedCells(currentCell);
                            currentCell.SetWall(Direction.LEFT, leftWall);
                        }
                        else
                        {
                            currentCell.SetWall(Direction.LEFT, currentCell.GetNearByCell(Direction.LEFT).GetWall(Direction.RIGHT));
                        }


                        Wall frontWall = new Wall();
                        frontWall.Add_dividedCells(currentCell);
                        if (i != _maze.Get_xSize() - 1)
                            frontWall.Add_dividedCells(currentCell.GetNearByCell(Direction.FRONT));
                        currentCell.SetWall(Direction.FRONT, frontWall);
                        if (i == 0)
                        {
                            Wall backWall = new Wall();
                            backWall.Add_dividedCells(currentCell);
                            currentCell.SetWall(Direction.BACK, backWall);
                        }
                        else
                        {
                            currentCell.SetWall(Direction.BACK, currentCell.GetNearByCell(Direction.BACK).GetWall(Direction.FRONT));
                        }
                    }
                }
            }
        }

        private void RunMazeCreateAlgorithm_vPrim()
        {
            // 1.셀을 하나 고른다 ( 0,0,0 으로 고르자 )
            Cell selectedCell = _maze.Get_cell(0, 0, 0);

            // 고른 셀을 마킹한다 ( 미로의 부분이 되었다 )
            selectedCell.SetIsVisited(true);

            // 그 셀의 벽을 벽리스트에 추가하라
            AddWallsToWallList(selectedCell);

            // 2. 벽들이 리스트에 있는동안 반복
            while ( _wallList.Count > 0)
            {
                Console.WriteLine(_wallList.Count);
                // 2-1 벽 리스트중에 벽을 하나 골라라 (벽 리스트는 현재까지 완성된미로의 외곽선을 의미함)
                Random random = new Random();
                Wall selectedWall = _wallList[random.Next(0,_wallList.Count)];

                // 만약 고른 벽이 나누는 두 셀중 오직 하나만 방문 됐다면
                Cell[]twoCell = new Cell[2];
                twoCell[0] = selectedWall.GetDividedCell(0);
                twoCell[1] = selectedWall.GetDividedCell(1);
                if (twoCell[0] == null && twoCell[1] == null)
                    throw new Exception();

                if (twoCell[0] != null && twoCell[1] != null)
                {
                    Cell unVisitedCell = null;
                    int twoCellvisitcount = 0;
                    for(int i = 0; i < 2; i++)
                    {
                        if(twoCell[i].GetIsVisited() == true)
                        {
                            twoCellvisitcount++;
                        }
                        else
                        {
                            unVisitedCell = twoCell[i];
                        }
                    }

                    // 만약 고른 벽이 나누는 두 셀중 오직 하나만 방문 됐다면
                    if (twoCellvisitcount == 1)
                    {
                        // 벽을 통과 가능하게 만들고 그 방문되지 않은 셀을 미로의 부분으로 만들어라
                        selectedWall.SetIsExist(false);
                        unVisitedCell.SetIsVisited(true);

                        // 그 셀의 벽을 벽리스트에 추가하라
                        AddWallsToWallList(unVisitedCell);
                    }
                }
                // 2-2 그 벽을 리스트로부터 지워라 //
                _wallList.Remove(selectedWall);
            }
        }

        private void AddWallsToWallList(Cell nextCell)
        {
            Direction direction;
            for (direction = Direction.TOP; direction <= Direction.BACK; direction++)
            {
                if (nextCell.GetWall(direction).GetIsExist() == true)
                {
                    _wallList.Add(nextCell.GetWall(direction));
                }
            }
        }
    }
}
