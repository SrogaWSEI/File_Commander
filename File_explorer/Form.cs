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
        //Wrzucanie dysków do combo lewey i prawy
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

        //Wrzucanie plików do Listy lewej
        public void GetLeftFiles(string tmp)
        {
            ListView_1.Items.Clear();
            DirectoryInfo disk = new DirectoryInfo(tmp);
            FileInfo[] Files = disk.GetFiles();
            DirectoryInfo[] Directories = disk.GetDirectories();
            //Pliki     
            foreach (FileInfo file in Files)
            {
                ListView_1.Items.Add(file.Name);
            }
            //Foldery
            foreach (DirectoryInfo directory in Directories)
            {
                ListView_1.Items.Add(directory.Name);
            }

        }
        //Wrzucanie plików do listy prawej
        public void GetRightFiles(string tmp)
        {
            ListView_2.Items.Clear();
            DirectoryInfo disk = new DirectoryInfo(tmp);
            FileInfo[] Files = disk.GetFiles();
            DirectoryInfo[] Directories = disk.GetDirectories();
            //Pliki        
            foreach (FileInfo file in Files)
            {
                ListView_2.Items.Add(file.Name);
            }
            //Foldery
            foreach (DirectoryInfo directory in Directories)
            {
                ListView_2.Items.Add(directory.Name);
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        //Lista dysków lewa
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
        //Lista dysków prawa
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
            string disk_left = ListDisk_1.SelectedItem.ToString();
            string name_left = ListView_1.SelectedItems[0].ToString();
            string files = ".";
            bool isfile = name_left.Contains(files);

            test.Text = isfile.ToString();

            if (!isfile)
            {
                if (ListDisk_1.SelectedIndex >= 0)
                {
                    string getdisk = disk_left + name_left;
                    GetLeftFiles(getdisk);
                }
            }
            else
            {
                MessageBox.Show("Nie możesz otwierać plików!");
                string getdisk = disk_left;
                GetLeftFiles(getdisk);
            }
        }
        //BUTTON OTWÓRZ_PRAWY
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string disk_right = ListDisk_2.SelectedItem.ToString();
            string name_right = ListView_2.SelectedItems[0].ToString();
            string files = ".";
            bool isfile = name_right.Contains(files);

            test2.Text = name_right;

            if (!isfile)
            {
                if (ListDisk_2.SelectedIndex >= 0)
                {
                    string getdisk = disk_right + name_right;
                    GetRightFiles(getdisk);
                }
            }
            else
            {
                MessageBox.Show("Nie możesz otwierać plików!");
                string getdisk = disk_right;
                GetRightFiles(getdisk);
            }
        }
        //BUTTON WSTECZ LEWY
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
        //BUTTON WSTECZ PRAWY
        private void Button_Click_3(object sender, RoutedEventArgs e)
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










        //Funkcje pobierające dane KONIEC


    }

}

