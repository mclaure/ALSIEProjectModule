using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ALSIE_ProjectModule.Abilities
{
    public class MovementAbility : UserControlAbility
    {
        private Point initialUserControlPosition = new Point();
        private Point initialMousePosition = new Point();

        public void InjectAbility(UserControl userControl)
        {
            #region UserControl
            userControl.Cursor = Cursors.SizeAll;
            #endregion

            #region MouseEvents
            userControl.MouseRightButtonDown += (sender, eventArgs) =>
            {
                this.initialUserControlPosition = new Point(Canvas.GetLeft(userControl), Canvas.GetTop(userControl));
                this.initialMousePosition = eventArgs.GetPosition(userControl);

                userControl.CaptureMouse();
            };

            userControl.MouseMove += (sender, eventArgs) =>
            {
                if (eventArgs.RightButton == MouseButtonState.Pressed)
                {
                    Point newMousePosition = eventArgs.GetPosition(userControl);
                    Point deltaMousePosition = new Point(this.initialMousePosition.X - newMousePosition.X, this.initialMousePosition.Y - newMousePosition.Y);

                    Point newUserControlPosition = new Point(this.initialUserControlPosition.X - deltaMousePosition.X, this.initialUserControlPosition.Y - deltaMousePosition.Y);
                    Canvas.SetLeft(userControl, newUserControlPosition.X);
                    Canvas.SetTop(userControl, newUserControlPosition.Y);

                    this.initialUserControlPosition = newUserControlPosition;
                }
            };

            userControl.MouseUp += (sender, eventArgs) =>
            {
                userControl.ReleaseMouseCapture();
            };
            #endregion
        }
    }
}
