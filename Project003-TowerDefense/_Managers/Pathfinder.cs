namespace Project003;

public class Pathfinder
{
    class Node
    {
        public int x;
        public int y;
        public Node parent;
        public bool visited;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    private Node[,] _nodeMap;
    private Map _map;
    private readonly int[] row = { 0, -1, 1, 0, };
    private readonly int[] col = { 1, 0, 0, -1, };

    public Pathfinder(Map map)
    {
        _map = map;
    }

    private (int x, int y) ScreenToMap(Vector2 pos)
    {
        return _map.ScreenToMap(pos);
    }

    private bool IsValid(int x, int y)
    {
        return x >= 0 && x < _nodeMap.GetLength(0) && y >= 0 && y < _nodeMap.GetLength(1);
    }

    private void CreateNodeMap()
    {
        _nodeMap = new Node[Map.SIZE_X, Map.SIZE_Y];

        for (int i = 0; i < Map.SIZE_X; i++)
        {
            for (int j = 0; j < Map.SIZE_Y; j++)
            {
                _nodeMap[i, j] = new(i, j);
                if (_map.MapTiles[i, j].Blocked) _nodeMap[i, j].visited = true;
            }
        }
    }

    public List<Vector2> BFSearch(Vector2 start, Point goal)
    {
        CreateNodeMap();
        Queue<Node> q = new();

        (int startX, int startY) = ScreenToMap(start);

        var startNode = _nodeMap[startX, startY];
        startNode.visited = true;
        q.Enqueue(startNode);

        while (q.Count > 0)
        {
            Node curr = q.Dequeue();

            if (curr.x == goal.X && curr.y == goal.Y)
            {
                return RetracePath(goal.X, goal.Y);
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

    private List<Vector2> RetracePath(int goalX, int goalY)
    {
        Stack<Vector2> stack = new();
        List<Vector2> result = new();
        Node curr = _nodeMap[goalX, goalY];

        while (curr is not null)
        {
            stack.Push(_map.MapTiles[curr.x, curr.y].Position);
            curr = curr.parent;
        }

        while (stack.Count > 0) result.Add(stack.Pop());

        return result;
    }
}
