using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqOperations
{
    class Operations
    {

        public void AgeMax(List<Human> people)
        {
            int maxAge = people.Max(x => x.Age);
            Console.WriteLine("1)Максимальный возраст:" + maxAge);
        }
        public void AgeMin(List<Human> people)
        {
            int minAge = people.Min(x => x.Age);
            Console.WriteLine("1)Минимальный возраст :" + minAge);
        }

        public void Alpahabet(List<Human> people, HumanGender man)
        {
            Console.WriteLine("2)Алфавитный порядок мужчин:");
            var alpha = from chel in people
                        where chel.Gender == HumanGender.man
                        orderby chel.Name
                        select chel;
            foreach (Human u in alpha)
                Console.WriteLine(u.Name);


        }
        public void AlpahabetW(List<Human> people, HumanGender woman)
        {
            Console.WriteLine("2)Алфавитный порядок женщин:");
            var alpha = from chel in people
                        where chel.Gender == HumanGender.woman
                        orderby chel.Name
                        select chel;
            foreach (Human u in alpha)
                Console.WriteLine(u.Name);
        }

        public void AverageName(List<Human> people)
        {
            Console.WriteLine("3)Средний возраст людей с именем короче 5 символов:");
            double result = people.Where(chel => chel.Name.Length < 5).Average(chel => chel.Age);
            Console.WriteLine(result);
        }

        public void SurnameCollection(List<Human> people)
        {
            Console.WriteLine("4)Группы однофамильцев:");
            var surnameing = from chel in people
                             group chel by chel.Surname;
            foreach (IGrouping<string, Human> surname in surnameing)
            {
                if (surname.Count() == 1)
                {
                    continue;
                }
                else
                {
                    foreach (var chel in surname)
                        Console.WriteLine($"{surname.Key} {chel.Name}");
                }
            }
        }
        public void AgeTeen(List<Human> people)
        {
            var teens = people.Where(h => h.IsKid());
            int count = teens.Count();
            Console.WriteLine("5)Количество несовершеннолетних:\n" + count);
        }


        public void JsonCreator(List<Human> people)
        {
            var HumanString = from chel in people
                             select chel;

            string jsonString = "{\n\t\"People\":[\n";

            foreach (Human chel in HumanString)
            {

                jsonString +=
                    "\t\t{\n" +
                    $"\t\t\t\"name\": \"{chel.Name}\"\n" +
                    $"\t\t\t\"surname\": \"{chel.Surname}\"\n" +
                    $"\t\t\t\"age\": {chel.Age}\n" +
                    $"\t\t\t\"gender\": {chel.Gender}\n";

                if (chel == HumanString.Last())
                {
                    jsonString += "\t\t}\n";
                }
                else
                {
                    jsonString += "\t\t},\n";
                }
            }

            jsonString = jsonString + "\t]\n}";
            Console.WriteLine("7)Содержимое коллекции в формате Json:");
            Console.WriteLine(jsonString);

        }
        public Dictionary<char, bool> WordsControl(List<Human> people)
        {
            Dictionary<char, bool> words = new Dictionary<char, bool>
            {
                { 'S', true }, { 'T', true }, { 'U', true }, { 'V', true }, { 'W', true }, { 'X', true }, { 'Y', true }, { 'Z', true },
                { 'A', true }, { 'B', true }, { 'C', true }, { 'D', true }, { 'E', true }, { 'F', true }, { 'G', true }, { 'H', true }, { 'I', true },
                { 'J', true }, { 'K', true }, { 'L', true }, { 'M', true }, { 'N', true }, { 'O', true }, { 'P', true }, { 'Q', true }, { 'R', true }

            };

            var stringPeople = from chel in people
                             select chel;

            foreach (Human chel in people)
            {
                foreach (char word in chel.Name.ToUpper())
                {
                    if (words[word])
                    {
                        words[word] = false;
                    }
                }
            }

            return words;
        }

        public void PrintWords(List<Human> people)
        {
            Console.WriteLine("6)Буквы которые не встречаются в именах:");
            Dictionary<char, bool> words = WordsControl(people);
            bool first = true;
            foreach (KeyValuePair<char, bool> word in words)
            {
                if (word.Value)
                {
                    if (first)
                    {
                        Console.Write($"{word.Key}");
                        first = false;
                    }
                    else
                    {
                        Console.Write($", {word.Key}");
                    }
                }
            }
        }

        public List<int> AgeControl(List<Human> people)
        {
            //var hash = new HashSet<int>();
            //var duplicates = list.Where(i => !hash.Add(i)); 

            List<int> result = new List<int> { };

            var ageMans = people
            .Where(man => man.Gender == HumanGender.man)
            .Select(man => man);

            foreach (Human ageMan in ageMans)
            {
                var WomanAge = people
                    .Where(woman => woman.Gender == HumanGender.woman && woman.Age == ageMan.Age)
                    .Select(woman => woman.Age);

                if (WomanAge.Count() > 0)
                {
                    result.Add(ageMan.Age);
                }

            }
            return result;
        }

        public void PrintAgeControl(List<Human> people)
        {
            Console.WriteLine("\n8)Возраста , которые встречаются у людей обоих полов");
            List<int> result = AgeControl(people);
            bool first = true;
            foreach (int age in result)
            {
                if (first)
                {
                    Console.Write($"{age}");
                    first = false;
                }
                else
                {
                    Console.Write($", {age}");
                }
            }


        }

        public List<Human> CreateNameMax(List<Human> people, MinumMaxum ager)
        {
            switch (ager)
            {
                case MinumMaxum.max:
                    var maxAge = people.GroupBy(chel => chel.Age).Max(chel => chel.Key);
                    List<Human> maxAgePeople = people.Where(age => age.Age == maxAge).ToList();
                    return maxAgePeople;

                case MinumMaxum.min:
                    var minAge = people.GroupBy(chel => chel.Age).Min(chel => chel.Key);
                    List<Human> minAgePeople = people.Where(age => age.Age == minAge).ToList();
                    return minAgePeople;

                default:
                    return new List<Human> { };
            }
        }

        public void PrintMaxMin(List<Human> people)
        {
            foreach (Human chel in people)
            {
                Console.WriteLine($"Name:{chel.Name} Age: {chel.Age}");
            }

        }

        public void PrintMaxMinNum(List<Human> people)
        {
            Console.WriteLine("\n9)Имя человека с максимальным возрастом:");
            var sordetPeople = CreateNameMax(people, MinumMaxum.max);
            PrintMaxMin(sordetPeople);
        }
        public void PrintMaxMinNumMi(List<Human> people)
        {
            Console.WriteLine("\n9)Имя человека с минимальным возрастом:");
            var sordetPeople = CreateNameMax(people, MinumMaxum.min);
            PrintMaxMin(sordetPeople);
        }

        public void Cupidon(List<Human> people)

        {

            Console.WriteLine("\n10)Пары людей:");

            var mans = from chel in people
                       where chel.Gender == HumanGender.man
                       select chel;

            var womans = from chel in people
                         where chel.Gender == HumanGender.woman
                         select chel;

            foreach (Human man in mans)
            {
                foreach (Human woman in womans)
                {
                    Console.Write($"{man.Name} {man.Surname} + {woman.Name} {woman.Surname} *|* ");
                }

                Console.WriteLine();
            }
        }
    }
}





        




    



    


   


  
            
        

    


    

