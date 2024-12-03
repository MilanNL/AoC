using System.Text.RegularExpressions;
Console.WriteLine(File.ReadAllLines("3.txt")
                 .SelectMany(x => Regex.Matches(x, @"mul\([0-9]+,[0-9]+\)")
                 .Select(x => int.Parse(x.Value.Split('(')[1].Split(',')[0]) * int.Parse(x.Value.Split(',')[1].Split(')')[0])))
                 .Sum());
 
bool enabled = true;
Console.WriteLine(File.ReadAllLines("3.txt")
                 .SelectMany(x => Regex.Matches(x, @"mul\([0-9]+,[0-9]+\)|do\(\)|don't\(\)"))
                 .Select(x => x.Value.Contains('m') && enabled ? int.Parse(x.Value.Split('(')[1].Split(',')[0]) * int.Parse(x.Value.Split(',')[1].Split(')')[0]) 
                                                               : (enabled = x.Value.Contains("o(") || (x.Value.Contains('m') && enabled)) ? 0 : 0)
                 .Sum());