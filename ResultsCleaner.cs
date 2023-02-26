using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blish_HUD.Controls;
using falson = Falson.SquadRoleRandomizer.RoleRandomizerMain;

namespace Falson.SquadRoleRandomizer
{
    public class ResultsCleaner
    {
        private List<Tuple<int, string>> _assignedRoles = new List<Tuple<int, string>>();
        private List<string> CleanedRoles = new List<string>();
        private List<string> CleanedHoTMechanics = new List<string>();
        private List<string> CleanedPoFMechanics = new List<string>();
        private Label[] DynamicLabel1;
        private Label[] DynamicLabel2;
        private Label[] DynamicLabel3;
        private List<string> _handKiteIs = new List<string>();
        private List<string> _oilKiteIs = new List<string>();
        private List<string> _flakKiteIs = new List<string>();
        private List<string> _tankIs = new List<string>();
        private List<string> _healAlacIs = new List<string>();
        private List<string> _healQuickIs = new List<string>();
        private List<string> _dpsAlacIs = new List<string>();
        private List<string> _dpsQuickIs = new List<string>();
        private List<string> _mushroomIs = new List<string>();
        private List<string> _towerIs = new List<string>();
        private List<string> _reflectIs = new List<string>();
        private List<string> _cannonIs = new List<string>();
        private List<string> _construcPusherIs = new List<string>();
        private List<string> _lampIs = new List<string>();
        private List<string> _pylonIs = new List<string>();
        private List<string> _pillarIs = new List<string>();
        private List<string> _greenIs = new List<string>();
        private List<string> _shPusherIs = new List<string>();
        private List<string> _dhuumKiteIs = new List<string>();
        private List<string> _qadimKiteIs = new List<string>();
        private List<string> _swordIs = new List<string>();
        private List<string> _shieldIs = new List<string>();
        IDictionary<int, List<string>> roleindexint_to_rolelist = new Dictionary<int, List<string>>();



