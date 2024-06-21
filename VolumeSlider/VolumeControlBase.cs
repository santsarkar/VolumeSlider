using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace VolumeSlider
{
    public class VolumeControlBase:UserControl
    {
        protected Slider volumeSlider;
        protected StackPanel scalePanel ;
        protected Grid gridPanel;
        public VolumeControlBase()
        {
            InitializeComponents();

        }

        private void AddScale()
        {
            scalePanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5,0,0,0),
            };

            for (int i = 0; i <= 8; i++)
            {
                double value = -10 * i;
                var scaleTextBlock = new TextBlock
                {
                    Text = $"{value} db",
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 17, 0, 0),
                    Foreground = Brushes.White

                };
                scalePanel.Children.Add(scaleTextBlock);
            }
             gridPanel = new Grid();
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            gridPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Grid.SetColumn(volumeSlider, 0);
            Grid.SetColumn(scalePanel, 1);

            gridPanel.Children.Add(volumeSlider);
            gridPanel.Children.Add(scalePanel);
            this.Content = gridPanel;

        }

        private void InitializeComponents()
        {
            volumeSlider = new Slider
            {
                Orientation = Orientation.Vertical,
                Minimum = -80,
                Maximum = 0,
                Width=15,
                Height=300,
                IsSnapToTickEnabled=true,
                Background = Brushes.Teal,
                Value=-50,
            };

            AddScale();
        }

        public double Volume
        {
            get { return volumeSlider.Value; }
            set { volumeSlider.Value = value; }
        }
    }
}
