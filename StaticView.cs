using Blish_HUD.Controls;
using Blish_HUD.Graphics.UI;
using Blish_HUD.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Falson.SquadRoleRandomizer
{
    public class StaticView : View
    {
        private string ActiveSettingString;
        private int tabId;

        public StaticView(FalsonSettings deserializedSettings, SettingEntry<string> base64SettingsString, Tab viewWindowTab) 
        {
            Panel omegaMasterPanel = new Panel
            {
                Parent = viewWindowTab
            };
            Panel _rolesWithNumbers = new Panel
            {
                Title = "Number of each role to generate",
                Parent = omegaMasterPanel,
                Size = new Point(480, 165),
                Location = new Point(401, 0),
            };
            StandardButton _generateRolesButton = new StandardButton
            {
                Text = "Generate \n  Roles",
                Size = new Point(80, 100),
                Location = new Point(890, 40),
                Parent = _randomizerSettingsWindow,
            };
            _generateRolesButton.Click += GenerateRolesButton_Click;

        }
        private void GenerateRolesButton_Click(object sender, Blish_HUD.Input.MouseEventArgs e) //uncomment structure below for debugging mode
        {
            //while (true)
            //{
            //DebuggerMethod(); //randomize settings first
            var prepRolesInstance = new PrepareRoles(_listofRolesSettings, _rolesToGenerate, _counterBoxesSettings, _playerNames);
            prepRolesInstance.Main();
            _randomizerResultsWindow.Show();
            //}
        }

    }
}
