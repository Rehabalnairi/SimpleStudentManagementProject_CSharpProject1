namespace SimpleStudentManagementProject_CSharpProject1
{
    internal class Program
    {
        static double[] marks = new double[10];
        static int[] Ages = new int[10];
        static string[] names = new string[10];
        static DateTime[] dates = new DateTime[10];

        static int StudentCounter = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Add a new student record ");
                Console.WriteLine("2.View all students with formatted output and subject-wise marks.  ");
                Console.WriteLine("3.Find a student by name ");
                Console.WriteLine("4.Calculate the class average (rounded to 2 decimals). ");
                Console.WriteLine("5.Find the top-performing student  ");
                Console.WriteLine("6.Sort students by marks (highest to lowest)");
                Console.WriteLine("7.Delete a student record (handle shifting logic).");
                Console.WriteLine("0.Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        ViewStudent();
                        break;
                    case 3:
                        classAverage();
                        break;
                    case 0: return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }

                Console.ReadLine();
            }
        }
        static void AddStudent()
        {
            Console.WriteLine("Enter Details of student");
            if (StudentCounter >= 10)
            {
                Console.WriteLine("there are only 10 student recored ");
            }

            Console.WriteLine("Enter the student name");
            names[StudentCounter] = Console.ReadLine();
            Console.WriteLine("Enter Age");
            Ages[StudentCounter] = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student Mark");
            marks[StudentCounter] = double.Parse(Console.ReadLine());
            dates[StudentCounter] = DateTime.Now;


            StudentCounter++;
            Console.WriteLine("Students added!");

        }
        static void ViewStudent()
        {
            for (int i = 0; i <= StudentCounter; i++)
            {
                Console.WriteLine("Stunent Name :" + names[i]+ "\nStudent Age:" + Ages[i] + "\nStudent Mark:" + marks[i] + "\nlogin date:" + dates[i]);
            }
        }

        static void Search()
        {
            Console.WriteLine("Enter the name");
            
        }
        static void classAverage()
        {
            if (StudentCounter ==0) {
                Console.WriteLine("Add Student first!");
                return;
            }
            double totalMark =0;
            for (int i = 0; i < StudentCounter; i++)
            {
                totalMark += marks[i];
            }
            double avg = totalMark / StudentCounter;

            Console.WriteLine(" average is"+avg);


        }
    }
}
