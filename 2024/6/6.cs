string[] l = File.ReadAllLines("6.txt");

(int, int) pos = (0, 0);
HashSet<(int, int)> obstacles = [];
for (int i = 0; i < l.Length; i++)
{
    if (l[i].Contains('^'))
        pos = (l[i].IndexOf('^'), i);
    if (l[i].Contains('#'))
        foreach ((int, int) x in l[i].Select((x, y) => ((int, int))(x == '#' ? (y, i) : (-1,-1))).Where(x => x.Item1 >= 0))
            obstacles.Add(x);
}
(int, int) startpos = pos;

int xdir = 0;
int ydir = -1;
HashSet<(int, int)> poss = [pos];
while (pos.Item1 + xdir >= 0 && pos.Item2 + ydir >= 0 && pos.Item1 + xdir < l[0].Length && pos.Item2 + ydir < l.Length)
{
    if (obstacles.Contains((pos.Item1 + xdir, pos.Item2 + ydir)))
    {
        int oldxdir = xdir;
        xdir = -ydir;
        ydir = oldxdir;
    }
    pos = (pos.Item1 + xdir, pos.Item2 + ydir);
    poss.Add(pos);
}

Console.WriteLine(poss.Count);

int sum = 0;
foreach ((int, int) posx in poss)
{
    pos = startpos;
    xdir = 0;
    ydir = -1;
    Dictionary<(int, int), List<(int,int)>> posss = new([new KeyValuePair<(int, int), List<(int,int)>>(pos, [(xdir, ydir)])]);
    while (pos.Item1 + xdir >= 0 && pos.Item2 + ydir >= 0 && pos.Item1 + xdir < l[0].Length && pos.Item2 + ydir < l.Length)
    {
        (int, int) tuple = (pos.Item1 + xdir, pos.Item2 + ydir);
        if (tuple == posx || obstacles.Contains((pos.Item1 + xdir, pos.Item2 + ydir)))
        {
            int oldxdir = xdir;
            xdir = -ydir;
            ydir = oldxdir;
            continue;
        }
        pos = (pos.Item1 + xdir, pos.Item2 + ydir);
        if (posss.TryGetValue(pos, out List<(int, int)>? value1) && value1.Any(x => x.Item1 == xdir && x.Item2 == ydir))
        {
            sum++;
            break;
        }
        else
            if (posss.TryGetValue(pos, out List<(int, int)>? value2))
                value2.Add((xdir, ydir));
            else
                posss[pos] = [(xdir, ydir)];
    }
}

Console.WriteLine(sum);