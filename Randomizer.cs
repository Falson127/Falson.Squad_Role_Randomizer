﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Blish_HUD;
using falson = Falson.SquadRoleRandomizer.RoleRandomizerMain;
using falsonG = Falson.SquadRoleRandomizer.PrepareRoles;
using System.Web;
using Blish_HUD.Controls;
using System.Drawing.Text;

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
        private static List<List<string>> TowerExclusivityBubble;
        private static List<List<string>> ConstrucPusherExclusivityBubble;
        private List<List<List<string>>> ListofExclusivityBubbles;
        private Label[] DynamicLabel1;
        private Label[] DynamicLabel2;
        private Label[] DynamicLabel3;
        public static List<Action> GenerationFunctions;
        public static IDictionary<string, string> RoleName_to_SelectedPlayer = new Dictionary<string, string>();
        public static IDictionary<string, string> HoTMechanic_to_SelectedPlayer = new Dictionary<string,string>();
        public static IDictionary<string, string> PoFMechanic_to_SelectedPlayer = new Dictionary<string,string>();
        public static Random rand;

        private static readonly Logger Logger = Logger.GetLogger<Blish_HUD.Modules.Module>();


        public void MainMethod() 
        {
            DefineExlusiveLists();
            BeginRandomization();
            UnloadRandomizer();
        }
        protected void UnloadRandomizer() 
        {
            HandKiteExclusivityBubble = null;
            OilKiteExclusivityBubble = null;
            FlakKiteExclusivityBubble = null;
            TankExclusivityBubble = null;
            HealAlacExclusivityBubble = null;
            HealQuickExclusivityBubble = null;
            DPSAlacExclusivityBubble = null;
            DPSQuickExclusivityBubble = null;
            MushroomExclusivityBubble = null;
            ReflectExclusivityBubble = null;
            CannonExclusivityBubble = null;
            LampExclusivityBubble = null;
            PylonExclusivityBubble = null;
            PillarExclusivityBubble = null;
            GreenExclusivityBubble = null;
            SoullessPusherExclusivityBubble = null;
            DhuumKiteExclusivityBubble = null;
            QadimKiteExclusivityBubble = null;
            SwordExclusivityBubble = null;
            ShieldExclusivityBubble = null;
            ListofExclusivityBubbles = null;
            GenerationFunctions = null;
            rand = null;
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
            TowerExclusivityBubble = new List<List<string>> { };
            ConstrucPusherExclusivityBubble = new List<List<string>> { };

            ListofExclusivityBubbles = new List<List<List<string>>> { HandKiteExclusivityBubble, OilKiteExclusivityBubble, FlakKiteExclusivityBubble, TankExclusivityBubble, HealAlacExclusivityBubble, HealQuickExclusivityBubble, DPSAlacExclusivityBubble, DPSQuickExclusivityBubble, MushroomExclusivityBubble, ReflectExclusivityBubble, CannonExclusivityBubble, LampExclusivityBubble, PylonExclusivityBubble, PillarExclusivityBubble, GreenExclusivityBubble, SoullessPusherExclusivityBubble, DhuumKiteExclusivityBubble, QadimKiteExclusivityBubble, SwordExclusivityBubble, ShieldExclusivityBubble };
            GenerationFunctions = new List<Action>();
            ListsOfLength1 = new List<List<string>>();
            ListsOfLength2 = new List<List<string>>();
            ListsOfLength3 = new List<List<string>>();
            ListsOfLength4 = new List<List<string>>();
            ListsOfLength5 = new List<List<string>>();
            ListsOfLength6 = new List<List<string>>();
            ListsOfLength7 = new List<List<string>>();
            ListsOfLength8 = new List<List<string>>();
            ListsOfLength9 = new List<List<string>>();
            ListsOfLength10 = new List<List<string>>();
        }
        
         
        public void BeginRandomization() 
        {
            //ValidRoleLists, which have been sorted smallest to largest, are brought in using falsonG.GenerationSequence
            IDictionary<List<List<string>>, List<string>> RolesDictionary_Bubble_to_Valid = new Dictionary<List<List<string>>, List<string>>
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
                {ShieldExclusivityBubble,falson.ShieldValid},
                {TowerExclusivityBubble, falson.TowerValid},
                {ConstrucPusherExclusivityBubble, falson.ConstrucPusherValid }
            };
            IDictionary<List<string>, List<List<string>>> RolesDictionary_Valid_to_Bubble = new Dictionary<List<string>, List<List<string>>>
            {
                {falson.HandKiteValid,HandKiteExclusivityBubble},
                {falson.OilKiteValid,OilKiteExclusivityBubble},
                {falson.FlakKiteValid,FlakKiteExclusivityBubble},
                {falson.TankValid,TankExclusivityBubble},
                {falson.HealAlacValid,HealAlacExclusivityBubble},
                {falson.HealQuickValid,HealQuickExclusivityBubble},
                {falson.DPSAlacValid,DPSAlacExclusivityBubble},
                {falson.DPSQuickValid,DPSQuickExclusivityBubble},
                {falson.MushroomValid,MushroomExclusivityBubble},
                {falson.ReflectValid,ReflectExclusivityBubble},
                {falson.CannonValid,CannonExclusivityBubble},
                {falson.LampValid,LampExclusivityBubble},
                {falson.PylonValid,PylonExclusivityBubble},
                {falson.PillarValid,PillarExclusivityBubble},
                {falson.GreenValid,GreenExclusivityBubble},
                {falson.SoullessPusherValid,SoullessPusherExclusivityBubble},
                {falson.DhuumKiteValid,DhuumKiteExclusivityBubble},
                {falson.QadimKiteValid,QadimKiteExclusivityBubble},
                {falson.SwordValid,SwordExclusivityBubble},
                {falson.ShieldValid,ShieldExclusivityBubble},
                {falson.TowerValid, TowerExclusivityBubble},
                {falson.ConstrucPusherValid,ConstrucPusherExclusivityBubble}
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
            rand = new Random();
            //These Role Lists are then sorted into 10 lists according to size
            List<List<List<string>>> ListsOfLengthX = new List<List<List<string>>>(){ListsOfLength1,ListsOfLength2,ListsOfLength3,ListsOfLength4,ListsOfLength5,ListsOfLength6,ListsOfLength7,ListsOfLength8,ListsOfLength9,ListsOfLength10};
            foreach (List<string> ValidNameList in falsonG.GenerationSequence)
            {
                listsize_to_Listsoflistsize[ValidNameList.Count()].Add(ValidNameList); //populates the ListsOfLengthXs
            }
            //Each size list is then further sorted from largest # of conflicting roles to smallest
            var IntermediateSortedList = new List<List<List<string>>>();
            var sortedNameList = new List<List<string>>();
            foreach (List<List<string>> listofnamelists in ListsOfLengthX)
            {
                foreach (List<string> namelist in listofnamelists)
                {

                    IntermediateSortedList.Add(RolesDictionary_Valid_to_Bubble[namelist]); //convert the names in a given listoflengthx into their corresponding lists of exlusivity 
                    
                }
                IntermediateSortedList = IntermediateSortedList.OrderByDescending(l => l.Count()).ToList(); //sort those exclusivity bubbles by descending size
                foreach (var ExclusivityBubble in IntermediateSortedList)
                {
                    sortedNameList.Add(RolesDictionary_Bubble_to_Valid[ExclusivityBubble]); //convert those newly sorted bubbles back into their name lists (which are of the same length)
                }
                foreach (var item in sortedNameList)
                {
                    GenerationFunctions.Add(FriendlyNames_to_ActionsDictionary[ValidRoleLists_to_FriendlyNamesDictionary[item]]); //add the finally double-sorted name lists to the generation function list using the dictionaries to convert.
                }
                IntermediateSortedList.Clear();
                sortedNameList.Clear();
            } //end of loop, do the same thing for all of the lists of lengths 1-10                                                                                                        

            //Finally we place a try statement to attempt to run method.Invoke for each Action in our GenerationActions List
            //if successful, all roles will be pulled. If an exception is thrown, it will be output to a log so I can determine
            //where the sanity checking failed and maybe bandaid the (hopefully very few) edge cases that arise
            falson.ResultsFlowPanel.ClearChildren();
            RoleName_to_SelectedPlayer.Clear();
            HoTMechanic_to_SelectedPlayer.Clear();
            PoFMechanic_to_SelectedPlayer.Clear();

            
            try
            {
                doInvoke();
            }
            catch (Exception)
            {
                try
                {
                    doInvoke();
                }
                catch (Exception)
                {

                    try
                    {
                        doInvoke();
                    }
                    catch (Exception ex)
                    { 
                        falson.ResultsFlowPanel.ClearChildren();
                        Logger.Error(ex, "One of the role lists was depleted of all names before its role could be generated. Send your settings.json file to @Falson in the Blish HUD Discord to examine this");
                        string Outputtext = "At least one role failed to generate.\nThis can happen if you don't have at least 1 player\nsigned up for each role you are trying to randomize.\nAnd in the case of roles with multiple players, make sure \nthere are at least the same number of players signed up \nas you selected to generate in the counter boxes." +
                            "\n\nIf this issue persists, then a list has been \ndepleted during generation due to certain roles inherently \nconflicting with others. " +
                            "try running the randomization again, \nand if the issue continues please reach out on the BlishHUD \nDiscord server.";
                        var exceptionlabel = new Label { Text = Outputtext, Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };

                        falson.RandomizerResultsWindow.Show();
                    }
                }
                
            }
        }

        private void doInvoke() 
        {
            foreach (var item in GenerationFunctions) //Takes the final sequence that gets loaded into the actions list and invokes each of them in order. This step must come last!
            {
                item.Invoke();
            }
            //output the results in RoleName_to_SelectedPlayer dictionary into the results window.
            if (RoleName_to_SelectedPlayer.Count != 0)
            {
                DynamicLabel1 = new Label[(RoleName_to_SelectedPlayer.Count + 2)];
                DynamicLabel1[0] = new Label { Text = "Standard Roles:", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                var RoleCounter = 1;
                foreach (KeyValuePair<string, string> entry in RoleName_to_SelectedPlayer)
                {
                    DynamicLabel1[RoleCounter] = new Label { Text = entry.Value, Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                    RoleCounter++;
                }
                DynamicLabel1[RoleCounter] = new Label { Text = "", Parent = falson.ResultsFlowPanel, Height = 25, AutoSizeWidth = true };
            }
            if (HoTMechanic_to_SelectedPlayer.Count != 0)
            {
                DynamicLabel2 = new Label[(HoTMechanic_to_SelectedPlayer.Count + 2)];
                DynamicLabel2[0] = new Label { Text = "HoT Mechanics:", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                var HoTCounter = 1;
                foreach (KeyValuePair<string, string> entry in HoTMechanic_to_SelectedPlayer)
                {
                    DynamicLabel2[HoTCounter] = new Label { Text = entry.Value, Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                    HoTCounter++;
                }
                DynamicLabel2[HoTCounter] = new Label { Text = "", Parent = falson.ResultsFlowPanel, Height = 25, AutoSizeWidth = true };
            }
            if (PoFMechanic_to_SelectedPlayer.Count != 0)
            {
                DynamicLabel3 = new Label[(HoTMechanic_to_SelectedPlayer.Count + 2)];
                DynamicLabel3[0] = new Label { Text = "PoF Mechanics:", Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                var PoFCounter = 1;
                foreach (KeyValuePair<string, string> entry in PoFMechanic_to_SelectedPlayer)
                {
                    DynamicLabel3[PoFCounter] = new Label { Text = entry.Value, Parent = falson.ResultsFlowPanel, AutoSizeHeight = true, AutoSizeWidth = true };
                    PoFCounter++;
                }
                DynamicLabel3[PoFCounter] = new Label { Text = "", Parent = falson.ResultsFlowPanel, Height = 25, AutoSizeWidth = true };
            }
            falson.RandomizerResultsWindow.Show();
        }
        #region RoleGeneratorMethods
        public static void GenerateHandKite()
        {
            Debug.WriteLine("Generating Hand Kite");
            string selectedhandkite = falson.HandKiteValid[rand.Next(0, (falson.HandKiteValid.Count - 1))]; //pick handkite
            foreach (List<string> list in HandKiteExclusivityBubble) //check all conflicting lists
            {
                if (list.Contains(selectedhandkite)) //if player is in a conflicting list
                {
                    list.Remove(selectedhandkite); //remove that player from the conflicting list
                }
            }
            HoTMechanic_to_SelectedPlayer.Add("HandKite", "The Hand Kiter is: " + selectedhandkite); //output result to dictionary
        }
        public static void GenerateOilKite()
        {
            Debug.WriteLine("Generating Oil Kite");
            string selectedoilkite = falson.OilKiteValid[rand.Next(0, (falson.OilKiteValid.Count - 1))];
            foreach (List<string> list in OilKiteExclusivityBubble)
            {
                if (list.Contains(selectedoilkite))
                {
                    list.Remove(selectedoilkite);
                }
            }
            HoTMechanic_to_SelectedPlayer.Add("OilKite", "The Oil Kiter is: " + selectedoilkite);
        }
        public static void GenerateFlakKite()
        {
            Debug.WriteLine("Generating Flak Kite");
            string selectedflakkite = falson.FlakKiteValid[rand.Next(0, (falson.FlakKiteValid.Count - 1))];
            foreach (List<string> list in FlakKiteExclusivityBubble)
            {
                if (list.Contains(selectedflakkite))
                {
                    list.Remove(selectedflakkite);
                }
            }
            HoTMechanic_to_SelectedPlayer.Add("FlakKite", "The Flak Kiter is: " + selectedflakkite);
        }
        public static void GenerateTank()
        {
            Debug.WriteLine("Generating Tank");
            string selectedtank = falson.TankValid[rand.Next(0, (falson.TankValid.Count - 1))];
            foreach (List<string> list in TankExclusivityBubble)
            {
                if (list.Contains(selectedtank))
                {
                    list.Remove(selectedtank);
                }
            }
            RoleName_to_SelectedPlayer.Add("Tank", "The Tank is: " + selectedtank);
        }
        public static void GenerateHealAlac() //2
        {
            Debug.WriteLine("Generating HealAlac");
            int numbertogenerate = falson.CounterBoxesSettings[0].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedhealalac = falson.HealAlacValid[rand.Next(0, (falson.HealAlacValid.Count - 1))];
                foreach (List<string> list in HealAlacExclusivityBubble)
                {
                    if (list.Contains(selectedhealalac))
                    {
                        list.Remove(selectedhealalac);
                    }
                }
                RoleName_to_SelectedPlayer.Add("HealAlac" + (i+1).ToString(), "Heal Alac " + (i+1).ToString() + " is: " + selectedhealalac);
                falson.HealAlacValid.Remove(selectedhealalac);
            }
        }
        public static void GenerateHealQuick() //2
        {
            Debug.WriteLine("Generating HealQuick");
            int numbertogenerate = falson.CounterBoxesSettings[1].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedhealquick = falson.HealQuickValid[rand.Next(0, (falson.HealQuickValid.Count - 1))];
                foreach (List<string> list in HealQuickExclusivityBubble)
                {
                    if (list.Contains(selectedhealquick))
                    {
                        list.Remove(selectedhealquick);
                    }
                }
                RoleName_to_SelectedPlayer.Add("HealQuick" + (i + 1).ToString(), "Heal Quick " + (i + 1).ToString() + " is: " + selectedhealquick);
                falson.HealQuickValid.Remove(selectedhealquick);
            }
        }
        public static void GenerateDPSAlac() //2
        {
            Debug.WriteLine("Generating DPSAlac");
            int numbertogenerate = falson.CounterBoxesSettings[2].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selecteddpsalac = falson.DPSAlacValid[rand.Next(0, (falson.DPSAlacValid.Count - 1))];
                foreach (List<string> list in DPSAlacExclusivityBubble)
                {
                    if (list.Contains(selecteddpsalac))
                    {
                        list.Remove(selecteddpsalac);
                    }
                }
                RoleName_to_SelectedPlayer.Add("DPSAlac" + (i + 1).ToString(), "Alac DPS " + (i + 1).ToString() + " is: " + selecteddpsalac);
                falson.DPSAlacValid.Remove(selecteddpsalac);
            }
        }
        public static void GenerateDPSQuick() //2
        {
            Debug.WriteLine("Generating DPSQuick");
            int numbertogenerate = falson.CounterBoxesSettings[3].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selecteddpsquick = falson.DPSQuickValid[rand.Next(0, (falson.DPSQuickValid.Count - 1))];
                foreach (List<string> list in DPSQuickExclusivityBubble)
                {
                    if (list.Contains(selecteddpsquick))
                    {
                        list.Remove(selecteddpsquick);
                    }
                }
                RoleName_to_SelectedPlayer.Add("DPSQuick" + (i + 1).ToString(), "Quick DPS " + (i + 1).ToString() + " is: " + selecteddpsquick);
                falson.DPSQuickValid.Remove(selecteddpsquick);
            }
        }
        public static void GenerateMushroom() //4
        {
            Debug.WriteLine("Generating Mushroom");
            int numbertogenerate = falson.CounterBoxesSettings[4].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedmushroom = falson.MushroomValid[rand.Next(0, (falson.MushroomValid.Count - 1))];
                foreach (List<string> list in MushroomExclusivityBubble)
                {
                    if (list.Contains(selectedmushroom))
                    {
                        list.Remove(selectedmushroom);
                    }
                }
                HoTMechanic_to_SelectedPlayer.Add("Mushroom" + (i + 1).ToString(), "Mushroom " + (i + 1).ToString() + " is: " + selectedmushroom);
                falson.MushroomValid.Remove(selectedmushroom);
            }
        }
        public static void GenerateTower()
        {
            Debug.WriteLine("Generating Tower");
            string selectedtower = falson.TowerValid[rand.Next(0, (falson.TowerValid.Count - 1))];
            HoTMechanic_to_SelectedPlayer.Add("Tower", "The Tower Mesmer is: " + selectedtower);
        }
        public static void GenerateReflect()
        {
            Debug.WriteLine("Generating Reflect");
            string selectedreflect = falson.ReflectValid[rand.Next(0, (falson.ReflectValid.Count - 1))];
            foreach (List<string> list in ReflectExclusivityBubble)
            {
                if (list.Contains(selectedreflect))
                {
                    list.Remove(selectedreflect);
                }
            }
            HoTMechanic_to_SelectedPlayer.Add("Reflect", "The Matthias Reflect Mesmer is: " + selectedreflect);
        }
        public static void GenerateCannon() //2
        {
            Debug.WriteLine("Generating Cannons");
            int numbertogenerate = falson.CounterBoxesSettings[5].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedcannon = falson.CannonValid[rand.Next(0, (falson.CannonValid.Count - 1))];
                foreach (List<string> list in CannonExclusivityBubble)
                {
                    if (list.Contains(selectedcannon))
                    {
                        list.Remove(selectedcannon);
                    }
                }
                HoTMechanic_to_SelectedPlayer.Add("Cannon" + (i + 1).ToString(), "Cannon " + (i + 1).ToString() + " is: " + selectedcannon);
                falson.CannonValid.Remove(selectedcannon);
            }
        }
        public static void GenerateConstrucPusher()
        {
            Debug.WriteLine("Generating KC Pusher");
            string selectedkcpusher = falson.ConstrucPusherValid[rand.Next(0, (falson.ConstrucPusherValid.Count - 1))];
            HoTMechanic_to_SelectedPlayer.Add("ConstructPusher", "The KC Core Pusher is: " + selectedkcpusher);
        }
        public static void GenerateLamp() //3
        {
            Debug.WriteLine("Generating Lamp");
            int numbertogenerate = falson.CounterBoxesSettings[6].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedlamp = falson.LampValid[rand.Next(0, (falson.LampValid.Count - 1))];
                foreach (List<string> list in LampExclusivityBubble)
                {
                    if (list.Contains(selectedlamp))
                    {
                        list.Remove(selectedlamp);
                    }
                }
                PoFMechanic_to_SelectedPlayer.Add("Lamp" + (i + 1).ToString(), "Lamp " + (i + 1).ToString() + " is: " + selectedlamp);
                falson.LampValid.Remove(selectedlamp);
            }
        }
        public static void GeneratePylon() //3
        {
            Debug.WriteLine("Generating Pylons");
            int numbertogenerate = falson.CounterBoxesSettings[7].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedpylon = falson.PylonValid[rand.Next(0, (falson.PylonValid.Count - 1))];
                foreach (List<string> list in PylonExclusivityBubble)
                {
                    if (list.Contains(selectedpylon))
                    {
                        list.Remove(selectedpylon);
                    }
                }
                PoFMechanic_to_SelectedPlayer.Add("Pylon" + (i + 1).ToString(), "Pylon " + (i + 1).ToString() + " is: " + selectedpylon);
                falson.PylonValid.Remove(selectedpylon);
            }
        }
        public static void GeneratePillar() //5
        {
            Debug.WriteLine("Generating Pillars");
            int numbertogenerate = falson.CounterBoxesSettings[8].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedpillar = falson.PillarValid[rand.Next(0, (falson.PillarValid.Count - 1))];
                foreach (List<string> list in PillarExclusivityBubble)
                {
                    if (list.Contains(selectedpillar))
                    {
                        list.Remove(selectedpillar);
                    }
                }
                PoFMechanic_to_SelectedPlayer.Add("Pillar" + (i + 1).ToString(), "Pillar " + (i + 1).ToString() + " is: " + selectedpillar);
                falson.PillarValid.Remove(selectedpillar);
            }
        }
        public static void GenerateGreen() //2
        {
            Debug.WriteLine("Generating Greens");
            int numbertogenerate = falson.CounterBoxesSettings[9].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedgreen = falson.GreenValid[rand.Next(0, (falson.GreenValid.Count - 1))];
                foreach (List<string> list in GreenExclusivityBubble)
                {
                    if (list.Contains(selectedgreen))
                    {
                        list.Remove(selectedgreen);
                    }
                }
                PoFMechanic_to_SelectedPlayer.Add("Green" + (i + 1).ToString(), "Green " + (i + 1).ToString() + " is: " + selectedgreen);
                falson.GreenValid.Remove(selectedgreen);
            }
        }
        public static void GenerateSoullessPusher()
        {
            Debug.WriteLine("Generating SH Pusher");
            string selectedpusher = falson.SoullessPusherValid[rand.Next(0, (falson.SoullessPusherValid.Count - 1))];
            foreach (List<string> list in SoullessPusherExclusivityBubble)
            {
                if (list.Contains(selectedpusher))
                {
                    list.Remove(selectedpusher);
                }
            }
            PoFMechanic_to_SelectedPlayer.Add("SoullessPusher", "The SH Tormented Dead Pusher is: " + selectedpusher);
        }
        public static void GenerateDhuumKite()
        {
            Debug.WriteLine("Generating Dhuum Kite");
            string selecteddhuumkite = falson.DhuumKiteValid[rand.Next(0, (falson.DhuumKiteValid.Count - 1))];
            foreach (List<string> list in DhuumKiteExclusivityBubble)
            {
                if (list.Contains(selecteddhuumkite))
                {
                    list.Remove(selecteddhuumkite);
                }
            }
            PoFMechanic_to_SelectedPlayer.Add("DhuumKite", "The Dhuum Messenger Kiter is: " + selecteddhuumkite);
        }
        public static void GenerateQadimKite()
        {
            Debug.WriteLine("Generating Qadim Kite");
            string selectedqadimkite = falson.QadimKiteValid[rand.Next(0, (falson.QadimKiteValid.Count - 1))];
            foreach (List<string> list in QadimKiteExclusivityBubble)
            {
                if (list.Contains(selectedqadimkite))
                {
                    list.Remove(selectedqadimkite);
                }
            }
            PoFMechanic_to_SelectedPlayer.Add("QadimKite", "The Qadim Kiter is: " + selectedqadimkite);
        }
        public static void GenerateSword() //2
        {
            Debug.WriteLine("Generating Sword Kite");
            int numbertogenerate = falson.CounterBoxesSettings[10].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedsword = falson.SwordValid[rand.Next(0, (falson.SwordValid.Count - 1))];
                foreach (List<string> list in SwordExclusivityBubble)
                {
                    if (list.Contains(selectedsword))
                    {
                        list.Remove(selectedsword);
                    }
                }
                PoFMechanic_to_SelectedPlayer.Add("Sword" + (i + 1).ToString(), "Sword Collector " + (i + 1).ToString() + " is: " + selectedsword);
                falson.SwordValid.Remove(selectedsword);
            }
        }
        public static void GenerateShield() //2
        {
            Debug.WriteLine("Generating Shield Kite");
            int numbertogenerate = falson.CounterBoxesSettings[11].Value;
            for (int i = 0; i < numbertogenerate; i++)
            {
                string selectedshield = falson.ShieldValid[rand.Next(0, (falson.ShieldValid.Count - 1))];
                foreach (List<string> list in ShieldExclusivityBubble)
                {
                    if (list.Contains(selectedshield))
                    {
                        list.Remove(selectedshield);
                    }
                }
                PoFMechanic_to_SelectedPlayer.Add("Shield" + (i + 1).ToString(), "Shield Collector " + (i + 1).ToString() + " is: " + selectedshield);
                falson.ShieldValid.Remove(selectedshield);
            }
        }
        #endregion
    }
}
