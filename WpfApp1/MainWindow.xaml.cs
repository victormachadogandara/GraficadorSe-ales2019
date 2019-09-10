using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {
       
        
                public MainWindow()
                {
                    InitializeComponent();

                }

                private void BtnGraficar_Click(object sender, RoutedEventArgs e)
                {
                
                    double tiempoInicial = double.Parse(txtTiempoInicial.Text);
                    double tiempoFinal = double.Parse(txtTiempoFinal.Text);
                    double frecuenciaDeMuestreo = double.Parse(txtFrecuenciaDeMuestreo.Text);
                    

                    /*SeñalSenoidal señal = new SeñalSenoidal(amplitud, fase, frecuencia);*/

                    Señal señal;
                    switch(cbTipoSeñal.SelectedIndex)
                    {
                        case 0: //Parabolica
                            señal = new SeñalParabolica();
                            break;
                        case 1: //Senoida
                        double amplitud = double.Parse(((ConfiguracionSeñaSenoidal)(PanelConfiguracion.Children[0])).txtAmplitud.Text);
                        double fase = double.Parse(((ConfiguracionSeñaSenoidal)(PanelConfiguracion.Children[0])).txtFase.Text);
                        double frecuencia = double.Parse(((ConfiguracionSeñaSenoidal)(PanelConfiguracion.Children[0])).txtFrecuencia.Text);
                        señal = new SeñalSenoidal(amplitud,fase, frecuencia);
                            break;
                        case 2:
                        double alfa = double.Parse(((ConfiguracionExponencial)(PanelConfiguracion.Children[0])).txtAlfa.Text);
                        señal = new SeñalExponencial(alfa);
                            break;
                        default:
                        señal = null;
                            break;
                    }

                    señal.TiempoInicial = tiempoInicial;

                    señal.TiempoFinal = tiempoFinal;

                    señal.FrecuenciaMuestreo = frecuenciaDeMuestreo;

                    señal.construirSeñal();
    
                   

                    double amplitudMaxima = señal.AmplitudMaxima;

                    plnGrafica.Points.Clear();
                
            
                    foreach(Muestra muestra in señal.Muestras)
                    {
                        plnGrafica.Points.Add(adaptarCoordenadas(muestra.X, muestra.Y, tiempoInicial, amplitudMaxima));
                    }

                    lblLimiteSuperior.Text = amplitudMaxima.ToString();
                    lblLimiteInferior.Text = "-" + amplitudMaxima.ToString();

                    plnEjeX.Points.Clear();
                    plnEjeX.Points.Add(adaptarCoordenadas(tiempoInicial,0.0, tiempoInicial, amplitudMaxima));
                    plnEjeX.Points.Add(adaptarCoordenadas(tiempoFinal,0.0, tiempoInicial, amplitudMaxima));

                    plnEjeY.Points.Clear();
                    plnEjeY.Points.Add(adaptarCoordenadas(0.0, amplitudMaxima, tiempoInicial,amplitudMaxima));
                    plnEjeY.Points.Add(adaptarCoordenadas(0.0, -amplitudMaxima, tiempoInicial, amplitudMaxima));
                
                }
                public Point adaptarCoordenadas(double x, double y, double tiempoInicial, double amplitudMaxima)
                {



                  return new Point((x -tiempoInicial) * srcGrafica.Width, (-1 * (y * (( (srcGrafica.Height / 2.0) -35) / amplitudMaxima) )) + (srcGrafica.Height / 2.0) );
                }

            private void CbTipoSeñal_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                PanelConfiguracion.Children.Clear();
                switch(cbTipoSeñal.SelectedIndex)
                {
                    case 0: //Parabolica
                        break;
                    case 1: //Senoidal
                        PanelConfiguracion.Children.Add(new ConfiguracionSeñaSenoidal());
                        break;
                    case 2:
                        PanelConfiguracion.Children.Add(new ConfiguracionExponencial());
                        break;
                    default:
                        break;
                }

            }
        }
    }
