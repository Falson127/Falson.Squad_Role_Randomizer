using Blish_HUD.Controls;
using Blish_HUD.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.SquadRoleRandomizer
{
    public class CustomCheckbox : Checkbox
    {
        //private bool _settingEntry; //change this to bool instead of settingentry<bool> to connect new settings
        private readonly Action<bool> _callback;
        public CustomCheckbox(bool settingsEntry, Action<bool> callback)//I think also add another callback action here to allow a delegate that updates the base64string when this box gets changed
        {
            _callback = callback;
            _callback.Invoke(settingsEntry);
        }
        protected override void OnCheckedChanged(CheckChangedEvent e)
        {
            _callback.Invoke(Checked);
            base.OnCheckedChanged(e);
        }
    }
}
