using System;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = GetUserData();
            ShowUserData(user);

            Console.ReadLine();
        }
        #region GetUser
        static (string Name, string LastName, int Age, bool HasPet, string[] pets, string[] favColors) GetUserData()
        {
            (string Name, string LastName, int Age, bool HasPet, string[] pets, string[] favColors) user;

            user.Name = GetName();
            user.LastName = GetLastName();
            user.Age = GetAge();
            user.HasPet = GetHavePets();
            if (user.HasPet == true)
                user.pets = GetPetsName();
            else
                user.pets = null;

            user.favColors = GetFavColors();

            return user;
        }
        static string GetName()
        {
            Console.WriteLine("Enter your name: ");
            return Console.ReadLine();
        }
        static string GetLastName()
        {
            Console.WriteLine("Enter your last name: ");
            return Console.ReadLine();
        }
        static int GetAge()
        {
            string age;
            int intage;
            do
            {
                Console.WriteLine("Enter your age (use the digits): ");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));

            return intage;

        }
        static bool GetHavePets()
        {
            bool hasPet;

            Console.WriteLine("Have you a pet? (write: yes or no): ");
            var result = Console.ReadLine();

            if (result.ToLower() == "yes")
            {
                hasPet = true;
            }
            else
            {
                hasPet = false;
            }
            return hasPet;
        }
        static string[] GetPetsName()
        {
            string pets;
            int num;
            do
            {
                Console.WriteLine("How much pets do you have? ");
                pets = Console.ReadLine();
            } while (CheckNum(pets, out num));

            var petsName = new string[num];

            for (int i = 0; i < petsName.Length; i++)
            {
                Console.WriteLine("Enter name of your {0} pet: ", i + 1);
                petsName[i] = Console.ReadLine();
            }

            return petsName;
        }
        static string[] GetFavColors()
        {
            string colors;
            int num2;
            do
            {
                Console.WriteLine("How many favorite colors do have? (use the digits): ");
                colors = Console.ReadLine();
            } while (CheckNum(colors, out num2));

            string[] favColors = new string[num2];

            for (int i = 0; i < favColors.Length; i++)
            {
                Console.WriteLine("Enter your {0} favorite color: ", i + 1);
                favColors[i] = Console.ReadLine();
            }
            return favColors;
        }
        #endregion
        private static void ShowUserData((string Name, string LastName, int Age, bool HasPet, string[] pets, string[] favColors) user)
        {
            Console.WriteLine();
            Console.Write("Your name:\t\t{0}\n", user.Name);
            Console.Write("Your surname:\t\t{0}\n", user.LastName);
            Console.Write("Your age:\t\t{0}\n", user.Age);

            if (user.HasPet)
            {
                for (int i = 0; i < user.pets.Length; i++)
                {
                    Console.Write("Names of your {0} pet:\t{1}\n", i + 1, user.pets[i]);
                }
            }
            else
                Console.Write("No pets.\n");

            for (int i = 0; i < user.favColors.Length; i++)
            {
                Console.Write("Your {0} favorite color:\t{1}\n", i + 1, user.favColors[i]);
            }
        }
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                return true;
            }
        }
    }
}
