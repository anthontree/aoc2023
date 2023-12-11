

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";


//StreamReader sr = new StreamReader(fPath);
//int result = 0;
//string prev = "";
//while (!sr.EndOfStream)
//{
//    string? read = sr.ReadLine();
//    string s = rep(read);
//    if (s != null)
//    {
//        int first = -1;
//        int last = -1;
//        foreach (char? c in s.ToCharArray())
//        {
//            int num = 0;
//            if (int.TryParse(c.ToString(), out num))
//            {
//                if (first < 0)
//                {
//                    first = num;
//                    last = num;
//                }
//                else
//                {
//                    last = num;
//                }
//            }
//        }
//        if (last > 0) { result += last; }
//        if (first > 0) { result += first * 10; }
//        prev = s;
//    }

//}
//Console.WriteLine(result);

//static string rep(string? s)
//{
//    if (s != null)
//    {
//        string[,] nums = { { "zero", "0" }, { "one", "o1e" }, { "two", "t2o" }, { "three", "t3e" }, { "four", "f4r" }, { "five", "f5e" }, { "six", "s6x" },
//            { "seven","s7n" }, { "eight","e8t" }, { "nine", "n9e" } };

//        for (int i = 0; i < nums.Length / 2; i++)
//        {
//            s = Regex.Replace(s, nums[i, 0], nums[i, 1]);
//        }
//    }

//    return s;
//}