using ALSIE_ProjectModule.Controls.Toolbox;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ALSIE_ProjectModule.Controls.Designer
{
    public partial class UmlDesignerCanvas : Canvas
    {
        #region UmlDesignerCanvas
        public ToolBoxItem currentToolBoxItem;
        public UmlDesignerCanvas()
        {
            this.Background = Brushes.GhostWhite;
            this.Cursor = Cursors.Cross;
            this.currentToolBoxItem = ToolBoxItem.Undefined;

            MouseLeftButtonDown += (sender, eventArgs) =>
            {
                Point mousePosition = eventArgs.GetPosition(this);
                switch(this.currentToolBoxItem)
                {
                    case ToolBoxItem.Class: this.AddUmlClassControl(mousePosition); break;
                    case ToolBoxItem.Interface: this.AddUmlInterfaceControl(mousePosition); break;
                    default: this.DisplayAlertMessage(); break;
                }
            };

            MouseUp += (sender, eventArgs) =>
            {
                this.InvalidateMeasure();
            };
        }
        
        public void UpdateCurrentToolBoxItem(ToolBoxItem toolBoxItem)
        {
            this.currentToolBoxItem = toolBoxItem;
        }

        private void AddUmlInterfaceControl(Point mousePosition)
        {
            UmlInterfaceControl umlInterfaceControl = new UmlInterfaceControl();
            this.AddUserControl(umlInterfaceControl, mousePosition);
            umlInterfaceControl.Focus();
            umlInterfaceControl.GetFocus();
        }

        private void AddUmlClassControl(Point mousePosition)
        {
            UmlClassControl umlClassControl = new UmlClassControl();
            this.AddUserControl(umlClassControl, mousePosition);
            umlClassControl.Focus();
            umlClassControl.GetFocus();
        }

        private void AddUserControl(UserControl userControl, Point position)
        {
            Canvas.SetLeft(userControl, position.X);
            Canvas.SetTop(userControl, position.Y);
            this.Children.Add(userControl);
        }
        
        private void DisplayAlertMessage()
        {
            string applicationName = "UML Class Diagrammer";
            string message = "You have to select a ToolBoxItem first!";
            MessageBox.Show(message, applicationName);
        }
        #endregion


        #region Canvas
        protected override Size MeasureOverride(Size constraint)
        {
            Size size = new Size();

            foreach (UIElement element in this.InternalChildren)
            {
                double left = Canvas.GetLeft(element);
                double top = Canvas.GetTop(element);
                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                element.Measure(constraint);

                Size desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }

            // Add a default margin
            size.Width += 10;
            size.Height += 10;

            return size;
        }
        #endregion
    }
}
