using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBracket.Games.TowerDefense
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                StartGame();
            });
        }

        private List<Enemy> enemyList = new List<Enemy>();
        private void StartGame()
        {
            var loop = 0;
            while (true)
            {
                if (Application.Current is null || loop == 10)
                    break;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var enemy = SpawnEnemy();
                    enemy.AnimationCompleted += new Enemy.AnimationCompletedHandler(() =>
                    {
                        GameCanvas.Children.Remove(enemy);
                        //enemyList.Remove(enemy);
                    });
                    enemyList.Add(enemy);
                    GameCanvas.Children.Add(enemy);
                    enemy.Animate(Canvas.GetTop(Target), Canvas.GetLeft(Target));

                });
                Task.Delay(500).Wait();
                loop++;
            }
        }

        private Enemy SpawnEnemy()
        {
            var enemy = new Enemy();

            Canvas.SetTop(enemy, Canvas.GetTop(Spawner));
            Canvas.SetLeft(enemy, Canvas.GetLeft(Spawner));

            return enemy;
        }
    }

    public class Enemy : Control
    {


        public void Animate(double top, double left)
        {
            var leftAnimation = new DoubleAnimation(left, new TimeSpan(0, 0, 0, 0, 2000));
            leftAnimation.Completed += HandleAnimationCompleted;
            BeginAnimation(Canvas.LeftProperty, leftAnimation);

            var topAnimation = new DoubleAnimation(top, new TimeSpan(0, 0, 0, 0, 2000));
            topAnimation.Completed += HandleAnimationCompleted;
            BeginAnimation(Canvas.TopProperty, topAnimation);
        }

        private void HandleAnimationCompleted(object? sender, EventArgs e)
        {
            AnimationCompleted?.Invoke();
        }


        public event AnimationCompletedHandler AnimationCompleted;
        public delegate void AnimationCompletedHandler();
    }
}