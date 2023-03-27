using Blish_HUD.Controls;
using Blish_HUD.Input;
using Falson.SquadRoleRandomizer.Views;
using MonoGame.Extended.Screens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Falson.SquadRoleRandomizer.Custom_Controls
{
    public class IOButton : StandardButton
    {
        private readonly string _IOType;
        private readonly int _settingIndex;
        public IOButton(string IOType, int settingIndex) 
        {
            _IOType = IOType;
            _settingIndex = settingIndex;
        }
        protected override void OnClick(Blish_HUD.Input.MouseEventArgs e)
        {
            if (_IOType == "Import")
            {
                try
                {
                    string clipboardText = Clipboard.GetText();
                    string json = Encoding.UTF8.GetString(Convert.FromBase64String(clipboardText)); //try to convert the base64 string into the raw json, if it works then code continues
                    FalsonSettings DeserializedSettings = JsonConvert.DeserializeObject<FalsonSettings>(json); //try to deserialize the json into my settings class, if it works, then it is valid and string can be placed into chosen settings index
                    RoleRandomizerMain._base64strings[_settingIndex].Value = clipboardText;
                    ScreenNotification.ShowNotification("Settings Successfully Imported", ScreenNotification.NotificationType.Green);
                    SettingsEncoder localEncoder = new SettingsEncoder(RoleRandomizerMain._base64strings[_settingIndex].Value);
                    var localSettingsObject = localEncoder.GetSettings();
                    StaticView localView = new StaticView(localSettingsObject, RoleRandomizerMain._base64strings[_settingIndex], _settingIndex);
                    StaticViewMain._viewContainer.Show(localView);

                }
                catch (Exception)
                {
                    ScreenNotification.ShowNotification("Invalid Settings String", ScreenNotification.NotificationType.Red);
                }
            }
            if (_IOType == "Export")
            {
                string settingsString = RoleRandomizerMain._base64strings[_settingIndex].Value;
                Clipboard.SetText(settingsString);
                ScreenNotification.ShowNotification("Settings Copied to Clipboard", ScreenNotification.NotificationType.Info);
            }
            base.OnClick(e);
        }
    }
}
