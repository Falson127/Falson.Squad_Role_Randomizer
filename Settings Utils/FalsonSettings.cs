using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.SquadRoleRandomizer
{
    public class FalsonSettings
    {
        public int[] _counterBoxesSettings { get; set; }
        public bool[] _rolesToGenerate { get; set; }
        public bool[] _handKiteRoles { get; set; }
        public bool[] _oilKiteRoles { get; set; }

        public bool[] _flakKiteRoles { get; set; }

        public bool[] _tankRoles { get; set; }

        public bool[] _healAlacRoles { get; set; }

        public bool[] _healQuickRoles { get; set; }

        public bool[] _dpsAlacRoles { get; set; }

        public bool[] _dpsQuickRoles { get; set; }

        public bool[] _mushroomRoles { get; set; }

        public bool[] _towerRoles { get; set; }

        public bool[] _reflectRoles { get; set; }

        public bool[] _cannonRoles { get; set; }

        public bool[] _construcPusherRoles { get; set; }

        public bool[] _lampRoles { get; set; }

        public bool[] _pylonRoles { get; set; }

        public bool[] _pillarRoles { get; set; }

        public bool[] _greenRoles { get; set; }

        public bool[] _soullessPusherRoles { get; set; }

        public bool[] _dhuumKiteRoles { get; set; }

        public bool[] _qadimKiteRoles { get; set; }

        public bool[] _swordRoles { get; set; }

        public bool[] _shieldRoles { get; set; }

        public string[] _playerNames { get; set; }

        public FalsonSettings() 
        {
            //initialize the settings arrays
            _counterBoxesSettings = new int[12];
            _rolesToGenerate = new bool[22];
            _handKiteRoles = new bool[10];
            _oilKiteRoles = new bool[10];
            _flakKiteRoles = new bool[10];
            _tankRoles = new bool[10];
            _healAlacRoles = new bool[10];
            _healQuickRoles = new bool[10];
            _dpsAlacRoles = new bool[10];
            _dpsQuickRoles = new bool[10];
            _mushroomRoles = new bool[10];
            _towerRoles = new bool[10];
            _reflectRoles = new bool[10];
            _cannonRoles = new bool[10];
            _construcPusherRoles = new bool[10];
            _lampRoles = new bool[10];
            _pylonRoles = new bool[10];
            _pillarRoles = new bool[10];
            _greenRoles = new bool[10];
            _soullessPusherRoles = new bool[10];
            _dhuumKiteRoles = new bool[10];
            _qadimKiteRoles = new bool[10];
            _swordRoles = new bool[10];
            _shieldRoles = new bool[10];
            _playerNames = new string[10];
        }

        public void LoadDefaultValues() //set all checkboxes to unchecked, player names to default, and counter boxes to 1. Call this if base64string setting is 'default' for view being loaded.
        {
            for (int i = 0; i < 10; i++)
            {
                _handKiteRoles[i] = false;
                _oilKiteRoles[i] = false;
                _flakKiteRoles[i] = false;
                _tankRoles[i] = false;
                _healAlacRoles[i] = false;
                _healQuickRoles[i] = false;
                _dpsAlacRoles[i] = false;
                _dpsQuickRoles[i] = false;
                _mushroomRoles[i] = false;
                _towerRoles[i] = false;
                _reflectRoles[i] = false;
                _cannonRoles[i] = false;
                _construcPusherRoles[i] = false;
                _lampRoles[i] = false;
                _pylonRoles[i] = false;
                _pillarRoles[i] = false;
                _greenRoles[i] = false;
                _soullessPusherRoles[i] = false;
                _dhuumKiteRoles[i] = false;
                _qadimKiteRoles[i] = false;
                _swordRoles[i] = false;
                _shieldRoles[i] = false;
                _playerNames[i] = $"Player {i + 1}";
            }
            for (int i = 0; i < 12; i++)
            {
                _counterBoxesSettings[i] = 1;
            }
            for (int i = 0; i < 22; i++)
            {
                _rolesToGenerate[i] = false;
            }
        }
    }
}
