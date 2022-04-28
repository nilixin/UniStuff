namespace PKS2
{
    public static class Status
    {
        public static void NeedsAuthorization(Label label)
        {
            label.ForeColor = Color.Red;
            label.Text = "Сначала авторизуйтесь.";
        }

        public static void Authorized(Label label, string email)
        {
            label.ForeColor = Color.Green;
            label.Text = $"Авторизовано {email}";
        }
    }
}
