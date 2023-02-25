using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using falsonP = Falson.SquadRoleRandomizer.PrepareRoles;
using Falson.SquadRoleRandomizer;

namespace Falson.Randomizer
{
    public class RecursiveRandomizer
    {
        private int[,] _conflicts = new int[22, 22]; //format: [x,y] x=role of interest, y=test role. If [x,y] = 0, then role y does not conflcit with x. if = 1, then role y does conflict with x
        private List<Tuple<int, string>> _roles = new List<Tuple<int, string>>();
        private List<int> _generationsequence = new List<int>();
        public static List<Tuple<int, string>> _assignedRoles = new List<Tuple<int, string>>();
        public IDictionary<string, string> RoleName_to_SelectedPlayer = new Dictionary<string, string>();
        public IDictionary<string, string> HoTMechanic_to_SelectedPlayer = new Dictionary<string, string>();
        public IDictionary<string, string> PoFMechanic_to_SelectedPlayer = new Dictionary<string, string>();
        int roleindex = 0;
  
        public void Main()
        {
            _roles.Clear();
            _generationsequence.Clear();
            setconflicts();
            _roles = falsonP.intRoles;
            _generationsequence = falsonP.intGenerationSequence;
            AssignRoles(roleindex,_roles,_assignedRoles);
            var Cleaner = new ResultsCleaner();
            Cleaner.Main();
        }

        private bool IsAssignmentValid(int roleIndex, string person, List<Tuple<int, string>> assignedRoles)
        {
            // Check if the person has already been assigned to a conflicting role
            if (assignedRoles.Any(a => _conflicts[a.Item1, roleIndex] == 1 && a.Item2 == person))
            {
                return false;
            }

            // Check if any other assigned person has already been assigned to this role
            if (assignedRoles.Any(a => a.Item1 == roleIndex && a.Item2 != person))
            {
                return false;
            }

            return true;
        }

