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
                // добавление файла с названием, которого нет
                // если такое название уже найдено, то к нему прибавляется номер копии
                string initialName = fileName.Item1;
                int copyNumber = 1;
                List<string[]>? details = ListDirectoryDetails(path, username, password);
                foreach (var detail in details)
                {
                    while (detail[detail.Length - 1] == fileName.Item1 + fileName.Item2 && // пока в папке есть файл с этим названием
                        !detail[0].Contains('d'))
                    {
                        fileName = new Tuple<string, string>(initialName + copyNumber, fileName.Item2); // добавить цифру к названию файла
                        copyNumber += 1; // и увеличить добавляемую цифру для следующей итерации, если и этот файл будет найден
                    }
                }
                string finalName = fileName.Item1 + fileName.Item2;
                string finalPath = path + "/" + finalName;

                // создание файла
                FtpWebRequest fileRequest = (FtpWebRequest)WebRequest.Create(new Uri(finalPath));
                fileRequest.Method = WebRequestMethods.Ftp.UploadFile;
                fileRequest.Credentials = new NetworkCredential(username, password);
                
                FtpWebResponse response = (FtpWebResponse)fileRequest.GetResponse();
                response.Close();

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
                // добавление папки с названием, которого нет
                // если такое название уже найдено, то к нему прибавляется номер копии
                string initialName = directoryName;
                int copyNumber = 1;
                List<string[]>? details = ListDirectoryDetails(path, username, password);
                foreach (var detail in details)
                {
                    while (detail[detail.Length - 1] == directoryName && // пока в папке есть папка с этим названием
                        detail[0].Contains('d'))
                    {
                        directoryName = initialName + copyNumber; // добавить цифру к названию папки
                        copyNumber += 1; // и увеличить добавляемую цифру для следующей итерации, если и этот файл будет найден
                    }
                }
                string finalPath = path + "/" + directoryName;

                // создание папки
                FtpWebRequest directoryRequest = (FtpWebRequest)WebRequest.Create(new Uri(finalPath));
                directoryRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                directoryRequest.Credentials = new NetworkCredential(username, password);

                FtpWebResponse response = (FtpWebResponse)directoryRequest.GetResponse();
                response.Close();

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
