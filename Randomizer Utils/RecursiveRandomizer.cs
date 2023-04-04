using System;
using System.Collections.Generic;
using System.Linq;
using falson = Falson.SquadRoleRandomizer.RoleRandomizerMain;
using Blish_HUD.Controls;
using Falson.SquadRoleRandomizer;


namespace Falson.Randomizer
{
    public class RecursiveRandomizer
    {
        private int[,] _conflicts = new int[23, 23]; //format: [x,y] x=role of interest, y=test role. If [x,y] = 0, then role y does not conflcit with x. if = 1, then role y does conflict with x
        private List<Tuple<int, string>> _roles = new List<Tuple<int, string>>();
        private List<int> _generationsequence = new List<int>();
        private List<Tuple<int, string>> _assignedRoles;
        public IDictionary<string, string> RoleName_to_SelectedPlayer = new Dictionary<string, string>();
        public IDictionary<string, string> HoTMechanic_to_SelectedPlayer = new Dictionary<string, string>();
        public IDictionary<string, string> PoFMechanic_to_SelectedPlayer = new Dictionary<string, string>();
        private readonly List<Tuple<int,bool>> _rolesToGenerate = new List<Tuple<int,bool>>();
        private readonly int[] _counterboxsettings = new int[12];
        private readonly int _numberOfPlayers;

