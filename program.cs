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
        public void ActualizarCliente(int nuevaCedula, int nuevoEstrato, int nuevaMetaAhorro, int nuevoConsumoEnergia, int nuevoConsumoDeAgua)
        {
            this.cedula = nuevaCedula;
            this.estrato = nuevoEstrato;
            this.meta_ahorro = nuevaMetaAhorro;
            this.consumo_energia = nuevoConsumoEnergia;
            this.consumo_agua = nuevoConsumoDeAgua;
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
                Console.WriteLine("4. Calcular consumo excesivo de agua");
                Console.WriteLine("5. Mostrar porcentajes de consumo excesivo de agua por estrato");
                Console.WriteLine("6. Mostrar clientes con consumo de agua mayor al promedio");
                Console.WriteLine("7. Salir");
                Console.WriteLine("8. Calcular promedio de consumo de agua");
                Console.WriteLine("9. Actualizar cliente");
                Console.WriteLine("10. Eliminar cliente");
                Console.WriteLine("11. MostrarClienteConMayorDesfase");
                Console.WriteLine("12.  MostrarEstratoConMayorConsumoEnergia");
                Console.WriteLine("13. MostrarEstratoConMenorConsumoEnergia");
                Console.WriteLine("14. Mostrar estrato con mayor ahorro de agua");
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
                        int consumoExcesivoAgua = CalcularConsumoExcesivoAgua(clientes);
                        Console.WriteLine($"El consumo excesivo de agua total es: {consumoExcesivoAgua}");
                        break;
                    case 5:
                        MostrarPorcentajesConsumoExcesivoAguaPorEstrato(clientes);
                        break;
                    case 6:
                        MostrarClientesConConsumoAguaMayorAlPromedio(clientes);
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;

                    case 7:
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    case 8:
                        double promedioConsumoAgua = CalcularPromedioConsumoAgua(clientes);
                        Console.WriteLine($"El promedio de consumo de agua es: {promedioConsumoAgua}");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;

                    case 9:
                        ActualizarCliente(clientes);
                        break;
                    case 10:
                        EliminarCliente(clientes);
                        break;
                    case 11:
                        MostrarClienteConMayorDesfase(clientes);
                        break;
                    case 12:
                        MostrarEstratoConMayorConsumoEnergia(clientes);
                        break;
                    case 13:
                        MostrarEstratoConMenorConsumoEnergia(clientes);
                        break;
                    case 14:
                        int estratoMayorAhorroAgua= EstratoConMayorAhorroDeAgua(clientes);
                        Console.WriteLine($"El estrato con mayor ahorro de agua es: {estratoMayorAhorroAgua}");
                        break;

                }
            }
               
        }
        static void EliminarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Ingrese la cédula del cliente a eliminar:");
            int cedulaCliente = Convert.ToInt32(Console.ReadLine());
            Cliente clienteEliminar = clientes.Find(c => c.cedula == cedulaCliente);
            if (clienteEliminar != null)
            {
                clientes.Remove(clienteEliminar);
                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
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

        static void ActualizarCliente(List<Cliente> clientes)
        {
            Console.WriteLine("Ingrese la cédula del cliente a actualizar:");
            int cedulaCliente = Convert.ToInt32(Console.ReadLine());
            Cliente clienteActualizar = clientes.Find(c => c.cedula == cedulaCliente);
            if (clienteActualizar != null)
            {
                Console.WriteLine("Ingrese la nueva cédula del cliente:");
                int nuevaCedula = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo estrato del cliente:");
                int nuevoEstrato = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la nueva meta de ahorro de energía:");
                int nuevaMetaAhorro = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo consumo actual de energía:");
                int nuevoConsumoEnergia = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo consumo actual de agua:");
                int nuevoConsumoAgua = Convert.ToInt32(Console.ReadLine());
                clienteActualizar.ActualizarCliente(nuevaCedula, nuevoEstrato, nuevaMetaAhorro, nuevoConsumoEnergia, nuevoConsumoAgua);
                Console.WriteLine("Cliente actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
        static void MostrarClienteConMayorDesfase(List<Cliente> clientes)
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes para mostrar.");
                return;
            }

            Cliente clienteConMayorDesfase = clientes[0];
            int maxDesfase = clienteConMayorDesfase.meta_ahorro - clienteConMayorDesfase.consumo_energia;

            foreach (Cliente cliente in clientes)
            {
                int desfase = cliente.meta_ahorro - cliente.consumo_energia;
                if (desfase > maxDesfase)
                {
                    maxDesfase = desfase;
                    clienteConMayorDesfase = cliente;
                }
            }

            Console.WriteLine($"El cliente con cédula {clienteConMayorDesfase.cedula} tiene el mayor desfase en el consumo de energía con respecto a la meta de ahorro: {maxDesfase}.");
        }

        static void MostrarEstratoConMayorConsumoEnergia(List<Cliente> clientes)
        {
            int estratoMayorConsumo = 0;
            int consumoEnergiaMayor = 0;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.consumo_energia> consumoEnergiaMayor)
                { consumoEnergiaMayor = cliente.consumo_energia;
                    estratoMayorConsumo = cliente.estrato;
                }
            }
            Console.WriteLine($"El estrato con mayor consumo de energia es:{estratoMayorConsumo} con un consumo de: {consumoEnergiaMayor} ");

        }

        static void MostrarEstratoConMenorConsumoEnergia(List<Cliente> clientes)
        {
            int estratoMenorConsumo = 0;
            int consumoEnergiaMenor = int.MaxValue;
            foreach (Cliente cliente in clientes)
            {
                if (cliente.consumo_energia < consumoEnergiaMenor)
                {
                    consumoEnergiaMenor = cliente.consumo_energia;
                    estratoMenorConsumo = cliente.estrato;
                }
            }
            Console.WriteLine($"El estrato con mayor consumo de energia es:{estratoMenorConsumo} con un consumo de: {consumoEnergiaMenor} ");

        }


        static int CalcularValorAPagar(Cliente cliente, List<Cliente> clientes)
        {
            int valor_parcial = cliente.consumo_energia * 850;
            int valor_incentivo = (cliente.meta_ahorro - cliente.consumo_energia) * 850;
            int valor_total_energia = valor_parcial - valor_incentivo;

            int valor_agua = 0;
            int valor_exceso = 0;
            int valor_total_agua = 0;
            int valor_pagar = 0;


            if (cliente.consumo_agua > promedio_consumo_agua)
            {
                valor_agua = 25 * 4600;
                valor_exceso = (cliente.consumo_agua - promedio_consumo_agua) * (2 * 4600);
                valor_total_agua = valor_agua + valor_exceso;
            }
            else
            {
                valor_agua = cliente.consumo_agua * 4600;
            }
            valor_pagar = valor_total_energia + valor_total_agua;
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
            Console.WriteLine(promedio_consumo_agua); 

            return promedio_consumo_agua = (int)promedio_consumo_agua_double;
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

        static int EstratoConMayorAhorroDeAgua(List<Cliente> clientes)
        {
            Dictionary<int, int> gastoPorEstrato = new Dictionary<int, int>();

            foreach (Cliente cliente in clientes)
            {
                if (!gastoPorEstrato.ContainsKey(cliente.estrato))
                {
                    gastoPorEstrato[cliente.estrato] = 0;
                }
                
                gastoPorEstrato[cliente.estrato] += cliente.consumo_agua;
            }

            int estratoMenorGastoAgua = -1; 
            int minGastoAgua = int.MaxValue;

            foreach (var kvp in gastoPorEstrato)
            {
                if (kvp.Value < minGastoAgua)
                {
                    minGastoAgua = kvp.Value;
                    estratoMenorGastoAgua = kvp.Key;
                }
            }

            return estratoMenorGastoAgua;
        }
    }
}