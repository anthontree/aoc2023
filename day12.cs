//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Security.Cryptography.X509Certificates;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<Line> field = new List<Line>();
//List<Line> field2 = new List<Line>();
//Dictionary<Tuple<int, int, int>, double> memo = new Dictionary<Tuple<int, int, int>, double>();
//int result = 0;
//double result2 = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        Line line = new Line(s.Split(' ')[0], s.Split(' ')[1].Split(','));
//        line.lin = s;
//        field.Add(line);
//    }
//}


////use brute force first
//// where do . come into play
////GAME 1
////foreach (var l in field)
////{
////    int lineNum = ProcessLine(l);
////    result += lineNum;
////}
//Console.WriteLine(result);

////GAME 2

//////test

////var zz = field[0];
////var all =GetOneSubset(zz.GetGroups(), zz);

//////endtest

//Unfold();
////field2 = field;
////maybe this would eventually work. but i know there has to be a math way to help this out.... spoiler alert it wont... just did that math on on some of the big ones lol
////foreach (var l in field2)
////{
////    double lineNum = ProcessLine(l); 
////    result2 += lineNum;
////    Console.WriteLine(lineNum + ":::" + l.lin);

////}


//foreach (var l in field2)
//{
//    double lineNum = ProcessLine2(l);
//    result2 += lineNum;
//    //Console.WriteLine(lineNum + ":::");// + l.lin);
//}
//Console.WriteLine(result2);

////get min length of the sections
////find first avail until reaches min length until end of list
//// find next poss, find next
//// if all fit then ++
//int ProcessLine(Line l)
//{
//    int ret = Combos(0, l, 0, l.car);
//    int i = 0;
//    //while (i < l.firstKnownBreak && i <= l.maxIndex)//check maths here TODO
//    //{
//    //    char[] car = l.springs.ToArray();
//    //    if (car[i] != '.')
//    //    {
//    //        var thisSectLen = int.Parse(l.broken[0]);
//    //        ret += Combos(i+thisSectLen+1, l, 0);
//    //    }
//    //    i++;
//    //}

//    return ret;
//}

//int Combos(int index, Line l, int sect, char[] cuur) // return combos for a given inddex and sections left over : recursive?
//{
//    int maxIndex = l.GetNewMaxIndex(l.broken.GetRange(sect, l.broken.Count - sect));
//    int c = 0;
//    int startRangeEnd = -1; ;// usedd for section length overlap of next break
//    var thisSectLen = int.Parse(l.broken[sect]);
//    int nextBreak = -1;//condition to end this recur?
//    // thisSectLen + index > next?

//    //get next break
//    for (int i = index; i < l.carLen; i++)
//    {
//        if (l.car[i].ToString() == "#")
//        {
//            if (thisSectLen + index < i)
//            {
//                nextBreak = i;
//                break;
//            }
//            else
//            {
//                startRangeEnd = i;// max possible index for this section to start
//            }
//        }
//    }
//    if (nextBreak == -1)
//    {
//        nextBreak = l.carLen - 1;
//    }
//    if (startRangeEnd == -1)
//    {
//        startRangeEnd = maxIndex;
//    }
//    //get all combos for moving 2nd element away 1 by 1
//    //will start at end of first break and go until next known break
//    // will return combos each time as if the 2nd element is the new first element
//    for (int i = index; i < nextBreak + 1; i++)//moves 2nd
//    {
//        char[] curr = new char[cuur.Length];
//        for (int k = 0; k < cuur.Length; k++)
//        {
//            curr[k] = cuur[k];
//        }
//        if (i > startRangeEnd || i > maxIndex)//break here to check if maths is right todo; end early if out of ranges //i > nextBreak - thisSectLen  ||
//        {
//            break;
//        }
//        if (CanSectionHere(thisSectLen, l.car, i))
//        {

//            // can section here nneds to include the recursive conditons... maybe. unless range conditions fix this
//            // have to figue out if section overlaps next; done
//            int newindex = i + thisSectLen + 1;
//            //replace 
//            for (int j = i; j < newindex - 1; j++)
//            {
//                if (j < curr.Length)
//                {
//                    curr[j] = '#';
//                }
//            }

//            if (sect == l.broken.Count - 1)
//            {
//                var numBreaks = curr.Where(x => x == '#')
//                     .Select(x => x).Count();

//                if (numBreaks == l.expected)
//                {
//                    c++;
//                }

