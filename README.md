# CodePuzzle1
This console application will calculate the pixel coordinates of the vertices of triangles in a square matrix as described in the image files 
ProblemStatementPartA.jpg and ProblemStatementPartB.jpg.

The coordinates of the matrix start at x,y where x = 0, and y = 0.  The matrix grows to the right (positive x) and down (negative y).

0,0            60,0





0,-60          60,-60

Imagine the image below was a square bisected from v2 to v3 into 2 right triangles where triangle t1 has coordinates [v1(1), v2, v3] and triangle t2
has coordinates [v1(2), v2, v3]  and the non-hypotenuse sides are of length L, where L = 10.  
Each square cell of the square matrix is comprised of two such right triangles.

         L
   v2__________v1(2)
   |\          |
 L |       t2  |  L
   |     \     |
   |  t1       |
   |__________\|
  v1(1)        v3
         L

The algorithm will find the coordinates of each triangle of the matrix.  The rows of the matrix are labeled A - F.  Each column of the square matrix has two 
internal columns cooresponding to the triangles.  t1 is in column 1, t2 is in column 2.  The label for each triangle is  RowColumn.  In the square above 
triangle t1 is labeled A1, and triangle t2 is labled A2.  Repeat this pattern through the square matrix. A1, A2, ... F11, F12

|12|34|56|78|910|1112|
A
B
C
D
E
F

Given the vertice coordinates of any triangle in the matrix, the algorithm will produce its label.

For purposes of scalability the algorithm will support a square matrix of sizes 2,2 to 26,26  (Rows A-Z) and arbitrary square length size L.
