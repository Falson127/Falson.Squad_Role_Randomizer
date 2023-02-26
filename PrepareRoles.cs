using Blish_HUD.Controls;
using Blish_HUD.Settings;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.SquadRoleRandomizer
{
    public class PrepareRoles 
    {
        //public RoleRandomizerMain mainInstance;

        public static List<int> Length_of_Roles_Arrays;
        public static List<List<string>> GenerationSequence;
        //public static List<List<string>> ListofValidLists;
        public static List<int> intGenerationSequence = new List<int>();
        public static List<Tuple<int, string>> intRoles = new List<Tuple<int,string>>();

        //local instances of valid lists
        private readonly List<string> _handKiteValid = new List<string>();
        private readonly List<string> _oilKiteValid = new List<string>();
        private readonly List<string> _flakKiteValid = new List<string>();
        private readonly List<string> _tankValid = new List<string>();
        private readonly List<string> _healAlacValid = new List<string>();
        private readonly List<string> _healQuickValid = new List<string>();
        private readonly List<string> _dpsAlacValid = new List<string>();
        private readonly List<string> _dpsQuickValid = new List<string>();
        private readonly List<string> _mushroomValid = new List<string>();
        private readonly List<string> _towerValid = new List<string>();
        private readonly List<string> _reflectValid = new List<string>();
        private readonly List<string> _cannonValid = new List<string>();
        private readonly List<string> _construcPusherValid = new List<string>();
        private readonly List<string> _lampValid = new List<string>();
        private readonly List<string> _pylonValid = new List<string>();
        private readonly List<string> _pillarValid = new List<string>();
        private readonly List<string> _greenValid = new List<string>();
        private readonly List<string> _soullessPusherValid = new List<string>();
        private readonly List<string> _dhuumKiteValid = new List<string>();
        private readonly List<string> _qadimKiteValid = new List<string>();
        private readonly List<string> _swordValid = new List<string>();
        private readonly List<string> _shieldValid = new List<string>();
        //local instances of role settings
        private readonly SettingEntry<bool>[] _handKiteRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _oilKiteRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _flakKiteRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _tankRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _healAlacRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _healQuickRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _dpsAlacRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _dpsQuickRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _mushroomRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _towerRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _reflectRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _cannonRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _construcPusherRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _lampRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _pylonRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _pillarRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _greenRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _soullessPusherRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _dhuumKiteRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _qadimKiteRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _swordRoles = new SettingEntry<bool>[10];
        private readonly SettingEntry<bool>[] _shieldRoles = new SettingEntry<bool>[10];
        //constructor
        public PrepareRoles(List<List<string>> listOfValidLists, List<SettingEntry<bool>[]> listofSettingEntries) 
        {
            _handKiteValid = listOfValidLists[0];
            _oilKiteValid = listOfValidLists[1];
            _flakKiteValid = listOfValidLists[2];
            _tankValid = listOfValidLists[3];
            _healAlacValid = listOfValidLists[4];
            _healQuickValid = listOfValidLists[5];
            _dpsAlacValid = listOfValidLists[6];
            _dpsQuickValid = listOfValidLists[7];
            _mushroomValid = listOfValidLists[8];
            _towerValid = listOfValidLists[9];
            _reflectValid = listOfValidLists[10];
            _cannonValid = listOfValidLists[11];
            _construcPusherValid = listOfValidLists[12];
            _lampValid = listOfValidLists[13];
            _pylonValid = listOfValidLists[14];
            _pillarValid = listOfValidLists[15];
            _greenValid = listOfValidLists[16];
            _soullessPusherValid = listOfValidLists[17];
            _dhuumKiteValid = listOfValidLists[18];
            _qadimKiteValid = listOfValidLists[19];
            _swordValid = listOfValidLists[20];
            _shieldValid = listOfValidLists[21];

            _handKiteRoles = listofSettingEntries[0];
            _oilKiteRoles = listofSettingEntries[1];
            _flakKiteRoles = listofSettingEntries[2];
            _tankRoles = listofSettingEntries[3];
            _healAlacRoles = listofSettingEntries[4];
            _healQuickRoles = listofSettingEntries[5];
            _dpsAlacRoles = listofSettingEntries[6];
            _dpsQuickRoles = listofSettingEntries[7];
            _mushroomRoles = listofSettingEntries[8];
            _towerRoles = listofSettingEntries[9];
            _reflectRoles = listofSettingEntries[10];
            _cannonRoles = listofSettingEntries[11];
            _construcPusherRoles = listofSettingEntries[12];
            _lampRoles = listofSettingEntries[13];
            _pylonRoles = listofSettingEntries[14];
            _pillarRoles = listofSettingEntries[15];
            _greenRoles = listofSettingEntries[16];
            _soullessPusherRoles = listofSettingEntries[17];
            _dhuumKiteRoles = listofSettingEntries[18];
            _qadimKiteRoles = listofSettingEntries[19];
            _swordRoles = listofSettingEntries[20];
            _shieldRoles = listofSettingEntries[21];


        }
        
        public void PrepRoles()
        {
            //This method prepares the roles to pass to the randomizer. It converts the checkboxes to activated roles to randomize, loads the saved player names into the list of valid options for each role
            //and then sorts them from smallest to largest, removing any role list that has no players. This information is then stored in a list called GenerationSequence, which is passed to the randomizer
            //to be sorted one last time before the randomizer class actually performs the necessary actions to randomize a member into each role.
            intRoles.Clear();
            intGenerationSequence.Clear();
            GenerationSequence = new List<List<string>>();
            //ListofValidLists = new List<List<string>> { RoleRandomizerMain.HandKiteValid, RoleRandomizerMain.OilKiteValid, RoleRandomizerMain.FlakKiteValid, RoleRandomizerMain.TankValid, RoleRandomizerMain.HealAlacValid, RoleRandomizerMain.HealQuickValid, RoleRandomizerMain.DPSAlacValid, RoleRandomizerMain.DPSQuickValid, RoleRandomizerMain.MushroomValid, RoleRandomizerMain.TowerValid, RoleRandomizerMain.ReflectValid, RoleRandomizerMain.CannonValid, RoleRandomizerMain.ConstrucPusherValid, RoleRandomizerMain.LampValid, RoleRandomizerMain.PylonValid, RoleRandomizerMain.PillarValid, RoleRandomizerMain.GreenValid, RoleRandomizerMain.SoullessPusherValid, RoleRandomizerMain.DhuumKiteValid, RoleRandomizerMain.QadimKiteValid, RoleRandomizerMain.SwordValid, RoleRandomizerMain.ShieldValid, };
            IDictionary<CustomCheckbox, SettingEntry<bool>[]> ActiveRolesDictionary = new Dictionary<CustomCheckbox, SettingEntry<bool>[]>()
            {
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[0], RoleRandomizerMain.HandKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[1], RoleRandomizerMain.OilKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[2], RoleRandomizerMain.FlakKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[3], RoleRandomizerMain.TankRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[4], RoleRandomizerMain.HealAlacRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[5], RoleRandomizerMain.HealQuickRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[6], RoleRandomizerMain.DPSAlacRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[7], RoleRandomizerMain.DPSQuickRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[8], RoleRandomizerMain.MushroomRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[9], RoleRandomizerMain.TowerRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[10], RoleRandomizerMain.ReflectRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[11], RoleRandomizerMain.CannonRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[12], RoleRandomizerMain.ConstrucPusherRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[13], RoleRandomizerMain.LampRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[14], RoleRandomizerMain.PylonRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[15], RoleRandomizerMain.PillarRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[16], RoleRandomizerMain.GreenRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[17], RoleRandomizerMain.SoullessPusherRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[18], RoleRandomizerMain.DhuumKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[19], RoleRandomizerMain.QadimKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[20], RoleRandomizerMain.SwordRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[21], RoleRandomizerMain.ShieldRoles }
            };
            IDictionary<int, string> ArrayPos_to_PlayerNameDictionary = new Dictionary<int, string>()
            {
                {0, RoleRandomizerMain.PlayerNames[0].Value},
                {1, RoleRandomizerMain.PlayerNames[1].Value},
                {2, RoleRandomizerMain.PlayerNames[2].Value},
                {3, RoleRandomizerMain.PlayerNames[3].Value},
                {4, RoleRandomizerMain.PlayerNames[4].Value},
                {5, RoleRandomizerMain.PlayerNames[5].Value},
                {6, RoleRandomizerMain.PlayerNames[6].Value},
                {7, RoleRandomizerMain.PlayerNames[7].Value},
                {8, RoleRandomizerMain.PlayerNames[8].Value},
                {9, RoleRandomizerMain.PlayerNames[9].Value}
            };
            IDictionary<SettingEntry<bool>[], int> RolesArrays_to_ArrayListPosDictionary = new Dictionary<SettingEntry<bool>[], int>()
            {
                {RoleRandomizerMain.HandKiteRoles, 0},
                {RoleRandomizerMain.OilKiteRoles, 1},
                {RoleRandomizerMain.FlakKiteRoles, 2},
                {RoleRandomizerMain.TankRoles, 3},
                {RoleRandomizerMain.HealAlacRoles, 4},
                {RoleRandomizerMain.HealQuickRoles, 5},
                {RoleRandomizerMain.DPSAlacRoles, 6},
                {RoleRandomizerMain.DPSQuickRoles, 7},
                {RoleRandomizerMain.MushroomRoles, 8},
                {RoleRandomizerMain.TowerRoles, 9},
                {RoleRandomizerMain.ReflectRoles, 10},
                {RoleRandomizerMain.CannonRoles, 11},
                {RoleRandomizerMain.ConstrucPusherRoles, 12},
                {RoleRandomizerMain.LampRoles, 13},
                {RoleRandomizerMain.PylonRoles, 14},
                {RoleRandomizerMain.PillarRoles, 15},
                {RoleRandomizerMain.GreenRoles, 16},
                {RoleRandomizerMain.SoullessPusherRoles, 17},
                {RoleRandomizerMain.DhuumKiteRoles, 18},
                {RoleRandomizerMain.QadimKiteRoles, 19},
                {RoleRandomizerMain.SwordRoles, 20},
                {RoleRandomizerMain.ShieldRoles, 21}
            };
            IDictionary<List<string>, int> rolelistname_to_roleidentifiernumber = new Dictionary<List<string>, int>()
            {
                {RoleRandomizerMain.HandKiteValid, 0},
                {RoleRandomizerMain.OilKiteValid, 1},
                {RoleRandomizerMain.FlakKiteValid, 2},
                {RoleRandomizerMain.TankValid, 3},
                {RoleRandomizerMain.HealAlacValid, 4},
                {RoleRandomizerMain.HealQuickValid, 5},
                {RoleRandomizerMain.DPSAlacValid, 6},
                {RoleRandomizerMain.DPSQuickValid, 7},
                {RoleRandomizerMain.MushroomValid, 8},
                {RoleRandomizerMain.TowerValid, 9},
                {RoleRandomizerMain.ReflectValid, 10},
                {RoleRandomizerMain.CannonValid, 11},
                {RoleRandomizerMain.ConstrucPusherValid, 12},
                {RoleRandomizerMain.LampValid, 13},
                {RoleRandomizerMain.PylonValid, 14},
                {RoleRandomizerMain.PillarValid, 15},
                {RoleRandomizerMain.GreenValid, 16},
                {RoleRandomizerMain.SoullessPusherValid, 17},
                {RoleRandomizerMain.DhuumKiteValid, 18},
                {RoleRandomizerMain.QadimKiteValid, 19},
                {RoleRandomizerMain.SwordValid, 20},
                {RoleRandomizerMain.ShieldValid, 21}
            };
            IDictionary<SettingEntry<bool>[], List<string>> RolesArrays_to_ValidLists = new Dictionary<SettingEntry<bool>[], List<string>>()
            {
                {RoleRandomizerMain.HandKiteRoles, RoleRandomizerMain.HandKiteValid},
                {RoleRandomizerMain.OilKiteRoles,RoleRandomizerMain.OilKiteValid },
                {RoleRandomizerMain.FlakKiteRoles, RoleRandomizerMain.FlakKiteValid},
                {RoleRandomizerMain.TankRoles, RoleRandomizerMain.TankValid},
                {RoleRandomizerMain.HealAlacRoles, RoleRandomizerMain.HealAlacValid},
                {RoleRandomizerMain.HealQuickRoles,RoleRandomizerMain.HealQuickValid},
                {RoleRandomizerMain.DPSAlacRoles,RoleRandomizerMain.DPSAlacValid},
                {RoleRandomizerMain.DPSQuickRoles, RoleRandomizerMain.DPSQuickValid},
                {RoleRandomizerMain.MushroomRoles, RoleRandomizerMain.MushroomValid},
                {RoleRandomizerMain.TowerRoles, RoleRandomizerMain.TowerValid },
                {RoleRandomizerMain.ReflectRoles,RoleRandomizerMain.ReflectValid },
                {RoleRandomizerMain.CannonRoles,RoleRandomizerMain.CannonValid },
                {RoleRandomizerMain.ConstrucPusherRoles, RoleRandomizerMain.ConstrucPusherValid},
                {RoleRandomizerMain.LampRoles,  RoleRandomizerMain.LampValid},
                {RoleRandomizerMain.PylonRoles,RoleRandomizerMain.PylonValid },
                {RoleRandomizerMain.PillarRoles,RoleRandomizerMain.PillarValid },
                {RoleRandomizerMain.GreenRoles, RoleRandomizerMain.GreenValid },
                {RoleRandomizerMain.SoullessPusherRoles,RoleRandomizerMain.SoullessPusherValid },
                {RoleRandomizerMain.DhuumKiteRoles,RoleRandomizerMain.DhuumKiteValid },
                {RoleRandomizerMain.QadimKiteRoles,RoleRandomizerMain.QadimKiteValid },
                {RoleRandomizerMain.SwordRoles, RoleRandomizerMain.SwordValid },
                {RoleRandomizerMain.ShieldRoles,  RoleRandomizerMain.ShieldValid}
            };
            IDictionary<List<string>,SettingEntry<int>> rolestogeneratemultiple_to_numbertogenerate = new Dictionary<List<string>, SettingEntry<int>> 
            {
                {RoleRandomizerMain.HealAlacValid, RoleRandomizerMain.CounterBoxesSettings[0]},
                {RoleRandomizerMain.HealQuickValid,RoleRandomizerMain.CounterBoxesSettings [1]},
                {RoleRandomizerMain.DPSAlacValid,RoleRandomizerMain.CounterBoxesSettings[2] },
                {RoleRandomizerMain.DPSQuickValid,RoleRandomizerMain.CounterBoxesSettings[3]},
                {RoleRandomizerMain.MushroomValid,RoleRandomizerMain.CounterBoxesSettings[4]},
                {RoleRandomizerMain.CannonValid,RoleRandomizerMain.CounterBoxesSettings[5]},
                {RoleRandomizerMain.LampValid,RoleRandomizerMain.CounterBoxesSettings[6]},
                {RoleRandomizerMain.PylonValid,RoleRandomizerMain.CounterBoxesSettings[7]},
                {RoleRandomizerMain.PillarValid,RoleRandomizerMain.CounterBoxesSettings[8]},
                {RoleRandomizerMain.GreenValid,RoleRandomizerMain.CounterBoxesSettings[9]},
                {RoleRandomizerMain.SwordValid,RoleRandomizerMain.CounterBoxesSettings[10]},
                {RoleRandomizerMain.ShieldValid,RoleRandomizerMain.CounterBoxesSettings[11]}
            };
            GenerationSequence.Clear();
            foreach (List<string> list in ListofValidLists)
            {
                list.Clear();
            }
            for (int i = 0; i < 22; i++)
            {
                if (RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[i].Checked)
                {
                    var tempkey = RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[i];
                    var temprole = ActiveRolesDictionary[tempkey];
                    for (int s = 0; s < 10; s++)
                    {
                        if (temprole[s].Value)
                        {

                            RolesArrays_to_ValidLists[temprole].Add(ArrayPos_to_PlayerNameDictionary[s]); //adds the player that has checked true for a role to the role valid list for that particular role.
                        }
                    }
                }
            }
            var mySortedList = RoleRandomizerMain.ListofRoleValidLists.OrderBy(x => x.Count).ToList();  //sorts the populated lists by length
            foreach (List<string> item in mySortedList)
            {
                if (item.Count != 0) //only roles that have at least 1 player signed up get added to the sequence for generation
                {
                    GenerationSequence.Add(item); //converts the current (role)valid list into a string name for the role to be generated and adds to the sequence, from shortest lists to longest.
                }
            }
            foreach (var entry in GenerationSequence)
            {
                if (rolestogeneratemultiple_to_numbertogenerate.ContainsKey(entry))//check if list might need multiple
                {
                    for (int i = 0; i < rolestogeneratemultiple_to_numbertogenerate[entry].Value; i++) //if it might, get number requested
                    {
                        intGenerationSequence.Add(rolelistname_to_roleidentifiernumber[entry]); //add that role's index the number of times needed
                    }
                }
                else
                {
                    intGenerationSequence.Add(rolelistname_to_roleidentifiernumber[entry]); //if it can't accept multiple, just add it once as integer index
                }
            }

            #region build intRoles list
            foreach (var name in RoleRandomizerMain.HandKiteValid)
            {
                intRoles.Add(Tuple.Create(0, name));
            }
            foreach (var name in RoleRandomizerMain.OilKiteValid)
            {
                intRoles.Add(Tuple.Create(1, name));
            }
            foreach (var name in RoleRandomizerMain.FlakKiteValid)
            {
                intRoles.Add(Tuple.Create(2, name));
            }
            foreach (var name in RoleRandomizerMain.TankValid)
            {
                intRoles.Add(Tuple.Create(3, name));
            }
            foreach (var name in RoleRandomizerMain.HealAlacValid)
            {
                intRoles.Add(Tuple.Create(4, name));
            }
            foreach (var name in RoleRandomizerMain.HealQuickValid)
            {
                intRoles.Add(Tuple.Create(5, name));
            }
            foreach (var name in RoleRandomizerMain.DPSAlacValid)
            {
                intRoles.Add(Tuple.Create(6, name));
            }
            foreach (var name in RoleRandomizerMain.DPSQuickValid)
            {
                intRoles.Add(Tuple.Create(7, name));
            }
            foreach (var name in RoleRandomizerMain.MushroomValid)
            {
                intRoles.Add(Tuple.Create(8, name));
            }
            foreach (var name in RoleRandomizerMain.TowerValid)
            {
                intRoles.Add(Tuple.Create(9, name));
            }
            foreach (var name in RoleRandomizerMain.ReflectValid)
            {
                intRoles.Add(Tuple.Create(10, name));
            }
            foreach (var name in RoleRandomizerMain.CannonValid)
            {
                intRoles.Add(Tuple.Create(11, name));
            }
            foreach (var name in RoleRandomizerMain.ConstrucPusherValid)
            {
                intRoles.Add(Tuple.Create(12, name));
            }
            foreach (var name in RoleRandomizerMain.LampValid)
            {
                intRoles.Add(Tuple.Create(13, name));
            }
            foreach (var name in RoleRandomizerMain.PylonValid)
            {
                intRoles.Add(Tuple.Create(14, name));
            }
            foreach (var name in RoleRandomizerMain.PillarValid)
            {
                intRoles.Add(Tuple.Create(15, name));
            }
            foreach (var name in RoleRandomizerMain.GreenValid)
            {
                intRoles.Add(Tuple.Create(16, name));
            }
            foreach (var name in RoleRandomizerMain.SoullessPusherValid)
            {
                intRoles.Add(Tuple.Create(17, name));
            }
            foreach (var name in RoleRandomizerMain.DhuumKiteValid)
            {
                intRoles.Add(Tuple.Create(18, name));
            }
            foreach (var name in RoleRandomizerMain.QadimKiteValid)
            {
                intRoles.Add(Tuple.Create(19, name));
            }
            foreach (var name in RoleRandomizerMain.SwordValid)
            {
                intRoles.Add(Tuple.Create(20, name));
            }
            foreach (var name in RoleRandomizerMain.ShieldValid)
            {
                intRoles.Add(Tuple.Create(21, name));
            }
            #endregion
            var TheRandomizer = new Randomizer.RecursiveRandomizer();
            TheRandomizer.Main();
        }

        
}
    
}
