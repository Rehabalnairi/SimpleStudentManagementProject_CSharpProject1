using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

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
            try
            {



                while (true) //switch statment inside while statment for create mune 
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
                            Search();
                            break;
                        case 4:
                            classAverage();
                            break;
                        case 5:
                            findTop();
                            break;
                        case 6:
                            sort();
                            break;
                        case 7:
                            deleteStudent();
                            break;

                        case 0: return;
                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }

                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AddStudent()
        {
            try
            {
                char ChoiceChar = 'y';
                while (StudentCounter < 10)
                //ask user for write only 10 students by use while statments 
                {
                    Console.WriteLine($"Enter the name of student {StudentCounter + 1}:");
                    names[StudentCounter] = Console.ReadLine();

                    double Mark;
                    do  // use do-while to check if input is  correct or no 
                    {
                        Console.WriteLine($"Enter the Mark of student {StudentCounter + 1} (0-100): ");
                        Mark = double.Parse(Console.ReadLine());

                        if (Mark < 0 || Mark > 100) // if Statement to check tme mark 
                        {
                            Console.WriteLine("Incorrect Mark format or it not in rang (0-100), please try again.");

                        }
                    }


                    while (Mark < 0 || Mark > 100);
                    Console.WriteLine("Mark Entered Successfully!");
                    marks[StudentCounter] = Mark;

                    int Age;
                    do
                    // use do-while to check if input is  correct or no 
                    {
                        Console.WriteLine($"Enter the age of student {StudentCounter + 1}: (>21): ");
                        Age = int.Parse(Console.ReadLine());
                        if (Age <= 21)
                        {
                            Console.WriteLine("Invalid Age Number format ot it less than 21, please try again.");
                        }

                    } while (Age <= 21);
                    Console.WriteLine("Age Entered Successfully!");
                    Ages[StudentCounter] = Age;

                    dates[StudentCounter] = DateTime.Now;
                    Console.WriteLine("Student Add Successfully");
                    StudentCounter++;

                    Console.WriteLine("Do you want add another student information ? y / n");
                    ChoiceChar = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    if (ChoiceChar != 'y' && ChoiceChar != 'Y')
                        break;


                }
                if (StudentCounter == 11)
                    Console.WriteLine("Cannot add more students. Maximum limit reached.");
            }
            catch (Exception e)
            {
                Console.WriteLine("chose currect" + e.Message);
            }
            Console.WriteLine("after excption handeled");
            Console.ReadLine(); /// break 

        }
            //Console.WriteLine("Enter Details of student");
            //if (StudentCounter >= 10)
            //{
            //    Console.WriteLine("there are only 10 student recored ");
            //}

            //Console.WriteLine("Enter the student name");
            //names[StudentCounter] = Console.ReadLine();
            //Console.WriteLine("Enter Age");
            //Ages[StudentCounter] = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter student Mark");
            //marks[StudentCounter] = double.Parse(Console.ReadLine());
            //dates[StudentCounter] = DateTime.Now;


            //StudentCounter++;
            //Console.WriteLine("Students added!");

        
        static void ViewStudent()
        {
            if (StudentCounter == 0)
            {
                Console.WriteLine("No recoed!");
                return;
            }
            for (int i = 0; i <= StudentCounter; i++)
            {
                Console.WriteLine("Stunent Name :" + names[i] + "\nStudent Age:" + Ages[i] + "\nStudent Mark:" + marks[i] + "\nlogin date:" + dates[i]);
            }
        }
        // use for loop to check if there any recoed inside array and print it
        static void Search()
        {
            Console.WriteLine("Enter the name");
            string inputName = Console.ReadLine().ToLower();

            bool found = false;
            for (int i = 0; i <= StudentCounter; i++)
            {
                if (names[i].ToLower() == inputName);
                {
                    Console.WriteLine("Stunent Name :" + names[i] + "\nStudent Age:" + Ages[i] + "\nStudent Mark:" + marks[i] + "\nlogin date:" + dates[i]);
                    found = true;
                    break;
                }
                if (!found)
                {
                    Console.WriteLine("Not found");
                }

            }
            //ask user to waite name for search if its inside the array or no 
            // use if statment to check if tne name is avalible or no 
            // use loop statment to check if there are recored with same name and print detailes 
            
        }

        static void findTop()
        {
            double topmark = 0;
            for (int i = 0; i <= StudentCounter; i++)
            {
                if (marks[i] > topmark)
                {
                    topmark = i;
                }
                Console.WriteLine("Stunent Name :" + names[i] + "\nStudent Age:" + Ages[i] + "\nStudent Mark:" + marks[i] + "\nlogin date:" + dates[i]);

            }
        }
        //declere new variable =0 
        //find the highest mark and save it inside topmark and print all detailes of this student which have highest mark 

        static void classAverage()
        {

            if (StudentCounter == 0)
            {
                Console.WriteLine("Add Student first!");
                return;
            }
            double totalMark = 0;
            for (int i = 0; i < StudentCounter; i++)
            {
                totalMark += marks[i];
            }
            double avg = totalMark / StudentCounter;

            Console.WriteLine(" average is" + avg);
        }
        //decleare variable for caluculate the avarage
        // loop arry to add all students marks and save it inside totalMark
        // Calculate average
        static void sort()
        {
            if (StudentCounter == 0)
            {
                Console.WriteLine("Add Student first!");
                return;
            }
            for (int i = 0; i < StudentCounter - 1; i++)
            {
                for (int j = 0; j < StudentCounter - 1 - i; j++)
                {
                    if (marks[j] < marks[j + 1])
                    {

                        double tempMark = marks[j];
                        marks[j] = marks[j + 1];
                        marks[j + 1] = tempMark;


                        string tempName = names[j];
                        names[j] = names[j + 1];
                        names[j + 1] = tempName;


                        int tempAge = Ages[j];
                        Ages[j] = Ages[j + 1];
                        Ages[j + 1] = tempAge;


                        DateTime tempDate = dates[j];
                        dates[j] = dates[j + 1];
                        dates[j + 1] = tempDate;
                    }


                }
                Console.WriteLine("Stunent Name :" + names[i] + "\nStudent Age:" + Ages[i] + "\nStudent Mark:" + marks[i] + "\nlogin date:" + dates[i]);
            }
        }
        //use loop to sorting students by marks in descreding order 
        // use flag optimze the sort
        //use if statment to compare the marks
        //swap mark ,names,ages and dates

        static void deleteStudent()
        {
            int indext = 0;
            Console.WriteLine("enter name ");
            string dename = Console.ReadLine();
            for (int i = 0; i < StudentCounter; i++)
            {
                if (names[i] == dename)
                {
                    indext = i;
                    for (int j = indext + 1; j < StudentCounter - 1; j++)
                    {
                        names[j] = names[j - 1];
                        Ages[j] = Ages[j - 1];
                        marks[j] = marks[j - 1];
                        dates[j] = dates[j - 1];
                    }
                    StudentCounter--;

                    Console.WriteLine("recored deleted !");
                }
            }
        }
    }
    // deleare new varabile dename 
    //loop array 
    //check if dename avalible inside array
    // shift element to next index
}

        
