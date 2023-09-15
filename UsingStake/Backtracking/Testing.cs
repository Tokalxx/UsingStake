namespace UsingStake.Backtracking
{
    public class Testing
    {
        static int size = 4;
        static int[,] maze = new int[,]{
                {1,1,0,0 },
                {1,0,0,0 },
                { 1,1,1,0 },
                {0,1,1,1 } };
        static int[,] path = new int[size, size];
        //static int[,] path = new int[maze.GetLength(0),maze.GetLength(1)];
        static void Main(string[] args)
        {
            //SolveMaze(0, 0);
            DisPath();
            Console.Read();
        }

        static bool IsValidPath(int r, int c)
        {
            return (r >= 0 &&
                r < maze.GetLength(0) &&
                c >= 0 &&
                c < maze.GetLength(1) &&
                maze[r, c] == 1);

        }

        static bool SolveMaze(int r, int c)
        {
            if (r == maze.GetLength(0) - 1 && c == maze.GetLength(1) - 1)
            {
                path[r, c] = 1;
                return true;
            }
            if (IsValidPath(r, c))
            {
                path[r, c] = 1;
                if (SolveMaze(r, c + 1))
                {
                    return true;
                }
                if (SolveMaze(r + 1, c))
                {
                    return true;
                }
                path[r, c] = 0;
                return false;
            }

            return false;
        }

        static void DisPath()
        {
            if (SolveMaze(0, 0) == false)
            {
                Console.WriteLine("No Path");
            }
            else
            {
                for (int i = 0; i < maze.GetLength(0); ++i)
                {
                    for (int j = 0; j < maze.GetLength(1); ++j)
                    {
                        //Console.Write(path[i, j]);
                        if (path[i, j] == 1)
                        {
                            Console.WriteLine($"{i}{j}");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
