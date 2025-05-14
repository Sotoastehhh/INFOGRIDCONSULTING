using PAGINA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class ProductoService
{
    private List<Productos> productos;

    public ProductoService(List<Productos> productos)
    {
        this.productos = productos;
    }

    public string DescontarStock(string codigo)
    {
        var producto = productos.FirstOrDefault(p => p.codigo_barras == codigo);

        if (producto == null)
            return "Producto no encontrado.";

        if (producto.stock <= 0)
            return "Stock agotado.";

        producto.stock -= 1;
        return "Producto descontado correctamente.";
    }
}
