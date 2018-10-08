using ALSIE_ProjectModule.Controls.Designer;
using ALSIE_ProjectModule.Controls.Toolbox;
using System.Windows;
using System.Windows.Controls;

namespace ALSIE_ProjectModule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ToolBoxItemDelegate
    {
        #region MainWindow
        private ToolBoxControl thingsToolbox;
        private ToolBoxControl relationshipsToolbox;
        private UmlDesignerCanvas umlDesignerCanvas;

        public MainWindow()
        {
            InitializeComponent();

            this.CreateUmlDesignerCanvas();

            this.CreateThingsToolbox();
            this.CreateRelationShipsToolbox();
        }
        #endregion


        #region UmlDesignerCanvas
        private void CreateUmlDesignerCanvas()
        {
            this.umlDesignerCanvas = new UmlDesignerCanvas();
            UmlCanvasContainer.Content = this.umlDesignerCanvas;
        }

        private void UpdateCurrentToolBoxItem(ToolBoxItem toolBoxItem)
        {
            this.umlDesignerCanvas.UpdateCurrentToolBoxItem(toolBoxItem);
        }
        #endregion

        
        #region ToolBox
        private void CreateThingsToolbox()
        {
            this.thingsToolbox = new ToolBoxControl("Things", Orientation.Horizontal);
            this.thingsToolbox.AddToolBoxItem(ToolBoxItem.Class, this);
            this.thingsToolbox.AddToolBoxItem(ToolBoxItem.Interface, this);

            ToolBoxPanel.Children.Add(this.thingsToolbox);
        }

        private void CreateRelationShipsToolbox()
        {
            this.relationshipsToolbox = new ToolBoxControl("Relationships", Orientation.Vertical);
            this.relationshipsToolbox.AddToolBoxItem(ToolBoxItem.Generalization, this);
            this.relationshipsToolbox.AddToolBoxItem(ToolBoxItem.Composition, this);
            this.relationshipsToolbox.AddToolBoxItem(ToolBoxItem.Aggregation, this);
            this.relationshipsToolbox.AddToolBoxItem(ToolBoxItem.Association, this);
            this.relationshipsToolbox.AddToolBoxItem(ToolBoxItem.Dependency, this);

            ToolBoxPanel.Children.Add(this.relationshipsToolbox);
        }

        private void UnselectAllToolBoxItems()
        {
            this.thingsToolbox.UnselectToolBoxItems();
            this.relationshipsToolbox.UnselectToolBoxItems();
        }

        private void SelectToolBoxItem(ToolBoxItem toolBoxItem)
        {
            this.UnselectAllToolBoxItems();
            this.thingsToolbox.SelectToolBoxItem(toolBoxItem);
            this.relationshipsToolbox.SelectToolBoxItem(toolBoxItem);
        }
        #endregion


        #region ToolBoxItemDelegate
        public void NotifySelectAction(ToolBoxItem toolBoxItem)
        {
            this.SelectToolBoxItem(toolBoxItem);

            this.UpdateCurrentToolBoxItem(toolBoxItem);
        }

        public void NotifyUnselectAction()
        {
            this.UnselectAllToolBoxItems();

            this.UpdateCurrentToolBoxItem(ToolBoxItem.Undefined);
        }
        #endregion
    }
}
