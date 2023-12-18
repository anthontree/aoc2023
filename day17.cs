//using System;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<List<int>> field = new List<List<int>>();
//Dictionary<Tuple<int, int, int, int, int>, int> memo = new Dictionary<Tuple<int, int, int, int, int>, int>();
//int res = 0;

////int wrInd = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    List<int> list = new List<int>();
//    if (s != null)
//    {
//        foreach (char c in s)
//        {
//            list.Add(int.Parse(c.ToString()));
//        }
//    }
//    field.Add(list);
//}
////game 1
//int max = 1000;
//PriorityQueue<Node, int> cue = new PriorityQueue<Node, int>();
//List<Dir> dirs = new List<Dir> { new Dir { pxd = 1, pyd = 0 }, new Dir { pxd = -1, pyd = 0 }, new Dir { pxd = 0, pyd = 1 }, new Dir { pxd = 0, pyd = -1 } };
////cue.Enqueue(new Node { x = 1, y = 0, st = 0, score = 0, dir = dirs[0], seen = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0) } }, 0);
////cue.Enqueue(new Node { x = 0, y = 1, st = 0, score = 0, dir = dirs[2], seen = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0) } }, 0);

////while (cue.Count > 0)
////{
////    var c = cue.Dequeue();
////    Hasha(c.x, c.y, c.score, c.st, c.dir, c.seen, c.maxX, c.maxY);
////}

//Console.WriteLine(res);

////game 2
//res = 0;
//int max2 = 1000;
//cue.Enqueue(new Node { x = 1, y = 0, st = 0, score = 3, dir = dirs[0], seen = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0) } }, 0);
//cue.Enqueue(new Node { x = 0, y = 1, st = 0, score = 3, dir = dirs[2], seen = new List<Tuple<int, int>> { new Tuple<int, int>(0, 0) } }, 0);
//memo.Clear();
//while (cue.Count > 0)
//{
//    var c = cue.Dequeue();
//    Hasha2(c.x, c.y, c.score, c.st, c.dir, c.seen, c.maxX, c.maxY);
//}
//Console.WriteLine(res);
//void Hasha(int xx, int yy, int tscore, int straightLine, Dir pDir, List<Tuple<int, int>> cPath, int maxX, int maxY)
//{
//    var tuu = new Tuple<int, int>(xx, yy);
//    var nSeen = new List<Tuple<int, int>>();
//    if (xx < maxX - 6 || yy < maxY - 6)
//    {
//        return;
//    }
//    if (cPath.Contains(tuu))
//    {
//        return;
//    }
//    else
//    {
//        nSeen.AddRange(cPath);
//        nSeen.Add(tuu);
//    }

//    if (OutOB(xx, yy))
//    {
//        return;
//    }
//    int nScore = tscore + field[xx][yy];
//    if (nScore > max)
//    {
//        return;
//    }
//    Tuple<int, int, int, int, int> tu = new Tuple<int, int, int, int, int>(xx, yy, pDir.pxd, pDir.pyd, straightLine);
//    if (!memo.ContainsKey(tu))
//    {
//        memo.Add(tu, nScore);
//    }
//    else
//    {
//        if (memo[tu] <= nScore)
//        {
//            return;
//        }
//        else
//        {
//            memo[tu] = nScore;
//        }
//    }
//    if (xx == field.Count - 1 && yy == field[0].Count - 1)
//    {
//        if (res == 0)
//        {
//            res = nScore;
//        }
//        else
//        {
//            if (nScore < res)
//            {
//                res = nScore;
//                max = res;
//            }
//        }
//    }

//    foreach (var d in dirs)
//    {
//        Node n = new Node();
//        n.x = xx;
//        n.y = yy;
//        n.score = nScore;
//        n.st = straightLine;
//        n.seen = nSeen;

