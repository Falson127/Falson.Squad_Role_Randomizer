using Blish_HUD.Controls;
using Blish_HUD.Graphics.UI;
using Blish_HUD.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SharpDX.MediaFoundation;
//using System.Windows.Forms;

namespace Falson.SquadRoleRandomizer
{
    public class StaticView : View
    {
        private CustomCheckbox[] _handKiteBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _oilKiteBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _flakKiteBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _tankAlacBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _tankQuickBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _healAlacBoxArray = new CustomCheckbox[10]; //1-2
        private CustomCheckbox[] _healQuickBoxArray = new CustomCheckbox[10]; //1-2
        private CustomCheckbox[] _dpsAlacBoxArray = new CustomCheckbox[10]; //1-2
        private CustomCheckbox[] _dpsQuickBoxArray = new CustomCheckbox[10]; //1-2
        private CustomCheckbox[] _mushroomBoxArray = new CustomCheckbox[10]; //1-4
        private CustomCheckbox[] _towerBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _reflectBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _cannonBoxArray = new CustomCheckbox[10]; //1-2
        private CustomCheckbox[] _construcPusherBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _lampBoxArray = new CustomCheckbox[10]; //1-3
        private CustomCheckbox[] _pylonBoxArray = new CustomCheckbox[10]; //1-3
        private CustomCheckbox[] _pillarBoxArray = new CustomCheckbox[10]; //1-5
        private CustomCheckbox[] _greenBoxArray = new CustomCheckbox[10]; //1-2
        private CustomCheckbox[] _soullessPusherBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _dhuumKiteBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _qadimKiteBoxArray = new CustomCheckbox[10];
        private CustomCheckbox[] _swordBoxArray = new CustomCheckbox[10]; //1-2
        private CustomCheckbox[] _shieldBoxArray = new CustomCheckbox[10]; //1-2
        private TextBox _player1NameBox;
        private TextBox _player2NameBox;
        private TextBox _player3NameBox;
        private TextBox _player4NameBox;
        private TextBox _player5NameBox;
        private TextBox _player6NameBox;
        private TextBox _player7NameBox;
        private TextBox _player8NameBox;
        private TextBox _player9NameBox;
        private TextBox _player10NameBox;
        private Panel _playerNameTextBoxPanel;
        private FlowPanel _masterFlowPanel;
        private PlayerPanel[] _playerPanels = new PlayerPanel[10];
        private Panel[] _standardRolesPanel = new Panel[10]; //5 items
        private Panel[] _hoTMechanicsPanel = new Panel[10]; //8 items
        private Panel[] _poFMechanicsPanel = new Panel[10]; //9 items
        private CustomButton[] _checkAllRoles = new CustomButton[10];
        private CustomButton[] _checkAllHoT = new CustomButton[10];
        private CustomButton[] _checkAllPoF = new CustomButton[10];
        private CounterBox[] _counterBoxes; //need 12 items in this
        private FalsonSettings _deserializedSettings;



