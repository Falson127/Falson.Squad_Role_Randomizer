using Blish_HUD.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Falson.SquadRoleRandomizer
{
    public class SettingsEncoder
    {
        private SettingEntry<string> _activeSettingEntry;
        private string _activeEncodedSettingsString;
        
        public SettingsEncoder(string base64settingsstring) 
        {
            //grab base64string, store locally, and decode it to json
            string base64string = base64settingsstring;
            string json = Encoding.UTF8.GetString(Convert.FromBase64String(base64string));
            //create instance of settings class and deserialize the json into that instance object
            FalsonSettings DeserializedSettings = JsonConvert.DeserializeObject<FalsonSettings>(json);
            //update the module's primary settings to the decoded string's values (overwrite)

        }
    }
}
