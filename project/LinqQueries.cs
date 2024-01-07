public class LinqQueries
{
    private List<Book> LibrosCollection = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.LibrosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true})!;
        }
    }
    public IEnumerable<Book> TodaLaColeccion()
    {
        return LibrosCollection;
    }
}