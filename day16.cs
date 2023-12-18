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
//List<List<char>> field = new List<List<char>>();
//List<List<int>> ene = new List<List<int>>();
//Queue<Tuple<int, int, int, int>> queue = new Queue<Tuple<int, int, int, int>>();
//HashSet<Tuple<int, int, int, int>> memo = new HashSet<Tuple<int, int, int, int>>();
//int res = 0;

//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    List<char> list = new List<char>();
//    List<int> enel = new List<int>();

//    if (s != null)
//    {
//        foreach (char c in s)
//        {
//            enel.Add(0);
//            list.Add(c);
//        }
//    }
//    field.Add(list);
//    ene.Add(enel);
//}
////game 1
////var sta = new Tuple<int, int, int, int>(0, 0, 0, 1);
////queue.Enqueue(sta);
////while()
//Beam(0, 0, 0, 1);
//foreach (var l in ene)
//{
//    foreach (var i in l)
//    {
//        res += i;
//    }
//}
//Console.WriteLine(res);

////game 2
//for (int i = 0; i < ene.Count; i++)
//{
//    CalcDir(i, 0, 0, 1);
//    CalcDir(i, ene[0].Count - 1, 0, -1);
//}
//for (int j = 0; j < ene[0].Count; j++)
//{
//    CalcDir(0, j, 1, 0);
//    CalcDir(ene.Count, j, -1, 0);
//}
//Console.WriteLine(res);

//void CalcDir(int x, int y, int dx, int dy)
//{
//    memo.Clear();
//    for (int i = 0; i < ene.Count; i++)
//    {
//        for (int j = 0; j < ene[0].Count; j++)
//        {
//            ene[i][j] = 0;
//        }
//    }
//    Beam(x, y, dx, dy);
//    int n = 0;
//    foreach (var l in ene)
//    {
//        foreach (var i in l)
//        {
//            n += i;
//        }
//    }
//    res = Math.Max(res, n);
//}
//void Beam(int x, int y, int dx, int dy)
//{
//    if (x >= field.Count || y >= field[0].Count || x < 0 || y < 0)
//    {
//        return;
//    }
//    var mem = new Tuple<int, int, int, int>(x, y, dx, dy);
//    if (memo.Contains(mem))
//    { return; }
//    else
//    {
//        memo.Add(mem);
//    }
//    ene[x][y] = 1;
//    char c = field[x][y];
//    if (c == '.')
//    {
//        Beam(x + dx, y + dy, dx, dy);
//    }
//    else if (c == '-')
//    {
//        if (dx != 0)
//        {
//            Beam(x, y + 1, 0, 1);
//            Beam(x, y - 1, 0, -1);
//        }
//        else
//        {
//            Beam(x + dx, y + dy, dx, dy);
//        }
//    }
//    else if (c == '|')
//    {
//        if (dy != 0)
//        {
//            Beam(x + 1, y, 1, 0);
//            Beam(x - 1, y, -1, 0);
//        }
//        else
//        {
//            Beam(x + dx, y + dy, dx, dy);
//        }
//    }
//    else if (c == '/')
//    {
//        if (dx == -1)
//        {
//            Beam(x, y + 1, 0, 1);
//        }
//        else if (dx == 1)
//        {
//            Beam(x, y - 1, 0, -1);
//        }
//        else if (dy == 1)
//        {
//            Beam(x - 1, y, -1, 0);
//        }
//        else if (dy == -1)
//        {
//            Beam(x + 1, y, 1, 0);
//        }
//    }
//    else if (c == '\\')
//    {
//        if (dx == -1)
//        {
//            Beam(x, y - 1, 0, -1);
//        }
//        else if (dx == 1)
//        {
//            Beam(x, y + 1, 0, 1);
//        }
//        else if (dy == 1)
//        {
//            Beam(x + 1, y, 1, 0);
//        }
//        else if (dy == -1)
//        {
//            Beam(x - 1, y, -1, 0);
//        }
//    }
//}

