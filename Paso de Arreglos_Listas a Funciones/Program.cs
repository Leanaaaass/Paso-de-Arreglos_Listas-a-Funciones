// ejercicio # 1
using System;
using System.Collections.Generic;

public class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
}

public class Inventario
{
    private List<Producto> productos = new List<Producto>();

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public void EliminarProducto(int codigo)
    {
        productos.RemoveAll(p => p.Codigo == codigo);
    }

    public void ModificarProducto(Producto producto)
    {
        var prod = productos.Find(p => p.Codigo == producto.Codigo);
        if (prod != null)
        {
            prod.Nombre = producto.Nombre;
            prod.Cantidad = producto.Cantidad;
            prod.Precio = producto.Precio;
        }
    }

    public Producto ConsultarProducto(int codigo)
    {
        return productos.Find(p => p.Codigo == codigo);
    }

    public List<Producto> MostrarTodosLosProductos()
    {
        return productos;
    }
}

public class Program
{
    public static void Main()
    {
        Inventario inventario = new Inventario();
        int opcion;

        do
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Producto nuevoProducto = new Producto();
                    Console.Write("Ingrese el código del producto: ");
                    nuevoProducto.Codigo = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nombre del producto: ");
                    nuevoProducto.Nombre = Console.ReadLine();
                    Console.Write("Ingrese la cantidad del producto: ");
                    nuevoProducto.Cantidad = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el precio del producto: ");
                    nuevoProducto.Precio = decimal.Parse(Console.ReadLine());
                    inventario.AgregarProducto(nuevoProducto);
                    break;
                case 2:
                    Console.Write("Ingrese el código del producto a eliminar: ");
                    int codigoEliminar = int.Parse(Console.ReadLine());
                    inventario.EliminarProducto(codigoEliminar);
                    break;
                case 3:
                    Producto productoModificado = new Producto();
                    Console.Write("Ingrese el código del producto a modificar: ");
                    productoModificado.Codigo = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nuevo nombre del producto: ");
                    productoModificado.Nombre = Console.ReadLine();
                    Console.Write("Ingrese la nueva cantidad del producto: ");
                    productoModificado.Cantidad = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nuevo precio del producto: ");
                    productoModificado.Precio = decimal.Parse(Console.ReadLine());
                    inventario.ModificarProducto(productoModificado);
                    break;
                case 4:
                    Console.Write("Ingrese el código del producto a consultar: ");
                    int codigoConsultar = int.Parse(Console.ReadLine());
                    Producto productoConsultado = inventario.ConsultarProducto(codigoConsultar);
                    if (productoConsultado != null)
                    {
                        Console.WriteLine($"Código: {productoConsultado.Codigo}, Nombre: {productoConsultado.Nombre}, Cantidad: {productoConsultado.Cantidad}, Precio: {productoConsultado.Precio}");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                    break;
                case 5:
                    List<Producto> todosLosProductos = inventario.MostrarTodosLosProductos();
                    foreach (var producto in todosLosProductos)
                    {
                        Console.WriteLine($" Nombre: {producto.Nombre}, Código: {producto.Codigo}, Cantidad: {producto.Cantidad}, Precio: {producto.Precio}");
                    }
                    if (todosLosProductos.Count == 0)
                    {
                        Console.WriteLine("No hay productos registrados.");
                    }
                    break;
                
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }
}
