using System;
using System.Text.Json;
using System.Collections;

namespace InterviewCake
{
    [Serializable]
    public class POJO : IEnumerable, IEnumerator
    {
        public Person[] PersonList { get;  set; }
        private int position = -1;

        public POJO(Person[] personList)
        {
            PersonList = personList;
        }

        public object Current 
        {
            get
            {
                try 
                {
                    return PersonList[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        } 

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < PersonList.Length);
        }

        public void Reset()
        {
            position = 0;
        }
    }

    public class Person : IEnumerable, IEnumerator
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Skill[] Skills { get; set; }

        private int position = -1;

        public Person (string name, int age, Skill[] skills)
        {
            Name = name;
            Age = age;
            Skills = skills;
        }

        public object Current
        {
            get
            {
                try
                {
                    return Skills[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < Skills.Length);
        }

        public void Reset()
        {
            position = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }

    public class Skill
    {
        public string SkillName { get; set; }   
    }

    public static class Lowes
    {
        public static void ToJsonTest()
        {
            var skills = new Skill[] { 
                new Skill() { SkillName = "firstSkill" },
                new Skill() { SkillName = "anotherSkill" }
            };

            var p = new Person("TEST", 20, skills);

            var pojo = new POJO( new Person[] { p } );
            var result = pojo.ToJson();
            System.Console.WriteLine(result);
        }

        public static string ToJson(this POJO data)
        {
            return JsonSerializer.Serialize(data);
        }
    }

/*
INPUT (It's a String)
[
{'event_id': 1, 'type':'SCAN', 'payload': {'time': '200ms', 'status': 'FAILED', 'catalog_id': 1}},
{'event_id': 2, 'type':'BUILD', 'payload': {'time': '250ms', 'status': 'FAILED', 'catalog_id': 2}},
{'event_id': 3, 'type':'SCAN', 'payload': {'time': '300ms', 'status': 'FAILED', 'catalog_id': 3}},
{'event_id': 4, 'type':'BUILD', 'payload': {'time': '201ms', 'status': 'SUCCEEDED', 'catalog_id': 4}},
{'event_id': 5, 'type':'BUILD', 'payload': {'time': '1200ms', 'status': 'FAILED', 'catalog_id': 12}},
{'event_id': 6, 'type':'BUILD', 'payload': {'time': '1000ms', 'status': 'SUCCEEDED', 'catalog_id': 1}},
{'event_id': 7, 'type':'INTAKE', 'payload': {'time': '', 'status': 'PENDING', 'catalog_id': 2}},
{'event_id': 8, 'type':'BUILD', 'payload': {'time': '20ms', 'status': 'SUCCEEDED', 'catalog_id': 3}},
{'event_id': 9, 'type':'BUILD', 'payload': {'time': '200ms', 'status': 'FAILED', 'catalog_id': 11}},
{'event_id': 10, 'type':'BUILD', 'payload': {'time': '20ms', 'status': 'SUCCEEDED', 'catalog_id': 5}}
]

OUTPUT ()Could be any structure
[
{'SUCCEDED': { 'time': 12334, 'catalog_ids': [4,1,3,5]}},
{'FAILED': { 'time': 12334, 'catalog_ids': [1,2,3,11,12]}},
]
*/
}