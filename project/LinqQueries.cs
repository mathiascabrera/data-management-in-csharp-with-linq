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
    public bool TodosLosLibrosTienenStatus()
    {
        return LibrosCollection.All(p=> p.Status!= string.Empty);
    }
    public bool LibroPublicadoEn2005()
    {
        return LibrosCollection.Any(p=> p.PublishedDate.Year == 2005);
    }
    public IEnumerable<Book> LibrosdePython()
    {
        //El "Contains" retorna un booleano, si es verdadero, además de retornar un true va a retornar el elmento en cuestión mediante el "where".
        return LibrosCollection.Where(p=> p.Categories.Contains("Python"));
    }
    public IEnumerable<Book> LibrosdeJavaPorNombreAscendente()
    {
        return LibrosCollection.Where(p=> p.Categories.Contains("Java")).OrderBy(p=> p.Title);
    }
    public IEnumerable<Book> LibrosMayorA450pagOrdenadosDesc()
    {
        return LibrosCollection.Where(p=> p.PageCount > 450).OrderByDescending(p=> p.PageCount);
    }
}