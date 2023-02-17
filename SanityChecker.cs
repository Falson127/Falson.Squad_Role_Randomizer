using System.Collections.Generic;
using System.Linq;
using falson = Falson.Squad_Role_Randomizer.RoleRandomizerMain;

namespace Falson.Randomizer.Sanity_Checker
{
    public class SanityChecker
    {
        //Define Exclusivity Bubbles First in Class
        private List<List<string>> HandKiteExclusivityBubble;
        private List<List<string>> OilKiteExclusivityBubble;
        private List<List<string>> FlakKiteExclusivityBubble;
        private List<List<string>> TankExclusivityBubble;
        private List<List<string>> HealAlacExclusivityBubble;
        private List<List<string>> HealQuickExclusivityBubble;
        private List<List<string>> DPSAlacExclusivityBubble;
        private List<List<string>> DPSQuickExclusivityBubble;
        private List<List<string>> MushroomExclusivityBubble;
        private List<List<string>> ReflectExclusivityBubble;
        private List<List<string>> CannonExclusivityBubble;
        private List<List<string>> LampExclusivityBubble;
        private List<List<string>> PylonExclusivityBubble;
        private List<List<string>> PillarExclusivityBubble;
        private List<List<string>> GreenExclusivityBubble;
        private List<List<string>> SoullessPusherExclusivityBubble;
        private List<List<string>> DhuumKiteExclusivityBubble;
        private List<List<string>> QadimKiteExclusivityBubble;
        private List<List<string>> SwordExclusivityBubble;
        private List<List<string>> ShieldExclusivityBubble;
        private List<List<List<string>>> ListofExclusivityBubbles;


        protected void CheckForSanity() 
        {
            HandKiteExclusivityBubble = new List<List<string>> {falson.TankValid,falson.OilKiteValid,falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid };
            OilKiteExclusivityBubble = new List<List<string>>{falson.TankValid, falson.HandKiteValid};
            FlakKiteExclusivityBubble = new List<List<string>>{falson.CannonValid};
            TankExclusivityBubble = new List<List<string>>{falson.HandKiteValid, falson.OilKiteValid, falson.DPSAlacValid, falson.DPSQuickValid};
            HealAlacExclusivityBubble = new List<List<string>>{falson.DPSAlacValid,falson.DPSQuickValid,falson.HealQuickValid, falson.HandKiteValid, falson.MushroomValid, falson.ReflectValid,falson.LampValid,falson.PylonValid,falson.GreenValid,falson.SoullessPusherValid};
            HealQuickExclusivityBubble = new List<List<string>>{falson.DPSAlacValid,falson.DPSQuickValid,falson.HealAlacValid,falson.HandKiteValid,falson.MushroomValid,falson.ReflectValid,falson.LampValid,falson.PylonValid,falson.GreenValid,falson.SoullessPusherValid};
            DPSAlacExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid,falson.DPSQuickValid,falson.HandKiteValid,falson.LampValid,falson.PylonValid,falson.GreenValid,falson.SoullessPusherValid,falson.DhuumKiteValid,falson.QadimKiteValid};
            DPSQuickExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid,falson.DPSAlacValid,falson.HandKiteValid,falson.LampValid,falson.PylonValid,falson.GreenValid,falson.SoullessPusherValid,falson.DhuumKiteValid,falson.QadimKiteValid};
            MushroomExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid};
            ReflectExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid};
            CannonExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid};
            LampExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid,falson.DPSAlacValid,falson.DPSQuickValid,falson.QadimKiteValid};
            PylonExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid,falson.DPSAlacValid,falson.DPSQuickValid,falson.TankValid};
            PillarExclusivityBubble = new List<List<string>>{falson.TankValid};
            GreenExclusivityBubble = new List<List<string>>{falson.TankValid,falson.HealAlacValid,falson.HealQuickValid,falson.DPSAlacValid,falson.DPSQuickValid};
            SoullessPusherExclusivityBubble = new List<List<string>>{falson.TankValid,falson.HealAlacValid,falson.HealQuickValid,falson.DPSAlacValid,falson.DPSQuickValid};
            DhuumKiteExclusivityBubble = new List<List<string>>{falson.TankValid,falson.HealAlacValid,falson.HealQuickValid,falson.DPSAlacValid,falson.DPSQuickValid,falson.GreenValid};
            QadimKiteExclusivityBubble = new List<List<string>>{falson.TankValid,falson.HealAlacValid,falson.HealQuickValid,falson.DPSAlacValid,falson.DPSQuickValid,falson.LampValid};
            SwordExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid};
            ShieldExclusivityBubble = new List<List<string>>{falson.HealAlacValid,falson.HealQuickValid};
            ListofExclusivityBubbles = new List<List<List<string>>>{ HandKiteExclusivityBubble,OilKiteExclusivityBubble,FlakKiteExclusivityBubble,TankExclusivityBubble,HealAlacExclusivityBubble,HealQuickExclusivityBubble,DPSAlacExclusivityBubble,DPSQuickExclusivityBubble,MushroomExclusivityBubble,ReflectExclusivityBubble,CannonExclusivityBubble,LampExclusivityBubble,PylonExclusivityBubble,PillarExclusivityBubble,GreenExclusivityBubble,SoullessPusherExclusivityBubble,DhuumKiteExclusivityBubble,QadimKiteExclusivityBubble,SwordExclusivityBubble,ShieldExclusivityBubble};




            //Check Sums of Linked Roles (I.E. How many HealAlac/HealQuick selected? Sum of their counter boxes should only be 2 due to 2 healers)
            //Same for DPSAlac/DPSHeal, and then insure that only 2 for summing HealAlac/DPSalac and HealQuick/DPSQuick


        }
        private bool ContainsUniqueName(List<string> target, List<string> Comparator) 
        {
            foreach (var name in target)
            {
                if (!Comparator.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
    }

}