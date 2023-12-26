
//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//double res1 = 0;
//var hails = new List<Hail>();
////var collisions = new Dictionary<Hail,Dictionary<Hail, double>>();
////PriorityQueue<Tuple<Hail, Hail>, double> cue = new();
////HashSet<Hail> actual = new();
//char ax = 'a';
//int i1 = 0;
//int i2 = 0;

//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();
//    if (s != null)
//    {
//        var sides = s.Split(" @ ");
//        var left = sides[0].Split(", ");
//        var right = sides[1].Split(", ");
//        var v1 = new Hail
//        {
//            px = double.Parse(left[0]),
//            py = double.Parse(left[1]),
//            pz = double.Parse(left[2]),
//            vx = double.Parse(right[0]),
//            vy = double.Parse(right[1]),
//            vz = double.Parse(right[2])
//        };
//        hails.Add(v1);
//    }
//}
////game 1

////Game1();

//Game2();
//void Game1()
//{
//    for (int i = 0; i < hails.Count; i++)
//    {
//        for (int j = i + 1; j < hails.Count; j++)
//        {
//            CalcCollisions(hails[i], hails[j], 200000000000000, 400000000000000);
//            //CalcCollisions(hails[i], hails[j], 7, 27);
//        }
//    }
//    //while (cue.Count > 0)
//    //{
//    //    var c = cue.Dequeue();
//    //    if (!actual.Contains(c.Item1) && !actual.Contains(c.Item2))
//    //    {
//    //        actual.Add(c.Item1);
//    //        actual.Add(c.Item2);
//    //        res1++;
//    //    }
//    //}
//    Console.WriteLine(res1);
//}


//void Game2()
//{
//    FindPair();//i could make this more robust but i just used a breakpoint to fins out which axis
//    double z0 = hails[i1].pz;
//    double vz0 = hails[i1].vz;
//    //t = (px2-px1)/(vx1-vx2)
//    var t = (hails[0].pz - z0) / (vz0 - hails[0].vz);
//    var x = hails[0].px + hails[0].vx * t;
//    var y = hails[0].py + hails[0].vy * t;
//    var z = hails[0].pz + hails[0].vz * t;
//    var t2 = (hails[1].pz - z0) / (vz0 - hails[1].vz);
//    var x2 = hails[1].px + hails[1].vx * t2;
//    var y2 = hails[1].py + hails[1].vy * t2;
//    var z2 = hails[1].pz + hails[1].vz * t2;
//    var yv0 = (y2 - y) / (t2 - t);
//    var xv0 = (x2 - x) / (t2 - t);
//    var x0 = x - xv0 * t;
//    var y0 = y - yv0 * t;
//    double res2 = x0 + y0 + z0;
//    Console.WriteLine(res2);
//}
//void CalcCollisions(Hail h1, Hail h2, double zoneMin, double zoneMax)
//{
//    double m1 = h1.vy / h1.vx;
//    double m2 = h2.vy / h2.vx;
//    if (m1 != m2)
//    {
//        double x = (h2.px * m2 - h1.px * m1 + h1.py - h2.py) / (m2 - m1);
//        double y = m1 * (x - h1.px) + h1.py;
//        if (zoneMin <= x && zoneMax >= x && zoneMin <= y && zoneMax >= y)
//        {
//            double time = (x - h1.px) / h1.vx;
//            double time2 = (y - h2.px) / h2.vx;// can be -?
//            if (time > 1)
//            {
//                //if (!collisions.ContainsKey(h1))
//                //{
//                //    var nd = new Dictionary<Hail, double>();
//                //    nd.Add(h2, time);
//                //    collisions.Add(h1, nd);
//                //}
//                //else
//                //{
//                //    collisions[h1].Add(h2, time);
//                //}
//                //cue.Enqueue(new(h1, h2), time);
//                bool hh1 = (x - h1.px) * h1.vx >= 0 && (y - h1.py) * h1.vy >= 0;
//                bool hh2 = (x - h2.px) * h2.vx >= 0 && (y - h2.py) * h2.vy >= 0;
//                if (hh1 && hh2)
//                {
//                    res1++;
//                }
//            }
//        }
//    }
//}

//void FindPair()
//{

//    for (int i = 0; i < hails.Count; i++)
//    {
//        for (int j = i + 1; j < hails.Count; j++)
//        {
//            double sx = 0;
//            double sv = 0;

//            if (hails[i].px == hails[j].px)
//            {
//                sx = hails[i].px;

//            }
//            if (hails[i].py == hails[j].py)
//            {
//                sx = hails[i].py;
//            }
//            if (hails[i].pz == hails[j].pz)
//            {
//                sx = hails[i].pz;
//            }
//            if (hails[i].vx == hails[j].vx)
//            {
//                sv = hails[i].vx;
//                ax = 'x';
//            }
//            if (hails[i].vy == hails[j].vy)
//            {
//                sv = hails[i].vy;
//                ax = 'y';
//            }
//            if (hails[i].vz == hails[j].vz)
//            {
//                sv = hails[i].vz;
//                ax = 'z';
//            }
//            if (sx != 0 && sv != 0)
//            {
//                i1 = i;
//                i2 = j;
//            }
//        }
//    }
//}
//struct Hail
//{
//    public double px, py, pz, vx, vy, vz;
//}
