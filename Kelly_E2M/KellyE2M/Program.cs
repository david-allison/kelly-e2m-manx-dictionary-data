// See https://aka.ms/new-console-template for more information

using KellyE2M.Domain;
using Newtonsoft.Json;

var lines = File.ReadAllLines("Resources/Kelly_E2M.txt")
    .Select(x => x.Trim())
    .Where(x => x.Length > 0)
    .SelectMany(Create)
    .ToList();


static IEnumerable<KellyEnglishToManxEntry> Create(string input)
{
    var headwordToDefinitions = input.Split("\t");
    if (headwordToDefinitions.Length != 2) throw new ArgumentException(input);

    foreach (var definition in headwordToDefinitions[1].Split("\\n").ToList())
    {
        yield return new KellyEnglishToManxEntry
        {
            Words = [headwordToDefinitions[0]], 
            Definition = definition,
        };
    }
}

File.WriteAllText("kelly-e2m-en-v1.json", JsonConvert.SerializeObject(lines, Formatting.Indented));