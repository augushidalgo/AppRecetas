using AppRecetas.Views;

namespace AppRecetas
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TodoRecetaPage), typeof(TodoRecetaPage));
        }
    }
}
