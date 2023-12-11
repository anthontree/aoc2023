//using System;
//using System.Reflection.Metadata.Ecma335;
//using System.Runtime.ExceptionServices;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";


//StreamReader sr = new StreamReader(fPath);
//List<int> times = new List<int>();
//List<int> dists = new List<int>();
//double result = 1;
////while (!sr.EndOfStream)
////{
////    string? s = sr.ReadLine();

////    if (s != null)
////    {
////        s = Regex.Replace(s, @"\s+", " ");
////        if (s.ToLower().Contains("time"))
////        {            
////            foreach (var time in s.Split(':')[1].Trim().Split(' '))
////            {
////                if (string.IsNullOrEmpty(time)) continue;
////                times.Add(int.Parse(time.Trim()));
////            }
////        }
////        if (s.ToLower().Contains("dist"))
////        {
////            foreach (var dist in s.Split(':')[1].Trim().Split(' '))
////            {
////                if (string.IsNullOrEmpty(dist)) continue;
////                dists.Add(int.Parse(dist.Trim()));
////            }
////        }
////    }
////}

////for(int k = 0;k< times.Count;k++)
////{
////    result *= getPossibleWins(times[k], dists[k]);
////}


//double getPossibleWins(double time, double dist)
//{
//    double wins = 0;
//    for (double i = 0; i < time; i++)
//    {
//        if (i * (time - i) > dist)
//        {
//            wins++;
//        }
//    }
//    return wins;
//}




////if (!string.IsNullOrEmpty(r) && string.Compare(l, r, StringComparison.OrdinalIgnoreCase) == 0) { matches++; }










//Console.WriteLine(getPossibleWins(35937366, 212206012011044));


