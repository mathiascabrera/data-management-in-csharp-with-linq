LinqQueries queries = new LinqQueries();

Console.WriteLine("Reto 1 OrderBy: ");
ImprimirValores(queries.LibrosdeJavaPorNombreAscendente());

Console.WriteLine("\nReto 2 OrderByDescending: ");
ImprimirValores(queries.LibrosMayorA450pagOrdenadosDesc());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n","Titulo","N. Paginas","Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
