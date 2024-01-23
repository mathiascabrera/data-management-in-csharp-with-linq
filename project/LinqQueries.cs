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
    public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorFecha()
    {
        return LibrosCollection
        .Where(p=> p.Categories
        .Contains("Java"))
        .OrderByDescending(p=> p.PublishedDate)
        .Take(3);

        /* return LibrosCollection
        .Where(p=> p.Categories
        .Contains("Java"))
        .OrderBy(p=> p.PublishedDate)
        .TakeLast(3); */
    }
    public IEnumerable<Book> TerceryCuartoLibroDeMas400Pag(){
        return LibrosCollection
        .Where(p=> p.PageCount > 400)
        .Take(4)
        .Skip(2);
    }
    public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion()
    {
        return LibrosCollection.Take(3)
        .Select(p=> new Book() {Title = p.Title, PageCount = p.PageCount});
    }
    public int CantidadDeLibrosEntre200y500Pag()
    {
        /* return LibrosCollection.Where(p=>p.PageCount>=200 && p.PageCount<=500).Count(); */ /* bad practice */
        return LibrosCollection.Count(p=>p.PageCount>=200 && p.PageCount<=500);/* good practice */
    }
    public long CantidadDeLibrosEntre200y500PagLong()
    {
        /* return LibrosCollection.Where(p=>p.PageCount>=200 && p.PageCount<=500).LongCount(); */ /* bad practice */
        return LibrosCollection.LongCount(p=>p.PageCount>=200 && p.PageCount<=500);/* good practice */
    }
    public DateTime FechaDePublicacionMenor()
    {
        return LibrosCollection.Min(p=> p.PublishedDate);
    }
    public int NumeroDePagLibroMayor()
    {
        return LibrosCollection.Max(p=> p.PageCount);
    }
    public Book LibroConMenorNumeroDePaginas()
    {
        return LibrosCollection.Where(p=> p.PageCount > 0).MinBy(p=>p.PageCount);
    }
    public Book LibroConFechaPublicacionMasReciente()
    {
        return LibrosCollection.MaxBy(p=> p.PublishedDate);
    }
    public int SumaDeTodasLasPaginasLibrosEntre0y500()
    {
        return LibrosCollection.Where(p=> p.PageCount > 0 && p.PageCount <= 500).Sum(p=> p.PageCount);
    }
    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return LibrosCollection
        .Where(p=> p.PublishedDate.Year > 2015)
        .Aggregate("",(TitulosLibros, next) =>
        {
            if(TitulosLibros != string.Empty)
                TitulosLibros += " - " + next.Title;
            else
                TitulosLibros += next.Title;
            return TitulosLibros;
        });

    }
}