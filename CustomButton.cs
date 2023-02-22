using Blish_HUD.Controls;
using Blish_HUD.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.SquadRoleRandomizer
{
    public class CustomButton : StandardButton
    {
        private readonly Panel _playerRolePanel;
        private bool _allboxeschecked;
        public CustomButton(Panel playerRolePanel, int _xpos, int _ypos)
        {
            _playerRolePanel = playerRolePanel;
            this.Parent = playerRolePanel.Parent;
            this.Location = new Microsoft.Xna.Framework.Point(_xpos, _ypos);
            this.Size = new Microsoft.Xna.Framework.Point(130, 25);
            this.Text = "Check/Uncheck All";
        }
        protected override void OnClick(MouseEventArgs e)
        {
            _allboxeschecked = true;
            foreach (CustomCheckbox child in _playerRolePanel.Children)
            {
                if (child.Checked == false)
                {
                    _allboxeschecked = false;
                }
            }
            if (_allboxeschecked ) 
            {
                foreach (CustomCheckbox child in _playerRolePanel.Children)
                {
                    child.Checked = false;
                }
            }
            else
            {
                foreach (CustomCheckbox child in _playerRolePanel.Children)
                {
                    child.Checked = true;
                }
            }
            base.OnClick(e);
        }
    }
}
