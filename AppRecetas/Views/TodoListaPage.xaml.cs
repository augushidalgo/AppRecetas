using AppRecetas.Data;
using AppRecetas.Models;
using System.Collections.ObjectModel;

namespace AppRecetas.Views;

public partial class TodoListaPage : ContentPage
{
	TodoItemBaseDatos basedatos;
	// Inicializamos un objeto colecci�n de la clase Recetas
    public ObservableCollection<Recetas> Items { get; set; } = new();
	public TodoListaPage(TodoItemBaseDatos todoItemBaseDatos)
	{
		InitializeComponent();
        // Con la inyecci�n de dependencias instanciamos un objeto de la clase TodoItemBaseDatos
        basedatos = todoItemBaseDatos;
        // Indicamos el Binding de la p�gina XAML
        BindingContext = this;
	}

    // Sobreescribimos el m�todo que se ejecuta al momento de cargar la p�gina
    // para obtener todas las recetas de la tabla Recetas
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await basedatos.GetRecetasAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);

        });
    }
    async void OnAgregarReceta(object sender, EventArgs e)
    {
        // Llamado a la p�gina para agregar una receta
        await Shell.Current.GoToAsync(nameof(TodoRecetaPage), true, new Dictionary<string, object>
        {
            ["Item"] = new Recetas()
        });
    }
    private async void ColeccionRecetas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Recetas item)
            return;

        await Shell.Current.GoToAsync(nameof(TodoRecetaPage), true, new Dictionary<string, object>
        {
            ["Item"] = item
        });
    }
}