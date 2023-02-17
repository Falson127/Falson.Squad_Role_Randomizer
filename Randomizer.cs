using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using falson = Falson.Squad_Role_Randomizer.RoleRandomizerMain;
using falsonG = Falson.Squad_Role_Randomizer.GenerateRoles;

namespace Falson.Randomizer.Randomizer
{
    class Randomizer
    {
        private List<List<string>> ListsOfLength1;
        private List<List<string>> ListsOfLength2;
        private List<List<string>> ListsOfLength3;
        private List<List<string>> ListsOfLength4;
        private List<List<string>> ListsOfLength5;
        private List<List<string>> ListsOfLength6;
        private List<List<string>> ListsOfLength7;
        private List<List<string>> ListsOfLength8;
        private List<List<string>> ListsOfLength9;
        private List<List<string>> ListsOfLength10;
        private static List<List<string>> HandKiteExclusivityBubble;
        private static List<List<string>> OilKiteExclusivityBubble;
        private static List<List<string>> FlakKiteExclusivityBubble;
        private static List<List<string>> TankExclusivityBubble;
        private static List<List<string>> HealAlacExclusivityBubble;
        private static List<List<string>> HealQuickExclusivityBubble;
        private static List<List<string>> DPSAlacExclusivityBubble;
        private static List<List<string>> DPSQuickExclusivityBubble;
        private static List<List<string>> MushroomExclusivityBubble;
        private static List<List<string>> ReflectExclusivityBubble;
        private static List<List<string>> CannonExclusivityBubble;
        private static List<List<string>> LampExclusivityBubble;
        private static List<List<string>> PylonExclusivityBubble;
        private static List<List<string>> PillarExclusivityBubble;
        private static List<List<string>> GreenExclusivityBubble;
        private static List<List<string>> SoullessPusherExclusivityBubble;
        private static List<List<string>> DhuumKiteExclusivityBubble;
        private static List<List<string>> QadimKiteExclusivityBubble;
        private static List<List<string>> SwordExclusivityBubble;
        private static List<List<string>> ShieldExclusivityBubble;
        private List<List<List<string>>> ListofExclusivityBubbles;

