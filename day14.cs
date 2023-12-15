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
//Pattern field = new Pattern();
//int result = 0;
//double result2 = 0;

////int wrInd = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        field.rows.Add(s);
//    }

//}
//field.SetCols();
////game 1
//foreach (string s in field.cols)
//{
//    int rocks = 0;
//    for (int i = 0; i < s.Length; i++)
//    {
//        if (s[i] == 'O')
//        {
//            rocks++;
//        }
//        if (s[i] == '#')
//        {
//            for (int j = 0; j < rocks; j++)
//            {
//                result += i - j;
//            }
//            rocks = 0;
//        }
//    }
//    for (int j = 0; j < rocks; j++)
//    {
//        result += s.Length - j;
//    }
//}
//Console.WriteLine(result);

////GAME 2


//var arr = field.GetChars();
////int tesee = CalcNorth(TiltNorth(arr));
////Console.WriteLine(tesee);
////var tiltN = TiltNorth(arr);
////PrintArr(tiltN);
////var tiltW = TiltWest(tiltN);
////PrintArr(tiltW);
////var tiltS = TiltSouth(tiltW);
////PrintArr(tiltS);
////var tiltE = TiltEast(tiltS);
////PrintArr(tiltE);
////var tester = CalcNorth(tiltN);
////Console.WriteLine(tester);


//List<char[,]> list = new List<char[,]>();
//list.Add(arr);
//int first = 0;
//int second = 0;
//int dist = 0;
//for (int z = 1; z < 1000000000; z++)
//{
//    list.Add(OneCycle(list[z - 1]));
//    if (Check(z))
//    {
//        break;
//    }
//}
//int remaining = 1000000000 - (first + 1);
//int remainder = remaining % dist;
//var final = list[first + remainder + 1];
//result2 = CalcNorth(final);
//Console.WriteLine(result2);



//bool Check(int index)
//{
//    for (int i = index - 1; i > -1; i--)
//    {
//        if (IsEqual(list[i], list[index]))
//        {
//            first = i;
//            second = index;
//            dist = index - i;
//            return true;
//        }
//    }
//    return false;
//}

//bool IsEqual(char[,] a, char[,] b)
//{
//    int rc = a.GetLength(0);
//    int cc = a.GetLength(1);
//    for (int i = 0; i < cc; i++)
//    {
//        for (int j = 0; j < rc; j++)
//        {
//            if (a[i, j] != b[i, j])
//            {
//                return false;
//            }
//        }
//    }
//    return true;
//}
//char[,] OneCycle(char[,] arr)
//{
//    var nor = TiltNorth(arr);
//    var wes = TiltWest(nor);
//    var sou = TiltSouth(wes);
//    var eas = TiltEast(sou);
//    return eas;
//}

//char[,] TiltNorth(char[,] arr)
//{
//    int rc = arr.GetLength(0);
//    int cc = arr.GetLength(1);
//    char[,] newArr = new char[rc, cc];
//    for (int i = 0; i < cc; i++)//each col
//    {
//        int spot = 0;
//        for (int j = spot; j < rc; j++)//each row
//        {
//            if (arr[j, i] == 'O')
//            {
//                newArr[j, i] = '.';
//                newArr[spot, i] = 'O';
//                spot++;
//            }
//            else if (arr[j, i] == '#')
//            {
//                newArr[j, i] = '#';
//                spot = j + 1;
//            }
//            else
//            {
//                newArr[j, i] = '.';
//            }
//        }
//    }
//    return newArr;
//}

//char[,] TiltSouth(char[,] arr)
//{
//    int rc = arr.GetLength(0);
//    int cc = arr.GetLength(1);
//    char[,] newArr = new char[rc, cc];
//    for (int i = 0; i < cc; i++)//each col
//    {
//        int spot = rc - 1; ;
//        for (int j = spot; j > -1; j--)//each row
//        {
//            if (arr[j, i] == 'O')
//            {
//                newArr[j, i] = '.';
//                newArr[spot, i] = 'O';
//                spot--;
//            }
//            else if (arr[j, i] == '#')
//            {
//                newArr[j, i] = '#';
//                spot = j - 1;
//            }
//            else
//            {
//                newArr[j, i] = '.';
//            }
//        }
//    }
//    return newArr;
//}
//char[,] TiltWest(char[,] arr)
//{
//    int rc = arr.GetLength(0);
//    int cc = arr.GetLength(1);
//    char[,] newArr = new char[rc, cc];
//    for (int i = 0; i < rc; i++)//each row
//    {
//        int spot = 0;
//        for (int j = spot; j < cc; j++)//each col
//        {
//            if (arr[i, j] == 'O')
//            {
//                newArr[i, j] = '.';
//                newArr[i, spot] = 'O';
//                spot++;
//            }
//            else if (arr[i, j] == '#')
//            {
//                newArr[i, j] = '#';
//                spot = j + 1;
//            }
//            else
//            {
//                newArr[i, j] = '.';
//            }
//        }
//    }
//    return newArr;
//}
//char[,] TiltEast(char[,] arr)
//{
//    int rc = arr.GetLength(0);
//    int cc = arr.GetLength(1);
//    char[,] newArr = new char[rc, cc];
//    for (int i = 0; i < rc; i++)//each row
//    {
//        int spot = cc - 1;
//        for (int j = spot; j > -1; j--)//each col
//        {
//            if (arr[i, j] == 'O')
//            {
//                newArr[i, j] = '.';
//                newArr[i, spot] = 'O';
//                spot--;
//            }
//            else if (arr[i, j] == '#')
//            {
//                newArr[i, j] = '#';
//                spot = j - 1;
//            }
//            else
//            {
//                newArr[i, j] = '.';
//            }
//        }
//    }
//    return newArr;
//}

//int CalcNorth(char[,] arr)//already tilted
//{
//    int res = 0;
//    int rc = arr.GetLength(0);
//    int cc = arr.GetLength(1);
//    for (int i = 0; i < rc; i++)//row
//    {
//        for (int j = 0; j < cc; j++)//col
//        {
//            if (arr[i, j] == 'O')
//            {
//                res += rc - i;
//            }
//        }
//    }
//    return res;
//}

//void PrintArr(char[,] arr)
//{
//    int rc = arr.GetLength(0);
//    int cc = arr.GetLength(1);
//    for (int i = 0; i < rc; i++)
//    {
//        string s = "";
//        for (int j = 0; j < cc; j++)
//        {
//            s += arr[i, j];

//        }
//        Console.WriteLine(s);
//    }
//}
//public struct IndexRange()
//{
//    public int start = 0; public int end = 0;
//}
//public class Pattern
//{
//    public List<string> rows = new List<string>();
//    public List<string> cols = new List<string>();

//    public void SetCols()
//    {
//        for (int c = 0; c < rows[0].Length; c++)
//        {
//            string s = "";
//            for (int r = rows.Count - 1; r > -1; r--)
//            {
//                s += rows[r][c];
//            }
//            cols.Add(s);
//        }
//    }

//    public char[,] GetChars()
//    {
//        int rowcnt = rows.Count;
//        int colcnt = cols.Count;
//        char[,] arr = new char[rowcnt, colcnt];
//        for (int r = 0; r < rowcnt; r++)
//        {
//            for (int c = 0; c < colcnt; c++)
//            {
//                arr[r, c] = rows[r][c];
//            }
//        }
//        return arr;
//    }
//}