        private bool AssignRoles(int roleIndex, List<Tuple<int, string>> availablePeople, List<Tuple<int, string>> assignedRoles)
        {
            if (roleIndex == _generationsequence.Count)
            {
                return true; // All roles have been assigned
            }

            int nextRoleIndex = _generationsequence[roleIndex];

            var roleAvailablePeople = availablePeople.Where(ap => ap.Item1 == nextRoleIndex).Select(ap => ap.Item2).ToList();

            ShuffleList(roleAvailablePeople);

            foreach (var person in roleAvailablePeople)
            {
                if (IsAssignmentValid(nextRoleIndex, person, assignedRoles))
                {
                    assignedRoles.Add(Tuple.Create(nextRoleIndex, person));
                    availablePeople.RemoveAll(ap => ap.Item1 == nextRoleIndex && ap.Item2 == person);

                    if (AssignRoles(roleIndex + 1, availablePeople, assignedRoles))
                    {
                        return true; // Successfully assigned all roles
                    }
                    else
                    {
                        assignedRoles.RemoveAt(assignedRoles.Count - 1);
                        availablePeople.Add(Tuple.Create(nextRoleIndex, person));
                    }
                }
            }

            return false; // Couldn't assign the current role
        }
        private void ShuffleList<T>(List<T> list)
        {
            var rng = new Random();
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
            _conflicts[1, 0] = 1;
            _conflicts[1, 3] = 1;
            #endregion
            #region FlakKite conflicts
            _conflicts[2, 11] = 1;
            #endregion
            #region Tank conflicts
            _conflicts[3, 0] = 1;
            _conflicts[3, 1] = 1;
            _conflicts[3, 6] = 1;
            _conflicts[3, 7] = 1;
            #endregion
            #region HealAlac conflicts
            _conflicts[4, 0] = 1;
            _conflicts[4, 5] = 1;
            _conflicts[4, 6] = 1;
            _conflicts[4, 7] = 1;
            _conflicts[4, 8] = 1;
            _conflicts[4, 10] = 1;
            _conflicts[4, 13] = 1;
            _conflicts[4, 14] = 1;
            _conflicts[4, 16] = 1;
            _conflicts[4, 17] = 1;
            _conflicts[4, 18] = 1;
            _conflicts[4, 19] = 1;
            #endregion
            #region HealQuick conflicts
            _conflicts[5, 0] = 1;
            _conflicts[5, 4] = 1;
            _conflicts[5, 6] = 1;
            _conflicts[5, 7] = 1;
            _conflicts[5, 8] = 1;
            _conflicts[5, 10] = 1;
            _conflicts[5, 13] = 1;
            _conflicts[5, 14] = 1;
            _conflicts[5, 16] = 1;
            _conflicts[5, 17] = 1;
            _conflicts[5, 18] = 1;
            _conflicts[5, 19] = 1;
            #endregion
            #region DPSAlac conflicts
            _conflicts[6, 0] = 1;
            _conflicts[6, 4] = 1;
            _conflicts[6, 5] = 1;
            _conflicts[6, 7] = 1;
            _conflicts[6, 13] = 1;
            _conflicts[6, 14] = 1;
            _conflicts[6, 16] = 1;
            _conflicts[6, 17] = 1;
            _conflicts[6, 18] = 1;
            _conflicts[6, 19] = 1;
            #endregion
            #region DPSQuick conflicts
            _conflicts[7, 0] = 1;
            _conflicts[7, 4] = 1;
            _conflicts[7, 5] = 1;
            _conflicts[7, 6] = 1;
            _conflicts[7, 13] = 1;
            _conflicts[7, 14] = 1;
            _conflicts[7, 16] = 1;
            _conflicts[7, 17] = 1;
            _conflicts[7, 18] = 1;
            _conflicts[7, 19] = 1;
            #endregion
            #region Mushroom conflicts
            _conflicts[8, 4] = 1;
            _conflicts[8, 5] = 1;
            #endregion
            #region Reflect conflicts
            _conflicts[10, 4] = 1;
            _conflicts[10, 5] = 1;
            #endregion
            #region Cannon conflicts
            _conflicts[11, 4] = 1;
            _conflicts[11, 5] = 1;
            #endregion
            #region Lamp conflicts
            _conflicts[13, 4] = 1;
            _conflicts[13, 5] = 1;
            _conflicts[13, 6] = 1;
            _conflicts[13, 7] = 1;
            _conflicts[13, 19] = 1;
            #endregion
            #region Pylon conflicts
            _conflicts[14, 4] = 1;
            _conflicts[14, 5] = 1;
            _conflicts[14, 6] = 1;
            _conflicts[14, 7] = 1;
            _conflicts[14, 3] = 1;
            #endregion
            #region Pillar conflicts
            _conflicts[15, 3] = 1;
            #endregion
            #region Green conflicts
            _conflicts[16, 3] = 1;
            _conflicts[16, 4] = 1;
            _conflicts[16, 5] = 1;
            _conflicts[16, 6] = 1;
            _conflicts[16, 7] = 1;
            #endregion
            #region SH Pusher conflicts
            _conflicts[17, 3] = 1;
            _conflicts[17, 4] = 1;
            _conflicts[17, 5] = 1;
            _conflicts[17, 6] = 1;
            _conflicts[17, 7] = 1;
            #endregion
            #region DhuumKite conflict
            _conflicts[18, 3] = 1;
            _conflicts[18, 4] = 1;
            _conflicts[18, 5] = 1;
            _conflicts[18, 6] = 1;
            _conflicts[18, 7] = 1;
            _conflicts[18, 16] = 1;
            #endregion
            #region QadimKite conflicts
            _conflicts[19, 3] = 1;
            _conflicts[19, 4] = 1;
            _conflicts[19, 5] = 1;
            _conflicts[19, 6] = 1;
            _conflicts[19, 7] = 1;
            _conflicts[19, 13] = 1;
            #endregion
            #region Sword conflicts
            _conflicts[20, 4] = 1;
            _conflicts[20, 5] = 1;
            #endregion
            #region Shield conflicts
            _conflicts[21, 4] = 1;
            _conflicts[21, 5] = 1;
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

    public class Program
    {
        private static readonly int[,] Conflicts = new int[22, 22];

        private static bool IsAssignmentValid(int roleIndex, string person, List<Tuple<int, string>> assignedRoles)
        {
            // Check if the person has already been assigned to a conflicting role
            if (assignedRoles.Any(a => Conflicts[a.Item1, roleIndex] == 1 && a.Item2 == person))
            {
                return false;
            }

            // Check if any other assigned person has already been assigned to this role
            if (assignedRoles.Any(a => a.Item1 == roleIndex && a.Item2 != person))
            {
                return false;
            }

            return true;
        }

        private static bool AssignRoles(int roleIndex, List<Tuple<int, string>> availablePeople, List<Tuple<int, string>> assignedRoles)
        {
            if (roleIndex >= assignedRoles.Count)
            {
                return true; // All roles have been assigned
            }

            var roleAvailablePeople = availablePeople.Where(ap => ap.Item1 == roleIndex).Select(ap => ap.Item2).ToList();

            ShuffleList(roleAvailablePeople);

            foreach (var person in roleAvailablePeople)
            {
                if (IsAssignmentValid(roleIndex, person, assignedRoles))
                {
                    assignedRoles.Add(Tuple.Create(roleIndex, person));
                    availablePeople.RemoveAll(ap => ap.Item1 == roleIndex && ap.Item2 == person);

                    if (AssignRoles(roleIndex + 1, availablePeople, assignedRoles))
                    {
                        return true; // Successfully assigned all roles
                    }

                    assignedRoles.RemoveAt(assignedRoles.Count - 1);
                    availablePeople.Add(Tuple.Create(roleIndex, person));
                }
            }

            return false; // Couldn't assign the current role
        }

        private static void ShuffleList<T>(List<T> list)
        {
            var rng = new Random();
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

        public static void Main()
        {
            // Define available people for each role
            var availablePeople = new List<Tuple<int, string>>();
            availablePeople.Add(Tuple.Create(0, "Person 1"));
            availablePeople.Add(Tuple.Create(0, "Person 2"));
            availablePeople.Add(Tuple.Create(0, "Person 3"));
            // Add available people for other roles...

            // Assign the roles
            var assignedRoles = new List<Tuple<int, string>>();
            AssignRoles(0, availablePeople, assignedRoles);

            // Output the assigned roles
            foreach (var assignment in assignedRoles)
            {
                Console.WriteLine($"Role {assignment.Item1}: {assignment.Item2}");
            }
        }
    }
}

