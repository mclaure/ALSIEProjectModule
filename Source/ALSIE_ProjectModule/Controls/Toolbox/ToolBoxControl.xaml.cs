using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ALSIE_ProjectModule.Controls.Toolbox
{
    /// <summary>
    /// Interaction logic for ToolBoxControl.xaml
    /// </summary>
    public partial class ToolBoxControl : UserControl
    {
        private List<ToolBoxItemControl> toolBoxItems;

        public ToolBoxControl(string title, Orientation orientation)
        {
            InitializeComponent();

            ToolBoxExpander.Header = title;
            ToolBoxContainer.Orientation = orientation;

            toolBoxItems = new List<ToolBoxItemControl>();
        }

        public void AddToolBoxItem(ToolBoxItem toolBoxItem, ToolBoxItemDelegate toolBoxItemDelegate)
        {
            ToolBoxItemControl toolBoxItemControl = new ToolBoxItemControl(toolBoxItem, toolBoxItemDelegate);
            if (this.toolBoxItems.Count > 0)
            {
                this.UpdateMargin(toolBoxItemControl);
            }
            
            ToolBoxContainer.Children.Add(toolBoxItemControl);

            this.toolBoxItems.Add(toolBoxItemControl);
        }

        private void UpdateMargin(ToolBoxItemControl toolBoxItemControl)
        {
            if (ToolBoxContainer.Orientation == Orientation.Horizontal)
            {
                toolBoxItemControl.Margin = new Thickness(10, 0, 0, 0);
            }
            else
            {
                toolBoxItemControl.Margin = new Thickness(0, 10, 0, 0);
            }
        }

        public void SelectToolBoxItem(ToolBoxItem toolBoxItem)
        {
            foreach (ToolBoxItemControl item in this.toolBoxItems)
            {
                if (item.GetToolBoxItem() == toolBoxItem)
                {
                    item.SelectToolBoxButton();
                    break;
                }
            }
        }

        public void UnselectToolBoxItems()
        {
            foreach (ToolBoxItemControl toolBoxItem in this.toolBoxItems)
            {
                toolBoxItem.UnselectToolBoxButton();
            }
        }
    }
}
