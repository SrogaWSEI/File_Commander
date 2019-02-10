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
        //Disk in combo left+right
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

        //Left List View
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
            //Directories
            foreach (DirectoryInfo directory in Directories)
            {
                ListView_1.Items.Add(directory.Name);
            }

        }
        //Right List View
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
            //Directories
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

        //Left list disk
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
        //Right list disk
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

        //left button open
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListDisk_1.SelectedIndex >= 0)
            {
                string disk_left = ListDisk_1.SelectedItem.ToString();
                string name_left = ListView_1.SelectedItems[0].ToString();
                string files = ".";
                bool isfile = name_left.Contains(files);
                if (!isfile)
                {
                    try
                    {
                        string getdisk = disk_left + name_left;
                        GetLeftFiles(getdisk);
                    }
                    catch
                    {
                        MessageBox.Show("Coś poszło nie tak!");
                    }

                }
                else
                {
                    MessageBox.Show("Nie możesz otwierać plików!");
                    string getdisk = disk_left;
                    GetLeftFiles(getdisk);
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }    
        }
        //right button open
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ListDisk_2.SelectedIndex >= 0)
            {
                string disk_right = ListDisk_2.SelectedItem.ToString();
                string name_right = ListView_2.SelectedItems[0].ToString();
                string files = ".";
                bool isfile = name_right.Contains(files);

                if (!isfile)
                {
                    try
                    {
                        string getdisk = disk_right + name_right;
                        GetRightFiles(getdisk);
                    }
                    catch
                    {
                        MessageBox.Show("Coś poszło nie tak!");
                    }

                }
                else
                {
                    MessageBox.Show("Nie możesz otwierać plików!");
                    string getdisk = disk_right;
                    GetRightFiles(getdisk);
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }
        }
        //left back button
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
        //right back button
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
        //left copy button
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ListDisk_1.SelectedIndex >= 0)
            {
                string fileName = ListView_1.SelectedItems[0].ToString();
                string sourcePath = ListDisk_1.SelectedItem.ToString();
                string targetPath = ListDisk_2.SelectedItem.ToString();

                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                if (File.Exists(sourceFile))
                {
                    try
                    {
                        File.Copy(sourceFile, destFile);
                        MessageBox.Show("Skopiowano");
                        GetRightFiles(targetPath);
                    }
                    catch
                    {
                        MessageBox.Show("Coś poszło nie tak!");
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak!");
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }
        }
        //right copy button
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (ListDisk_2.SelectedIndex >= 0)
            {
                string fileName = ListView_2.SelectedItems[0].ToString();
                string sourcePath = ListDisk_2.SelectedItem.ToString();
                string targetPath = ListDisk_1.SelectedItem.ToString();

                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                if (File.Exists(sourceFile))
                {
                    try
                    {
                        File.Copy(sourceFile, destFile);
                        MessageBox.Show("Skopiowano");
                        GetLeftFiles(targetPath);
                    }
                    catch
                    {
                        MessageBox.Show("Coś poszło nie tak!");
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak!");
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }

        }

        //left move button
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (ListDisk_1.SelectedIndex >= 0)
            {
                string fileName = ListView_1.SelectedItems[0].ToString();
                string sourcePath = ListDisk_1.SelectedItem.ToString();
                string targetPath = ListDisk_2.SelectedItem.ToString();

                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                if (File.Exists(sourceFile))
                {
                    try
                    {
                        File.Move(sourceFile, destFile);
                        MessageBox.Show("Przeniesiono!");
                        GetLeftFiles(sourcePath);
                        GetRightFiles(targetPath);
                    }
                    catch
                    {
                        MessageBox.Show("Coś poszło nie tak!");
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak!");
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }
        }
        //right move button
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (ListDisk_2.SelectedIndex >= 0)
            {
                string fileName = ListView_2.SelectedItems[0].ToString();
                string sourcePath = ListDisk_2.SelectedItem.ToString();
                string targetPath = ListDisk_1.SelectedItem.ToString();

                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                if (File.Exists(sourceFile))
                {
                    try
                    {
                        File.Move(sourceFile, destFile);
                        MessageBox.Show("Przeniesiono");
                        GetRightFiles(sourcePath);
                        GetLeftFiles(targetPath);
                    }
                    catch
                    {
                        MessageBox.Show("Coś poszło nie tak!");
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak!");
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }
        }
        //left delete button
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ListDisk_1.SelectedIndex >= 0)
            {
                string disk_left = ListDisk_1.SelectedItem.ToString();
                string name_left = ListView_1.SelectedItems[0].ToString();
                string file = disk_left + name_left;
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                        MessageBox.Show("Usunięto!");
                        GetLeftFiles(disk_left);
                    }
                    catch
                    {
                        MessageBox.Show("Nie można usunąć!");
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak!");
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }
        }
        //right delete button
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (ListDisk_2.SelectedIndex >= 0)
            {
                string disk_right = ListDisk_2.SelectedItem.ToString();
                string name_right = ListView_2.SelectedItems[0].ToString();
                string file = disk_right + name_right;
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                        MessageBox.Show("Usunięto!");
                        GetRightFiles(disk_right);
                    }
                    catch
                    {
                        MessageBox.Show("Nie można usunąć!");
                    }

                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak!");
                }
            }
            else
            {
                MessageBox.Show("Lista pusta!");
            }
        }


    }

}

