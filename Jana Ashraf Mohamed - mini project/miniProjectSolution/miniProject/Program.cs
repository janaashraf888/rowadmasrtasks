using System;
using System.Collections.Generic;
using System.IO;

namespace miniProject
{
    enum ExamMode { Starting, Queued, Finished }

    class Answer : ICloneable, IComparable<Answer>
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Answer(string text, bool isCorrect) { Text = text; IsCorrect = isCorrect; }
        public object Clone() { return new Answer(Text, IsCorrect); }
        public int CompareTo(Answer other) { return Text.CompareTo(other.Text); }
        public override string ToString() { return Text; }
        public override bool Equals(object obj) { return obj is Answer a && a.Text == Text && a.IsCorrect == IsCorrect; }
        public override int GetHashCode() { return HashCode.Combine(Text, IsCorrect); }
    }

    class AnswerList : List<Answer>, ICloneable
    {
        public object Clone()
        {
            var list = new AnswerList();
            foreach (var a in this) list.Add((Answer)a.Clone());
            return list;
        }
    }

    abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }

        protected Question(string header, string body, int marks, AnswerList answers)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = answers;
        }

        public abstract void Show();

        public object Clone()
        {
            var clone = (Question)this.MemberwiseClone();
            clone.Answers = (AnswerList)Answers.Clone();
            return clone;
        }

        public int CompareTo(Question other) { return Marks.CompareTo(other.Marks); }
        public override string ToString() { return $"{Header}-{Body} ({Marks})"; }
        public override bool Equals(object obj) { return obj is Question q && q.Header == Header && q.Body == Body; }
        public override int GetHashCode() { return HashCode.Combine(Header, Body); }
    }

    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks, bool correct)
        : base(header, body, marks, new AnswerList { new Answer("True", correct), new Answer("False", !correct) }) { }

        public override void Show()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            Console.WriteLine("1-True");
            Console.WriteLine("2-False");
        }
    }

    class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, int marks, AnswerList answers)
        : base(header, body, marks, answers) { }

        public override void Show()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine($"{i + 1}-{Answers[i]}");
        }
    }

    class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string header, string body, int marks, AnswerList answers)
        : base(header, body, marks, answers) { }

        public override void Show()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            for (int i = 0; i < Answers.Count; i++)
                Console.WriteLine($"{i + 1}-{Answers[i]}");
        }
    }

    class QuestionList<T> : List<T> where T : Question
    {
        string filePath;

        public QuestionList(string file) { filePath = file; }

        public new void Add(T q)
        {
            base.Add(q);
            using (StreamWriter sw = new StreamWriter(filePath, true))
                sw.WriteLine(q.ToString());
        }
    }

    class Subject
    {
        public string Name { get; set; }
        public Subject(string name) { Name = name; }
        public override string ToString() { return Name; }
    }

    class Student
    {
        public string Name { get; set; }
        public Student(string name) { Name = name; }
        public void OnExamStarted(object sender, EventArgs e)
        {
            Console.WriteLine($"Notification for {Name}: Exam Started");
        }
    }

    abstract class Exam<T> : ICloneable, IComparable<Exam<T>> where T : Question
    {
        public int Time { get; set; }
        public QuestionList<T> Questions { get; set; }
        public Dictionary<T, List<int>> QuestionAnswers { get; set; }
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }
        public event EventHandler ExamStarted;

        protected Exam(int time, QuestionList<T> questions, Subject subject)
        {
            Time = time;
            Questions = questions;
            Subject = subject;
            QuestionAnswers = new Dictionary<T, List<int>>();
            Mode = ExamMode.Queued;
        }

        public void Start()
        {
            Mode = ExamMode.Starting;
            ExamStarted?.Invoke(this, EventArgs.Empty);
        }

        protected void CollectAnswer(T q)
        {
            var list = new List<int>();

            while (true)
            {
                Console.WriteLine("Enter answer(s) separated by comma (numbers only):");
                string input = Console.ReadLine();
                bool allValid = true;
                list.Clear();

                foreach (var s in input.Split(','))
                {
                    if (int.TryParse(s.Trim(), out int val))
                    {
                        val--;
                        if (val >= 0 && val < q.Answers.Count)
                            list.Add(val);
                        else
                        {
                            Console.WriteLine($"Invalid choice '{val + 1}'. Please select between 1 and {q.Answers.Count}.");
                            allValid = false;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input '{s}'. Please enter numbers only.");
                        allValid = false;
                        break;
                    }
                }

                if (allValid) break;
            }

            QuestionAnswers[q] = list;
        }

        public abstract void ShowExam();

        public object Clone()
        {
            var clone = (Exam<T>)this.MemberwiseClone();
            clone.Questions = new QuestionList<T>(Guid.NewGuid().ToString());
            foreach (var q in Questions)
                clone.Questions.Add((T)q.Clone());
            clone.QuestionAnswers = new Dictionary<T, List<int>>();
            return clone;
        }

        public int CompareTo(Exam<T> other) { return Time.CompareTo(other.Time); }
        public override string ToString() { return $"{Subject}-{Time}min"; }
        public override bool Equals(object obj) { return obj is Exam<T> e && e.Subject.Equals(Subject) && e.Time == Time; }
        public override int GetHashCode() { return HashCode.Combine(Subject, Time); }
    }

    class PracticeExam : Exam<Question>
    {
        public PracticeExam(int time, QuestionList<Question> questions, Subject subject)
        : base(time, questions, subject) { }

        public override void ShowExam()
        {
            Start();
            foreach (var q in Questions)
            {
                q.Show();
                CollectAnswer(q);
                foreach (var a in q.Answers)
                    if (a.IsCorrect)
                        Console.WriteLine($"Right: {a}");
            }
            Mode = ExamMode.Finished;
        }
    }

    class FinalExam : Exam<Question>
    {
        public FinalExam(int time, QuestionList<Question> questions, Subject subject)
        : base(time, questions, subject) { }

        public override void ShowExam()
        {
            Start();
            foreach (var q in Questions)
            {
                q.Show();
                CollectAnswer(q);
            }
            Mode = ExamMode.Finished;
        }
    }

    internal class Program
    {
        static void Main()
        {
            Subject sub = new Subject("OOP");

            var qList1 = new QuestionList<Question>("practice.txt");
            var qList2 = new QuestionList<Question>("final.txt");

            qList1.Add(new TrueFalseQuestion("Q1", "C# is OOP?", 5, true));
            var ans = new AnswerList{
                new Answer("Encapsulation",true),
                new Answer("Banana",false),
                new Answer("Inheritance",true)
            };
            qList1.Add(new ChooseAllQuestion("Q2", "Select OOP pillars", 10, ans));

            qList2.Add(new TrueFalseQuestion("Q1", "CLR is runtime?", 5, true));
            var ans2 = new AnswerList{
                new Answer("int",true),
                new Answer("car",false)
            };
            qList2.Add(new ChooseOneQuestion("Q2", "Select data type", 5, ans2));

            Student s1 = new Student("Ali");
            Student s2 = new Student("Mona");

            PracticeExam pe = new PracticeExam(30, qList1, sub);
            FinalExam fe = new FinalExam(60, qList2, sub);

            pe.ExamStarted += s1.OnExamStarted;
            pe.ExamStarted += s2.OnExamStarted;
            fe.ExamStarted += s1.OnExamStarted;
            fe.ExamStarted += s2.OnExamStarted;

            int choice;

            while (true)
            {
                Console.WriteLine("1-Practice 2-Final");
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && (choice == 1 || choice == 2))
                    break;

                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
            }

            if (choice == 1)
                pe.ShowExam();
            else
                fe.ShowExam();
        }
    }
}