using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TiliToli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int db = 0;

        public MainWindow()
        {
            InitializeComponent();
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            Button5.IsEnabled = false;
            Button6.IsEnabled = false;
            Button7.IsEnabled = false;
            Button8.IsEnabled = false;
        }

        //Itt azt kezeljük le, hogy az adott gombot csak akkor tudjuk elmozgatni, ha mellette található a nullás gomb
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button egyikGomb = sender as Button;
            Button nullaGomb = (Button)FindName("Button0");
            int vtav = Math.Abs((int)(egyikGomb.Margin.Left - nullaGomb.Margin.Left));
            int ftav = Math.Abs((int)(egyikGomb.Margin.Top - nullaGomb.Margin.Top));
            if ((vtav < 175 && ftav == 0) || (ftav < 175 && vtav == 0))
            {
                var seged = egyikGomb.Margin;
                egyikGomb.Margin = nullaGomb.Margin;
                nullaGomb.Margin = seged;
                db++;
                steps.Content = "Lépésszám: " + db;
            }

            Button Button1 = (Button)FindName("Button1");
            Button Button2 = (Button)FindName("Button2");
            Button Button3 = (Button)FindName("Button3");
            Button Button4 = (Button)FindName("Button4");
            Button Button5 = (Button)FindName("Button5");
            Button Button6 = (Button)FindName("Button6");
            Button Button7 = (Button)FindName("Button7");
            Button Button8 = (Button)FindName("Button8");

            //Ha az összes gomb a helyén van, akkor vége a játéknak és kiírja, hogy hány lépésbl sikerült kirakni

            if ((int)(Button1.Margin.Left) == 23 && (int)(Button1.Margin.Top) == 61 && (int)(Button2.Margin.Left) == 175 && (int)(Button2.Margin.Top) == 61 && (int)(Button3.Margin.Left) == 327 && (int)(Button3.Margin.Top) == 61 && (int)(Button4.Margin.Left) == 23 && (int)(Button4.Margin.Top) == 213 && (int)(Button5.Margin.Left) == 175 && (int)(Button5.Margin.Top) == 213 && (int)(Button6.Margin.Left) == 327 && (int)(Button6.Margin.Top) == 213 && (int)(Button7.Margin.Left) == 23 && (int)(Button7.Margin.Top) == 365 && (int)(Button8.Margin.Left) == 175 && (int)(Button8.Margin.Top) == 365)
                    {
                        string message = Convert.ToString(db) + " lépésből kiraktad!";
                        keszLabel.Content = message;
                        db = 0;
                    }
                
            
        }

        //Ebben a metódusban a program elején lévő metódushoz hasonlóan összekeverjük a gombokat, így biztos kirakható
        private void _new_Click(object sender, RoutedEventArgs e)
        {
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;
            newgame.IsEnabled = true;
            keszLabel.Content = " ";
            byte mixingRandom = 0;
            byte mixingNow = 0;
            byte mixingStep = 0;
            steps.Content = "Lépésszám: ";
            Button nullGomb = (Button)FindName("Button0");
            Random r = new Random();
            do
            {
                do
                {
                    mixingRandom = Convert.ToByte(r.Next(1, 9));
                } while (mixingNow == mixingRandom);
                mixingNow = mixingRandom;
                string gomb = "Button" + mixingRandom;
                Button egyGomb = (Button)FindName(gomb);
                int vtav = Math.Abs((int)(egyGomb.Margin.Left - nullGomb.Margin.Left));
                int ftav = Math.Abs((int)(egyGomb.Margin.Top - nullGomb.Margin.Top));
                if ((vtav < 175 && ftav == 0) || (ftav < 175 && vtav == 0))
                {
                    var seged = egyGomb.Margin;
                    egyGomb.Margin = nullGomb.Margin;
                    nullGomb.Margin = seged;
                    mixingStep++;
                }
            } while (mixingStep != 100);
        }
    }
}
