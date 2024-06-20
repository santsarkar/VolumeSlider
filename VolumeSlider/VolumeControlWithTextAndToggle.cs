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
            };
            textLabel = new Label
            {
                Content = "Enable/Disable",
                Margin = new System.Windows.Thickness(10),
            };
            toggleButton.Click += ToggleButton_Click;

            var grid = new Grid();
            grid.RowDefinitions.Add( new RowDefinition { Height= GridLength.Auto});
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            Grid.SetRow(toggleButton, 0);
            Grid.SetRow(textLabel, 1);

            var stackPanel = this.Content as StackPanel;
            stackPanel.Children.Remove(volumeSlider);
            stackPanel.Children.Remove(volumeText);

            Grid.SetRow(volumeSlider, 2);
            Grid.SetRow(volumeText, 3);

            grid.Children.Add(toggleButton);
            grid.Children.Add(textLabel);
            grid.Children.Add(volumeSlider);
            grid.Children.Add(volumeText);

            this.Content = grid;

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
