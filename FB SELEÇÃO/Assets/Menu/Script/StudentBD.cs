using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UI;

public class StudentBD : MonoBehaviour
{
   public InputField ifStudentName, ifStudentOldSchool, ifRespName, ifRespEmail, ifRespPhone;
   public Dropdown ddBirthdateDay, ddBirthdateMonth, ddBirthdateYear, ddStudentGrade;

   public static int incriptionCounter;
    
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
            mysqlConnection.Open();
            //String query = "SELECT * from student WHERE name LIKE @paramName";

            // Search student by Name
            if (!String.IsNullOrEmpty(student.Name))
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


            
            MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), mysqlConnection);

            foreach (ParametroQuery parametroQuery in parametroQueryList)
            {
                command.Parameters.AddWithValue("@" + parametroQuery.ParamName, parametroQuery.ParamValue);
            }

            
            MySqlDataReader dataReader = command.ExecuteReader();

        
            while (dataReader.Read())
            {
                Student studentAux = new Student();
                studentAux.Name = Convert.ToString(dataReader["name"]);
                studentAux.BirthDate = Convert.ToString(dataReader["birthdate"]);
                studentAux.OldSchool = Convert.ToString(dataReader["oldSchool"]);
                studentAux.Grade = Convert.ToString(dataReader["grade"]);

                studentList.Add(studentAux);
                

            }

            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (mysqlConnection != null)
                mysqlConnection.Close();
        }

        return studentList;
    }

    public void Insert()
    {
        // Student student = new Student();
        // student.Name = "cicrano 11111111";
        // student.Grade = "22222";
        // student.BirthDate = "03/03/2013";
        // student.OldSchool = "Escola anterior 3333";
        // student.Inscription = 1238;

        


        int studentInscription = 201900000 + ++incriptionCounter;
        String studentBirthdate = ddBirthdateDay.options[ddBirthdateDay.value].text + "/" + ddBirthdateMonth.options[ddBirthdateMonth.value].text + "/" + ddBirthdateYear.options[ddBirthdateYear.value].text;
        int admin_id = 1;
        int info_id = 1;

        MySqlConnection mySqlConnection = ConnectionDB.GetMysqlConnection();

        Debug.Log("inscription: " + studentInscription);
        Debug.Log("Name: " + ifStudentName.text);
        Debug.Log("Birthdate: " + studentBirthdate);
        Debug.Log("Name: " + ifStudentOldSchool.text);
        Debug.Log("Name: " + ddStudentGrade.options[ddStudentGrade.value].text);
        try
        {
            String query = "INSERT INTO student (admin_ID, info_ID, name, birthdate, oldSchool, grade) " +
            "VALUES(@admin_id, @info_ID, @name, @birthdate, @oldSchool, @grade)";
            //123", "2", "4", "4", "Pedro", "01/01/2000", "Escola antiga", "Serie do aluno"
            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@admin_id", admin_id);
            command.Parameters.AddWithValue("@info_ID", info_id);
            command.Parameters.AddWithValue("@name", ifStudentName.text);
            command.Parameters.AddWithValue("@birthdate", studentBirthdate);
            command.Parameters.AddWithValue("@oldSchool", ifStudentOldSchool.text);
            command.Parameters.AddWithValue("@grade", ddStudentGrade.options[ddStudentGrade.value].text);
            

            mySqlConnection.Open();
            command.ExecuteNonQuery();


        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        } finally
        {
            if (mySqlConnection != null)
                mySqlConnection.Close();
        }
    }

    public void stuUpdate(Student student)
    {
        MySqlConnection mySqlConnection = ConnectionDB.GetMysqlConnection();
        try
        {
            mySqlConnection.Open();
            String query = "UPDATE student SET name = @name, birthdate = @birthdate, oldSchool = @oldSchool, grade = @grade " +
            "WHERE inscription = @inscription";

            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@inscription", student.Inscription);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@birthdate", student.BirthDate);
            command.Parameters.AddWithValue("@oldschool", student.OldSchool);
            command.Parameters.AddWithValue("@grade", student.Grade);

            command.ExecuteNonQuery();


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (mySqlConnection != null)
                mySqlConnection.Close();
        }
    }

    public void Delete(int inscription)
    {
        MySqlConnection mySqlConnection = ConnectionDB.GetMysqlConnection();
        try
        {
            mySqlConnection.Open();
            String query = "DELETE FROM student WHERE inscription = @inscription";
            MySqlCommand command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@inscription", inscription);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (mySqlConnection != null)
                mySqlConnection.Close();
        }
    }

    static void Main(String[] Args)
    {
        StudentBD studentBD = new StudentBD();

        Student student = new Student();
        student.Name = "Fulano 22222";
        student.Grade = "22222";
        student.BirthDate = "03/03/2013";
        student.OldSchool = "Escola anterior 3333";
        student.Inscription = 123;
        List<Student> studentList = new List<Student>();
        //studentList = studentBD.Select(student);

        //foreach (Student s in studentList)
        //{
        //    // Exibindo dados do aluno no console
        //    Console.WriteLine("Nome: " + s.Name);
        //    Console.WriteLine("Data de nascimento: " + s.BirthDate);
        //    Console.WriteLine("Escola anterior: " + s.OldSchool);
        //    Console.WriteLine("Série: " + s.Grade);
        //    Console.WriteLine("");
        //}

        //if (studentList.Count == 0)
        //{
        //    Console.WriteLine("Buscas sem resultados.");
        //}

        
        //studentBD.Delete(1234);
        //List<Student> studentList = studentBD.Select(student);
        //studentBD.Update(student);
    }
}


