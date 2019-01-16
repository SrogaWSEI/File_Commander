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
using System.IO;



namespace File_explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            GettingListDrives();
            GettingFiles();
            // string text = ListView_1.SelectedItems[0].ToString();

        }

       

        //Funkcje pobierające dane

        //Wrzucanie dysków do combo
        public void GettingListDrives()
        {
            DriveInfo[] ListDrives = DriveInfo.GetDrives();
            for (int i=0; i<ListDrives.Length; i++)
            {
                ListDisk_1.Items.Add(ListDrives[i]);
                ListDisk_2.Items.Add(ListDrives[i]);
            }
            
            
           
        }
       
    //Wrzucanie plików do Listy
    public void GettingFiles()
        {
            DirectoryInfo disk = new DirectoryInfo(@"D:\");
            DirectoryInfo disk_2 = new DirectoryInfo(@"C:\");
            FileInfo[] Files = disk.GetFiles();
            DirectoryInfo[] Directories = disk.GetDirectories();
            FileInfo[] Files_2 = disk_2.GetFiles();
            DirectoryInfo[] Directories_2 = disk_2.GetDirectories();
            //Files           
            foreach (FileInfo file in Files)
            {
                ListView_1.Items.Add(file.Name);
            }
            foreach (FileInfo file in Files_2)
            {
                ListView_2.Items.Add(file.Name);
            }
            //Directonaries
            foreach (DirectoryInfo directory in Directories)
            {
                ListView_1.Items.Add(directory.Name);
            }
            foreach (DirectoryInfo directory in Directories_2)
            {
                ListView_2.Items.Add(directory.Name);
            }
        }

        //POBIERANIE Z LISTY
       

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void List_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListDisk_1.SelectedIndex >= 0)
            {
                string getdisk = ListDisk_1.SelectedItem.ToString();
                txt_test.Text = getdisk;
            }
            else
            {
                string getdisk = @"C:\";
                txt_test.Text = getdisk;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_test_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Txt_test_TextChanged(object sender, TextChangedEventArgs e)
        {

        }





        //Funkcje pobierające dane KONIEC


    }

}

