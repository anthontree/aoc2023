//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Security.Cryptography.X509Certificates;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<Pattern> field = new List<Pattern>();
//int result = 0;
//double result2 = 0;

//int wrInd = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        if (string.IsNullOrEmpty(s))
//        {
//            field[wrInd].SetCols();
//            wrInd++;
//            continue;
//        }

//        if (field.Count <= wrInd)
//        {
//            field.Add(new Pattern());
//        }
//        field[wrInd].rows.Add(s);
//    }

//}
//field[wrInd].SetCols();


////GAME 1
//foreach (Pattern p in field)
//{
//    var v = GetVert(p);
//    var h = GetHor(p);
//    result += h + 1 + (v + 1) * 100;
//}

//Console.WriteLine(result);


////GAME 2 
//foreach (Pattern p in field)
//{
//    var fv = GetVert(p);
//    var fh = GetHor(p);

//    var v = GetVert2(p, fv);
//    var h = GetHor2(p, fh);
//    if (v == -1 && h == -1)
//    {
//        Console.WriteLine("fv" + fv);
//        Console.WriteLine("fh:" + fh);
//        Console.WriteLine("v:" + v);
//        Console.WriteLine("h:" + h);
//        foreach (string r in p.rows)
//        {
//            Console.WriteLine(r);
//        }
//    }
//    result2 += h + 1 + (v + 1) * 100;
//}



//Console.WriteLine(result2);

////find vert reflec for one pat.. reeturn left col
//int GetVert(Pattern p)
//{
//    for (int i = 0; i < p.rows.Count - 1; i++)
//    {
//        if (p.rows[i] == p.rows[i + 1])
//        {
//            if (CheckAllRows(i, p))
//            {
//                return i;
//            }
//        }
//    }
//    return -1;
//}

////Findhor ref for one pattern return top row
//int GetHor(Pattern p)
//{
//    for (int i = 0; i < p.cols.Count - 1; i++)
//    {
//        if (p.cols[i] == p.cols[i + 1])
//        {
//            if (CheckAllCols(i, p))
//            {
//                return i;
//            }
//        }
//    }
//    return -1;
//}


////find vert reflec for one pat.. reeturn left col
//int GetVert2(Pattern p, int fv)
//{
//    for (int i = 0; i < p.rows.Count - 1; i++)
//    {
//        if (i == fv)
//        {
//            continue;
//        }
//        if (CheckAllRows2(i, p))
//        {
//            return i;
//        }
//    }
//    return -1;
//}

////Findhor ref for one pattern return top row
//int GetHor2(Pattern p, int fh)
//{
//    for (int i = 0; i < p.cols.Count - 1; i++)
//    {
//        if (i == fh)
//        {
//            continue;
//        }
//        if (CheckAllCols2(i, p))
//        {
//            return i;
//        }
//    }
//    return -1;
//}
//bool CheckAllRows(int i, Pattern p)
//{
//    int up = i;
//    int down = i + 1;
//    while (up >= 0 && down < p.rows.Count)
//    {
//        if (p.rows[up] != p.rows[down])
//        {
//            return false;
//        }
//        up--;
//        down++;
//    }
//    return true;
//}

//bool CheckAllCols(int i, Pattern p)
//{
//    int up = i;
//    int down = i + 1;
//    while (up >= 0 && down < p.cols.Count)
//    {
//        if (p.cols[up] != p.cols[down])
//        {
//            return false;
//        }
//        up--;
//        down++;
//    }
//    return true;
//}

//bool CheckAllRows2(int i, Pattern p)
//{
//    int up = i;
//    int down = i + 1;
//    int smudged = 0;
//    while (up >= 0 && down < p.rows.Count)
//    {
//        int ch = CheckForSmudge(p.rows[up], p.rows[down]);
//        if (ch == 1)
//        {
//            smudged++;
//        }
//        if (ch == -1 || smudged > 1)
//        {
//            return false;
//        }
//        up--;
//        down++;
//    }
//    return true;
//}

//bool CheckAllCols2(int i, Pattern p)
//{
//    int up = i;
//    int down = i + 1;
//    int smudged = 0;
//    while (up >= 0 && down < p.cols.Count)
//    {
//        int ch = CheckForSmudge(p.cols[up], p.cols[down]);
//        if (ch == 1)
//        {
//            smudged++;
//        }
//        if (ch == -1 || smudged > 1)
//        {
//            return false;
//        }
//        up--;
//        down++;
//    }
//    return true;
//}

//int CheckForSmudge(string a, string b)
//{
//    int diffs = 0;
//    for (int i = 0; i < a.Length; i++)
//    {
//        if (a[i] != b[i])
//        {
//            diffs++;
//        }
//        if (diffs > 1)
//        {
//            return -1;//-1 for not equal
//        }
//    }
//    return diffs;//1 for fixed 1 smudge//0 for equal
//}
//public class Pattern
//{
//    public List<string> rows = new List<string>();
//    public List<string> cols = new List<string>();

//    public void SetCols()
//    {
//        for (int i = 0; i < rows[0].Length; i++)
//        {
//            string s = "";
//            foreach (string s2 in rows)
//            {
//                s += s2[i];
//            }
//            cols.Add(s);
//        }
//    }
//}