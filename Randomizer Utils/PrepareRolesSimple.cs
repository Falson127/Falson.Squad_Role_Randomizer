using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falson.SquadRoleRandomizer.Randomizer_Utils
{
    public class PrepareRolesSimple
    {
        private readonly bool[] _wingsToGenerate;
        private readonly FalsonSettings _deserializedSettings;
        public PrepareRolesSimple(FalsonSettings deserializedSettings, bool[] wingsToGenerate) 
        {
            _deserializedSettings = deserializedSettings;
            _wingsToGenerate = wingsToGenerate;
        }
    
        public void Main() 
        {
            
        }
    }
}
