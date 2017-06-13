using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CodePuzzle1
{
    public class Point
    {
        public Point( int xIn, int yIn )
        {
            x = xIn;
            y = yIn;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void Print()
        {
            Console.Write("(" + x + "," + y + ")");
        }

        private

        int x;
        int y;
    }

public class Triangle
    {
        public Triangle( int v1x, int v1y, int v2x, int v2y, int v3x, int v3y )
        {
            v1 = new Point(v1x, v1y);
            v2 = new Point(v2x, v2y);
            v3 = new Point(v3x, v3y);
			Init();
        }

        public Triangle( Point p1, Point p2, Point p3 )
        {
            v1 = p1;
            v2 = p2;
            v3 = p3;
			Init();
        }
		
		protected void Init()
		{			
			verticesList.Add( v1 );
			verticesList.Add( v2 );
			verticesList.Add( v3 );
		}

		public List<Point> GetVertices()
		{
			return verticesList;			
		}

        public Point GetV1()
        { return v1; }
        public Point GetV2()
        { return v2; }
        public Point GetV3()
        { return v3; }

        public void PrintCoords()
        {
            Console.Write("[");
            v1.Print();
            Console.Write(",");
            v2.Print();
            Console.Write(",");
            v3.Print();
            Console.Write("]");
        }


        protected Point v1;
        protected Point v2;
        protected Point v3;

        protected List<Point> verticesList = new List<Point>();
    }
	
	// This triangle is an isosceles triangle with a right angle
	public class RightTriangle : Triangle
	{
		public RightTriangle( int v1x, int v1y, int v2x, int v2y, int v3x, int v3y, int sideLengthIn ) : base(v1x, v1y, v2x,  v2y, v3x, v3y )
		{
            sideLength = sideLengthIn;
		}
		
		// Point p1 is always the vertice intersection of the non-hypotonuse sides
		// Point p2 is the leftmost of the hypotonuse side
		// Point p3 is the rightmost of the hypotonuse side
        public RightTriangle( Point p1, Point p2, Point p3, int sideLengthIn ) : base( p1, p2, p3 )
        {
            sideLength = sideLengthIn;
        }
      
        int sideLength = 0;

        // We may want to add some more attributes and functions later to this subclass - but not now.
    }


  
    public class SquarePointGrid
	{
        // sideLengthIn is the length of the square's side.  
        // dimenstionIn is the size of the square matrix  2x2 -- up to the maxDim of number of capital letters in the English alphabet
        public SquarePointGrid(int sideLengthIn, int dimensionIn)
		{
			InitializeGrid( sideLengthIn, dimensionIn );
		}
		
        // sideLengthIn is the length of the square's side.  
        // dimenstionIn is the size of the square matrix  1x1 -- up to the maxDim of number of capital letters in the English alphabet
		void InitializeGrid( int sideLengthIn, int dimensionIn)
		{
            // add checking for max sizes here

            maxDim = RowNames.Count();
            
            // No less than 1. No more than the number of capital letters we have.  Later - we can go to "AA" "BB" or something  
            if (dimensionIn > maxDim)
                dimensionIn = maxDim;

            if (dimensionIn <= 0)
                dimensionIn = 1;

            if (sideLength < 1)
                sideLength = 1;

            sideLength = sideLengthIn;
			dimension = dimensionIn;
			PopulatePoints();
            CreateRightTriangles();
		}

        // Calculate all the point coordinates of the matrix and put them into a List.  We're not using this yet.
        void PopulatePoints()
		{
			// this grid starts at 0,0 and grows in the +x and -y direction 
			// of a cartesian coordinate system
			int x = 0;
			int y = 0;
			for( int i = 0; i < dimension + 1; i++ )
			{ 
				x = 0;
				for( int j = 0; j < dimension + 1; j++ )
				{
					Point thisPoint = new Point(x,y);
					pointsList.Add( thisPoint );
					x += sideLength;
				}
				y -= sideLength;
			}
		}

        // create all the right isosceles triangles that would exist in the nXn (n > 0, n <= 26) matrix given two triangles per cell
        void CreateRightTriangles()
        {
            int x = 0;
            int y = 0;

            for (int i = 0; i < dimension; i++)
            {
                x = 0;
                for( int j = 0; j < dimension; j++ )
                {
                    Point p1 = new Point(x, y - sideLength);
                    Point p2 = new Point(x, y);
                    Point p3 = new Point(x + sideLength, y - sideLength);
                    Point p4 = new Point(x + sideLength, y);

                    RightTriangle leftSide = new RightTriangle(p1, p2, p3, sideLength);
                    RightTriangle rightSide = new RightTriangle(p4, p2, p3, sideLength);
                    rightTriangleList.Add(leftSide);
                    rightTriangleList.Add(rightSide);
                    x += sideLength;
                }

                y -= sideLength;
            }
        }

        public int GetDimension()
        {
            return dimension;
        }

        public List<Point> GetPoints()
        {
            return pointsList;
        }

        public List<RightTriangle> GetRightTriangles()
        {
            return rightTriangleList;
        }

        // Get the Row and Column of a Triangle where "A, B, C..." are the rows and the columns are numbered "1, 2, 3. ..."
        public string GetPosition(RightTriangle triangleIn)
        {
            int column = 0;
            string row = "A";

            Point v1 = triangleIn.GetV1();
            Point v2 = triangleIn.GetV2();
            Point v3 = triangleIn.GetV3();

            int rowNum = 0;
            if (v1.GetX() == v2.GetX())
            {
                rowNum = Math.Abs(v1.GetY() / sideLength) - 1;
                column = (v1.GetX() / sideLength)*2 + 1;
            }
            else if (v1.GetX() == v3.GetX())
            {
                rowNum = Math.Abs(v3.GetY() / sideLength) - 1;
                column = (v3.GetX() / sideLength)*2;
            }

            row = RowNames[rowNum];

            string position = row + column.ToString();
            return position;
        }     

        private List<string> RowNames = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        int sideLength;  // square side in pixels
		int dimension;   // number of columns and rows (this is a square matrix)

        int maxDim = 0;
				
		List<Point> pointsList = new List<Point>();
        List<RightTriangle> rightTriangleList = new List<RightTriangle>();
		
	}
}
