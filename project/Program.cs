LinqQueries queries = new LinqQueries();

Console.WriteLine($"Reto Count.\nCantidad de libros que tienen entre 200 y 500 páginas: {queries.CantidadDeLibrosEntre200y500Pag()}\n\n");

Console.WriteLine($"Reto LongCount.\nCantidad de libros que tienen entre 200 y 500 páginas: {queries.CantidadDeLibrosEntre200y500PagLong()}");

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n","Titulo","N. Paginas","Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
