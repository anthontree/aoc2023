//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Text.RegularExpressions;
//using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<string> smallRows = new();
//List<string> bigRows = new();
//List<Tuple<int, int>> cur = new();
//Tuple<int, int> start1 = new(0, 0);
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    if (s != null)
//    {
//        smallRows.Add(s);
//        if (s.Contains('S'))
//        {
//            var co = s.IndexOf('S');
//            var ro = smallRows.Count - 1;
//            start1 = new Tuple<int, int>(ro, co);
//        }
//    }
//}
////game 1
//long res1 = CalcV(64, smallRows, start1);
//Console.WriteLine(res1);


////game2
//MakeBigRows();

//int x = smallRows.Count / 2;
//int y = smallRows.Count;
//int src = bigRows.Count / 2;
//Tuple<int, int> start2 = new(src, src);
//long v1 = CalcV(x, bigRows, start2);
//long v2 = CalcV(x + y, bigRows, start2);
//long v3 = CalcV(x + y + y, bigRows, start2);
//int n = 26501365 / y;
//long res2 = Lag(v1, v2, v3, n, 26501365);
//Console.WriteLine(res2);
//void MakeBigRows()
//{
//    for (int i = 0; i < 7; i++)
//    {
//        for (int r = 0; r < smallRows.Count; r++)
//        {
//            for (int j = 0; j < 7; j++)
//            {
//                if (bigRows.Count <= r + i * smallRows.Count)
//                {
//                    bigRows.Add("");
//                }
//                bigRows[r + i * smallRows.Count] += smallRows[r];
//            }
//        }
//    }
//}

//void Step(List<string> rows)
//{
//    HashSet<Tuple<int, int>> list = new();
//    foreach (var cu in cur)
//    {
//        if (cu.Item1 - 1 > 0)
//        {
//            if (rows[cu.Item1 - 1][cu.Item2] != '#')
//            {
//                var t = new Tuple<int, int>(cu.Item1 - 1, cu.Item2);
//                if (!list.Contains(t))
//                {
//                    list.Add(t);
//                }
//            }
//        }
//        if (cu.Item1 + 1 < rows.Count)
//        {
//            if (rows[cu.Item1 + 1][cu.Item2] != '#')
//            {
//                var t = new Tuple<int, int>(cu.Item1 + 1, cu.Item2);
//                if (!list.Contains(t))
//                {
//                    list.Add(t);
//                }
//            }
//        }
//        if (cu.Item2 - 1 > 0)
//        {
//            if (rows[cu.Item1][cu.Item2 - 1] != '#')
//            {
//                var t = new Tuple<int, int>(cu.Item1, cu.Item2 - 1);
//                if (!list.Contains(t))
//                {
//                    list.Add(t);
//                }
//            }
//        }
//        if (cu.Item2 + 1 < rows[0].Length)
//        {
//            if (rows[cu.Item1][cu.Item2 + 1] != '#')
//            {
//                var t = new Tuple<int, int>(cu.Item1, cu.Item2 + 1);
//                if (!list.Contains(t))
//                {
//                    list.Add(t);
//                }
//            }
//        }
//    }
//    cur.Clear();
//    cur.AddRange(list);
//}

//long CalcV(long steps, List<string> rows, Tuple<int, int> start)
//{
//    cur.Clear();
//    cur.Add(start);
//    for (int i = 0; i < steps; i++)
//    {
//        Step(rows);
//    }
//    return cur.Count;
//}

////figuring out the right lagrange to use
//long Lag(long v1, long v2, long v3, long n, long steps)
//{
//    //long a = (v3 - 2 * v2 + v1) / 2;
//    //long b = v2 - v1 - a;
//    //long c = v1;
//    ////long a = v1 / 2-v2+v3/2;
//    ////long b = -3*v1/2+2*v2-v3/2;
//    ////long c = v1;
//    ////both of these work the same...
//    //return a * n * n + b + n + c;
//    long res = 0;
//    List<long> list = [v1, v2, v3];
//    for (var i = 0; i < 3; i++)
//    {
//        long term = list[i];

//        for (var j = 0; j < 3; j++)
//        {
//            if (j != i)
//            {
//                term = term * (steps - (65 + j * 131)) / (65 + i * 131 - (65 + j * 131));
//            }
//        }
//        res += term;
//    }
//    return res;
//}
