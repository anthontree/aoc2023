//using System;
//using System.Reflection.Metadata.Ecma335;
//using System.Runtime.ExceptionServices;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";


//StreamReader sr = new StreamReader(fPath);
//int result = 0;
//int ratios = 0;
//List<List<string>> schem = new List<List<string>>();
//int index = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    schem.Add(new List<string>());
//    if (s != null)
//    {
//        foreach (char value in s.ToCharArray())
//        {
//            schem[index].Add(value.ToString());
//        }
//    }
//    index++;
//}

//index = 0;

//int xlen = schem.Count;
//int ylen = schem[0].Count;

//for (int i = 0; i < xlen; i++)// each line
//{
//    int startOfNum = 0;
//    int endOfNum = 0;
//    int num = 0;
//    int temp = 0;
//    int j = 0;
//    while (j < ylen)// each char in a line
//    {
//        if (int.TryParse(schem[i][j], out temp))
//        {
//            startOfNum = j;
//            getNumFromIndex(i, j, out endOfNum, out num);
//            j = endOfNum + 1;
//            if (isSym(startOfNum, endOfNum, i))
//            {
//                //Console.WriteLine("issym");
//                result += num;
//            }
//        }
//        else
//        {
//            j++;
//        }
//    }

//}

//Console.WriteLine(result);

//for (int i = 0; i < xlen; i++)// each line
//{
//    int j = 0;
//    while (j < ylen)// each char in a line
//    {
//        if (schem[i][j] == "*" && HasTwo(i, j))
//        {
//            //Console.WriteLine("i: "+i+" j: "+j);
//            ratios += getRatio(i, j);
//        }
//        j++;
//    }

//}

//Console.WriteLine("ratios: " + ratios);
//void getNumFromIndex(int line, int sIndex, out int endnum, out int num)
//{
//    string thenum = schem[line][sIndex];
//    endnum = sIndex;
//    sIndex++;
//    int digit = 0;

//    while (sIndex < ylen && int.TryParse(schem[line][sIndex], out digit))
//    {
//        thenum += digit.ToString();
//        endnum = sIndex;
//        sIndex++;
//    }
//    num = int.Parse(thenum);
//    //Console.WriteLine("num: " + num);
//}

//bool isSym(int start, int end, int line)
//{

//    //above same or below -1 from start or +1 from end
//    //above
//    int searchSt = Math.Max(start - 1, 0);
//    int searchEn = Math.Min(ylen - 1, end + 1);
//    if (line > 0)
//    {
//        for (int a = searchSt; a <= searchEn; a++)
//        {
//            string test = schem[line - 1][a];
//            if (testSym(test)) { return true; }
//        }
//    }

//    //same
//    string stest = schem[line][searchSt];
//    if (testSym(stest)) { return true; }
//    string etest = schem[line][searchEn];
//    if (testSym(etest)) { return true; }
//    //below
//    if (line < xlen - 1)
//    {
//        for (int b = searchSt; b <= searchEn; b++)
//        {
//            string test = schem[line + 1][b];
//            if (testSym(test)) { return true; }
//        }
//    }
//    return false;
//}
//bool testSym(string t)
//{
//    int dummy = 0;
//    return t != " " && !int.TryParse(t, out dummy) && t != ".";
//}
////array
//// find numbers in a line, then save start/end loc 
//// find symbols around start/end loc
//// prevent boundary errors

////find gear, ssearch numbers

//bool HasTwo(int i, int j)
//{
//    int dummy = 0;
//    int adjnums = 0;
//    //above same or below -1 from start or +1 from end
//    //above
//    int searchSt = Math.Max(j - 1, 0);
//    int searchEn = Math.Min(ylen - 1, j + 1);
//    if (i > 0)
//    {
//        string test1 = schem[i - 1][searchSt];
//        string test2 = schem[i - 1][j];
//        string test3 = schem[i - 1][searchEn];
//        if (int.TryParse(test1, out dummy) && !int.TryParse(test2, out dummy) && int.TryParse(test3, out dummy)) { adjnums += 2; }//2
//        else if (!int.TryParse(test1, out dummy) && !int.TryParse(test2, out dummy) && !int.TryParse(test3, out dummy)) { }//0
//        else { adjnums++; }//1
//    }

//    //same
//    string stest = schem[i][searchSt];
//    if (int.TryParse(stest, out dummy)) { adjnums++; }
//    string etest = schem[i][searchEn];
//    if (int.TryParse(etest, out dummy)) { adjnums++; }
//    //below
//    if (i < xlen - 1)
//    {
//        string test1 = schem[i + 1][searchSt];
//        string test2 = schem[i + 1][j];
//        string test3 = schem[i + 1][searchEn];
//        if (int.TryParse(test1, out dummy) && !int.TryParse(test2, out dummy) && int.TryParse(test3, out dummy)) { adjnums += 2; }//2
//        else if (!int.TryParse(test1, out dummy) && !int.TryParse(test2, out dummy) && !int.TryParse(test3, out dummy)) { }//0
//        else { adjnums++; }//1
//    }
//    return adjnums == 2; ;