        public void DefineExlusiveLists() 
        {
            HandKiteExclusivityBubble = new List<List<string>> { falson.TankValid, falson.OilKiteValid, falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid };
            OilKiteExclusivityBubble = new List<List<string>> { falson.TankValid, falson.HandKiteValid };
            FlakKiteExclusivityBubble = new List<List<string>> { falson.CannonValid };
            TankExclusivityBubble = new List<List<string>> { falson.HandKiteValid, falson.OilKiteValid, falson.DPSAlacValid, falson.DPSQuickValid };
            HealAlacExclusivityBubble = new List<List<string>> { falson.DPSAlacValid, falson.DPSQuickValid, falson.HealQuickValid, falson.HandKiteValid, falson.MushroomValid, falson.ReflectValid, falson.LampValid, falson.PylonValid, falson.GreenValid, falson.SoullessPusherValid };
            HealQuickExclusivityBubble = new List<List<string>> { falson.DPSAlacValid, falson.DPSQuickValid, falson.HealAlacValid, falson.HandKiteValid, falson.MushroomValid, falson.ReflectValid, falson.LampValid, falson.PylonValid, falson.GreenValid, falson.SoullessPusherValid };
            DPSAlacExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid, falson.DPSQuickValid, falson.HandKiteValid, falson.LampValid, falson.PylonValid, falson.GreenValid, falson.SoullessPusherValid, falson.DhuumKiteValid, falson.QadimKiteValid };
            DPSQuickExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.HandKiteValid, falson.LampValid, falson.PylonValid, falson.GreenValid, falson.SoullessPusherValid, falson.DhuumKiteValid, falson.QadimKiteValid };
            MushroomExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid };
            ReflectExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid };
            CannonExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid };
            LampExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid, falson.QadimKiteValid };
            PylonExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid, falson.TankValid };
            PillarExclusivityBubble = new List<List<string>> { falson.TankValid };
            GreenExclusivityBubble = new List<List<string>> { falson.TankValid, falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid };
            SoullessPusherExclusivityBubble = new List<List<string>> { falson.TankValid, falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid };
            DhuumKiteExclusivityBubble = new List<List<string>> { falson.TankValid, falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid, falson.GreenValid };
            QadimKiteExclusivityBubble = new List<List<string>> { falson.TankValid, falson.HealAlacValid, falson.HealQuickValid, falson.DPSAlacValid, falson.DPSQuickValid, falson.LampValid };
            SwordExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid };
            ShieldExclusivityBubble = new List<List<string>> { falson.HealAlacValid, falson.HealQuickValid };
            ListofExclusivityBubbles = new List<List<List<string>>> { HandKiteExclusivityBubble, OilKiteExclusivityBubble, FlakKiteExclusivityBubble, TankExclusivityBubble, HealAlacExclusivityBubble, HealQuickExclusivityBubble, DPSAlacExclusivityBubble, DPSQuickExclusivityBubble, MushroomExclusivityBubble, ReflectExclusivityBubble, CannonExclusivityBubble, LampExclusivityBubble, PylonExclusivityBubble, PillarExclusivityBubble, GreenExclusivityBubble, SoullessPusherExclusivityBubble, DhuumKiteExclusivityBubble, QadimKiteExclusivityBubble, SwordExclusivityBubble, ShieldExclusivityBubble };

        }

        public void BeginRandomization() 
        {
            //ValidRoleLists, which have been sorted smallest to largest, are brought in using falsonG.GenerationSequence
            IDictionary<List<List<string>>, List<string>> RolesDictionary = new Dictionary<List<List<string>>, List<string>>
            {
                {HandKiteExclusivityBubble,falson.HandKiteValid},
                {OilKiteExclusivityBubble, falson.OilKiteValid},
                {FlakKiteExclusivityBubble,falson.FlakKiteValid},
                {TankExclusivityBubble, falson.TankValid},
                {HealAlacExclusivityBubble,falson.HealAlacValid},
                {HealQuickExclusivityBubble,falson.HealQuickValid},
                {DPSAlacExclusivityBubble,falson.DPSAlacValid},
                {DPSQuickExclusivityBubble,falson.DPSQuickValid},
                {MushroomExclusivityBubble,falson.MushroomValid},
                {ReflectExclusivityBubble,falson.ReflectValid},
                {CannonExclusivityBubble,falson.CannonValid},
                {LampExclusivityBubble,falson.LampValid},
                {PylonExclusivityBubble,falson.PylonValid},
                {PillarExclusivityBubble,falson.PillarValid},
                {GreenExclusivityBubble,falson.GreenValid},
                {SoullessPusherExclusivityBubble,falson.SoullessPusherValid},
                {DhuumKiteExclusivityBubble,falson.DhuumKiteValid},
                {QadimKiteExclusivityBubble,falson.QadimKiteValid},
                {SwordExclusivityBubble,falson.SwordValid},
                {ShieldExclusivityBubble,falson.ShieldValid}
            };
            IDictionary<int, List<List<string>>> listsize_to_Listsoflistsize = new Dictionary<int, List<List<string>>> 
            {
                {1 , ListsOfLength1},
                {2 , ListsOfLength2},
                {3 , ListsOfLength3},
                {4 , ListsOfLength4},
                {5 , ListsOfLength5},
                {6 , ListsOfLength6},
                {7 , ListsOfLength7},
                {8 , ListsOfLength8},
                {9 , ListsOfLength9},
                {10, ListsOfLength10}
            };
            IDictionary<List<List<string>>, int> ListsofLengthX_to_minUniqueNames = new Dictionary<List<List<string>>, int>
            {
                {ListsOfLength1, 1 },
                {ListsOfLength2, 2 },
                {ListsOfLength3, 3 },
                {ListsOfLength4, 4 },
                {ListsOfLength5, 5 },
                {ListsOfLength6, 6 },
                {ListsOfLength7, 7 },
                {ListsOfLength8, 8 },
                {ListsOfLength9, 9 },
                {ListsOfLength10,10}
            };
            List<List<List<string>>> ListsOfLengthX = new List<List<List<string>>>(){ListsOfLength1,ListsOfLength2,ListsOfLength3,ListsOfLength4,ListsOfLength5,ListsOfLength6,ListsOfLength7,ListsOfLength8,ListsOfLength9,ListsOfLength10};
            foreach (var ValidNameList in falsonG.GenerationSequence)
            {
                listsize_to_Listsoflistsize[ValidNameList.Count()].Add(ValidNameList); //populates the ListsOfLengthXs
            }
            var sortedNameList = new List<List<string>>();
            foreach (var nameList in ListsOfLengthX)
            {
                sortedNameList = ListofExclusivityBubbles.OrderByDescending(l => l.Count).Select(l => RolesDictionary[l]).ToList(); //If I understand it correctly, this should take l, a list of list<string>'s within LoEB's, order it by descending sizes
            }                                                                                                                       //and then for each l, return the dictionary linked rolevalid list sorted by which has the higher number of conflicts.
            foreach (var item in sortedNameList)
            {
                Debug.WriteLine(item.ToString());
            }
            //foreach (var item in falsonG.GenerationSequence)
            //{
            //    falsonG.GenerationFunctions.Add(FriendlyNames_to_ActionsDictionary[item]);
            //}
        }
    }
}
