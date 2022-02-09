using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace v2
{
    public static class FtpAdapter
    {
        // Возвращает список массивов с метаданными файлов указанной директории на сервере
        // Используется для получения названия файлов и папок, а так же для уточнения файл это или папка
        public static List<string[]>? ListDirectoryDetails(string requestUriString, string username, string password)
        {
            try
            {
                FtpWebRequest detailsRequest = (FtpWebRequest)WebRequest.Create(requestUriString);
                detailsRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                detailsRequest.Credentials = new NetworkCredential(username, password);
                FtpWebResponse response = (FtpWebResponse)detailsRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();

                List<string[]> details = new List<string[]>();
                using (var reader = new StreamReader(responseStream))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        details.Add(line.Split(' '));
                    }
                }

                response.Close();
                responseStream.Close();

                return details;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nВозможно данные введены неправильно или такого пользователя не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Скачивание файла, перемещение файла из серверной папки в локальную папку
        // Возвращает, успешно ли выполнена операция
        public static bool DownloadFile(string sourcePath, string destinationPath, string username, string password)
        {
            try
            {
                FtpWebRequest downloadRequest = (FtpWebRequest)(WebRequest.Create(new Uri(sourcePath)));
                downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                downloadRequest.Credentials = new NetworkCredential(username, password);

                Stream responseStream = downloadRequest.GetResponse().GetResponseStream();
                FileStream fileStream = new FileStream(destinationPath, FileMode.Create);

                StreamReader reader = new StreamReader(responseStream);
                byte[] buffer = new byte[1024];
                int byteRead;
                do
                {
                    byteRead = responseStream.Read(buffer, 0, buffer.Length);
                } while (byteRead != 0);

                reader.Close();
                responseStream.Close();
                fileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nВозможно был выбран не файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Загрузка файла, перемещение файла из локальной папки в серверную папку
        // Возвращает, успешно ли выполнена операция
        public static bool UploadFile(string sourcePath, string destinationPath, string username, string password)
        {
            try
            {
                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(new Uri(destinationPath));
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                uploadRequest.Credentials = new NetworkCredential(username, password);

                Stream requestStream = uploadRequest.GetRequestStream();
                FileStream fileStream = File.OpenRead(sourcePath);

                byte[] buffer = new byte[1024];
                int byteRead;
                double read = 0;
                do
                {
                    byteRead = fileStream.Read(buffer, 0, buffer.Length);
                    requestStream.Write(buffer, 0, byteRead);
                    read += byteRead;
                } while (byteRead != 0);

                requestStream.Close();
                fileStream.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\nВозможно был выбран не файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string? NewFile(string path, Tuple<string, string> fileName, string username, string password)
        {
            try
            {
                string initialName = fileName.Item1;
                int copyNumber = 1;
                while (File.Exists(fileName.Item1 + fileName.Item2))
                {
                    fileName = new Tuple<string, string>(initialName + copyNumber, fileName.Item2);
                    copyNumber += 1;
                }
                string finalName = fileName.Item1 + fileName.Item2;

                FtpWebRequest newRequest = (FtpWebRequest)WebRequest.Create(new Uri(path + "/" + finalName));
                newRequest.Method = WebRequestMethods.Ftp.UploadFile;
                newRequest.Credentials = new NetworkCredential(username, password);

                Stream requestStream = newRequest.GetRequestStream();

                FileStream fileStream = File.Create(finalName);

                requestStream.Close();
                fileStream.Close();

                return finalName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static string? NewDirectory(string path, string directoryName, string username, string password)
        {
            try
            {
                string initialName = directoryName;
                int copyNumber = 1;
                while (Directory.Exists(directoryName))
                {
                    directoryName = initialName + copyNumber;
                    copyNumber += 1;
                }
                string fullName = path + "/" + directoryName;

                FtpWebRequest newRequest = (FtpWebRequest)WebRequest.Create(new Uri(fullName));
                newRequest.Method= WebRequestMethods.Ftp.MakeDirectory;
                newRequest.Credentials = new NetworkCredential(username,password);

                //Directory.CreateDirectory(directoryName);
                // TODO не работает добавление директорий. почему?

                return directoryName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
