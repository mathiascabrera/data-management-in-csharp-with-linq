using System.Text.Json;
public class LinqQueries
{
    private List<Book> LibrosCollection = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.LibrosCollection = JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true})!;
        }
    }
    public IEnumerable<Book> GetBooks() => this.LibrosCollection;

    public void ImprimirBooks()
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "Paginas", "Publicación");
        this.LibrosCollection.ForEach(x => Console.WriteLine("{0, -60} {1, 15} {2, 15}\n",
            x.Title,
            x.PageCount,
            x.PublishedDate.ToString("yyyy-MM-dd")));
    }
}