//        if (d.pxd == pDir.pxd && d.pyd == pDir.pyd && n.st < 2)
//        {
//            n.dir = new Dir { pxd = d.pxd, pyd = d.pyd };
//            n.x += n.dir.pxd;
//            n.y += n.dir.pyd;
//            n.st++;
//            n.maxX = Math.Max(n.x, maxX);
//            n.maxY = Math.Max(n.y, maxY);
//            cue.Enqueue(n, cPath.Count);
//        }
//        else if (d.pxd != pDir.pxd && d.pyd != pDir.pyd)
//        {
//            n.dir = new Dir { pxd = d.pxd, pyd = d.pyd };
//            n.x += n.dir.pxd;
//            n.y += n.dir.pyd;
//            n.maxX = Math.Max(n.x, maxX);
//            n.maxY = Math.Max(n.y, maxY);
//            n.st = 0;
//            cue.Enqueue(n, cPath.Count);
//        }
//    }
//}

//void Hasha2(int xx, int yy, int tscore, int straightLine, Dir pDir, List<Tuple<int, int>> cPath, int maxX, int maxY)
//{
//    var tuu = new Tuple<int, int>(xx, yy);
//    var nSeen = new List<Tuple<int, int>>();
//    if (xx < maxX - 9 || yy < maxY - 9)
//    {
//        return;
//    }
//    if (cPath.Contains(tuu))
//    {
//        return;
//    }
//    else
//    {
//        nSeen.AddRange(cPath);
//        nSeen.Add(tuu);
//    }

//    if (OutOB(xx, yy))
//    {
//        return;
//    }
//    int nScore = tscore + field[xx][yy];
//    if (nScore > max2)
//    {
//        return;
//    }
//    Tuple<int, int, int, int, int> tu = new Tuple<int, int, int, int, int>(xx, yy, pDir.pxd, pDir.pyd, straightLine);
//    if (!memo.ContainsKey(tu))
//    {
//        memo.Add(tu, nScore);
//    }
//    else
//    {
//        if (memo[tu] <= nScore)
//        {
//            return;
//        }
//        else
//        {
//            memo[tu] = nScore;
//        }
//    }
//    if (xx == field.Count - 1 && yy == field[0].Count - 1)
//    {
//        if (res == 0)
//        {
//            res = nScore;
//        }
//        else
//        {
//            if (nScore < res)
//            {
//                res = nScore;
//                max = res;
//            }
//        }
//    }
//    if (straightLine < 3)
//    {
//        Node n = new Node();
//        n.x = xx;
//        n.y = yy;
//        n.score = nScore;
//        n.st = straightLine;
//        n.seen = nSeen;
//        n.dir = pDir;
//        n.x += n.dir.pxd;
//        n.y += n.dir.pyd;
//        n.st++;
//        n.maxX = Math.Max(n.x, maxX);
//        n.maxY = Math.Max(n.y, maxY);
//        cue.Enqueue(n, cPath.Count);
//        return;
//    }
//    foreach (var d in dirs)
//    {
//        Node n = new Node();
//        n.x = xx;
//        n.y = yy;
//        n.score = nScore;
//        n.st = straightLine;
//        n.seen = nSeen;
//        if (d.pxd == pDir.pxd && d.pyd == pDir.pyd && n.st < 9)
//        {
//            n.dir = new Dir { pxd = d.pxd, pyd = d.pyd };
//            n.x += n.dir.pxd;
//            n.y += n.dir.pyd;
//            n.st++;
//            n.maxX = Math.Max(n.x, maxX);
//            n.maxY = Math.Max(n.y, maxY);
//            cue.Enqueue(n, cPath.Count);
//        }
//        else if (d.pxd != pDir.pxd && d.pyd != pDir.pyd)
//        {
//            n.dir = new Dir { pxd = d.pxd, pyd = d.pyd };
//            n.x += n.dir.pxd;
//            n.y += n.dir.pyd;
//            n.maxX = Math.Max(n.x, maxX);
//            n.maxY = Math.Max(n.y, maxY);
//            n.st = 0;
//            cue.Enqueue(n, cPath.Count);
//        }
//    }
//}
//bool OutOB(int x, int y)
//{
//    return x < 0 || y < 0 || x > field.Count - 1 || y > field[0].Count - 1;
//}
//struct Node
//{
//    public int x, y, score, st, maxX, maxY;
//    public Dir dir;
//    public List<Tuple<int, int>> seen;
//}
//struct Dir
//{
//    public int pxd, pyd;
//}