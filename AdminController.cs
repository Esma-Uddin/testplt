using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testplatformu2
{
    public class AdminController
    {
        private string adminName = "Esma";
        private string adminPassword = "esma123";
        private List<Student> students = new List<Student>();
        private List<Category> categories = new List<Category>();
        private List<Question> questions = new List<Question>();
        private Random random = new Random();

        
        public bool Login(string name, string password)
        {
            return name == adminName && password == adminPassword;
        }

        
        public void AddStudent(string name, string surname, string email, string password)
        {
            students.Add(new Student { Name = name, Surname = surname, Email = email, Password = password });
            Console.WriteLine("Yeni öğrenci eklendi: " + name + " " + surname);
        }

        
        public void AddCategory(string categoryName)
        {
            categories.Add(new Category { Id = categories.Count + 1, CategoryName = categoryName });
            Console.WriteLine("Yeni kategori eklendi: " + categoryName);
        }

        
        public void AddQuestion(string text, string correctAnswer)
        {
            int randomIndex = random.Next(categories.Count);
            string randomCategory = categories[randomIndex].CategoryName;
            questions.Add(new Question { Text = text, Category = randomCategory, CorrectAnswer = correctAnswer });
            Console.WriteLine($"Yeni soru eklendi: {text} (Kategori: {randomCategory})");
        }

        
        public int ConductExam(List<string> studentAnswers)
        {
            int score = 0;
            for (int i = 0; i < questions.Count && i < studentAnswers.Count; i++)
            {
                if (questions[i].CorrectAnswer == studentAnswers[i]) score++;
            }
            return score;
        }

       
        public void ShowExamResult(int score)
        {
            Console.WriteLine($"Sınav Sonucu: {score} / {questions.Count} doğru cevap");
        }

        
        public List<Question> GetQuestions()
        {
            return questions;
        }
    }



}
