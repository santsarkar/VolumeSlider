using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VolumeSlider
{
    public class VolumeControlWithText:VolumeControlBase
    {
        protected TextBox volumeText;
        public VolumeControlWithText()
        {
            AddTextControl();
            volumeSlider.ValueChanged += VolumeSlider_ValueChanged;
        }
        private void AddTextControl()
        {
            volumeText = new TextBox
            {

                Text = $"{volumeSlider.Value} db",
                Margin = new System.Windows.Thickness(15,5,0,0),
                Height = 20,
                Width=40
                             
            };

            var grid = this.Content as Grid;
            grid.Children.Remove(volumeSlider);
            grid.Children.Remove(scalePanel);

            var parentGrid = new Grid();
            parentGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            parentGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            parentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            parentGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Grid.SetRow(volumeText, 1);
            Grid.SetColumnSpan(volumeText,2 );
            parentGrid.Children.Add(volumeText);

            Grid.SetRow(volumeSlider,0);
            Grid.SetColumn(volumeSlider, 1);
            parentGrid.Children.Add(volumeSlider);

            Grid.SetRow(scalePanel, 0);
            Grid.SetColumn(scalePanel, 1);
            parentGrid.Children.Add(scalePanel);

            this.Content = parentGrid;

        }

        private void VolumeSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            volumeText.Text = $"{volumeSlider.Value} db";
           
        }
    }
}
