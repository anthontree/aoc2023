//using System.Collections;
//using System.Collections.Generic;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<List<string>> field = new List<List<string>>();
//List<int> cols = new List<int>();
//List<int> rows = new List<int>();
//List<Coord> coords = new List<Coord>();
//int result = 0;
//double result2 = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        List<string> list = new List<string>();
//        //make nodes
//        foreach (char c in s.ToCharArray())
//        {
//            list.Add(c.ToString());
//        }
//        field.Add(list);
//    }
//}

//expands();
////expand(); enable for g1
//int rr = 0;
//foreach (var r in field)
//{
//    int cc = 0;
//    foreach (var c in r)
//    {
//        if (c == "#")
//        {
//            var cccc = new Coord() { r = rr, c = cc };
//            coords.Add(cccc);
//        }
//        cc++;
//    }
//    rr++;
//}

//for (int i = 0; i < coords.Count; i++)
//{
//    for (int j = i + 1; j < coords.Count; j++)
//    {
//        result += FindDist(coords[i], coords[j]);
//    }
//}
//Console.WriteLine(result);
//for (int i = 0; i < coords.Count; i++)
//{
//    for (int j = i + 1; j < coords.Count; j++)
//    {
//        int bet = GetBetweens(coords[i], coords[j]);
//        int dist = FindDist(coords[i], coords[j]);
//        result2 += (999999 * bet) + dist;//4,0 9,1
//    }
//}
//Console.WriteLine(result2);
//int GetBetweens(Coord a, Coord b)
//{
//    int bets = 0;
//    int minrow = Math.Min(a.r, b.r);
//    int mincol = Math.Min(a.c, b.c);
//    int maxrow = Math.Max(a.r, b.r);
//    int maxcol = Math.Max(a.c, b.c);
//    for (int rrr = minrow; rrr < maxrow; rrr++)
//    {
//        if (rows.Contains(rrr))
//        {
//            bets++;
//        }
//    }
//    for (int ccc = mincol; ccc < maxcol; ccc++)
//    {
//        if (cols.Contains(ccc))
//        {
//            bets++;
//        }
//    }
//    return bets;
//}
//int FindDist(Coord a, Coord b)
//{
//    return Math.Abs(a.c - b.c) + Math.Abs(a.r - b.r);
//}



//void expands()
//{
//    //get oness to expand
//    //cols
//    for (int i = 0; i < field[0].Count; i++)
//    {
//        if (IsCol(i))
//        {
//            cols.Add(i);
//        }
//    }
//    //rows
//    for (int i = 0; i < field.Count; i++)
//    {
//        if (IsRow(i))
//        {
//            rows.Add(i);
//        }
//    }
//}

//void expand()
//{
//    //apply expand cols
//    foreach (List<string> list in field)
//    {
//        int offsetc = 0;

//        foreach (int t in cols)
//        {
//            list.Insert(t + offsetc, ".");
//            offsetc++;
//        }
//    }
//    //rows

//    int offsetr = 0;
//    List<string> blank = new List<string>(field[rows[0]]);
//    foreach (int t in rows)
//    {
//        field.Insert(t + offsetr, blank);
//        offsetr++;
//    }
//}

//bool IsCol(int col)
//{
//    for (int i = 0; i < field.Count; i++)
//    {
//        if (field[i][col] == "#")
//        {
//            return false;
//        }
//    }
//    return true;
//}

//bool IsRow(int row)
//{
//    for (int i = 0; i < field[0].Count; i++)
//    {
//        if (field[row][i] == "#")
//        {
//            return false;
//        }
//    }
//    return true;
//}


//struct Coord
//{
//    public int c; public int r;
//}

