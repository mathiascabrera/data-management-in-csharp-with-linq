LinqQueries queries = new LinqQueries();

Console.WriteLine($"¿Todos los libros tienen Status?: {queries.TodosLosLibrosTienenStatus()}");

Console.WriteLine($"¿Existe algun libro publicado en el 2005?: {queries.LibroPublicadoEn2005()}");

