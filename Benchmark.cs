using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UndirectedWeightedGraph;

namespace Testing
{
    internal class Benchmark
    {
        List<long> execTime_v_1 = new List<long>();
        List<long> execTime_v_2 = new List<long>();
        List<long> execTime_v_3 = new List<long>();

        int runTest = 10;

        public void Benchmark_V_1(TFLShortestPathFinder_matrix.Station source,
            TFLShortestPathFinder_matrix.Station target,
            TFLShortestPathFinder_matrix.Graph graph, int[,] adj)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            TFLShortestPathFinder_matrix.MyList<string>[] resp_v_1 = graph.DijkestraAlgorithm(source, target, graph, adj);

            sw.Stop();
            execTime_v_1.Add(sw.ElapsedMilliseconds);
        }

        public void Benchmark_V_2(UndirectedWeightedGraph.Station source,
            UndirectedWeightedGraph.Station target,
            UndirectedWeightedGraph.Graph graph, UndirectedWeightedGraph.MyList<MyLinkedList> adj)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            UndirectedWeightedGraph.MyList<string>[] resp_v_2 = graph.DijkstraAlgorithem(source, target, graph, adj);

            sw.Stop();
            execTime_v_2.Add(sw.ElapsedMilliseconds);
        }

        public void Benchmark_V_3(TFLShortestPathFinder.Station source,
            TFLShortestPathFinder.Station target,
            TFLShortestPathFinder.Graph graph, int[,] adj)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            List<string>[] resp_v_3 = graph.DijkestraAlgorithm(source, target, graph, adj);

            sw.Stop();
            execTime_v_3.Add(sw.ElapsedMilliseconds);
        }

        public void RunTest()
        {
            TFLShortestPathFinder_matrix.Graph graph_matrix = new TFLShortestPathFinder_matrix.Graph();
            graph_matrix = graph_matrix.CreateGraph(graph_matrix);
            int[,] adj_m = graph_matrix.CreateAdjMatrix();

            UndirectedWeightedGraph.Graph graph_list = new UndirectedWeightedGraph.Graph();
            graph_list = graph_list.CreateGraph(graph_list);
            UndirectedWeightedGraph.MyList<UndirectedWeightedGraph.MyLinkedList> adj_l = graph_list.CreateAdjList();

            TFLShortestPathFinder.Graph graph_net = new TFLShortestPathFinder.Graph();
            graph_net = graph_net.CreateGraph(graph_net);
            int[,] adj_n = graph_net.CreateAdjMatrix();

            Console.WriteLine("Enter the source station name:");
            string sourceName = Console.ReadLine();
            Console.WriteLine("Enter the target station name:");
            string targetName = Console.ReadLine();

            TFLShortestPathFinder_matrix.Station source_m = TFLShortestPathFinder_matrix.Station.FindStationByName(sourceName, graph_matrix.stations);
            TFLShortestPathFinder_matrix.Station target_m = TFLShortestPathFinder_matrix.Station.FindStationByName(targetName, graph_matrix.stations);

            UndirectedWeightedGraph.Station source_l = graph_list.GetStationByName(sourceName);
            UndirectedWeightedGraph.Station target_l = graph_list.GetStationByName(targetName);

            TFLShortestPathFinder.Station source_n = TFLShortestPathFinder.Station.FindStationByName(sourceName, graph_net.stations);
            TFLShortestPathFinder.Station target_n = TFLShortestPathFinder.Station.FindStationByName(targetName, graph_net.stations);

            for (int i = 0; i < runTest; i++)
            {
                Benchmark_V_1(source_m, target_m, graph_matrix, adj_m);
                Benchmark_V_2(source_l, target_l, graph_list, adj_l);
                Benchmark_V_3(source_n, target_n, graph_net, adj_n);
            }
        }

        public void OutputResults()
        {
            Console.WriteLine("\nResults:");

            Console.WriteLine($"Version 1: {execTime_v_1.Average()} ms");
            Console.WriteLine($"Version 2: {execTime_v_2.Average()} ms");
            Console.WriteLine($"Version 3: {execTime_v_3.Average()} ms");
        }
    }
}
