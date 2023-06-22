using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLShortestPathFinder_matrix; //version 1
using UndirectedWeightedGraph; // Version_2


namespace Testing
{
    internal class TestVersion_1
    {
        TFLShortestPathFinder_matrix.MyList<string>[] resp_v_1;
        UndirectedWeightedGraph.MyList<string>[] resp_v_2;
        List<string>[] resp_v_3;

        // For Matrix
        public void Test_V_1()
        {
            TFLShortestPathFinder_matrix.Graph graph = new TFLShortestPathFinder_matrix.Graph();

            graph = graph.CreateGraph(graph);
            int[,] adj = graph.CreateAdjMatrix();

            // Call the function to find the fastest walking route
            Console.WriteLine("Enter the source station name:");
            string sourceName = Console.ReadLine();
            Console.WriteLine("Enter the target station name:");
            string targetName = Console.ReadLine();


            TFLShortestPathFinder_matrix.Station source = TFLShortestPathFinder_matrix.Station.FindStationByName(sourceName, graph.stations);
            TFLShortestPathFinder_matrix.Station target = TFLShortestPathFinder_matrix.Station.FindStationByName(targetName, graph.stations);

            if (source == null || target == null)
            {
                Console.WriteLine("Invalid source or target station name. Please make sure you entered the correct names.");
                return; // or you can use a loop to ask for input again
            }

            resp_v_1 = graph.DijkestraAlgorithm(source, target, graph, adj);
        }

        // Adj List Version
        public void Test_V_2()
        {

            UndirectedWeightedGraph.Graph graph = new UndirectedWeightedGraph.Graph();
            graph = graph.CreateGraph(graph);

            UndirectedWeightedGraph.MyList<UndirectedWeightedGraph.MyLinkedList> adj = graph.CreateAdjList();

            // Call the function to find the fastest walking route
            Console.WriteLine("Enter the source station name:");
            string sourceName = Console.ReadLine();
            Console.WriteLine("Enter the target station name:");
            string targetName = Console.ReadLine();

            UndirectedWeightedGraph.Station source = graph.GetStationByName(sourceName);
            UndirectedWeightedGraph.Station target = graph.GetStationByName(targetName);

            resp_v_2 = graph.DijkstraAlgorithem(source, target, graph, adj);
        }

        public void Test_V_3()
        {
            TFLShortestPathFinder.Graph graph = new TFLShortestPathFinder.Graph();

            graph = graph.CreateGraph(graph);
            int[,] adj = graph.CreateAdjMatrix();

            // Call the function to find the fastest walking route
            Console.WriteLine("Enter the source station name:");
            string sourceName = Console.ReadLine();
            Console.WriteLine("Enter the target station name:");
            string targetName = Console.ReadLine();


            TFLShortestPathFinder.Station source = TFLShortestPathFinder.Station.FindStationByName(sourceName, graph.stations);
            TFLShortestPathFinder.Station target = TFLShortestPathFinder.Station.FindStationByName(targetName, graph.stations);

            if (source == null || target == null)
            {
                Console.WriteLine("Invalid source or target station name. Please make sure you entered the correct names.");
                return; // or you can use a loop to ask for input again
            }


            resp_v_3 = graph.DijkestraAlgorithm(source, target, graph, adj);
        }

        public void ComparePaths()
        {
            for (int i = 0; i < resp_v_3[0].Count(); i++)
            {
                if (resp_v_1[0][i] == resp_v_2[0][i] && resp_v_1[0][i] == resp_v_3[0][i] && resp_v_2[0][i] == resp_v_3[0][i])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Path did not match!");
                }
            }

            Console.WriteLine("All the Three Versions Produce the Same Paths");
        }

        public void CompareTime()
        {
            if (resp_v_1[1][1] != resp_v_2[1][1] && resp_v_1[1][1] != resp_v_3[1][1] && resp_v_2[1][1] != resp_v_3[1][1])
            {
                Console.WriteLine("Time did not match!");
            }
            else
            {
                Console.WriteLine("All the Three Versions Produce the Same Section Timings and Overall Fastest Time");
            }
        }

    }
}
