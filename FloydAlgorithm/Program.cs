using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydsAlgorithm
{
    class Program
    {

        // Number of vertices in the graph
        static int V = 5;

        /* Define Infinite as a large enough value. This value will be used
          for vertices not connected to each other */
        static int INF = int.MaxValue / 2;


        static void Main(string[] args)
        {
            /* Let us create the following weighted graph
                   10
              (0)------->(3)
               |         /|\
             5 |          |
               |          | 1
              \|/         |
              (1)------->(2)
                   3           */
            int[,] graph = { {INF,   8,  INF, 9, 4},
                        {INF, INF,   1, INF, INF},
                        {INF, 2, INF,   3, INF},
                        {INF, INF, 2, INF, 7},
                        {INF, INF, 1, INF, INF}
                      };

            // Print the solution
            FloydsAlgorithm(graph);
            Console.ReadKey();
        }

        // A function to print the solution matrix
        //  void printSolution(int dist[][V]);

        // Solves the all-pairs shortest path problem using Floyd Warshall algorithm
       static void FloydsAlgorithm(int[,] graph)
        {
            /* dist[,] will be the output matrix that will finally have the shortest
              distances between every pair of vertices */

            /* Initialize the solution matrix same as input graph matrix. Or
               we can say the initial values of shortest distances are based
               on shortest paths considering no intermediate vertex. */

            /* Add all vertices one by one to the set of intermediate vertices.
              ---> Before start of a iteration, we have shortest distances between all
              pairs of vertices such that the shortest distances consider only the
              vertices in set {0, 1, 2, .. k-1} as intermediate vertices.
              ----> After the end of a iteration, vertex no. k is added to the set of
              intermediate vertices and the set becomes {0, 1, 2, .. k} */
            int[,] dist = graph;
            // Number of nodes n
            int n = dist.GetLength(0);

            // Use k as the intermediate
            for (int k = 0; k < n; k++)
            {
                // For each cell [i,j] in the current (meaning, from i to j)
                // dist, is it better to go from i to j via k?
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int attempt = dist[i, k] + dist[k, j];
                        if (attempt < dist[i,j])
                        {
                            Console.WriteLine("i -> j: {0}", dist[i, j]);
                            Console.WriteLine("i -> k: {0}", dist[i, k]);
                            Console.WriteLine("k -> j: {0}", dist[k, j]);
                            Console.WriteLine("i -> k -> j: {0}\n", attempt);
                        }
                        dist[i, j] = Math.Min(dist[i, j], attempt);
                    }
                }

                Console.WriteLine("At k = {0}", k);
                printSolution(dist);
            }

            // Print the shortest distance matrix
            Console.WriteLine("Final solution:");
            printSolution(dist);
        }
        /* A utility function to print solution */
      static  void printSolution(int[,] dist)
        {
            Console.Write("Following matrix shows the shortest distances\n" +
                    " between every pair of vertices \n");
            Console.Write("     ");
            for (int m = 0; m < V; m++)
            {
                Console.Write("        " + m);
            }
            Console.Write("\r\n");
            Console.WriteLine("=======================================================");
            for (int i = 0; i < V; i++)
            {
                Console.Write("    " + i);
                for (int j = 0; j < V; j++)
                {

                    if (dist[i, j] == INF)
                    {
                        Console.Write("        " + "INF");
                    }
                    else
                    {
                        Console.Write("        " + dist[i, j]);
                    }
                }
                Console.Write("\r\n");
            }
        }
    }
}
