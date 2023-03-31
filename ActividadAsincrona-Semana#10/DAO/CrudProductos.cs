using ActividadAsincrona_Semana_8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadAsincrona_Semana_8.DAO
{
    public class CrudProductos
    {
        public void AgregarProductos(Producto ParametroosProductos) 
        { 
            using(AlmacenContext db = new AlmacenContext())
            {
                Producto producto = new Producto();
                producto.Nombre = ParametroosProductos.Nombre;
                producto.Descripcion = ParametroosProductos.Descripcion;
                producto.Precio = ParametroosProductos.Precio;
                producto.Stock = ParametroosProductos.Stock;
                db.Add(producto);
                db.SaveChanges();
            }
        }

        public Producto ProductoIndividual(int id)
        {
            using (AlmacenContext db = new AlmacenContext())
            {

                var buscar = db.Productos.FirstOrDefault(x => x.Id == id);

                return buscar;
            }
        }
        public void ActualizarProducto (Producto ParametroosProducto, int Lector)
        {
            using(AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductoIndividual(ParametroosProducto.Id);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParametroosProducto.Nombre;
                    }

                    else if (Lector == 2)
                    {
                        buscar.Descripcion = ParametroosProducto.Descripcion;
                    }
                    else if (Lector == 3)
                    {
                        buscar.Precio = ParametroosProducto.Precio;
                    }
                    else if (Lector == 4) {
                        buscar.Stock = ParametroosProducto.Stock;
                    }
                    db.Update(buscar);
                    db.SaveChanges();

                }

            }
        }
        public string EliminarProducto(int id)
        {
            using(AlmacenContext db = new AlmacenContext())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "El producto no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "**EL PRODUCTO SE ELIMINO CORRECTAMENTE**";
                }
            }
        }
        public List<Producto> ListarProducto()
        {
            using (AlmacenContext db = new AlmacenContext()
            )
            {
                return db.Productos.ToList();
            }
        }
    }
}
