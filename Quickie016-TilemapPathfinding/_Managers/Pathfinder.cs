namespace Quickie016;

public static class Pathfinder
{
    class Node(int x, int y)
    {
        public int x = x;
        public int y = y;
        public Node parent;
        public bool visited;
    }

    private static Node[,] _nodeMap;
    private static Map _map;
    private static Hero _hero;
    private static readonly int[] row = [-1, 0, 0, 1];
    private static readonly int[] col = [0, -1, 1, 0];

    public static void Init(Map map, Hero hero)
    {
        _map = map;
        _hero = hero;
    }

    public static bool Ready()
    {
        return _hero.MoveDone;
    }

    public static (int x, int y) ScreenToMap(Vector2 pos)
    {
        return _map.ScreenToMap(pos);
    }

    private static bool IsValid(int x, int y)
    {
        return x >= 0 && x < _nodeMap.GetLength(0) && y >= 0 && y < _nodeMap.GetLength(1);
    }

    private static void CreateNodeMap()
    {
        _nodeMap = new Node[_map.Size.X, _map.Size.Y];

        for (int i = 0; i < _map.Size.X; i++)
        {
            for (int j = 0; j < _map.Size.Y; j++)
            {
                _map.Tiles[i, j].Path = false;
                _nodeMap[i, j] = new(i, j);
                if (_map.Tiles[i, j].Blocked) _nodeMap[i, j].visited = true;
            }
        }
    }

    public static List<Vector2> BFSearch(int goalX, int goalY)
    {
        CreateNodeMap();
        Queue<Node> q = new();

        (int startX, int startY) = ScreenToMap(_hero.Position);
        var start = _nodeMap[startX, startY];
        start.visited = true;
        q.Enqueue(start);

        while (q.Count > 0)
        {
            Node curr = q.Dequeue();

            if (curr.x == goalX && curr.y == goalY)
            {
                return RetracePath(goalX, goalY);
            }

            for (int i = 0; i < row.Length; i++)
            {
                int newX = curr.x + row[i];
                int newY = curr.y + col[i];

                if (IsValid(newX, newY) && !_nodeMap[newX, newY].visited)
                {
                    q.Enqueue(_nodeMap[newX, newY]);
                    _nodeMap[newX, newY].visited = true;
                    _nodeMap[newX, newY].parent = curr;
                }
            }
        }

        return null;
    }

    private static List<Vector2> RetracePath(int goalX, int goalY)
    {
        Stack<Vector2> stack = new();
        List<Vector2> result = [];
        Node curr = _nodeMap[goalX, goalY];

        while (curr is not null)
        {
            _map.Tiles[curr.x, curr.y].Path = true;
            stack.Push(_map.Tiles[curr.x, curr.y].Position);
            curr = curr.parent;
        }

        while (stack.Count > 0) result.Add(stack.Pop());

        _hero.SetPath(result);

        return result;
    }
}
