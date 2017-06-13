using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePuzzle1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n This console application will calculate the pixel coordinates of the vertices of triangles in a");
            Console.WriteLine("square matrix as described in the images ProblemStatementPartA and ProblemStatementPartB");

            int defaultSideLength = 10;
            int defaultDimension = 6;

            Console.WriteLine("\nCreate a square matrix of dimension " + defaultDimension + " whose cell sides are length: " + defaultSideLength);
            SquarePointGrid pointGrid = new SquarePointGrid(defaultSideLength, defaultDimension);

            List<RightTriangle> triangleList = pointGrid.GetRightTriangles();

            int dimension = pointGrid.GetDimension();

            Console.Write("\n\nRowColumn\tCoordinates\n");
            foreach (RightTriangle triangle in triangleList)
            {
                Console.Write(pointGrid.GetPosition(triangle));
                Console.Write("\t\t");
                triangle.PrintCoords();
                Console.WriteLine();
            }

            Console.WriteLine("\n\nSo that was a 6 X 6 matrix with cell length 10.");
            Console.WriteLine("Would you like to try a different sized matrix with a different square side length?");
            Console.WriteLine("\nType \"y\" or \"n\" and hit enter. Hit Enter or type \"n\" and hit Enter to exit the program.");

            string inputStr = Console.ReadLine();
            if (inputStr.Count() == 0)
                inputStr = inputStr + "n";

            inputStr = inputStr.Substring(0, 1);

            while (inputStr == "y")
            {
                Console.WriteLine("\nEnter the size of the matrix (number of rows/columns - max is 26): ");
                int dim = 0;
                int sideLength = 0;

                string dimStr = Console.ReadLine();

                try
                {
                    dim = Convert.ToInt32(dimStr);
                }
                catch
                {
                    Console.WriteLine("\nReally??  Defaulting to matrix size 6.");
                    dim = 6;
                }

                if( dim > 26 )
                {
                    Console.WriteLine("\nReally??  Defaulting to matrix size 6.");
                    dim = 6;
                }


                Console.WriteLine("\nEnter the lenth in pixels of the square's side: ");

                string lenStr = Console.ReadLine();

                try
                {
                    sideLength = Convert.ToInt32(lenStr);
                }
                catch
                {
                    Console.WriteLine("\nReally??  Defaulting to square size 10.");
                    sideLength = 10;
                }

                pointGrid = new SquarePointGrid(sideLength, dim);

                triangleList = pointGrid.GetRightTriangles();

                dimension = pointGrid.GetDimension();

                Console.Write("\n\nRowColumn\tCoordinates\n");
                foreach (RightTriangle triangle in triangleList)
                {
                    Console.Write(pointGrid.GetPosition(triangle));
                    Console.Write("\t");
                    triangle.PrintCoords();
                    Console.WriteLine();
                }

                Console.WriteLine("Would you like to try a different sized matrix with a different square side length?");
                Console.WriteLine("\nType \"y\" or \"n\" and hit enter. Hit Enter or type \"n\" and hit Enter to exit the program.");

                inputStr = Console.ReadLine();
                if (inputStr.Count() == 0)
                    inputStr = inputStr + "n";

                inputStr = inputStr.Substring(0, 1);
            }
            
        }
    }
}
