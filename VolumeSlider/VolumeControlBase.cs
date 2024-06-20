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
        public VolumeControlBase()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            volumeSlider = new Slider
            {
                Orientation = Orientation.Vertical,
                Minimum = -80,
                Maximum = 0,
                Width=30,
                Height=300,
                IsSnapToTickEnabled=true,
                Background = Brushes.Teal,
                Value=-50
            };
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(volumeSlider);  
            this.Content = stackPanel;
        }

        public double Volume
        {
            get { return volumeSlider.Value; }
            set { volumeSlider.Value = value; }
        }
    }
}
