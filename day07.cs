//using System;
//using System.ComponentModel;
//using System.Reflection;
//using System.Reflection.Metadata.Ecma335;
//using System.Runtime.ExceptionServices;
//using System.Security.Cryptography;
//using System.Text.RegularExpressions;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Runtime.InteropServices.JavaScript.JSType;


//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";


//StreamReader sr = new StreamReader(fPath);
//List<Player> players = new List<Player>();
//List<Player> sortedplayers = new List<Player>();
//List<Player> fives = new List<Player>();
//List<Player> fours = new List<Player>();
//List<Player> house = new List<Player>();
//List<Player> threes = new List<Player>();
//List<Player> twopairs = new List<Player>();
//List<Player> pairs = new List<Player>();
//List<Player> highs = new List<Player>();
//double result = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        var p = new Player { hand = s.Split(' ')[0] };
//        int b = 0;
//        var bi = s.Split(' ')[1].Trim();
//        int.TryParse(bi, out b);
//        p.bid = b;
//        players.Add(p);
//    }
//}


//foreach (Player p in players)
//{
//    addType(p);
//}

//sorttype(fives);
//sorttype(fours);
//sorttype(house);
//sorttype(threes);
//sorttype(twopairs);
//sorttype(pairs);
//sorttype(highs);

//remakePlayerlist();

//getScores();
//Console.WriteLine(result);


////game2
//sortedplayers = new List<Player>();
//fives = new List<Player>();
//fours = new List<Player>();
//house = new List<Player>();
//threes = new List<Player>();
//twopairs = new List<Player>();
//pairs = new List<Player>();
//highs = new List<Player>();
//foreach (Player p in players)
//{
//    addStrongestType(p);
//}

//sorttype2(fives);
//sorttype2(fours);
//sorttype2(house);
//sorttype2(threes);
//sorttype2(twopairs);
//sorttype2(pairs);
//sorttype2(highs);

//remakePlayerlist();
//result = 0;
//getScores();
//Console.WriteLine(result);

//void addStrongestType(Player p)
//{
//    string current = p.hand;
//    int str = getTypeStr(current);
//    string temphand = "";
//    foreach (Card2 c2 in Enum.GetValues(typeof(Card2)))
//    {
//        temphand = Regex.Replace(p.hand.ToLower(), "j", GetDescription(c2));
//        int tstr = getTypeStr(temphand);
//        int tcur = getTypeStr(current);
//        if (tstr > tcur)
//        {
//            current = temphand;
//            str = tstr;
//        }
//    }
//    if (str == 6) { fives.Add(p); }
//    else if (str == 5) { fours.Add(p); }
//    else if (str == 4) { house.Add(p); }
//    else if (str == 3) { threes.Add(p); }
//    else if (str == 2) { twopairs.Add(p); }
//    else if (str == 1) { pairs.Add(p); }
//    else if (str == 0) { highs.Add(p); }
//}

//int getTypeStr(string ph)
//{
//    var result5 = ph
// .GroupBy(_ => _)
// .Where(x => x.Count() == 5)
// .Select(x => x.Key);
//    var result4 = ph
// .GroupBy(_ => _)
// .Where(x => x.Count() == 4)
// .Select(x => x.Key);
//    var result3 = ph
// .GroupBy(_ => _)
// .Where(x => x.Count() == 3)
// .Select(x => x.Key);
//    var result2 = ph
// .GroupBy(_ => _)
// .Where(x => x.Count() == 2)
// .Select(x => x.Key);
//    //five
//    if (result5.Count() == 1)
//    {
//        return 6;
//    }
//    //fours

//    else if (result4.Count() == 1)
//    {
//        return 5;
//    }
//    else if (result3.Count() == 1 && result2.Count() == 1)
//    {
//        return 4;
//    }
//    else if (result3.Count() == 1 && result2.Count() == 0)
//    {
//        return 3;
//    }
//    else if (result3.Count() == 0 && result2.Count() == 2)
//    {
//        return 2;
//    }
//    else if (result3.Count() == 0 && result2.Count() == 1)
//    {
//        return 1;
//    }
//    else { return 0; }
//}
//void addType(Player p)
//{
//    var result5 = p.hand
// .GroupBy(_ => _)
// .Where(x => x.Count() == 5)
// .Select(x => x.Key);
//    var result4 = p.hand
// .GroupBy(_ => _)
// .Where(x => x.Count() == 4)
// .Select(x => x.Key);
//    var result3 = p.hand
// .GroupBy(_ => _)
// .Where(x => x.Count() == 3)
// .Select(x => x.Key);
//    var result2 = p.hand
// .GroupBy(_ => _)
// .Where(x => x.Count() == 2)
// .Select(x => x.Key);
//    //five
//    if (result5.Count() == 1)
//    {
//        fives.Add(p);
//    }
//    //fours

