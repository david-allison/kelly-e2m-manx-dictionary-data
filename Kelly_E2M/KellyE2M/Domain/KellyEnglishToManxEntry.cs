namespace KellyE2M.Domain;

/**
 * Keep in sync with CorpusSearch: KellyEnglishToManxEntry
 */
public class KellyEnglishToManxEntry
{
    public List<string> Words { get; set; }
    public string Definition { get; set; }
    public List<KellyEnglishToManxEntry> Children { get; set; } = new();
}