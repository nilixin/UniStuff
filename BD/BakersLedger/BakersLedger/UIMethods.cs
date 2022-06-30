using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BakersLedger
{
    static class UIMethods
    {
        private static ScrollViewer? _visibleScrollViewer = null;
        private static Button? _visibleButton = null;

        public static void ToggleVisibility(ScrollViewer scrollViewer, Button button)
        {
            if (_visibleScrollViewer == null) // нет отображённой панели
            {
                scrollViewer.Visibility = Visibility.Visible;
                button.Style = (Style)Application.Current.Resources["MenuButtonSticky"];
                _visibleScrollViewer = scrollViewer;
                _visibleButton = button;
            }
            else if (_visibleScrollViewer == scrollViewer) // выбрана та же отображаемая панель, панель прячется
            {
                scrollViewer.Visibility = Visibility.Hidden;
                button.Style = (Style)Application.Current.Resources["MenuButton"];
                _visibleScrollViewer = null;
                _visibleButton = null;
            }
            else // выбрана другая панель для отображения, не смотря на уже отображённую
            {
                _visibleScrollViewer.Visibility = Visibility.Hidden;
                _visibleButton.Style = (Style)Application.Current.Resources["MenuButton"];
                _visibleScrollViewer = null;
                _visibleButton = null;

                scrollViewer.Visibility = Visibility.Visible;
                button.Style = (Style)Application.Current.Resources["MenuButtonSticky"];
                _visibleScrollViewer = scrollViewer;
                _visibleButton = button;
            }
        }
    }
}
