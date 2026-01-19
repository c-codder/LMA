namespace LMA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnGreetClicked(object? sender, EventArgs e)
        {
            string userName = NameEntry.Text ?? "Guest";
            GreetingLabel.Text = $"Hello {userName}";
        }
    }
}
