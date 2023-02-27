﻿using Blish_HUD.Controls;
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

        //public static List<int> Length_of_Roles_Arrays;
        public static List<List<string>> GenerationSequence;
        private List<List<string>> _listOfValidLists;
        public static List<int> intGenerationSequence = new List<int>();
        public static List<Tuple<int, string>> intRoles = new List<Tuple<int,string>>();
        IDictionary<bool, SettingEntry<bool>[]> ActiveRolesDictionary = new Dictionary<bool, SettingEntry<bool>[]>();
        IDictionary<SettingEntry<bool>[], int> RolesArrays_to_ArrayListPosDictionary = new Dictionary<SettingEntry<bool>[], int>();
        IDictionary<SettingEntry<bool>[], List<string>> RolesArrays_to_ValidLists = new Dictionary<SettingEntry<bool>[], List<string>>();
        IDictionary<List<string>, SettingEntry<int>> rolestogeneratemultiple_to_numbertogenerate = new Dictionary<List<string>, SettingEntry<int>>();
        IDictionary<List<string>, int> rolelistname_to_roleidentifiernumber = new Dictionary<List<string>, int>();
        IDictionary<int, string> ArrayPos_to_PlayerNameDictionary = new Dictionary<int, string>();


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
        private readonly SettingEntry<bool>[] _rolesToGenerate = new SettingEntry<bool>[22];
        private readonly SettingEntry<int>[] _counterBoxSettings = new SettingEntry<int>[12];
        private readonly SettingEntry<string>[] _playerNames = new SettingEntry<string>[10];
        //constructor
        public PrepareRoles(List<List<string>> listOfValidLists, List<SettingEntry<bool>[]> listofSettingEntries, SettingEntry<bool>[] rolesToGenerateSettings, SettingEntry<int>[] counterboxsettings, SettingEntry<string>[] playerNames) 
        {
            _playerNames = playerNames;
            _rolesToGenerate = rolesToGenerateSettings;
            _counterBoxSettings = counterboxsettings;

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

        private void Main() 
        {
            FillDictionaries();
            PrepRoles();
        }

        public void FillDictionaries() 
        {
            ActiveRolesDictionary.Add(_rolesToGenerate[0].Value, _handKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[1].Value, _oilKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[2].Value, _flakKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[3].Value, _tankRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[4].Value, _healAlacRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[5].Value, _healQuickRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[6].Value, _dpsAlacRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[7].Value, _dpsQuickRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[8].Value, _mushroomRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[9].Value, _towerRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[10].Value, _reflectRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[11].Value, _cannonRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[12].Value, _construcPusherRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[13].Value, _lampRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[14].Value, _pylonRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[15].Value, _pillarRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[16].Value, _greenRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[17].Value, _soullessPusherRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[18].Value, _dhuumKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[19].Value, _qadimKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[20].Value, _swordRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[21].Value, _shieldRoles);
            RolesArrays_to_ArrayListPosDictionary.Add(_handKiteRoles, 0);
            RolesArrays_to_ArrayListPosDictionary.Add(_oilKiteRoles, 1);
            RolesArrays_to_ArrayListPosDictionary.Add(_flakKiteRoles, 2);
            RolesArrays_to_ArrayListPosDictionary.Add(_tankRoles, 3);
            RolesArrays_to_ArrayListPosDictionary.Add(_healAlacRoles, 4);
            RolesArrays_to_ArrayListPosDictionary.Add(_healQuickRoles, 5);
            RolesArrays_to_ArrayListPosDictionary.Add(_dpsAlacRoles, 6);
            RolesArrays_to_ArrayListPosDictionary.Add(_dpsQuickRoles, 7);
            RolesArrays_to_ArrayListPosDictionary.Add(_mushroomRoles, 8);
            RolesArrays_to_ArrayListPosDictionary.Add(_towerRoles, 9);
            RolesArrays_to_ArrayListPosDictionary.Add(_reflectRoles, 10);
            RolesArrays_to_ArrayListPosDictionary.Add(_cannonRoles, 11);
            RolesArrays_to_ArrayListPosDictionary.Add(_construcPusherRoles, 12);
            RolesArrays_to_ArrayListPosDictionary.Add(_lampRoles, 13);
            RolesArrays_to_ArrayListPosDictionary.Add(_pylonRoles, 14);
            RolesArrays_to_ArrayListPosDictionary.Add(_pillarRoles, 15);
            RolesArrays_to_ArrayListPosDictionary.Add(_greenRoles, 16);
            RolesArrays_to_ArrayListPosDictionary.Add(_soullessPusherRoles, 17);
            RolesArrays_to_ArrayListPosDictionary.Add(_dhuumKiteRoles, 18);
            RolesArrays_to_ArrayListPosDictionary.Add(_qadimKiteRoles, 19);
            RolesArrays_to_ArrayListPosDictionary.Add(_swordRoles, 20);
            RolesArrays_to_ArrayListPosDictionary.Add(_shieldRoles, 21);
            RolesArrays_to_ValidLists.Add(_handKiteRoles, _handKiteValid);
            RolesArrays_to_ValidLists.Add(_oilKiteRoles, _oilKiteValid );
            RolesArrays_to_ValidLists.Add(_flakKiteRoles,  _flakKiteValid);
            RolesArrays_to_ValidLists.Add(_tankRoles,  _tankValid);
            RolesArrays_to_ValidLists.Add(_healAlacRoles,  _healAlacValid);
            RolesArrays_to_ValidLists.Add(_healQuickRoles, _healQuickValid);
            RolesArrays_to_ValidLists.Add(_dpsAlacRoles, _dpsAlacValid);
            RolesArrays_to_ValidLists.Add(_dpsQuickRoles,  _dpsQuickValid);
            RolesArrays_to_ValidLists.Add(_mushroomRoles,  _mushroomValid);
            RolesArrays_to_ValidLists.Add(_towerRoles,  _towerValid );
            RolesArrays_to_ValidLists.Add(_reflectRoles, _reflectValid );
            RolesArrays_to_ValidLists.Add(_cannonRoles, _cannonValid );
            RolesArrays_to_ValidLists.Add(_construcPusherRoles,  _construcPusherValid);
            RolesArrays_to_ValidLists.Add(_lampRoles,   _lampValid);
            RolesArrays_to_ValidLists.Add(_pylonRoles, _pylonValid );
            RolesArrays_to_ValidLists.Add(_pillarRoles, _pillarValid );
            RolesArrays_to_ValidLists.Add(_greenRoles,  _greenValid );
            RolesArrays_to_ValidLists.Add(_soullessPusherRoles, _soullessPusherValid );
            RolesArrays_to_ValidLists.Add(_dhuumKiteRoles, _dhuumKiteValid );
            RolesArrays_to_ValidLists.Add(_qadimKiteRoles, _qadimKiteValid );
            RolesArrays_to_ValidLists.Add(_swordRoles,  _swordValid );
            RolesArrays_to_ValidLists.Add(_shieldRoles, _shieldValid);
            rolestogeneratemultiple_to_numbertogenerate.Add(_healAlacValid, _counterBoxSettings[0]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_healQuickValid, _counterBoxSettings [1]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_dpsAlacValid, _counterBoxSettings[2] );
            rolestogeneratemultiple_to_numbertogenerate.Add(_dpsQuickValid, _counterBoxSettings[3]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_mushroomValid, _counterBoxSettings[4]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_cannonValid, _counterBoxSettings[5]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_lampValid, _counterBoxSettings[6]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_pylonValid, _counterBoxSettings[7]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_pillarValid, _counterBoxSettings[8]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_greenValid, _counterBoxSettings[9]);
            rolestogeneratemultiple_to_numbertogenerate.Add(_swordValid, _counterBoxSettings[10]);
            rolestogeneratemultiple_to_numbertogenerate.Add( _shieldValid, _counterBoxSettings[11]);     
            rolelistname_to_roleidentifiernumber.Add(_handKiteValid, 0);
            rolelistname_to_roleidentifiernumber.Add(_oilKiteValid, 1);
            rolelistname_to_roleidentifiernumber.Add(_flakKiteValid, 2);
            rolelistname_to_roleidentifiernumber.Add(_tankValid, 3);
            rolelistname_to_roleidentifiernumber.Add(_healAlacValid, 4);
            rolelistname_to_roleidentifiernumber.Add(_healQuickValid, 5);
            rolelistname_to_roleidentifiernumber.Add(_dpsAlacValid, 6);
            rolelistname_to_roleidentifiernumber.Add(_dpsQuickValid, 7);
            rolelistname_to_roleidentifiernumber.Add(_mushroomValid, 8);
            rolelistname_to_roleidentifiernumber.Add(_towerValid, 9);
            rolelistname_to_roleidentifiernumber.Add(_reflectValid, 10);
            rolelistname_to_roleidentifiernumber.Add(_cannonValid, 11);
            rolelistname_to_roleidentifiernumber.Add(_construcPusherValid, 12);
            rolelistname_to_roleidentifiernumber.Add(_lampValid, 13);
            rolelistname_to_roleidentifiernumber.Add(_pylonValid, 14);
            rolelistname_to_roleidentifiernumber.Add(_pillarValid, 15);
            rolelistname_to_roleidentifiernumber.Add(_greenValid, 16);
            rolelistname_to_roleidentifiernumber.Add(_soullessPusherValid, 17);
            rolelistname_to_roleidentifiernumber.Add(_dhuumKiteValid, 18);
            rolelistname_to_roleidentifiernumber.Add(_qadimKiteValid, 19);
            rolelistname_to_roleidentifiernumber.Add(_swordValid, 20);
            rolelistname_to_roleidentifiernumber.Add(_shieldValid, 21);
            ArrayPos_to_PlayerNameDictionary.Add(0, _playerNames[0].Value);
            ArrayPos_to_PlayerNameDictionary.Add(1, _playerNames[1].Value);
            ArrayPos_to_PlayerNameDictionary.Add(2, _playerNames[2].Value);
            ArrayPos_to_PlayerNameDictionary.Add(3, _playerNames[3].Value);
            ArrayPos_to_PlayerNameDictionary.Add(4, _playerNames[4].Value);
            ArrayPos_to_PlayerNameDictionary.Add(5, _playerNames[5].Value);
            ArrayPos_to_PlayerNameDictionary.Add(6, _playerNames[6].Value);
            ArrayPos_to_PlayerNameDictionary.Add(7, _playerNames[7].Value);
            ArrayPos_to_PlayerNameDictionary.Add(8, _playerNames[8].Value);
            ArrayPos_to_PlayerNameDictionary.Add(9, _playerNames[9].Value);      
        }
        public void PrepRoles()
        {
            //This method prepares the roles to pass to the randomizer. It converts the checkboxes to activated roles to randomize, loads the saved player names into the list of valid options for each role
            //and then sorts them from smallest to largest, removing any role list that has no players. This information is then stored in a list called GenerationSequence, which is passed to the randomizer
            //to be sorted one last time before the randomizer class actually performs the necessary actions to randomize a member into each role.
            intRoles.Clear();
            intGenerationSequence.Clear();
            GenerationSequence = new List<List<string>>();
            _listOfValidLists = new List<List<string>> 
            {
            
            };

            
            GenerationSequence.Clear();
            foreach (List<string> list in _listOfValidLists)
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
