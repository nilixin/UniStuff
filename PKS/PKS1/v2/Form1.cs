using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace v2
{
    public partial class Form1 : Form
    {
        ImageList ImageList = new ImageList();
        
        string Server = string.Empty; // данные, введённые пользователем
        string Username = string.Empty;
        string Password = string.Empty;
        string CurrentRemotePath = string.Empty; // текущий серверный путь
        string CurrentLocalPath = string.Empty; // текущий локальный путь

        public Form1()
        {
            InitializeComponent();

            DefineTabOrder();

            #region ToolTips
            toolTip.SetToolTip(bDownload, "Скачать с сервера");
            toolTip.SetToolTip(bUpload, "Загрузить на сервер");
            toolTip.SetToolTip(bRemoteRefresh, "Обновить");
            toolTip.SetToolTip(bLocalRefresh, "Обновить");
            toolTip.SetToolTip(bRemoteHome, "Домашняя директория на сервере");
            toolTip.SetToolTip(bLocalHome, "Домашняя директория на компьютере");
            toolTip.SetToolTip(bNewRemoteFolder, "Создать папку");
            toolTip.SetToolTip(bNewRemoteFile, "Создать файл");
            #endregion

            tbServer.Text = "ftp://localhost";
            tbUsername.Text = "User";
            
            ImageList.ImageSize = new Size(32, 32); // добавление иконок в lvRemote и lvLocal
            ImageList.Images.Add(Image.FromFile(@"../../../icons/file.png"));
            ImageList.Images.Add(Image.FromFile(@"../../../icons/folder.png"));
            lvRemote.LargeImageList = ImageList;
            lvLocal.LargeImageList = ImageList;

            CurrentLocalPath = @"C:/"; // изменение текущего локального пути
            LocalDirectoryDetails(CurrentLocalPath);

            ConnectionStatus.None(lConnectionStatus);
            bDownload.Enabled = false;
            bUpload.Enabled = false;
            bNewRemoteFolder.Enabled = false;
            bNewRemoteFile.Enabled = false;
            bRemoteHome.Enabled = false;
            bRemoteRefresh.Enabled = false;
        }

        // Устанавливает соединение с сервером, запоминает введённые данные для дальнейшего использования
        private void bConnect_Click(object sender, EventArgs e)
        {
            List<string[]>? details = FtpAdapter.ListDirectoryDetails(tbServer.Text, tbUsername.Text, tbPassword.Text);
            lvRemote.Items.Clear();
            if (details == null) // если вернуло null, то подключение не произошло
            {
                ConnectionStatus.None(lConnectionStatus);
                return;
            }

            foreach (var detail in details) // перенесение содержимого сервера в lvRemote
            {
                // если в первом элементе, содержащем разрешения, есть буква 'd', то это папка
                // тогда к lvRemote добавляется самый последний элемент, содержащий название файла
                if (detail[0].Contains('d')) // это папка
                    lvRemote.Items.Add(detail[detail.Length - 1], 1);
                else // это файл
                    lvRemote.Items.Add(detail[detail.Length - 1], 0);
            }

            ConnectionStatus.Established(lConnectionStatus); // обновление статуса об успешном подключении

            CurrentRemotePath = tbServer.Text; // обновление текущего серверного пути
            Server = tbServer.Text; // сохранение введённых данных
            Username = tbUsername.Text;
            Password = tbPassword.Text;

            bDownload.Enabled = true; // активация кнопок
            bUpload.Enabled = true;
            bNewRemoteFolder.Enabled = true;
            bNewRemoteFile.Enabled = true;
            bRemoteHome.Enabled = true;
            bRemoteRefresh.Enabled = true;
        }

        // Cбрасывает введённый в поля текст
        private void bReset_Click(object sender, EventArgs e)
        {
            tbServer.Text = string.Empty;
            tbUsername.Text = string.Empty;
            tbPassword.Text = string.Empty;
            lvRemote.Items.Clear();

            ConnectionStatus.None(lConnectionStatus);

            bDownload.Enabled = false; // деактивация кнопок скачивания и загрузки
            bUpload.Enabled = false;
            bNewRemoteFolder.Enabled = false;
            bNewRemoteFile.Enabled = false;
            bRemoteHome.Enabled = false;
            bRemoteRefresh.Enabled = false;
        }

        // Двойной щелчок по lvRemote, перемещение вниз по серверной папке
        private void lvRemote_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = lvRemote.SelectedItems[0];
            string selectedItemName = selectedItem.Text; // получение названия выбранной папки
            CurrentRemotePath += "/" + selectedItemName; // обновление текущего серверного пути вместе с выбранной папкой

            List<string[]>? details = FtpAdapter.ListDirectoryDetails(CurrentRemotePath, Username, Password);

            lvRemote.Items.Clear();
            foreach (var detail in details) // перенесение содержимого сервера в lvRemote
            {
                if (detail[0].Contains('d')) // это папка
                    lvRemote.Items.Add(detail[detail.Length - 1], 1);
                else // это файл
                    lvRemote.Items.Add(detail[detail.Length - 1], 0);
            }
        }

        // Перемещение вниз по локальной папке
        private void lvLocal_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = lvLocal.SelectedItems[0];
            string selectedItemName = selectedItem.Text; // получение названия выбранного элемента
            string selectedItemPath = CurrentLocalPath + "/" + selectedItemName;
            if (File.Exists(selectedItemPath)) // если выбран файл, а не директория, выход из метода
                return;

            CurrentLocalPath = selectedItemPath;
            lvLocal.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(CurrentLocalPath);
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                lvLocal.Items.Add(dirInfo.Name, 1);
            }
            foreach (FileInfo fileInfo in dir.GetFiles())
            {
                lvLocal.Items.Add(fileInfo.Name, 0);
            }
        }

        // Возвращение в домашнюю серверную папку
        private void bRemoteHome_Click(object sender, EventArgs e)
        {
            CurrentRemotePath = Server;

            List<string[]>? details = FtpAdapter.ListDirectoryDetails(CurrentRemotePath, Username, Password);

            lvRemote.Items.Clear();
            foreach (var detail in details) // перенесение содержимого сервера в lvRemote
            {
                if (detail[0].Contains('d')) // это папка
                    lvRemote.Items.Add(detail[detail.Length - 1], 1);
                else // это файл
                    lvRemote.Items.Add(detail[detail.Length - 1], 0);
            }
        }

        // Возвращение в домашнюю локальную папку
        private void bLocalHome_Click(object sender, EventArgs e)
        {
            lvLocal.Items.Clear();
            CurrentLocalPath = @"C:/";

            DirectoryInfo dir = new DirectoryInfo(CurrentLocalPath);
            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                lvLocal.Items.Add(dirInfo.Name, 1);
            }
            foreach (FileInfo fileInfo in dir.GetFiles())
            {
                lvLocal.Items.Add(fileInfo.Name, 0);
            }
        }

        // Скачивание файла с сервера на компьютер
        private void bDownload_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = lvRemote.SelectedItems[0];
                string selectedItemName = selectedItem.Text;
                string sourcePath = CurrentRemotePath + "/" + selectedItemName;
                string destinationPath = CurrentLocalPath + "/" + selectedItemName;

                bool isDownloaded = FtpAdapter.DownloadFile(sourcePath, destinationPath, Username, Password);
                if (isDownloaded)
                {
                    LocalDirectoryDetails(CurrentLocalPath); // обновление lvLocal
                    SystemSounds.Asterisk.Play(); // звук об успешной операции
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nВозможно ничего не было выбрано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка файла с компьютера на сервер
        private void bUpload_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = lvLocal.SelectedItems[0];
                string selectedItemName = selectedItem.Text;
                string uploadableFilePath = CurrentLocalPath + "/" + selectedItemName;
                string destinationFilePath = CurrentRemotePath + "/" + selectedItemName;

                bool isUploded = FtpAdapter.UploadFile(uploadableFilePath, destinationFilePath, Username, Password);
                if (isUploded)
                {
                    List<string[]>? details = FtpAdapter.ListDirectoryDetails(CurrentRemotePath, Username, Password);
                    lvRemote.Items.Clear();
                    foreach (var detail in details) // перенесение содержимого сервера в lvRemote
                    {
                        if (detail[0].Contains('d')) // это папка
                            lvRemote.Items.Add(detail[detail.Length - 1], 1);
                        else // это файл
                            lvRemote.Items.Add(detail[detail.Length - 1], 0);
                    }

                    SystemSounds.Asterisk.Play(); // звук об успешной операции
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nВозможно ничего не было выбрано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Перенесение содержимого локальной папки в lvLocal
        private void LocalDirectoryDetails(string path)
        {
            lvLocal.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (DirectoryInfo dirInfo in dir.GetDirectories()) // сначала папки
            {
                lvLocal.Items.Add(dirInfo.Name, 1);
            }
            foreach (FileInfo fileInfo in dir.GetFiles()) // потом файлы
            {
                lvLocal.Items.Add(fileInfo.Name, 0);
            }
        }

        // Обновление lvRemote
        private void bRemoteRefresh_Click(object sender, EventArgs e)
        {
            List<string[]>? details = FtpAdapter.ListDirectoryDetails(CurrentRemotePath, Username, Password);

            lvRemote.Items.Clear();
            foreach (var detail in details) // перенесение содержимого сервера в lvRemote
            {
                if (detail[0].Contains('d')) // это папка
                    lvRemote.Items.Add(detail[detail.Length - 1], 1);
                else // это файл
                    lvRemote.Items.Add(detail[detail.Length - 1], 0);
            }
        }

        // Добавление новой пустой папки на сервер
        private void bNewRemoteFolder_Click(object sender, EventArgs e)
        {
            string? addedDirectoryName = FtpAdapter.NewDirectory(CurrentRemotePath, "NewDirectory", Username, Password);
            if (addedDirectoryName != null)
            {
                // обновление данных
                List<string[]>? details = FtpAdapter.ListDirectoryDetails(CurrentRemotePath, Username, Password);
                lvRemote.Items.Clear();
                foreach (var detail in details) // перенесение содержимого сервера в lvRemote
                {
                    if (detail[0].Contains('d')) // это папка
                        lvRemote.Items.Add(detail[detail.Length - 1], 1);
                    else // это файл
                        lvRemote.Items.Add(detail[detail.Length - 1], 0);
                }

                // выделение добавленного элемента
                foreach (ListViewItem item in lvRemote.Items)
                {
                    lvRemote.Items[item.Index].Selected = false;
                    if (item.Text.Equals(addedDirectoryName))
                        lvRemote.Items[item.Index].Selected = true;
                }
            }
        }

        // Добавление нового пустого файла на сервер
        private void bNewRemoteFile_Click(object sender, EventArgs e)
        {
            string? addedFileName = FtpAdapter.NewFile(CurrentRemotePath, new Tuple<string, string>("NewFile", ".txt"), Username, Password);
            if (addedFileName != null)
            {
                // обновление данных
                List<string[]>? details = FtpAdapter.ListDirectoryDetails(CurrentRemotePath, Username, Password);
                lvRemote.Items.Clear();
                foreach (var detail in details) // перенесение содержимого сервера в lvRemote
                {
                    if (detail[0].Contains('d')) // это папка
                        lvRemote.Items.Add(detail[detail.Length - 1], 1);
                    else // это файл
                        lvRemote.Items.Add(detail[detail.Length - 1], 0);
                }

                // выделение добавленного элемента
                foreach (ListViewItem item in lvRemote.Items)
                {
                    lvRemote.Items[item.Index].Selected = false;
                    if (item.Text.Equals(addedFileName))
                        lvRemote.Items[item.Index].Selected = true;
                }
            }
        }

        // Обновление lvLocal
        private void bLocalRefresh_Click(object sender, EventArgs e)
        {
            LocalDirectoryDetails(CurrentLocalPath);
        }

        private void DefineTabOrder()
        {
            tbServer.TabIndex = 0;
            tbUsername.TabIndex = 1;
            tbPassword.TabIndex = 2;
            bConnect.TabIndex = 3;
            bReset.TabIndex = 4;
        }
    }
}
