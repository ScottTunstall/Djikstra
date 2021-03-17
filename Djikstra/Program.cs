using System;

namespace Djikstra
{
    using System;

    class ScottTunstall
    {
        // V represents the number of vertices in the graph
        // V is also the width and height of the 2D adjacency matrix (2D array) supplied.
        private const int V = 9;

        // dist[i]  will hold the shortest distance from src to i 
        private int[] Distances { get; set; }

        private bool[] VertexVisited { get; set; }


        // Function that implements Dijkstra's 
        // single source shortest path algorithm 
        // for a graph represented using adjacency 
        // matrix representation  (see https://www.youtube.com/watch?v=5S1II7Mc8v8)
        public void Dijkstra(int[,] graph, int src)
        {
            Distances = new int[V];

            VertexVisited = new bool[V];

            // Initialize all distances as INFINITE and reset shortest paths
            for (int i = 0; i < V; i++)
            {
                Distances[i] = int.MaxValue;
            }

            // Distance of source vertex 
            // from itself is always 0 
            Distances[src] = 0;

            for (int i = 0; i< V - 1; i++)
            {
                int index = GetUnvisitedVertexWithLowestCost();

                VertexVisited[index] = true;

                for (int j = 0; j < V; j++)
                {
                    if (!VertexVisited[j] &&
                        (graph[index, j] != 0) &&
                        (Distances[index] != int.MaxValue) &&
                        (Distances[index] + graph[index, j] < Distances[j]))
                    {
                        Distances[j] = Distances[index] + graph[index, j];
                    }
                }
            }

            // print the constructed distance array 
            PrintSolution();
        }


        private int GetUnvisitedVertexWithLowestCost()
        {
            // Initialize min value 
            int min = int.MaxValue; 
            int minIndex = -1;

            for (int i = 0; i < V; i++)
            {
                if (!VertexVisited[i] && Distances[i] <= min)
                {
                    min = Distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }


        // A utility function to print 
        // the constructed distance array 
        private void PrintSolution()
        {
            Console.Write("Vertex\t\tDistance from Source\n");
            for (int i = 0; i < V; i++)
                Console.Write(i + " \t\t " + Distances[i] + "\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
                { 0, 4,  0, 0,  0,  0,  0, 8,  0 },
                { 4, 0,  8, 0,  0,  0,  0, 11, 0 },
                { 0, 8,  0, 7,  0,  4,  0, 0,  2 },
                { 0, 0,  7, 0,  9,  14, 0, 0,  0 },
                { 0, 0,  0, 9,  0,  10, 0, 0,  0 },
                { 0, 0,  4, 14, 10, 0,  2, 0,  0 },
                { 0, 0,  0, 0,  0,  2,  0, 1,  6 },
                { 8, 11, 0, 0,  0,  0,  1, 0,  7 },
                { 0, 0,  2, 0,  0,  0,  6, 7,  0 }
            };

            var t = new ScottTunstall();
            t.Dijkstra(graph, 0);
        }
    }
}