        public StaticView(FalsonSettings deserializedSettings, SettingEntry<string> base64SettingsString)//, Tab viewWindowTab)
        {
            _deserializedSettings = deserializedSettings;
        }
        protected override void Build(Container buildPanel)
        {

            //_deserializedSettings = deserializedSettings;

            _playerNameTextBoxPanel = new Panel
            {
                Title = "Enter Player Names",
                Size = new Point(400, 165),
                Location = new Point(0, 0),
                Parent = buildPanel,
            };

            _masterFlowPanel = new FlowPanel
            {
                ShowBorder = true,
                Title = "Set Roles for Each Player  (Click to Expand)",
                Size = new Point(1000, 400),
                Location = new Point(0, 180),
                Parent = buildPanel,
                CanScroll = true,
                CanCollapse = false,
                FlowDirection = ControlFlowDirection.SingleTopToBottom
            };
            #region Player Panels
            for (int i = 0; i < 10; i++)
            {
                _playerPanels[i] = new PlayerPanel(_deserializedSettings._playerNames[i], _masterFlowPanel);
            }
            #endregion
            #region Role Panels
            for (int i = 0; i < 10; i++)
            {
                _standardRolesPanel[i] = new Panel
                {
                    Size = new Point(280, 110),
                    Parent = _playerPanels[i],
                    ShowBorder = true,
                    Title = "Standard Roles",
                    Visible = true,
                    Location = new Point(0, 0)
                };
                _hoTMechanicsPanel[i] = new Panel
                {
                    Size = new Point(330, 110),
                    Parent = _playerPanels[i],
                    ShowBorder = true,
                    Title = "HoT Mechanics",
                    Location = new Point(280, 0)
                };
                _poFMechanicsPanel[i] = new Panel
                {
                    Size = new Point(350, 110),
                    Parent = _playerPanels[i],
                    ShowBorder = true,
                    Title = "PoF Mechanics",
                    Location = new Point(610, 0)
                };
            }
            #endregion
            #region _checkAllBoxesButtons
            for (int i = 0; i < 10; i++)
            {
                _checkAllRoles[i] = new CustomButton(_standardRolesPanel[i], 120, 5);
                _checkAllHoT[i] = new CustomButton(_hoTMechanicsPanel[i], 420, 5);
                _checkAllPoF[i] = new CustomButton(_poFMechanicsPanel[i], 750, 5);
            }
            #endregion
            #region Checkboxes
            for (int j = 0; j < 10; j++) //commenting for a commit so I don't forget. Need to adjust line 202 and add second delegate to all other boxes. They need to adjust the chosen settings string, not just 0 (that was for proof of concept)
            {
                int i = j;
                _tankAlacBoxArray[i] = new CustomCheckbox(_deserializedSettings._tankAlacRoles[i], isChecked =>{_deserializedSettings._tankAlacRoles[i] = isChecked; RoleRandomizerMain._base64strings[0].Value = SettingsEncoder.UpdateBase64(_deserializedSettings);}){ Text = "Heal + Alac Tank", Location = new Point(0, 0), BasicTooltipText = "Heal + Alac Tank", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._tankAlacRoles[i] };
                _tankQuickBoxArray[i] = new CustomCheckbox(_deserializedSettings._tankQuickRoles[i], isChecked => { _deserializedSettings._tankQuickRoles[i] = isChecked; }) { Text = "Heal + Quick Tank", Location = new Point(0,25), BasicTooltipText = "Heal + Quickness Tank", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._tankQuickRoles[i] };
                _healAlacBoxArray[i] = new CustomCheckbox(_deserializedSettings._healAlacRoles[i], isChecked => { _deserializedSettings._healAlacRoles[i] = isChecked; }) { Text = "Heal + Alac", Location = new Point(0, 50), BasicTooltipText = "Heal + Alac", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._healAlacRoles[i] };
                _healQuickBoxArray[i] = new CustomCheckbox(_deserializedSettings._healQuickRoles[i], isChecked => { _deserializedSettings._healQuickRoles[i] = isChecked; }) { Text = "Heal + Quick", Location = new Point(150, 0), BasicTooltipText = "Heal + Quick", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._healQuickRoles[i] };
                _dpsAlacBoxArray[i] = new CustomCheckbox(_deserializedSettings._dpsAlacRoles[i], isChecked => { _deserializedSettings._dpsAlacRoles[i] = isChecked; }) { Text = "DPS + Alac", Location = new Point(150, 25), BasicTooltipText = "DPS + Alac", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._dpsAlacRoles[i] };
                _dpsQuickBoxArray[i] = new CustomCheckbox(_deserializedSettings._dpsQuickRoles[i], isChecked => { _deserializedSettings._dpsQuickRoles[i] = isChecked; }) { Text = "DPS + Quick", Location = new Point(150, 50), BasicTooltipText = "DPS + Quick", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._dpsQuickRoles[i] };

                _handKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._handKiteRoles[i], isChecked => { _deserializedSettings._handKiteRoles[i] = isChecked; }) { Text = "Hand Kite", Location = new Point(0, 0), BasicTooltipText = "Hand Kite", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._handKiteRoles[i] };
                _oilKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._oilKiteRoles[i], isChecked => { _deserializedSettings._oilKiteRoles[i] = isChecked; }) { Text = "Oil Kite", Location = new Point(0, 25), BasicTooltipText = "Oil Kite", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._oilKiteRoles[i] };
                _flakKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._flakKiteRoles[i], isChecked => { _deserializedSettings._flakKiteRoles[i] = isChecked; }) { Text = "Flak Kite", Location = new Point(0, 50), BasicTooltipText = "Flak Kite", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._flakKiteRoles[i] };
                _mushroomBoxArray[i] = new CustomCheckbox(_deserializedSettings._mushroomRoles[i], isChecked => { _deserializedSettings._mushroomRoles[i] = isChecked; }) { Text = "Mushroom", Location = new Point(100, 0), BasicTooltipText = "Slothosaur Mushroom", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._mushroomRoles[i] };
                _towerBoxArray[i] = new CustomCheckbox(_deserializedSettings._towerRoles[i], isChecked => { _deserializedSettings._towerRoles[i] = isChecked; }) { Text = "Tower", Location = new Point(100, 25), BasicTooltipText = "Tower Mesmer", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._towerRoles[i] };
                _reflectBoxArray[i] = new CustomCheckbox(_deserializedSettings._reflectRoles[i], isChecked => { _deserializedSettings._reflectRoles[i] = isChecked; }) { Text = "Reflect", Location = new Point(100, 50), BasicTooltipText = "Matthias Reflect", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._reflectRoles[i] };
                _cannonBoxArray[i] = new CustomCheckbox(_deserializedSettings._cannonRoles[i], isChecked => { _deserializedSettings._cannonRoles[i] = isChecked; }) { Text = "Cannons", Location = new Point(200, 0), BasicTooltipText = "Sabetha Cannons", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._cannonRoles[i] };
                _construcPusherBoxArray[i] = new CustomCheckbox(_deserializedSettings._construcPusherRoles[i], isChecked => { _deserializedSettings._construcPusherRoles[i] = isChecked; }) { Text = "KC Pusher", Location = new Point(200, 25), BasicTooltipText = "Keep Construct Pusher", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._construcPusherRoles[i] };

