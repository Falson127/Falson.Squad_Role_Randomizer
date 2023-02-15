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
        private CornerIcon TestingCornerIcon;
        public static List<string> HealValid;
        public static List<string> DPSValid;
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
        public static Label SelectedTank;
        public static Label SelectedHeal1;
        public static Label SelectedHeal2;
        public static Label SelectedAlac1;
        public static Label SelectedAlac2;
        public static Label SelectedQuick1;
        public static Label SelectedQuick2;
        public static Label SelectedHandKite;
        public static Label SelectedOilKite;
        public static Label SelectedMush1;
        public static Label SelectedMush2;
        public static Label SelectedMush3;
        public static Label SelectedMush4;
        public static Label SelectedFlakKite;
        public static Label SelectedTowerMesmer;
        public static Label SelectedReflect;
        public StandardButton GenerateRandomRoles;
        public SettingCollection HoTRolesToRandomize;
        public SettingCollection PoFRolesToRandomize;
        public SettingCollection InternalPlayerRolesSettings;
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
        //public List<List<string>> SelectedRolesToRandomize;
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
        public CustomCheckbox[] HealAlacBoxArray;
        public CustomCheckbox[] HealQuickBoxArray;
        public CustomCheckbox[] DPSAlacBoxArray;
        public CustomCheckbox[] DPSQuickBoxArray;
        public CustomCheckbox[] MushroomBoxArray;
        public CustomCheckbox[] TowerBoxArray;
        public CustomCheckbox[] ReflectBoxArray;
        public CustomCheckbox[] CannonBoxArray;
        public CustomCheckbox[] ConstrucPusherBoxArray;
        public CustomCheckbox[] LampBoxArray;
        public CustomCheckbox[] PylonBoxArray;
        public CustomCheckbox[] PillarBoxArray;
        public CustomCheckbox[] GreenBoxArray;
        public CustomCheckbox[] SoullessPusherBoxArray;
        public CustomCheckbox[] DhuumKiteBoxArray;
        public CustomCheckbox[] QadimKiteBoxArray;
        public CustomCheckbox[] SwordBoxArray;
        public CustomCheckbox[] ShieldBoxArray;
        public static Checkbox[] RolestoRandomizeSelectionCheckboxesArray;
        public Panel[] HoTPannelArray;
        public Panel[] PoFPannelArray;
        //Roles Per Pannel: HoT: 13
        //Dimensions 5, 5, 3
        //Roles Per Pannel: PoF: 9
        //Dimensions 5, 4
        public Checkbox RandomizeHandKite;
        public Checkbox RandomizeOilKite;
        public Checkbox RandomizeFlakKite;
        public Checkbox RandomizeTank;
        public Checkbox RandomizeHealAlac;
        public Checkbox RandomizeHealQuick;
        public Checkbox RandomizeDPSAlac;
        public Checkbox RandomizeDPSQuick;
        public Checkbox RandomizeMushroom;
        public Checkbox RandomizeTower;
        public Checkbox RandomizeReflect;
        public Checkbox RandomizeCannon;
        public Checkbox RandomizeConstrucPusher;
        public Checkbox RandomizeLamp;
        public Checkbox RandomizePylon;
        public Checkbox RandomizePillar;
        public Checkbox RandomizeGreen;
        public Checkbox RandomizeSoullessPusher;
        public Checkbox RandomizeDhuumKite;
        public Checkbox RandomizeQadimKite;
        public Checkbox RandomizeSword;
        public Checkbox RandomizeShield;

       




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
            HealValid = new List<string>();
            DPSValid = new List<string>();
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
            RandomizerSettingsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Randomization Settings",
                Subtitle = "Define Roles to Randomize",
                Parent = GameService.Graphics.SpriteScreen,
                Size = new Point(1050, 800)
            };
            RandomizerResultsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(30, 30, 700, 930), new Rectangle(50, 50, 640, 890))
            {
                Title = "Randomized Roles",
                Parent = GameService.Graphics.SpriteScreen
            };
            PlayerNameTextBoxPanel = new Panel 
            {
                Title = "Enter Player Names",
                Size = new Point(1000,200),
                Location = new Point(0,0),
                Parent = RandomizerSettingsWindow,
            };
            RandomizeCheckboxesPanel = new FlowPanel
            {
                Title = "Select roles to be randomized",
                Size = new Point(1000,100),
                Parent = RandomizerSettingsWindow,
                Location = new Point(0,0),
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            MasterFlowPanel = new FlowPanel 
            {
                ShowBorder = true,
                Title = "Set Roles for Each Player",
                Size = new Point(1000,700),
                Location = new Point(0,101),
                Parent = RandomizerSettingsWindow,
                CanScroll = true,
                CanCollapse = false,
                FlowDirection = ControlFlowDirection.SingleTopToBottom
            };
            Player1FlowPanel = new FlowPanel 
            {
                Title = Player1Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            Player2FlowPanel = new FlowPanel 
            {
                Title = Player2Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            Player3FlowPanel = new FlowPanel 
            {
                Title = Player3Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player4FlowPanel = new FlowPanel 
            {
                Title = Player4Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player5FlowPanel = new FlowPanel 
            {
                Title = Player5Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player6FlowPanel = new FlowPanel 
            {
                Title = Player6Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player7FlowPanel = new FlowPanel 
            {
                Title = Player7Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player8FlowPanel = new FlowPanel 
            {
                Title = Player8Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player9FlowPanel = new FlowPanel 
            {
                Title = Player9Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight

            };
            Player10FlowPanel = new FlowPanel 
            {
                Title = Player10Name.Value,
                Size = new Point(1050,150),
                Parent = MasterFlowPanel,
                ShowBorder = true,
                CanCollapse = true,
                Collapsed = true,
                FlowDirection = ControlFlowDirection.LeftToRight
            };
            #region HoT_FlowPanels
            HoT_PlayerRolesPanel1 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player1FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel2 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player2FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel3 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player3FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel4 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player4FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel5 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player5FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel6 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player6FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel7 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player7FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel8 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player8FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles"
            };
            HoT_PlayerRolesPanel9 = new FlowPanel() 
            {
                Size = new Point(510,150),
                Parent = Player9FlowPanel,
                ShowBorder = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                Title = "HoT Roles",
            };
            HoT_PlayerRolesPanel10 = new FlowPanel() 
            {
                Size = new Point(510,150),
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
        }

        protected override async Task LoadAsync()
        //Label Dimensions(width, height): (100, 25)
        //HoT Panel Dimensions(width, height): (510, 100)
        //PoF Panel Dimensions(width, height): (510, 75)
        {
            //Initialize Windows Here first, Then initialize panels, then labels and checkboxes
            #region Box and Label Arrays
            RolestoRandomizeSelectionCheckboxesArray = new Checkbox[22];
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
                {8,"Slothosaur Mushrroms"},
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
            for (int i = 0; i < 22; i++)
            {
                RolestoRandomizeSelectionCheckboxesArray[i] = new Checkbox
                {
                    Text = "Randomize " + RandomizeSelectionBoxesInt_to_StringDictionary[i],
                    Location = new Point(),
                    BasicTooltipText = "Check this box to include " + RandomizeSelectionBoxesInt_to_StringDictionary[i] + " in the randomization",
                    Parent = RandomizeCheckboxesPanel,
                    Checked = true
                };
            }

            //Make dropdown lists with int options 1-3 to apply to both Pylon and Lamp. Then make one that is 1-5 to apply to pillars.
            //Greens: Dropdown for 1-2 (tank always takes one green, and one person is dedicated green, but may want to randomize a second dedicated and let kiter do their thing alone
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

            TestingCornerIcon = new CornerIcon
            {
                Icon = ContentsManager.GetTexture("Emblem.png"),
                BasicTooltipText = "Click for debugging functions"
            };
            TestingCornerIcon.Click += delegate
            {
                MasterFlowPanel.BackgroundColor = Color.Red;
                MasterFlowPanel.Size = new Point(1000, 400);
                MasterFlowPanel.ClipsBounds = false;
                MasterFlowPanel.Location = new Point(0, 300);
                RandomizeCheckboxesPanel.Location = new Point(0, 180);
                RandomizeCheckboxesPanel.Size = new Point(1000, 120);
                RandomizeCheckboxesPanel.BackgroundColor = Color.Blue;
                PlayerNameTextBoxPanel.BackgroundColor = Color.Green;
                PlayerNameTextBoxPanel.Size = new Point(400 , 165);


            };
        }
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
            GenerateRoles.RandomizeTheRoles();
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
            // Unload here

            // All static members must be manually unset
        }
    }

    public class GenerateRoles
    {
        public static List<Action> GenerationFunctions;
        public static List<SettingEntry<bool>[]> Rolestoberandomized;
        public static List<int> Length_of_Roles_Arrays;
        public static List<string> GenerationSequence;

        public static void RandomizeTheRoles()
        { //RandomizeHandKite,RandomizeOilKite,RandomizeFlakKite,RandomizeTank,RandomizeHealAlac,RandomizeHealQuick,RandomizeDPSAlac,RandomizeDPSQuick,RandomizeMushroom,
          //RandomizeTower,RandomizeReflect,RandomizeCannon,RandomizeConstrucPusher,RandomizeLamp,RandomizePylon,RandomizePillar,RandomizeGreen,RandomizeSoullessPusher,
          //RandomizeDhuumKite,RandomizeQadimKite,RandomizeSword,RandomizeShield
            Rolestoberandomized = new List<SettingEntry<bool>[]>();
            GenerationSequence = new List<string>();
            GenerationFunctions = new List<Action>();
            IDictionary<Checkbox, SettingEntry<bool>[]> ActiveRolesDictionary = new Dictionary<Checkbox, SettingEntry<bool>[]>() 
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
            IDictionary<List<string>, string> ValidRoleLists_to_FriendlyNamesDictionary = new Dictionary<List<string>, string>() 
            {
                {RoleRandomizerMain.HealValid, "Heal" },
                {RoleRandomizerMain.DPSValid, "DPS"},
                {RoleRandomizerMain.HandKiteValid, "HandKite"},
                {RoleRandomizerMain.OilKiteValid, "OilKite"},
                {RoleRandomizerMain.FlakKiteValid, "FlakKite"},
                {RoleRandomizerMain.TankValid, "Tank"},
                {RoleRandomizerMain.HealAlacValid, "HealAlac"},
                {RoleRandomizerMain.HealQuickValid, "HealQuick"},
                {RoleRandomizerMain.DPSAlacValid, "DPSAlac"},
                {RoleRandomizerMain.DPSQuickValid, "DPSQuick"},
                {RoleRandomizerMain.MushroomValid, "Mushroom"},
                {RoleRandomizerMain.TowerValid, "Tower"},
                {RoleRandomizerMain.ReflectValid, "Reflect"},
                {RoleRandomizerMain.CannonValid, "Cannon"},
                {RoleRandomizerMain.ConstrucPusherValid, "ConstrucPusher"},
                {RoleRandomizerMain.LampValid, "Lamp"},
                {RoleRandomizerMain.PylonValid, "Pylon"},
                {RoleRandomizerMain.PillarValid, "Pillar"},
                {RoleRandomizerMain.GreenValid, "Green"},
                {RoleRandomizerMain.SoullessPusherValid, "SoullessPusher"},
                {RoleRandomizerMain.DhuumKiteValid, "DhuumKite"},
                {RoleRandomizerMain.QadimKiteValid, "QadimKite"},
                {RoleRandomizerMain.SwordValid, "Sword"},
                {RoleRandomizerMain.ShieldValid, "Shield"},
            };
            IDictionary<string, Action> FriendlyNames_to_ActionsDictionary = new Dictionary<string, Action>() 
            {
                {"Heal" , () =>GenerateHealers()},
                //{"DPS", () =>Generate},
                {"HandKite", () =>GenerateHandKite()},
                {"OilKite", () =>GenerateOilKite()},
                {"FlakKite", () =>GenerateFlakKite()},
                {"Tank", () =>GenerateTank()},
                //{"HealAlac", () =>Generate},
                //{"HealQuick", () =>Generate},
                {"DPSAlac", () =>GenerateAlacrity()},
                {"DPSQuick", () =>GenerateQuickness()},
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

            for (int i = 0; i < 22; i++)
            {
                if (RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[i].Checked)
                {
                    var tempkey = RoleRandomizerMain.RolestoRandomizeSelectionCheckboxesArray[i];
                    var temprole = ActiveRolesDictionary[tempkey];
                    for (int s = 0; s < 10; s++)
                    {
                        if (temprole[s].Value)
                        {
                            Rolestoberandomized.Add(temprole);
                            Debug.WriteLine("Adding " + temprole[s].EntryKey + "to roles to be randomized");
                        }
                    }
                }
            }

            foreach (var item in Rolestoberandomized)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (item[i].Value)
                    {
                        RoleRandomizerMain.ListofRoleValidLists[RolesArrays_to_ArrayListPosDictionary[item]].Add(ArrayPos_to_PlayerNameDictionary[i]);
                    };
                }
            }
            IEnumerable<List<string>> SortedList = RoleRandomizerMain.ListofRoleValidLists.OrderBy(x => x.Count);  //sorts the populated lists by length
            foreach (var item in SortedList)
            {
                if (item.Count != 0)
                {
                    GenerationSequence.Add(ValidRoleLists_to_FriendlyNamesDictionary[item]); //converts the current (role)valid list into a string name for the role to be generated and adds to the sequence, from shortest lists to longest.
                }
            }
            foreach (var item in GenerationSequence)
            {
                GenerationFunctions.Add(FriendlyNames_to_ActionsDictionary[item]);
            }




            //Check list rolestoberandomized to decide which checks to make
            //Then check their lengths/run sanity checking to determine which order to generate in
            //Then add them to GenerationFunctions Action List in the order that they need to be generated
            foreach (var item in GenerationFunctions) //Takes the final sequence that gets loaded into the actions list and invokes each of them in order. This step must come last!
            {
                item.Invoke();
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
        public static void GenerateHealers() 
        {
            Debug.WriteLine("Generating Healers");
        }
        public static void GenerateAlacrity() 
        {
            Debug.WriteLine("Generating Alac");
        }
        public static void GenerateQuickness() 
        {
            Debug.WriteLine("Generating Quickness");
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
    public class CustomCheckbox : Checkbox 
    {
        private readonly SettingEntry<bool> _settingEntry;

        public CustomCheckbox(SettingEntry<bool> settingsEntry)
        {
            _settingEntry = settingsEntry;
            Debug.WriteLine("Initialized as: " + _settingEntry.Value);
        }
        protected override void OnCheckedChanged(CheckChangedEvent e)
        {
            _settingEntry.Value = Checked;
            Debug.WriteLine("Changing value of " + _settingEntry.EntryKey + "to: " + _settingEntry.Value.ToString());
            Debug.WriteLine(_settingEntry.Value.ToString());
            base.OnCheckedChanged(e);
        }
    }
}

