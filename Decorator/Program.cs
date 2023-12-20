using System;

// Interfaz que define el comportamiento básico
public interface IBebida
{
    string ObtenerDescripcion();
    double ObtenerCosto();
}

// Clase concreta que implementa la interfaz
public class Cafe : IBebida
{
    public string ObtenerDescripcion()
    {
        return "Café";
    }

    public double ObtenerCosto()
    {
        return 2.0;
    }
}

// Decorador abstracto que implementa la interfaz y contiene una referencia al componente
public abstract class Decorador : IBebida
{
    protected IBebida bebida;

    public Decorador(IBebida bebida)
    {
        this.bebida = bebida ?? throw new ArgumentNullException(nameof(bebida));
    }

    public virtual string ObtenerDescripcion()
    {
        return bebida.ObtenerDescripcion();
    }

    public virtual double ObtenerCosto()
    {
        return bebida.ObtenerCosto();
    }
}

// Decorador concreto que agrega leche a la bebida
public class Leche : Decorador
{
    public Leche(IBebida bebida) : base(bebida)
    {
    }

    public override string ObtenerDescripcion()
    {
        return $"{base.ObtenerDescripcion()}, Leche";
    }

    public override double ObtenerCosto()
    {
        return base.ObtenerCosto() + 0.5;
    }
}

// Decorador concreto que agrega chocolate a la bebida
public class Chocolate : Decorador
{
    public Chocolate(IBebida bebida) : base(bebida)
    {
    }

    public override string ObtenerDescripcion()
    {
        return $"{base.ObtenerDescripcion()}, Chocolate";
    }

    public override double ObtenerCosto()
    {
        return base.ObtenerCosto() + 1.0;
    }
}

// Decorador concreto que agrega caramelo a la bebida
public class Caramelo : Decorador
{
    public Caramelo(IBebida bebida) : base(bebida)
    {
    }

    public override string ObtenerDescripcion()
    {
        return $"{base.ObtenerDescripcion()}, Caramelo";
    }

    public override double ObtenerCosto()
    {
        return base.ObtenerCosto() + 0.75;
    }
}

// Clase principal que simula la aplicación de cafetería
class Program
{
    static void Main()
    {
        // Solicitar al usuario que elija una bebida base
        Console.WriteLine("Seleccione una bebida base:");
        Console.WriteLine("1. Café");
        Console.Write("Ingrese el número de su elección: ");

        // Leer la elección del usuario y crear la bebida base correspondiente
        IBebida? bebida = null;
        string eleccion = Console.ReadLine();
        if (!string.IsNullOrEmpty(eleccion) && eleccion.Equals("1"))
        {
            bebida = new Cafe();
        }
        else
        {
            Console.WriteLine("Opción no válida. Seleccionando Café por defecto.");
            bebida = new Cafe();
        }

        // Permitir al usuario agregar decoradores a la bebida
        while (true)
        {
            Console.WriteLine("\nSeleccione un ingrediente adicional:");
            Console.WriteLine("1. Leche");
            Console.WriteLine("2. Chocolate");
            Console.WriteLine("3. Caramelo");
            Console.WriteLine("4. Finalizar y Mostrar");
            Console.Write("Ingrese el número de su elección: ");

            // Leer la elección del usuario y agregar el decorador correspondiente
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    bebida = new Leche(bebida);
                    break;
                case "2":
                    bebida = new Chocolate(bebida);
                    break;
                case "3":
                    bebida = new Caramelo(bebida);
                    break;
                case "4":
                    // Mostrar la descripción y el costo final de la bebida personalizada
                    Console.WriteLine($"\nDescripción: {bebida.ObtenerDescripcion()}");
                    Console.WriteLine($"Costo: ${bebida.ObtenerCosto()}\n");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
