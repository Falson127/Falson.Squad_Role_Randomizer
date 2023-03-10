using Blish_HUD.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//flow for using this class. This gets called when creating a view in order to load the states of the control objects. Stores base64 string in variable and creates FalsonSettings Instance to hold object controls
//Then the settings are passed to the view using a publi

namespace Falson.SquadRoleRandomizer
{
    public class SettingsEncoder
    {
        private SettingEntry<string> _activeSettingEntry;
        private string _activeEncodedSettingsString;
        private string _activeJsonString;

        public SettingsEncoder(string base64settingsstring)
        {
            //grab base64string, store locally, and decode it to json
            string base64string = base64settingsstring;
            _activeEncodedSettingsString = base64string;
            string json = Encoding.UTF8.GetString(Convert.FromBase64String(base64string));
            _activeJsonString = json;
            //create instance of settings class and deserialize the json into that instance object
            FalsonSettings DeserializedSettings = JsonConvert.DeserializeObject<FalsonSettings>(json);
        }
        public string UpdateBase64(FalsonSettings DeserializedSettings) 
        {
            string base64string;
            string json = JsonConvert.SerializeObject(DeserializedSettings);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            base64string = Convert.ToBase64String(jsonBytes);
            return base64string;
        }

        public FalsonSettings GetSettings()
        {
            //call to create settings object and pass that object to caller
            FalsonSettings DeserializedSettings = JsonConvert.DeserializeObject<FalsonSettings>(_activeJsonString);
            return DeserializedSettings;
        }




    }
}
