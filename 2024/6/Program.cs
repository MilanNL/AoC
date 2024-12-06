using System.Drawing;

string[] l = File.ReadAllLines("6.txt");

Point pos = Point.Empty;
for (int i = 0; i < l.Length; i++)
    if (l[i].Contains('^'))
        pos = new Point(l[i].IndexOf('^'), i);
Point startpos = pos;

int xdir = 0;
int ydir = -1;
HashSet<Point> poss = [pos];
while (pos.X + xdir >= 0 && pos.Y + ydir >= 0 && pos.X + xdir < l[0].Length && pos.Y + ydir < l.Length)
{
    if (l[pos.Y + ydir][pos.X + xdir] == '#')
    {
        int oldxdir = xdir;
        xdir = -ydir;
        ydir = oldxdir;
    }
    pos = new Point(pos.X + xdir, pos.Y + ydir);
    poss.Add(pos);
}

Console.WriteLine(poss.Count);

string[] lx = [.. l];
int sum = 0;
foreach(Point posx in poss)
{
    char[] lxc = lx[posx.Y].ToCharArray();
    lxc[posx.X] = '#';
    lx[posx.Y] = new string(lxc);

    pos = startpos;
    xdir = 0;
    ydir = -1;
    List<(Point, int, int)> posss = [(pos, xdir, ydir)];
    while (pos.X + xdir >= 0 && pos.Y + ydir >= 0 && pos.X + xdir < l[0].Length && pos.Y + ydir < l.Length)
    {
        if (lx[pos.Y + ydir][pos.X + xdir] == '#')
        {
            int oldxdir = xdir;
            xdir = -ydir;
            ydir = oldxdir;
            continue;
        }
        pos = new Point(pos.X + xdir, pos.Y + ydir);
        if (posss.Any(x => x.Item1.X == pos.X && x.Item1.Y == pos.Y && x.Item2 == xdir && x.Item3 == ydir))
        {
            sum++;
            break;
        }
        else
            posss.Add((pos, xdir, ydir));
    }

    lx[posx.Y] = l[posx.Y];
}

Console.WriteLine(sum);