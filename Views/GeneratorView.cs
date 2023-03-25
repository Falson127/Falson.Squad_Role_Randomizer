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
        private FalsonSettings _settingsObject;
        private Panel _masterPanel;
        private Panel _advancedSettingsPanel;
        private Panel _rolesToGeneratePanel;
        private Panel _advancedRolesToGeneratePanel;
        private Panel _numberToGeneratePanel;
        private Dropdown _staticSelectionDropdown;
        private Checkbox[] _playerDisableBoxes = new Checkbox[10];
        private StandardButton _generateRolesButton;
        private Checkbox _enableAdvancedConfigBox;

        public GeneratorView(SettingEntry<string>[] base64StringSettings) 
        {
            _base64Strings = base64StringSettings;
        }

        protected override void Build(Container buildPanel)
        {
            _masterPanel = new Panel 
            {
                Parent = buildPanel,
                Size = new Point(1050,800),
                BackgroundColor = Color.Red
            };

            _enableAdvancedConfigBox = new Checkbox 
            {
                Text = "Advanced Configuration Mode",
                BasicTooltipText = "Check this box to enable greater customization of the role randomizer",
                Checked = false,
                Location = new Point(0,0),
                Parent = _masterPanel
            };

            for (int i = 0; i < 10; i++)
            {
                _playerDisableBoxes[i] = new Checkbox
                {
                    Text = $"Disable Player {i + 1}",
                    BasicTooltipText = $"Check this box to disable player {i + 1} from being included in the randomization",
                    Checked = false,
                    Parent = _advancedSettingsPanel
                };
            }
            _numberToGeneratePanel = new Panel
            {
                Title = "Number of each role to generate",
                Parent = _masterPanel,
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
            _rolesToGeneratePanel = new Panel
            {
                Title = "Select Roles to Generate",
                Parent = _masterPanel,
                Size = new Point(1000,120)
            };
            _generateRolesButton.Click += GenerateRolesButton_Click;
            Dropdown dropdown1 = new Dropdown
            {
                Parent = _masterPanel,
            };
            dropdown1.Items.Add("Static 1");
            dropdown1.Items.Add("Static 2");
            dropdown1.Items.Add("Static 3");

            _staticSelectionDropdown = dropdown1;
            _staticSelectionDropdown.ValueChanged += SelectedStaticChanged;

            base.Build(buildPanel);
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
                PrepareRolesSimple localPreparer = new PrepareRolesSimple(localSettings);
                localPreparer.Main();
                RoleRandomizerMain._randomizerResultsWindow.Show();
            }
        }

    }
}
