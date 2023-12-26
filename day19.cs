//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Runtime.ConstrainedExecution;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//string first = "in";
//Dictionary<string, List<Tuple<string, string, long, string>>> works = new Dictionary<string, List<Tuple<string, string, long, string>>>();
//List<Dictionary<string, long>> parts = new List<Dictionary<string, long>>();
//long res = 0;
//long res2 = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    List<long> list = new List<long>();
//    if (s != null)
//    {
//        if (string.IsNullOrEmpty(s))
//        {

//        }
//        else if (s[0] != '{')
//        {
//            var name = s.Split("{")[0];
//            var right = Regex.Replace(s.Split("{")[1], "}", "");
//            var nWork = new List<Tuple<string, string, long, string>>();
//            foreach (var item in right.Split(","))
//            {
//                if (item.Contains(":"))
//                {
//                    var spp = item.Split(":");
//                    var next = spp[1];
//                    var xmas = spp[0].Substring(0, 1);
//                    var con = spp[0].Substring(1, 1);
//                    var n = long.Parse(spp[0].Substring(2, spp[0].Length - 2));
//                    var tu = new Tuple<string, string, long, string>(xmas, con, n, next);
//                    nWork.Add(tu);
//                }
//                else
//                {
//                    nWork.Add(new Tuple<string, string, long, string>("L", "", 0, item));
//                }
//            }
//            works.Add(name, nWork);
//        }
//        else if (s[0] == '{')
//        {
//            string ns = Regex.Replace(s, "{", "");
//            ns = Regex.Replace(ns, "}", "");
//            var sp = ns.Split(',');
//            var dd = new Dictionary<string, long>();
//            foreach (string s2 in sp)
//            {
//                dd.Add(s2.Split('=')[0], long.Parse(s2.Split('=')[1])); ;
//            }
//            parts.Add(dd);
//        }
//    }
//}
////game 1

////for (int i = 0;i<parts.Count;i++) { Follow(first, i); }
////Console.WriteLine(res);

////game2
//var mxR = new Range
//{
//    minX = 1,
//    maxX = 4000,
//    minM = 1,
//    maxM = 4000,
//    minA = 1,
//    maxA = 4000,
//    minS = 1,
//    maxS = 4000
//};
//FollowAll(mxR, first);
//Console.WriteLine(res2);
//void Follow(string name, int partIndex)
//{
//    if (name == "R")
//    {
//        return;
//    }
//    if (name == "A")
//    {
//        foreach (var v in parts[partIndex])
//        {
//            res += v.Value;
//        }
//        return;
//    }
//    var wf = works[name];
//    foreach (var w in wf)
//    {
//        if (w.Item2 == "<")
//        {
//            if (parts[partIndex][w.Item1] < w.Item3)
//            {
//                Follow(w.Item4, partIndex);
//                return;
//            }
//        }
//        else if (w.Item2 == ">")
//        {
//            if (parts[partIndex][w.Item1] > w.Item3)
//            {
//                Follow(w.Item4, partIndex);
//                return;
//            }
//        }
//        else if (w.Item1 == "L")
//        {
//            Follow(w.Item4, partIndex);
//            return;
//        }
//    }
//}

//void FollowAll(Range path, string rName)
//{
//    if (rName == "R")
//    {
//        return;
//    }
//    if (rName == "A")
//    {
//        CalcCombos(path);
//        return;
//    }
//    var p = works[rName];
//    foreach (var r in p)
//    {
//        var nPath = new Range { minX = path.minX, maxX = path.maxX, minM = path.minM, maxM = path.maxM, minA = path.minA, maxA = path.maxA, minS = path.minS, maxS = path.maxS };

//        if (r.Item1 == "L")
//        {
//            FollowAll(nPath, r.Item4);
//            return;
//        }
//        if (r.Item2 == ">")
//        {
//            if (r.Item1 == "x")
//            {
//                path.maxX = r.Item3;
//                nPath.minX = r.Item3 + 1;
//            }
//            else if (r.Item1 == "m")
//            {
//                path.maxM = r.Item3;
//                nPath.minM = r.Item3 + 1;
//            }
//            else if (r.Item1 == "a")
//            {
//                path.maxA = r.Item3;
//                nPath.minA = r.Item3 + 1;
//            }
//            else if (r.Item1 == "s")
//            {
//                path.maxS = r.Item3;
//                nPath.minS = r.Item3 + 1;
//            }
//        }
//        else if (r.Item2 == "<")
//        {
//            if (r.Item1 == "x")
//            {
//                path.minX = r.Item3;
//                nPath.maxX = r.Item3 - 1;
//            }
//            else if (r.Item1 == "m")
//            {
//                path.minM = r.Item3;
//                nPath.maxM = r.Item3 - 1;
//            }
//            else if (r.Item1 == "a")
//            {
//                path.minA = r.Item3;
//                nPath.maxA = r.Item3 - 1;
//            }
//            else if (r.Item1 == "s")
//            {
//                path.minS = r.Item3;
//                nPath.maxS = r.Item3 - 1;
//            }
//        }
//        FollowAll(nPath, r.Item4);

//    }
//}
//bool ValidRanges(Range r)
//{
//    return r.minX < r.maxX && r.minM < r.maxM && r.minA < r.maxA && r.minS < r.maxS;
//}
//void CalcCombos(Range path)
//{
//    if (ValidRanges(path))
//    {
//        res2 += (path.maxX + 1 - path.minX) * (path.maxM + 1 - path.minM) * (path.maxA + 1 - path.minA) * (path.maxS + 1 - path.minS);
//    }
//    else
//    {
//        int i = 0;
//    }

//}
//struct Range
//{
//    public long minX, maxX, minM, maxM, minA, maxA, minS, maxS;
//}
