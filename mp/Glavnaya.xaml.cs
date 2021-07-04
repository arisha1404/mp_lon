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

namespace mp
{
    /// <summary>
    /// Логика взаимодействия для Glavnaya.xaml
    /// </summary>
    public partial class Glavnaya : Page
    {
        List<Книги> KnigiList = BaseBd.B.Книги.ToList();
        public Glavnaya()
        {
            InitializeComponent();
            DGbook.ItemsSource = KnigiList;
            
        }
        int i = -1;
        public static int result = 0;
        int indexChange;
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < KnigiList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Книги KN = KnigiList[i];
                Uri U = new Uri(KN.Обложка, UriKind.RelativeOrAbsolute);
                ME.Source = U;
            }
        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i< KnigiList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги KN = KnigiList[i];
                TB.Text = Convert.ToString("Название: " + KN.Название);
            }
        }

        private void avtor_Initialized(object sender, EventArgs e)
        {

            if (i < KnigiList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги KN = KnigiList[i];
                TB.Text = KN.Авторы.Автор;
            }
        }

        private void cost_Initialized(object sender, EventArgs e)
        {
            if (i < KnigiList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги KN = KnigiList[i];
                int cost = Convert.ToInt32(KN.Цена);
                TB.Text = Convert.ToString("Цена: " + cost + "руб");
            }
        }

        private void Nal_Initialized(object sender, EventArgs e)
        {
            if (i < KnigiList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги KN = KnigiList[i];
                TB.Text = Convert.ToString("Наличие в магазине: " + KN.Количество_магазин);
            }
        }

        private void NakSklad_Initialized(object sender, EventArgs e)
        {
            if (i < KnigiList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги KN = KnigiList[i];
                if (KN.Количество_склад > 5)
                {
                    TB.Text = Convert.ToString("Наличие на складе: " + "много");
                }
                else
                {
                    TB.Text = Convert.ToString("Наличие на складе: " + KN.Количество_склад);
                }
            }
        }

        private void zakaz_Initialized(object sender, EventArgs e)
        {
            Button zak = (Button)sender;
            if (zak != null)
            {
                zak.Uid = Convert.ToString(i);
            }
        }
        int z = 0;
        int cost_sum = 0;
        private void zakaz_Click(object sender, RoutedEventArgs e)
        {
            info.Visibility = Visibility.Visible;
            Button zak = (Button)sender;
            int index = Convert.ToInt32(zak.Uid);
            indexChange = Convert.ToInt32(zak.Uid);
            Книги KN = KnigiList[indexChange];
            z++;
            kolvo.Text = Convert.ToString("Количество выбранных книг: " + z);
            int prise = KN.Цена;
            cost_sum += prise;
            cost.Text = Convert.ToString("Цена покупки: " + cost_sum + " руб");


        }
    }
}
