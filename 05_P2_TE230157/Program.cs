Console.WriteLine("SERVOMOTOR");
Console.WriteLine();

// Crear un objeto de la clase Servomotor
Servomotor servo1 = new Servomotor();

// Capturar la información del objeto (se repite mientras haya valores fuera de 0 a 180)
do
{
    Console.Write("Ingrese la posición actual (0 a 180 °): ");
    servo1.PosicionActual = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese la posición objetivo (0 a 180 °): ");
    servo1.PosicionObjetivo = Convert.ToDouble(Console.ReadLine());

    if (!servo1.PosicionesValidas())
    {
        Console.WriteLine("Error: ambos valores deben estar entre 0 y 180 °. Intente de nuevo.");
        Console.WriteLine();
    }
}
while (!servo1.PosicionesValidas());

// Solicitar al objeto que calcule su desplazamiento
double desplazamiento = servo1.CalcularDesplazamiento();

// Mostrar resultados
Console.WriteLine();
Console.WriteLine($"Posición actual: {servo1.PosicionActual:F1} °");
Console.WriteLine($"Posición objetivo: {servo1.PosicionObjetivo:F1} °");
Console.WriteLine($"Desplazamiento absoluto: {desplazamiento:F1} °");
Console.WriteLine($"Movimiento: {servo1.ObtenerDireccion()}");


// Definición de la clase
class Servomotor
{
    // Propiedades
    public double PosicionActual { get; set; }     // °

    public double PosicionObjetivo { get; set; }   // °


    // Método para validar que ambas posiciones estén entre 0 y 180
    public bool PosicionesValidas()
    {
        bool actualValida = PosicionActual >= 0 && PosicionActual <= 180;
        bool objetivoValida = PosicionObjetivo >= 0 && PosicionObjetivo <= 180;

        return actualValida && objetivoValida;
    }


    // Método para calcular el desplazamiento absoluto
    public double CalcularDesplazamiento()
    {
        double desplazamiento;

        desplazamiento = Math.Abs(PosicionObjetivo - PosicionActual);

        return desplazamiento;
    }


    // Método para determinar la dirección del movimiento
    public string ObtenerDireccion()
    {
        if (PosicionObjetivo > PosicionActual)
        {
            return "hacia una posición MAYOR";
        }
        else if (PosicionObjetivo < PosicionActual)
        {
            return "hacia una posición MENOR";
        }
        else
        {
            return "SIN movimiento";
        }
    }
}