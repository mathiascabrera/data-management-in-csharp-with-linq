LinqQueries queries = new LinqQueries();

Console.WriteLine($"Reto Min.\n{queries.FechaDePublicacionMenor()}\n\n");

Console.WriteLine($"Reto Max.\n{queries.NumeroDePagLibroMayor()} paginas.");