//            }
//            if (sect + 1 < l.broken.Count)
//            {
//                //need to make sure all # are accounted for
//                c += Combos(newindex, l, sect + 1, curr);//how to determin start of next section?? 
//            }

//        }
//    }
//    return c;
//}

//bool CanSectionHere(int thisSectLen, char[] car, int index)
//{
//    //false right
//    if ((index + thisSectLen) < car.Length && car[index + thisSectLen] == '#')
//    {
//        return false;
//    }
//    //false left
//    if (index > 0 && car[index - 1] == '#')
//    {
//        return false;
//    }
//    for (int i = index; i < index + thisSectLen; i++)
//    {
//        if (car[i] == '.')
//        {
//            return false;
//        }
//    }
//    return true;
//}

//void Unfold()
//{
//    foreach (var l in field)
//    {
//        var newSprings = string.Empty;
//        var newBroken = new List<string>();
//        var newLin = string.Empty;
//        for (int i = 0; i < 5; i++)
//        {
//            newSprings += l.springs;
//            if (i != 4)
//            {
//                newSprings += "?";
//            }
//            newBroken.AddRange(l.broken);
//        }
//        string reduced = ReduceDots(newSprings);
//        var newLine = new Line(newSprings, newBroken.ToArray());
//        newLine.lin += reduced + " ";
//        foreach (string s in newBroken)
//        {
//            newLine.lin += s + ",";
//        }
//        field2.Add(newLine);
//    }
//}

//string ReduceDots(string s)
//{
//    string pattern = @"\.{2,}";
//    return Regex.Replace(s, pattern, ".");
//}
//double ProcessLine2(Line l)
//{
//    memo.Clear();
//    double ret2 = Combos2(0, l, 0, l.car);
//    //if (ret != ret2)
//    //{
//    //    Console.WriteLine(ret + ":::" + ret2);// + l.lin);
//    //}
//    //Console.WriteLine(ret + ":::" + ret2);// + l.lin);
//    return ret2;
//}

//double Combos2(int index, Line l, int sect, char[] cuur) // return combos for a given inddex and sections left over : recursive?
//{
//    int maxIndex = l.GetNewMaxIndex(l.broken.GetRange(sect, l.broken.Count - sect));
//    double c = 0;
//    int startRangeEnd = -1; ;// usedd for section length overlap of next break
//    var thisSectLen = int.Parse(l.broken[sect]);


//    for (int i = index; i < l.carLen; i++)
//    {
//        if (l.car[i].ToString() == "#")
//        {
//            if (thisSectLen + index < i)
//            {
//                break;
//            }
//            else
//            {
//                startRangeEnd = i;// max possible index for this section to start
//            }
//        }
//    }
//    if (startRangeEnd == -1)
//    {
//        startRangeEnd = maxIndex;
//    }
//    int cuurCnt = 0;
//    for (int z = 0; z < index; z++)
//    {
//        if (cuur[z] == '#')
//        {
//            cuurCnt++;
//        }
//    }
//    Tuple<int, int, int> tu = new Tuple<int, int, int>(index, sect, cuurCnt);
//    if (memo.ContainsKey(tu))
//    {
//        return memo[tu];
//    }
//    for (int i = index; i <= maxIndex; i++)//moves 2nd
//    {
//        char[] curr = new char[cuur.Length];
//        for (int k = 0; k < cuur.Length; k++)
//        {
//            curr[k] = cuur[k];
//        }
//        if (i > startRangeEnd)
//        {
//            break;
//        }
//        if (CanSectionHere(thisSectLen, l.car, i))
//        {
//            int newindex = i + thisSectLen + 1;
//            for (int j = i; j < newindex - 1; j++)
//            {
//                if (j < curr.Length)
//                {
//                    curr[j] = '#';
//                }
//            }
//            if (sect == l.broken.Count - 1)
//            {
//                var numBreaks = curr.Where(x => x == '#')
//                    .Select(x => x).Count();

//                if (numBreaks == l.expected)
//                {
//                    c++;
//                }
//            }
//            if (sect + 1 < l.broken.Count)
//            {
//                c += Combos2(newindex, l, sect + 1, curr);
//            }
//        }
//    }
//    memo.Add(tu, c);
//    return c;
//}




