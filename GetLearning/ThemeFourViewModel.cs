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
    // ViewModel for Theme 4 Questions
    public class ThemeFourViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; set; }
        public ICommand SubmitAnswerCommand { get; private set; }

        public ThemeFourViewModel()
        {
            // Theme 4 questions and answers
            Questions = new ObservableCollection<Question>
            {
                new Question { Text = "What is the formula for Break-even Point?", Answer = "Fixed Costs / (Selling Price per Unit - Variable Cost per Unit)" },
                new Question { Text = "What is the formula for Return on Investment (ROI)?", Answer = "Net Profit / Cost of Investment" },
                new Question { Text = "What is the formula for Market Capitalization?", Answer = "Stock Price x Total Shares Outstanding" },
                new Question { Text = "What is the formula for Gross Profit Margin?", Answer = "Gross Profit / Revenue x 100" },
                new Question { Text = "What is the formula for Operating Profit Margin?", Answer = "Operating Profit / Revenue x 100" },
                new Question { Text = "What is the formula for Asset Turnover?", Answer = "Revenue / Average Total Assets" }
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

