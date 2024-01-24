LinqQueries queries = new LinqQueries();


Console.WriteLine($"Reto GroupBy.\nLibros publicados a partir del 2000 agrupados por ano:\n");
ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAno());


void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");//Imprime el anio
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}