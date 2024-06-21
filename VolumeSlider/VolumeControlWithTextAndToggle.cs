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
    public class VolumeControlWithTextAndToggle:VolumeControlWithText
    {
        private Button toggleButton;
        private bool isEnabled;
        private string labelContent;
        private Label textLabel;

        public VolumeControlWithTextAndToggle()
        {
            AddToggleButton();
            isEnabled = true;
            
        }

        private void AddToggleButton()
        {
            toggleButton = new Button
            {
                Background = Brushes.Teal,
                Height = 20,
                Width = 40,
                Content = "E/D",
                Foreground = Brushes.White,
            };
            textLabel = new Label
            {
                Content = "VOLUME",
                Margin = new System.Windows.Thickness(20,10,0,0),
                Foreground= Brushes.White,
            };
            toggleButton.Click += ToggleButton_Click;

            var parentGrid = this.Content as Grid;
            parentGrid.Children.Remove(volumeText);
            parentGrid.Children.Remove(volumeSlider);
            parentGrid.Children.Remove(scalePanel);

            var newgrid = new Grid();
            newgrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            newgrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            newgrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            newgrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            newgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            newgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            newgrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Grid.SetRow(textLabel, 0);
            Grid.SetColumnSpan(textLabel, 4);
            newgrid.Children.Add(textLabel);

            Grid.SetRow(toggleButton, 1);
            Grid.SetColumnSpan(toggleButton, 1);
            newgrid.Children.Add(toggleButton);

            Grid.SetRow(volumeSlider, 2);
            Grid.SetColumn(volumeSlider, 1);
            newgrid.Children.Add(volumeSlider);

            Grid.SetRow(scalePanel, 2);
            Grid.SetColumn(scalePanel, 2);
            newgrid.Children.Add(scalePanel);

            Grid.SetRow(volumeText, 3);
            Grid.SetColumnSpan(volumeText, 4);
            newgrid.Children.Add(volumeText);

            this.Content = newgrid;

        }

        private void ToggleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            isEnabled = !isEnabled;

            volumeSlider.IsEnabled = isEnabled;
            volumeText.IsEnabled = isEnabled;
            toggleButton.Background = isEnabled ? Brushes.Teal : Brushes.Red;
        }
    }
}
