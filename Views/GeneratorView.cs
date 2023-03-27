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
using System.Windows.Forms.VisualStyles;
using Falson.SquadRoleRandomizer.Randomizer_Utils;

namespace Falson.SquadRoleRandomizer.Views
{
    public class GeneratorView : View
    {
        //objects we need: Roles to generate, Advanced options for things like tank = healer automatically, full comp randomization (it will randomly decide what boons each healer will pull,
        //and then fill in dps similar to the python version. Checkboxes to enable/disable including a specific player in the generation (that way you can easily statically set a given person)
        //Dropdown to select which static settings to pull from for the generation (I think maybe just allow 3 statics for now will be good).

        //external (from this class) data we need: The base64string for the chosen static to pass to the encoder class

        private bool[] _playersToInclude = new bool[10];
        private string _selectedBase64string;
        private SettingEntry<string>[] _base64Strings;
        //private FalsonSettings _settingsObject;
        private Panel _masterPanel;
        //private Panel _advancedSettingsPanel;
        private Panel _wingsToIncludePanel;
        private Panel _advancedRolesToGeneratePanel;
        private Panel _numberToGeneratePanel;
        private Dropdown _staticSelectionDropdown;
        private Checkbox[] _playerDisableBoxes = new Checkbox[10];
        private Checkbox[] _rolesToGenerateBoxes = new Checkbox[23];
        private CounterBox[] _counterBoxes = new CounterBox[12];
        private Label[] _counterBoxLabels = new Label[12];
        private StandardButton _generateRolesButton;
        private Checkbox _enableAdvancedConfigBox;
        private Checkbox _hotWingsEnabled;
        private Checkbox _pofWingsEnabled;
        private readonly FalsonSettings _deserializedSettings;

        public GeneratorView(SettingEntry<string>[] base64StringSettings) 
        {
            _base64Strings = base64StringSettings;
            SettingsEncoder localEncoder = new SettingsEncoder(_base64Strings[0].Value);
            _deserializedSettings = localEncoder.GetSettings();

        }

        protected override void Build(Container buildPanel)
        {

            _advancedRolesToGeneratePanel = new Panel 
            {
                Parent = buildPanel,
                Size = new Point(1000,120),
                Location = new Point (0, 180),
                Title = "Roles to Generate"
            };
            _hotWingsEnabled = new Checkbox 
            {
                Text = "Enable HoT Mechanics",
                BasicTooltipText = "If checked, this box will enable assignment of HoT specific mechanics in the randomization",
                Checked = true,
                Parent = _wingsToIncludePanel,
                Location = new Point(500,25)
            };
            _pofWingsEnabled = new Checkbox 
            {
                Text = "Enable PoF Mechanics",
                BasicTooltipText = "If checked, this box will enable assignment of PoF specific mechanics in the randomization",
                Checked = true,
                Parent = _wingsToIncludePanel,
                Location = new Point(500,75)
            };
            _enableAdvancedConfigBox = new Checkbox 
            {
                Text = "Advanced Configuration Mode",
                BasicTooltipText = "Check this box to enable greater customization of the role randomizer",
                Checked = false,
                Location = new Point(0,0),
                Parent = buildPanel
            };
            _enableAdvancedConfigBox.CheckedChanged += _enableAdvancedConfigBox_CheckedChanged;
            for (int i = 0; i < 10; i++)
            {
                int xpos;
                int ypos;
                if (i<5)
                {
                    xpos = 0;
                    ypos = (i * 25) + 25;
                }
                else 
                {
                    xpos = 150;
                    ypos = (25 * (i-5))+25;
                }
                _playerDisableBoxes[i] = new Checkbox
                {
                    Text = $"Disable {_deserializedSettings._playerNames[i]}",
                    BasicTooltipText = $"Check this box to prevent {_deserializedSettings._playerNames[i]} from being included in the randomization",
                    Checked = false,
                    Parent = buildPanel,
                    Location = new Point(xpos, ypos)
                };
                var j = i;
                _playerDisableBoxes[j].CheckedChanged += delegate
                {
                    _playersToInclude[j] = !_playerDisableBoxes[j].Checked;
                };
            }
            _numberToGeneratePanel = new Panel
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
                Parent = _masterPanel,
            };
            _wingsToIncludePanel = new Panel
            {
                Title = "Select Wings to Generate Roles For",
                Parent = _masterPanel,
                Size = new Point(1000,120)
            };
            _generateRolesButton.Click += GenerateRolesButton_Click;
            Dropdown dropdown1 = new Dropdown
            {
                Parent = buildPanel,
                Location = new Point(0, 150)
            };
            dropdown1.Items.Add("Static 1");
            dropdown1.Items.Add("Static 2");
            dropdown1.Items.Add("Static 3");

            _staticSelectionDropdown = dropdown1;
            _staticSelectionDropdown.ValueChanged += SelectedStaticChanged;

