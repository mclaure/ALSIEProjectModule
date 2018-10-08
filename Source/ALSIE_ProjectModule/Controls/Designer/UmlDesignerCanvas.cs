using ALSIE_ProjectModule.Controls.Toolbox;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ALSIE_ProjectModule.Controls.Designer
{
    public partial class UmlDesignerCanvas : Canvas
    {
        #region UmlDesignerCanvas
        private ToolBoxItem currentToolBoxItem;
        private List<UmlConnectorHandler> umlConnectorHandlers;
        private Point initialMousePosition;

        public UmlDesignerCanvas()
        {
            this.Background = Brushes.GhostWhite;
            this.Cursor = Cursors.Cross;
            this.currentToolBoxItem = ToolBoxItem.Undefined;

            this.umlConnectorHandlers = new List<UmlConnectorHandler>();

            MouseLeftButtonDown += (sender, eventArgs) =>
            {
                this.initialMousePosition = eventArgs.GetPosition(this);
                
                switch(this.currentToolBoxItem)
                {
                    case ToolBoxItem.Class: {
                            this.AddUmlClassControl();
                        }; break;
                    case ToolBoxItem.Interface: {
                            this.AddUmlInterfaceControl();
                        }; break;
                    case ToolBoxItem.Generalization:
                        {
                        }; break;
                    default: this.DisplayAlertMessage("You have to select a ToolBoxItem first!"); break;
                }
            };

            MouseUp += (sender, eventArgs) =>
            {
                Point mousePosition = eventArgs.GetPosition(this);
                switch (this.currentToolBoxItem)
                {
                    case ToolBoxItem.Generalization:
                        {
                            this.AddUmlGeneralizationControl(mousePosition);
                        }; break;
                    case ToolBoxItem.Composition:
                        {
                            this.DisplayAlertMessage("To be implemented!");
                        }; break;
                    case ToolBoxItem.Aggregation:
                        {
                            this.DisplayAlertMessage("To be implemented!");
                        }; break;
                    case ToolBoxItem.Association:
                        {
                            this.DisplayAlertMessage("To be implemented!");
                        }; break;
                    case ToolBoxItem.Dependency:
                        {
                            this.DisplayAlertMessage("To be implemented!");
                        }; break;
                    default: { } break;
                }

                this.InvalidateMeasure();
            };
        }
        
        public void UpdateCurrentToolBoxItem(ToolBoxItem toolBoxItem)
        {
            this.currentToolBoxItem = toolBoxItem;

            this.UpdateUmlConnectors();
        }
        
        private void UpdateUmlConnectors()
        {
            switch (this.currentToolBoxItem)
            {
                case ToolBoxItem.Class:
                    {
                        this.HideUmlConnectors();
                    }; break;
                case ToolBoxItem.Interface:
                    {
                        this.HideUmlConnectors();
                    }; break;
                case ToolBoxItem.Generalization:
                    {
                        this.ShowUmlConnectors();
                    }; break;
                case ToolBoxItem.Composition:
                    {
                        this.ShowUmlConnectors();
                    }; break;
                case ToolBoxItem.Aggregation:
                    {
                        this.ShowUmlConnectors();
                    }; break;
                case ToolBoxItem.Association:
                    {
                        this.ShowUmlConnectors();
                    }; break;
                case ToolBoxItem.Dependency:
                    {
                        this.ShowUmlConnectors();
                    }; break;
                default: this.HideUmlConnectors(); break;
            }
        }

        private void ShowUmlConnectors()
        {
            foreach (UmlConnectorHandler handler in this.umlConnectorHandlers)
            {
                handler.ShowUmlConnectors();
            }
        }

        private void HideUmlConnectors()
        {
            foreach (UmlConnectorHandler handler in this.umlConnectorHandlers)
            {
                handler.HideUmlConnectors();
            }
        }

        private void AddUmlGeneralizationControl(Point endPoint)
        {
            Point startPoint = this.initialMousePosition;
            double yDiff = endPoint.Y - startPoint.Y;
            double xDiff = endPoint.X - startPoint.X;
            double longitude = Math.Sqrt(Math.Pow(yDiff, 2) + Math.Pow(xDiff, 2));
            double angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
            
            UmlGeneralizationControl umlGeneralizationControl = new UmlGeneralizationControl();
            umlGeneralizationControl.SetLongitude(longitude);
            umlGeneralizationControl.RenderTransform = new RotateTransform(0, 10, longitude);
            ((RotateTransform)umlGeneralizationControl.RenderTransform).Angle = (90 + 360 + angle);
            
            this.AddUserControl(umlGeneralizationControl, new Point(startPoint.X - 10, startPoint.Y - longitude));
        }

        private void AddUmlInterfaceControl()
        {
            UmlInterfaceControl umlInterfaceControl = new UmlInterfaceControl();
            this.AddUserControl(umlInterfaceControl, this.initialMousePosition);
            umlInterfaceControl.Focus();
            umlInterfaceControl.GetFocus();

            this.umlConnectorHandlers.Add(umlInterfaceControl);
        }

        private void AddUmlClassControl()
        {
            UmlClassControl umlClassControl = new UmlClassControl();
            this.AddUserControl(umlClassControl, this.initialMousePosition);
            umlClassControl.Focus();
            umlClassControl.GetFocus();

            this.umlConnectorHandlers.Add(umlClassControl);
        }

        private void AddUserControl(UserControl userControl, Point position)
        {
            Canvas.SetLeft(userControl, position.X);
            Canvas.SetTop(userControl, position.Y);
            this.Children.Add(userControl);
        }
        
        private void DisplayAlertMessage(string message)
        {
            string applicationName = "UML Class Diagrammer";
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
