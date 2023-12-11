////using System;
////using System.ComponentModel;
////using System.Reflection;
////using System.Reflection.Metadata.Ecma335;
////using System.Runtime.ExceptionServices;
////using System.Security.Cryptography;
////using System.Text.RegularExpressions;
////using System.Xml.Serialization;
////using static System.Net.Mime.MediaTypeNames;
////using static System.Runtime.InteropServices.JavaScript.JSType;


////string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";
//////RL

//////AAA = (BBB, CCC)
//////BBB = (DDD, EEE)
//////CCC = (ZZZ, GGG)
//////DDD = (DDD, DDD)
//////EEE = (EEE, EEE)
//////GGG = (GGG, GGG)
//////ZZZ = (ZZZ, ZZZ)

////Dictionary<string, Step> steps = new Dictionary<string, Step>(); 
////StreamReader sr = new StreamReader(fPath);
////var lr = "";
////double result = 0;
////while (!sr.EndOfStream)
////{
////    string? s = sr.ReadLine();

////    if (s != null)
////    {
////        if(!s.Contains("(")&& !string.IsNullOrEmpty(s))
////        {
////            if(string.IsNullOrEmpty(lr))
////            {
////                lr = s;
////            }
////            else
////            {
////                lr += s;
////            }

////        }
////        if(s.Contains("(") && !string.IsNullOrEmpty(s))
////        {
////            Step step = new Step();
////            step.node = s.Split('=')[0].Trim();
////            step.left = s.Split('=')[1].Trim().Split(',')[0].Trim().Substring(1);
////            step.right = s.Split('=')[1].Trim().Split(',')[1].Trim().Substring(0,3);
////            steps.Add(s.Split('=')[0].Trim(), step);
////        }

////    }
////}
////Step current = steps["AAA"];
////int count = 0;

////cycle();
////void cycle()
////{
////    while (true)
////    {
////        foreach (char c in lr.ToCharArray())
////        {
////            if (c == 'L')
////            {
////                current = steps[current.left];
////            }
////            else if (c == 'R')
////            {
////                current = steps[current.right];
////            }
////            count++;
////            if (current.node == "ZZZ")
////            {
////                return;
////            }
////        }
////    }
////}


////Console.WriteLine(count);


////public class Step
////{
////    public string node = "";
////    public string left = "";
////    public string right = "";
////}



////11A = (11B, XXX)
////11B = (XXX, 11Z)
////11Z = (11B, XXX)
////22A = (22B, XXX)
////22B = (22C, 22C)
////22C = (22Z, 22Z)
////22Z = (22B, 22B)
////XXX = (XXX, XXX)


//using System.Collections;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";
////RL

////AAA = (BBB, CCC)
////BBB = (DDD, EEE)
////CCC = (ZZZ, GGG)
////DDD = (DDD, DDD)
////EEE = (EEE, EEE)
////GGG = (GGG, GGG)
////ZZZ = (ZZZ, ZZZ)

//Dictionary<string, Step> steps = new Dictionary<string, Step>();
//StreamReader sr = new StreamReader(fPath);
//Dictionary<string, Step> asteps = new Dictionary<string, Step>();
//List<int> indsteps = new List<int>();
//var lr = "";
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        if (!s.Contains("(") && !string.IsNullOrEmpty(s))
//        {
//            if (string.IsNullOrEmpty(lr))
//            {
//                lr = s;
//            }
//            else
//            {
//                lr += s;
//            }

//        }
//        if (s.Contains("(") && !string.IsNullOrEmpty(s))
//        {
//            Step step = new Step();
//            step.node = s.Split('=')[0].Trim();
//            step.left = s.Split('=')[1].Trim().Split(',')[0].Trim().Substring(1);
//            step.right = s.Split('=')[1].Trim().Split(',')[1].Trim().Substring(0, 3);
//            steps.Add(step.node, step);
//            if (step.node.Substring(2, 1) == "A")
//            {
//                asteps.Add(step.node, step);
//            }
//        }

//    }
//}


//int count = 0;
//foreach (Step astep in asteps.Values)
//{
//    count = 0;
//    cycle(astep);
//    indsteps.Add(count);
//}
//void cycle(Step astep)
//{
//    Step current = astep;

//    while (true)
//    {
//        foreach (char c in lr.ToCharArray())
//        {

//            if (c == 'L')
//            {
//                current = steps[current.left];
//            }
//            else if (c == 'R')
//            {
//                current = steps[current.right];
//            }
//            count++;

//            if (isDone(current))
//            {
//                return;
//            }
//        }

//    }
//}



//Console.WriteLine(LCM(indsteps.ToArray()));

//bool isDone(Step s)
//{
//    return s.node.Substring(2, 1) == "Z";
//}

//static long LCM(int[] arr)
//{
//    // Find the maximum value in arr[] 
//    int max_num = 0;
//    int n = arr.Length;
//    for (int i = 0; i < n; i++)
//    {
//        if (max_num < arr[i])
//        {
//            max_num = arr[i];
//        }
//    }

//    // Initialize result 
//    long res = 1;

//    // Find all factors that are present 
//    // in two or more array elements. 
//    int x = 2; // Current factor. 
//    while (x <= max_num)
//    {
//        // To store indexes of all array 
//        // elements that are divisible by x. 
//        ArrayList indexes = new ArrayList();
//        for (int j = 0; j < n; j++)
//        {
//            if (arr[j] % x == 0)
//            {
//                indexes.Add(j);
//            }
//        }

//        // If there are 2 or more array elements 
//        // that are divisible by x. 
//        if (indexes.Count >= 2)
//        {
//            // Reduce all array elements divisible 
//            // by x. 
//            for (int j = 0; j < indexes.Count; j++)
//            {
//                arr[(int)indexes[j]] = arr[(int)indexes[j]] / x;
//            }

//            res = res * x;
//        }
//        else
//        {
//            x++;
//        }
//    }

//    // Then multiply all reduced 
//    // array elements 
//    for (int i = 0; i < n; i++)
//    {
//        res = res * arr[i];
//    }

//    return res;
//}
//public class Step
//{
//    public string node = "";
//    public string left = "";
//    public string right = "";
//}







