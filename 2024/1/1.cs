string[] l = File.ReadAllLines("1.txt");

int[] l0 = new int[l.Length];
int[] l1 = new int[l.Length];

for (int i = 0; i < l.Length; i++)
{
    string[] s = l[i].Split(' ');
    l0[i] = int.Parse(s[0]);
    l1[i] = int.Parse(s[3]);
}

Array.Sort(l0);
Array.Sort(l1);

int[] l2 = new int[l.Length];

for (int i = 0; i < l.Length; i++)
    l2[i] = Math.Abs(l0[i] - l1[i]);

Console.WriteLine(l2.Sum());

for (int i = 0; i < l.Length; i++)
    l0[i] *= l1.Count(x => x == l0[i]);

Console.WriteLine(l0.Sum());