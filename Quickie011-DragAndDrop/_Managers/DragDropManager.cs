namespace Quickie011;

public static class DragDropManager
{
    private static readonly List<IDraggable> _draggables = new();
    private static readonly List<ITargetable> _targets = new();
    private static IDraggable _dragItem;

    public static void AddDraggable(IDraggable item)
    {
        _draggables.Add(item);
    }

    public static void AddTarget(ITargetable item)
    {
        _targets.Add(item);
    }

    private static void CheckDragStart()
    {
        if (InputManager.MouseClicked)
        {
            foreach (var item in _draggables)
            {
                if (item.Rectangle.Contains(InputManager.MousePosition))
                {
                    _dragItem = item;
                    break;
                }
            }
        }
    }

    private static void CheckTarget()
    {
        foreach (var item in _targets)
        {
            if (item.Rectangle.Contains(InputManager.MousePosition))
            {
                _dragItem.Position = item.Position;
                break;
            }
        }
    }

    private static void CheckDragStop()
    {
        if (InputManager.MouseReleased)
        {
            CheckTarget();
            _dragItem = null;
        }
    }

    public static void Update()
    {
        CheckDragStart();

        if (_dragItem is not null)
        {
            _dragItem.Position = InputManager.MousePosition;
            CheckDragStop();
        }
    }
}
