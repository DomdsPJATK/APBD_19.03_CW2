using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using APBD_19._03_CW2.Exceptions;
using APBD_19._03_CW2.Model;
using APBD_19._03_CW2.MyUtils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APBD_19._03_CW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program(args);
        }

        //------------------------------------------

        private string urlCSV;
        private string urlTarget;
        private string dataForm;
        private string dataFromFile;
        private List<Student> students = new List<Student>();
        private static LogWriter _logWriter;
        private IDataWriter dataWriter;

        private Program(string[] args)
        {
            ReadParametersFromUser();
            _logWriter = new LogWriter("log.txt");
            ReadDataFromFile(urlCSV);
            WriteDataToFile(dataForm);
            
        }

        public void WriteDataToFile(string form)
        {
            University university = new University()
            {
                createdAt = DateTime.Now.ToString("h:mm:ss tt"),
                author = "Dominik Suchner",
                listOfStudents = students
            };
            
            if (dataForm.Equals("xml"))
            {
                new XMLWriter().WriteData(urlTarget, university);
            }

            if (dataForm.Equals("json"))
            {
                new JSONWriter().WriteData(urlTarget, university);
            }
            
        }

        public void ReadDataFromFile(string path)
        {
            try
            {
                using (var stream = new StreamReader(path))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        Boolean isOk = true;
                        string[] studentSplit = line.Split(',');
                        try
                        {
                            if (studentSplit.Length != 9) throw new ColumnException("log.txt", line);
                        }
                        catch (ColumnException e)
                        {
                            Console.WriteLine(e.Message);
                            isOk = false;
                        }

                        if (isOk)
                        {
                            foreach (var dataInStudent in studentSplit)
                            {
                                try
                                {
                                    if (dataInStudent == "")
                                        throw new ColumnException("Brakujace dane", "log.txt", line);
                                }
                                catch (ColumnException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }

                            var student = new Student
                            {
                                name = studentSplit[0],
                                surname = studentSplit[1],
                                index = "s" + studentSplit[4],
                                birthdate = Convert.ToDateTime(studentSplit[5]),
                                email = studentSplit[6],
                                mothersName = studentSplit[7],
                                fathersName = studentSplit[8],
                                mode = new Mode()
                                {
                                    name = studentSplit[2],
                                    mode = studentSplit[3]
                                }
                            };

                            if (!isDuplicated(student)) students.Add(student);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                _logWriter.WriteData(e.Message);
                Console.WriteLine("Podana ścieżka jest niepoprawna");
            }
            catch (ArgumentException e)
            {
                _logWriter.WriteData(e.Message);
                Console.WriteLine("Plik" + urlCSV + "nie istnieje");
            }
        }
        
        public Boolean isDuplicated(Student student)
        {
            foreach (var stud in students)
            {
                if (!student.Equals(stud))
                {
                    if (String.Equals(student.name, stud.name) && String.Equals(student.surname, stud.surname) && String.Equals(student.index, stud.index)) return true;
                }
            }

            return false;
        }

        public void ReadParametersFromUser()
        {
            String d1, d2, d3;
            Console.WriteLine("Podaj url do CSV");
            d1 = Console.ReadLine();
            if (d1 == "")
                urlCSV = "data.csv";
            else
                urlCSV = d1;

            Console.WriteLine("Podaj sciezke docelowa: ");
            d2 = Console.ReadLine();
            if (d2 == "")
                urlTarget = "result.xml";
            else
                urlTarget = d2;

            Console.WriteLine("Podaj typ danych: ");
            d3 = Console.ReadLine();
            if (d3 == "")
                dataForm = "xml";
            else
                dataForm = d3;

            Console.WriteLine(urlCSV);
            Console.WriteLine(urlTarget);
            Console.WriteLine(dataForm);
        }
    }
}