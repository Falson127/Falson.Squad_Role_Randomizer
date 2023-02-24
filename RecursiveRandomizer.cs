using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.Randomizer
{
    public class RecursiveRandomizer 
    {
        
    }

    //0 HandKiteValid 
    //1 OilKiteValid 
    //2 FlakKiteValid
    //3 TankValid 
    //4 HealAlacValid
    //5 HealQuickValid
    //6 DPSAlacValid 
    //7 DPSQuickValid
    //8 MushroomValid
    //9 TowerValid 
    //10 ReflectValid
    //11 CannonValid
    //12 ConstrucPusherValid
    //13 LampValid 
    //14 PylonValid
    //15 PillarValid
    //16 GreenValid 
    //17 SoullessPusherValid
    //18 DhuumKiteValid 
    //19 QadimKiteValid 
    //20 SwordValid 
    //21 ShieldValid 
    class Program
    {
        // Define the roles and conflicts
        static string[] Roles = Enumerable.Range(0, 22).Select(i => $"role{i}").ToArray();
        static int[,] Conflicts = new int[22, 22];
        // set conflicts between roles (for example)
        static void SetConflicts(int[,] conflicts)
        {
            conflicts[0, 1] = 1;
            conflicts[1, 0] = 1;
        }

        static bool CanAssign(string person, int role, string[] assignments)
        {
            // Check if the person can be assigned to the role
            for (int i = 0; i < assignments.Length; i++)
            {
                if (Conflicts[i, role] == 1 && assignments[i] == person)
                    return false;
                if (assignments[i] == person && i != role)
                    return false;
            }
            return true;
        }

        static bool AssignRoles(int roleIndex, List<string> assignments, List<string> availablePeople)
        {
            // Recursive function to assign people to roles
            if (roleIndex >= Roles.Length)
                return true;
            availablePeople.Shuffle();
            foreach (var person in availablePeople)
            {
                if (CanAssign(person, roleIndex, assignments.ToArray()))
                {
                    assignments.Add(person);
                    var remainingPeople = availablePeople.Where(p => p != person).ToList();
                    if (AssignRoles(roleIndex + 1, assignments, remainingPeople))
                        return true;
                    assignments.RemoveAt(assignments.Count - 1);
                }
            }
            return false;
        }

        static void Main()
        {
            SetConflicts(Conflicts);

            var availablePeople = Enumerable.Range(0, 10).Select(i => $"person{i}").ToList();
            availablePeople.Shuffle();
            var assignments = new List<string>();

            if (AssignRoles(0, assignments, availablePeople))
            {
                for (int i = 0; i < assignments.Count; i++)
                {
                    Console.WriteLine($"Role {Roles[i]} assigned to {assignments[i]}");
                }
            }
            else
            {
                Console.WriteLine("No valid assignments found.");
            }
        }
    }

    // Extension method to shuffle a list
    static class ListExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

}
