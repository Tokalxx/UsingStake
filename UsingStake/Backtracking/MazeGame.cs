namespace UsingStake.Backtracking
{
    internal class MazeGame
    {
        static int[,] maze = new int[,]{
                {1,1,0,0 },
                {1,0,0,0 },
                { 1,1,1,0 },
                {0,1,1,1 } };
        static int[,] path = new int[4, 4];

        static void Main(string[] args)
        {



            int startX = 0;
            int startY = 0;
            int endX = 0;
            int endY = 0;


            foreach (var point in FindPath(maze, startX, startY, endX, endY))
            {
                // Print the path coordinates
                Console.WriteLine($"({point.Item1}, {point.Item2})");
            }

            SolveMaze(0, 0, maze.GetLength(0));
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(path[i, j]);
                }
            }
        }

        public static int SolveMaze(int row, int col, int size)
        {
            if (row == size - 1 && col == size) return 1;

            if (maze[row, col] == 1)
            {
                path[row, col] = 1;
                if (SolveMaze(row, col + 1, size) == 1) return 1;
                if (SolveMaze(row + 1, col, size) == 1) return 1;

                path[row, col] = 0;
            }
            return 0;
        }

        public static List<Tuple<int, int>> FindPath(int[,] maze, int sx, int sy, int ex, int ey)
        {
            int numRows = maze.GetLength(0);
            int numCols = maze.GetLength(1);

            Stack<Tuple<int, int>> pathStack = new Stack<Tuple<int, int>>();
            List<Tuple<int, int>> pathList = new List<Tuple<int, int>>();
            bool[,] visited = new bool[numRows, numCols];

            int[] dirX = { -1, 1, 0, 0 };
            int[] dirY = { 0, 0, -1, 1 };

            pathStack.Push(new Tuple<int, int>(sx, sy));

            while (pathStack.Count > 0)
            {
                Tuple<int, int> current = pathStack.Pop();
                int x = current.Item1;
                int y = current.Item2;

                // If we reached the end of the maze, break
                if (x == ex && y == ey)
                {
                    pathList.Add(new Tuple<int, int>(x, y));
                    break;
                }

                // Mark the current cell as visited
                visited[x, y] = true;

                // Try all possible moves
                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dirX[i];
                    int newY = y + dirY[i];

                    // Check if the new position is within bounds and not visited
                    if (newX >= 0 && newX < numRows && newY >= 0 && newY < numCols
                        && maze[newX, newY] == 0 && !visited[newX, newY])
                    {
                        pathStack.Push(new Tuple<int, int>(newX, newY));
                        pathList.Add(new Tuple<int, int>(newX, newY));
                    }
                }
            }

            return pathList;
        }


        //public static bool FindPath(int[,] maze, int sx, int sy, int ex, int ey)
        //{
        //    int numRows = maze.GetLength(0);
        //    int numCol = maze.GetLength(1);

        //    Stack<Tuple<int, int>> path = new Stack<Tuple<int, int>>();

        //    bool[,] vis = new bool[numRows, numCol];

        //    int[] dirx = { -1, -1, 0, 0 };
        //    int[] diry = { 0, 0, -1, -1 };

        //    path.Push(new Tuple<int, int>(sx, sy));


        //    while (path.Count > 0)
        //    {
        //        Tuple<int, int> current = path.Pop();
        //        int x = current.Item1;
        //        int y = current.Item2;

        //        // If we reached the end of the maze, a path is found
        //        if (x == ex && y == ey)
        //        {
        //            return true;
        //        }

        //        // Mark the current cell as visited
        //        vis[x, y] = true;

        //        // Try all possible moves
        //        for (int i = 0; i < 4; i++)
        //        {
        //            int newX = x + dirx[i];
        //            int newY = y + diry[i];

        //            // Check if the new position is within bounds and not visited
        //            if (newX >= 0 && newX < numRows && newY >= 0 && newY < numCol
        //                && maze[newX, newY] == 0 && !vis[newX, newY])
        //            {
        //                path.Push(new Tuple<int, int>(newX, newY));
        //            }
        //        }
        //    }
        //    // No path found
        //    return false;
        //}


    }
}
