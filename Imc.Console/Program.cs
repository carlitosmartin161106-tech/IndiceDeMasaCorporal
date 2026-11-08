
using Imc.Models;

Console.WriteLine("Aplicacion Que calcula el indice de masa corporal");
Console.WriteLine();

decimal peso = ReadDecimal("proporcione el peso de la persona en kilogramos: ");
decimal estatura = ReadDecimal("proporcione la estatura en metros de la persona: ");

decimal imc = CalculadoraImc.CalcularImc(peso, estatura);
var estadoNutricional = CalculadoraImc.ObtenerEstadoNutricional(imc);

Console.WriteLine($"El índice de masa corporal de la persona es: {imc:F4}");
Console.WriteLine($"Estado nutricional: {estadoNutricional}");

Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadKey();


static decimal ReadDecimal(string Indicacion)
{
    decimal valor;
    bool entradaEsValida;

    do
    {
        Console.WriteLine(Indicacion);
        string? entrada = Console.ReadLine();

        entradaEsValida = decimal.TryParse(entrada, out valor);

        if (!entradaEsValida)
        {
            Console.WriteLine("Error: La entrada debe ser un valor numérico válido.\n");
        }

    } while (!entradaEsValida);

    return valor;
}
