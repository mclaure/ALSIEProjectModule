using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ALSIE_ProjectModule.Controls.Designer
{
    /// <summary>
    /// Interaction logic for UmlGeneralizationControl.xaml
    /// </summary>
    public partial class UmlGeneralizationControl : UserControl
    {
        public UmlGeneralizationControl()
        {
            InitializeComponent();

            SetLongitude(0);
        }

        public void SetLongitude(double longitude)
        {
            GeneralizationLine.Y2 = longitude;
            GeneralizationCanvas.Height = longitude;
        }
    }
}