//public class Line
//{
//    public string springs = string.Empty;
//    public char[] car;
//    public List<string> broken = new List<string>();
//    public int minleng = 0;
//    public int firstKnownBreak = 0;
//    public int maxIndex = 0;
//    public int carLen = 0;
//    public string lin = "";
//    public int expected = 0;
//    public Line(string springs, string[] broken)
//    {
//        this.springs = springs;
//        this.broken.AddRange(broken);
//        minleng = GetMinLen(this.broken);
//        car = springs.ToCharArray();
//        firstKnownBreak = GetFirst();
//        carLen = car.Length;
//        maxIndex = carLen - minleng;
//        expected = CalcExpected();
//    }
//    private int CalcExpected()
//    {
//        int r = 0;
//        foreach (string s in this.broken)
//        {
//            r += int.Parse(s);
//        }
//        return r;
//    }
//    public int GetNewMaxIndex(List<string> b) { return carLen - GetMinLen(b); }
//    public int GetMinLen(List<string> b)
//    {
//        int res = 0;
//        foreach (string s in b)
//        {
//            res += int.Parse(s) + 1;
//        }
//        if (res > 0)
//        {
//            return res - 1;//last section ddoesnt need a +1
//        }
//        else { return 0; }

//    }

//    private int GetFirst()
//    {
//        int res = 0;
//        foreach (char c in car)
//        {
//            if (c.ToString() == "#")
//            {
//                break;
//            }
//            res++;
//        }
//        return res;
//    }

//    public string[] GetGroups() { return springs.Split('.'); }
//}

//public struct IndexRange()
//{
//    public int start = 0; public int end = 0;
//}



////List<List<IndexRange>> GetOneSubset(string[] groups, Line l)// list of contigs per each group.. top level list leng should equal groups len
////{
////    List<List<IndexRange>> all = new List<List<IndexRange>>();
////    var singleGroupSubsets = GetSubsetsForGroupFromIndex(0, groups[0], l);
////    foreach (var group in singleGroupSubsets)
////    {
////        GetNextGroup(0, groups, singleGroupSubsets, l, all, 0, new List<IndexRange>());
////    }
////    //for (int j = 0; j < groups.Length; j++)//pick starting group
////    //{
////    //    var singleGroupSubsets = GetSubsetsForGroupFromIndex(0, groups[j], l);
////    //    //next group then next group

////    //}
////    return all;
////}

//////one whole subset is List<IndexRange>
//////all subsets for a line List<List<IndexRange>>... how to build this..
////int GetNextGroup(int groupIndex, string[] groups, List<IndexRange> rs, Line l, List<List<IndexRange>> allSubsets, int allIndex, List<IndexRange> currTrack)
////{
////    int f = 0;
////    int totIndex = allIndex;
////    while (f < rs.Count)
////    {
////        List<IndexRange> newCurTrack = new List<IndexRange>(currTrack);
////        while (allSubsets.Count <= totIndex)
////        {
////            List<IndexRange> newList = new List<IndexRange>();
////            foreach (var v in currTrack)
////            {
////                newList.Add(v);
////            }
////            allSubsets.Add(newList);
////        }
////        allSubsets[totIndex].Add(rs[f]);
////        newCurTrack.Add(rs[f]);

////        if (groupIndex < groups.Length - 1)
////        {
////            var singleGroupSubsets = GetSubsetsForGroupFromIndex(rs[f].end + 1, groups[groupIndex + 1], l);
////            totIndex += GetNextGroup(groupIndex + 1, groups, singleGroupSubsets, l, allSubsets, totIndex, newCurTrack);
////        }
////        totIndex++;
////        f++;
////    }
////    return totIndex;
////}

////List<IndexRange> GetSubsetsForGroupFromIndex(int index, string group, Line l)
////{
////    List<IndexRange> indexRange = new List<IndexRange>();//add a skip
////    indexRange.Add(new IndexRange { start = -1, end = index - 1 });
////    for (int i = 1; i <= l.broken.Count - index; i++)//try subsets for this group
////    {
////        var rang = l.broken.GetRange(index, i);
////        if (CanFitInGroup(group, rang))
////        {

////            indexRange.Add(new IndexRange { start = index, end = index + i - 1 });
////        }
////        else
////        {
////            break;
////        }
////    }
////    return indexRange;
////}
////bool CanFitInGroup(string group, List<string> subset)
////{
////    int subsetSize = 0;
////    foreach (string s in subset)
////    {
////        int contig = int.Parse(s);
////        subsetSize += contig + 1;
////    }
////    subsetSize--;//doesnt need the last separator for the gorup
////    return group.Length >= subsetSize;
////}