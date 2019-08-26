﻿using System;
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
                double amplitud = double.Parse(txtAmplitud.Text);
                double fase = double.Parse(txtFase.Text);
                double frecuencia = double.Parse(txtFrecuencia.Text);
                double tiempoInicial = double.Parse(txtTiempoInicial.Text);
                double tiempoFinal = double.Parse(txtTiempoFinal.Text);
                double frecuenciaDeMuestreo = double.Parse(txtFrecuenciaDeMuestreo.Text);

                SeñalSenoidal señal = new SeñalSenoidal(amplitud, fase, frecuencia);

                double periodoMuestreo = 1 / frecuenciaDeMuestreo;

                plnGrafica.Points.Clear();
                
                for(double i = tiempoInicial; i <= tiempoFinal; i += periodoMuestreo)
            
                {
                    Muestra muestra = new Muestra(i, señal.evaluar(i));
                    señal.Muestras.Add(muestra);
                }
            
                foreach(Muestra muestra in señal.Muestras)
                {
                    plnGrafica.Points.Add(adaptarCoordenadas(muestra.X, muestra.Y, tiempoInicial));
                }

                plnEjeX.Points.Clear();
                plnEjeX.Points.Add(adaptarCoordenadas(tiempoInicial,0.0, tiempoInicial));
                plnEjeX.Points.Add(adaptarCoordenadas(tiempoFinal,0.0, tiempoInicial));
                
            }
            public Point adaptarCoordenadas(double x, double y, double tiempoInicial)
            {



            return new Point((x -tiempoInicial) * srcGrafica.Width, (-1 * (y * ((srcGrafica.Height / 2.0)-35)) ) + (srcGrafica.Height / 2.0) );
            }
        }
    }
