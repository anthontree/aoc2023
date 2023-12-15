//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Runtime.ConstrainedExecution;
//using System.Security.Cryptography.X509Certificates;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<string> field = new List<string>();
//List<List<Tuple<string, int>>> field2 = new List<List<Tuple<string, int>>>();
//int result = 0;
//double result2 = 0;

////int wrInd = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        field.AddRange(s.Split(','));
//    }
//}

////game 1
//foreach (string s in field)
//{
//    result += Hasha(s);
//}
//Console.WriteLine(result);

////GAME 2

//for (int i = 0; i < 256; i++)
//{
//    field2.Add(new List<Tuple<string, int>>());
//}
//foreach (string s in field)
//{
//    if (s.Contains('-'))
//    {
//        Remove(s.Substring(0, s.Length - 1));
//    }
//    else
//    {
//        var st = s.Split('=');
//        Add(st[0], int.Parse(st[1]));
//    }
//}

//int b = 1;
//foreach (var box in field2)
//{
//    int i = 1;
//    foreach (var lens in box)
//    {
//        result2 += b * i * lens.Item2;
//        i++;
//    }
//    b++;
//}
//Console.WriteLine(result2);
//int Hasha(string s)
//{
//    int v = 0;
//    foreach (char c in s)
//    {
//        v = (17 * ((int)c + v)) % 256;
//    }
//    return v;
//}

//void Remove(string label)
//{
//    var box = field2[Hasha(label)];
//    for (int i = 0; i < box.Count; i++)
//    {
//        if (box[i].Item1 == label)
//        {
//            box.Remove(box[i]);
//        }
//    }
//}

//void Add(string label, int foc)
//{
//    var box = field2[Hasha(label)];
//    for (int i = 0; i < box.Count; i++)
//    {
//        if (box[i].Item1 == label)
//        {
//            box[i] = new Tuple<string, int>(label, foc);
//            return;
//        }
//    }
//    box.Add(new Tuple<string, int>(label, foc));
//}
