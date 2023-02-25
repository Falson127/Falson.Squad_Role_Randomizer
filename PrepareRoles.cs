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
        public RoleRandomizerMain mainInstance;

        public static List<int> Length_of_Roles_Arrays;
        public static List<List<string>> GenerationSequence;
        public static List<List<string>> ListofValidLists;
        public static List<int> intGenerationSequence = new List<int>();
        public static List<Tuple<int, string>> intRoles = new List<Tuple<int,string>>();
        public static void PrepRoles()
        {
            //This method prepares the roles to pass to the randomizer. It converts the checkboxes to activated roles to randomize, loads the saved player names into the list of valid options for each role
            //and then sorts them from smallest to largest, removing any role list that has no players. This information is then stored in a list called GenerationSequence, which is passed to the randomizer
            //to be sorted one last time before the randomizer class actually performs the necessary actions to randomize a member into each role.

            GenerationSequence = new List<List<string>>();
            ListofValidLists = new List<List<string>> { RoleRandomizerMain.HandKiteValid, RoleRandomizerMain.OilKiteValid, RoleRandomizerMain.FlakKiteValid, RoleRandomizerMain.TankValid, RoleRandomizerMain.HealAlacValid, RoleRandomizerMain.HealQuickValid, RoleRandomizerMain.DPSAlacValid, RoleRandomizerMain.DPSQuickValid, RoleRandomizerMain.MushroomValid, RoleRandomizerMain.TowerValid, RoleRandomizerMain.ReflectValid, RoleRandomizerMain.CannonValid, RoleRandomizerMain.ConstrucPusherValid, RoleRandomizerMain.LampValid, RoleRandomizerMain.PylonValid, RoleRandomizerMain.PillarValid, RoleRandomizerMain.GreenValid, RoleRandomizerMain.SoullessPusherValid, RoleRandomizerMain.DhuumKiteValid, RoleRandomizerMain.QadimKiteValid, RoleRandomizerMain.SwordValid, RoleRandomizerMain.ShieldValid, };
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
                    intGenerationSequence.Add(rolelistname_to_roleidentifiernumber[item]); //new standard, GenSequence above will depreciate once RR.cs is done
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
