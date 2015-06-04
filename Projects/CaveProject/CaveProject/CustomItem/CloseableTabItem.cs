using CaveProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CaveProject.CustomItem
{
    public class CloseableTabItem : TabItem
    {
        TabCloseButton closeButton;
        DockPanel dockPanel;

        public void SetHeader(UIElement header)
        {
            // Container for header controls
            dockPanel = new DockPanel();
            dockPanel.Children.Add(header);

            // Close button to remove the tab
            closeButton = new TabCloseButton();
            closeButton.Click +=
                (sender, e) =>
                {
                    ItemsControl tabControl = Parent as ItemsControl;

                    Console.Out.WriteLine("click_item");
                    tabControl.Items.Remove(this);
                };
            dockPanel.Children.Add(closeButton);

            // Set the header
            Header = dockPanel;
        }
    }
}
