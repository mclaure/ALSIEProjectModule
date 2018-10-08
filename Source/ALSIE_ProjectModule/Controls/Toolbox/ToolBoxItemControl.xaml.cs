using System.Windows;
using System.Windows.Controls;

namespace ALSIE_ProjectModule.Controls.Toolbox
{
    /// <summary>
    /// Interaction logic for ToolBoxItemControl.xaml
    /// </summary>
    public partial class ToolBoxItemControl : UserControl
    {
        public enum ToolBoxItemMode
        {
            Selected,
            Unselected
        }

        private ToolBoxItem toolBoxItem;
        private ToolBoxItemDelegate toolBoxItemDelegate;

        public ToolBoxItemControl(ToolBoxItem toolBoxItem, ToolBoxItemDelegate toolBoxItemDelegate)
        {
            InitializeComponent();

            this.toolBoxItem = toolBoxItem;
            this.toolBoxItemDelegate = toolBoxItemDelegate;
            
            ToolBoxText.Text = toolBoxItem.ToString();
        }

        private void ToolBoxButton_Click(object sender, RoutedEventArgs e)
        {
            this.SwitchToolBoxItemMode();
        }

        private void SwitchToolBoxItemMode()
        {
            if (ToolBoxButton.Tag.ToString() == ToolBoxItemMode.Selected.ToString())
            {
                this.UnselectToolBoxButton();
                this.toolBoxItemDelegate.NotifyUnselectAction();
            }
            else
            {
                this.SelectToolBoxButton();
                this.toolBoxItemDelegate.NotifySelectAction(this.toolBoxItem);
            }
        }

        public ToolBoxItem GetToolBoxItem()
        {
            return this.toolBoxItem;
        }

        public void SelectToolBoxButton()
        {
            ToolBoxButton.Tag = ToolBoxItemMode.Selected.ToString();
        }

        public void UnselectToolBoxButton()
        {
            ToolBoxButton.Tag = ToolBoxItemMode.Unselected.ToString();
        }
    }
}
