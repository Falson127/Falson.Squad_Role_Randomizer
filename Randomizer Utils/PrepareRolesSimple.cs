using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.SquadRoleRandomizer.Randomizer_Utils
{
    public class PrepareRolesSimple
    {
        private readonly bool _hotWingsEnabled;
        private readonly bool _pofWingsEnabled;
        private readonly FalsonSettings _deserializedSettings;
        public PrepareRolesSimple(FalsonSettings deserializedSettings, bool hotWingsEnabled, bool pofWingsEnabled) 
        {
            _deserializedSettings = deserializedSettings;
            _hotWingsEnabled = hotWingsEnabled;
            _pofWingsEnabled = pofWingsEnabled;
        }
    
        public void Main() 
        {
            
        }
    }
}
