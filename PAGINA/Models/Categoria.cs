using PAGINA.Models;
using System.Collections.Generic;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string Nombre { get; set; }

    // Relación con Productos
    public virtual ICollection<Productos> Productos { get; set; }
}
