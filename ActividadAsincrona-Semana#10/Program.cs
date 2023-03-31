// See https://aka.ms/new-console-template for more information
using ActividadAsincrona_Semana_8.Models;
using ActividadAsincrona_Semana_8.DAO;

bool continuar = true;
while (continuar){ 


Console.WriteLine("           ******************************************************************       ");
Console.WriteLine("             BIENVENIDO HA HACER USO DE EL CRUD EN LA BASE DE DATOS <ALMACEN>        ");
Console.WriteLine("           ******************************************************************       ");

CrudProductos crudProductos = new CrudProductos();
Producto producto = new Producto();


Console.WriteLine();
Console.WriteLine("Menu");
Console.WriteLine("=> Pulse 1 para insertar productos en la base de datos <Almacen>");
Console.WriteLine("=> Pulse 2 para hacer una actualizaciòn de productos");
Console.WriteLine("=> Pulse 3 para hacer una elimicacion de productos");
Console.WriteLine("=> Pulse 4 para hacer un listado de productos");
Console.WriteLine("=> Pulse 5 para salir");
    Console.WriteLine();
var Menu = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

switch (Menu)
{

    case 1:
        int bucle = 1;
        while (bucle == 1)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("-INSERTAR PRODUCTOS-");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.Write("- Ingresa El nombre de el producto a ingresar ----> ");
            producto.Nombre = Console.ReadLine();
            Console.Write("- Ingresa la descripcion de el producto ingresado ----> ");
            producto.Descripcion = Console.ReadLine();
            Console.Write("- Ingresa el precio de el producto ingresado ----> ");
            producto.Precio = Convert.ToDecimal(Console.ReadLine());
            Console.Write("- Ingrese la cantidad de productos ---> ");
            producto.Stock = Convert.ToInt32(Console.ReadLine());
            crudProductos.AgregarProductos(producto);
            Console.WriteLine();
            Console.WriteLine("**EL PRODUCTO SE REGISTRO CORRECTAMENTE**");
            Console.WriteLine();
            Console.WriteLine("=> Pulsa 1 para continuar insertando productos");
            Console.WriteLine("=> Pulsa 0 para salir");
            Console.WriteLine();

            bucle = Convert.ToInt32(Console.ReadLine());
        }
        break;

        Console.WriteLine();
    case 2:
        int bucle2 = 2;
        while (bucle2 == 2) {

                Console.WriteLine("----------------------");
                Console.WriteLine("-ACTUALIZAR PRODUCTOS-");
                Console.WriteLine("----------------------");
                Console.WriteLine();
            Console.Write("- Ingrese el ID del producto a actualizar ----> ");
            var ProductoIndividual1 = crudProductos.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();
            if (ProductoIndividual1 == null)
            {
                Console.WriteLine("El producto no existe");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Nombre: {ProductoIndividual1.Nombre}, Descripcion: {ProductoIndividual1.Descripcion}, Precio:{ProductoIndividual1.Precio} Stock: {ProductoIndividual1.Stock}");
                Console.WriteLine();
                Console.WriteLine("=> Presiona 1 para actualizar nombre de el producto");
                Console.WriteLine("=> Presiona 2 para actualizar La descripcion de el producto");
                Console.WriteLine("=> Presiona 3 para actualizar el precio de el producto");
                Console.WriteLine("=> Presiona 4 para actualizar el Stock de productos");
                Console.WriteLine();

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.Write("- Ingrese el nombre nuevo ----> ");
                    ProductoIndividual1.Nombre = Console.ReadLine();
                }
                else if (Lector == 2)
                {
                    Console.Write("- Ingrese la descripcion nueva ----> ");
                    ProductoIndividual1.Descripcion = Console.ReadLine();
                }
                else if (Lector == 3)
                {
                    Console.WriteLine("- Ingrese el precio nuevo ----> ");
                    ProductoIndividual1.Precio = Convert.ToInt32(Console.ReadLine());
                }
                else if (Lector == 4)
                {
                    Console.Write("- Ingrese la cantidad de productos nuevo ----> ");
                    ProductoIndividual1.Stock = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine();
                crudProductos.ActualizarProducto(ProductoIndividual1, Lector);
                Console.WriteLine("**EL PRODUCTO SE ACTUALIZO CORRECTAMENTE**");

                Console.WriteLine();
                Console.WriteLine("=> Pulsa 2 para continuar actualizando productos");
                Console.WriteLine("=> Pulsa 0 para salir");
                bucle2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            } 
            
        }
        break;

    case 3:
        int bucle3 = 3;
        while (bucle3 == 3) {
                Console.WriteLine("--------------------");
                Console.WriteLine("-ELIMINAR PRODUCTOS-");
                Console.WriteLine("--------------------");
                Console.WriteLine();
            Console.Write("- Ingrese el ID del producto a Eliminar ----> ");
            var ProductoIndividual2 = crudProductos.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();
            if (ProductoIndividual2 == null)
            {
                Console.WriteLine("Este producto no existe");
                    Console.WriteLine();
                }
            else
            {
                Console.WriteLine("Eliminar producto");
                Console.WriteLine();
                Console.WriteLine($"Nombre: {ProductoIndividual2.Nombre}, Descripcion: {ProductoIndividual2.Descripcion}, Precio: {ProductoIndividual2.Precio}, Sock: {ProductoIndividual2.Stock}");
                Console.WriteLine("¿El producto encontrado es el correcto? Precione 1");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var id = Convert.ToInt32(ProductoIndividual2.Id);
                    Console.WriteLine(crudProductos.EliminarProducto(id));
                }
                else
                {
                    Console.WriteLine("Inicia nuevamente");
                }
                Console.WriteLine();
                Console.WriteLine("=> Pulsa 3 para continuar eliminando productos");
                Console.WriteLine("=> Pulsa 0 para salir");
                bucle3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            
        }
        break;

    case 4:
        int bucle4 = 4;
        while (bucle4 == 4)
        {
                Console.WriteLine("--------------------");
                Console.WriteLine("-LISTA DE PRODUCTOS-");
                Console.WriteLine("--------------------");
                Console.WriteLine();
            var ListarProducto = crudProductos.ListarProducto();
            foreach (var IteracionProducto in ListarProducto)
            {
                Console.WriteLine($"{IteracionProducto.Id}, {IteracionProducto.Nombre}, {IteracionProducto.Descripcion}, {IteracionProducto.Precio}, {IteracionProducto.Stock}");
                Console.WriteLine();
                Console.WriteLine("=> Pulsa 4 para hacer otro listado de productos");
                Console.WriteLine("=> Pulsa 0 para salir");
                bucle4 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
        }
        break;
        case 5:
            continuar = false;
            break;



}
}




