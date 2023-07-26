using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleQuestionApp.Pages
{
    public partial class QuestionPage : UserControl
    {
        public event Action YesButtonPressed;

        private static readonly Random random = new Random();
        public QuestionPage()
        {
            InitializeComponent();
        }

        private void ButtonsGrid_MouseMove(object sender, MouseEventArgs e)
        {
            Random rand = new Random();

            Point cursorPosition = e.GetPosition(buttonsGrid);

            Rect noButtonRect = new Rect(noButton.Margin.Left, noButton.Margin.Top, noButton.ActualWidth, noButton.ActualHeight);
            noButtonRect.Inflate(50, 50);

            if (!noButtonRect.Contains(cursorPosition))
            {
                return;
            }

            Point proposedCoordinates;

            bool isOverlapping = false;
            do
            {
                isOverlapping = false;

                Rect yesButtonBounds = new Rect(yesButton.Margin.Left, yesButton.Margin.Top, yesButton.ActualWidth, yesButton.ActualHeight);
                yesButtonBounds.Inflate(10, 10);

                int maxLeftMargin = Convert.ToInt32(buttonsGrid.ActualWidth - noButton.ActualWidth - 20);
                int maxTopMargin = Convert.ToInt32(buttonsGrid.ActualHeight - noButton.ActualHeight - 20);

                double newX = rand.Next(20, maxLeftMargin);
                double newY = rand.Next(20, maxTopMargin);

                proposedCoordinates = new Point(newX, newY);

                Rect proposedButtonRect = new Rect(proposedCoordinates, noButton.RenderSize);

                bool overlappingYesButton = proposedButtonRect.IntersectsWith(yesButtonBounds);
                bool overlappingCursor = proposedButtonRect.Contains(cursorPosition);

                if (overlappingYesButton || overlappingCursor)
                {
                    isOverlapping = true;
                    continue;
                }

            } while (isOverlapping);

            noButton.Margin = new Thickness(proposedCoordinates.X, proposedCoordinates.Y, 0, 0);
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            YesButtonPressed?.Invoke();
        }
    }
}