//    else if (result4.Count() == 1)
//    {
//        fours.Add(p);
//    }
//    else if (result3.Count() == 1 && result2.Count() == 1)
//    {
//        house.Add(p);
//    }
//    else if (result3.Count() == 1 && result2.Count() == 0)
//    {
//        threes.Add(p);
//    }
//    else if (result3.Count() == 0 && result2.Count() == 2)
//    {
//        twopairs.Add(p);
//    }
//    else if (result3.Count() == 0 && result2.Count() == 1)
//    {
//        pairs.Add(p);
//    }
//    else { highs.Add(p); }
//}

//void sorttype(List<Player> ps)
//{
//    for (int i = 1; i < ps.Count; i++)
//    {
//        swapIfAhigherThanB(ps, i);
//    }
//}

//void sorttype2(List<Player> ps)
//{
//    for (int i = 1; i < ps.Count; i++)
//    {
//        swapIfAhigherThanB2(ps, i);
//    }
//}
//void remakePlayerlist()
//{
//    sortedplayers = [.. fives, .. fours, .. house, .. threes, .. twopairs, .. pairs, .. highs];
//}

//void getScores()
//{
//    int len = sortedplayers.Count;
//    for (int i = 0; i < len; i++)
//    {
//        int rank = len - i;
//        int score = rank * sortedplayers[i].bid;
//        result += score;
//    }
//}


//void swapIfAhigherThanB(List<Player> pss, int i)
//{
//    if (isAhigherThanB(pss[i], pss[i - 1]))
//    {
//        Player t1 = pss[i];
//        Player t2 = pss[i - 1];
//        pss[i] = t2;
//        pss[i - 1] = t1;
//        if (i > 1) { swapIfAhigherThanB(pss, i - 1); }
//    }
//}

//bool isAhigherThanB(Player a, Player b)
//{
//    var ahand = a.hand.ToArray();
//    var bhand = b.hand.ToArray();
//    for (int i = 0; i < ahand.Length; i++)
//    {
//        int ac = 0;
//        int bc = 0;

//        if (!int.TryParse(ahand[i].ToString(), out ac))
//        {
//            ac = (int)Enum.Parse(typeof(Card), ahand[i].ToString().ToLower());
//        }
//        if (!int.TryParse(bhand[i].ToString(), out bc))
//        {
//            bc = (int)Enum.Parse(typeof(Card), bhand[i].ToString().ToLower());
//        }
//        if (ac > bc) { return true; }
//        if (bc > ac) { return false; }
//    }
//    return false;
//}

//void swapIfAhigherThanB2(List<Player> pss, int i)
//{
//    if (isAhigherThanB2(pss[i], pss[i - 1]))
//    {
//        Player t1 = pss[i];
//        Player t2 = pss[i - 1];
//        pss[i] = t2;
//        pss[i - 1] = t1;
//        if (i > 1) { swapIfAhigherThanB2(pss, i - 1); }
//    }
//}

//bool isAhigherThanB2(Player a, Player b)
//{
//    var ahand = a.hand.ToArray();
//    var bhand = b.hand.ToArray();
//    for (int i = 0; i < ahand.Length; i++)
//    {
//        int ac = 0;
//        int bc = 0;

//        if (!int.TryParse(ahand[i].ToString(), out ac))
//        {
//            ac = (int)Enum.Parse(typeof(Card2), ahand[i].ToString().ToLower());
//        }
//        if (!int.TryParse(bhand[i].ToString(), out bc))
//        {
//            bc = (int)Enum.Parse(typeof(Card2), bhand[i].ToString().ToLower());
//        }
//        if (ac > bc) { return true; }
//        if (bc > ac) { return false; }
//    }
//    return false;
//}
//string GetDescription(Enum value)
//{
//    return ((DescriptionAttribute)Attribute.GetCustomAttribute(
//        value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
//            .Single(x => x.GetValue(null).Equals(value)),
//        typeof(DescriptionAttribute)))?.Description ?? value.ToString();
//}

//public class Player
//{
//    public string hand = "";
//    public int bid = 0;
//}

//public enum Card
//{
//    t = 10,
//    j = 11,
//    q = 12,
//    k = 13,
//    a = 14
//}

//public enum Card2
//{
//    [Description("t")]
//    t = 10,
//    [Description("j")]
//    j = 1,
//    [Description("q")]
//    q = 12,
//    [Description("k")]
//    k = 13,
//    [Description("a")]
//    a = 14,
//    [Description("2")]
//    two = 2,
//    [Description("3")]
//    three = 3,
//    [Description("4")]
//    four = 4,
//    [Description("5")]
//    five = 5,
//    [Description("6")]
//    six = 6,
//    [Description("7")]
//    seven = 7,
//    [Description("8")]
//    eight = 8,
//    [Description("9")]
//    nine = 9
//}