                _lampBoxArray[i] = new CustomCheckbox(_deserializedSettings._lampRoles[i], isChecked => { _deserializedSettings._lampRoles[i] = isChecked; }) { Text = "Lamp", Location = new Point(0, 0), BasicTooltipText = "Qadim Lamp", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._lampRoles[i] };
                _pylonBoxArray[i] = new CustomCheckbox(_deserializedSettings._pylonRoles[i], isChecked => { _deserializedSettings._pylonRoles[i] = isChecked; }) { Text = "Pylon", Location = new Point(0, 25), BasicTooltipText = "Qadim Pylon", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._pylonRoles[i] };
                _pillarBoxArray[i] = new CustomCheckbox(_deserializedSettings._pillarRoles[i], isChecked => { _deserializedSettings._pillarRoles[i] = isChecked; }) { Text = "Pillar", Location = new Point(0, 50), BasicTooltipText = "Adina Pillar", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._pillarRoles[i] };
                _greenBoxArray[i] = new CustomCheckbox(_deserializedSettings._greenRoles[i], isChecked => { _deserializedSettings._greenRoles[i] = isChecked; }) { Text = "Green", Location = new Point(100, 0), BasicTooltipText = "Dhuum Green", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._greenRoles[i] };
                _soullessPusherBoxArray[i] = new CustomCheckbox(_deserializedSettings._soullessPusherRoles[i], isChecked => { _deserializedSettings._soullessPusherRoles[i] = isChecked; }) { Text = "SH Pusher", Location = new Point(100, 25), BasicTooltipText = "Soulless Horror Pusher", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._soullessPusherRoles[i] };
                _dhuumKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._dhuumKiteRoles[i], isChecked => { _deserializedSettings._dhuumKiteRoles[i] = isChecked; }) { Text = "Dhuum Kiter", Location = new Point(100, 50), BasicTooltipText = "Dhuum Messenger Kiter", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._dhuumKiteRoles[i] };
                _qadimKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._qadimKiteRoles[i], isChecked => { _deserializedSettings._qadimKiteRoles[i] = isChecked; }) { Text = "Qadim Kiter", Location = new Point(200, 0), BasicTooltipText = "Qadim Kiter", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._qadimKiteRoles[i] };
                _swordBoxArray[i] = new CustomCheckbox(_deserializedSettings._swordRoles[i], isChecked => { _deserializedSettings._swordRoles[i] = isChecked; }) { Text = "Sword", Location = new Point(200, 25), BasicTooltipText = "CA Sword Collector", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._swordRoles[i] };
                _shieldBoxArray[i] = new CustomCheckbox(_deserializedSettings._shieldRoles[i], isChecked => { _deserializedSettings._shieldRoles[i] = isChecked; }) { Text = "Shield", Location = new Point(200, 50), BasicTooltipText = "CA Shield Collector", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._shieldRoles[i] };
            }





            #endregion

            #region Textboxes
            _player1NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[0],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(0, 0)
            };
            _player2NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[1],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(0, 25)
            };
            _player3NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[2],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(0, 50)
            };
            _player4NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[3],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(0, 75)
            };
            _player5NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[4],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(0, 100)
            };
            _player6NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[5],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(200, 0)
            };
            _player7NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[6],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(200, 25)
            };
            _player8NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[7],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(200, 50)
            };
            _player9NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[8],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(200, 75)
            };
            _player10NameBox = new TextBox
            {
                PlaceholderText = _deserializedSettings._playerNames[9],
                Size = new Point(200, 25),
                Parent = _playerNameTextBoxPanel,
                Location = new Point(200, 100)
            };
            #endregion

            #region Event Subscriptions
            _player1NameBox.TextChanged += Player1NameBox_TextChanged;
            _player2NameBox.TextChanged += Player2NameBox_TextChanged;
            _player3NameBox.TextChanged += Player3NameBox_TextChanged;
            _player4NameBox.TextChanged += Player4NameBox_TextChanged;
            _player5NameBox.TextChanged += Player5NameBox_TextChanged;
            _player6NameBox.TextChanged += Player6NameBox_TextChanged;
            _player7NameBox.TextChanged += Player7NameBox_TextChanged;
            _player8NameBox.TextChanged += Player8NameBox_TextChanged;
            _player9NameBox.TextChanged += Player9NameBox_TextChanged;
            _player10NameBox.TextChanged += Player10NameBox_TextChanged;
            #endregion
            base.Build(buildPanel);

        }
        #region Event Functions
        #region CounterBox Click Functions
        private void CounterBox12Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[11] = _counterBoxes[11].Value;
        }

        private void CounterBox11Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[10] = _counterBoxes[10].Value;
        }

        private void CounterBox10Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[9] = _counterBoxes[9].Value;
        }

        private void CounterBox9Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[8] = _counterBoxes[8].Value;
        }

        private void CounterBox8Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[7] = _counterBoxes[7].Value;
        }

        private void CounterBox7Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[6] = _counterBoxes[6].Value;
        }

        private void CounterBox6Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[5] = _counterBoxes[5].Value;
        }

        private void CounterBox5Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[4] = _counterBoxes[4].Value;
        }

        private void CounterBox4Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[3] = _counterBoxes[3].Value;
        }

        private void CounterBox3Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[2] = _counterBoxes[2].Value;
        }

        private void CounterBox2Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[1] = _counterBoxes[1].Value;
        }

        private void CounterBox1Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _deserializedSettings._counterBoxesSettings[0] = _counterBoxes[0].Value;
        }
        #endregion
        #region Textbox text changed functions
        private void Player10NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[9].Title = _player10NameBox.Text;
            _deserializedSettings._playerNames[9] = _player10NameBox.Text;

            if (_deserializedSettings._playerNames[9] == "")
            {
                _playerPanels[9].Title = "Enter Player Name";
            };
        }

        private void Player9NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[8].Title = _player9NameBox.Text;
            _deserializedSettings._playerNames[8] = _player9NameBox.Text;
            if (_deserializedSettings._playerNames[8] == "")
            {
                _playerPanels[8].Title = "Enter Player Name";
            };
        }

        private void Player8NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[7].Title = _player8NameBox.Text;
            _deserializedSettings._playerNames[7] = _player8NameBox.Text;
            if (_deserializedSettings._playerNames[7] == "")
            {
                _playerPanels[7].Title = "Enter Player Name";
            };
        }

        private void Player7NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[6].Title = _player7NameBox.Text;
            _deserializedSettings._playerNames[6] = _player7NameBox.Text;
            if (_deserializedSettings._playerNames[6] == "")
            {
                _playerPanels[6].Title = "Enter Player Name";
            };
        }

        private void Player6NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[5].Title = _player6NameBox.Text;
            _deserializedSettings._playerNames[5] = _player6NameBox.Text;
            if (_deserializedSettings._playerNames[5] == "")
            {
                _playerPanels[5].Title = "Enter Player Name";
            };
        }

        private void Player5NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[4].Title = _player5NameBox.Text;
            _deserializedSettings._playerNames[4] = _player5NameBox.Text;
            if (_deserializedSettings._playerNames[4] == "")
            {
                _playerPanels[4].Title = "Enter Player Name";
            };
        }

        private void Player4NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[3].Title = _player4NameBox.Text;
            _deserializedSettings._playerNames[3] = _player4NameBox.Text;
            if (_deserializedSettings._playerNames[3] == "")
            {
                _playerPanels[3].Title = "Enter Player Name";
            };
        }

        private void Player3NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[2].Title = _player3NameBox.Text;
            _deserializedSettings._playerNames[2] = _player3NameBox.Text;
            if (_deserializedSettings._playerNames[2] == "")
            {
                _playerPanels[2].Title = "Enter Player Name";
            };
        }

        private void Player2NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[1].Title = _player2NameBox.Text;
            _deserializedSettings._playerNames[1] = _player2NameBox.Text;
            if (_deserializedSettings._playerNames[1] == "")
            {
                _playerPanels[1].Title = "Enter Player Name";
            };
        }

        private void Player1NameBox_TextChanged(object sender, EventArgs e)
        {
            _playerPanels[0].Title = _player1NameBox.Text;
            _deserializedSettings._playerNames[0] = _player1NameBox.Text;
            if (_deserializedSettings._playerNames[0] == "")
            {
                _playerPanels[0].Title = "Enter Player Name";
            };
        }
        #endregion
        #endregion

    }
}
