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

namespace Falson.Squad_Role_Randomizer
{
    [Export(typeof(Blish_HUD.Modules.Module))]
    public class RoleRandomizerMain : Blish_HUD.Modules.Module
    {
        public static StandardWindow RandomizerResultsWindow;
        public static StandardWindow RandomizerSettingsWindow;
        private CornerIcon RandomizerSettingIcon;
        public static List<string> HandKiteValid;
        public static List<string> OilKiteValid;
        public static List<string> FlakKiteValid;
        public static List<string> TankValid;
        public static List<string> HealAlacValid;
        public static List<string> HealQuickValid;
        public static List<string> DPSAlacValid;
        public static List<string> DPSQuickValid;
        public static List<string> MushroomValid;
        public static List<string> TowerValid;
        public static List<string> ReflectValid;
        public static List<string> CannonValid;
        public static List<string> ConstrucPusherValid;
        public static List<string> LampValid;
        public static List<string> PylonValid;
        public static List<string> PillarValid;
        public static List<string> GreenValid;
        public static List<string> SoullessPusherValid;
        public static List<string> DhuumKiteValid;
        public static List<string> QadimKiteValid;
        public static List<string> SwordValid;
        public static List<string> ShieldValid;
        public static Label RandomizationOutputLabel;
        public CounterBox[] CounterBoxes; //need 12 items in this
        public Label[] CounterBoxLabels;
        private StandardButton GenerateRolesButton;
        public SettingCollection InternalPlayerRolesSettings;
        public static SettingEntry<int>[]  CounterBoxesSettings;
        public static SettingEntry<bool>[] RolesToGenerate;
        public static SettingEntry<bool>[] HandKiteRoles;
        public static SettingEntry<bool>[] OilKiteRoles;
        public static SettingEntry<bool>[] FlakKiteRoles;
        public static SettingEntry<bool>[] TankRoles;
        public static SettingEntry<bool>[] HealAlacRoles;
        public static SettingEntry<bool>[] HealQuickRoles;
        public static SettingEntry<bool>[] DPSAlacRoles;
        public static SettingEntry<bool>[] DPSQuickRoles;
        public static SettingEntry<bool>[] MushroomRoles;
        public static SettingEntry<bool>[] TowerRoles;
        public static SettingEntry<bool>[] ReflectRoles;
        public static SettingEntry<bool>[] CannonRoles;
        public static SettingEntry<bool>[] ConstrucPusherRoles;
        public static SettingEntry<bool>[] LampRoles;
        public static SettingEntry<bool>[] PylonRoles;
        public static SettingEntry<bool>[] PillarRoles;
        public static SettingEntry<bool>[] GreenRoles;
        public static SettingEntry<bool>[] SoullessPusherRoles;
        public static SettingEntry<bool>[] DhuumKiteRoles;
        public static SettingEntry<bool>[] QadimKiteRoles;
        public static SettingEntry<bool>[] SwordRoles;
        public static SettingEntry<bool>[] ShieldRoles;
        public static SettingEntry<string> Player1Name; 
        public static SettingEntry<string> Player2Name;
        public static SettingEntry<string> Player3Name;
        public static SettingEntry<string> Player4Name;
        public static SettingEntry<string> Player5Name;
        public static SettingEntry<string> Player6Name;
        public static SettingEntry<string> Player7Name;
        public static SettingEntry<string> Player8Name;
        public static SettingEntry<string> Player9Name;
        public static SettingEntry<string> Player10Name;
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
        public FlowPanel Player1FlowPanel;
        public FlowPanel Player2FlowPanel;
        public FlowPanel Player3FlowPanel;
        public FlowPanel Player4FlowPanel;
        public FlowPanel Player5FlowPanel;
        public FlowPanel Player6FlowPanel;
        public FlowPanel Player7FlowPanel;
        public FlowPanel Player8FlowPanel;
        public FlowPanel Player9FlowPanel;
        public FlowPanel Player10FlowPanel;
        public FlowPanel MasterFlowPanel;
        public FlowPanel RandomizeCheckboxesPanel;
        public FlowPanel HoT_PlayerRolesPanel1;
        public FlowPanel PoF_PlayerRolesPanel1;
        public FlowPanel HoT_PlayerRolesPanel2;
        public FlowPanel PoF_PlayerRolesPanel2;
        public FlowPanel HoT_PlayerRolesPanel3;
        public FlowPanel PoF_PlayerRolesPanel3;
        public FlowPanel HoT_PlayerRolesPanel4;
        public FlowPanel PoF_PlayerRolesPanel4;
        public FlowPanel HoT_PlayerRolesPanel5;
        public FlowPanel PoF_PlayerRolesPanel5;
        public FlowPanel HoT_PlayerRolesPanel6;
        public FlowPanel PoF_PlayerRolesPanel6;
        public FlowPanel HoT_PlayerRolesPanel7;
        public FlowPanel PoF_PlayerRolesPanel7;
        public FlowPanel HoT_PlayerRolesPanel8;
        public FlowPanel PoF_PlayerRolesPanel8;
        public FlowPanel HoT_PlayerRolesPanel9;
        public FlowPanel PoF_PlayerRolesPanel9;
        public FlowPanel HoT_PlayerRolesPanel10;
        public FlowPanel PoF_PlayerRolesPanel10;
        //Checkbox Arrays
        public CustomCheckbox[] HandKiteBoxArray;
        public CustomCheckbox[] OilKiteBoxArray;
        public CustomCheckbox[] FlakKiteBoxArray;
        public CustomCheckbox[] TankBoxArray;
        public CustomCheckbox[] HealAlacBoxArray; //1-2
        public CustomCheckbox[] HealQuickBoxArray; //1-2
        public CustomCheckbox[] DPSAlacBoxArray; //1-2
        public CustomCheckbox[] DPSQuickBoxArray; //1-2
        public CustomCheckbox[] MushroomBoxArray; //1-4
        public CustomCheckbox[] TowerBoxArray;
        public CustomCheckbox[] ReflectBoxArray;
        public CustomCheckbox[] CannonBoxArray; //1-2
        public CustomCheckbox[] ConstrucPusherBoxArray;
        public CustomCheckbox[] LampBoxArray; //1-3
        public CustomCheckbox[] PylonBoxArray; //1-3
        public CustomCheckbox[] PillarBoxArray; //1-5
        public CustomCheckbox[] GreenBoxArray; //1-2
        public CustomCheckbox[] SoullessPusherBoxArray;
        public CustomCheckbox[] DhuumKiteBoxArray;
        public CustomCheckbox[] QadimKiteBoxArray;
        public CustomCheckbox[] SwordBoxArray; //1-2
        public CustomCheckbox[] ShieldBoxArray; //1-2
        public static CustomCheckbox[] RolestoRandomizeSelectionCheckboxesArray;
        public Panel[] HoTPannelArray;
        public Panel[] PoFPannelArray;
        public Panel RolesWithNumbers;
        

