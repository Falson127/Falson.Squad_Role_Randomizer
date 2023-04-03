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

        private List<List<string>> _generationSequence = new List<List<string>>();
        private List<List<string>> _listOfValidLists;
        private List<int> _intGenerationSequence = new List<int>();
        private List<Tuple<int, string>> intRoles = new List<Tuple<int,string>>();
        IDictionary<Tuple<int, bool>, bool[]> ActiveRolesDictionary = new Dictionary<Tuple<int, bool>, bool[]>();
        IDictionary<bool[], int> RolesArrays_to_ArrayListPosDictionary = new Dictionary<bool[], int>();
        IDictionary<bool[], List<string>> RolesArrays_to_ValidLists = new Dictionary<bool[], List<string>>();
        IDictionary<List<string>, int> rolestogeneratemultiple_to_numbertogenerate = new Dictionary<List<string>, int>();
        IDictionary<List<string>, int> rolelistname_to_roleidentifiernumber = new Dictionary<List<string>, int>();
        IDictionary<int, string> ArrayPos_to_PlayerNameDictionary = new Dictionary<int, string>();


        //local instances of valid lists
        private List<string> _handKiteValid = new List<string>();
        private List<string> _oilKiteValid = new List<string>();
        private List<string> _flakKiteValid = new List<string>();
        private List<string> _tankAlacValid = new List<string>();
        private List<string> _tankQuickValid = new List<string>();
        private List<string> _healAlacValid = new List<string>();
        private List<string> _healQuickValid = new List<string>();
        private List<string> _dpsAlacValid = new List<string>();
        private List<string> _dpsQuickValid = new List<string>();
        private List<string> _mushroomValid = new List<string>();
        private List<string> _towerValid = new List<string>();
        private List<string> _reflectValid = new List<string>();
        private List<string> _cannonValid = new List<string>();
        private List<string> _construcPusherValid = new List<string>();
        private List<string> _lampValid = new List<string>();
        private List<string> _pylonValid = new List<string>();
        private List<string> _pillarValid = new List<string>();
        private List<string> _greenValid = new List<string>();
        private List<string> _soullessPusherValid = new List<string>();
        private List<string> _dhuumKiteValid = new List<string>();
        private List<string> _qadimKiteValid = new List<string>();
        private List<string> _swordValid = new List<string>();
        private List<string> _shieldValid = new List<string>();
        //local instances of role settings
        private readonly bool[] _handKiteRoles = new bool[10];
        private readonly bool[] _oilKiteRoles = new bool[10];
        private readonly bool[] _flakKiteRoles = new bool[10];
        private readonly bool[] _tankAlacRoles = new bool[10];
        private readonly bool[] _tankQuickRoles = new bool[10];
        private readonly bool[] _healAlacRoles = new bool[10];
        private readonly bool[] _healQuickRoles = new bool[10];
        private readonly bool[] _dpsAlacRoles = new bool[10];
        private readonly bool[] _dpsQuickRoles = new bool[10];
        private readonly bool[] _mushroomRoles = new bool[10];
        private readonly bool[] _towerRoles = new bool[10];
        private readonly bool[] _reflectRoles = new bool[10];
        private readonly bool[] _cannonRoles = new bool[10];
        private readonly bool[] _construcPusherRoles = new bool[10];
        private readonly bool[] _lampRoles = new bool[10];
        private readonly bool[] _pylonRoles = new bool[10];
        private readonly bool[] _pillarRoles = new bool[10];
        private readonly bool[] _greenRoles = new bool[10];
        private readonly bool[] _soullessPusherRoles = new bool[10];
        private readonly bool[] _dhuumKiteRoles = new bool[10];
        private readonly bool[] _qadimKiteRoles = new bool[10];
        private readonly bool[] _swordRoles = new bool[10];
        private readonly bool[] _shieldRoles = new bool[10];
        private readonly bool[] _playersToInclude = new bool[10];
        //private readonly bool[] _rolesToGenerate = new bool[22];
        private readonly List<Tuple<int, bool>> _rolesToGenerate = new List<Tuple<int, bool>>();
        private readonly int[] _counterBoxSettings = new int[12];
        private readonly string[] _playerNames = new string[10];
        //constructor
        public PrepareRoles(FalsonSettings deserializedSettings, bool[] rolesToGenerate, int[] counterBoxSettings, bool[] playerToInclude) 
        {
            for (int i = 0; i < 23; i++)
            {
                _rolesToGenerate.Add(Tuple.Create(i, rolesToGenerate[i]));
            }
            _playerNames = deserializedSettings._playerNames;
            _counterBoxSettings = counterBoxSettings;
            _playersToInclude = playerToInclude;

            _handKiteRoles = deserializedSettings._handKiteRoles;
            _oilKiteRoles = deserializedSettings._oilKiteRoles;
            _flakKiteRoles = deserializedSettings._flakKiteRoles;
            _tankAlacRoles = deserializedSettings._tankAlacRoles;
            _tankQuickRoles = deserializedSettings._tankQuickRoles;
            _healAlacRoles = deserializedSettings._healAlacRoles;
            _healQuickRoles = deserializedSettings._healQuickRoles;
            _dpsAlacRoles = deserializedSettings._dpsAlacRoles;
            _dpsQuickRoles = deserializedSettings._dpsQuickRoles;
            _mushroomRoles = deserializedSettings._mushroomRoles;
            _towerRoles = deserializedSettings._towerRoles;
            _reflectRoles = deserializedSettings._reflectRoles;
            _cannonRoles = deserializedSettings._cannonRoles;
            _construcPusherRoles = deserializedSettings._construcPusherRoles;
            _lampRoles = deserializedSettings._lampRoles;
            _pylonRoles = deserializedSettings._pylonRoles;
            _pillarRoles = deserializedSettings._pillarRoles;
            _greenRoles = deserializedSettings._greenRoles;
            _soullessPusherRoles = deserializedSettings._soullessPusherRoles;
            _dhuumKiteRoles = deserializedSettings._dhuumKiteRoles;
            _qadimKiteRoles = deserializedSettings._qadimKiteRoles;
            _swordRoles = deserializedSettings._swordRoles;
            _shieldRoles = deserializedSettings._shieldRoles;
        }

        public void Main() 
        {
            FillDictionaries();
            PrepRoles();
        }

        private void FillDictionaries() 
        {
            ActiveRolesDictionary.Add(_rolesToGenerate[0], _handKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[1], _oilKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[2], _flakKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[3], _tankAlacRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[22], _tankQuickRoles);
            ActiveRolesDictionary.Add(_rolesToGenerate[4], _healAlacRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[5], _healQuickRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[6], _dpsAlacRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[7], _dpsQuickRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[8], _mushroomRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[9], _towerRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[10], _reflectRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[11], _cannonRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[12], _construcPusherRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[13], _lampRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[14], _pylonRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[15], _pillarRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[16], _greenRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[17], _soullessPusherRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[18], _dhuumKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[19], _qadimKiteRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[20], _swordRoles );
            ActiveRolesDictionary.Add(_rolesToGenerate[21], _shieldRoles);
            RolesArrays_to_ArrayListPosDictionary.Add(_handKiteRoles, 0);
            RolesArrays_to_ArrayListPosDictionary.Add(_oilKiteRoles, 1);
            RolesArrays_to_ArrayListPosDictionary.Add(_flakKiteRoles, 2);
            RolesArrays_to_ArrayListPosDictionary.Add(_tankAlacRoles, 3);
            RolesArrays_to_ArrayListPosDictionary.Add(_tankQuickRoles, 22);
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
            RolesArrays_to_ValidLists.Add(_tankAlacRoles,  _tankAlacValid);
            RolesArrays_to_ValidLists.Add(_tankQuickRoles, _tankQuickValid);
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
            rolelistname_to_roleidentifiernumber.Add(_tankAlacValid, 3);
            rolelistname_to_roleidentifiernumber.Add(_tankQuickValid, 22);
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
            ArrayPos_to_PlayerNameDictionary.Add(0, _playerNames[0]);
            ArrayPos_to_PlayerNameDictionary.Add(1, _playerNames[1]);
            ArrayPos_to_PlayerNameDictionary.Add(2, _playerNames[2]);
            ArrayPos_to_PlayerNameDictionary.Add(3, _playerNames[3]);
            ArrayPos_to_PlayerNameDictionary.Add(4, _playerNames[4]);
            ArrayPos_to_PlayerNameDictionary.Add(5, _playerNames[5]);
            ArrayPos_to_PlayerNameDictionary.Add(6, _playerNames[6]);
            ArrayPos_to_PlayerNameDictionary.Add(7, _playerNames[7]);
            ArrayPos_to_PlayerNameDictionary.Add(8, _playerNames[8]);
            ArrayPos_to_PlayerNameDictionary.Add(9, _playerNames[9]);      
        }
        private void PrepRoles()
        {
            //This method prepares the roles to pass to the randomizer. It converts the checkboxes to activated roles to randomize, loads the saved player names into the list of valid options for each role
            //and then sorts them from smallest to largest, removing any role list that has no players. This information is then stored in a list called GenerationSequence, which is passed to the randomizer
            //to be sorted one last time before the randomizer class actually performs the necessary actions to randomize a member into each role.
            //intRoles.Clear();
            //intGenerationSequence.Clear();
            //GenerationSequence = new List<List<string>>();
            //GenerationSequence.Clear();
            _listOfValidLists = new List<List<string>>
            {
            _handKiteValid,
            _oilKiteValid,
            _flakKiteValid,
            _tankAlacValid,
            _healAlacValid,
            _healQuickValid,
            _dpsAlacValid,
            _dpsQuickValid,
            _mushroomValid,
            _towerValid,
            _reflectValid,
            _cannonValid,
            _construcPusherValid,
            _lampValid,
            _pylonValid,
            _pillarValid,
            _greenValid,
            _soullessPusherValid,
            _dhuumKiteValid,
            _qadimKiteValid,
            _swordValid,
            _shieldValid,
            _tankQuickValid
            };
            for (int i = 0; i < 23; i++)
            {
                if (_rolesToGenerate[i].Item2)
                {
                    var tempkey = _rolesToGenerate[i];
                    var temprole = ActiveRolesDictionary[tempkey];
                    for (int s = 0; s < 10; s++)
                    {
                        if (_playersToInclude[s]) //only add the player to the valid list if they are set to be included in the randomizer
                        {
                            if (temprole[s])
                            {
                                RolesArrays_to_ValidLists[temprole].Add(ArrayPos_to_PlayerNameDictionary[s]); //adds the player that has checked true for a role to the role valid list for that particular role.
                            }
                        }
                    }
                }
            }
            var mySortedList = _listOfValidLists.OrderBy(x => x.Count).ToList();  //sorts the populated lists by length
            foreach (var item in mySortedList)
            {
                if (item.Count != 0) //only roles that have at least 1 player signed up get added to the sequence for generation
                {
                    _generationSequence.Add(item); //converts the current (role)valid list into a string name for the role to be generated and adds to the sequence, from shortest lists to longest.
                }
            }
            foreach (var entry in _generationSequence)
            {
                if (rolestogeneratemultiple_to_numbertogenerate.ContainsKey(entry))//check if list might need multiple
                {
                    for (int i = 0; i < rolestogeneratemultiple_to_numbertogenerate[entry]; i++) //if it might, get number requested
                    {
                        _intGenerationSequence.Add(rolelistname_to_roleidentifiernumber[entry]); //add that role's index the number of times needed
                    }
                }
                else
                {
                    _intGenerationSequence.Add(rolelistname_to_roleidentifiernumber[entry]); //if it can't accept multiple, just add it once as integer index
                }
            }

            #region build intRoles list
            foreach (var name in _handKiteValid)
            {
                intRoles.Add(Tuple.Create(0, name));
            }
            foreach (var name in _oilKiteValid)
            {
                intRoles.Add(Tuple.Create(1, name));
            }
            foreach (var name in _flakKiteValid)
            {
                intRoles.Add(Tuple.Create(2, name));
            }
            foreach (var name in _tankAlacValid)
            {
                intRoles.Add(Tuple.Create(3, name));
            }
            foreach (var name in _tankQuickValid)
            {
                intRoles.Add(Tuple.Create(22, name));
            }
            foreach (var name in _healAlacValid)
            {
                intRoles.Add(Tuple.Create(4, name));
            }
            foreach (var name in _healQuickValid)
            {
                intRoles.Add(Tuple.Create(5, name));
            }
            foreach (var name in _dpsAlacValid)
            {
                intRoles.Add(Tuple.Create(6, name));
            }
            foreach (var name in _dpsQuickValid)
            {
                intRoles.Add(Tuple.Create(7, name));
            }
            foreach (var name in _mushroomValid)
            {
                intRoles.Add(Tuple.Create(8, name));
            }
            foreach (var name in _towerValid)
            {
                intRoles.Add(Tuple.Create(9, name));
            }
            foreach (var name in _reflectValid)
            {
                intRoles.Add(Tuple.Create(10, name));
            }
            foreach (var name in _cannonValid)
            {
                intRoles.Add(Tuple.Create(11, name));
            }
            foreach (var name in _construcPusherValid)
            {
                intRoles.Add(Tuple.Create(12, name));
            }
            foreach (var name in _lampValid)
            {
                intRoles.Add(Tuple.Create(13, name));
            }
            foreach (var name in _pylonValid)
            {
                intRoles.Add(Tuple.Create(14, name));
            }
            foreach (var name in _pillarValid)
            {
                intRoles.Add(Tuple.Create(15, name));
            }
            foreach (var name in _greenValid)
            {
                intRoles.Add(Tuple.Create(16, name));
            }
            foreach (var name in _soullessPusherValid)
            {
                intRoles.Add(Tuple.Create(17, name));
            }
            foreach (var name in _dhuumKiteValid)
            {
                intRoles.Add(Tuple.Create(18, name));
            }
            foreach (var name in _qadimKiteValid)
            {
                intRoles.Add(Tuple.Create(19, name));
            }
            foreach (var name in _swordValid)
            {
                intRoles.Add(Tuple.Create(20, name));
            }
            foreach (var name in _shieldValid)
            {
                intRoles.Add(Tuple.Create(21, name));
            }
            #endregion
            var TheRandomizer = new Randomizer.RecursiveRandomizer(intRoles, _intGenerationSequence, _rolesToGenerate, _counterBoxSettings);
            TheRandomizer.Main();
        }

        
}
    
}
