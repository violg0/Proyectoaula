using System;
using System.Collections.Generic;

namespace programa
{
    class Cliente
    {
        public int cedula;
        public int estrato;
        public int meta_ahorro;
        public int consumo_energia;
        public int consumo_agua;

        
        public Cliente(int cedula, int estrato, int meta_ahorro, int consumo_energia, int consumo_agua)
        {
            this.cedula = cedula;
            this.estrato = estrato;
            this.meta_ahorro = meta_ahorro;
            this.consumo_energia = consumo_energia;
            this.consumo_agua = consumo_agua;
        }
    }

    class Program
    {
        static int promedio_consumo_agua;

    
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>();
            promedio_consumo_agua = CalcularPromedioConsumoAgua(clientes);


            while (true)
            {
                Console.WriteLine("1. Agregar cliente");
                Console.WriteLine("2. Calcular valor a pagar");
                Console.WriteLine("3. Calcular promedio de consumo de energía");
                Console.WriteLine("4. Calcular descuentos");
                Console.WriteLine("5. Calcular consumo excesivo de agua");
                Console.WriteLine("6. Mostrar porcentajes de consumo excesivo de agua por estrato");
                Console.WriteLine("7. Mostrar clientes con consumo de agua mayor al promedio");
                Console.WriteLine("8. Salir");
                Console.WriteLine("9. Calcular promedio de consumo de agua");
                Console.WriteLine("Seleccione una opción:");


                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarCliente(clientes);
                        break;
                    case 2:
                        Cliente? cliente = null;
                        Console.WriteLine("Ingrese la cédula del cliente para calcular el valor a pagar:");
                        int cedulaCliente = Convert.ToInt32(Console.ReadLine());
                        foreach (Cliente clienteActual in clientes)
                        {
                            if (clienteActual.cedula == cedulaCliente)
                            {
                                cliente = clienteActual;
                                break; 
                            
                            }
                        }

                            if (cliente != null)
                            {
                                int valorAPagar = CalcularValorAPagar(cliente, clientes);
                                Console.WriteLine($"El valor a pagar para el cliente con cédula {cliente.cedula} es: {valorAPagar}");
                            }
                            else
                            {
                                Console.WriteLine("Cliente no encontrado.");
                            }
                            break;
                        

                    case 3:
                        CalcularPromedioConsumoEnergia(clientes);
                        double promedioConsumoEnergia = CalcularPromedioConsumoEnergia(clientes);
                        Console.WriteLine($"El promedio de consumo de energía es: {promedioConsumoEnergia}");
                        break;
                    case 4:
                        double descuentos = CalcularDescuentos(clientes);
                        Console.WriteLine($"El total de descuentos es: {descuentos}");
                        break;

                    case 5:
                        int consumoExcesivoAgua = CalcularConsumoExcesivoAgua(clientes);
                        Console.WriteLine($"El consumo excesivo de agua total es: {consumoExcesivoAgua}");
                        break;
                    case 6:
                        MostrarPorcentajesConsumoExcesivoAguaPorEstrato(clientes);
                        break;
                    case 7:
                        MostrarClientesConConsumoAguaMayorAlPromedio(clientes);
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;

                        case 8:
                            Console.WriteLine("Saliendo del programa...");
                            return;
                        case 9:
                            double promedioConsumoAgua= CalcularPromedioConsumoAgua(clientes);
                            Console.WriteLine($"El promedio de consumo de agua es: {promedioConsumoAgua}");
                            break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        

        static void AgregarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Ingrese la cédula del cliente:");
            int cedula = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el estrato del cliente:");
            int estrato = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la meta de ahorro de energía:");
            int meta_ahorro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el consumo actual de energía:");
            int consumo_energia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el consumo actual de agua:");
            int consumo_agua = Convert.ToInt32(Console.ReadLine());
        

            Cliente cliente = new Cliente(cedula, estrato, meta_ahorro, consumo_energia, consumo_agua);
            clientes.Add(cliente);
            Console.WriteLine("Cliente agregado correctamente");
        }

        

        static int CalcularValorAPagar(Cliente cliente, List<Cliente> clientes)
        {
            int valor_parcial= cliente.consumo_energia * 850;
            int valor_incentivo=(cliente.meta_ahorro - cliente.consumo_energia) * 850;
            int valor_total_energia= valor_parcial - valor_incentivo;

            int valor_agua= 0;
            int valor_exceso= 0;
            int  valor_total_agua= 0;
            int valor_pagar = 0;
           
        
            if (cliente.consumo_agua > promedio_consumo_agua)
            {
                valor_agua = 25 * 4600;
                valor_exceso= (cliente.consumo_agua - promedio_consumo_agua)*(2 * 4600);
                valor_total_agua= valor_agua + valor_exceso;
            }
            else
            {
                valor_agua = cliente.consumo_agua * 4600;
            }
            valor_pagar= valor_total_energia + valor_total_agua;
            return valor_pagar;
        }

        static double CalcularPromedioConsumoEnergia(List<Cliente> clientes)
        {
            int suma_consumo_energia = 0;
            foreach (Cliente cliente in clientes)
            {
                suma_consumo_energia += cliente.consumo_energia;
            }
            double promedio_consumo_energia = suma_consumo_energia / (double)clientes.Count;
            return promedio_consumo_energia;
        }

        static int CalcularPromedioConsumoAgua(List<Cliente> clientes)
        {
            int suma_consumo_agua = 0;
            foreach (Cliente cliente in clientes)
            {
                suma_consumo_agua += cliente.consumo_agua;
            }
            double promedio_consumo_agua_double = suma_consumo_agua / (double)clientes.Count;
    
            return promedio_consumo_agua = (int)promedio_consumo_agua_double;
        }

        static double CalcularDescuentos(List<Cliente> clientes)
        {
            double descuentos = 0;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.consumo_energia <= cliente.meta_ahorro)
                {
                    descuentos += 100;
                }
                else
                {
                    descuentos += (cliente.consumo_energia - cliente.meta_ahorro) * 0.5;
                }
            }
            return descuentos;
        }

        static int CalcularConsumoExcesivoAgua(List<Cliente> clientes)
        {
            int consumo_excesivo_agua = 0;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.consumo_agua > promedio_consumo_agua)
                {
                    consumo_excesivo_agua += cliente.consumo_agua - promedio_consumo_agua;
                }
            }
            return consumo_excesivo_agua;
        }

        static void MostrarPorcentajesConsumoExcesivoAguaPorEstrato(List<Cliente> clientes)
        {
            Dictionary<int, int> porcentajes = new Dictionary<int, int>();
            foreach (Cliente cliente in clientes)
            {
                if (!porcentajes.ContainsKey(cliente.estrato))
                {
                    porcentajes[cliente.estrato] = 0;
                }
                if (cliente.consumo_agua > promedio_consumo_agua)
                {
                    porcentajes[cliente.estrato] += 1;
                }
            }
            foreach (var kvp in porcentajes)
            {
                Console.WriteLine($"El porcentaje de consumo excesivo de agua en el estrato {kvp.Key} es: {kvp.Value / (double)clientes.Count * 100}%");
            }
        }

        static void MostrarClientesConConsumoAguaMayorAlPromedio(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.consumo_agua > promedio_consumo_agua)
                {
                    Console.WriteLine($"Cliente con cédula {cliente.cedula} tiene consumo de agua mayor al promedio.");
                }
            }
        }
    }
}