using Course_Managment_Appilaction.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_Managment_Appilaction
{
    static class MenuServives
    {
        public static CourseService courseService= new CourseService();

        public static void CreateGroup()
        {
            Group group = new Group();
            object category;
            string answer; 

            Console.WriteLine("Please, Enter Which Category Do You Want To Study ");


            foreach (var item in Enum.GetValues(typeof(Catagories)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }

            bool resultCategory = Enum.TryParse(typeof(Catagories), Console.ReadLine(), out category);

           


            Console.WriteLine("is it Group online Yes/No");
            answer = Console.ReadLine();
            if (answer.ToLower().Trim() == "yes")
            {
                group.IsOnline = true;
            }
            else if(answer.ToLower().Trim() == "no")
            {
                group.IsOnline = false;
            }
            else
            {
                Console.WriteLine("invalid answer \nPlease only yes or not ");
               
            }


            if (resultCategory)
            {
                courseService.CreateGroup((Catagories)category, group.IsOnline);
            }

        }

        public static void EditGroup()
        {

            Console.WriteLine("Please, enter Group No");
            string OldNum = Console.ReadLine();
            Console.WriteLine("Please, enter New Group No");
            string NewNum = Console.ReadLine();
            courseService.EditGroup(OldNum, NewNum);
        }

        public static void ShowAllGroup()
        {
            courseService.ShowGroups();
        }

        public static void CreateStudent()
        {

            string fullname;
            string group_no;
            do
            {

                Console.WriteLine("Enter the Fullname");
                fullname = Console.ReadLine();

            }
            while (string.IsNullOrEmpty(fullname) || string.IsNullOrWhiteSpace(fullname));

            do
            {
                Console.WriteLine("Enter Group Name");
                group_no = Console.ReadLine();
            } while (string.IsNullOrEmpty(group_no) || string.IsNullOrWhiteSpace(group_no));
            

         
            Console.WriteLine("Enter  Entry Point");
            
            byte enterpoint;
            bool resultPoint = byte.TryParse(Console.ReadLine(), out enterpoint);

            while(resultPoint != true)
            {
                    Console.WriteLine("Invalid Input");

                     enterpoint = Convert.ToByte(Console.ReadLine());

               
            }

            courseService.CreateStudent(fullname,enterpoint,group_no);
        }


        public static void ShowAllStudents()
        {
            courseService.ShowAllStudents();
        }

        public static void ShowStudentsByGroup()
        {
            Console.WriteLine("Enter Group Number");
            string groupNumber = Console.ReadLine();
            courseService.ShowStudentsByGroup(groupNumber);
        }

        public static void RemoveStudent()
        {
            Console.WriteLine("Write Group Code Please ");
            string group_no = Console.ReadLine();
            Console.WriteLine("Please Enter Id of Student");
            int id = Convert.ToInt32(Console.ReadLine());
            courseService.RemoveStudent(group_no, id);
        }

        public static void findStudent()
        {
            Console.WriteLine("Enter ID of Student");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(courseService.FindStudent(id) ); 

        }
    }
}

    
