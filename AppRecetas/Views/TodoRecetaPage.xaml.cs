using AppRecetas.Data;
using AppRecetas.Models;

namespace AppRecetas.Views;
[QueryProperty("Item", "Item")]
public partial class TodoRecetaPage : ContentPage
{
    Recetas item;
    public Recetas Item
    {
        get => BindingContext as Recetas;
        set => BindingContext = value;
    }
    TodoItemBaseDatos basedatos;
	public TodoRecetaPage(TodoItemBaseDatos todoItemBaseDatos)
	{
		InitializeComponent();
        basedatos = todoItemBaseDatos;
	}
    async void OnGuardar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Nombre))
        {
            await DisplayAlert("Nombre requerido", "Por favor ingrese un nomre para la receta.", "Ok");
            return;
        }

        await basedatos.SaveRecetaAsync(Item);
        await Shell.Current.GoToAsync("..");
    }
    async void OnEliminar_Clicked(object sender, EventArgs e)
    {
        if (Item.Id == 0)
        {
            return;
        }

        await basedatos.DeleteRecetaAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}