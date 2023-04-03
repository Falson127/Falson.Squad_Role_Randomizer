using Blish_HUD.Controls;
using Blish_HUD.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.SquadRoleRandomizer
{
    public class WingButton : StandardButton
    {
        private readonly List<Checkbox> _controlledBoxes;
        private bool _allboxeschecked;
        public WingButton(List<Checkbox> controlledBoxes,string buttonText, int _xpos, int _ypos, Container parent) //pass list of checkboxes to control, the Text for the button, position, and parent container
        {
            _controlledBoxes = controlledBoxes;
            this._location = new Microsoft.Xna.Framework.Point(_xpos, _ypos);
            this.Text = buttonText;
            this.Size = new Microsoft.Xna.Framework.Point(50, 25);
            this.Parent = parent;

        }
        protected override void OnClick(MouseEventArgs e)
        {
            _allboxeschecked = true;
            foreach (Checkbox box in _controlledBoxes)
            {
                if (box.Checked == false)
                {
                    _allboxeschecked = false;
                }
            }
            if (_allboxeschecked)
            {
                foreach (Checkbox box in _controlledBoxes)
                {
                    box.Checked = false;
                }
            }
            else
            {
                foreach (Checkbox box in _controlledBoxes)
                {
                    box.Checked = true;
                }
            }
            base.OnClick(e);
        }
    }
}
