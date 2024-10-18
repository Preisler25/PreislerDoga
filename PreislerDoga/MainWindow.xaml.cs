using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PreislerDoga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tipus.Items.Clear();
            FilterTipus.Items.Clear();
            foreach (var i in Könyv.könyv_types)
            {
                Tipus.Items.Add(i);
                FilterTipus.Items.Add(i);
            }
        }

        private void Render()
        {
            DisplayList.Items.Clear();
            foreach (Könyv könyv in Könyv.könyvek)
            {
                DisplayList.Items.Add(könyv);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            DisplayList.Items.Clear();
            foreach (Könyv könyv in Könyv.könyvek)
            {
                if (könyv.Típus == FilterTipus.Text)
                {
                    DisplayList.Items.Add(könyv);
                }
            }
            FilterTipus.Text = "";
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            String name = Cim.Text;
            String type = Tipus.Text;

            if (name == null) {
                MessageBox.Show("Nem adtál meg címet!");
                return;
            }
            if (name == "")
            {
                MessageBox.Show("Nem adtál meg címet!");
                return;
            }
            if (type == null) {
                MessageBox.Show("Nem adtál meg típust!");
                return;
            }
            if (type == "")
            {
                MessageBox.Show("Nem adtál meg típust!");
                return;
            }

            Könyv.könyvek.Add(new Könyv(name, type));

            Cim.Text = "";
            Tipus.Text = "";

            Render();
        }

        private void Del(object sender, MouseButtonEventArgs e)
        {

            Könyv selectedKönyv = (Könyv)DisplayList.SelectedItem;

            MessageBoxResult result = MessageBox.Show($"Biztosan törölni akarod a '{selectedKönyv.Cím}' ?", "Törlés megerősítése", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Könyv.könyvek.Remove(selectedKönyv);
                Render();
            }
        }

        private void ShowAll(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Összes könyv: \n" + string.Join("\n", Könyv.könyvek));
        }

        private void ResetFilter(object sender, RoutedEventArgs e)
        {
            Render();
        }
    }
}
