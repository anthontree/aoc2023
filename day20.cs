//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text.RegularExpressions;
//using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);

//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    if (s != null)
//    {
//        if (s[0] == 'b')
//        {
//            //broadcaster -> hd, zj, sq, jz
//            string ri = s.Substring(15, s.Length - 15);
//            var ns = ri.Split(", ");
//            Game.nodes.Add("bc", new Broadcast(ns));

//        }
//        else if (s[0] == '%')
//        {
//            //%vh -> qc, rr
//            string name = s.Substring(1, 2);
//            string ri = s.Substring(7, s.Length - 7);
//            var ns = ri.Split(", ");
//            Game.nodes.Add(name, new FlipFlop(ns, name));
//        }
//        else if (s[0] == '&')
//        {
//            //&pb -> gf, gv, vp, qb, vr, hq, zj
//            string name = s.Substring(1, 2);
//            string ri = s.Substring(7, s.Length - 7);
//            var ns = ri.Split(", ");
//            Game.nodes.Add(name, new Conj(ns, name));
//        }
//    }
//}
//Game.SetInputs();
////game 1
//for (int j = 1; j < 1000000000; j++)
//{
//    Game.PushButton();
//}
//Console.WriteLine(Game.g1low * Game.g1high);
//public static class Game
//{
//    public static int pushes = 1;
//    public static Queue<Tuple<string, string, string>> pulses = new();
//    public static Dictionary<string, Node> nodes = new();
//    public static long g1low = 0;
//    public static long g1high = 0;

//    public static void SetInputs()
//    {
//        Dictionary<string, Node> blanks = new();
//        foreach (var kvp in nodes)
//        {
//            foreach (var n in kvp.Value.GetRec())
//            {
//                if (nodes.ContainsKey(n))
//                {
//                    var des = nodes[n];
//                    if (des is Conj)
//                    {
//                        (des as Conj).inputs.Add(kvp.Key, false);
//                    }
//                }
//                else
//                {
//                    blanks.Add(n, new BlankNode(n));
//                }
//            }
//        }
//        foreach (var k in blanks)
//        {
//            nodes.Add(k.Key, k.Value);
//        }
//    }



//    public static void PushButton()
//    {
//        pulses.Enqueue(new Tuple<string, string, string>("bc", "l", "button"));
//        while (0 < pulses.Count)
//        {
//            var next = pulses.Dequeue();
//            if (next.Item2 == "l")
//            {
//                nodes[next.Item1].Low(next.Item3);
//            }
//            if (next.Item2 == "h")
//            {
//                nodes[next.Item1].High(next.Item3);
//            }
//        }
//        pushes++;
//        CheckHighs();
//    }
//    static void CheckHighs()
//    {
//        foreach (var n in nodes.Values)
//        {
//            if (n is Conj)
//            {
//                var c = n as Conj;

//            }
//        }
//    }
//}

//public class BlankNode : Node
//{
//    public string name = "";
//    public BlankNode(string n)
//    {
//        name = n;
//    }
//    public List<string> GetRec()
//    {
//        return null;
//    }

//    public void High(string sender)
//    {
//        Game.g1high++;
//    }

//    public void Low(string sender)
//    {
//        Game.g1low++;
//    }
//}
//public class FlipFlop : Node
//{
//    public string name = "";
//    public bool on = false;
//    public FlipFlop(string[] s, string n) { rec.AddRange(s); name = n; }
//    public void High(string sender)
//    {
//        Game.g1high++;
//    }

//    public void Low(string sender)
//    {
//        Game.g1low++;
//        if (on)
//        {
//            foreach (string s in rec)
//            {
//                Game.pulses.Enqueue(new Tuple<string, string, string>(s, "l", name));
//            }
//        }
//        else
//        {
//            foreach (string s in rec)
//            {
//                Game.pulses.Enqueue(new Tuple<string, string, string>(s, "h", name));
//            }
//        }
//        on = !on;
//    }
//    public List<string> GetRec()
//    {
//        return rec;
//    }

//    public List<string> rec = new List<string>();
//}

//public class Conj : Node
//{
//    public string name = "";
//    public long lcm = 0;
//    public Conj(string[] s, string n) { rec.AddRange(s); name = n; }
//    Dictionary<string, int> highs = new();
//    public void High(string sender)
//    {
//        if (!highs.ContainsKey(sender))
//        {
//            highs.Add(sender, Game.pushes);
//            if (highs.Count == inputs.Count && name == "ns")
//            {
//                int[] arr = highs.Values.ToArray();
//                lcm = LCM(arr);//answer here
//            }
//        }
//        Game.g1high++;
//        inputs[sender] = true;
//        check();
//    }

//    public void Low(string sender)
//    {
//        Game.g1low++;
//        inputs[sender] = false;
//        check();
//    }
//    void check()
//    {
//        bool res = true;
//        foreach (bool b in inputs.Values)
//        {
//            res &= b;
//        }
//        if (res)
//        {
//            foreach (string s in rec)
//            {
//                Game.pulses.Enqueue(new Tuple<string, string, string>(s, "l", name));
//            }
//        }
//        else
//        {
//            foreach (string s in rec)
//            {
//                Game.pulses.Enqueue(new Tuple<string, string, string>(s, "h", name));
//            }
//        }
//    }
//    public List<string> GetRec()
//    {
//        return rec;
//    }

//    long LCM(int[] arr)
//    {
//        // Find the maximum value in arr[] 
//        int max_num = 0;
//        int n = arr.Length;
//        for (int i = 0; i < n; i++)
//        {
//            if (max_num < arr[i])
//            {
//                max_num = arr[i];
//            }
//        }

//        // Initialize result 
//        long res = 1;

//        int x = 2; // Current factor. 
//        while (x <= max_num)
//        {
//            ArrayList indexes = new ArrayList();
//            for (int j = 0; j < n; j++)
//            {
//                if (arr[j] % x == 0)
//                {
//                    indexes.Add(j);
//                }
//            }
//            if (indexes.Count >= 2)
//            {
//                for (int j = 0; j < indexes.Count; j++)
//                {
//                    arr[(int)indexes[j]] = arr[(int)indexes[j]] / x;
//                }

//                res = res * x;
//            }
//            else
//            {
//                x++;
//            }
//        }
//        for (int i = 0; i < n; i++)
//        {
//            res = res * arr[i];
//        }

//        return res;
//    }
//    public List<string> rec = new List<string>();
//    public Dictionary<string, bool> inputs = new();
//}

//public interface Node
//{ void High(string sender); void Low(string sender); List<string> GetRec(); }

//public class Broadcast : Node
//{
//    public string name = "bc";
//    public Broadcast(string[] s) { rec.AddRange(s); }
//    public List<string> rec = new List<string>();

//    public void High(string sender)
//    {
//        //Game.g1high++;
//    }

//    public void Low(string sender)
//    {
//        Game.g1low++;
//        foreach (string s in rec)
//        {
//            Game.pulses.Enqueue(new Tuple<string, string, string>(s, "l", name));
//        }
//    }
//    public List<string> GetRec()
//    {
//        return rec;
//    }
//}
