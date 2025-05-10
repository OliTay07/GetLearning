using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GetLearning
{
    // ViewModel for Theme 3 Questions
    public class ThemeThreeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; set; }
        public ICommand SubmitAnswerCommand { get; private set; }

        public ThemeThreeViewModel()
        {
            // Questions and answers for theme 3
            Questions = new ObservableCollection<Question>
            {
                new Question { Text = "What is the formula for Customer Lifetime Value (CLV)?", Answer = "(Average Purchase Value x Purchase Frequency) x Customer Lifespan" },
                new Question { Text = "What is the formula for Return on Assets (ROA)?", Answer = "Net Income / Total Assets" },
                new Question { Text = "What is the formula for Debt to Equity Ratio?", Answer = "Total Liabilities / Total Shareholders' Equity" },
                new Question { Text = "What is the formula for Earnings Before Interest and Taxes (EBIT)?", Answer = "Revenue - Operating Expenses" },
                new Question { Text = "What is the formula for Contribution Margin?", Answer = "Sales Revenue - Variable Costs" }
            };

            // Hook up the command with the method to check answers
            SubmitAnswerCommand = new RelayCommand(SubmitAnswer);
        }

        // Runs when a user submits an answer
        private void SubmitAnswer(object parameter)
        {
            if (parameter is Question question)
            {
                // Check if the inputted text matches the answer
                if (question.UserInput?.Trim().ToLower() == question.Answer.ToLower())
                {
                    // If correct display that the answer is correcy
                    question.Feedback = "Correct!";
                }

                // If inputted text is incorrect display the correct answer
                else
                {
                    question.Feedback = $"Wrong answer! Correct: {question.Answer}";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

