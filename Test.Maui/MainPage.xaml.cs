using Test.Maui.Components;

namespace Test.Maui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnBlazorPageClicked(object sender, EventArgs e)
    {
        ContentArea.Content = new BlazorPage();
    }

    private void OnDragDropPageClicked(object sender, EventArgs e)
    {
        ContentArea.Content = new DragDropPage();
    }
}
