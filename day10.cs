//using System.Collections;
//using System.Collections.Generic;

//string fPath = @"C:\Users\lizzm\Documents\inputs1.txt";

//StreamReader sr = new StreamReader(fPath);
//List<List<Node>> field = new List<List<Node>>();
//Coord start = new Coord();
//int x = 0;
//int y = 0;
//while (!sr.EndOfStream)
//{
//    string? s = sr.ReadLine();

//    if (s != null)
//    {
//        List<Node> list = new List<Node>();
//        //make nodes
//        foreach (char c in s.ToCharArray())
//        {
//            Node n = new Node();
//            if (c.ToString() == Pipe.se)
//            {
//                n.south = 1;
//                n.east = 1;
//                n.pipe = Pipe.se;
//            }
//            if (c.ToString() == Pipe.ne)
//            {
//                n.north = 1;
//                n.east = 1;
//                n.pipe = Pipe.ne;
//            }
//            if (c.ToString() == Pipe.nw)
//            {
//                n.north = 1;
//                n.west = 1;
//                n.pipe = Pipe.nw;
//            }
//            if (c.ToString() == Pipe.sw)
//            {
//                n.south = 1;
//                n.west = 1;
//                n.pipe = Pipe.sw;
//            }
//            if (c.ToString() == Pipe.ver)
//            {
//                n.south = 1;
//                n.north = 1;
//                n.pipe = Pipe.ver;
//            }
//            if (c.ToString() == Pipe.hor)
//            {
//                n.east = 1;
//                n.west = 1;
//                n.pipe = Pipe.hor;
//            }
//            if (c.ToString() == Pipe.gro)
//            {
//                n.south = 0;
//                n.north = 0;
//                n.east = 0;
//                n.west = 0;
//                n.pipe = Pipe.gro;
//            }
//            if (c.ToString() == Pipe.sta)
//            {
//                start.x = x; start.y = y;
//                n.pipe = Pipe.sta;
//            }
//            n.coord = new Coord
//            {
//                x = x,
//                y = y
//            };
//            list.Add(n);
//            x++;
//        }
//        field.Add(list);
//    }
//    x = 0;
//    y++;
//}

//Coord path1 = new Coord();
//Coord path2 = new Coord();

//bool path1set = false;

//Node node = getStart(start);
//field[start.y][start.x] = node;
//Coord path1prev = start;
//Coord path2prev = start;
//Coord path1next = start;
//Coord path2next = start;

//if (node.south > 0)
//{
//    if (!path1set)
//    {
//        path1 = new Coord
//        {
//            x = start.x,
//            y = start.y + 1
//        };
//        path1set = true;
//    }

//}
//if (node.north > 0)
//{
//    if (!path1set)
//    {
//        path1 = new Coord
//        {
//            x = start.x,
//            y = start.y - 1
//        };
//        path1set = true;
//    }
//    else
//    {
//        path2 = new Coord
//        {
//            x = start.x,
//            y = start.y - 1
//        };
//    }

//}
//if (node.east > 0)
//{
//    if (!path1set)
//    {
//        path1 = new Coord
//        {
//            x = start.x + 1,
//            y = start.y
//        };
//        path1set = true;
//    }
//    else
//    {
//        path2 = new Coord
//        {
//            x = start.x + 1,
//            y = start.y
//        };
//    }
//}
//if (node.west > 0)
//{
//    if (!path1set)
//    {
//        path1 = new Coord
//        {
//            x = start.x - 1,
//            y = start.y
//        };
//        path1set = true;
//    }
//    else
//    {
//        path2 = new Coord
//        {
//            x = start.x - 1,
//            y = start.y
//        };
//    }
//}
//int res = 1;
////while (!(path1.x == path2.x && path1.y == path2.y))
////{
////    Coord t1 = new Coord
////    {
////        x = path1.x,
////        y = path1.y
////    };
////    Coord t2 = new Coord
////    {
////        x = path2.x,
////        y = path2.y
////    };
////    path1 = Follow(path1, path1prev);
////    path2 = Follow(path2, path2prev);
////    path1prev.x = t1.x; path1prev.y = t1.y;
////    path2prev.x = t2.x; path2prev.y = t2.y;
////    res++;
////}
//List<Node> path = new List<Node>();
//while (!(path1.x == start.x && path1.y == start.y))
//{
//    path.Add(field[path1prev.y][path1prev.x]);
//    path1next = Follow(path1, path1prev);
//    path1prev = path1;
//    path1 = path1next;
//    //Console.WriteLine(path1.x +   ":::"+ path1.y);
//    res++;
//}


//Console.WriteLine(res / 2);

