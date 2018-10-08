using ALSIE_ProjectModule.Abilities;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ALSIE_ProjectModule.Controls.Designer
{
    /// <summary>
    /// Interaction logic for UmlClassControl.xaml
    /// </summary>
    public partial class UmlClassControl : UserControl, UmlConnectorHandler
    {
        #region UserControl
        private UserControlAbilityInjector abilityInjector;

        public UmlClassControl() : base()
        {
            InitializeComponent();

            this.abilityInjector = new UserControlAbilityInjector(this, new MovementAbility());
            this.abilityInjector.InjectAbility();

            this.AllowEdition(true);
            this.HideUmlConnectors();
        }

        private void AllowEdition(bool enable)
        {
            classNameTextBox.IsHitTestVisible = enable;
        }

        private void classNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (classNameTextBox.Text != "ClassName")
            {
                this.AllowEdition(false);
            }
        }

        public void GetFocus()
        {
            classNameTextBox.Focusable = true;
            Task.Delay(100).ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    classNameTextBox.Focus();
                }));
            });
            classNameTextBox.SelectAll();
        }
        #endregion


        #region UmlConnectorHandler
        public void ShowUmlConnectors()
        {
            TopConnector.Visibility = Visibility.Visible;
            BottomConnector.Visibility = Visibility.Visible;
            LeftConnector.Visibility = Visibility.Visible;
            RightConnector.Visibility = Visibility.Visible;
        }

        public void HideUmlConnectors()
        {
            TopConnector.Visibility = Visibility.Hidden;
            BottomConnector.Visibility = Visibility.Hidden;
            LeftConnector.Visibility = Visibility.Hidden;
            RightConnector.Visibility = Visibility.Hidden;
        }
        #endregion
    }
}
