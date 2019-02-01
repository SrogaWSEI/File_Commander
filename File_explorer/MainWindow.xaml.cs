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
            //GettingFiles();
            // string text = ListView_1.SelectedItems[0].ToString();

        }

       

        //Funkcje pobierające dane

        //Wrzucanie dysków do combo
        public void GettingListDrives()
        {
            DriveInfo[] ListDrives = DriveInfo.GetDrives();
            for (int i = 0; i < ListDrives.Length; i++)
                {
                   if (ListDrives[i].DriveType.ToString() != "CDRom")
                    {
                        ListDisk_1.Items.Add(ListDrives[i]);
                        ListDisk_2.Items.Add(ListDrives[i]);
                    }                   
                }
        }
       
    //Wrzucanie plików do Listy
    public void GetLeftFiles(string tmp)
        {
            ListView_1.Items.Clear();
            DirectoryInfo disk = new DirectoryInfo(tmp);           
            FileInfo[] Files = disk.GetFiles();
            DirectoryInfo[] Directories = disk.GetDirectories();
            //Files           
            foreach (FileInfo file in Files)
            {
                ListView_1.Items.Add(file.Name);
            }
            //Directonaries
            foreach (DirectoryInfo directory in Directories)
            {
                ListView_1.Items.Add(directory.Name);
            }
        }
    public void GetRightFiles(string tmp)
        {
            ListView_2.Items.Clear();
            DirectoryInfo disk = new DirectoryInfo(tmp);
            FileInfo[] Files = disk.GetFiles();
            DirectoryInfo[] Directories = disk.GetDirectories();
            //Files           
            foreach (FileInfo file in Files)
            {
                ListView_2.Items.Add(file.Name);
            }
            //Directonaries
            foreach (DirectoryInfo directory in Directories)
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
                GetLeftFiles(getdisk);
            }
            else
            {
                string getdisk = @"C:\";
                GetLeftFiles(getdisk);
            }

            
        }

        private void ListDisk_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListDisk_2.SelectedIndex >= 0)
            {
                string getdisk = ListDisk_2.SelectedItem.ToString();
                GetRightFiles(getdisk);
            }
            else
            {
                string getdisk = @"C:\";
                GetRightFiles(getdisk);
            }
        }

         //WERSJA BUTTONOW NIE POPRAWNA Z BŁĘDAMI 
        //BUTTON OTWÓRZ_LEWY
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name_left = ListView_1.SelectedItems[0].ToString();
            
            if (ListDisk_1.SelectedIndex >= 0)
            {
                string getdisk = ListDisk_1.SelectedItem.ToString() + name_left;
                GetLeftFiles(getdisk);
            }
            else
            {
                string getdisk = @"C:\" + name_left;
                GetLeftFiles(getdisk);
            }           
        }
        //BUTTON OTWÓRZ_PRAWY
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name_right = ListView_2.SelectedItems[0].ToString();
            test2.Text = name_right;
        }
        //BUTTON WSTECZ
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ListDisk_1.SelectedIndex >= 0)
            {
                string getdisk = ListDisk_1.SelectedItem.ToString();
                GetLeftFiles(getdisk);
            }
            else
            {
                string getdisk = @"C:\";
                GetLeftFiles(getdisk);
            }
        }










        //Funkcje pobierające dane KONIEC


    }

}

