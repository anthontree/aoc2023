//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;
//using System.Runtime.ConstrainedExecution;
//using System.Runtime.InteropServices;
//using System.Security.Cryptography.X509Certificates;
//using System.Text.RegularExpressions;
//using System.Xml.Schema;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<Line> field = new List<Line>();
//List<Vert> path = new List<Vert>();
//long perim = 0;

//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        var sp = s.Split(" ");
//        Line l = new Line();
//        l.n = int.Parse(sp[1]);
//        l.dir = sp[0];
//        l.color = sp[2];
//        field.Add(l);
//    }
//}

////game1
////int cx = 0, cy = 0;
////for (int i = 0; i < field.Count; i++)
////{
////    var verti = field[i];
////    perim += verti.n;
////    if (verti.dir == "U")
////    {
////        cx -= verti.n;
////        path.Add(new Vert { x = cx, y = cy });
////    }
////    else if (verti.dir == "R")
////    {
////        cy += verti.n;
////        path.Add(new Vert { x = cx, y = cy });
////    }
////    else if (verti.dir == "D")
////    {
////        cx += verti.n;
////        path.Add(new Vert { x = cx, y = cy });
////    }
////    else if (verti.dir == "L")
////    {
////        cy -= verti.n;
////        path.Add(new Vert { x = cx, y = cy });
////    }

////}

////Console.WriteLine(GetArea());

////game 2
//long cx = 0, cy = 0;
//for (int i = 0; i < field.Count; i++)
//{
//    var verti = field[i];
//    verti.dir = verti.color.Substring(7, 1);
//    string hex = verti.color.Substring(2, 5);
//    verti.n = ToDec(hex);
//    perim += verti.n;
//    if (verti.dir == "3")
//    {
//        cx -= verti.n;
//        path.Add(new Vert { x = cx, y = cy });
//    }
//    else if (verti.dir == "0")
//    {
//        cy += verti.n;
//        path.Add(new Vert { x = cx, y = cy });
//    }
//    else if (verti.dir == "1")
//    {
//        cx += verti.n;
//        path.Add(new Vert { x = cx, y = cy });
//    }
//    else if (verti.dir == "2")
//    {
//        cy -= verti.n;
//        path.Add(new Vert { x = cx, y = cy });
//    }

//}

//Console.WriteLine(GetArea());
//long ToDec(string s)
//{
//    return Int64.Parse(s, System.Globalization.NumberStyles.HexNumber);
//}
//long GetArea()
//{
//    // | 1/2 [ (x1y2 + x2y3 + … + xn-1yn + xny1) –(x2y1 + x3y2 + … +xnyn - 1 + x1yn) ] |
//    long a = 0;
//    long b = 0;

//    for (int i = 0; i < path.Count; i++)
//    {
//        if (i < path.Count - 1)

//        {
//            a += path[i].x * path[i + 1].y;
//        }
//        else
//        {
//            a += path[i].x * path[0].y;
//        }
//    }
//    for (int i = 0; i < path.Count; i++)
//    {
//        if (i < path.Count - 1)

//        {
//            b += path[i].y * path[i + 1].x;
//        }
//        else
//        {
//            b += path[i].y * path[0].x;
//        }
//    }

//    return Math.Abs((a - b) / 2) + (perim + 2) / 2;
//}

//struct Vert
//{
//    public long x, y;
//}
//struct Line
//{
//    public long n;
//    public string dir, color;

//}

