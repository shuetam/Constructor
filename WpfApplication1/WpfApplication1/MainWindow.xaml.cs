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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double beam_lenght;
        public double load_value;
        public double center;
        public double h_profile;
        public double b_profile;
        public double t_profile;
        public double h2_profile;
        public string wood_class;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void BeamLenght(object sender, TextChangedEventArgs e)
        {

            beam_lenght = DoubleFromTextbox((TextBox)sender);

        }


        private void PLoadValue(object sender, TextChangedEventArgs e)
        {

            load_value = DoubleFromTextbox((TextBox)sender);

        }

        private void PxValue(object sender, TextChangedEventArgs e)
        {

            center = DoubleFromTextbox((TextBox)sender);

        }

        private void qLoadValue(object sender, TextChangedEventArgs e)
        {


            load_value = DoubleFromTextbox((TextBox)sender);



        }

        private void HProfile(object sender, TextChangedEventArgs e)
        {

            h_profile = (DoubleFromTextbox((TextBox)sender)) / 100;

        }

        private void BProfile(object sender, TextChangedEventArgs e)
        {

            b_profile = (DoubleFromTextbox((TextBox)sender)) / 100;

        }


        private void tProfile(object sender, TextChangedEventArgs e)
        {

            t_profile = (DoubleFromTextbox((TextBox)sender)) / 100;

        }

        private void hProfile(object sender, TextChangedEventArgs e)
        {

            h2_profile = (DoubleFromTextbox((TextBox)sender)) / 100;

        }

        private void ProstokątDrew(object sender, RoutedEventArgs e)
        {

            image1.Source = new BitmapImage(new Uri("/WpfApplication1;component/Images/Przechwytywanie3.JPG", UriKind.RelativeOrAbsolute));

        }


        private void DwuteownikDrew(object sender, RoutedEventArgs e)
        {

            image1.Source = new BitmapImage(new Uri("/WpfApplication1;component/Images/DwuteoDrew.JPG", UriKind.RelativeOrAbsolute));

        }


        private void WoodClass(object sender, RoutedEventArgs e)
        {
            wood_class = ((ComboBoxItem)sender).Name;
        }


        private double DoubleFromTextbox(TextBox sender)
        {
            try { if (sender.Text == "") return 0; else return double.Parse(sender.Text); }
            catch
            {
                MessageBox.Show("Niepoprawny format wejściowy.");
                return 0;
            }
        }


        IBeam beam;
        ILoad load;
        IMaterial material;
        IProfile profile;

        void CreateStaticSchema()
        {
            if (BelkaObciazonaSilaSkupiona.IsChecked == true || BelkaZObciazeniemCiaglym.IsChecked == true)
            {
                image2.Source = new BitmapImage(new Uri("/WpfApplication1;component/Images/BelkaJedno.JPG"));
                beam = new SingleBeam(beam_lenght);
            }

            if (WspornikObciazonySilaSkupiona.IsChecked == true || WspornikZObciazeniemCiaglym.IsChecked==true)
            {
                beam = new Bracket(beam_lenght);
            }

            if (BelkaObciazonaSilaSkupiona.IsChecked == true || WspornikObciazonySilaSkupiona.IsChecked == true)
                   {
                        load = new FocusForce(beam, load_value, center);
                   }

            if (BelkaZObciazeniemCiaglym.IsChecked == true || WspornikZObciazeniemCiaglym.IsChecked == true)
                    {
                        load = new ContinuousLoad(beam, load_value);
                    }

                    beam.Reactions(load);
                }

        

        private void WoodResults(object sender, RoutedEventArgs e)
        {
            try
            {
            StringBuilder result = new StringBuilder();
            material =(Wood.GetWood()).First(x => x.Class == wood_class);
            CreateStaticSchema();


                if (ProstokatDrew.IsSelected == true)
                {
                    profile = new RecProfile(h_profile, b_profile, material, beam, load);
                }  

                if (DwuteowDrew.IsSelected == true)
                {
                    profile = new I_Profile(h_profile, b_profile, h2_profile, t_profile, material, beam, load);
                }


                        foreach (var v in beam.GetResults(load))
                        {
                         result.Append( (v + Environment.NewLine)); 
                        }
                         
                        foreach (var v in profile.GetResults())
                        {
                         result.Append((v + Environment.NewLine));
                        }

                Wyniki.Text = result.ToString();
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }

        }

       
    }

}




