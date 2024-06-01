using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuestoDeControl
{
    internal class Program
    {
        static double recaudacion = 0;
        static int CantidadDeIngresos = 0;

        static void GenerarTicket()
        {
            int vehi, cantidad, numdias = 0;
            double valor = 0, valxcant = 0, acumpie = 0, acummoto = 0, acumauto = 0, acumcam = 0, acumbugy = 0, acumnauti = 0, valordias = 0;
            bool bandera = true;
            do
            {
                Console.WriteLine("Ingrese el tipo de vehículo");
                Console.WriteLine("1: No tengo vehículo");
                Console.WriteLine("2: Moto");
                Console.WriteLine("3: Auto");
                Console.WriteLine("4: Camioneta");
                Console.WriteLine("5: Bugy");
                Console.WriteLine("6: Vehículo Náutico");
                Console.WriteLine("Otro para terminar mis ingresos");
                vehi = Convert.ToInt32(Console.ReadLine());
                if (vehi <= 6 && vehi != 0)
                {
                    Console.WriteLine("Ingrese la cantidad de vehículos del tipo");
                    cantidad = Convert.ToInt32(Console.ReadLine());
                    switch (vehi)
                    {
                        case 1:
                            {
                                valor = 100;
                                valxcant = valor * cantidad;
                                acumpie = acumpie + valxcant;
                            }
                            break;
                        case 2:
                            {
                                valor = 800;
                                valxcant = valor * cantidad;
                                acummoto = acummoto + valxcant;
                            }
                            break;
                        case 3:
                            {
                                valor = 1000;
                                valxcant = valor * cantidad;
                                acumauto = acumauto + valxcant;
                            }
                            break;
                        case 4:
                            {
                                valor = 1500;
                                valxcant = valor * cantidad;
                                acumcam = acumcam + valxcant;
                            }
                            break;
                        case 5:
                            {
                                valor = 5000;
                                valxcant = valor * cantidad;
                                acumbugy = acumbugy + valxcant;
                            }
                            break;
                        case 6:
                            {
                                valor = 1200;
                                valxcant = valor * cantidad;
                                acumnauti = acumnauti + valxcant;
                            }
                            break;
                    }
                    CantidadDeIngresos = CantidadDeIngresos + cantidad;
                }
                else
                {
                    bandera = false;
                }
            }
            while (bandera == true);

            Console.WriteLine("Ingrese el número de días: 1, 2, 3, 4, 5 (5 o más)");
            numdias = Convert.ToInt32(Console.ReadLine());
            switch (numdias)
            {
                case 1:
                    {
                        valordias = valxcant * 2;
                    }
                    break;
                case 2:
                    {
                        valordias = valxcant + (valxcant / 100) * 120;
                    }
                    break;
                case 3:
                    {
                        valordias = valxcant + (valxcant / 100) * 220;
                    }
                    break;
                case 4:
                    {
                        valordias = valxcant + (valxcant / 100) * 320;
                    }
                    break;
                case 5:
                    {
                        valordias = valxcant + (valxcant / 100) * 380;
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Sin agregados por estadía menor a un día");
                    }
                    break;
            }
            MostrarTicket(valxcant, valordias);
        }

        static double MostrarTicket(double valxcant, double valordias)
        {
            double costoiva = 0, costoaconcagua = 0, montofinal = 0;
            costoiva = (valordias/100) * 21;
            costoaconcagua = (valordias/100) * 15;
            montofinal = valordias + costoiva + costoaconcagua;
            Console.WriteLine("Valor por cantidad de dias: {0}", valordias);
            Console.WriteLine("Valor impuesto IVA: {0}", costoiva);
            Console.WriteLine("Valor por impuesto ecológico: {0}", costoaconcagua);
            Console.WriteLine("El monto total a pagar es de: {0}", montofinal);
            recaudacion = recaudacion + montofinal;
            return recaudacion;
        }

        static void RegistrarAcceso()
        {
            int ticket;
            Console.WriteLine("Ingrese 1 si tiene el ticket, sino ingrese otro número");
            ticket = Convert.ToInt32(Console.ReadLine());
            if (ticket == 1)
            {
                Console.WriteLine("El acceso fue validado");
            }
            else
            {
                GenerarTicket();
            }
        }
        static void ImprimirMenu()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("1: Registrar acceso");
            Console.WriteLine("2: Mostrar cantidad de ingresos");
            Console.WriteLine("3: Mostrar informe de caja");
            Console.WriteLine("Otro para salir");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Ingrese una de las opciones");
        }
        static void MostrarCantidadDeIngresos(int CantIng)
        {
            Console.WriteLine("La cantidad de ingresos es: {0}", CantIng);
        }
        static void MostrarInformeCaja(double acumcaja)
        {
            int num1;
            Console.WriteLine("El total recaudado por la caja es de: {0}", acumcaja);
            Console.WriteLine("Por favor, presione 1 si quiere seguir en la aplicación u otro número para finalizar");
            num1 = Convert.ToInt32(Console.ReadLine());
            if (num1 != 1)
            {
                Console.WriteLine("Fin de la aplicación");
            }
        }

        static void Main(string[] args)
        {
            int opcion;

            ImprimirMenu();
            opcion = Convert.ToInt32(Console.ReadLine());
            while (opcion >= 1 && opcion <= 3)
            {
                switch (opcion)
                {
                    case 1:
                        {
                            RegistrarAcceso();
                        }
                        break;
                    case 2:
                        {
                            MostrarCantidadDeIngresos(CantidadDeIngresos);
                        }
                        break;
                    case 3:
                        {
                            MostrarInformeCaja(recaudacion);
                        }
                        break;

                }
                ImprimirMenu();
                opcion = Convert.ToInt32(Console.ReadLine());
            }

        }
    }
}

