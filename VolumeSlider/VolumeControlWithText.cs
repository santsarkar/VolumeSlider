using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                Margin = new System.Windows.Thickness(10),
                Height = 20,
                Width=40,
                Background = Brushes.Teal,
                             
            };

            var stackPanel = this.Content as StackPanel;
            stackPanel.Children.Add(volumeText);
        }

        private void VolumeSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            volumeText.Text = $"{volumeSlider.Value} db";
           
        }
    }
}
