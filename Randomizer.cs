using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Blish_HUD;
using falson = Falson.Squad_Role_Randomizer.RoleRandomizerMain;
using falsonG = Falson.Squad_Role_Randomizer.PrepareRoles;

namespace Falson.Randomizer
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
        public static List<Action> GenerationFunctions;

        private static readonly Logger Logger = Logger.GetLogger<Blish_HUD.Modules.Module>();


        public void MainMethod() 
        {
            DefineExlusiveLists();
            BeginRandomization();
        }
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
            GenerationFunctions = new List<Action>();
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
            IDictionary<List<string>, string> ValidRoleLists_to_FriendlyNamesDictionary = new Dictionary<List<string>, string>()
            {
                {falson.HandKiteValid, "HandKite"},
                {falson.OilKiteValid, "OilKite"},
                {falson.FlakKiteValid, "FlakKite"},
                {falson.TankValid, "Tank"},
                {falson.HealAlacValid, "HealAlac"},
                {falson.HealQuickValid, "HealQuick"},
                {falson.DPSAlacValid, "DPSAlac"},
                {falson.DPSQuickValid, "DPSQuick"},
                {falson.MushroomValid, "Mushroom"},
                {falson.TowerValid, "Tower"},
                {falson.ReflectValid, "Reflect"},
                {falson.CannonValid, "Cannon"},
                {falson.ConstrucPusherValid, "ConstrucPusher"},
                {falson.LampValid, "Lamp"},
                {falson.PylonValid, "Pylon"},
                {falson.PillarValid, "Pillar"},
                {falson.GreenValid, "Green"},
                {falson.SoullessPusherValid, "SoullessPusher"},
                {falson.DhuumKiteValid, "DhuumKite"},
                {falson.QadimKiteValid, "QadimKite"},
                {falson.SwordValid, "Sword"},
                {falson.ShieldValid, "Shield"},
            };
            IDictionary<string, Action> FriendlyNames_to_ActionsDictionary = new Dictionary<string, Action>()
            {
                {"HealAlac" , () =>GenerateHealAlac()},
                {"HandKite", () =>GenerateHandKite()},
                {"OilKite", () =>GenerateOilKite()},
                {"FlakKite", () =>GenerateFlakKite()},
                {"Tank", () =>GenerateTank()},
                {"HealQuick", () =>GenerateHealQuick()},
                {"DPSAlac", () =>GenerateDPSAlac()},
                {"DPSQuick", () =>GenerateDPSQuick()},
                {"Mushroom", () =>GenerateMushroom()},
                {"Tower", () =>GenerateTower()},
                {"Reflect", () =>GenerateReflect()},
                {"Cannon", () =>GenerateCannon()},
                {"ConstrucPusher", () =>GenerateConstrucPusher()},
                {"Lamp", () =>GenerateLamp()},
                {"Pylon", () =>GeneratePylon()},
                {"Pillar", () =>GeneratePillar()},
                {"Green", () =>GenerateGreen()},
                {"SoullessPusher", () =>GenerateSoullessPusher()},
                {"DhuumKite", () =>GenerateDhuumKite()},
                {"QadimKite", () =>GenerateQadimKite()},
                {"Sword", () =>GenerateSword()},
                {"Shield", () =>GenerateShield()},
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
            //These Role Lists are then sorted into 10 lists according to size
            List<List<List<string>>> ListsOfLengthX = new List<List<List<string>>>(){ListsOfLength1,ListsOfLength2,ListsOfLength3,ListsOfLength4,ListsOfLength5,ListsOfLength6,ListsOfLength7,ListsOfLength8,ListsOfLength9,ListsOfLength10};
            foreach (var ValidNameList in falsonG.GenerationSequence)
            {
                listsize_to_Listsoflistsize[ValidNameList.Count()].Add(ValidNameList); //populates the ListsOfLengthXs
            }
            //Each size list is then further sorted from largest # of conflicting roles to smallest
            var sortedNameList = new List<List<string>>();
            foreach (var nameList in ListsOfLengthX)
            {
                sortedNameList = ListofExclusivityBubbles.OrderByDescending(l => l.Count).Select(l => RolesDictionary[l]).ToList(); //If I understand it correctly, this should take l, a list of list<string>'s within LoEB's, order it by descending sizes
            }                                                                                                                       //and then for each l, return the dictionary linked rolevalid list sorted by which has the higher number of conflicts.
            //these doubly sorted lists are then added to the GenerationActions list by translating a role list to a generation method
            //allowing them to generate in sequence of the double sort
            foreach (var item in sortedNameList)
            {
                GenerationFunctions.Add(FriendlyNames_to_ActionsDictionary[ValidRoleLists_to_FriendlyNamesDictionary[item]]);
            }
            //Finally we place a try statement to attempt to run method.Invoke for each Action in our GenerationActions List
            //if successful, all roles will be pulled. If an exception is thrown, it will be output to a log so I can determine
            //where the sanity checking failed and maybe bandaid the (hopefully very few) edge cases that arise
            try
            {
                foreach (var item in GenerationFunctions) //Takes the final sequence that gets loaded into the actions list and invokes each of them in order. This step must come last!
                {
                    item.Invoke();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "One of the role lists was depleted of all names before its role could be generated. Send your settings.json file to @Falson in the Blish HUD Discord to examine this");
            }

        }
        #region RoleGeneratorMethods
        public static void GenerateHandKite()
        {
            Debug.WriteLine("Generating Hand Kite");
        }
        public static void GenerateOilKite()
        {
            Debug.WriteLine("Generating Oil Kite");
        }
        public static void GenerateFlakKite()
        {
            Debug.WriteLine("Generating Flak Kite");
        }
        public static void GenerateTank()
        {
            Debug.WriteLine("Generating Tank");
        }
        public static void GenerateHealAlac()
        {
            Debug.WriteLine("Generating HealAlac");
        }
        public static void GenerateHealQuick()
        {
            Debug.WriteLine("Generating HealQuick");
        }
        public static void GenerateDPSAlac()
        {
            Debug.WriteLine("Generating DPSAlac");
        }
        public static void GenerateDPSQuick()
        {
            Debug.WriteLine("Generating DPSQuick");
        }
        public static void GenerateMushroom()
        {
            Debug.WriteLine("Generating Mushroom");
        }
        public static void GenerateTower()
        {
            Debug.WriteLine("Generating Tower");
        }
        public static void GenerateReflect()
        {
            Debug.WriteLine("Generating Reflect");
        }
        public static void GenerateCannon()
        {
            Debug.WriteLine("Generating Cannons");
        }
        public static void GenerateConstrucPusher()
        {
            Debug.WriteLine("Generating KC Pusher");
        }
        public static void GenerateLamp()
        {
            Debug.WriteLine("Generating Lamp");
        }
        public static void GeneratePylon()
        {
            Debug.WriteLine("Generating Pylons");
        }
        public static void GeneratePillar()
        {
            Debug.WriteLine("Generating Pillars");
        }
        public static void GenerateGreen()
        {
            Debug.WriteLine("Generating Greens");
        }
        public static void GenerateSoullessPusher()
        {
            Debug.WriteLine("Generating SH Pusher");
        }
        public static void GenerateDhuumKite()
        {
            Debug.WriteLine("Generating Dhuum Kite");
        }
        public static void GenerateQadimKite()
        {
            Debug.WriteLine("Generating Qadim Kite");
        }
        public static void GenerateSword()
        {
            Debug.WriteLine("Generating Sword Kite");
        }
        public static void GenerateShield()
        {
            Debug.WriteLine("Generating Shield Kite");
        }
        #endregion
    }
}
