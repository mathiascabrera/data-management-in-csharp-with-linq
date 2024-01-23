LinqQueries queries = new LinqQueries();

Console.WriteLine($"Reto Sum.\nSuma total de paginas: {queries.SumaDeTodasLasPaginasLibrosEntre0y500()}.\n\n");

Console.WriteLine($"Reto Aggregate.\nTitulos: {queries.TitulosDeLibrosDespuesDel2015Concatenados()}");