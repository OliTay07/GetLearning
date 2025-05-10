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

    // Represents a single question with its answer and whether it's been correctly answered
    public class Question : INotifyPropertyChanged
    {

        // Question prompt
        public string Text { get; set; }
        // Correct answer to the question
        public string Answer { get; set; }

        private string _userInput;

        // User's input for the question
        public string UserInput
        {
            get => _userInput;
            set
            {
                _userInput = value;
                OnPropertyChanged(nameof(UserInput));
            }
        }

        // Feedback to the user after submitting an answer
        private string _feedback;
        public string Feedback
        {
            get => _feedback;
            set
            {
                _feedback = value;
                OnPropertyChanged(nameof(Feedback));
            }
        }

        private bool _isAnsweredCorrectly;

        // Indicates if the question has been answered correctly
        public bool IsAnsweredCorrectly
        {
            get { return _isAnsweredCorrectly; }
            set
            {
                _isAnsweredCorrectly = value;
                OnPropertyChanged("IsAnsweredCorrectly");
            }
        }

        // Event needed to update UI when property changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // ViewModel connects the data (the questions) to the UI
    public class ThemeOneViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; set; }
        public ICommand SubmitAnswerCommand { get; private set; }

        public ThemeOneViewModel()
        {
            // Adds the questions
            Questions = new ObservableCollection<Question>
            {
                // Theme 1 questions & answers
                new Question { Text = "What is the formula for Market Share (%)?", Answer = "sales of one product / total market sales x 100" },
                new Question { Text = "What is the formula for Market Growth (%)?", Answer = "change in market size / original market size x 100" },
                new Question { Text = "What is the formula for Revenue?", Answer = "price x quantity" },
                new Question { Text = "What is the formula for Profit?", Answer = "total revenue - total costs" },
                new Question { Text = "What is the formula for Price Elasticity of Demand (PED)?", Answer = "% change in quantity demanded / % change in price" },
                new Question { Text = "What is the formula for Price Income Elasticity of Demand (YED)?", Answer = "% change in quantity demanded / % change in icnome" }

            };

            // Hook up the command with the method to check answers
            SubmitAnswerCommand = new RelayCommand(SubmitAnswer);
        }


        //Runs when a user submits an answer
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

