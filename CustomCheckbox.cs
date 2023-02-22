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
        private readonly SettingEntry<bool> _settingEntry;

        public CustomCheckbox(SettingEntry<bool> settingsEntry)
        {
            _settingEntry = settingsEntry;
        }
        protected override void OnCheckedChanged(CheckChangedEvent e)
        {
            _settingEntry.Value = Checked;
            base.OnCheckedChanged(e);
        }
    }
}
