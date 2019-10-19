using System;

namespace ShortestPathWithDijkstrasAlgo
{
    internal class Program
    {
        public class clsShortestPathAlgo
        {
            static int V = 9;
            int minDistance(int[] dist, bool[] sptSet)
            {
                int min = int.MaxValue, min_index = -1;
                for (int i = 0; i < V; i++)
                {
                    if(sptSet[i]==false && dist[i]<=min)
                    {
                        min = dist[i];
                        min_index = i;
                    }

                }


                return min_index;
            }


            void printSolution(int[] dist)
            {
                Console.Write("Vertex \t\t Distance from Source\n");
                for (int i = 0; i < V; i++)
                {
                    Console.Write(i + " \t\t " + dist[i] + "\n");

                }

            }

            public void dijkstra(int[,] graph, int src)
            {
                int[] dist = new int[V];
                bool[] sptSet = new bool[V];

                for (int i = 0; i < V; i++)
                {
                    dist[i] = int.MaxValue;
                    sptSet[i] = false;
                    
                }

                dist[src] = 0;

                for (int count = 0; count < V-1; count++)
                {
                    int u = minDistance(dist, sptSet);

                    sptSet[u] = true;

                    for (int i = 0; i < V; i++)
                    {
                        if (!sptSet[i] && graph[u, i] != 0 && dist[u] != int.MaxValue && dist[u] + graph[u, i] < dist[i])
                        {
                            dist[i] = dist[u] + graph[u, i];
                        }
                        

                    }
                }

                printSolution(dist);
            }
        }

        private static void Main(string[] args)
        {
            
            int[,] graph = new int[,] {
                                        { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                        { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                        { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                        { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                        { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                        { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                        { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                        { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                        { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
                                    };

            clsShortestPathAlgo finder = new clsShortestPathAlgo();
            finder.dijkstra(graph, 0);
        }
    }
}
