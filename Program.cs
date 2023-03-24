
class Program
{
    /// <summary>
    /// Computes the number of rectangles in a set of given points.
    /// </summary>
    /// <param name="points">A list of tuples representing the points.</param>
    /// <returns>The number of rectangles.</returns>
    static int CountRectangles(List<Tuple<int, int>> points)
    {
        // Create a hash set of the points for fast lookup. (O(1) lookup time)
        HashSet<Tuple<int, int>> pointSet = new HashSet<Tuple<int, int>>(points);

        // Counter for the number of rectangles.  
        int count = 0;

        // Loop through all distinct pairs of points.
        for (int i = 0; i < points.Count; i++)
        {
            // Loop through all points after the current point.
            for (int j = i + 1; j < points.Count; j++)
            {
                int x1 = points[i].Item1;  // x-coordinate of point 1
                int y1 = points[i].Item2;  // y-coordinate of point 1
                int x2 = points[j].Item1;  // x-coordinate of point 2
                int y2 = points[j].Item2;  // y-coordinate of point 2

                //Check if the two points are not colinear (they are not on the same X or Y axis)
                if (x1 != x2 && y1 != y2)
                {
                    // Check if the two points are the opposite corners of a rectangle. (share the same X and Y coordinates with two other points)
                    if (pointSet.Contains(Tuple.Create(x1, y2)) && pointSet.Contains(Tuple.Create(x2, y1)))
                    {
                        // Increment the counter if they are
                        count++;
                    }
                }
            }
        }
        // Divide by 2 because each rectangle is counted twice.
        return count / 2;
    }

    static void Main(string[] args)
    {
        // First test case
        List<Tuple<int, int>> points = new List<Tuple<int, int>>()
        {
            Tuple.Create(1, 1),
            Tuple.Create(1, 3),
            Tuple.Create(2, 1),
            Tuple.Create(2, 3),
            Tuple.Create(3, 1),
            Tuple.Create(3, 3)
        };
        Console.WriteLine(CountRectangles(points)); // Output: 3

        // Second test case
        points = new List<Tuple<int, int>>()
        {
            Tuple.Create(1, 1),
            Tuple.Create(1, 3),
            Tuple.Create(2, 1),
            Tuple.Create(3, 1),
            Tuple.Create(3, 3)
        };
        Console.WriteLine(CountRectangles(points)); // Output: 1
    }
}