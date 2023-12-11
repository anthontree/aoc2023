//using System.Runtime.ExceptionServices;
//using System.Text.RegularExpressions;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";


//StreamReader sr = new StreamReader(fPath);
//int result = 0;
//int powersum = 0;

//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    int id = 0;
//    if (s != null)
//    {
//        string[] split = s.Split(':');// split between game id and all grabs
//        int.TryParse(split[0].Split(' ')[1], out id);// get id
//        string[] grabs = split[1].Split(';');// split different grabs
//        bool ispos = true;
//        foreach (string grab in grabs)
//        {
//            ispos = ispos && isPossible(grab);
//            if (!ispos)
//            {
//                break;
//            }
//        }
//        if (ispos)
//        {
//            result += id;
//        }

//        int maxB = 0;
//        int maxR = 0;
//        int maxG = 0;
//        int tmaxB = 0;
//        int tmaxR = 0;
//        int tmaxG = 0;
//        foreach (string grab in grabs)
//        {
//            getMax(grab, out tmaxG, out tmaxB, out tmaxR);
//            maxB = Math.Max(maxB, tmaxB);
//            maxR = Math.Max(maxR, tmaxR);
//            maxG = Math.Max(maxG, tmaxG);
//        }

//        powersum += (maxG * maxR * maxB);
//    }

//}
//Console.WriteLine(result);
//Console.WriteLine(powersum);

//static bool isPossible(string? s)
//{
//    bool result = true;
//    //3 blue, 4 red; 12 red cubes, 13 green cubes, and 14 blue cubes
//    if (s != null)
//    {
//        string[] single = s.Split(',');

//        foreach (string sin in single)
//        {
//            string col = sin.Trim().Split(" ")[1];
//            int num = int.Parse(sin.Trim().Split(" ")[0]);
//            if (col.ToLower() == "blue" && num > 14)
//            {
//                return false;
//            }
//            if (col.ToLower() == "red" && num > 12)
//            {
//                return false;
//            }
//            if (col.ToLower() == "green" && num > 13)
//            {
//                return false;
//            }
//        }
//    }

//    return true;
//}

//static void getMax(string? s, out int maxG, out int maxB, out int maxR)
//{
//    maxB = 0;
//    maxR = 0;
//    maxG = 0;
//    string[] single = s.Split(',');

//    foreach (string sin in single)
//    {
//        string col = sin.Trim().Split(" ")[1];
//        int num = int.Parse(sin.Trim().Split(" ")[0]);
//        if (col.ToLower() == "blue")
//        {
//            maxB = Math.Max(maxB, num);
//        }
//        if (col.ToLower() == "red")
//        {
//            maxR = Math.Max(maxR, num);
//        }
//        if (col.ToLower() == "green")
//        {
//            maxG = Math.Max(maxG, num);
//        }
//    }
//}