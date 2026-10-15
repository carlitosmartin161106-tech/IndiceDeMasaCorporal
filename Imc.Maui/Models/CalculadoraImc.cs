namespace Imc.Maui.Models
{
    public static class CalculadoraImc
    {
        public static decimal CalcularImc(decimal peso, decimal altura)
        {
            if (altura <= 0) return 0;
            return peso / (altura * altura);
        }

        public static string ObtenerEstadoNutricional(decimal imc)
        {
            if (imc < 18.5m)
                return "Bajo peso";

            if (imc < 25.0m)
                return "Peso normal";

            if (imc < 30.0m)
                return "Sobrepeso";

            if (imc < 40.0m)
                return "Obesidad";

            return "Obesidad extrema";
        }
    }
}