﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamTwoCodeQuestions.Data;

namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        public CustomizeCobblerControl()
        {
            InitializeComponent();
        }

        private void CherryBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext is Cobbler cob)
            {
                cob.Fruit = FruitFilling.Cherry;
            }
        }

        private void BlueberryBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext is Cobbler cob)
            {
                cob.Fruit = FruitFilling.Blueberry;
            }
        }

        private void PeachBtn_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext is Cobbler cob)
            {
                cob.Fruit = FruitFilling.Peach;
            }
        }

    }
}
