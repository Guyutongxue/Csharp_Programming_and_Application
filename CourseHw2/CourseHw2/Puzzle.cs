namespace CourseHw2;

class Puzzle
{

    int[,] tiles = new int[4, 4];

    public int this[int i, int j]
    {
        get => tiles[i, j];
    }

    public int Score { get; private set; } = 0;

    public bool Over
    {
        get => tiles.Cast<int>().All(x => x > 0) && !HasMatch();
    }

    public void Restore()
    {
        tiles = new int[4, 4];
        Score = 0;
        InsertTile();
        InsertTile();
    }

    private static readonly int[] dx = new[] { -1, 0, 0, 1 };
    private static readonly int[] dy = new[] { 0, -1, 1, 0 };

    private static (int, int)? MoveTile(int x, int y, int dir)
    {
        x += dx[dir];
        y += dy[dir];
        if (x < 0 || y < 0 || x > 3 || y > 3) return null;
        return (x, y);
    }

    private static (List<int>, List<int>) Traversals(int dir)
    {
        return dir switch
        {
            2 => (new List<int> { 0, 1, 2, 3 }, new List<int> { 3, 2, 1, 0 }),
            3 => (new List<int> { 3, 2, 1, 0 }, new List<int> { 0, 1, 2, 3 }),
            _ => (new List<int> { 0, 1, 2, 3 }, new List<int> { 0, 1, 2, 3 }),
        };
    }

    private bool HasMatch()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int d = 0; d < 4; d++)
                {
                    if (MoveTile(i, j, d) is (int ni, int nj) && this[i, j] == this[ni, nj])
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    readonly Random random = new(new Guid().GetHashCode());

    private void InsertTile()
    {
        var available = new List<(int, int)>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (this[i, j] == 0) available.Add((i, j));
            }
        }
        var val = random.NextDouble() < 0.9 ? 1 : 2;
        var target = available[random.Next(available.Count)];
        tiles[target.Item1, target.Item2] = val;
    }

    public void Move(int direction)
    {
        if (Over) return;
        var oldPosition = ((int[,])tiles.Clone()).Cast<int>();
        var mergedFrom = new bool[4, 4];
        var (xs, ys) = Traversals(direction);
        foreach (var i in xs)
        {
            foreach (var j in ys)
            {
                if (this[i, j] == 0) continue;
                if (MoveTile(i, j, direction) is (int ni, int nj))
                {
                    if (this[ni, nj] == this[i, j] && !mergedFrom[ni, nj])
                    {
                        // merge
                        tiles[i, j] = 0;
                        tiles[ni, nj]++;
                        Score += 1 << tiles[ni, nj];
                        mergedFrom[ni, nj] = true;
                    }
                    else
                    {
                        // move-to-furthest
                        var (pi, pj) = (i, j);
                        while (MoveTile(pi, pj, direction) is (int ti, int tj) && tiles[ti, tj] == 0)
                        {
                            (pi, pj) = (ti, tj);
                        }
                        tiles[pi, pj] = tiles[i, j];
                        if (pi != i || pj != j) tiles[i, j] = 0;
                    }
                }
            }
        }
        if (!Enumerable.SequenceEqual(tiles.Cast<int>(), oldPosition))
        {
            InsertTile();
        }
    }

    public Puzzle()
    {
        Restore();
    }

}

