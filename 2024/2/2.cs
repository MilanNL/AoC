bool IsSafe(List<int> split)
{
    if (!split.SequenceEqual(split.Order()) && !split.SequenceEqual(split.OrderDescending()))
        return false;

    if (Enumerable.Range(1, split.Count - 1).Any(i => Math.Abs(split[i - 1] - split[i]) == 0 || Math.Abs(split[i - 1] - split[i]) > 3))
        return false;

    return true;
}

string[] l = File.ReadAllLines("2.txt");

int safe = 0;
foreach (string line in l)
{
    List<int> split = line.Split(' ').Select(int.Parse).ToList();

    if (IsSafe(split))
        safe++;
}

Console.WriteLine(safe);

safe = 0;
foreach (string line in l)
{
    List<int> split = line.Split(' ').Select(int.Parse).ToList();

    if (IsSafe(split))
        safe++;
    else
    {
        for (int i = 0; i < split.Count; i++)
        {
            List<int> temp = [.. split];
            temp.RemoveAt(i);
            if (IsSafe(temp))
            {
                safe++;
                break;
            }
        }
    }
}

Console.WriteLine(safe);