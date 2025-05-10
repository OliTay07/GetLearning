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
    // ViewModel for Theme 2 Questions
    public class ThemeTwoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; set; }
        public ICommand SubmitAnswerCommand { get; private set; }

        public ThemeTwoViewModel()
        {
            // Adds the questions for Theme 2
            Questions = new ObservableCollection<Question>
            {
                new Question { Text = "What is the formula for Return on Investment (ROI)?", Answer = "(Net Profit / Cost of Investment) x 100" },
                new Question { Text = "What is the formula for Break-even Point?", Answer = "Fixed Costs / (Selling Price per Unit - Variable Cost per Unit)" },
                new Question { Text = "What is the formula for Gross Profit?", Answer = "Revenue - Cost of Goods Sold" },
                new Question { Text = "What is the formula for Operating Profit?", Answer = "Gross Profit - Operating Expenses" },
                new Question { Text = "What is the formula for Net Profit?", Answer = "Operating Profit - Taxes and Interest" }
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