////game 2
//// | 1/2 [ (x1y2 + x2y3 + … + xn-1yn + xny1) –(x2y1 + x3y2 + … +xnyn - 1 + x1yn) ] |
//int a = 0;
//int b = 0;

//for (int i = 0; i < path.Count; i++)
//{
//    if (i < path.Count - 1)

//    {
//        a += path[i].coord.x * path[i + 1].coord.y;
//    }
//    else
//    {
//        a += path[i].coord.x * path[0].coord.y;
//    }
//}
//for (int i = 0; i < path.Count; i++)
//{
//    if (i < path.Count - 1)

//    {
//        b += path[i].coord.y * path[i + 1].coord.x;
//    }
//    else
//    {
//        b += path[i].coord.y * path[0].coord.x;
//    }
//}

//int area = Math.Abs((a - b) / 2) - res / 2 + 2;
//Console.WriteLine(area);
//Node getStart(Coord s)
//{
//    Node st = new Node();
//    //north node
//    if (s.y - 1 >= 0 && field[s.y - 1][s.x].south > 0)
//    {
//        st.north = 1;
//    }
//    //south

//    if (s.y + 1 < field.Count && field[s.y + 1][s.x].north > 0)
//    {
//        st.south = 1;
//    }
//    //east
//    if (s.x + 1 < field[s.y].Count && field[s.y][s.x + 1].west > 0)
//    {
//        st.east = 1;
//    }
//    //wesst
//    if (s.x - 1 >= 0 && field[s.y][s.x - 1].east > 0)
//    {
//        st.west = 1;
//    }
//    st.coord = s;
//    return st;
//}
//Coord Follow(Coord nextnode, Coord prevnode)
//{
//    Node n = field[nextnode.y][nextnode.x];
//    Coord newCoord = new Coord();
//    //prev south
//    if (nextnode.x == prevnode.x && nextnode.y < prevnode.y)
//    {
//        if (n.north > 0)
//        {
//            newCoord.x = nextnode.x;
//            newCoord.y = nextnode.y - 1;
//        }
//        if (n.east > 0)
//        {
//            newCoord.x = nextnode.x + 1;
//            newCoord.y = nextnode.y;
//        }
//        if (n.west > 0)
//        {
//            newCoord.x = nextnode.x - 1;
//            newCoord.y = nextnode.y;
//        }
//    }
//    //prev north
//    else if (nextnode.x == prevnode.x && nextnode.y > prevnode.y)
//    {
//        if (n.south > 0)
//        {
//            newCoord.x = nextnode.x;
//            newCoord.y = nextnode.y + 1;
//        }
//        if (n.east > 0)
//        {
//            newCoord.x = nextnode.x + 1;
//            newCoord.y = nextnode.y;
//        }
//        if (n.west > 0)
//        {
//            newCoord.x = nextnode.x - 1;
//            newCoord.y = nextnode.y;
//        }
//    }
//    //prev east
//    else if (nextnode.x < prevnode.x && nextnode.y == prevnode.y)
//    {
//        if (n.north > 0)
//        {
//            newCoord.x = nextnode.x;
//            newCoord.y = nextnode.y - 1;
//        }
//        if (n.south > 0)
//        {
//            newCoord.x = nextnode.x;
//            newCoord.y = nextnode.y + 1;
//        }
//        if (n.west > 0)
//        {
//            newCoord.x = nextnode.x - 1;
//            newCoord.y = nextnode.y;
//        }
//    }
//    //prev west
//    else if (nextnode.x > prevnode.x && nextnode.y == prevnode.y)
//    {
//        if (n.north > 0)
//        {
//            newCoord.x = nextnode.x;
//            newCoord.y = nextnode.y - 1;
//        }
//        if (n.east > 0)
//        {
//            newCoord.x = nextnode.x + 1;
//            newCoord.y = nextnode.y;
//        }
//        if (n.south > 0)
//        {
//            newCoord.x = nextnode.x;
//            newCoord.y = nextnode.y + 1;
//        }
//    }
//    else
//    {
//        int o = 0;
//    }
//    return newCoord;
//}

//public struct Pipe
//{
//    public const string se = "F";
//    public const string ne = "L";
//    public const string sw = "7";
//    public const string nw = "J";
//    public const string ver = "|";
//    public const string hor = "-";
//    public const string gro = ".";
//    public const string sta = "S";
//}
//public class Node
//{
//    public int north = 0;
//    public int south = 0;
//    public int east = 0;
//    public int west = 0;
//    public Coord coord;
//    public List<Node> innerNodess = new List<Node>();
//    public string pipe = string.Empty;

//}
//public struct Coord
//{
//    public int x;
//    public int y;
//}
