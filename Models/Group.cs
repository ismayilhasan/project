using System;
using System.Collections.Generic;
using System.Text;

namespace Course_Managment_Appilaction
{
    class Group
    {
        public string No;
      
        public bool IsOnline;
        public int Limit;
        
        public List<Student> StudentList;
        Catagories Catagory = new Catagories();
        public static int Count;
        public static int Count_group;

        public Group()
        {
        }
        static Group()
        {
            Count = 100;
            Count_group = 0;
        }

      
        public Group( Catagories catagory, bool isOnline)
        {
            switch (catagory)
            {
                case Catagories.Programming:
                    No = $"P" + Count;
                    break;
                case Catagories.Desing:
                    No = $"D" + Count;
                    break;
                case Catagories.System_Administration:
                    No = $"SA" + Count;
                    break;
                default:
                    break;
            }

            StudentList = new List<Student>();

            Catagory = catagory;
            IsOnline = isOnline;
            Count++;
            Count_group++;
            Limit = isOnline ? 10 : 15;
            


        }

        public override string ToString()
        {
            return $"{No},{Catagory}";
        }


    }
}