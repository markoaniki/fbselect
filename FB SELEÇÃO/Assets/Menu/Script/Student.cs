using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student
{
    static int BaseInscrption = 201900000;
    static int NextId = 1;

    public int Inscription { get; }
    public string Name { get; set; }
    public string BirthTime { get; set; }
    public string OldSchool { get; set; }
    public string Grade { get; set; }

    public List<Questao> Questions { get; set; }

    public Questao inProgressQuestion { get; set; }

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
        Inscription = BaseInscrption + NextId;
        NextId++;
        Name = name;
        BirthTime = birthDate;
        OldSchool = oldSchool;
        Grade = grade;
        Questions = GenerateQuestions(questions);
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
        
        if(q != null)
        {
            inProgressQuestion = q;
            q.beginQuestion();
            return true;
        }

        return false;
    }
}
