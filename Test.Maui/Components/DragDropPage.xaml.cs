namespace Test.Maui.Components;

public partial class DragDropPage : ContentView
{
    public DragDropPage()
    {
        InitializeComponent();
    }
    private void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        if (sender is DragGestureRecognizer gesture && gesture.Parent is Border draggableBorder)
        {
            e.Data.Properties.Add("DraggedItem", draggableBorder);
        }
    }

    private void OnDrop(object sender, DropEventArgs e)
    {
        if (e.Data.Properties.TryGetValue("DraggedItem", out var draggedItem))
        {
            if (draggedItem is Border draggedFrame)
            {
                var dropZone = (sender as DropGestureRecognizer)?.Parent as VerticalStackLayout;

                if (dropZone != null)
                {
                    if (draggedFrame.Parent is Layout oldParent)
                    {
                        oldParent.Children.Remove(draggedFrame);
                    }
                    dropZone.Children.Add(draggedFrame); 
                }
            }
        }
        else
        {
            Console.WriteLine("DraggedItem not found in Data.Properties.");
        }
    }
}