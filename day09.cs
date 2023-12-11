//using System.Collections;
//using System.Collections.Generic;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<List<int>> list = new List<List<int>>();
//List<List<int>> list2 = new List<List<int>>();
//var lr = "";
//double result = 0;
//double result2 = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        List<int> l = new List<int>();
//        foreach (string ss in s.Split(' '))
//        {
//            l.Add(int.Parse(ss.Trim()));
//        }
//        list.Add(l);
//    }
//}
////game 2
//list2 = reverse(list);
//foreach (List<int> l in list)
//{
//    result += extrap(l);
//}
//foreach (List<int> l in list2)
//{
//    result2 += extrap(l);
//}
//Console.WriteLine(result);
//Console.WriteLine(result2);

//int extrap(List<int> l)
//{
//    List<List<int>> tozer = new List<List<int>>();
//    tozer.Add(l);
//    while (!isAllZero(tozer[tozer.Count - 1]))
//    {
//        addDidffs(tozer);

//    }
//    NewNum(tozer);
//    return tozer[0][tozer[0].Count - 1];
//}

//bool isAllZero(List<int> l)
//{
//    foreach (int i in l)
//    {
//        if (i != 0)
//        {
//            return false;
//        }
//    }

//    return true;
//}

//void addDidffs(List<List<int>> tozer)
//{
//    List<int> curr = tozer[tozer.Count - 1];
//    List<int> newline = new List<int>();
//    for (int i = 0; i < curr.Count - 1; i++)
//    {
//        int n = curr[i + 1] - curr[i];
//        newline.Add(n);
//    }
//    tozer.Add(newline);
//}

//void NewNum(List<List<int>> tozer)
//{
//    for (int i = tozer.Count - 2; i > 0; i--)
//    {
//        int n = tozer[i][tozer[i].Count - 1];
//        int cur = tozer[i - 1][tozer[i - 1].Count - 1];
//        tozer[i - 1].Add(n + cur);
//    }
//}

//List<List<int>> reverse(List<List<int>> list)
//{
//    var newlist = new List<List<int>>();
//    foreach (List<int> l in list)
//    {
//        var rev = new List<int>();
//        for (int i = l.Count - 1; i > -1; i--)
//        {
//            rev.Add(l[i]);
//        }
//        newlist.Add(rev);
//    }
//    return newlist;
//}








