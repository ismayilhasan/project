using Course_Managment_Appilaction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course_Managment_Appilaction.Interfaces
{
    class CourseService : ICourseService
    {

        List<Group> _Groups = new List<Group>();
        List<Student> _students = new List<Student>();
        List<Student> Students => _students;
        public List<Group> Groups => _Groups;


        //********************************Creat Group***********************
        public void CreateGroup(Catagories catagory, bool isOnline)
        {

            Group group = new Group(catagory, isOnline);

            _Groups.Add(group);

            if (isOnline == true)
            {
                Console.WriteLine($"{group.No}  has done Succesfully");
            }
            else if (isOnline == false)
            {
                Console.WriteLine($"{group.No}  has done Succesfully");
            }
            else
            {
                Console.WriteLine("Try again ");
            }





        }

        //********************************FindStudent***********************
        public Student FindStudent(int id)
        {
            foreach (Student student in Students)
            {
                if (student.Id == id)
                {
                    return student;
                }

            }
            return null;
        }
        //********************************FindGroup***********************
        public Group FindGroup(string no)
        {
            foreach (Group group in Groups)
            {
                if (group.No.ToLower().Trim() == no.ToLower().Trim())
                {
                    return group;
                }
            }
            return null;
        }

        //********************************EditGroup***********************
        public void EditGroup(string OldNo, string NewNo)
        {

            if (FindGroup(NewNo) == null)
            {
                Group group = FindGroup(OldNo);
                if (group != null)
                {


                    group.No = NewNo.ToLower().Trim();
                    Console.WriteLine($"{group.No} successfully created");
                }
                else
                {
                    Console.WriteLine($"There is no group for editing {OldNo.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine($"This Group which you edit already existed {NewNo.ToUpper()}");
            }
        }
        //********************************ShowGroup***********************
        public void ShowGroups()
        {
            if (Groups.Count > 0)
            {
                foreach (Group group in Groups)
                {
                    if (group.IsOnline == true)
                    {
                        Console.WriteLine($"Group :{group.No}   status : online \n ");
                    }
                    else
                    {
                        Console.WriteLine($"Group :{group.No}   status : ofline \n ");
                    }

                }
            }
            else
            {
                Console.WriteLine("There is no group for showing \n");
            }
        }
        //********************************CreateStudent***********************
        public void CreateStudent(string fullname, byte enter_point, string group_no)
        {
            
            if (Group.Count_group > 0)
            {
                Student student = new Student(fullname, enter_point, group_no);

                if (string.IsNullOrEmpty(student.Fullname) || string.IsNullOrWhiteSpace(student.Fullname))
                {
                    Console.WriteLine("invalid input \nStudent can not create ");

                }
                else
                {

                    Students.Add(student);
                    Group group = FindGroup(group_no);
                    //group.StudentList = new List<Student>();
                    group.StudentList.Add(student);
                  
                    if (group == null)
                    {
                        Console.WriteLine("Group not found");
                        return;
                    }
                    if (group.StudentList.Count >= group.Limit)
                    {
                        Console.WriteLine("There is no space for adding student");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("adding is succesful");
                    }
                    Console.WriteLine($"fullname: {student.Fullname}  Group Number : {student.Group_No}");

                    
                }
            }
            else
            {
                Console.WriteLine("There is no group for adding student");
            }


        }
        //********************************removeStudent***********************
        public void RemoveStudent(string group_no, int id)
        {


            Group group = FindGroup(group_no);

            if (group == null)
            {
                Console.WriteLine("There is not group with this name");
                return;
            }

            if (group.StudentList.Count == 0)
            {
                Console.WriteLine("There is no student in the group");
                return;
            }

            foreach (var item in group.StudentList)
            {
                if (item.Id == id)
                {

                    group.StudentList.Remove(item);
                    Console.WriteLine("Student is removed succesfully");
                    return;
                }
            }
            Console.WriteLine(id+ "student not found");

        }


        //********************************ShowAllStudent***********************
        public void ShowAllStudents()
        {
            if(Students.Count > 0)
            {
                foreach (Group group in Groups)
                {
                    foreach (Student student in group.StudentList)
                    {
                        Console.WriteLine($"Fullname : {student.Fullname} Group : {group} : Id : {student.Id}    ");
                    }
                }
            }
            else
            {
                Console.WriteLine("There is no student for showing \n\n");
            }
          
        }


        //********************************ShowStudentsByGroup***********************
        public void ShowStudentsByGroup(string no)
        {

            Group group = FindGroup(no);

            if (group != null)
            {

                foreach (Student students in group.StudentList)
                {

                    if (students.Type == true)
                    {
                        Console.WriteLine($"Fullname : {students.Fullname} status  : Guarenteed     Id : {students.Id} ");
                    }
                    else
                    {
                        Console.WriteLine($"Fullname : {students.Fullname}  status : not guarenteed        Id : {students.Id}");
                    }

                }
            }
            else
            {
                Console.WriteLine("There is no Student in Group");
            }
        }



    }
}