#region Proyecto Asincrona-Semana#8

//AlmacenContext db = new AlmacenContext();
//Producto producto = new Producto();

//Console.WriteLine();

//Console.Write("- Ingrese un Nombre de producto ---> ");
//producto.Nombre = Console.ReadLine();
//Console.Write("- Ingrese la descripción del producto ---> ");
//producto.Descripcion = Console.ReadLine();
//Console.Write("- Ingrese el presio de el producto ---> ");
//producto.Precio = Convert.ToDecimal(Console.ReadLine());
//Console.Write("- Ingrese la cantidad de productos ---> ");
//producto.Stock = Convert.ToInt32(Console.ReadLine());

//db.Productos.Add(producto);
//db.SaveChanges();

//Console.WriteLine();

//Console.WriteLine("             -----------------------------------------                  ");
//Console.WriteLine("             PRODUCTOS REGISTRADOS EN LA BASE DE DATOS                  ");
//Console.WriteLine("             -----------------------------------------                  ");

//Console.WriteLine();

//var LisProducto = db.Productos.ToList();
//foreach (var usu in LisProducto)
//{
//    Console.WriteLine($"Id: {usu.Id}, NOMBRE: {usu.Nombre}, DESCRIPCION: {usu.Descripcion}, PRECIO: {usu.Precio}, STOCK: {usu.Stock}");
//}

//Console.WriteLine();

//Console.Write("*FIN DE REGISTROS*");

//Console.WriteLine();

#endregion