        private static readonly Logger Logger = Logger.GetLogger<Module>();

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
            CounterBoxesSettings = new SettingEntry<int>[12];
            for (int i = 0; i < 12; i++)
            {
                CounterBoxesSettings[i] = InternalPlayerRolesSettings.DefineSetting("Counter Box " + (i+1) + "setting", 1);
            }
            RolesToGenerate = new SettingEntry<bool>[22];
            for (int i = 0; i < 22; i++)
            {
                RolesToGenerate[i] = InternalPlayerRolesSettings.DefineSetting("Role to Generate " + (i+1), true);
            }
            Player1Name = InternalPlayerRolesSettings.DefineSetting("Player 1 Name", "Player 1");
            Player2Name = InternalPlayerRolesSettings.DefineSetting("Player 2 Name", "Player 2");
            Player3Name = InternalPlayerRolesSettings.DefineSetting("Player 3 Name", "Player 3");
            Player4Name = InternalPlayerRolesSettings.DefineSetting("Player 4 Name", "Player 4");
            Player5Name = InternalPlayerRolesSettings.DefineSetting("Player 5 Name", "Player 5");
            Player6Name = InternalPlayerRolesSettings.DefineSetting("Player 6 Name", "Player 6");
            Player7Name = InternalPlayerRolesSettings.DefineSetting("Player 7 Name", "Player 7");
            Player8Name = InternalPlayerRolesSettings.DefineSetting("Player 8 Name", "Player 8");
            Player9Name = InternalPlayerRolesSettings.DefineSetting("Player 9 Name", "Player 9");
            Player10Name = InternalPlayerRolesSettings.DefineSetting("Player 10 Name", "Player 10");
            HandKiteValid = new List<string>();
            OilKiteValid = new List<string>();
            FlakKiteValid = new List<string>();
            TankValid = new List<string>();
            HealAlacValid = new List<string>();
            HealQuickValid = new List<string>();
            DPSAlacValid = new List<string>();
            DPSQuickValid = new List<string>();
            MushroomValid = new List<string>();
            TowerValid = new List<string>();
            ReflectValid = new List<string>();
            CannonValid = new List<string>();
            ConstrucPusherValid = new List<string>();
            LampValid = new List<string>();
            PylonValid = new List<string>();
            PillarValid = new List<string>();
            GreenValid = new List<string>();
            SoullessPusherValid = new List<string>();
            DhuumKiteValid = new List<string>();
            QadimKiteValid = new List<string>();
            SwordValid = new List<string>();
            ShieldValid = new List<string>();
            HandKiteRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                HandKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting("Hand_Kite Player" + (i + 1).ToString(), false);
            }
            OilKiteRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                OilKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting("OilKite Player" + (i + 1).ToString(), false);
            }
            FlakKiteRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                FlakKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting("FlakKite Player" + (i + 1).ToString(), false);
            }
            TankRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                TankRoles[i] = InternalPlayerRolesSettings.DefineSetting("Tank Player" + (i + 1).ToString(), false);
            }
            HealAlacRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                HealAlacRoles[i] = InternalPlayerRolesSettings.DefineSetting("HealAlac Player" + (i + 1).ToString(), false);
            }
            HealQuickRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                HealQuickRoles[i] = InternalPlayerRolesSettings.DefineSetting("HealQuick Player" + (i + 1).ToString(), false);
            }
            DPSAlacRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                DPSAlacRoles[i] = InternalPlayerRolesSettings.DefineSetting("DPSAlac Player" + (i + 1).ToString(), false);
            }
            DPSQuickRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                DPSQuickRoles[i] = InternalPlayerRolesSettings.DefineSetting("DPSQuick Player" + (i + 1).ToString(), false);
            }
            MushroomRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                MushroomRoles[i] = InternalPlayerRolesSettings.DefineSetting("Mushroom Player" + (i + 1).ToString(), false);
            }
            TowerRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                TowerRoles[i] = InternalPlayerRolesSettings.DefineSetting("Tower Player" + (i + 1).ToString(), false);
            }
            ReflectRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                ReflectRoles[i] = InternalPlayerRolesSettings.DefineSetting("Reflect Player" + (i + 1).ToString(), false);
            }
            CannonRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                CannonRoles[i] = InternalPlayerRolesSettings.DefineSetting("Cannon Player" + (i + 1).ToString(), false);
            }
            ConstrucPusherRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                ConstrucPusherRoles[i] = InternalPlayerRolesSettings.DefineSetting("ConstrucPusher Player" + (i + 1).ToString(), false);
            }
            LampRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                LampRoles[i] = InternalPlayerRolesSettings.DefineSetting("Lamp Player" + (i + 1).ToString(), false);
            }
            PylonRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                PylonRoles[i] = InternalPlayerRolesSettings.DefineSetting("Pylon Player" + (i + 1).ToString(), false);
            }
            PillarRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                PillarRoles[i] = InternalPlayerRolesSettings.DefineSetting("Pillar Player" + (i + 1).ToString(), false);
            }
            GreenRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                GreenRoles[i] = InternalPlayerRolesSettings.DefineSetting("Green Player" + (i + 1).ToString(), false);
            }
            SoullessPusherRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                SoullessPusherRoles[i] = InternalPlayerRolesSettings.DefineSetting("SoullessPusher Player" + (i + 1).ToString(), false);
            }
            DhuumKiteRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                DhuumKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting("DhuumKite Player" + (i + 1).ToString(), false);
            }
            QadimKiteRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                QadimKiteRoles[i] = InternalPlayerRolesSettings.DefineSetting("QadimKite Player" + (i + 1).ToString(), false);
            }
            SwordRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                SwordRoles[i] = InternalPlayerRolesSettings.DefineSetting("Sword Player" + (i + 1).ToString(), false);
            }
            ShieldRoles = new SettingEntry<bool>[10];
            for (int i = 0; i < 10; i++)
            {
                ShieldRoles[i] = InternalPlayerRolesSettings.DefineSetting("Shield Player" + (i + 1).ToString(), false);
            }
        }

        protected override void Initialize()
        {

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
                Id = "Falson.RoleRandomizer.SettingsWindow"
            };
            RandomizerResultsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Randomized Roles",
                Parent = GameService.Graphics.SpriteScreen,
                Size = new Point(450, 800),
                Location = new Point(100, 100),
                SavesPosition = true,
                Id = "Falson.RoleRandomizer.ResultsWindow"
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
            RandomizeCheckboxesPanel = new FlowPanel
            {
                Title = "Select roles to be randomized",
                Size = new Point(1000, 120),
                Parent = RandomizerSettingsWindow,
                Location = new Point(0, 166),
                FlowDirection = ControlFlowDirection.LeftToRight
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
            Player1FlowPanel = new FlowPanel
            {
                Title = Player1Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            Player2FlowPanel = new FlowPanel
            {
                Title = Player2Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            Player3FlowPanel = new FlowPanel
            {
                Title = Player3Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player4FlowPanel = new FlowPanel
            {
                Title = Player4Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player5FlowPanel = new FlowPanel
            {
                Title = Player5Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player6FlowPanel = new FlowPanel
            {
                Title = Player6Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player7FlowPanel = new FlowPanel
            {
                Title = Player7Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player8FlowPanel = new FlowPanel
            {
                Title = Player8Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player9FlowPanel = new FlowPanel
            {
                Title = Player9Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player10FlowPanel = new FlowPanel
            {
                Title = Player10Name.Value,
                Size = new Point(1050, 150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            #endregion
            #region HoT_FlowPanels
            HoT_PlayerRolesPanel1 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player1FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel2 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player2FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel3 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player3FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel4 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player4FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel5 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player5FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel6 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player6FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel7 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player7FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel8 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player8FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel9 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player9FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles",
            };
            HoT_PlayerRolesPanel10 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player10FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            #endregion
            #region PoF_FlowPanels
            PoF_PlayerRolesPanel1 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player1FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel2 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player2FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel3 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player3FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel4 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player4FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel5 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player5FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel6 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player6FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel7 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player7FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel8 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player8FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel9 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player9FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            PoF_PlayerRolesPanel10 = new FlowPanel()
            {
                Size = new Point(510, 150),
                Parent = Player10FlowPanel,
                ShowBorder = true,
                Title = "PoF Roles",
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            #endregion
            #region Box and Label Arrays
            RolestoRandomizeSelectionCheckboxesArray = new CustomCheckbox[22];
            //RolestoRandomizeSelectionCheckboxesArray = new Checkbox[22] {RandomizeHandKite,RandomizeOilKite,RandomizeFlakKite,RandomizeTank,RandomizeHealAlac,RandomizeHealQuick,RandomizeDPSAlac,RandomizeDPSQuick,RandomizeMushroom,RandomizeTower,RandomizeReflect,RandomizeCannon,RandomizeConstrucPusher,RandomizeLamp,RandomizePylon,RandomizePillar,RandomizeGreen,RandomizeSoullessPusher,RandomizeDhuumKite,RandomizeQadimKite,RandomizeSword,RandomizeShield};
            HandKiteBoxArray = new CustomCheckbox[10];
            OilKiteBoxArray = new CustomCheckbox[10];
            FlakKiteBoxArray = new CustomCheckbox[10];
            TankBoxArray = new CustomCheckbox[10];
            HealAlacBoxArray = new CustomCheckbox[10];
            HealQuickBoxArray = new CustomCheckbox[10];
            DPSAlacBoxArray = new CustomCheckbox[10];
            DPSQuickBoxArray = new CustomCheckbox[10];
            MushroomBoxArray = new CustomCheckbox[10];
            TowerBoxArray = new CustomCheckbox[10];
            ReflectBoxArray = new CustomCheckbox[10];
            CannonBoxArray = new CustomCheckbox[10];
            ConstrucPusherBoxArray = new CustomCheckbox[10];
            LampBoxArray = new CustomCheckbox[10];
            PylonBoxArray = new CustomCheckbox[10];
            PillarBoxArray = new CustomCheckbox[10];
            GreenBoxArray = new CustomCheckbox[10];
            SoullessPusherBoxArray = new CustomCheckbox[10];
            DhuumKiteBoxArray = new CustomCheckbox[10];
            QadimKiteBoxArray = new CustomCheckbox[10];
            SwordBoxArray = new CustomCheckbox[10];
            ShieldBoxArray = new CustomCheckbox[10];
            ListofCheckboxArrays = new List<CustomCheckbox[]> {HandKiteBoxArray,OilKiteBoxArray,FlakKiteBoxArray,TankBoxArray,HealAlacBoxArray,HealQuickBoxArray,DPSAlacBoxArray,DPSQuickBoxArray,MushroomBoxArray,TowerBoxArray,ReflectBoxArray,CannonBoxArray,ConstrucPusherBoxArray,LampBoxArray,PylonBoxArray,PillarBoxArray,GreenBoxArray,SoullessPusherBoxArray,DhuumKiteBoxArray,QadimKiteBoxArray,SwordBoxArray,ShieldBoxArray };
            ListofRolesSettings = new List<SettingEntry<bool>[]> {HandKiteRoles,OilKiteRoles,FlakKiteRoles,TankRoles,HealAlacRoles,HealQuickRoles,DPSAlacRoles,DPSQuickRoles,MushroomRoles,TowerRoles,ReflectRoles,CannonRoles,ConstrucPusherRoles,LampRoles,PylonRoles,PillarRoles,GreenRoles,SoullessPusherRoles,DhuumKiteRoles,QadimKiteRoles,SwordRoles,ShieldRoles };
            ListofRoleValidLists = new List<List<string>> { HandKiteValid,OilKiteValid,FlakKiteValid,TankValid,HealAlacValid,HealQuickValid,DPSAlacValid,DPSQuickValid,MushroomValid,TowerValid,ReflectValid,CannonValid,ConstrucPusherValid,LampValid,PylonValid,PillarValid,GreenValid,SoullessPusherValid,DhuumKiteValid,QadimKiteValid,SwordValid,ShieldValid};
            #endregion
            #region Checkboxes
            HoTPannelArray = new Panel[10] { HoT_PlayerRolesPanel1, HoT_PlayerRolesPanel2, HoT_PlayerRolesPanel3, HoT_PlayerRolesPanel4, HoT_PlayerRolesPanel5, HoT_PlayerRolesPanel6, HoT_PlayerRolesPanel7, HoT_PlayerRolesPanel8, HoT_PlayerRolesPanel9, HoT_PlayerRolesPanel10 };
            PoFPannelArray = new Panel[10] { PoF_PlayerRolesPanel1, PoF_PlayerRolesPanel2, PoF_PlayerRolesPanel3, PoF_PlayerRolesPanel4, PoF_PlayerRolesPanel5, PoF_PlayerRolesPanel6, PoF_PlayerRolesPanel7, PoF_PlayerRolesPanel8, PoF_PlayerRolesPanel9, PoF_PlayerRolesPanel10 };

            for (int i = 0; i < 10; i++)
            {
                HandKiteBoxArray[i] = new CustomCheckbox(HandKiteRoles[i]) 
                {
                    Text = "Hand Kite",
                    Location = new Point(0,0),
                    BasicTooltipText = "Hand Kite",
                    Parent = HoTPannelArray[i],
                    Checked = HandKiteRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                OilKiteBoxArray[i] = new CustomCheckbox(OilKiteRoles[i])
                {
                    Text = "Oil Kite",
                    Location = new Point(100,0),
                    BasicTooltipText = "Oil Kite",
                    Parent = HoTPannelArray[i],
                    Checked = OilKiteRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                FlakKiteBoxArray[i] = new CustomCheckbox(FlakKiteRoles[i])
                {
                    Text = "Flak Kite",
                    Location = new Point(200,0),
                    BasicTooltipText = "Flak Kite",
                    Parent = HoTPannelArray[i],
                    Checked = FlakKiteRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                TankBoxArray[i] = new CustomCheckbox(TankRoles[i]) 
                {
                    Text = "Tank",
                    Location = new Point(300, 0),
                    BasicTooltipText = "Tank",
                    Parent = HoTPannelArray[i],
                    Checked = TankRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                HealAlacBoxArray[i] = new CustomCheckbox(HealAlacRoles[i])
                {
                    Text = "Heal + Alac",
                    Location = new Point(400,0),
                    BasicTooltipText = "Heal + Alac",
                    Parent = HoTPannelArray[i],
                    Checked = HealAlacRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                HealQuickBoxArray[i] = new CustomCheckbox(HealQuickRoles[i])
                {
                    Text = "Heal + Quick",
                    Location = new Point(0, 50),
                    BasicTooltipText = "Heal + Quick",
                    Parent = HoTPannelArray[i],
                    Checked = HealQuickRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                DPSAlacBoxArray[i] = new CustomCheckbox(DPSAlacRoles[i])
                {
                    Text = "DPS + Alac",
                    Location = new Point(100,50),
                    BasicTooltipText = "DPS + Alac",
                    Parent = HoTPannelArray[i],
                    Checked = DPSAlacRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                DPSQuickBoxArray[i] = new CustomCheckbox(DPSQuickRoles[i])
                {
                    Text = "DPS + Quick",
                    Location = new Point(200,50),
                    BasicTooltipText = "DPS + Quick",
                    Parent = HoTPannelArray[i],
                    Checked = DPSQuickRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                MushroomBoxArray[i] = new CustomCheckbox(MushroomRoles[i])
                {
                    Text = "Slothosaur Mushroom",
                    Location = new Point(300, 50),
                    BasicTooltipText = "Slothosaur Mushroom",
                    Parent = HoTPannelArray[i],
                    Checked = MushroomRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                TowerBoxArray[i] = new CustomCheckbox(TowerRoles[i])
                {
                    Text = "Tower Mesmer",
                    Location = new Point(400, 50),
                    BasicTooltipText = "Tower Mesmer",
                    Parent = HoTPannelArray[i],
                    Checked = TowerRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                ReflectBoxArray[i] = new CustomCheckbox(ReflectRoles[i])
                {
                    Text = "Matthias Reflect",
                    Location = new Point(0, 100),
                    BasicTooltipText = "Matthias Reflect",
                    Parent = HoTPannelArray[i],
                    Checked = ReflectRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                CannonBoxArray[i] = new CustomCheckbox(CannonRoles[i])
                {
                    Text = "Sabetha Cannons",
                    Location = new Point(100,100),
                    BasicTooltipText = "Sabetha Cannons",
                    Parent = HoTPannelArray[i],
                    Checked = CannonRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                ConstrucPusherBoxArray[i] = new CustomCheckbox(ConstrucPusherRoles[i])
                {
                    Text = "Keep Construct Pusher",
                    Location = new Point(200, 100),
                    BasicTooltipText = "Keep Construct Pusher",
                    Parent = HoTPannelArray[i],
                    Checked = ConstrucPusherRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                LampBoxArray[i] = new CustomCheckbox(LampRoles[i])
                {
                    Text = "Qadim Lamp",
                    Location = new Point(0,0),
                    BasicTooltipText = "Qadim Lamp",
                    Parent = PoFPannelArray[i],
                    Checked = LampRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                PylonBoxArray[i] = new CustomCheckbox(PylonRoles[i])
                {
                    Text = "Qadim Pylon",
                    Location = new Point(100,0),
                    BasicTooltipText = "Qadim Pylon",
                    Parent = PoFPannelArray[i],
                    Checked = PylonRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                PillarBoxArray[i] = new CustomCheckbox(PillarRoles[i])
                {
                    Text = "Adina Pillar",
                    Location = new Point(200,0),
                    BasicTooltipText = "Adina Pillar",
                    Parent = PoFPannelArray[i],
                    Checked = PillarRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                GreenBoxArray[i] = new CustomCheckbox(GreenRoles[i])
                {
                    Text = "Dhuum Green",
                    Location = new Point(300,0),
                    BasicTooltipText = "Dhuum Green",
                    Parent = PoFPannelArray[i],
                    Checked = GreenRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                SoullessPusherBoxArray[i] = new CustomCheckbox(SoullessPusherRoles[i])
                {
                    Text = "Soulless Horror Pusher",
                    Location = new Point(400,0),
                    BasicTooltipText = "Soulless Horror Pusher",
                    Parent = PoFPannelArray[i],
                    Checked = SoullessPusherRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                DhuumKiteBoxArray[i] = new CustomCheckbox(DhuumKiteRoles[i])
                {
                    Text = "Dhuum Messenger Kiter",
                    Location = new Point(0,50),
                    BasicTooltipText = "Dhuum Messenger Kiter",
                    Parent = PoFPannelArray[i],
                    Checked = DhuumKiteRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                QadimKiteBoxArray[i] = new CustomCheckbox(QadimKiteRoles[i])
                {
                    Text = "Qadim Kiter",
                    Location = new Point(100,50),
                    BasicTooltipText = "Qadim Kiter",
                    Parent = PoFPannelArray[i],
                    Checked = QadimKiteRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                SwordBoxArray[i] = new CustomCheckbox(SwordRoles[i])
                {
                    Text = "CA Sword Collector",
                    Location = new Point(200,50),
                    BasicTooltipText = "CA Sword Collector",
                    Parent = PoFPannelArray[i],
                    Checked = SwordRoles[i].Value
                };
            }
            for (int i = 0; i < 10; i++)
            {
                ShieldBoxArray[i] = new CustomCheckbox(ShieldRoles[i])
                {
                    Text = "CA Shield Collector",
                    Location = new Point(300, 50),
                    BasicTooltipText = "CA Shield Collector",
                    Parent = PoFPannelArray[i],
                    Checked = ShieldRoles[i].Value
                };
            }
            IDictionary<int, string> RandomizeSelectionBoxesInt_to_StringDictionary = new Dictionary<int, string> 
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
                    Text =  RandomizeSelectionBoxesInt_to_StringDictionary[i] + "  ",
                    BasicTooltipText = "Check this box to include " + RandomizeSelectionBoxesInt_to_StringDictionary[i] + " in the randomization",
                    Parent = RandomizeCheckboxesPanel,
                    Checked = RolesToGenerate[i].Value
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
                    MinValue = 1,
                    Location = new Point(CounterBox_X_PositionDictionary[i],CounterBox_Y_PositionDictionary[i])
                };
            }
            #endregion
            #region Textboxes
            Player1NameBox = new TextBox 
            {
                PlaceholderText = Player1Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0,0)
            };
            Player2NameBox = new TextBox 
            {
                PlaceholderText = Player2Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 25)
            };
            Player3NameBox = new TextBox 
            {
                PlaceholderText = Player3Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 50)
            };
            Player4NameBox = new TextBox 
            {
                PlaceholderText = Player4Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 75)
            };
            Player5NameBox = new TextBox 
            {
                PlaceholderText = Player5Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(0, 100)
            };
            Player6NameBox = new TextBox 
            {
                PlaceholderText = Player6Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 0)
            };
            Player7NameBox = new TextBox 
            {
                PlaceholderText = Player7Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 25)
            };
            Player8NameBox = new TextBox 
            {
                PlaceholderText = Player8Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 50)
            };
            Player9NameBox = new TextBox 
            {
                PlaceholderText = Player9Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 75)
            };
            Player10NameBox = new TextBox 
            {
                PlaceholderText = Player10Name.Value,
                Size = new Point(200,25),
                Parent = PlayerNameTextBoxPanel,
                Location = new Point(200, 100)
            };
            #endregion
            #region Labels

            RandomizationOutputLabel = new Label 
            {
            Parent = RandomizerResultsWindow,
            Location = new Point(0,0),
            Size = new Point(375, 650),
            VerticalAlignment = VerticalAlignment.Top
            };
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
            Player10FlowPanel.Title = Player10NameBox.Text;
            Player10Name.Value = Player10NameBox.Text;
        }

        private void Player9NameBox_TextChanged(object sender, EventArgs e)
        {
            Player9FlowPanel.Title = Player9NameBox.Text;
            Player9Name.Value = Player9NameBox.Text;
        }

        private void Player8NameBox_TextChanged(object sender, EventArgs e)
        {
            Player8FlowPanel.Title = Player8NameBox.Text;
            Player8Name.Value = Player8NameBox.Text;
        }

        private void Player7NameBox_TextChanged(object sender, EventArgs e)
        {
            Player7FlowPanel.Title = Player7NameBox.Text;
            Player7Name.Value = Player7NameBox.Text;
        }

        private void Player6NameBox_TextChanged(object sender, EventArgs e)
        {
            Player6FlowPanel.Title = Player6NameBox.Text;
            Player6Name.Value = Player6NameBox.Text;
        }

        private void Player5NameBox_TextChanged(object sender, EventArgs e)
        {
            Player5FlowPanel.Title = Player5NameBox.Text;
            Player5Name.Value = Player5NameBox.Text;
        }

        private void Player4NameBox_TextChanged(object sender, EventArgs e)
        {
            Player4FlowPanel.Title = Player4NameBox.Text;
            Player4Name.Value = Player4NameBox.Text;
        }

        private void Player3NameBox_TextChanged(object sender, EventArgs e)
        {
            Player3FlowPanel.Title = Player3NameBox.Text;
            Player3Name.Value = Player3NameBox.Text;
        }

        private void Player2NameBox_TextChanged(object sender, EventArgs e)
        {
            Player2FlowPanel.Title = Player2NameBox.Text;
            Player2Name.Value = Player2NameBox.Text;
        }

        private void Player1NameBox_TextChanged(object sender, EventArgs e)
        {
            Player1FlowPanel.Title = Player1NameBox.Text;
            Player1Name.Value = Player1NameBox.Text;
        }
        #endregion
        protected override void OnModuleLoaded(EventArgs e)
        {
            //GenerateRoles.RandomizeTheRoles();
            RandomizerSettingIcon = new CornerIcon 
            {
                Icon = ContentsManager.GetTexture("Emblem.png"),
                BasicTooltipText = "Click to open settings window"
            };
            RandomizerSettingIcon.Click += delegate 
            {
                RandomizerSettingsWindow.Show();

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
            foreach(var item in HoTPannelArray)
            {
                item?.Dispose();
            }
            foreach(var item in PoFPannelArray)
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
            Player1FlowPanel?.Dispose();
            Player2FlowPanel?.Dispose();
            Player3FlowPanel?.Dispose();
            Player4FlowPanel?.Dispose();
            Player5FlowPanel?.Dispose();
            Player6FlowPanel?.Dispose();
            Player7FlowPanel?.Dispose();
            Player8FlowPanel?.Dispose();
            Player9FlowPanel?.Dispose();
            Player10FlowPanel?.Dispose();
            MasterFlowPanel?.Dispose();
            RandomizeCheckboxesPanel?.Dispose();
            HoT_PlayerRolesPanel1?.Dispose();
            PoF_PlayerRolesPanel1?.Dispose();
            HoT_PlayerRolesPanel2?.Dispose();
            PoF_PlayerRolesPanel2?.Dispose();
            HoT_PlayerRolesPanel3?.Dispose();
            PoF_PlayerRolesPanel3?.Dispose();
            HoT_PlayerRolesPanel4?.Dispose();
            PoF_PlayerRolesPanel4?.Dispose();
            HoT_PlayerRolesPanel5?.Dispose();
            PoF_PlayerRolesPanel5?.Dispose();
            HoT_PlayerRolesPanel6?.Dispose();
            PoF_PlayerRolesPanel6?.Dispose();
            HoT_PlayerRolesPanel7?.Dispose();
            PoF_PlayerRolesPanel7?.Dispose();
            HoT_PlayerRolesPanel8?.Dispose();
            PoF_PlayerRolesPanel8?.Dispose();
            HoT_PlayerRolesPanel9?.Dispose();
            PoF_PlayerRolesPanel9?.Dispose();
            HoT_PlayerRolesPanel10?.Dispose();
            PoF_PlayerRolesPanel10?.Dispose();
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
            RandomizationOutputLabel = null;
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
            Player1Name = null;
            Player2Name = null;
            Player3Name = null;
            Player4Name = null;
            Player5Name = null;
            Player6Name = null;
            Player7Name = null;
            Player8Name = null;
            Player9Name = null;
            Player10Name = null;
            ListofRoleValidLists = null;
            RolestoRandomizeSelectionCheckboxesArray = null;
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

    public class PrepareRoles
    {
        public static List<SettingEntry<bool>[]> Rolestoberandomized;
        public static List<int> Length_of_Roles_Arrays;
        public static List<List<string>> GenerationSequence;
        public static List<List<string>> ListofValidLists;
        public static void PrepRoles() 
        {
            //This method prepares the roles to pass to the randomizer. It converts the checkboxes to activated roles to randomize, loads the saved player names into the list of valid options for each role
            //and then sorts them from smallest to largest, removing any role list that has no players. This information is then stored in a list called GenerationSequence, which is passed to the randomizer
            //to be sorted one last time before the randomizer class actually performs the necessary actions to randomize a member into each role.
            //Rolestoberandomized = new List<SettingEntry<bool>[]>();
            GenerationSequence = new List<List<string>>();
            ListofValidLists = new List<List<string>>{RoleRandomizerMain.HandKiteValid,RoleRandomizerMain.OilKiteValid,RoleRandomizerMain.FlakKiteValid,RoleRandomizerMain.TankValid,RoleRandomizerMain.HealAlacValid,RoleRandomizerMain.HealQuickValid,RoleRandomizerMain.DPSAlacValid,RoleRandomizerMain.DPSQuickValid,RoleRandomizerMain.MushroomValid,RoleRandomizerMain.TowerValid,RoleRandomizerMain.ReflectValid,RoleRandomizerMain.CannonValid,RoleRandomizerMain.ConstrucPusherValid,RoleRandomizerMain.LampValid,RoleRandomizerMain.PylonValid,RoleRandomizerMain.PillarValid,RoleRandomizerMain.GreenValid,RoleRandomizerMain.SoullessPusherValid,RoleRandomizerMain.DhuumKiteValid,RoleRandomizerMain.QadimKiteValid,RoleRandomizerMain.SwordValid,RoleRandomizerMain.ShieldValid,};
            IDictionary<CustomCheckbox, SettingEntry<bool>[]> ActiveRolesDictionary = new Dictionary<CustomCheckbox, SettingEntry<bool>[]>() 
            {
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[0], RoleRandomizerMain.HandKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[1], RoleRandomizerMain.OilKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[2], RoleRandomizerMain.FlakKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[3], RoleRandomizerMain.TankRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[4], RoleRandomizerMain.HealAlacRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[5], RoleRandomizerMain.HealQuickRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[6], RoleRandomizerMain.DPSAlacRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[7], RoleRandomizerMain.DPSQuickRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[8], RoleRandomizerMain.MushroomRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[9], RoleRandomizerMain.TowerRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[10], RoleRandomizerMain.ReflectRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[11], RoleRandomizerMain.CannonRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[12], RoleRandomizerMain.ConstrucPusherRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[13], RoleRandomizerMain.LampRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[14], RoleRandomizerMain.PylonRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[15], RoleRandomizerMain.PillarRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[16], RoleRandomizerMain.GreenRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[17], RoleRandomizerMain.SoullessPusherRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[18], RoleRandomizerMain.DhuumKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[19], RoleRandomizerMain.QadimKiteRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[20], RoleRandomizerMain.SwordRoles },
                {RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[21], RoleRandomizerMain.ShieldRoles }
            };
            IDictionary<int, string> ArrayPos_to_PlayerNameDictionary = new Dictionary<int, string>() 
            {
                {0, RoleRandomizerMain.Player1Name.Value},
                {1, RoleRandomizerMain.Player2Name.Value},
                {2, RoleRandomizerMain.Player3Name.Value},
                {3, RoleRandomizerMain.Player4Name.Value},
                {4, RoleRandomizerMain.Player5Name.Value},
                {5, RoleRandomizerMain.Player6Name.Value},
                {6, RoleRandomizerMain.Player7Name.Value},
                {7, RoleRandomizerMain.Player8Name.Value},
                {8, RoleRandomizerMain.Player9Name.Value},
                {9, RoleRandomizerMain.Player10Name.Value}
            };
            IDictionary<SettingEntry<bool>[], int> RolesArrays_to_ArrayListPosDictionary = new Dictionary<SettingEntry<bool>[], int>() 
            {
                {RoleRandomizerMain.HandKiteRoles, 0},
                {RoleRandomizerMain.OilKiteRoles, 1},
                {RoleRandomizerMain.FlakKiteRoles, 2},
                {RoleRandomizerMain.TankRoles, 3},
                {RoleRandomizerMain.HealAlacRoles, 4},
                {RoleRandomizerMain.HealQuickRoles, 5},
                {RoleRandomizerMain.DPSAlacRoles, 6},
                {RoleRandomizerMain.DPSQuickRoles, 7},
                {RoleRandomizerMain.MushroomRoles, 8},
                {RoleRandomizerMain.TowerRoles, 9},
                {RoleRandomizerMain.ReflectRoles, 10},
                {RoleRandomizerMain.CannonRoles, 11},
                {RoleRandomizerMain.ConstrucPusherRoles, 12},
                {RoleRandomizerMain.LampRoles, 13},
                {RoleRandomizerMain.PylonRoles, 14},
                {RoleRandomizerMain.PillarRoles, 15},
                {RoleRandomizerMain.GreenRoles, 16},
                {RoleRandomizerMain.SoullessPusherRoles, 17},
                {RoleRandomizerMain.DhuumKiteRoles, 18},
                {RoleRandomizerMain.QadimKiteRoles, 19},
                {RoleRandomizerMain.SwordRoles, 20},
                {RoleRandomizerMain.ShieldRoles, 21}
            };
            IDictionary<SettingEntry<bool>[], List<string>> RolesArrays_to_ValidLists = new Dictionary<SettingEntry<bool>[], List<string>>()
            {
                {RoleRandomizerMain.HandKiteRoles, RoleRandomizerMain.HandKiteValid},
                {RoleRandomizerMain.OilKiteRoles,RoleRandomizerMain.OilKiteValid },
                {RoleRandomizerMain.FlakKiteRoles, RoleRandomizerMain.FlakKiteValid},
                {RoleRandomizerMain.TankRoles, RoleRandomizerMain.TankValid},
                {RoleRandomizerMain.HealAlacRoles, RoleRandomizerMain.HealAlacValid},
                {RoleRandomizerMain.HealQuickRoles,RoleRandomizerMain.HealQuickValid},
                {RoleRandomizerMain.DPSAlacRoles,RoleRandomizerMain.DPSAlacValid},
                {RoleRandomizerMain.DPSQuickRoles, RoleRandomizerMain.DPSQuickValid},
                {RoleRandomizerMain.MushroomRoles, RoleRandomizerMain.MushroomValid},
                {RoleRandomizerMain.TowerRoles, RoleRandomizerMain.TowerValid },
                {RoleRandomizerMain.ReflectRoles,RoleRandomizerMain.ReflectValid },
                {RoleRandomizerMain.CannonRoles,RoleRandomizerMain.CannonValid },
                {RoleRandomizerMain.ConstrucPusherRoles, RoleRandomizerMain.ConstrucPusherValid},
                {RoleRandomizerMain.LampRoles,  RoleRandomizerMain.LampValid},
                {RoleRandomizerMain.PylonRoles,RoleRandomizerMain.PylonValid },
                {RoleRandomizerMain.PillarRoles,RoleRandomizerMain.PillarValid },
                {RoleRandomizerMain.GreenRoles, RoleRandomizerMain.GreenValid },
                {RoleRandomizerMain.SoullessPusherRoles,RoleRandomizerMain.SoullessPusherValid },
                {RoleRandomizerMain.DhuumKiteRoles,RoleRandomizerMain.DhuumKiteValid },
                {RoleRandomizerMain.QadimKiteRoles,RoleRandomizerMain.QadimKiteValid },
                {RoleRandomizerMain.SwordRoles, RoleRandomizerMain.SwordValid },
                {RoleRandomizerMain.ShieldRoles,  RoleRandomizerMain.ShieldValid}
            };
            GenerationSequence.Clear();
            foreach (List<string> list in ListofValidLists)
            {
                list.Clear();
            }
            for (int i = 0; i < 22; i++)
            {
                if (RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[i].Checked)
                {
                    var tempkey = RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[i];
                    var temprole = ActiveRolesDictionary[tempkey];
                    var ContainsOnePlayerChecked = 0;
                    for (int s = 0; s < 10; s++)
                    {
                        if (temprole[s].Value)
                        {
                            ContainsOnePlayerChecked = 1;
                            RolesArrays_to_ValidLists[temprole].Add(ArrayPos_to_PlayerNameDictionary[s]); //adds the player that has checked true for a role to the role valid list for that particular role.
                        }
                    }
                }
            }
            var mySortedList = RoleRandomizerMain.ListofRoleValidLists.OrderBy(x => x.Count).ToList();  //sorts the populated lists by length
            foreach (List<string> item in mySortedList)
            {
                if (item.Count != 0)
                {
                    GenerationSequence.Add(item); //converts the current (role)valid list into a string name for the role to be generated and adds to the sequence, from shortest lists to longest.
                }
            }
            var TheRandomizer = new Randomizer.Randomizer();
            TheRandomizer.MainMethod();
        }
        

        
    }
    public class CustomCheckbox : Checkbox 
    {
        private readonly SettingEntry<bool> _settingEntry;

        public CustomCheckbox(SettingEntry<bool> settingsEntry)
        {
            _settingEntry = settingsEntry;
        }
        protected override void OnCheckedChanged(CheckChangedEvent e)
        {
            _settingEntry.Value = Checked;
            base.OnCheckedChanged(e);
        }
    }
}

