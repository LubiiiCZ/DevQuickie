namespace Quickie011;

public interface IDraggable
{
    Rectangle Rectangle { get; }
    Vector2 Position { get; set; }

    void RegisterDraggable()
    {
        DragDropManager.AddDraggable(this);
    }
}
