using System.Collections;
using System.Collections.Generic;

public class Student
{
    static int BaseInscrption = 201900000;
    static int NextId = 1;

    private int inscription;
    private string name;
    private string birthDate;
    private string oldSchool;
    private string grade;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public string OldSchool
    {
        get { return oldSchool; }
        set { oldSchool = value; }
    }

    public string Grade
    {
        get { return grade; }
        set { grade = value; }
    }

    public int Inscription
    {
        get { return inscription; }
        set { inscription = value; }
    }



    public List<Questao> Questions { get; set; }

    public Questao inProgressQuestion { get; set; }

    public float Time { get; set; } = 0;

    private List<Questao> GenerateQuestions(List<int> questions)
    {
        List<Questao> qs = new List<Questao>();
        foreach (int q in questions)
        {
            qs.Add(new Questao(q));
        }
        return qs;
    }

    public Student(string name, string birthDate, string oldSchool, string grade, List<int> questions)
    {
        inscription = BaseInscrption + NextId;
        NextId++;
        this.Name = name;
        this.BirthDate = birthDate;
        this.OldSchool = oldSchool;
        this.Grade = grade;
        Questions = GenerateQuestions(questions);
    }

    public Student()
    {
    }

    public Questao GetQuestionByID(int questionID)
    {
        foreach (Questao q in Questions)
        {
            if (q.QuestionID == questionID) { return q; }
        }
        return null;
    }

    public bool SetQuestion(int questionID)
    {
        Questao q = GetQuestionByID(questionID);

        if (q != null)
        {
            inProgressQuestion = q;
            q.beginQuestion();
            return true;
        }

        return false;
    }
}
