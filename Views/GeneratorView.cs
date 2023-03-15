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
        private SettingEntry<string> _base64Strings;
        private FalsonSettings _settingsObject;
        private Panel _masterPanel;
        private Panel _advancedSettingsPanel;
        private Panel _rolesToGeneratePanel;
        private Panel _numberToGeneratePanel;
        private Dropdown _staticSelectionDropdown;
        private Checkbox[] _playerDisableBoxes = new Checkbox[10];
        private StandardButton _generateRolesButton;

        public GeneratorView(SettingEntry<string> base64StringSettings) 
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
            _generateRolesButton.Click += GenerateRolesButton_Click;


            base.Build(buildPanel);
        }
        private void GenerateRolesButton_Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {

        }

        private void TriggerGenerator() 
        {
            //call this to pass all current settings plus the selected static config to the Prepare Roles class
        }


    }
}
