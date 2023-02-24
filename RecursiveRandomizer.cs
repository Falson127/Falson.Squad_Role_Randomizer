using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.Randomizer
{
    public class RecursiveRandomizer 
    {
        private int[,] _conflicts = new int[22,22];

        private void setconflicts()
        {
            //start with no conflicts
            for (int i = 0; i < 22; i++)
            {
                for (int s = 0; s < 22; s++)
                {
                    _conflicts[i, s] = 0;
                }
            }
            //add conflicts only where needed
            #region handkite conflicts
            _conflicts[0, 1] = 1;
            _conflicts[0, 3] = 1;
            _conflicts[0, 4] = 1;
            _conflicts[0, 5] = 1;
            _conflicts[0, 6] = 1;
            _conflicts[0, 7] = 1;
            #endregion
            #region OilKite conflicts
            _conflicts[1,0] = 1;
            _conflicts[1,3] = 1;
            #endregion
            #region FlakKite conflicts
            _conflicts[2, 11] = 1;
            #endregion
            #region Tank conflicts
            _conflicts[3,0] = 1;
            _conflicts[3,1] = 1;
            _conflicts[3,6] = 1;
            _conflicts[3,7] = 1;
            #endregion
            #region HealAlac conflicts
            _conflicts[4,0] = 1;
            _conflicts[4,5] = 1;
            _conflicts[4, 6] = 1;
            _conflicts[4,7] = 1;
            _conflicts[4,8] = 1;
            _conflicts[4, 10] = 1;
            _conflicts[4, 13] = 1;
            _conflicts[4,14] = 1;
            _conflicts[4, 16] = 1;
            _conflicts[4, 17] = 1;
            _conflicts[4, 18] = 1;
            _conflicts[4, 19] = 1;
            #endregion
            #region HealQuick conflicts
            _conflicts[5,0] = 1;
            _conflicts[5,4] = 1;
            _conflicts[5,6] = 1;
            _conflicts[5,7] = 1;
            _conflicts[5,8] = 1;
            _conflicts[5, 10] = 1;
            _conflicts[5,13] = 1;
            _conflicts[5,14] = 1;
            _conflicts[5,16] = 1;
            _conflicts[5,17] = 1;
            _conflicts[5,18] = 1;
            _conflicts[5,19] = 1;
            #endregion
            #region DPSAlac conflicts
            _conflicts[6,0] = 1;
            _conflicts[6,4] = 1;
            _conflicts[6,5] = 1;
            _conflicts[6,7] = 1;
            _conflicts[6,13] = 1;
            _conflicts[6,14] = 1;
            _conflicts[6,16] = 1;
            _conflicts[6,17] = 1;
            _conflicts[6,18] = 1;
            _conflicts[6,19] = 1;
            #endregion
            #region DPSQuick conflicts
            _conflicts[7,0] = 1;
            _conflicts[7,4] = 1;
            _conflicts[7,5] = 1;
            _conflicts[7,6] = 1;
            _conflicts[7,13] = 1;
            _conflicts[7,14] = 1;
            _conflicts[7,16] = 1;
            _conflicts[7,17] = 1;
            _conflicts[7,18] = 1;
            _conflicts[7,19] = 1;
            #endregion
            #region Mushroom conflicts
            _conflicts[8,4] = 1;
            _conflicts[8,5] = 1;
            #endregion
            #region Reflect conflicts
            _conflicts[10,4] = 1;
            _conflicts[10,5] = 1;
            #endregion
            #region Cannon conflicts
            _conflicts[11,4] = 1;
            _conflicts[11,5] = 1;
            #endregion
            #region Lamp conflicts
            _conflicts[13,4] = 1;
            _conflicts[13,5] = 1;
            _conflicts[13,6] = 1;
            _conflicts[13,7] = 1;
            _conflicts[13,19] = 1;
            #endregion
            #region Pylon conflicts
            _conflicts[14,4] = 1;
            _conflicts[14,5] = 1;
            _conflicts[14,6] = 1;
            _conflicts[14,7] = 1;
            _conflicts[14,3] = 1;
            #endregion
            #region Pillar conflicts
            _conflicts[15,3] = 1;
            #endregion
            #region Green conflicts
            _conflicts[16,3] = 1;
            _conflicts[16,4] = 1;
            _conflicts[16,5] = 1;
            _conflicts[16,6] = 1;
            _conflicts[16,7] = 1;
            #endregion
            #region SH Pusher conflicts
            _conflicts[17,3] = 1;
            _conflicts[17,4] = 1;
            _conflicts[17,5] = 1;
            _conflicts[17,6] = 1;
            _conflicts[17,7] = 1;
            #endregion
            #region DhuumKite conflict
            _conflicts[18,3] = 1;
            _conflicts[18,4] = 1;
            _conflicts[18,5] = 1;
            _conflicts[18,6] = 1;
            _conflicts[18,7] = 1;
            _conflicts[18,16] = 1;
            #endregion
            #region QadimKite conflicts
            _conflicts[19,3] = 1;
            _conflicts[19,4] = 1;
            _conflicts[19,5] = 1;
            _conflicts[19,6] = 1;
            _conflicts[19,7] = 1;
            _conflicts[19,13] = 1;
            #endregion
            #region Sword conflicts
            _conflicts[20, 4] = 1;
            _conflicts[20,5] = 1;
            #endregion
            #region Shield conflicts
            _conflicts[21,4] = 1;
            _conflicts[21,5] = 1;
            #endregion
        }
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
