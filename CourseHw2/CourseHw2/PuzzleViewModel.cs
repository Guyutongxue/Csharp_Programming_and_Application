using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CourseHw2;

class Tile
{
    static readonly (int, int, int)[] BackgroundColorMap = new[]
    {
        (205, 193, 180),
        (238, 228, 218), // 2
        (237, 224, 200), // 4
        (242, 177, 121), // 8
        (245, 149, 99), // 16
        (246, 124, 95), // 32
        (246, 94, 59), // 64
        (237, 207, 114), // 128
        (237, 204, 97), // 256
        (237, 200, 89), // 512
        (237, 197, 63), // 1024
        (237, 194, 46), // 2048
        (208, 191, 42),
        (169, 188, 37),
        (98, 181, 28),
    };
    static readonly (int, int, int) SuperBackgroundColor = (69, 197, 24);

    public string Text { get; }
    public Color TextColor { get; }
    public Color BackgroundColor { get; }
    public int FontSize { get; }

    public Tile(int power)
    {
        Text = power == 0 ? "" : $"{1 << power}";
        var bgRgb = power >= BackgroundColorMap.Length ? SuperBackgroundColor : BackgroundColorMap[power];
        BackgroundColor = new Color(bgRgb.Item1, bgRgb.Item2, bgRgb.Item3);
        TextColor = power < 3 ? new Color(119, 110, 101) : new Color(249, 246, 242);
        FontSize = 15 + 35 / (1 + (int)Math.Log10(1 << power));
    }
}

class PuzzleViewModel : INotifyPropertyChanged
{
    public delegate void PuzzleOverHandler(object sender, int score);

    public event PropertyChangedEventHandler PropertyChanged;
    public event PuzzleOverHandler PuzzleOvered;
    private void OnPropertyChanged()
    {

        var invoke = (string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        invoke("Tiles");
        invoke("Score");
    }

    Puzzle puzzle = new();

    public ICommand RestoreCommand { get; }
    public ICommand MoveCommand { get; }

    public List<List<Tile>> Tiles
    {
        get
        {
            var result = new List<List<Tile>>();
            for (int i = 0; i < 4; i++)
            {
                var row = new List<Tile>();
                for (int j = 0; j < 4; j++)
                {
                    var val = puzzle[i, j];
                    row.Add(new Tile(val));
                }
                result.Add(row);
            }
            return result;
        }
    }

    public int Score { get => puzzle.Score; }

    public PuzzleViewModel()
    {
        RestoreCommand = new Command(() =>
        {
            puzzle.Restore();
            OnPropertyChanged();
        });
        MoveCommand = new Command((param) =>
        {
            puzzle.Move((int)param);
            OnPropertyChanged();
            if (puzzle.Over)
            {
                PuzzleOvered(this, puzzle.Score);
            }
        });
    }

}