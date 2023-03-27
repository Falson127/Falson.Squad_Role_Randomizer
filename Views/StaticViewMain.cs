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

namespace Falson.SquadRoleRandomizer.Views
{
    public class StaticViewMain : View
    {
        private Panel _viewContainingPanel;
        private Dropdown _staticSelectionDropdown;
        private ViewContainer _viewContainer;
        private int _selectedSettings;

        //public StaticViewMain()
        
        protected override void Build(Container buildPanel)
        {
            _viewContainingPanel = new Panel
            { 
                Size = new Point(1050, 800),
                Location = new Point(0, 0),
                ShowBorder = false,
                Parent = buildPanel
            };
            Dropdown dropdown1 = new Dropdown
            {
                BasicTooltipText = "Select which static you would like to modify",
                Size = new Point(150, 50),
                Location = new Point(600, 75),
                Parent = _viewContainingPanel,
                ZIndex = 10
            };
            dropdown1.Items.Add("Static 1");
            dropdown1.Items.Add("Static 2");
            dropdown1.Items.Add("Static 3");
            _staticSelectionDropdown = dropdown1;
            _staticSelectionDropdown.SelectedItem = _staticSelectionDropdown.Items[0];
            _selectedSettings = 0;

            //Create Settings Encoder Instance
            SettingsEncoder localEncoder = new SettingsEncoder(RoleRandomizerMain._base64strings[_selectedSettings].Value);
            var localSettingsObject = localEncoder.GetSettings();
            //create staticview instance
            StaticView localView = new StaticView(localSettingsObject, RoleRandomizerMain._base64strings[_selectedSettings]);
            _viewContainer = new ViewContainer();
            _viewContainer.Size = new Point(1050, 800);
            _viewContainer.Parent = _viewContainingPanel;
            _viewContainer.Show(localView);
            _viewContainingPanel.Children.Add(_viewContainer);
            _staticSelectionDropdown.ValueChanged += staticChanged;
        }

        private void staticChanged(object sender, ValueChangedEventArgs e)
        {
            if (_staticSelectionDropdown.SelectedItem == "Static 1")
            {
                _selectedSettings = 0;
            }
            else if ( _staticSelectionDropdown.SelectedItem == "Static 2")
            {
                _selectedSettings = 1;
            }
            else
            {
                _selectedSettings = 2;
            }
            SettingsEncoder localEncoder = new SettingsEncoder(RoleRandomizerMain._base64strings[_selectedSettings].Value);
            var localSettingsObject = localEncoder.GetSettings();
            StaticView localView = new StaticView(localSettingsObject, RoleRandomizerMain._base64strings[_selectedSettings]);
            _viewContainer.Show(localView);
        }
    }
}
