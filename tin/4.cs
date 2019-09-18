using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpDev
{
    class Program
    {
        class SpaceDot
        {
            public int x = 0;
            public int y = 0;

            public SpaceDot(int a, int b)
            {
                x = a;
                y = b;
            }
        }

        private static List<List<bool>> flagMatrix;
        private static List<List<char>> spaceMatrix;
        static int emptyPlaces = 0;

        static void Main(string[] args)
        {
            var dim = Convert.ToInt32(Console.ReadLine());

            flagMatrix = new List<List<bool>>(dim);
            spaceMatrix = new List<List<char>>(dim);


            for (int i = 0; i < dim; i++)
            {
                flagMatrix.Add(new List<bool>(dim));
                spaceMatrix.Add(new List<char>(dim));

                var currStr = Console.ReadLine().Replace(" ", "");

                for (int j = 0; j < dim; j++)
                {
                    flagMatrix[i].Add(false);
                    spaceMatrix[i].Add(currStr[j]);
                }
            }

            var dot = Console.ReadLine().Split(' ').ToList();

            var lastDot = new SpaceDot(Convert.ToInt32(dot[0]) - 1, Convert.ToInt32(dot[1]) - 1);

            BFS(lastDot, dim);

            Console.WriteLine(emptyPlaces);

            return;
        }

        private static void BFS(SpaceDot dot, int dim)
        {
            if (flagMatrix[dot.x][dot.y])
                return;

            flagMatrix[dot.x][dot.y] = true;
            ++emptyPlaces;

            if (DotIsGood(dot.x, dot.y - 1, dim) && spaceMatrix[dot.x][dot.y - 1] != '*')
            {
                var nDot = new SpaceDot(dot.x,dot.y - 1);

                BFS(nDot, dim);
            }

            if (DotIsGood(dot.x - 1, dot.y, dim) && spaceMatrix[dot.x - 1][dot.y] != '*')
            {
                var nDot = new SpaceDot(dot.x - 1, dot.y);
                BFS(nDot, dim);
            }

            if (DotIsGood(dot.x + 1, dot.y, dim) && spaceMatrix[dot.x + 1][dot.y] != '*')
            {
                var nDot = new SpaceDot(dot.x + 1, dot.y);

                BFS(nDot, dim);
            }

            if (DotIsGood(dot.x, dot.y + 1, dim) && spaceMatrix[dot.x][dot.y + 1] != '*')
            {
                var nDot = new SpaceDot(dot.x, dot.y + 1);

                BFS(nDot, dim);
            }
        }

        private static bool DotIsGood(int x, int y, int dim)
        {
            if (x > 0 && x < dim - 1 && y > 0 && y < dim - 1 && !flagMatrix[x][y])
                return true;

            return false;
        }
    }
}