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
        private CustomCheckbox[] _tankBoxArray = new CustomCheckbox[10];
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
        private CustomCheckbox[] _rolestoRandomizeSelectionCheckboxesArray = new CustomCheckbox[22];
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
        private Panel _randomizeCheckboxesPanel = new Panel();
        private PlayerPanel[] _playerPanels = new PlayerPanel[10];
        private Panel[] _standardRolesPanel = new Panel[10]; //5 items
        private Panel[] _hoTMechanicsPanel = new Panel[10]; //8 items
        private Panel[] _poFMechanicsPanel = new Panel[10]; //9 items
        private Panel _rolesWithNumbers;
        private Label[] _counterBoxLabels;
        private StandardButton _generateRolesButton;
        private CustomButton[] _checkAllRoles = new CustomButton[10];
        private CustomButton[] _checkAllHoT = new CustomButton[10];
        private CustomButton[] _checkAllPoF = new CustomButton[10];
        private CustomButton _checkAllGenerateRoles;
        private CounterBox[] _counterBoxes; //need 12 items in this

        private readonly int[] _counterBoxesSettings;
        private readonly string[] _playerNames;
        private FalsonSettings _deserializedSettings;

        private string ActiveSettingString;
        private int tabId;

        public StaticView(FalsonSettings deserializedSettings, SettingEntry<string> base64SettingsString)//, Tab viewWindowTab)
        {
            _deserializedSettings = deserializedSettings;
        }
        protected override void Build(Container buildPanel)
        {

            //_deserializedSettings = deserializedSettings;

            _rolesWithNumbers = new Panel
            {
                Title = "Number of each role to generate",
                Parent = buildPanel,
                Size = new Point(480, 165),
                Location = new Point(401, 0),
            };      
            _generateRolesButton = new StandardButton
            {
                Text = "Generate \n  Roles",
                Size = new Point(80, 100),
                Location = new Point(890, 40),
                Parent = buildPanel,
            };
            _generateRolesButton.Click += GenerateRolesButton_Click;
            _counterBoxes = new CounterBox[12];
            _counterBoxLabels = new Label[12];
            _rolesWithNumbers = new Panel
            {
                Title = "Number of each role to generate",
                Parent = buildPanel,
                Size = new Point(480, 165),
                Location = new Point(401, 0),
            };
            _generateRolesButton = new StandardButton
            {
                Text = "Generate \n  Roles",
                Size = new Point(80, 100),
                Location = new Point(890, 40),
                Parent = buildPanel,
            };
            _generateRolesButton.Click += GenerateRolesButton_Click;
            _playerNameTextBoxPanel = new Panel
            {
                Title = "Enter Player Names",
                Size = new Point(400, 165),
                Location = new Point(0, 0),
                Parent = buildPanel,
            };
            _randomizeCheckboxesPanel = new Panel
            {
                Title = "Select roles to be randomized",
                Size = new Point(1000, 120),
                Parent = buildPanel,
                Location = new Point(0, 166),
            };
            _masterFlowPanel = new FlowPanel
            {
                ShowBorder = true,
                Title = "Set Roles for Each Player  (Click to Expand)",
                Size = new Point(1000, 400),
                Location = new Point(0, 255),
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
            _checkAllGenerateRoles = new CustomButton(_randomizeCheckboxesPanel, 220, 170);
            #endregion
            #region Checkboxes
            for (int i = 0; i < 10; i++)
            {
                _tankBoxArray[i] = new CustomCheckbox(_deserializedSettings._tankRoles[i]) { Text = "Tank", Location = new Point(0, 0), BasicTooltipText = "Tank", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._tankRoles[i] };
                _healAlacBoxArray[i] = new CustomCheckbox(_deserializedSettings._healAlacRoles[i]) { Text = "Heal + Alac", Location = new Point(0, 25), BasicTooltipText = "Heal + Alac", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._healAlacRoles[i] };
                _healQuickBoxArray[i] = new CustomCheckbox(_deserializedSettings._healQuickRoles[i]) { Text = "Heal + Quick", Location = new Point(0, 50), BasicTooltipText = "Heal + Quick", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._healQuickRoles[i] };
                _dpsAlacBoxArray[i] = new CustomCheckbox(_deserializedSettings._dpsAlacRoles[i]) { Text = "DPS + Alac", Location = new Point(100, 0), BasicTooltipText = "DPS + Alac", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._dpsAlacRoles[i] };
                _dpsQuickBoxArray[i] = new CustomCheckbox(_deserializedSettings._dpsQuickRoles[i]) { Text = "DPS + Quick", Location = new Point(100, 25), BasicTooltipText = "DPS + Quick", Parent = _standardRolesPanel[i], Checked = _deserializedSettings._dpsQuickRoles[i] };

                _handKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._handKiteRoles[i]) { Text = "Hand Kite", Location = new Point(0, 0), BasicTooltipText = "Hand Kite", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._handKiteRoles[i] };
                _oilKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._oilKiteRoles[i]) { Text = "Oil Kite", Location = new Point(0, 25), BasicTooltipText = "Oil Kite", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._oilKiteRoles[i] };
                _flakKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._flakKiteRoles[i]) { Text = "Flak Kite", Location = new Point(0, 50), BasicTooltipText = "Flak Kite", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._flakKiteRoles[i] };
                _mushroomBoxArray[i] = new CustomCheckbox(_deserializedSettings._mushroomRoles[i]) { Text = "Mushroom", Location = new Point(100, 0), BasicTooltipText = "Slothosaur Mushroom", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._mushroomRoles[i] };
                _towerBoxArray[i] = new CustomCheckbox(_deserializedSettings._towerRoles[i]) { Text = "Tower", Location = new Point(100, 25), BasicTooltipText = "Tower Mesmer", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._towerRoles[i] };
                _reflectBoxArray[i] = new CustomCheckbox(_deserializedSettings._reflectRoles[i]) { Text = "Reflect", Location = new Point(100, 50), BasicTooltipText = "Matthias Reflect", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._reflectRoles[i] };
                _cannonBoxArray[i] = new CustomCheckbox(_deserializedSettings._cannonRoles[i]) { Text = "Cannons", Location = new Point(200, 0), BasicTooltipText = "Sabetha Cannons", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._cannonRoles[i] };
                _construcPusherBoxArray[i] = new CustomCheckbox(_deserializedSettings._construcPusherRoles[i]) { Text = "KC Pusher", Location = new Point(200, 25), BasicTooltipText = "Keep Construct Pusher", Parent = _hoTMechanicsPanel[i], Checked = _deserializedSettings._construcPusherRoles[i] };

                _lampBoxArray[i] = new CustomCheckbox(_deserializedSettings._lampRoles[i]) { Text = "Lamp", Location = new Point(0, 0), BasicTooltipText = "Qadim Lamp", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._lampRoles[i] };
                _pylonBoxArray[i] = new CustomCheckbox(_deserializedSettings._pylonRoles[i]) { Text = "Pylon", Location = new Point(0, 25), BasicTooltipText = "Qadim Pylon", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._pylonRoles[i] };
                _pillarBoxArray[i] = new CustomCheckbox(_deserializedSettings._pillarRoles[i]) { Text = "Pillar", Location = new Point(0, 50), BasicTooltipText = "Adina Pillar", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._pillarRoles[i] };
                _greenBoxArray[i] = new CustomCheckbox(_deserializedSettings._greenRoles[i]) { Text = "Green", Location = new Point(100, 0), BasicTooltipText = "Dhuum Green", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._greenRoles[i] };
                _soullessPusherBoxArray[i] = new CustomCheckbox(_deserializedSettings._soullessPusherRoles[i]) { Text = "SH Pusher", Location = new Point(100, 25), BasicTooltipText = "Soulless Horror Pusher", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._soullessPusherRoles[i] };
                _dhuumKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._dhuumKiteRoles[i]) { Text = "Dhuum Kiter", Location = new Point(100, 50), BasicTooltipText = "Dhuum Messenger Kiter", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._dhuumKiteRoles[i] };
                _qadimKiteBoxArray[i] = new CustomCheckbox(_deserializedSettings._qadimKiteRoles[i]) { Text = "Qadim Kiter", Location = new Point(200, 0), BasicTooltipText = "Qadim Kiter", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._qadimKiteRoles[i] };
                _swordBoxArray[i] = new CustomCheckbox(_deserializedSettings._swordRoles[i]) { Text = "Sword", Location = new Point(200, 25), BasicTooltipText = "CA Sword Collector", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._swordRoles[i] };
                _shieldBoxArray[i] = new CustomCheckbox(_deserializedSettings._shieldRoles[i]) { Text = "Shield", Location = new Point(200, 50), BasicTooltipText = "CA Shield Collector", Parent = _poFMechanicsPanel[i], Checked = _deserializedSettings._shieldRoles[i] };
            }
            IDictionary<int, string> RandomizeSelectionBoxesInt_to_NameDictionary = new Dictionary<int, string>
            {
                {0,"Hand Kite"},
                {1,"Oil Kite"},
                {2,"Flak Kite"},
                {3,"Tank"},
                {4,"Heal Alac"},
                {5,"Heal Quick"},
                {6,"DPS Alac"},
                {7,"DPS Quick"},
                {8,"Mushrooms"},
                {9,"Tower"},
                {10,"Reflect"},
                {11,"Cannons"},
                {12,"KC Pusher"},
                {13,"Lamp(s)"},
                {14,"Pylon(s)"},
                {15,"Pillar(s)"},
                {16,"Green(s)"},
                {17,"SH Pusher"},
                {18,"Dhuum Kite"},
                {19,"Qadim Kite"},
                {20,"Sword Collector(s)"},
                {21,"Shield Collector(s)"},
            };
            IDictionary<int, string> RandomizeSelectionBoxesInt_to_TooltipDictionary = new Dictionary<int, string>
            {
                {0,"Hand Kite"},
                {1,"Oil Kite"},
                {2,"Flak Kite"},
                {3,"Tank"},
                {4,"Heal Alac"},
                {5,"Heal Quickness"},
                {6,"DPS Alac"},
                {7,"DPS Quickness"},
                {8,"Slothosaur Mushrooms"},
                {9,"Tower Mesmer"},
                {10,"Matthias Reflect"},
                {11,"Sabetha Cannons"},
                {12,"Keep Construct Pusher"},
                {13,"Qadim Lamp(s)"},
                {14,"Qadim Pylon(s)"},
                {15,"Adina Pillar(s)"},
                {16,"Dhuum Green(s)"},
                {17,"Soulless Horror Pusher"},
                {18,"Dhuum Messenger Kiter"},
                {19,"Qadim Kite"},
                {20,"Sword Collector(s)"},
                {21,"Shield Collector(s)"},
            };
            IDictionary<int, Point> RandomizedBoxes_to_LocationDictioanry = new Dictionary<int, Point>
            {
                {0,new Point(100,30)},
                {1,new Point(200,0)},
                {2,new Point(200,15)},
                {3,new Point(0,0)},
                {4,new Point(0,15)},
                {5,new Point(0,30)},
                {6,new Point(100,0)},
                {7,new Point(100,15)},
                {8,new Point(200,30)},
                {9,new  Point(300,0)},
                {10,new Point(300,15)},
                {11,new Point(300,30)},
                {12,new Point(400,0)},
                {13,new Point(400,15)},
                {14,new Point(400,30)},
                {15,new Point(500,0)},
                {16,new Point(500,15)},
                {17,new Point(500,30)},
                {18,new Point(600,0)},
                {19,new Point(600,15)},
                {20,new Point(600,30)},
                {21,new Point(700,0)},
            };
            IDictionary<int, int> CounterBoxes_MaxAllowedIntValues = new Dictionary<int, int>
            {
                {0, 2},
                {1, 2},
                {2, 2},
                {3, 2},
                {4, 4},
                {5, 2},
                {6, 3},
                {7, 3},
                {8, 5},
                {9, 2},
                {10, 2},
                {11, 2}
            };
            IDictionary<int, string> CounterBoxInt_to_Text = new Dictionary<int, string>
            {
                {0, "# of Heal/Alac"},
                {1, "# of Heal/Quick"},
                {2, "# of DPS/Alac"},
                {3, "# of DPS/Quick"},
                {4, "# of Mushrooms"},
                {5, "# of Cannons"},
                {6, "# of Lamps"},
                {7, "# of Pylons"},
                {8, "# of Pillars"},
                {9, "# of Greens"},
                {10, "# of Swords"},
                {11, "# of Shields"}
            };
            for (int i = 0; i < 22; i++)
            {
                _rolestoRandomizeSelectionCheckboxesArray[i] = new CustomCheckbox(_deserializedSettings._rolesToGenerate[i])
                {
                    Text = RandomizeSelectionBoxesInt_to_NameDictionary[i] + "  ",
                    BasicTooltipText = "Check this box to include " + RandomizeSelectionBoxesInt_to_TooltipDictionary[i] + " in the randomization",
                    Parent = _randomizeCheckboxesPanel,
                    Checked = _deserializedSettings._rolesToGenerate[i],
                    Location = RandomizedBoxes_to_LocationDictioanry[i]

                };
            }
            #endregion
            #region CounterBoxes
            IDictionary<int, int> CounterBox_X_PositionDictionary = new Dictionary<int, int>
            {
                {0, 100},
                {1, 100},
                {2, 100},
                {3, 100},
                {4, 100},
                {5, 260},
                {6, 260},
                {7, 260},
                {8, 260},
                {9, 260},
                {10, 420},
                {11, 420},
            };
            IDictionary<int, int> CounterBox_Y_PositionDictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 25},
                {2, 50},
                {3, 75},
                {4, 100},
                {5, 0},
                {6, 25},
                {7, 50},
                {8, 75},
                {9, 100},
                {10, 0},
                {11, 25},
            };
            for (int i = 0; i < 12; i++)
            {
                _counterBoxes[i] = new CounterBox
                {
                    MaxValue = CounterBoxes_MaxAllowedIntValues[i],
                    Parent = _rolesWithNumbers,
                    ValueWidth = 10,
                    Width = 60,
                    BasicTooltipText = CounterBoxInt_to_Text[i],
                    Value = _deserializedSettings._counterBoxesSettings[i],//_counterBoxesSettings[i],
                    MinValue = 0,
                    Location = new Point(CounterBox_X_PositionDictionary[i], CounterBox_Y_PositionDictionary[i])
                };
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
            #region Labels

            IDictionary<int, int> CounterBoxLabel_X_PositionDictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 160},
                {6, 160},
                {7, 160},
                {8, 160},
                {9, 160},
                {10, 320},
                {11, 320},
            };
            IDictionary<int, int> CounterBoxLabel_Y_PositionDictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 25},
                {2, 50},
                {3, 75},
                {4, 100},
                {5, 0},
                {6, 25},
                {7, 50},
                {8, 75},
                {9, 100},
                {10, 0},
                {11, 25},
            };

            _counterBoxLabels = new Label[12];
            for (int i = 0; i < 12; i++)
            {
                _counterBoxLabels[i] = new Label
                {
                    Text = CounterBoxInt_to_Text[i],
                    Size = new Point(100, 25),
                    Location = new Point(CounterBoxLabel_X_PositionDictionary[i], CounterBoxLabel_Y_PositionDictionary[i]),
                    Parent = _rolesWithNumbers
                };
            }
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
            _counterBoxes[0].Click += CounterBox1Click;
            _counterBoxes[1].Click += CounterBox2Click;
            _counterBoxes[2].Click += CounterBox3Click;
            _counterBoxes[3].Click += CounterBox4Click;
            _counterBoxes[4].Click += CounterBox5Click;
            _counterBoxes[5].Click += CounterBox6Click;
            _counterBoxes[6].Click += CounterBox7Click;
            _counterBoxes[7].Click += CounterBox8Click;
            _counterBoxes[8].Click += CounterBox9Click;
            _counterBoxes[9].Click += CounterBox10Click;
            _counterBoxes[10].Click += CounterBox11Click;
            _counterBoxes[11].Click += CounterBox12Click;
            #endregion
            base.Build(buildPanel);

        }
        #region Event Functions
        #region CounterBox Click Functions
        private void CounterBox12Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[11] = _counterBoxes[11].Value;
        }

        private void CounterBox11Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[10] = _counterBoxes[10].Value;
        }

        private void CounterBox10Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[9] = _counterBoxes[9].Value;
        }

        private void CounterBox9Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[8] = _counterBoxes[8].Value;
        }

        private void CounterBox8Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[7] = _counterBoxes[7].Value;
        }

        private void CounterBox7Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[6] = _counterBoxes[6].Value;
        }

        private void CounterBox6Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[5] = _counterBoxes[5].Value;
        }

        private void CounterBox5Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[4] = _counterBoxes[4].Value;
        }

        private void CounterBox4Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[3] = _counterBoxes[3].Value;
        }

        private void CounterBox3Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[2] = _counterBoxes[2].Value;
        }

        private void CounterBox2Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[1] = _counterBoxes[1].Value;
        }

        private void CounterBox1Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _counterBoxesSettings[0] = _counterBoxes[0].Value;
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
        private void GenerateRolesButton_Click(object sender, Blish_HUD.Input.MouseEventArgs e) //uncomment structure below for debugging mode
        {
            //while (true)
            //{
            //DebuggerMethod(); //randomize settings first
            var prepRolesInstance = new PrepareRoles(_deserializedSettings);
            prepRolesInstance.Main();
            RoleRandomizerMain._randomizerResultsWindow.Show();
            //}
        }
        #endregion

    }
}
