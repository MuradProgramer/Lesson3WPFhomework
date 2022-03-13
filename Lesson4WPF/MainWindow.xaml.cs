using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Lesson4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Persons { get; set; }

        public MainWindow()
        {

            InitializeComponent();

            Persons = new ObservableCollection<Person>()
            { 
                new Person("Eva Summer", new ListBox(), new Label()),
                new Person("Billie Jean", new ListBox(), new Label()),
                new Person("John Doe", new ListBox(), new Label())
            };
            foreach (var person in Persons)
            {
                person.Messages.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\User\Desktop\WinForms\Lesson4WPF\Lesson4WPF\telegramwallpaper.jpg", UriKind.Relative)));
                scndGrid.Children.Add(person.Messages);
                Grid.SetRow(person.Messages, 0);
                person.Messages.Margin = new Thickness(6,6,3,0);
                person.Messages.FontSize = 20;
                ScrollViewer.SetHorizontalScrollBarVisibility(person.Messages, ScrollBarVisibility.Hidden);
                ScrollViewer.SetVerticalScrollBarVisibility(person.Messages, ScrollBarVisibility.Hidden);
            }

            lbPersons.SelectedIndex = 0;

            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (txtbWriteMes.Text.Length != 0)
            {
                var grpBox1 = new GroupBox();
                grpBox1.BorderThickness = new Thickness(0);
                grpBox1.Width = 574;

                var myBorder1 = new Border();
                myBorder1.Effect = new DropShadowEffect();
                myBorder1.HorizontalAlignment = HorizontalAlignment.Right;
                myBorder1.Background = Brushes.LightBlue;
                myBorder1.BorderThickness = new Thickness(0);
                myBorder1.CornerRadius = new CornerRadius(4);
                var label1 = new Label();
                if (txtbWriteMes.Text.Length >= 28)
                {
                    int ind = (txtbWriteMes.Text.Length - 1) / 28 + 1;
                    string temp = "";
                    for (int x = 0; x <= ind; x++)
                    {
                        for (int i = x * 28; i < (x + 1) * 28; i++)
                        {
                            if (i >= txtbWriteMes.Text.Length)
                                break;
                            temp += txtbWriteMes.Text[i];
                        }

                        temp += "\n";
                    }
                    temp = temp.Remove(temp.Length - 2);
                    label1.Content = temp;
                }
                else
                    label1.Content = txtbWriteMes.Text;
                myBorder1.Child = label1;

                grpBox1.Content = myBorder1;

                Persons[lbPersons.SelectedIndex].Messages.Items.Add(grpBox1);
                Persons[lbPersons.SelectedIndex].Messages.ScrollIntoView(
                    Persons[lbPersons.SelectedIndex].Messages.Items[Persons[lbPersons.SelectedIndex].Messages.Items.Count - 1]);

                (lbPersons.SelectedItem as Person).LastMessage.Content = "";
                if (txtbWriteMes.Text.Length >= 30)
                {
                    for (int i = 0; i < 30; i++)
                        (lbPersons.SelectedItem as Person).LastMessage.Content += txtbWriteMes.Text[i].ToString();
                    (lbPersons.SelectedItem as Person).LastMessage.Content += "...";
                }
                else
                    (lbPersons.SelectedItem as Person).LastMessage.Content = txtbWriteMes.Text;
                


                if (infoONOFF.Content.ToString() == "online")
                {
                    var rand = new Random();
                    if (rand.Next(2) == 1)
                    {
                        List<string> list = new List<string>() {
                        "Vaxtim yoxdu, birazdan cavab vererem.",
                        "Mueyyen Ishlere gore elaqe saxlamaga imkanim yoxdu, calishacam az sonra elaqe saxlayim seninle))",
                        "Sonra danishariq",
                        "..."}; 

                        int index = rand.Next(list.Count - 1);

                        grpBox1 = new GroupBox();
                        grpBox1.BorderThickness = new Thickness(0);

                        myBorder1 = new Border();
                        myBorder1.Effect = new DropShadowEffect();
                        myBorder1.HorizontalAlignment = HorizontalAlignment.Left;
                        myBorder1.Background = Brushes.White;
                        myBorder1.BorderThickness = new Thickness(0);
                        myBorder1.CornerRadius = new CornerRadius(4);
                        label1 = new Label();
                        if (list[index].Length >= 28)
                        {
                            int ind = (list[index].Length - 1) / 28 + 1;
                            string temp = "";
                            for (int x = 0; x <= ind; x++)
                            {
                                for (int i = x * 28; i < (x + 1) * 28; i++)
                                {
                                    if (i >= list[index].Length)
                                        break;
                                    temp += list[index][i];
                                }

                                temp += "\n";
                            }
                            temp = temp.Remove(temp.Length - 2);
                            label1.Content = temp;
                        }
                        else
                            label1.Content = list[index];
                        myBorder1.Child = label1;

                        grpBox1.Content = myBorder1;

                        Persons[lbPersons.SelectedIndex].Messages.Items.Add(grpBox1);
                        Persons[lbPersons.SelectedIndex].Messages.ScrollIntoView(
                            Persons[lbPersons.SelectedIndex].Messages.Items[Persons[lbPersons.SelectedIndex].Messages.Items.Count - 1]);

                        (lbPersons.SelectedItem as Person).LastMessage.Content = "";
                        if (list[index].Length >= 30)
                        {
                            for (int i = 0; i < 30; i++)
                                (lbPersons.SelectedItem as Person).LastMessage.Content += list[index][i].ToString();
                            (lbPersons.SelectedItem as Person).LastMessage.Content += "...";
                        }
                        else
                            (lbPersons.SelectedItem as Person).LastMessage.Content = list[index];
                    }
                }

                else
                {
                    var grpBox = new GroupBox();
                    grpBox.BorderThickness = new Thickness(0);

                    var myBorder = new Border();
                    myBorder.Effect = new DropShadowEffect();
                    myBorder.HorizontalAlignment = HorizontalAlignment.Left;
                    myBorder.Background = Brushes.White;
                    myBorder.BorderThickness = new Thickness(0);
                    myBorder.CornerRadius = new CornerRadius(4);

                    var label = new Label();
                    label.Content = "Danishdiginiz abuneci heleki\n offline-di. Zehmet olmasa\n gozleyin.";

                    myBorder.Child = label;

                    grpBox.Content = myBorder;

                    Persons[lbPersons.SelectedIndex].Messages.Items.Add(grpBox);
                    Persons[lbPersons.SelectedIndex].Messages.ScrollIntoView(
                        Persons[lbPersons.SelectedIndex].Messages.Items[Persons[lbPersons.SelectedIndex].Messages.Items.Count - 1]);
                    
                    (lbPersons.SelectedItem as Person).LastMessage.Content = "Danishdiginiz abuneci heleki offline...";
                }

                txtbWriteMes.Text = "";
            }
        }

        private void lbPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < Persons.Count; i++)
            {
                if (i == lbPersons.SelectedIndex)
                {
                    Persons[lbPersons.SelectedIndex].Messages.IsEnabled = true;
                    Persons[lbPersons.SelectedIndex].Messages.Visibility = Visibility.Visible;
                }
                else
                {
                    Persons[i].Messages.IsEnabled = false;
                    Persons[i].Messages.Visibility = Visibility.Hidden;
                }
            }
            lblName.Content = Persons[lbPersons.SelectedIndex].Fullname;
            var rand = new Random();
            if (rand.Next(2) == 1)
            {
                infoONOFF.Foreground = Brushes.Blue;
                infoONOFF.Content = "online";
            }
            else
            {
                infoONOFF.Foreground = Brushes.Gray;
                infoONOFF.Content = "offline";
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtbWriteMes.Text = "";
        }
    }
}
