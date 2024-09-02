using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TFDGraphicsManager
{
    public partial class MainWindow : Window
    {
        private readonly SettingsManager _settingsManager = new();
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxItems();
            _settingsManager.GetSettingsValues();
            SetCurrentSettings();
        }

        private void InitializeComboBoxItems()
        {
            // Initialize items for each ComboBox
            var qualityLevels = new List<string> { "Low", "Medium", "High", "Ultra", "Cinematic" };
            ViewDistance.ItemsSource = qualityLevels;
            AntiAliasing.ItemsSource = qualityLevels;
            PostProcessing.ItemsSource = qualityLevels;
            Shadows.ItemsSource = qualityLevels;
            GlobalIllumination.ItemsSource = qualityLevels;
            Reflections.ItemsSource = qualityLevels;
            Textures.ItemsSource = qualityLevels;
            Effects.ItemsSource = qualityLevels;
            Foliage.ItemsSource = qualityLevels;
            Shading.ItemsSource = qualityLevels;
            Mesh.ItemsSource = qualityLevels;
            Physics.ItemsSource = qualityLevels;

            var rayTracingLevels = new List<string> { "Disabled", "Medium", "High", "Ultra", "Cinematic" };
            RayTracingQuality.ItemsSource = rayTracingLevels;
        }

        private void SetCurrentSettings()
        {
            foreach (var item in ViewDistance.Items)
            {
                if (item.ToString() ==
                    GraphicsSetting.ViewDistanceMapping[_settingsManager.settingsValues["ViewDistance"]])
                {
                    ViewDistance.SelectedItem = item;
                }
            }
        }
    }
}
