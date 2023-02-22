using Blish_HUD;
using Blish_HUD.Modules;
using Blish_HUD.Modules.Managers;
using Blish_HUD.Settings;
using Blish_HUD.Content;
using Blish_HUD.Controls;
using Microsoft.Xna.Framework;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Falson.SquadRoleRandomizer
{
    [Export(typeof(Blish_HUD.Modules.Module))]
    public class RoleRandomizerMain : Blish_HUD.Modules.Module
    {
        public static StandardWindow RandomizerResultsWindow;
        public static StandardWindow RandomizerSettingsWindow;
        private CornerIcon RandomizerSettingIcon;
        private CustomButton[] CheckAllRoles = new CustomButton[10];
        private CustomButton[] CheckAllHoT = new CustomButton[10];
        private CustomButton[] CheckAllPoF = new CustomButton[10];
        private CustomButton CheckAllGenerateRoles;
        public static List<string> HandKiteValid = new List<string>();
        public static List<string> OilKiteValid = new List<string>();
        public static List<string> FlakKiteValid = new List<string>();
        public static List<string> TankValid = new List<string>();
        public static List<string> HealAlacValid = new List<string>();
        public static List<string> HealQuickValid = new List<string>();
        public static List<string> DPSAlacValid = new List<string>();
        public static List<string> DPSQuickValid = new List<string>();
        public static List<string> MushroomValid = new List<string>();
        public static List<string> TowerValid = new List<string>();
        public static List<string> ReflectValid = new List<string>();
        public static List<string> CannonValid = new List<string>();
        public static List<string> ConstrucPusherValid = new List<string>();
        public static List<string> LampValid = new List<string>();
        public static List<string> PylonValid = new List<string>();
        public static List<string> PillarValid = new List<string>();
        public static List<string> GreenValid = new List<string>();
        public static List<string> SoullessPusherValid = new List<string>();
        public static List<string> DhuumKiteValid = new List<string>();
        public static List<string> QadimKiteValid = new List<string>();
        public static List<string> SwordValid = new List<string>();
        public static List<string> ShieldValid = new List<string>();
        public CounterBox[] CounterBoxes; //need 12 items in this
        public Label[] CounterBoxLabels;
        private StandardButton GenerateRolesButton;
        public SettingCollection InternalPlayerRolesSettings;
        public static SettingEntry<int>[]  CounterBoxesSettings = new SettingEntry<int>[12];
        public static SettingEntry<bool>[] RolesToGenerate = new SettingEntry<bool>[22];
        public static SettingEntry<bool>[] HandKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] OilKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] FlakKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] TankRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] HealAlacRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] HealQuickRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] DPSAlacRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] DPSQuickRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] MushroomRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] TowerRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] ReflectRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] CannonRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] ConstrucPusherRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] LampRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] PylonRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] PillarRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] GreenRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] SoullessPusherRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] DhuumKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] QadimKiteRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] SwordRoles = new SettingEntry<bool>[10];
        public static SettingEntry<bool>[] ShieldRoles = new SettingEntry<bool>[10];
        public static SettingEntry<string>[] PlayerNames = new SettingEntry<string>[10];
        public List<CustomCheckbox[]> ListofCheckboxArrays;
        public List<SettingEntry<bool>[]> ListofRolesSettings;
        public static List<List<string>> ListofRoleValidLists;
        public TextBox Player1NameBox;
        public TextBox Player2NameBox;
        public TextBox Player3NameBox;
        public TextBox Player4NameBox;
        public TextBox Player5NameBox;
        public TextBox Player6NameBox;
        public TextBox Player7NameBox;
        public TextBox Player8NameBox;
        public TextBox Player9NameBox;
        public TextBox Player10NameBox;
        public Panel PlayerNameTextBoxPanel;
        public FlowPanel MasterFlowPanel;
        public static FlowPanel ResultsFlowPanel;
        public Panel RandomizeCheckboxesPanel = new Panel();
        public PlayerPanel[] PlayerPanels = new PlayerPanel[10];
        public Panel[] StandardRolesPanel = new Panel[10]; //5 items
        public Panel[] HoTMechanicsPanel = new Panel[10]; //8 items
        public Panel[] PoFMechanicsPanel = new Panel[10]; //9 items
        public Panel RolesWithNumbers;
        public CustomCheckbox[] HandKiteBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] OilKiteBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] FlakKiteBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] TankBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] HealAlacBoxArray = new CustomCheckbox[10]; //1-2
        public CustomCheckbox[] HealQuickBoxArray = new CustomCheckbox[10]; //1-2
        public CustomCheckbox[] DPSAlacBoxArray = new CustomCheckbox[10]; //1-2
        public CustomCheckbox[] DPSQuickBoxArray = new CustomCheckbox[10]; //1-2
        public CustomCheckbox[] MushroomBoxArray = new CustomCheckbox[10]; //1-4
        public CustomCheckbox[] TowerBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] ReflectBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] CannonBoxArray = new CustomCheckbox[10]; //1-2
        public CustomCheckbox[] ConstrucPusherBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] LampBoxArray = new CustomCheckbox[10]; //1-3
        public CustomCheckbox[] PylonBoxArray = new CustomCheckbox[10]; //1-3
        public CustomCheckbox[] PillarBoxArray = new CustomCheckbox[10]; //1-5
        public CustomCheckbox[] GreenBoxArray = new CustomCheckbox[10]; //1-2
        public CustomCheckbox[] SoullessPusherBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] DhuumKiteBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] QadimKiteBoxArray = new CustomCheckbox[10];
        public CustomCheckbox[] SwordBoxArray = new CustomCheckbox[10]; //1-2
        public CustomCheckbox[] ShieldBoxArray = new CustomCheckbox[10]; //1-2
        public static CustomCheckbox[] RolestoRandomizeSelectionCheckboxesArray = new CustomCheckbox[22];
        

        private static readonly Logger Logger = Logger.GetLogger<RoleRandomizerMain>();

        #region Service Managers
        internal SettingsManager SettingsManager => this.ModuleParameters.SettingsManager;
        internal ContentsManager ContentsManager => this.ModuleParameters.ContentsManager;
        internal DirectoriesManager DirectoriesManager => this.ModuleParameters.DirectoriesManager;
        internal Gw2ApiManager Gw2ApiManager => this.ModuleParameters.Gw2ApiManager;
        #endregion

        [ImportingConstructor]
        public RoleRandomizerMain([Import("ModuleParameters")] ModuleParameters moduleParameters) : base(moduleParameters) { }
        protected override void DefineSettings(SettingCollection settings)
        {   
            InternalPlayerRolesSettings = settings.AddSubCollection("Internal Setting Collection", false);
            InternalPlayerRolesSettings.RenderInUi = false;
            for (int i = 0; i < 12; i++)
            {
                CounterBoxesSettings[i] = InternalPlayerRolesSettings.DefineSetting($"Counter Box {i+1} setting", 1);
            }
            for (int i = 0; i < 22; i++)
            {
                RolesToGenerate[i] = InternalPlayerRolesSettings.DefineSetting($"Role to Generate{i+1} ", false);
            }
            for (int i = 0; i < 10; i++)
            {
                //Build role settings + Playername settings
                HandKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Hand_Kite Player {i+1}" , false);
                OilKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"OilKite Player {i+1}" , false);
                FlakKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"FlakKite Player {i+1}" , false);
                TankRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Tank Player {i+1}" , false);
                HealAlacRoles[i] = InternalPlayerRolesSettings.DefineSetting($"HealAlac Player {i+1}" , false);
                HealQuickRoles[i] = InternalPlayerRolesSettings.DefineSetting($"HealQuick Player {i+1}" , false);
                DPSAlacRoles[i] = InternalPlayerRolesSettings.DefineSetting($"DPSAlac Player {i+1}" , false);
                DPSQuickRoles[i] = InternalPlayerRolesSettings.DefineSetting($"DPSQuick Player {i+1}" , false);
                MushroomRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Mushroom Player {i+1}" , false);
                TowerRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Tower Player {i+1}" , false);
                ReflectRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Reflect Player {i+1}" , false);
                CannonRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Cannon Player {i+1}" , false);
                ConstrucPusherRoles[i] = InternalPlayerRolesSettings.DefineSetting($"ConstrucPusher Player {i+1}" , false);
                LampRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Lamp Player {i+1}" , false);
                PylonRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Pylon Player {i+1}" , false);
                PillarRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Pillar Player {i+1}" , false);
                GreenRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Green Player {i+1}" , false);
                SoullessPusherRoles[i] = InternalPlayerRolesSettings.DefineSetting($"SoullessPusher Player {i+1}" , false);
                DhuumKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"DhuumKite Player {i+1}" , false);
                QadimKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting($"QadimKite Player {i+1}" , false);
                SwordRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Sword Player {i+1}" , false);
                ShieldRoles[i] = InternalPlayerRolesSettings.DefineSetting($"Shield Player {i+1}" , false);
                PlayerNames[i] = InternalPlayerRolesSettings.DefineSetting($"Player {i} Name", $"Player {i}");

            }

        }
        private void GenerateRolesButton_Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            PrepareRoles.PrepRoles();
        }

        protected override async Task LoadAsync()
        {
            CounterBoxes = new CounterBox[12];
            CounterBoxLabels = new Label[12];
            RandomizerSettingsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Randomization Settings",
                Subtitle = "Define Roles to Randomize",
                Parent = GameService.Graphics.SpriteScreen,
                Size = new Point(1050, 800),
                SavesPosition = true,
                Id = "Falson.RoleRandomizer.SettingsWindow",
                Emblem = ContentsManager.GetTexture("Emblem.png")
            };
            RandomizerResultsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Randomized Roles",
                Parent = GameService.Graphics.SpriteScreen,
                //Size = new Point(450, 800),
                HeightSizingMode = SizingMode.AutoSize,
                WidthSizingMode = SizingMode.AutoSize,
                Location = new Point(100, 100),
                SavesPosition = true,
                Id = "Falson.RoleRandomizer.ResultsWindow",
                Emblem = ContentsManager.GetTexture("Emblem.png")

            };
            ResultsFlowPanel = new FlowPanel 
            {
                Location = new Point(0,0),
                Parent = RandomizerResultsWindow,
                FlowDirection = ControlFlowDirection.SingleTopToBottom,
                HeightSizingMode = SizingMode.AutoSize,
                WidthSizingMode = SizingMode.AutoSize
            };
            RolesWithNumbers = new Panel
            {
                Title = "Number of each role to generate",
                Parent = RandomizerSettingsWindow,
                Size = new Point(480, 165),
                Location = new Point(401, 0),
            };
            GenerateRolesButton = new StandardButton
            {
                Text = "Generate \n  Roles",
                Size = new Point(80, 100),
                Location = new Point(890, 40),
                Parent = RandomizerSettingsWindow,
            };
            GenerateRolesButton.Click += GenerateRolesButton_Click;
            PlayerNameTextBoxPanel = new Panel
            {
                Title = "Enter Player Names",
                Size = new Point(400, 165),
                Location = new Point(0, 0),
                Parent = RandomizerSettingsWindow,
            };
            RandomizeCheckboxesPanel = new Panel
            {
                Title = "Select roles to be randomized",
                Size = new Point(1000, 120),
                Parent = RandomizerSettingsWindow,
                Location = new Point(0, 166),
            };
            MasterFlowPanel = new FlowPanel
            {
                ShowBorder = true,
                Title = "Set Roles for Each Player  (Click to Expand)",
                Size = new Point(1000, 400),
                Location = new Point(0, 255),
                Parent = RandomizerSettingsWindow,
                CanScroll = true,
                CanCollapse = false,
                FlowDirection = ControlFlowDirection.SingleTopToBottom
            };
            #region Player Panels
            for (int i = 0; i < 10; i++)
            {
                PlayerPanels[i] = new PlayerPanel(PlayerNames[i].Value, MasterFlowPanel);
            }
            #endregion
            #region Role Panels
            for (int i = 0; i < 10; i++)
            {
                StandardRolesPanel[i] = new Panel
                {
                    Size = new Point(280,110),
                    Parent = PlayerPanels[i],
                    ShowBorder = true,
                    Title = "Standard Roles",
                    Visible = true,
                    Location = new Point(0,0)
                };
                HoTMechanicsPanel[i] = new Panel
                {
                    Size = new Point(330, 110),
                    Parent = PlayerPanels[i],
                    ShowBorder = true,
                    Title = "HoT Mechanics",
                    Location = new Point(280,0)
                };
                PoFMechanicsPanel[i] = new Panel 
                {
                    Size = new Point(350, 110),
                    Parent = PlayerPanels[i],
                    ShowBorder = true,
                    Title = "PoF Mechanics",
                    Location = new Point(610,0)
                };
            }
            #endregion
            #region ListsOf: Box Arrays, Role Arrays, and Valid Lists
            ListofCheckboxArrays = new List<CustomCheckbox[]> {HandKiteBoxArray,OilKiteBoxArray,FlakKiteBoxArray,TankBoxArray,HealAlacBoxArray,HealQuickBoxArray,DPSAlacBoxArray,DPSQuickBoxArray,MushroomBoxArray,TowerBoxArray,ReflectBoxArray,CannonBoxArray,ConstrucPusherBoxArray,LampBoxArray,PylonBoxArray,PillarBoxArray,GreenBoxArray,SoullessPusherBoxArray,DhuumKiteBoxArray,QadimKiteBoxArray,SwordBoxArray,ShieldBoxArray };
            ListofRolesSettings = new List<SettingEntry<bool>[]> {HandKiteRoles,OilKiteRoles,FlakKiteRoles,TankRoles,HealAlacRoles,HealQuickRoles,DPSAlacRoles,DPSQuickRoles,MushroomRoles,TowerRoles,ReflectRoles,CannonRoles,ConstrucPusherRoles,LampRoles,PylonRoles,PillarRoles,GreenRoles,SoullessPusherRoles,DhuumKiteRoles,QadimKiteRoles,SwordRoles,ShieldRoles };
            ListofRoleValidLists = new List<List<string>> { HandKiteValid,OilKiteValid,FlakKiteValid,TankValid,HealAlacValid,HealQuickValid,DPSAlacValid,DPSQuickValid,MushroomValid,TowerValid,ReflectValid,CannonValid,ConstrucPusherValid,LampValid,PylonValid,PillarValid,GreenValid,SoullessPusherValid,DhuumKiteValid,QadimKiteValid,SwordValid,ShieldValid};
            #endregion
            #region CheckAllBoxesButtons
            for (int i = 0; i < 10; i++)
            {
                CheckAllRoles[i] = new CustomButton(StandardRolesPanel[i], 120, 5);
                CheckAllHoT[i] = new CustomButton(HoTMechanicsPanel[i],420,5);
                CheckAllPoF[i] = new CustomButton(PoFMechanicsPanel[i],750,5);
            }
            CheckAllGenerateRoles = new CustomButton(RandomizeCheckboxesPanel, 220, 170);
            #endregion
            #region Checkboxes
            for (int i = 0; i < 10; i++)
            {
                TankBoxArray[i] = new CustomCheckbox(TankRoles[i]) { Text = "Tank", Location = new Point(0, 0), BasicTooltipText = "Tank", Parent = StandardRolesPanel[i], Checked = TankRoles[i].Value };
                HealAlacBoxArray[i] = new CustomCheckbox(HealAlacRoles[i]) { Text = "Heal + Alac", Location = new Point(0, 25), BasicTooltipText = "Heal + Alac", Parent = StandardRolesPanel[i], Checked = HealAlacRoles[i].Value };
                HealQuickBoxArray[i] = new CustomCheckbox(HealQuickRoles[i]) { Text = "Heal + Quick", Location = new Point(0, 50), BasicTooltipText = "Heal + Quick", Parent = StandardRolesPanel[i], Checked = HealQuickRoles[i].Value };
                DPSAlacBoxArray[i] = new CustomCheckbox(DPSAlacRoles[i]) { Text = "DPS + Alac", Location = new Point(100, 0), BasicTooltipText = "DPS + Alac", Parent = StandardRolesPanel[i], Checked = DPSAlacRoles[i].Value };
                DPSQuickBoxArray[i] = new CustomCheckbox(DPSQuickRoles[i]) { Text = "DPS + Quick", Location = new Point(100, 25), BasicTooltipText = "DPS + Quick", Parent = StandardRolesPanel[i], Checked = DPSQuickRoles[i].Value };
                
                HandKiteBoxArray[i] = new CustomCheckbox(HandKiteRoles[i]) { Text = "Hand Kite", Location = new Point(0,0), BasicTooltipText = "Hand Kite", Parent = HoTMechanicsPanel[i], Checked = HandKiteRoles[i].Value };
                OilKiteBoxArray[i] = new CustomCheckbox(OilKiteRoles[i]) { Text = "Oil Kite", Location = new Point(0, 25), BasicTooltipText = "Oil Kite", Parent = HoTMechanicsPanel[i], Checked = OilKiteRoles[i].Value };
                FlakKiteBoxArray[i] = new CustomCheckbox(FlakKiteRoles[i]) { Text = "Flak Kite", Location = new Point(0, 50), BasicTooltipText = "Flak Kite", Parent = HoTMechanicsPanel[i], Checked = FlakKiteRoles[i].Value };
                MushroomBoxArray[i] = new CustomCheckbox(MushroomRoles[i]) { Text = "Mushroom", Location = new Point(100, 0), BasicTooltipText = "Slothosaur Mushroom", Parent = HoTMechanicsPanel[i], Checked = MushroomRoles[i].Value };
                TowerBoxArray[i] = new CustomCheckbox(TowerRoles[i]) { Text = "Tower", Location = new Point(100, 25), BasicTooltipText = "Tower Mesmer", Parent = HoTMechanicsPanel[i], Checked = TowerRoles[i].Value };
                ReflectBoxArray[i] = new CustomCheckbox(ReflectRoles[i]) { Text = "Reflect", Location = new Point(100, 50), BasicTooltipText = "Matthias Reflect", Parent = HoTMechanicsPanel[i], Checked = ReflectRoles[i].Value };
                CannonBoxArray[i] = new CustomCheckbox(CannonRoles[i]) { Text = "Cannons", Location = new Point(200, 0), BasicTooltipText = "Sabetha Cannons", Parent = HoTMechanicsPanel[i], Checked = CannonRoles[i].Value };
                ConstrucPusherBoxArray[i] = new CustomCheckbox(ConstrucPusherRoles[i]) { Text = "KC Pusher", Location = new Point(200, 25), BasicTooltipText = "Keep Construct Pusher", Parent = HoTMechanicsPanel[i], Checked = ConstrucPusherRoles[i].Value };
                
                LampBoxArray[i] = new CustomCheckbox(LampRoles[i]) { Text = "Lamp", Location = new Point(0, 0), BasicTooltipText = "Qadim Lamp", Parent = PoFMechanicsPanel[i], Checked = LampRoles[i].Value };
                PylonBoxArray[i] = new CustomCheckbox(PylonRoles[i]) { Text = "Pylon", Location = new Point(0, 25), BasicTooltipText = "Qadim Pylon", Parent = PoFMechanicsPanel[i], Checked = PylonRoles[i].Value };
                PillarBoxArray[i] = new CustomCheckbox(PillarRoles[i]) { Text = "Pillar", Location = new Point(0, 50), BasicTooltipText = "Adina Pillar", Parent = PoFMechanicsPanel[i], Checked = PillarRoles[i].Value };
                GreenBoxArray[i] = new CustomCheckbox(GreenRoles[i]) { Text = "Green", Location = new Point(100, 0), BasicTooltipText = "Dhuum Green", Parent = PoFMechanicsPanel[i], Checked = GreenRoles[i].Value };
                SoullessPusherBoxArray[i] = new CustomCheckbox(SoullessPusherRoles[i]) { Text = "SH Pusher", Location = new Point(100, 25), BasicTooltipText = "Soulless Horror Pusher", Parent = PoFMechanicsPanel[i], Checked = SoullessPusherRoles[i].Value };
                DhuumKiteBoxArray[i] = new CustomCheckbox(DhuumKiteRoles[i]) { Text = "Dhuum Kiter", Location = new Point(100, 50), BasicTooltipText = "Dhuum Messenger Kiter", Parent = PoFMechanicsPanel[i], Checked = DhuumKiteRoles[i].Value };
                QadimKiteBoxArray[i] = new CustomCheckbox(QadimKiteRoles[i]) { Text = "Qadim Kiter", Location = new Point(200, 0), BasicTooltipText = "Qadim Kiter", Parent = PoFMechanicsPanel[i], Checked = QadimKiteRoles[i].Value };
                SwordBoxArray[i] = new CustomCheckbox(SwordRoles[i]) { Text = "Sword", Location = new Point(200, 25), BasicTooltipText = "CA Sword Collector", Parent = PoFMechanicsPanel[i], Checked = SwordRoles[i].Value };
                ShieldBoxArray[i] = new CustomCheckbox(ShieldRoles[i]) { Text = "Shield", Location = new Point(200, 50), BasicTooltipText = "CA Shield Collector", Parent = PoFMechanicsPanel[i], Checked = ShieldRoles[i].Value };
            }
            IDictionary<int, string> RandomizeSelectionBoxesInt_to_NameDictionary = new Dictionary<int, string>
            {
                {0,"Hand Kite"},
                {1,"Oil Kite"},
                {2,"Flak Kite"},
                {3,"Tank"},
                {4,"Heal Alac"},
                {5,"Heal Quick"},
                {6,"DPS Alac"},
                {7,"DPS Quick"},
                {8,"Mushrooms"},
                {9,"Tower"},
                {10,"Reflect"},
                {11,"Cannons"},
                {12,"KC Pusher"},
                {13,"Lamp(s)"},
                {14,"Pylon(s)"},
                {15,"Pillar(s)"},
                {16,"Green(s)"},
                {17,"SH Pusher"},
                {18,"Dhuum Kite"},
                {19,"Qadim Kite"},
                {20,"Sword Collector(s)"},
                {21,"Shield Collector(s)"},
            };
            IDictionary<int, string> RandomizeSelectionBoxesInt_to_TooltipDictionary = new Dictionary<int, string> 
            {
                {0,"Hand Kite"},
                {1,"Oil Kite"},
                {2,"Flak Kite"},
                {3,"Tank"},
                {4,"Heal Alac"},
                {5,"Heal Quickness"},
                {6,"DPS Alac"},
                {7,"DPS Quickness"},
                {8,"Slothosaur Mushrooms"},
                {9,"Tower Mesmer"},
                {10,"Matthias Reflect"},
                {11,"Sabetha Cannons"},
                {12,"Keep Construct Pusher"},
                {13,"Qadim Lamp(s)"},
                {14,"Qadim Pylon(s)"},
                {15,"Adina Pillar(s)"},
                {16,"Dhuum Green(s)"},
                {17,"Soulless Horror Pusher"},
                {18,"Dhuum Messenger Kiter"},
                {19,"Qadim Kite"},
                {20,"Sword Collector(s)"},
                {21,"Shield Collector(s)"},
            };
            IDictionary<int, Point> RandomizedBoxes_to_LocationDictioanry = new Dictionary<int, Point> 
            {
                {0,new Point(100,30)},
                {1,new Point(200,0)},
                {2,new Point(200,15)},
                {3,new Point(0,0)},
                {4,new Point(0,15)},
                {5,new Point(0,30)},
                {6,new Point(100,0)},
                {7,new Point(100,15)},
                {8,new Point(200,30)},
                {9,new  Point(300,0)},
                {10,new Point(300,15)},
                {11,new Point(300,30)},
                {12,new Point(400,0)},
                {13,new Point(400,15)},
                {14,new Point(400,30)},
                {15,new Point(500,0)},
                {16,new Point(500,15)},
                {17,new Point(500,30)},
                {18,new Point(600,0)},
                {19,new Point(600,15)},
                {20,new Point(600,30)},
                {21,new Point(700,0)},
            };
            IDictionary<int, int> CounterBoxes_MaxAllowedIntValues = new Dictionary<int, int>
            {
                {0, 2},
                {1, 2},
                {2, 2},
                {3, 2},
                {4, 4},
                {5, 2},
                {6, 3},
                {7, 3},
                {8, 5},
                {9, 2},
                {10, 2},
                {11, 2}
            };
            IDictionary<int, string> CounterBoxInt_to_Text = new Dictionary<int, string>
            {
                {0, "# of Heal/Alac"},
                {1, "# of Heal/Quick"},
                {2, "# of DPS/Alac"},
                {3, "# of DPS/Quick"},
                {4, "# of Mushrooms"},
                {5, "# of Cannons"},
                {6, "# of Lamps"},
                {7, "# of Pylons"},
                {8, "# of Pillars"},
                {9, "# of Greens"},
                {10, "# of Swords"},
                {11, "# of Shields"}
            };
            for (int i = 0; i < 22; i++)
            {
                RolestoRandomizeSelectionCheckboxesArray[i] = new CustomCheckbox(RolesToGenerate[i])
                {
                    Text =  RandomizeSelectionBoxesInt_to_NameDictionary[i] + "  ",
                    BasicTooltipText = "Check this box to include " + RandomizeSelectionBoxesInt_to_TooltipDictionary[i] + " in the randomization",
                    Parent = RandomizeCheckboxesPanel,
                    Checked = RolesToGenerate[i].Value,
                    Location = RandomizedBoxes_to_LocationDictioanry[i]

                };
            }
            #endregion
            #region CounterBoxes
            IDictionary<int, int> CounterBox_X_PositionDictionary = new Dictionary<int, int>
            {
                {0, 100},
                {1, 100},
                {2, 100},
                {3, 100},
                {4, 100},
                {5, 260},
                {6, 260},
                {7, 260},
                {8, 260},
                {9, 260},
                {10, 420},
                {11, 420},
            };
            IDictionary<int, int> CounterBox_Y_PositionDictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 25},
                {2, 50},
                {3, 75},
                {4, 100},
                {5, 0},
                {6, 25},
                {7, 50},
                {8, 75},
                {9, 100},
                {10, 0},
                {11, 25},
            };
            for (int i = 0; i<12; i++) 
            {
                CounterBoxes[i] = new CounterBox
                {
                    MaxValue = CounterBoxes_MaxAllowedIntValues[i],
                    Parent = RolesWithNumbers,
                    ValueWidth = 10,
                    Width = 60,
                    BasicTooltipText = CounterBoxInt_to_Text[i],
                    Value = CounterBoxesSettings[i].Value,
                    MinValue = 0,
                    Location = new Point(CounterBox_X_PositionDictionary[i],CounterBox_Y_PositionDictionary[i])
                };
            }
            #endregion
            #region Textboxes
            Player1NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[0].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0,0)
            };
            Player2NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[1].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 25)
            };
            Player3NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[2].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 50)
            };
            Player4NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[3].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 75)
            };
            Player5NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[4].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 100)
            };
            Player6NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[5].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 0)
            };
            Player7NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[6].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 25)
            };
            Player8NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[7].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 50)
            };
            Player9NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[8].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 75)
            };
            Player10NameBox = new TextBox 
            {
                PlaceholderText = PlayerNames[9].Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 100)
            };
            #endregion
            #region Labels

            IDictionary<int, int> CounterBoxLabel_X_PositionDictionary = new Dictionary<int, int> 
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 160},
                {6, 160},
                {7, 160},
                {8, 160},
                {9, 160},
                {10, 320},
                {11, 320},
            };
            IDictionary<int, int> CounterBoxLabel_Y_PositionDictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 25},
                {2, 50},
                {3, 75},
                {4, 100},
                {5, 0},
                {6, 25},
                {7, 50},
                {8, 75},
                {9, 100},
                {10, 0},
                {11, 25},
            };

            CounterBoxLabels = new Label[12];
            for (int i = 0; i < 12; i++)
            {
                CounterBoxLabels[i] = new Label 
                {
                    Text = CounterBoxInt_to_Text[i],
                    Size = new Point(100,25),
                    Location = new Point(CounterBoxLabel_X_PositionDictionary[i],CounterBoxLabel_Y_PositionDictionary[i]),
                    Parent = RolesWithNumbers
                };
            }
            #endregion
            #region Event Subscriptions
            Player1NameBox.TextChanged += Player1NameBox_TextChanged;
            Player2NameBox.TextChanged += Player2NameBox_TextChanged;
            Player3NameBox.TextChanged += Player3NameBox_TextChanged;
            Player4NameBox.TextChanged += Player4NameBox_TextChanged;
            Player5NameBox.TextChanged += Player5NameBox_TextChanged;
            Player6NameBox.TextChanged += Player6NameBox_TextChanged;
            Player7NameBox.TextChanged += Player7NameBox_TextChanged;
            Player8NameBox.TextChanged += Player8NameBox_TextChanged;
            Player9NameBox.TextChanged += Player9NameBox_TextChanged;
            Player10NameBox.TextChanged += Player10NameBox_TextChanged;
            CounterBoxes[0].Click += CounterBox1Click;
            CounterBoxes[1].Click += CounterBox2Click;
            CounterBoxes[2].Click += CounterBox3Click;
            CounterBoxes[3].Click += CounterBox4Click;
            CounterBoxes[4].Click += CounterBox5Click;
            CounterBoxes[5].Click += CounterBox6Click;
            CounterBoxes[6].Click += CounterBox7Click;
            CounterBoxes[7].Click += CounterBox8Click;
            CounterBoxes[8].Click += CounterBox9Click;
            CounterBoxes[9].Click += CounterBox10Click;
            CounterBoxes[10].Click += CounterBox11Click;
            CounterBoxes[11].Click += CounterBox12Click;
            #endregion
        }
        #region CounterBox Click Functions
        private void CounterBox12Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[11].Value = CounterBoxes[11].Value;
        }

        private void CounterBox11Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[10].Value = CounterBoxes[10].Value;
        }

        private void CounterBox10Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[9].Value = CounterBoxes[9].Value;
        }

        private void CounterBox9Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[8].Value = CounterBoxes[8].Value;
        }

        private void CounterBox8Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[7].Value = CounterBoxes[7].Value;
        }

        private void CounterBox7Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[6].Value = CounterBoxes[6].Value;
        }

        private void CounterBox6Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[5].Value = CounterBoxes[5].Value;
        }

        private void CounterBox5Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[4].Value = CounterBoxes[4].Value;
        }

        private void CounterBox4Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[3].Value = CounterBoxes[3].Value;
        }

        private void CounterBox3Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[2].Value = CounterBoxes[2].Value;
        }

        private void CounterBox2Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[1].Value = CounterBoxes[1].Value;
        }

        private void CounterBox1Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            CounterBoxesSettings[0].Value = CounterBoxes[0].Value;
        }
        #endregion
        #region Textbox text changed functions
        private void Player10NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[9].Title = Player10NameBox.Text;
            PlayerNames[9].Value = Player10NameBox.Text;

        }

        private void Player9NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[8].Title = Player9NameBox.Text;
            PlayerNames[8].Value = Player9NameBox.Text;
        }

        private void Player8NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[7].Title = Player8NameBox.Text;
            PlayerNames[7].Value = Player8NameBox.Text;
        }

        private void Player7NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[6].Title = Player7NameBox.Text;
            PlayerNames[6].Value = Player7NameBox.Text;
        }

        private void Player6NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[5].Title = Player6NameBox.Text;
            PlayerNames[5].Value = Player6NameBox.Text;
        }

        private void Player5NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[4].Title = Player5NameBox.Text;
            PlayerNames[4].Value = Player5NameBox.Text;
        }

        private void Player4NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[3].Title = Player4NameBox.Text;
            PlayerNames[3].Value = Player4NameBox.Text;
        }

        private void Player3NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[2].Title = Player3NameBox.Text;
            PlayerNames[2].Value = Player3NameBox.Text;
        }

        private void Player2NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[1].Title = Player2NameBox.Text;
            PlayerNames[1].Value = Player2NameBox.Text;
        }

        private void Player1NameBox_TextChanged(object sender, EventArgs e)
        {
            PlayerPanels[0].Title = Player1NameBox.Text;
            PlayerNames[0].Value = Player1NameBox.Text;
        }
        #endregion
        protected override void OnModuleLoaded(EventArgs e)
        {
            RandomizerSettingIcon = new CornerIcon 
            {
                Icon = ContentsManager.GetTexture("Emblem.png"),
                BasicTooltipText = "Click to open settings window"
            };
            RandomizerSettingIcon.Click += delegate 
            {
                RandomizerSettingsWindow.ToggleWindow();
            };
            // Base handler must be called
            base.OnModuleLoaded(e);
        }

        protected override void Update(GameTime gameTime)
        {

        }

        /// <inheritdoc />
        protected override void Unload()
        {
            #region Disposables
            #region Checkboxes
            foreach (var item in CounterBoxes)
            {
                item?.Dispose();
            }
            foreach (var item in CounterBoxLabels)
            {
                item?.Dispose();
            }
            foreach (var item in HandKiteBoxArray) 
            {
                item?.Dispose();
            }
            foreach(var item in OilKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in FlakKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in TankBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in HealAlacBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in HealQuickBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in DPSAlacBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in DPSQuickBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in MushroomBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in TowerBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in ReflectBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in CannonBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in ConstrucPusherBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in LampBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in PylonBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in PillarBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in GreenBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in SoullessPusherBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in DhuumKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in QadimKiteBoxArray)
            {
                item?.Dispose();
            }
            foreach(var item in SwordBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in ShieldBoxArray)
            {
                item?.Dispose();
            } 
            foreach(var item in RolestoRandomizeSelectionCheckboxesArray)
            {
                item?.Dispose();
            }
            foreach(var item in HoTMechanicsPanel)
            {
                item?.Dispose();
            }
            foreach(var item in PoFMechanicsPanel)
            {
                item?.Dispose();
            }
            foreach (var item in StandardRolesPanel)
            {
                item?.Dispose();
            }
            #endregion
            RandomizerSettingIcon?.Dispose();
            RandomizerResultsWindow?.Dispose();
            RandomizerSettingsWindow?.Dispose();
            MasterFlowPanel?.Dispose();
            GenerateRolesButton?.Dispose();
            Player1NameBox?.Dispose();
            Player2NameBox?.Dispose();
            Player3NameBox?.Dispose();
            Player4NameBox?.Dispose();
            Player5NameBox?.Dispose();
            Player6NameBox?.Dispose();
            Player7NameBox?.Dispose();
            Player8NameBox?.Dispose();
            Player9NameBox?.Dispose();
            Player10NameBox?.Dispose();
            PlayerNameTextBoxPanel?.Dispose();
            for (int i = 0; i < 10; i++)
            {
                PlayerPanels[i]?.Dispose();
                StandardRolesPanel[i]?.Dispose();
                HoTMechanicsPanel[i]?.Dispose();
                PoFMechanicsPanel[i]?.Dispose();
            }
            MasterFlowPanel?.Dispose();
            RandomizeCheckboxesPanel?.Dispose();
            #endregion
            #region Static Members
            HandKiteValid = null;
            OilKiteValid = null;
            FlakKiteValid = null;
            TankValid = null;
            HealAlacValid = null;
            HealQuickValid = null;
            DPSAlacValid = null;
            DPSQuickValid = null;
            MushroomValid = null;
            TowerValid = null;
            ReflectValid = null;
            CannonValid = null;
            ConstrucPusherValid = null;
            LampValid = null;
            PylonValid = null;
            PillarValid = null;
            GreenValid = null;
            SoullessPusherValid = null;
            DhuumKiteValid = null;
            QadimKiteValid = null;
            SwordValid = null;
            ShieldValid = null;
            CounterBoxesSettings = null;
            RolesToGenerate = null;
            HandKiteRoles = null;
            OilKiteRoles = null;
            FlakKiteRoles = null;
            TankRoles = null;
            HealAlacRoles = null;
            HealQuickRoles = null;
            DPSAlacRoles = null;
            DPSQuickRoles = null;
            MushroomRoles = null;
            TowerRoles = null;
            ReflectRoles = null;
            CannonRoles = null;
            ConstrucPusherRoles = null;
            LampRoles = null;
            PylonRoles = null;
            PillarRoles = null;
            GreenRoles = null;
            SoullessPusherRoles = null;
            DhuumKiteRoles = null;
            QadimKiteRoles = null;
            SwordRoles = null;
            ShieldRoles = null;
            for (int i = 0; i < 10; i++)
            {
                PlayerNames[i] = null;
            }
            ListofRoleValidLists = null;
            RolestoRandomizeSelectionCheckboxesArray = null;
            Randomizer.Randomizer.RoleName_to_SelectedPlayer = null;
            #endregion
            #region Events
            Player1NameBox.TextChanged -= Player1NameBox_TextChanged;
            Player2NameBox.TextChanged -= Player2NameBox_TextChanged;
            Player3NameBox.TextChanged -= Player3NameBox_TextChanged;
            Player4NameBox.TextChanged -= Player4NameBox_TextChanged;
            Player5NameBox.TextChanged -= Player5NameBox_TextChanged;
            Player6NameBox.TextChanged -= Player6NameBox_TextChanged;
            Player7NameBox.TextChanged -= Player7NameBox_TextChanged;
            Player8NameBox.TextChanged -= Player8NameBox_TextChanged;
            Player9NameBox.TextChanged -= Player9NameBox_TextChanged;
            Player10NameBox.TextChanged -= Player10NameBox_TextChanged;
            CounterBoxes[0].Click -= CounterBox1Click;
            CounterBoxes[1].Click -= CounterBox2Click;
            CounterBoxes[2].Click -= CounterBox3Click;
            CounterBoxes[3].Click -= CounterBox4Click;
            CounterBoxes[4].Click -= CounterBox5Click;
            CounterBoxes[5].Click -= CounterBox6Click;
            CounterBoxes[6].Click -= CounterBox7Click;
            CounterBoxes[7].Click -= CounterBox8Click;
            CounterBoxes[8].Click -= CounterBox9Click;
            CounterBoxes[9].Click -= CounterBox10Click;
            CounterBoxes[10].Click -= CounterBox11Click;
            CounterBoxes[11].Click -= CounterBox12Click;
            GenerateRolesButton.Click -= GenerateRolesButton_Click;
            RandomizerSettingIcon.Click -= delegate{RandomizerSettingsWindow.Show();};
            #endregion
        }
    }
}

