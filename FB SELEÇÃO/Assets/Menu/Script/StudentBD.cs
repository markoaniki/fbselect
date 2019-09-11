using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using UnityEngine;

public class StudentBD : MonoBehaviour
{
    public static readonly string querySelectStudent = "SELECT* from student WHERE name LIKE @paramName";
    public static readonly string querySelectStudentByNameAndGrade = "SELECT* from student WHERE name LIKE @paramName";
    public static readonly string queryInsertStudent = "";

    
    
    public StudentBD(){}



    public List<Student> Select(Student student)
    {
        int paramsCount = 0;
        StringBuilder queryBuilder = new System.Text.StringBuilder();
        queryBuilder.Append("SELECT * FROM student");
        List<ParametroQuery> parametroQueryList = new List<ParametroQuery>(); 
        

        MySqlConnection mysqlConnection = ConnectionDB.GetMysqlConnection();
        List<Student> studentList = new List<Student>();
        
        try
        {
            //String query = "SELECT * from student WHERE name LIKE @paramName";

            // Search student by Name
            if(!String.IsNullOrEmpty(student.Name))
            {
                ParametroQuery parametroQuery = new ParametroQuery("name", student.Name);
                parametroQueryList.Add(parametroQuery);
                queryBuilder.Append(" WHERE " + parametroQuery.ParamName + " LIKE @" + parametroQuery.ParamName);
                paramsCount++;
            }

            // Search student by Grade
            if (!String.IsNullOrEmpty(student.Grade))
            {
                ParametroQuery parametroQuery = new ParametroQuery("grade", student.Grade);
                parametroQueryList.Add(parametroQuery);

                if (paramsCount == 0)
                    queryBuilder.Append(" WHERE " + parametroQuery.ParamName + " = @" + parametroQuery.ParamName);
                else
                    queryBuilder.Append(" AND " + parametroQuery.ParamName + " = @" + parametroQuery.ParamName);
                paramsCount++;
            }


            mysqlConnection.Open();
            MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), mysqlConnection);

            foreach (ParametroQuery parametroQuery in parametroQueryList)
            {
                command.Parameters.AddWithValue("@" + parametroQuery.ParamName, parametroQuery.ParamValue);
            }

            
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Student studentAux = new Student();
                student.Name = dataReader["name"].ToString();
                student.BirthDate = dataReader["birthtime"].ToString();
                student.OldSchool = dataReader["oldSchool"].ToString();
                student.Grade = dataReader["grade"].ToString();

                studentList.Add(studentAux);

            }

            mysqlConnection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            mysqlConnection.Close();
        }

        return studentList;
    }

    public void Insert(Student student)
    {
        MySqlConnection mySqlConnection = ConnectionDB.GetMysqlConnection();

        try
        {
            String query = "INSERT INTO student (inscription, admin_ID, info_ID, name, birthdate, oldSchool, grade) " +
            "VALUES(@inscription, @admin_id, @info_ID, @name, @birthdate, @oldSchool, @grade)";
            //123", "2", "4", "4", "Pedro", "01/01/2000", "Escola antiga", "Serie do aluno"
            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@inscription", "1234");
            command.Parameters.AddWithValue("@admin_id", "2");
            command.Parameters.AddWithValue("@info_ID", "5");
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@birthdate", student.BirthDate);
            command.Parameters.AddWithValue("@oldSchool", student.OldSchool);
            command.Parameters.AddWithValue("@grade", student.Grade);

            mySqlConnection.Open();
            command.ExecuteNonQuery();


        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        } finally
        {
            mySqlConnection.Close();
        }
        
        

    }

    public void Delete(Student student)
    {

    }

    static void Main(String[] Args)
    {
        StudentBD studentBD = new StudentBD();

        Student student = new Student();
        student.Name = "asdadasdas";
        student.Grade = "3";
        student.BirthDate = "01/01/2010";
        student.OldSchool = "Escola anterior";
        //List<Student> studentList = studentBD.Select(student);

        //foreach (Student s in studentList)
        //{
        //    // Exibindo dados do aluno no console
        //    Console.WriteLine("Nome: " + student.Name);
        //    Console.WriteLine("Data de nascimento: " + student.BirthDate);
        //    Console.WriteLine("Escola anterior: " + student.OldSchool);
        //    Console.WriteLine("Série: " + student.Grade);
        //    Console.WriteLine("");
        //}

        //if (studentList.Count == 0)
        //{
        //    Console.WriteLine("Buscas sem resultados.");
        //}

        studentBD.Insert(student);

    }
}


