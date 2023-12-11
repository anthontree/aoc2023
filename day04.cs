//using System;
//using System.Reflection.Metadata.Ecma335;
//using System.Runtime.ExceptionServices;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";


//StreamReader sr = new StreamReader(fPath);
//List<int> copies = new List<int>();
//List<IEnumerable<string>> lefts = new List<IEnumerable<string>>();
//List<IEnumerable<string>> rights = new List<IEnumerable<string>>();
//double result = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        string[] topSplit = s.Split(':')[1].Split('|');
//        lefts.Add(topSplit[0].Trim().Split(' ').Distinct<string>());
//        rights.Add(topSplit[1].Trim().Split(' ').Distinct<string>());
//        copies.Add(1);
//    }
//}

//for (int i = 0; i < lefts.Count; i++)
//{
//    int matches = 0;
//    foreach (string l in lefts[i])
//    {
//        if (!string.IsNullOrEmpty(l))
//        {
//            foreach (string r in rights[i])
//            {
//                if (!string.IsNullOrEmpty(r) && string.Compare(l, r, StringComparison.OrdinalIgnoreCase) == 0) { matches++; }
//            }
//        }

//    }
//    if (matches > 0)
//    {
//        for (int k = i + 1; k <= i + matches; k++)
//        {
//            copies[k] += copies[i];
//        }
//    }
//    else
//    {
//        int y = 0;
//    }
//}
//foreach (var copy in copies)
//{
//    result += copy;
//}






//Console.WriteLine(result);


//// get left nums get right nums

