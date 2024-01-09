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
    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        //Extension Method
        //return LibrosCollection.Where(p=> p.PublishedDate.Year > 2000);

        /* Query Expresion */
        return from l in LibrosCollection where l.PublishedDate.Year > 2000 select l;
    }
    public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
    {
        //Extension Method
        //return LibrosCollection.Where(p=> p.PageCount > 250 && (p.Title ?? string.Empty).Contains("in Action"));

        /* Query Expresion */
        return from l in LibrosCollection where l.PageCount > 250 && (l.Title ?? String.Empty).Contains("in Action") select l;
    }
}