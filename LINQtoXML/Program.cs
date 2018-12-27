using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LINQtoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //We simply apply our Student-Structure to XML. 
            string studentsXML =
                        @"<Students>
                            <Student>
                                <Name>Toni</Name>
                                <Age>21</Age>
                                <University>Yale</University>
                                <Semester>6</Semester>
                            </Student>
                            <Student>
                                <Name>Carla</Name>
                                <Age>17</Age>
                                <University>Yale</University>
                                <Semester>1</Semester>
                            </Student>
                            <Student>
                                <Name>Leyla</Name>
                                <Age>19</Age>
                                <University>Beijing Tech</University>
                                <Semester>3</Semester>
                            </Student>
                            <Student>
                                <Name>Frank</Name>
                                <Age>25</Age>
                                <University>Beijing Tech</University>
                                <Semester>10</Semester>
                            </Student>
                        </Students>";

            XDocument studentsXmlDoc = new XDocument();
            studentsXmlDoc = XDocument.Parse(studentsXML);
            var students =
                from student in studentsXmlDoc.Descendants("Student")
                orderby student.Element("Age").Value
                select new
                {
                    name = student.Element("Name").Value,
                    age = student.Element("Age").Value,
                    university = student.Element("University").Value,
                    semester = student.Element("Semester").Value
                };

            Console.WriteLine("Students ordered by age:");

            foreach (var student in students)
            {
                Console.WriteLine("Student name: {0}, age: {1}, university: {2}, semester: {3}", student.name, student.age, student.university, student.semester);
            }

            Console.ReadLine();
        }
    }
}
