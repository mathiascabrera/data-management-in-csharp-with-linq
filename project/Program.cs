LinqQueries queries = new LinqQueries();

var diccionarioLookup = queries.DiccinariosDeLibrosPorLetra();
ImprimirDiccionario(diccionarioLookup, 'S');


void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
   Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
   foreach(var item in ListadeLibros[letra])
   {
         Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
   }
}

