using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    static public List<Student> Students = null;
    public string scenePATH = "Menu/Scenes/Menu";

    static public Student estudanteLogado = null;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(Students == null) {
            Students = new List<Student>();
        }
    }

    void Start()
    {
        SceneManager.LoadScene(scenePATH, LoadSceneMode.Single);
    }

    public static void AddStudent(string name, string birthDate, string oldSchool, string grade, List<int> questions)
    {
        Students.Add(new Student(name, birthDate, oldSchool, grade, questions));
    }

    public static Student GetStudentsByID(int studentID)
    {
        foreach(Student s in Students)
        {
            if (s.Inscription == studentID)
            {
                return s;
            }
        }
        return null;
    }

    public static bool SetStudentByID(int studentID)
    {
        foreach(Student s in Students)
        {
            if (s.Inscription == studentID)
            {
                estudanteLogado = s;
                return true;
            }
        }
        estudanteLogado = null;
        return false;
    }

    public static List<Student> GetAllStudents()
    {
        return Students;
    }

    public static Questao GetQuestionByID(Student s, int questionID)
    {
        return s.GetQuestionByID(questionID);
    }

    public static void SetQuestionByID(int questionID)
    {
        estudanteLogado.SetQuestion(questionID);
    }

    public static List<Questao> GetAllQuestions(Student s)
    {
        return s.Questions;
    }
}
