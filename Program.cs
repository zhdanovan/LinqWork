using System;
using System.Collections.Generic;
using System.Linq;



namespace LinqOperations
{
    class Program
    {
        static void Main(string[] args)


        {
            List<Human> people = new List<Human>()
            {
                new Human() {Name ="Joe", Surname ="Biden", Age = 78,Gender= HumanGender.man},
                new Human() {Name = "Hillary", Surname = "Clinton", Age = 30, Gender = HumanGender.woman},
                new Human() {Name ="Artemis", Surname ="Zhdanov", Age = 19, Gender= HumanGender.man},
                new Human() {Name ="Ben", Surname ="Morgan", Age =40, Gender= HumanGender.man},
                new Human() {Name ="Cat", Surname ="Clinton", Age =15, Gender= HumanGender.woman},
                new Human() {Name ="Jessica", Surname ="Alba", Age =10, Gender= HumanGender.woman},
                new Human() {Name ="Peter", Surname ="Parker", Age =15, Gender= HumanGender.man},


            };

            //Console.WriteLine("Введите число соответствующее вашей просьбе:");
            //string choice = Console.ReadLine();

            //switch (choice)
            //{
            //    case "1":
            //        Operations opers = new Operations();
            //        opers.AgeMax(people);
            //        break;
            //    case "2":
            //        Operations opersi = new Operations();
            //        opersi.AgeMin(people);
            //        break;

            //}



            Operations opers = new Operations();
            opers.AgeMax(people);
            Operations opersi = new Operations();
            opersi.AgeMin(people);
            Operations opersit = new Operations();
            HumanGender man = new HumanGender();
            opersit.Alpahabet(people, man);
            Operations opersitr = new Operations();
            HumanGender woman = new HumanGender();
            opersitr.AlpahabetW(people, woman);
            Operations ope = new Operations();
            ope.AverageName(people);
            Operations opes = new Operations();
            ope.SurnameCollection(people);
            Operations oper = new Operations();
            oper.AgeTeen(people);
            Operations operk = new Operations();
            operk.JsonCreator(people);
            Operations opek = new Operations();
            opek.PrintWords(people);
            Operations opew = new Operations();
            opew.PrintAgeControl(people);
            Operations opej = new Operations();
            opej.PrintMaxMinNum(people);
            Operations opel = new Operations();
            opel.PrintMaxMinNumMi(people);
            Operations opl = new Operations();
            opl.Cupidon(people);











            //Console.WriteLine("Группировка людей по гендеру");
            //var genderGroup = from p in people
            //                  group p by p.Gender;
            //var genderGroupLambda = people.GroupBy(p => p.Gender);

            //foreach (var pers in genderGroupLambda)
            //{
            //    Console.WriteLine($"{pers.Key}");
            //    foreach (var p in pers)
            //    {
            //        Console.WriteLine($"   {p.Name}");
            //    }
            //}

        }




    }

    }

  


