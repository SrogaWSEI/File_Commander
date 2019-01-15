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
        }


        
        //Funkcje pobierające dane

        //Wrzucanie dysków do combo
        public void GettingListDrives()
        {
            DriveInfo[] ListDrives = DriveInfo.GetDrives();
            for (int i=0; i<ListDrives.Length; i++)
            {
                ListDisk_1.Items.Add(ListDrives[i]);
            }           
        }
       
    //Wrzucanie plików do Listy
    public void GettingFiles()
        {

            DirectoryInfo disk = new DirectoryInfo(@"C:\");
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

        //POBIERANIE Z LISTY
       

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void List_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    

        //Funkcje pobierające dane KONIEC


    }

}

