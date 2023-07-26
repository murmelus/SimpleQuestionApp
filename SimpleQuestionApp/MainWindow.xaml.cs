using SimpleQuestionApp.Pages;
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

namespace SimpleQuestionApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            QuestionPage questionPage = new QuestionPage();

            questionPage.YesButtonPressed += switchToCongratulations;

            pageElementContainer.Children.Add(questionPage);
        }

        private void switchToCongratulations()
        {
            pageElementContainer.Children.Clear();

            CongratulationsPage congratulationsPage = new CongratulationsPage();

            pageElementContainer.Children.Add(congratulationsPage);
        }
    }
}