            IDictionary<int, string> RandomizeSelectionBoxesInt_to_NameDictionary = new Dictionary<int, string>
            {
                {0,"Hand Kite"},
                {1,"Oil Kite"},
                {2,"Flak Kite"},
                {3,"Heal/Alac Tank"},
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
                {22, "Heal/Quick Tank"}
            };
            IDictionary<int, string> RandomizeSelectionBoxesInt_to_TooltipDictionary = new Dictionary<int, string>
            {
                {0,"Hand Kite"},
                {1,"Oil Kite"},
                {2,"Flak Kite"},
                {3,"Heal/Alac Tank"},
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
                {22, "Heal/Quickness Tank" }
            };
            IDictionary<int, Point> RandomizedBoxes_to_LocationDictioanry = new Dictionary<int, Point>
            {
                {7,new Point(140,30)},
                {1,new Point(240,0)},
                {2,new Point(240,15)},
                {3,new Point(0,0)},
                {22,new Point(0,15)}, 
                {4,new Point(0,30)},
                {5,new Point(140,0)},
                {6,new Point(140,15)},
                {0,new Point(240,30)},
                {8,new  Point(340,0)},
                {9,new Point(340,15)},
                {10,new Point(340,30)},
                {11,new Point(440,0)},
                {12,new Point(440,15)},
                {13,new Point(440,30)},
                {14,new Point(540,0)},
                {15,new Point(540,15)},
                {16,new Point(540,30)},
                {17,new Point(640,0)},
                {18,new Point(640,15)},
                {19,new Point(640,30)},
                {20,new Point(740,0)},
                {21,new Point(740,15)}
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
            for (int j = 0; j < 23; j++)
            {
                int i = j;
                _rolesToGenerateBoxes[i] = new Checkbox
                {
                    Text = RandomizeSelectionBoxesInt_to_NameDictionary[i] + "  ",
                    BasicTooltipText = "Check this box to include " + RandomizeSelectionBoxesInt_to_TooltipDictionary[i] + " in the randomization",
                    Parent = _advancedRolesToGeneratePanel,
                    Checked = true,
                    Location = RandomizedBoxes_to_LocationDictioanry[i]

                };
            }

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
                    Parent = _numberToGeneratePanel,
                    ValueWidth = 10,
                    Width = 60,
                    BasicTooltipText = CounterBoxInt_to_Text[i],
                    Value = _deserializedSettings._counterBoxesSettings[i],//_counterBoxesSettings[i],
                    MinValue = 0,
                    Location = new Point(CounterBox_X_PositionDictionary[i], CounterBox_Y_PositionDictionary[i])
                };
            }
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
                    Parent = _numberToGeneratePanel
                };
            }
            #endregion
            base.Build(buildPanel);
        }

        private void GeneratorView_CheckedChanged(object sender, CheckChangedEvent e)
        {
            throw new NotImplementedException();
        }

        private void _enableAdvancedConfigBox_CheckedChanged(object sender, CheckChangedEvent e)
        {
            //when box is changed, get the current state
            var state = _enableAdvancedConfigBox.Checked;
            if (state)
            {
                _advancedRolesToGeneratePanel.Show();
                //_advancedSettingsPanel.Show();
                _numberToGeneratePanel.Show();
                _wingsToIncludePanel.Hide();
            }
            else
            {
                _advancedRolesToGeneratePanel.Hide();
                _numberToGeneratePanel.Hide();
                _wingsToIncludePanel.Show();
            }
        }

        private void SelectedStaticChanged(object sender, ValueChangedEventArgs e) //set selected settings string after changing in dropdown
        {
            if (_staticSelectionDropdown.SelectedItem == "Static 1")
            {
                _selectedBase64string = _base64Strings[0].Value;
            }
            if (_staticSelectionDropdown.SelectedItem == "Static 2")
            {
                _selectedBase64string = _base64Strings[1].Value;
            }
            if (_staticSelectionDropdown.SelectedItem == "Static 3")
            {
                _selectedBase64string = _base64Strings[2].Value;
            }
        }

        private void GenerateRolesButton_Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            SettingsEncoder localEncoder = new SettingsEncoder(_selectedBase64string); //initialize decoder with selected base64 string
            var localSettings = localEncoder.GetSettings(); //get settings object from string
            
            if (_enableAdvancedConfigBox.Checked) //if advanced config is checked, send to the original role preparation class
            {
                PrepareRoles localPreparer = new PrepareRoles(localSettings); //call prep roles with the settings object for the selected static
                localPreparer.Main();
                RoleRandomizerMain._randomizerResultsWindow.Show();
            }
            else //if advanced config is not checked, send to the new role preparer for a simple composition
            {
                PrepareRolesSimple localPreparer = new PrepareRolesSimple(localSettings,_hotWingsEnabled.Checked,_pofWingsEnabled.Checked);
                localPreparer.Main();
                RoleRandomizerMain._randomizerResultsWindow.Show();
            }
        }

    }
}
