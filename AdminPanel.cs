using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testplatformu2
{
    public class AdminPanel
    {
        private AdminController adminController = new AdminController();

        // Başlangıç ve giriş işlemi
        public void Start()
        {
            if (Login())
            {
                ShowPanel();
            }
            else
            {
                Console.WriteLine("Giriş başarısız.");
            }
        }

        private bool Login()
        {
            Console.Write("Admin adı: ");
            string name = Console.ReadLine();
            Console.Write("Şifre: ");
            string password = Console.ReadLine();
            return adminController.Login(name, password);
        }

        // Admin paneli seçenekleri
        private void ShowPanel()
        {
            while (true)
            {
                Console.WriteLine("\n1. Öğrenci Ekle\n2. Kategori Ekle\n3. Soru Ekle\n4. Sınav Yap\n5. Çıkış");
                Console.Write("Bir seçenek seçin: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddCategory();
                        break;
                    case "3":
                        AddQuestion();
                        break;
                    case "4":
                        ConductExam();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçenek.");
                        break;
                }
            }
        }

        // Öğrenci ekleme
        private void AddStudent()
        {
            Console.Write("Ad: ");
            string name = Console.ReadLine();
            Console.Write("Soyad: ");
            string surname = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Şifre: ");
            string password = Console.ReadLine();
            adminController.AddStudent(name, surname, email, password);
        }

        // Kategori ekleme
        private void AddCategory()
        {
            Console.Write("Kategori Adı: ");
            string categoryName = Console.ReadLine();
            adminController.AddCategory(categoryName);
        }

        // Soru ekleme
        private void AddQuestion()
        {
            Console.Write("Soru metni: ");
            string questionText = Console.ReadLine();
            Console.Write("Doğru Cevap: ");
            string correctAnswer = Console.ReadLine();
            adminController.AddQuestion(questionText, correctAnswer);
        }
        string correctAnswer = "programlama dilidir";
        // Sınav yapma işlemi
        private void ConductExam()
        {
            List<Question> questions = adminController.GetQuestions();
            List<string> studentAnswers = new List<string>();

            Console.WriteLine("\nSınav Başladı:");
            foreach (var question in questions)
            {
                Console.WriteLine(question.Text);
                Console.Write("Cevap: ");
                string answer = Console.ReadLine();
                studentAnswers.Add(answer);
            }

            int score = adminController.ConductExam(studentAnswers);
            adminController.ShowExamResult(score);
        }
    }

}