//}

//int getRatio(int i, int j)
//{
//    int dummy = 0;
//    int searchSt = Math.Max(j - 1, 0);
//    int searchEn = Math.Min(ylen - 1, j + 1);
//    int num1 = 0;
//    int num2 = 0;
//    int abov = i - 1;
//    int below = i + 1;
//    if (i > 0)
//    {
//        string test1 = schem[abov][searchSt];
//        if (int.TryParse(test1, out dummy))
//        {
//            int endnum = 0;
//            int num = 0;
//            int rew = searchSt;
//            while (rew - 1 >= 0 && int.TryParse(schem[abov][rew - 1], out dummy))
//            {
//                rew--;
//            }
//            getNumFromIndex(abov, rew, out endnum, out num);
//            if (num1 == 0) { num1 = num; }
//            else { if (num2 > 0) { breakpoint(); } num2 = num; }
//            if (endnum == searchSt && !int.TryParse(schem[abov][j], out dummy) && int.TryParse(schem[abov][searchEn], out dummy))
//            {
//                getNumFromIndex(abov, searchEn, out endnum, out num);
//                if (num1 == 0) { num1 = num; }
//                else { if (num2 > 0) { breakpoint(); } num2 = num; }
//            }
//        }
//        else
//        {
//            int inda = searchSt + 1;
//            while (inda <= searchEn)
//            {
//                if (int.TryParse(schem[abov][inda], out dummy))
//                {
//                    int endnum = 0;
//                    int num = 0;
//                    getNumFromIndex(abov, inda, out endnum, out num);
//                    if (num1 == 0) { num1 = num; }
//                    else { if (num2 > 0) { breakpoint(); } num2 = num; }
//                    inda = endnum + 1;
//                }
//                else
//                {
//                    inda++;
//                }
//            }
//        }
//    }

//    string test2 = schem[i][searchSt];
//    if (int.TryParse(test2, out dummy))
//    {
//        int endnum = 0;
//        int num = 0;
//        int rew = searchSt;
//        while (rew - 1 >= 0 && int.TryParse(schem[i][rew - 1], out dummy))
//        {
//            rew--;
//        }
//        getNumFromIndex(i, rew, out endnum, out num);
//        if (num1 == 0) { num1 = num; }
//        else { if (num2 > 0) { breakpoint(); } num2 = num; }
//    }
//    string test25 = schem[i][searchEn];
//    if (int.TryParse(test25, out dummy))
//    {
//        int endnum = 0;
//        int num = 0;
//        getNumFromIndex(i, searchEn, out endnum, out num);
//        if (num1 == 0) { num1 = num; }
//        else { if (num2 > 0) { breakpoint(); } num2 = num; }
//    }

//    if (i < xlen - 1)
//    {
//        string test3 = schem[below][searchSt];
//        if (int.TryParse(test3, out dummy))
//        {
//            int endnum = 0;
//            int num = 0;
//            int rew = searchSt;
//            while (rew - 1 >= 0 && int.TryParse(schem[below][rew - 1], out dummy))
//            {
//                rew--;
//            }
//            getNumFromIndex(below, rew, out endnum, out num);
//            if (num1 == 0) { num1 = num; }
//            else { if (num2 > 0) { breakpoint(); } num2 = num; }
//            if (endnum == searchSt && !int.TryParse(schem[below][j], out dummy) && int.TryParse(schem[below][searchEn], out dummy))
//            {
//                getNumFromIndex(below, searchEn, out endnum, out num);
//                if (num1 == 0) { num1 = num; }
//                else { if (num2 > 0) { breakpoint(); } num2 = num; }
//            }
//        }
//        else
//        {
//            int inda = searchSt + 1;
//            while (inda <= searchEn)
//            {
//                if (int.TryParse(schem[below][inda], out dummy))
//                {
//                    int endnum = 0;
//                    int num = 0;
//                    getNumFromIndex(below, inda, out endnum, out num);
//                    if (num1 == 0) { num1 = num; }
//                    else { if (num2 > 0) { breakpoint(); } num2 = num; }
//                    inda = endnum + 1;
//                }
//                else
//                {
//                    inda++;
//                }
//            }
//        }
//    }
//    Console.WriteLine("num1: " + num1 + "num2: " + num2);
//    return num1 * num2;
//}

//void breakpoint()
//{
//    int i = 0;
//}