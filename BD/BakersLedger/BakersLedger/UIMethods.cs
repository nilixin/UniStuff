using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BakersLedger
{
    static class UIMethods
    {
        private static StackPanel? _visibleStackPanel = null;
        private static Button? _visibleButton = null;

        public static void ToggleVisibility(StackPanel stackPanel, Button button)
        {
            if (_visibleStackPanel == null) // нет отображённой панели
            {
                stackPanel.Visibility = Visibility.Visible;
                button.Style = (Style)Application.Current.Resources["MenuButtonSticky"];
                _visibleStackPanel = stackPanel;
                _visibleButton = button;
            }
            else if (_visibleStackPanel == stackPanel) // выбрана та же отображаемая панель, панель прячется
            {
                stackPanel.Visibility = Visibility.Hidden;
                button.Style = (Style)Application.Current.Resources["MenuButton"];
                _visibleStackPanel = null;
                _visibleButton = null;
            }
            else // выбрана другая панель для отображения, не смотря на уже отображённую
            {
                _visibleStackPanel.Visibility = Visibility.Hidden;
                _visibleButton.Style = (Style)Application.Current.Resources["MenuButton"];
                _visibleStackPanel = null;
                _visibleButton = null;

                stackPanel.Visibility = Visibility.Visible;
                button.Style = (Style)Application.Current.Resources["MenuButtonSticky"];
                _visibleStackPanel = stackPanel;
                _visibleButton = button;
            }
        }
    }
}