        public void filldictionary()
        {
            roleindexint_to_rolelist.Add(0, _handKiteIs);
            roleindexint_to_rolelist.Add(1, _oilKiteIs);
            roleindexint_to_rolelist.Add(2, _flakKiteIs);
            roleindexint_to_rolelist.Add(3, _tankIs);
            roleindexint_to_rolelist.Add(4, _healAlacIs);
            roleindexint_to_rolelist.Add(5, _healQuickIs);
            roleindexint_to_rolelist.Add(6, _dpsAlacIs);
            roleindexint_to_rolelist.Add(7, _dpsQuickIs);
            roleindexint_to_rolelist.Add(8, _mushroomIs);
            roleindexint_to_rolelist.Add(9, _towerIs);
            roleindexint_to_rolelist.Add(10, _reflectIs);
            roleindexint_to_rolelist.Add(11, _cannonIs);
            roleindexint_to_rolelist.Add(12, _construcPusherIs);
            roleindexint_to_rolelist.Add(13, _lampIs);
            roleindexint_to_rolelist.Add(14, _pylonIs);
            roleindexint_to_rolelist.Add(15, _pillarIs);
            roleindexint_to_rolelist.Add(16, _greenIs);
            roleindexint_to_rolelist.Add(17, _shPusherIs);
            roleindexint_to_rolelist.Add(18, _dhuumKiteIs);
            roleindexint_to_rolelist.Add(19, _qadimKiteIs);
            roleindexint_to_rolelist.Add(20, _swordIs);
            roleindexint_to_rolelist.Add(21, _shieldIs);
        }
        public void Main()
        {
            CleanedRoles.Clear();
            CleanedHoTMechanics.Clear();
            CleanedPoFMechanics.Clear();
            filldictionary();
            _assignedRoles = Falson.Randomizer.RecursiveRandomizer._assignedRoles;
            for (int i = 0; i < _assignedRoles.Count(); i++) //takes all assigned roles and breaks them into their assignments for each role
            {
                roleindexint_to_rolelist[_assignedRoles[i].Item1].Add(_assignedRoles[i].Item2);
            }
            #region Call all datamanip methods
            Tank();
            HealAlac();
            HealQuick();
            DPSAlac();
            DPSQuick();
            HandKite();
            OilKite();
            FlakKite();
            Mushroom();
            Tower();
            Reflect();
            Cannon();
            KCPush();
            Lamp();
            Pylon();
            Pillar();
            Green();
            SHPush();
            DhuumKite();
            QadimKite();
            Sword();
            Shield();
            #endregion

            //now make the dynamic labels to load into the results window.
            if (CleanedRoles.Count != 0)
            {
                DynamicLabel1 = new Label[(CleanedRoles.Count + 2)];
                DynamicLabel1[0] = new Label { Text = "Standard Roles:", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                var rolecounter = 1;
                foreach (var role in CleanedRoles)
                {
                    DynamicLabel1[rolecounter] = new Label { Text = role, Parent = falson.ResultsFlowPanel, AutoSizeHeight=true, AutoSizeWidth = true };
                    rolecounter++;
                }
                DynamicLabel1[rolecounter] = new Label { Text = "", Parent= falson.ResultsFlowPanel,AutoSizeHeight=true,AutoSizeWidth = true };
            }
            if (CleanedHoTMechanics.Count != 0)
            {
                DynamicLabel2 = new Label[(CleanedHoTMechanics.Count + 2)];
                DynamicLabel2[0] = new Label { Text = "HoT Mechanics:", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                var hotcounter = 1;
                foreach (var role in CleanedHoTMechanics)
                {
                    DynamicLabel2[hotcounter] = new Label { Text = role, Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                    hotcounter++;
                }
                DynamicLabel2[hotcounter] = new Label { Text = "", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
            }
            if (CleanedPoFMechanics.Count != 0)
            {
                DynamicLabel3 = new Label[(CleanedPoFMechanics.Count + 2)];
                DynamicLabel3[0] = new Label { Text = "Standard Roles:", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                var pofcounter = 1;
                foreach (var role in CleanedPoFMechanics)
                {
                    DynamicLabel3[pofcounter] = new Label { Text = role, Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                    pofcounter++;
                }
                DynamicLabel3[pofcounter] = new Label { Text = "", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
            }
        }

        private void HandKite() 
        {
            foreach (var player in _handKiteIs)
            {
                CleanedHoTMechanics.Add("The Hand Kite is: " + player);
            }
        }
        private void OilKite() 
        {
            foreach (var player in _oilKiteIs)
            {
                CleanedHoTMechanics.Add("The Oil Kite is: " + player);
            }
        }
        private void FlakKite() 
        {
            foreach (var player in _flakKiteIs)
            {
                CleanedHoTMechanics.Add("The Flak Kite is: " + player);
            }
        }
        private void Tank() 
        {
            foreach (var player in _tankIs)
            {
                CleanedRoles.Add("The Tank is: " + player);
            }
        }
        private void HealAlac() 
        {
            for (int i = 0; i < _healAlacIs.Count; i++)
            {
                CleanedRoles.Add($"Heal Alac {i+1} is: {_healAlacIs[i]}");
            }
        }
        private void HealQuick() 
        {
            for (int i = 0; i < _healQuickIs.Count; i++)
            {
                CleanedRoles.Add($"Heal Quick {i + 1} is: {_healQuickIs[i]}");
            }
        }
        private void DPSAlac() 
        {
            for (int i = 0; i < _dpsAlacIs.Count; i++)
            {
                CleanedRoles.Add($"DPS Alac {i + 1} is: {_dpsAlacIs[i]}");
            }
        }
        private void DPSQuick() 
        {
            for (int i = 0; i < _dpsQuickIs.Count; i++)
            {
                CleanedRoles.Add($"DPS Quick {i + 1} is: {_dpsQuickIs[i]}");
            }
        }
        private void Mushroom() 
        {
            for (int i = 0; i < _mushroomIs.Count; i++)
            {
                CleanedHoTMechanics.Add($"Mushroom {i + 1} is: {_mushroomIs[i]}");
            }
        }
        private void Tower() 
        {
            foreach (var player in _towerIs)
            {
                CleanedHoTMechanics.Add("The Tower Mesmer is: " + player);
            }
        }
        private void Reflect() 
        {
            foreach (var player in _reflectIs)
            {
                CleanedHoTMechanics.Add("The Matthias Reflect is: " + player);
            }
        }
        private void Cannon() 
        {
            for (int i = 0; i < _cannonIs.Count; i++)
            {
                CleanedHoTMechanics.Add($"Cannon {i + 1} is: {_cannonIs[i]}");
            }
        }
        private void KCPush() 
        {
            foreach (var player in _construcPusherIs)
            {
                CleanedHoTMechanics.Add("The KC Pusher is: " + player);
            }
        }
        private void Lamp() 
        {
            for (int i = 0; i < _lampIs.Count; i++)
            {
                CleanedPoFMechanics.Add($"Lamp {i + 1} is: {_lampIs[i]}");
            }
        }
        private void Pylon() 
        {
            for (int i = 0; i < _pylonIs.Count; i++)
            {
                CleanedPoFMechanics.Add($"Pylon {i + 1} is: {_pylonIs[i]}");
            }
        } 
        private void Pillar() 
        {
            for (int i = 0; i < _pillarIs.Count; i++)
            {
                CleanedPoFMechanics.Add($"Pillar {i + 1} is: {_pillarIs[i]}");
            }
        }
        private void Green() 
        {
            for (int i = 0; i < _greenIs.Count; i++)
            {
                CleanedPoFMechanics.Add($"Green {i + 1} is: {_greenIs[i]}");
            }
        }
        private void SHPush() 
        {
            foreach (var player in _shPusherIs)
            {
                CleanedPoFMechanics.Add("The SH Pusher is: " + player);
            }
        }
        private void DhuumKite() 
        {
            foreach (var player in _dhuumKiteIs)
            {
                CleanedPoFMechanics.Add("The Dhuum Kite is: " + player);
            }
        }
        private void QadimKite() 
        {
            foreach (var player in _qadimKiteIs)
            {
                CleanedPoFMechanics.Add("The Qadim Kite is: " + player);
            }
        }
        private void Sword() 
        {
            for (int i = 0; i < _swordIs.Count; i++)
            {
                CleanedPoFMechanics.Add($"Sword {i + 1} is: {_swordIs[i]}");
            }
        }
        private void Shield() 
        {
            for (int i = 0; i < _shieldIs.Count; i++)
            {
                CleanedPoFMechanics.Add($"Shield {i + 1} is: {_shieldIs[i]}");
            }
        }
    }
}
