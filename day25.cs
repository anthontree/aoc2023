//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics.CodeAnalysis;
//using System.IO;
//using System.Text.RegularExpressions;
//using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//double res1 = 0;
//Dictionary<string, HashSet<string>> allNodes = new();
//Dictionary<string, int> visited = new();


//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    if (s != null)
//    {
//        var sides = s.Split(": ");
//        var right = sides[1].Split(" ");
//        if (!allNodes.ContainsKey(sides[0]))
//        {
//            allNodes.Add(sides[0], new());
//        }
//        foreach (var n in right)
//        {
//            if (!allNodes[sides[0]].Contains(n))
//            {
//                allNodes[sides[0]].Add(n);
//            }
//            if (!allNodes.ContainsKey(n))
//            {
//                allNodes.Add(n, new());
//            }
//            if (!allNodes[n].Contains(sides[0]))
//            {
//                allNodes[n].Add(sides[0]);
//            }

//        }
//    }
//}
////game 1

//Game1();


//void Game1()
//{
//    var list = allNodes.Keys.ToList();
//    for (int i = 0; i < 1234; i++)
//    {
//        var pair = GetRandomPair(list);
//        FindShortestPath(pair.Item1, pair.Item2);
//    }
//    var sorted = visited.OrderByDescending(x => x.Value).ToList();
//    var top6 = sorted.GetRange(0, 6).ToDictionary().Keys.ToList();

//    int g1 = GetGroupSize(sorted[6].Key, top6);
//    int g2 = allNodes.Count - g1;
//    Console.WriteLine(g2 * g1);
//}

//void FindShortestPath(string n1, string n2)
//{
//    List<string> seen = new List<string>();
//    List<string> path = new List<string>();
//    PriorityQueue<Tuple<string, List<string>>, int> cue = new();
//    seen.Add(n1);
//    foreach (var n in allNodes[n1])
//    {
//        if (n == n2)
//        {
//            return;
//        }
//        List<string> nSeen = [.. seen];
//        nSeen.Add(n);
//        cue.Enqueue(new(n, nSeen), nSeen.Count);
//    }
//    while (cue.Count > 0)
//    {
//        var nx = cue.Dequeue();
//        foreach (var n in allNodes[nx.Item1])
//        {
//            if (!seen.Contains(n))
//            {
//                if (n == n2)
//                {
//                    path = [.. nx.Item2];
//                    path.Add(n);
//                    cue.Clear();
//                    break;
//                }
//                List<string> nSeen = [.. nx.Item2];
//                if (!nSeen.Contains(n))
//                {
//                    nSeen.Add(n);
//                    cue.Enqueue(new(n, nSeen), nSeen.Count);
//                }
//            }
//        }
//    }

//    foreach (var p in path)
//    {
//        if (!visited.ContainsKey(p))
//        {
//            visited.Add(p, 1);
//        }
//        else
//        {
//            visited[p]++;
//        }
//    }

//}

//Tuple<string, string> GetRandomPair(List<string> list)
//{
//    int min = 0;
//    int max = list.Count;
//    var r = new Random();
//    int p1 = r.Next(min, max);
//    int p2 = r.Next(min, max);
//    while (p1 == p2)
//    {
//        p2 = r.Next(min, max);
//    }
//    return new(list[p1], list[p2]);
//}

//int GetGroupSize(string n1, List<string> b)
//{
//    HashSet<string> group = [n1];
//    PriorityQueue<Tuple<string, int>, int> cue = new();
//    foreach (var n in allNodes[n1])
//    {
//        if (b.Contains(n))
//        {
//            group.Add(n);
//        }
//        else
//        {
//            if (!group.Contains(n))
//            {
//                group.Add(n);
//                cue.Enqueue(new(n, 0), 0);
//            }
//        }
//    }
//    while (cue.Count > 0)
//    {
//        var nx = cue.Dequeue();
//        foreach (var n in allNodes[nx.Item1])
//        {
//            if (b.Contains(n))
//            {
//                if (!group.Contains(n))
//                {
//                    group.Add(n);
//                }
//            }
//            else
//            {
//                if (!group.Contains(n))
//                {
//                    group.Add(n);
//                    cue.Enqueue(new(n, nx.Item2 + 1), nx.Item2 + 1);
//                }
//            }
//        }
//    }
//    return group.Count;
//}
