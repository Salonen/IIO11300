/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2015
* Authors: Esa Salmikangas, Simo Samuli Salonen
*/using System;
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
using System.Xml;

namespace Tehtava1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {
                double result;
                result = BusinessLogicWindow.CalculateArea(double.Parse(txtWidht.Text), double.Parse(txtHeight.Text));
                txtAla.Text = result.ToString();

                double result2;
                result2 = BusinessLogicWindow.CalculatePerimeter(double.Parse(txtWidht.Text), double.Parse(txtHeight.Text));
                txtPiiri.Text = result2.ToString();

                double result3;
                result3 = BusinessLogicWindow.CalculateKarmi(double.Parse(txtWidht.Text), double.Parse(txtHeight.Text), double.Parse(txtKarmi.Text));
                txtKA.Text = result3.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {

    }
  }

  public class BusinessLogicWindow
    {
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
    public static double CalculateArea(double widht, double height)
        {
            //throw new System.NotImplementedException();
            return widht * height;
        }
    public static double CalculatePerimeter(double widht, double height)
        {
            //throw new System.NotImplementedException();
            return widht * 2 + height * 2;
        }
    public static double CalculateKarmi(double widht, double height, double karmi)
        {
            double ala, sisa, tulos;
            //double m;
            //throw new System.NotImplementedException();
            //m = (widht * height - ( (widht - (2 * karmi)) * (height - (2 * karmi) ) ) );
            //return m;
            ala = widht * height;
            sisa = (widht - karmi - karmi) * (height - karmi - karmi);
            tulos = ala - sisa;
            return tulos;
            //return 30;
        }
    }
}
