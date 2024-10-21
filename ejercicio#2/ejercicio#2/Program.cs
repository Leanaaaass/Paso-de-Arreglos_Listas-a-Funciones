// ejercicio#2 
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        decimal saldo = 0;
        List<string> historialTransacciones = new List<string>();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al cajero automático");
            Console.WriteLine("Por favor, seleccione una opción:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
          
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConsultarSaldo(saldo);
                    break;
                case "2":
                    saldo = DepositarDinero(saldo, historialTransacciones);
                    break;
                case "3":
                    saldo = RetirarDinero(saldo, historialTransacciones);
                    break;
                case "4":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void ConsultarSaldo(decimal saldo)
    {
        Console.WriteLine($"Su saldo actual es: {saldo}");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static decimal DepositarDinero(decimal saldo, List<string> historialTransacciones)
    {
        Console.Write("Ingrese la cantidad a depositar: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal cantidad))
        {
            saldo += cantidad;
            historialTransacciones.Add($"Depósito: {cantidad}");
            Console.WriteLine($"Depósito exitoso. Su nuevo saldo es: {saldo}");
        }
        else
        {
            Console.WriteLine("Cantidad no válida. Intente de nuevo.");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        return saldo;
    }

    static decimal RetirarDinero(decimal saldo, List<string> historialTransacciones)
    {
        Console.Write("Ingrese la cantidad a retirar: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal cantidad))
        {
            if (cantidad <= saldo)
            {
                saldo -= cantidad;
                historialTransacciones.Add($"Retiro: {cantidad}");
                Console.WriteLine($"Retiro exitoso. Su nuevo saldo es: {saldo}");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente. Intente de nuevo.");
            }
        }
        else
        {
            Console.WriteLine("Cantidad no válida. Intente de nuevo.");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        return saldo;
    }
}
