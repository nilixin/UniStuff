using System;
using MimeKit;

namespace PKS2
{
    public partial class Form3 : Form
    {
        public Form3(MimeKit.MimeMessage message)
        {
            InitializeComponent();

            try
            {
                tbSourceAddress.Text = message.From.ToString();
                tbSubject.Text = message.Subject;
                rtbBody.Text = message.Body.ToString();

                Text = message.From.ToString() + " " + message.Subject;
                // TODO правильно отображать текст
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось отобразить содержание письма\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
