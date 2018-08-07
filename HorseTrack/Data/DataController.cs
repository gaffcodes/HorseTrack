using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using HorseTrack.Models.DBModels;

namespace HorseTrack.Data
{
    public class DataController
    {
        public List<User> Users { get; set; }
        public Dictionary<String, String> UserDict { get; set; }
        public List<Horse> Horses { get; set; }
        public Dictionary<String, String> HorseDict { get; set; }

        private static DataController data;
        public static DataController Data
        {
            get
            {
                if (data != null) { return data; }
                data = new DataController();
                return data;
            }
        }

        private DataController()
        {
            Users = new List<User>();
            UserDict = new Dictionary<string, string>();
            Horses = new List<Horse>();
            HorseDict = new Dictionary<string, string>();
            ProcessUsers();
        }

        private List<String> ReadFile(String fileName)
        {
            List<String> list = new List<String>();
            String[] file = File.ReadAllLines(fileName);
            foreach (String line in file)
            {
                list.Add(line);
            }
            return list;
        }

        private void ProcessUsers()
        {
            List<String> names = ReadFile(@"F:\Code\HorseTrack\HorseTrack\Data\UserNames.txt");
            List<String> streets = ReadFile(@"F:\Code\HorseTrack\HorseTrack\Data\Streets.txt");
            Random rand = new Random();
            Users = new List<User>();

            for (int x = 0; x<30; x++)
            {
                int ID = x;
                String name = names.ElementAt(rand.Next(names.Count - 1));
                names.Remove(name);
                String email = name.Substring(name.IndexOf(' ')).Trim() + "@gmail.com";
                String phone = "314" + rand.Next(10) + rand.Next(10) + rand.Next(10) + rand.Next(10) + rand.Next(10) + rand.Next(10) + rand.Next(10);
                String[] address = {"" + rand.Next(10) + rand.Next(10) + rand.Next(10) + rand.Next(10),
                                        streets.ElementAt(rand.Next(streets.Count-1)),
                                        "St. Louis, MO, 63126"
                                   };

                List<Horse> horses = new List<Horse>();
                for (int y=0; y<rand.Next(4)+2; y++)
                {
                    horses.Add(makeHorse(ID));
                }
                User user = new User
                {
                    ID = ID,
                    Name = name,
                    Email = email,
                    Phone = phone,
                    Address = address,
                    Horses = horses
                };

                foreach (Horse horse in user.Horses)
                {
                    horse.Owner = user;
                }
                UserDict.Add(user.ID.ToString(), user.Name);
                Users.Add(user);
            }
        }

        private Horse makeHorse(int ownerID)
        {
            List<String> maleNames = ReadFile(@"F:\Code\HorseTrack\HorseTrack\Data\MaleHorseNames.txt");
            List<String> femaleNames = ReadFile(@"F:\Code\HorseTrack\HorseTrack\Data\FemaleHorseNames.txt");
            List<String> breeds = ReadFile(@"F:\Code\HorseTrack\HorseTrack\Data\Breeds.txt");
            List<String> colors = ReadFile(@"F:\Code\HorseTrack\HorseTrack\Data\Colors.txt");
            Random rand = new Random();

            String name;
            String gender;
            int _gender = rand.Next(4);
            if (_gender <= 1)
            {
                name = maleNames.ElementAt(rand.Next(maleNames.Count - 1));
                maleNames.Remove(name);
                gender = (_gender == 0) ? "Stallion" : "Gelding";
            }
            else
            {
                name = femaleNames.ElementAt(rand.Next(femaleNames.Count - 1));
                femaleNames.Remove(name);
                gender = "Mare";
            }
            String breed = breeds.ElementAt(rand.Next(breeds.Count - 1));
            String color = colors.ElementAt(rand.Next(colors.Count - 1));
            String age = rand.Next(20).ToString();

            Horse horse = new Horse
            {
                ID = Horses.Count,
                OwnderID = ownerID,
                Name = name,
                Gender = gender,
                Breed = breed,
                Color = color,
                Age = age
            };
            HorseDict.Add(horse.ID.ToString(), horse.Name);
            Horses.Add(horse);
            return horse;
        }

    }
}