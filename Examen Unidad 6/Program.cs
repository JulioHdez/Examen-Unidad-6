using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen_Unidad_6
{
    //Clase 
    public class IAmazon
    {
        //Campos de la clase
        public string nombre, descripcion;
        public float precio;
        public int stock;

        //Constructor de la clase
        public IAmazon(string nombre, string descripcion, float precio, int stock)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }

        //Metodo para mostrar datos o productos registrados
        public void Productos()
        {
            Console.WriteLine("Nombre del Producto es: {0}" , nombre);
            Console.WriteLine("Descripción del Producto es: {0}", descripcion);
            Console.WriteLine("Precio del Producto: {0:C}" , precio);
            Console.WriteLine("Cantidad en Stock: {0}" , stock);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "INVENTARIOS AMAZON";
            //Creacion del Archivo
            StreamWriter sw = new StreamWriter("Productos.txt" , true); //True para no sobreescribir dentro del archivo, utiliza false si deseea sobreescribir

            //Variables auxiliares
            int opc;

            do
            {
                Console.WriteLine("\t~ INVENTARIOS AMAZON ~");

                Console.WriteLine("1.- Registrar Productos");
                Console.WriteLine("2.- Salir del Programa");

                Console.Write("Seleccione alguna de las opciones (1 o 2): ");
                opc = Int16.Parse(Console.ReadLine());
                Console.Clear();


                switch (opc)
                {
                    case 1:
                        //Variables auxiliares
                        string nombre, descripcion;
                        float precio;
                        int stock;

                        try
                        {
                            //Captura de Variables
                            Console.Write("Ingrese el Nombre del Producto: ");
                            nombre = Console.ReadLine();

                            Console.Write("Ingrese la Descripción del Producto: ");
                            descripcion = Console.ReadLine();

                            Console.Write("Ingrese el Precio del Producto: ");
                            precio = float.Parse(Console.ReadLine());

                            Console.Write("Ingrese la Cantidad en Stock: ");
                            stock = int.Parse(Console.ReadLine());
                            Console.Clear();

                            //Creacion del objeto, asignando parametros
                            IAmazon Inv = new IAmazon(nombre, descripcion, precio, stock);

                            //Captura dentro del archivo
                            sw.WriteLine("\n\t~ Inventario Amazon ~");
                            sw.WriteLine("Producto: {0}" , Inv.nombre);
                            sw.WriteLine("Descripción del Producto: {0}", Inv.descripcion);
                            sw.WriteLine("Precio del Producto: {0:C}", Inv.precio);
                            sw.WriteLine("Quedan: {0} unidades en stock del producto {1}", Inv.stock, Inv.nombre);

                            char op;
                            Console.Write("¿Deseas ver los datos ingresados (S/N)?: ");
                            op = Char.Parse(Console.ReadLine());

                            if ((op == 's') || (op == 'S'))
                            {
                                //Invoque de metodos
                                Inv.Productos();
                                Console.WriteLine("Presiona ENTER para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                            Console.WriteLine("Ruta: " + e.StackTrace);
                        }

                        catch (FormatException e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                            Console.WriteLine("Ruta: " + e.StackTrace);
                        }
                        sw.Close();
                        break;

                    case 2:
                        Console.WriteLine("Presiona ENTER para salir del programa.");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opción inexistente, Presiona ENTER para continuar...");
                        break;
                }
            } while (opc != 2);
        }
    }
}
