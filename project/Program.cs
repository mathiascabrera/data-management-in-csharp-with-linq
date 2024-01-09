LinqQueries queries = new LinqQueries();

Console.WriteLine("Reto 1: \n");

ImprimirValores(queries.LibrosDespuesdel2000());

Console.WriteLine("\nReto 2: \n");
ImprimirValores(queries.LibrosConMasde250PagConPalabrasInAction());


void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n","Titulo","N. Paginas","Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