        public RecursiveRandomizer(List<Tuple<int,string>> intRoles, List<int> intGenSequence, List<Tuple<int,bool>> rolestogenerate, int[] counterboxsettings, bool[] playersIncluded) 
        {
            _roles = intRoles;
            _generationsequence = intGenSequence;
            _rolesToGenerate = rolestogenerate;
            _counterboxsettings = counterboxsettings;
            _numberOfPlayers = 0;
            foreach (var player in playersIncluded)
            {
                if (player)
                {
                    _numberOfPlayers++;
                }
            }
        }
        private bool SanityCheck()
        {
            IDictionary<int, int> roleChecked_to_numberofplayers = new Dictionary<int, int>() //key is the role that was checked within a given 
            {
                {0, 1},
                {1, 1},
                {2, 1},
                {3, 1},
                {4, _counterboxsettings[0]},
                {5, _counterboxsettings[1]},
                {6, _counterboxsettings[2]},
                {7, _counterboxsettings[3]},
                {8, _counterboxsettings[4]},
                {9, 1},
                {10, 1},
                {11, _counterboxsettings[5]},
                {12, 1},
                {13, _counterboxsettings[6]},
                {14, _counterboxsettings[7]},
                {15, _counterboxsettings[8]},
                {16, _counterboxsettings[9]},
                {17, 1},
                {18, 1},
                {19, 1},
                {20, _counterboxsettings[10]},
                {21, _counterboxsettings[11]},
                {22, 1 }
            };
            IDictionary<int, bool> conflictRoleIndex_to_RoleChecked = new Dictionary<int, bool> 
            {
                {0, _rolesToGenerate[0].Item2},
                {1, _rolesToGenerate[1].Item2},
                {2, _rolesToGenerate[2].Item2},
                {3, _rolesToGenerate[3].Item2},
                {4, _rolesToGenerate[4].Item2},
                {5, _rolesToGenerate[5].Item2},
                {6, _rolesToGenerate[6].Item2},
                {7, _rolesToGenerate[7].Item2},
                {8, _rolesToGenerate[8].Item2},
                {9, _rolesToGenerate[9].Item2},
                {10, _rolesToGenerate[10].Item2},
                {11, _rolesToGenerate[11].Item2},
                {12, _rolesToGenerate[12].Item2},
                {13, _rolesToGenerate[13].Item2},
                {14, _rolesToGenerate[14].Item2},
                {15, _rolesToGenerate[15].Item2},
                {16, _rolesToGenerate[16].Item2},
                {17, _rolesToGenerate[17].Item2},
                {18, _rolesToGenerate[18].Item2},
                {19, _rolesToGenerate[19].Item2},
                {20, _rolesToGenerate[20].Item2},
                {21, _rolesToGenerate[21].Item2},
                {22, _rolesToGenerate[22].Item2}
            };
            for (int i = 0; i < 23; i++)
            {
                var _roleConflictBubblePlayerCount = 0;
                for (int j = 0; j < 23; j++)
                {
                    if (_conflicts[i,j] == 1 || i == j) //only execute the check and addition if the given roles i and j are in conflict with each other or if i and j are the same, that way the role itself is included for consideration.
                    {
                        if (conflictRoleIndex_to_RoleChecked[j]) //here we need to pass j into a dictionary that checks whether that specific role is enabled for generation, and if it is, we get the number requested.
                        {
                            _roleConflictBubblePlayerCount = _roleConflictBubblePlayerCount + roleChecked_to_numberofplayers[j]; //gets number needed for role J and adds it to number of roles requested that conflict with role i.
                        }
                    }
                }
                if (i==4 || i==5 || i==6 || i==7) //ignore the sanity checker for healalac/quick and dpsalac/quick. I think this will just give them priority, and if they cause any other roles to deplete it will still be caught, so should be fine?
                {
                    continue;
                }
                if (_roleConflictBubblePlayerCount > _numberOfPlayers)
                {
                    return false; //if a single conflict bubble requests more than 10 players, function will return false.
                }
            }
            return true; //if the code makes it through all 22 conflict bubbles without the _roleConflictBubblePlayerCount exceeding the number of players, then it returns true
        }
        public void Main()
        {
            falson.ResultsFlowPanel.ClearChildren();
            _assignedRoles = new List<Tuple<int, string>>();
            setconflicts();
            int roleindex = 0;
            if (SanityCheck()) //if sanity check passes, attempt randomization
            {
                if (AssignRoles(roleindex, _roles, _assignedRoles))
                {
                    var Cleaner = new ResultsCleaner(_assignedRoles);
                    Cleaner.Main();
                    UnloadRandomizer();
                }
                else
                {
                    Label templabel = new Label()
                    {
                        Text = "The Randomizer failed to find a valid composition based on your configured settings. \nTry decreasing the number of roles being generated or increasing \nthe number of players signed up for each role.",
                        Parent = falson.ResultsFlowPanel,
                        AutoSizeWidth = true,
                        AutoSizeHeight = true
                    };
                }
            }
            else
            {
                Label templabel = new Label()
                {
                    Text = "Your configuration is invalid. You have requested to generate more than the total # of available players" +
                    "\nwithin at least one group of conflicting roles. The only solutions are to reduce" +
                    "\nthe number of roles requested by unchecking boxes in 'roles to be randomized', reducing the" +
                    "\nnumber requested in the counter boxes, or 'un-disabling' players if you have done so" +
                    "\n\nPlease feel free to reach out on the Blish HUD Discord for more information on this error.",
                    Parent = falson.ResultsFlowPanel,
                    AutoSizeWidth = true,
                    AutoSizeHeight = true
                };
            }
        }
        private void UnloadRandomizer() 
        {
            //_assignedRoles = null;
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
                //return false;
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
            for (int i = 0; i < 23; i++)
            {
                for (int s = 0; s < 23; s++)
                {
                    _conflicts[i, s] = 0;
                }
            }
            //add conflicts only where needed
            #region handkite conflicts (Need to check sanity)
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
            _conflicts[3, 22] = 1;
            _conflicts[22,0] = 1;
            _conflicts[22,1] = 1;
            _conflicts[22, 6] = 1;
            _conflicts[22, 7] = 1;
            _conflicts[22, 3] = 1;
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
            #region Lamp conflicts (need to check sanity)
            _conflicts[13, 4] = 1;
            _conflicts[13, 5] = 1;
            _conflicts[13, 6] = 1;
            _conflicts[13, 7] = 1;
            _conflicts[13, 19] = 1;
            #endregion
            #region Pylon conflicts (need to check sanity)
            _conflicts[14, 3] = 1;
            _conflicts[14, 4] = 1;
            _conflicts[14, 5] = 1;
            _conflicts[14, 6] = 1;
            _conflicts[14, 7] = 1;
            #endregion
            #region Pillar conflicts
            _conflicts[15, 3] = 1;
            #endregion
            #region Green conflicts (need to check sanity)
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
            #region DhuumKite conflict (need to check sanity)
            _conflicts[18, 3] = 1;
            _conflicts[18, 4] = 1;
            _conflicts[18, 5] = 1;
            _conflicts[18, 6] = 1;
            _conflicts[18, 7] = 1;
            _conflicts[18, 16] = 1;
            #endregion
            #region QadimKite conflicts (need to check sanity)
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
            _conflicts[20, 21] = 1;
            #endregion
            #region Shield conflicts
            _conflicts[21, 4] = 1;
            _conflicts[21, 5] = 1;
            _conflicts[21, 20] = 1;
            #endregion
        }

    }
    //0 HandKiteValid 
    //1 OilKiteValid 
    //2 FlakKiteValid
    //3 TankAlacValid 
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
    //22 TankQuickValid
}

