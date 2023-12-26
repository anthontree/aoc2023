//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Text.RegularExpressions;
//using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<string> rows = new();
//int res1 = 0;
//int res2 = 0;

//Tuple<int, int> start = new(0, 0);
//Tuple<int, int> end = new(0, 0);
//Dictionary<Tuple<int, int>, Dictionary<Tuple<int, int>, int>> junctions = new();
//var endSeen = new HashSet<Tuple<int, int>>();
//HashSet<Tuple<int, int>> dirs =
//        new HashSet<Tuple<int, int>> {
//            new Tuple<int, int>(0,-1),
//            new Tuple<int, int>(0, 1),
//            new Tuple<int, int>(-1, 0),
//            new Tuple<int, int>(1, 0),
//        };

//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    if (s != null)
//    {
//        rows.Add(s);
//    }
//}
////game 1
//start = new(0, rows[0].IndexOf('.'));
//end = new(rows.Count - 1, rows[rows.Count - 1].IndexOf('.'));
//var see = new HashSet<Tuple<int, int>>();
//see.Add(start);
//Queue<Node> cue = new();
//cue.Enqueue(new Node { cur = start, steps = 0, seen = see });
////while (cue.Count > 0)
////{
////    var n = cue.Dequeue();
////    Walk(n.cur, n.steps, n.seen);
////}


////Console.WriteLine(res1);
////game2
//SetupJunctions();
//CalcJunctions();
//Console.WriteLine(WalkBig(start) + 1);
//void Walk(Tuple<int, int> cu, int steps, HashSet<Tuple<int, int>> seen)
//{
//    if (cu.Item1 == end.Item1)
//    {
//        res1 = Math.Max(res1, steps);
//        return;
//    }
//    HashSet<Tuple<int, int>> nSeen = new();
//    foreach (var item in seen)
//    {
//        nSeen.Add(item);
//    }
//    if (cu.Item1 - 1 > 0)
//    {
//        if (rows[cu.Item1 - 1][cu.Item2] != '#' && rows[cu.Item1 - 1][cu.Item2] != 'v')
//        {
//            var t = new Tuple<int, int>(cu.Item1 - 1, cu.Item2);
//            if (!nSeen.Contains(t))
//            {
//                nSeen.Add(t);
//                cue.Enqueue(new Node { cur = t, steps = steps + 1, seen = nSeen });
//            }
//        }
//    }
//    if (cu.Item1 + 1 < rows.Count)
//    {
//        if (rows[cu.Item1 + 1][cu.Item2] != '#' && rows[cu.Item1 + 1][cu.Item2] != '^')
//        {
//            var t = new Tuple<int, int>(cu.Item1 + 1, cu.Item2);
//            if (!nSeen.Contains(t))
//            {
//                nSeen.Add(t);
//                cue.Enqueue(new Node { cur = t, steps = steps + 1, seen = nSeen });
//            }
//        }
//    }
//    if (cu.Item2 - 1 > 0)
//    {
//        if (rows[cu.Item1][cu.Item2 - 1] != '#' && rows[cu.Item1][cu.Item2 - 1] != '>')
//        {
//            var t = new Tuple<int, int>(cu.Item1, cu.Item2 - 1);
//            if (!nSeen.Contains(t))
//            {
//                nSeen.Add(t);
//                cue.Enqueue(new Node { cur = t, steps = steps + 1, seen = nSeen });
//            }
//        }
//    }
//    if (cu.Item2 + 1 < rows[0].Length)
//    {
//        if (rows[cu.Item1][cu.Item2 + 1] != '#' && rows[cu.Item1][cu.Item2 + 1] != '<')
//        {
//            var t = new Tuple<int, int>(cu.Item1, cu.Item2 + 1);
//            if (!nSeen.Contains(t))
//            {
//                nSeen.Add(t);
//                cue.Enqueue(new Node { cur = t, steps = steps + 1, seen = nSeen });
//            }
//        }
//    }
//}

//void SetupJunctions()
//{
//    junctions.Add(start, new());
//    junctions.Add(end, new());
//    for (int i = 0; i < rows.Count; i++)
//    {
//        for (int j = 0; j < rows[0].Length; j++)
//        {
//            if (rows[i][j] != '#')
//            {
//                int k = 0;
//                foreach (var dr in dirs)
//                {
//                    int ii = i + dr.Item1;
//                    int jj = j + dr.Item2;
//                    if (ii >= 0 && jj >= 0 && ii < rows.Count && jj < rows[0].Length && rows[ii][jj] != '#')
//                    {
//                        k++;
//                    }
//                }
//                if (k > 2)
//                {
//                    junctions.Add(new Tuple<int, int>(i, j), new());
//                }
//            }
//        }
//    }
//}

//void CalcJunctions()
//{
//    foreach (var junction in junctions)
//    {
//        if (junction.Key == end)
//        {
//            continue;
//        }
//        Queue<Tuple<int, int, int>> cue = new();
//        HashSet<Tuple<int, int>> seent = new();
//        cue.Enqueue(new Tuple<int, int, int>(junction.Key.Item1, junction.Key.Item2, 0));
//        while (cue.Count > 0)
//        {
//            var next = cue.Dequeue();
//            seent.Add(new Tuple<int, int>(next.Item1, next.Item2));
//            foreach (var dr in dirs)
//            {
//                int ii = next.Item1 + dr.Item1;
//                int jj = next.Item2 + dr.Item2;
//                if (ii >= 0 && jj >= 0 && ii < rows.Count && jj < rows[0].Length && rows[ii][jj] != '#')
//                {
//                    var tu = new Tuple<int, int>(ii, jj);
//                    if (seent.Contains(tu))
//                    {
//                        continue;
//                    }
//                    if (junctions.ContainsKey(tu))
//                    {
//                        junctions[junction.Key].Add(tu, next.Item3 + 1);
//                    }
//                    else
//                    {
//                        cue.Enqueue(new Tuple<int, int, int>(ii, jj, next.Item3 + 1));
//                    }
//                }
//            }
//        }

//    }
//}

//int WalkBig(Tuple<int, int> coord)
//{
//    int m = -1;
//    if (coord == end)
//    {
//        return 0;
//    }
//    endSeen.Add(coord);
//    foreach (var ju in junctions[coord])
//    {
//        if (!endSeen.Contains(ju.Key))
//        {
//            m = Math.Max(m, WalkBig(ju.Key) + junctions[coord][ju.Key]);
//        }
//    }
//    endSeen.Remove(coord);
//    return m;
//}
//struct Node
//{
//    public Tuple<int, int> cur;
//    public int steps;
//    public HashSet<Tuple<int, int>> seen;
//}


