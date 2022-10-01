using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CourseHw2;

public partial class MainPage : ContentPage
{
	public int Count { get; set; }

	public MainPage()
	{
		InitializeComponent();
	}

	void ShowScore(object sender, int score)
	{
		DisplayAlert("游戏结束", $"你的得分是 {score}", "OK");
	}

	private void OnSwiped(object sender, SwipedEventArgs e)
	{
		var vm = (PuzzleViewModel)BindingContext;
		switch (e.Direction)
		{
			case SwipeDirection.Up: vm.MoveCommand.Execute(0); break;
            case SwipeDirection.Left: vm.MoveCommand.Execute(1); break;
            case SwipeDirection.Right: vm.MoveCommand.Execute(2); break;
            case SwipeDirection.Down: vm.MoveCommand.Execute(3); break;
		}
    }
}

