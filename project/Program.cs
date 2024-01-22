LinqQueries queries = new LinqQueries();

var libroMenorPag = queries.LibroConMenorNumeroDePaginas();

Console.WriteLine($"Reto MinBy.\n{libroMenorPag.Title} - {libroMenorPag.PageCount}\n\n");

var libroFechaMasReciente = queries.LibroConFechaPublicacionMasReciente();

Console.WriteLine($"Reto MaxBy.\n{libroFechaMasReciente.Title} - {libroFechaMasReciente.PublishedDate.ToShortDateString()}\n\n");

