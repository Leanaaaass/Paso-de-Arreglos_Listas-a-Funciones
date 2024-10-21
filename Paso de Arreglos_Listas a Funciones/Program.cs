// ejercicio # 1
using System;
using System.Collections.Generic;

// Definición de la clase Producto
public class Producto
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
}

// Definición de la clase Inventario
public class Inventario
{
    private List<Producto> productos = new List<Producto>();

    // Método para agregar un producto al inventario
    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    // Método para eliminar un producto del inventario
    public void EliminarProducto(int codigo)
    {
        productos.RemoveAll(p => p.Codigo == codigo);
    }

    // Método para modificar un producto del inventario
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

    // Método para consultar un producto del inventario
    public Producto ConsultarProducto(int codigo)
    {
        return productos.Find(p => p.Codigo == codigo);
    }

    // Método para mostrar todos los productos del inventario
    public List<Producto> MostrarTodosLosProductos()
    {
        return productos;
    }
}

// Clase principal Program
public class Program
{
    public static void Main()
    {
        // Creación de una instancia de la clase inventario
        Inventario inventario = new Inventario();
        int opcion;

        // Ciclo principal del programa
        do
        {
            // Mostrar el menú de opciones
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            // Realizacion de acciones según la opción seleccionada
            switch (opcion)
            {
                case 1:
                    //caso1: Agregar un nuevo producto
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
                    // Caso2: Eliminar un producto
                    Console.Write("Ingrese el código del producto a eliminar: ");
                    int codigoEliminar = int.Parse(Console.ReadLine());
                    inventario.EliminarProducto(codigoEliminar);
                    break;
                case 3:
                    // Caso3: Modificar un producto
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
                    // Caso4: Consultar un producto
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
                    // Caso5:Se muestran todos los productos
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
                    // Caso6: salida del programa
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    // Opción no válida
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }
}
