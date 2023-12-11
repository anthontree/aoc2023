//using System;
//using System.Reflection.Metadata.Ecma335;
//using System.Runtime.ExceptionServices;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";


//StreamReader sr = new StreamReader(fPath);
//List<List<List<double>>> maps = new List<List<List<double>>>();
//List<double> seeds = new List<double>();
//double result = 0;
//int mapnum = -1;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        if (s.Contains("seeds"))
//        {
//            foreach (var seed in s.Split(':')[1].Trim().Split(' '))
//            {
//                if (string.IsNullOrEmpty(seed)) continue;
//                seeds.Add(double.Parse(seed.Trim()));
//            }
//        }
//        else if (string.IsNullOrEmpty(s)) { continue; }
//        else if (s.Contains("map"))
//        { mapnum++; maps.Add(new List<List<double>>()); continue; }

//        else
//        {
//            var strings = s.Split(' ').ToList();
//            List<double> templist = new List<double>();
//            foreach (string t in strings)
//            {
//                templist.Add(double.Parse(t));
//            }
//            maps[mapnum].Add(templist);
//        }
//    }
//}
//result = getMapped(0, seeds[0]);
//for (int p = 0; p < seeds.Count; p += 2)
//{
//    Console.WriteLine(p);
//    for (double st = seeds[p]; st < seeds[p] + seeds[p + 1]; st++)
//    {
//        result = Math.Min(result, getMapped(0, st));
//    }
//}

//double getMapped(int mapindex, double input)
//{
//    if (mapindex < maps.Count)
//    {
//        double mapped = -1;
//        foreach (var line in maps[mapindex])
//        {
//            if (input >= line[1])
//            {
//                double diff = input - line[1];
//                if (diff <= line[2])
//                {
//                    mapped = diff + line[0]; break;
//                }
//            }
//        }
//        return getMapped(mapindex + 1, mapped == -1 ? input : mapped);
//    }
//    else { return input; }
//}




////if (!string.IsNullOrEmpty(r) && string.Compare(l, r, StringComparison.OrdinalIgnoreCase) == 0) { matches++; }










//Console.WriteLine(result);


