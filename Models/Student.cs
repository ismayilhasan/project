using System;
using System.Collections.Generic;
using System.Text;

namespace Course_Managment_Appilaction
{
    class Student
    {
        public byte Enter_Point;
        public  int Id;
        public static int Count;
        public string Fullname;
        public string Group_No;
         public bool Type;


        public Student()
        {

        }
        static Student() // static constructor
        {
            Count = 0;
  
        }
         
        public Student(string fullname,byte enter_point,string group_no) : this(enter_point)
        {
            
            Fullname = fullname;
            Group_No = group_no;
            Enter_Point = enter_point;
            Id = Count++;
            Id += 1000;

        }

        public Student(byte enter_point)
        {
            if(enter_point > 80)
            {
                Enter_Point = enter_point;
                Type = true;
            }
            else
            {
                Type = false;
            }
        }

        public override string ToString()
        {
            if(Type == true)
            {
                return $"Fullname : {Fullname} Group  :  {Group_No} ID : {Id} Status : Guarenteed  ";
            }
            return $"Fullname : {Fullname} Group :  {Group_No} ID : {Id} Status : not guarenteed  ";
        }
    }
}
