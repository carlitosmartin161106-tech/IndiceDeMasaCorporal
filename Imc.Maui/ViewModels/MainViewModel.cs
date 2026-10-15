using Imc.Maui.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Imc.Maui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _peso;
        private string _altura;
        private string _imc;
        private string _estadoNutricional;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Peso
        {
            get => _peso;
            set
            {
                if (_peso != value)
                {
                    _peso = value;
                    OnPropertyChanged(nameof(Peso));
                }
            }
        }

        public string Altura
        {
            get => _altura;
            set
            {
                if (_altura != value)
                {
                    _altura = value;
                    OnPropertyChanged(nameof(Altura));
                }
            }
        }

        public string Imc
        {
            get => _imc;
            set
            {
                if (_imc != value)
                {
                    _imc = value;
                    OnPropertyChanged(nameof(Imc));
                }
            }
        }

        public string EstadoNutricional
        {
            get => _estadoNutricional;
            set
            {
                if (_estadoNutricional != value)
                {
                    _estadoNutricional = value;
                    OnPropertyChanged(nameof(EstadoNutricional));
                }
            }
        }

        public ICommand CalcularCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }

        public MainViewModel()
        {
            Limpiar();
            CalcularCommand = new Command(Calcular);
            LimpiarCommand = new Command(Limpiar);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Calcular()
        {
            try
            {
                decimal peso;
                decimal altura;
                bool pesoEsValido = decimal.TryParse(Peso, out peso);
                bool alturaEsValida = decimal.TryParse(Altura, out altura);

                if (pesoEsValido && alturaEsValida)
                {
                    decimal imc = CalculadoraImc.CalcularImc(peso, altura);
                    Imc = imc.ToString("F4");
                    EstadoNutricional = CalculadoraImc.ObtenerEstadoNutricional(imc);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Limpiar()
        {
            Peso = string.Empty;
            Altura = string.Empty;
            Imc = string.Empty;
            EstadoNutricional = string.Empty;
        }
    }
}