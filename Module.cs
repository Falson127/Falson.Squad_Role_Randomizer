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

namespace Falson.Squad_Role_Randomizer
{
    [Export(typeof(Blish_HUD.Modules.Module))]
    public class RoleRandomizerMain : Blish_HUD.Modules.Module
    {
        public static StandardWindow RandomizerResultsWindow;
        public static StandardWindow RandomizerSettingsWindow;
        public static List<string> TankValid;
        public static List<string> HealValid;
        public static List<string> DPSAlacValid;
        public static List<string> DPSQuickValid;
        public static List<string> HealAlacValid;
        public static List<string> HealQuickValid;
        public static List<string> DPSValid;
        public static List<string> CannonValid;
        public static List<string> HandKiteValid;
        public static List<string> OilKiteValid;
        public static List<string> FlakKiteValid;
        public static List<string> TowerMesmerValid;
        public static List<string> ReflectValid;
        public static List<string> player1roles;
        public static List<string> player2roles;
        public static List<string> player3roles;
        public static List<string> player4roles;
        public static List<string> player5roles;
        public static List<string> player6roles;
        public static List<string> player7roles;
        public static List<string> player8roles;
        public static List<string> player9roles;
        public static List<string> player10roles;
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
        public List<List<string>> SelectedRolesToRandomize;
        public TextBox Player1Name;
        public TextBox Player2Name;
        public TextBox Player3Name;
        public TextBox Player4Name;
        public TextBox Player5Name;
        public TextBox Player6Name;
        public TextBox Player7Name;
        public TextBox Player8Name;
        public TextBox Player9Name;
        public TextBox Player10Name;
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
        //Roles Per Pannel: HoT: 13
        //Dimensions 5, 5, 3
        //Roles Per Pannel: PoF: 9
        //Dimensions 5, 4
        #region Define Checkboxes
        public Checkbox HandKitePlayer1;
        public Checkbox OilKitePlayer1;
        public Checkbox FlakKitePlayer1;
        public Checkbox TankPlayer1;
        public Checkbox HealAlacPlayer1;
        public Checkbox HealQuickPlayer1;
        public Checkbox DPSAlacPlayer1;
        public Checkbox DPSQuickPlayer1;
        public Checkbox MushroomPlayer1;
        public Checkbox TowerPlayer1;
        public Checkbox ReflectPlayer1;
        public Checkbox CannonPlayer1;
        public Checkbox LampPlayer1;
        public Checkbox PylonPlayer1;
        public Checkbox PillarPlayer1;
        public Checkbox GreenPlayer1;
        public Checkbox SoullessPusherPlayer1;
        public Checkbox ConstrucPusherPlayer1;
        public Checkbox DhuumKitePlayer1;
        public Checkbox QadimKitePlayer1;
        public Checkbox SwordPlayer1;
        public Checkbox ShieldPlayer1;
        public Checkbox HandKitePlayer2;
        public Checkbox OilKitePlayer2;
        public Checkbox FlakKitePlayer2;
        public Checkbox TankPlayer2;
        public Checkbox HealAlacPlayer2;
        public Checkbox HealQuickPlayer2;
        public Checkbox DPSAlacPlayer2;
        public Checkbox DPSQuickPlayer2;
        public Checkbox MushroomPlayer2;
        public Checkbox TowerPlayer2;
        public Checkbox ReflectPlayer2;
        public Checkbox CannonPlayer2;
        public Checkbox LampPlayer2;
        public Checkbox PylonPlayer2;
        public Checkbox PillarPlayer2;
        public Checkbox GreenPlayer2;
        public Checkbox SoullessPusherPlayer2;
        public Checkbox ConstrucPusherPlayer2;
        public Checkbox DhuumKitePlayer2;
        public Checkbox QadimKitePlayer2;
        public Checkbox SwordPlayer2;
        public Checkbox ShieldPlayer2;
        public Checkbox HandKitePlayer3;
        public Checkbox OilKitePlayer3;
        public Checkbox FlakKitePlayer3;
        public Checkbox TankPlayer3;
        public Checkbox HealAlacPlayer3;
        public Checkbox HealQuickPlayer3;
        public Checkbox DPSAlacPlayer3;
        public Checkbox DPSQuickPlayer3;
        public Checkbox MushroomPlayer3;
        public Checkbox TowerPlayer3;
        public Checkbox ReflectPlayer3;
        public Checkbox CannonPlayer3;
        public Checkbox LampPlayer3;
        public Checkbox PylonPlayer3;
        public Checkbox PillarPlayer3;
        public Checkbox GreenPlayer3;
        public Checkbox SoullessPusherPlayer3;
        public Checkbox ConstrucPusherPlayer3;
        public Checkbox DhuumKitePlayer3;
        public Checkbox QadimKitePlayer3;
        public Checkbox SwordPlayer3;
        public Checkbox ShieldPlayer3;
        public Checkbox HandKitePlayer4;
        public Checkbox OilKitePlayer4;
        public Checkbox FlakKitePlayer4;
        public Checkbox TankPlayer4;
        public Checkbox HealAlacPlayer4;
        public Checkbox HealQuickPlayer4;
        public Checkbox DPSAlacPlayer4;
        public Checkbox DPSQuickPlayer4;
        public Checkbox MushroomPlayer4;
        public Checkbox TowerPlayer4;
        public Checkbox ReflectPlayer4;
        public Checkbox CannonPlayer4;
        public Checkbox LampPlayer4;
        public Checkbox PylonPlayer4;
        public Checkbox PillarPlayer4;
        public Checkbox GreenPlayer4;
        public Checkbox SoullessPusherPlayer4;
        public Checkbox ConstrucPusherPlayer4;
        public Checkbox DhuumKitePlayer4;
        public Checkbox QadimKitePlayer4;
        public Checkbox SwordPlayer4;
        public Checkbox ShieldPlayer4;
        public Checkbox HandKitePlayer5;
        public Checkbox OilKitePlayer5;
        public Checkbox FlakKitePlayer5;
        public Checkbox TankPlayer5;
        public Checkbox HealAlacPlayer5;
        public Checkbox HealQuickPlayer5;
        public Checkbox DPSAlacPlayer5;
        public Checkbox DPSQuickPlayer5;
        public Checkbox MushroomPlayer5;
        public Checkbox TowerPlayer5;
        public Checkbox ReflectPlayer5;
        public Checkbox CannonPlayer5;
        public Checkbox LampPlayer5;
        public Checkbox PylonPlayer5;
        public Checkbox PillarPlayer5;
        public Checkbox GreenPlayer5;
        public Checkbox SoullessPusherPlayer5;
        public Checkbox ConstrucPusherPlayer5;
        public Checkbox DhuumKitePlayer5;
        public Checkbox QadimKitePlayer5;
        public Checkbox SwordPlayer5;
        public Checkbox ShieldPlayer5;
        public Checkbox HandKitePlayer6;
        public Checkbox OilKitePlayer6;
        public Checkbox FlakKitePlayer6;
        public Checkbox TankPlayer6;
        public Checkbox HealAlacPlayer6;
        public Checkbox HealQuickPlayer6;
        public Checkbox DPSAlacPlayer6;
        public Checkbox DPSQuickPlayer6;
        public Checkbox MushroomPlayer6;
        public Checkbox TowerPlayer6;
        public Checkbox ReflectPlayer6;
        public Checkbox CannonPlayer6;
        public Checkbox LampPlayer6;
        public Checkbox PylonPlayer6;
        public Checkbox PillarPlayer6;
        public Checkbox GreenPlayer6;
        public Checkbox SoullessPusherPlayer6;
        public Checkbox ConstrucPusherPlayer6;
        public Checkbox DhuumKitePlayer6;
        public Checkbox QadimKitePlayer6;
        public Checkbox SwordPlayer6;
        public Checkbox ShieldPlayer6;
        public Checkbox HandKitePlayer7;
        public Checkbox OilKitePlayer7;
        public Checkbox FlakKitePlayer7;
        public Checkbox TankPlayer7;
        public Checkbox HealAlacPlayer7;
        public Checkbox HealQuickPlayer7;
        public Checkbox DPSAlacPlayer7;
        public Checkbox DPSQuickPlayer7;
        public Checkbox MushroomPlayer7;
        public Checkbox TowerPlayer7;
        public Checkbox ReflectPlayer7;
        public Checkbox CannonPlayer7;
        public Checkbox LampPlayer7;
        public Checkbox PylonPlayer7;
        public Checkbox PillarPlayer7;
        public Checkbox GreenPlayer7;
        public Checkbox SoullessPusherPlayer7;
        public Checkbox ConstrucPusherPlayer7;
        public Checkbox DhuumKitePlayer7;
        public Checkbox QadimKitePlayer7;
        public Checkbox SwordPlayer7;
        public Checkbox ShieldPlayer7;
        public Checkbox HandKitePlayer8;
        public Checkbox OilKitePlayer8;
        public Checkbox FlakKitePlayer8;
        public Checkbox TankPlayer8;
        public Checkbox HealAlacPlayer8;
        public Checkbox HealQuickPlayer8;
        public Checkbox DPSAlacPlayer8;
        public Checkbox DPSQuickPlayer8;
        public Checkbox MushroomPlayer8;
        public Checkbox TowerPlayer8;
        public Checkbox ReflectPlayer8;
        public Checkbox CannonPlayer8;
        public Checkbox LampPlayer8;
        public Checkbox PylonPlayer8;
        public Checkbox PillarPlayer8;
        public Checkbox GreenPlayer8;
        public Checkbox SoullessPusherPlayer8;
        public Checkbox ConstrucPusherPlayer8;
        public Checkbox DhuumKitePlayer8;
        public Checkbox QadimKitePlayer8;
        public Checkbox SwordPlayer8;
        public Checkbox ShieldPlayer8;
        public Checkbox HandKitePlayer9;
        public Checkbox OilKitePlayer9;
        public Checkbox FlakKitePlayer9;
        public Checkbox TankPlayer9;
        public Checkbox HealAlacPlayer9;
        public Checkbox HealQuickPlayer9;
        public Checkbox DPSAlacPlayer9;
        public Checkbox DPSQuickPlayer9;
        public Checkbox MushroomPlayer9;
        public Checkbox TowerPlayer9;
        public Checkbox ReflectPlayer9;
        public Checkbox CannonPlayer9;
        public Checkbox LampPlayer9;
        public Checkbox PylonPlayer9;
        public Checkbox PillarPlayer9;
        public Checkbox GreenPlayer9;
        public Checkbox SoullessPusherPlayer9;
        public Checkbox ConstrucPusherPlayer9;
        public Checkbox DhuumKitePlayer9;
        public Checkbox QadimKitePlayer9;
        public Checkbox SwordPlayer9;
        public Checkbox ShieldPlayer9;
        public Checkbox HandKitePlayer10;
        public Checkbox OilKitePlayer10;
        public Checkbox FlakKitePlayer10;
        public Checkbox TankPlayer10;
        public Checkbox HealAlacPlayer10;
        public Checkbox HealQuickPlayer10;
        public Checkbox DPSAlacPlayer10;
        public Checkbox DPSQuickPlayer10;
        public Checkbox MushroomPlayer10;
        public Checkbox TowerPlayer10;
        public Checkbox ReflectPlayer10;
        public Checkbox CannonPlayer10;
        public Checkbox LampPlayer10;
        public Checkbox PylonPlayer10;
        public Checkbox PillarPlayer10;
        public Checkbox GreenPlayer10;
        public Checkbox SoullessPusherPlayer10;
        public Checkbox ConstrucPusherPlayer10;
        public Checkbox DhuumKitePlayer10;
        public Checkbox QadimKitePlayer10;
        public Checkbox SwordPlayer10;
        public Checkbox ShieldPlayer10;
        #endregion
        #region Define Checkbox Labels
        public Label HandkiteLabel1;
        public Label OilKiteLabel1;
        public Label FlakKiteLabel1;
        public Label TankLabel1;
        public Label HealAlacLabel1;
        public Label HealQuickLabel1;
        public Label DPSAlacLabel1;
        public Label DPSQuickLabel1;
        public Label MushroomLabel1;
        public Label CannonLabel1;
        public Label ConstructPusherLabel1;
        public Label TowerLabel1;
        public Label ReflectLabel1;
        public Label LampLabel1;
        public Label SoullessHorrorPusherLabel1;
        public Label DhuumKiteLabel1;
        public Label PylonLabel1;
        public Label PillarLabel1;
        public Label QadimKiteLabel1;
        public Label SwordLabel1;
        public Label ShieldLabel1;
        public Label GreenLabel1;
        public Label HandkiteLabel2;
        public Label OilKiteLabel2;
        public Label FlakKiteLabel2;
        public Label TankLabel2;
        public Label HealAlacLabel2;
        public Label HealQuickLabel2;
        public Label DPSAlacLabel2;
        public Label DPSQuickLabel2;
        public Label MushroomLabel2;
        public Label CannonLabel2;
        public Label ConstructPusherLabel2;
        public Label TowerLabel2;
        public Label ReflectLabel2;
        public Label LampLabel2;
        public Label SoullessHorrorPusherLabel2;
        public Label DhuumKiteLabel2;
        public Label PylonLabel2;
        public Label PillarLabel2;
        public Label QadimKiteLabel2;
        public Label SwordLabel2;
        public Label ShieldLabel2;
        public Label GreenLabel2;
        public Label HandkiteLabel3;
        public Label OilKiteLabel3;
        public Label FlakKiteLabel3;
        public Label TankLabel3;
        public Label HealAlacLabel3;
        public Label HealQuickLabel3;
        public Label DPSAlacLabel3;
        public Label DPSQuickLabel3;
        public Label MushroomLabel3;
        public Label CannonLabel3;
        public Label ConstructPusherLabel3;
        public Label TowerLabel3;
        public Label ReflectLabel3;
        public Label LampLabel3;
        public Label SoullessHorrorPusherLabel3;
        public Label DhuumKiteLabel3;
        public Label PylonLabel3;
        public Label PillarLabel3;
        public Label QadimKiteLabel3;
        public Label SwordLabel3;
        public Label ShieldLabel3;
        public Label GreenLabel3;
        public Label HandkiteLabel4;
        public Label OilKiteLabel4;
        public Label FlakKiteLabel4;
        public Label TankLabel4;
        public Label HealAlacLabel4;
        public Label HealQuickLabel4;
        public Label DPSAlacLabel4;
        public Label DPSQuickLabel4;
        public Label MushroomLabel4;
        public Label CannonLabel4;
        public Label ConstructPusherLabel4;
        public Label TowerLabel4;
        public Label ReflectLabel4;
        public Label LampLabel4;
        public Label SoullessHorrorPusherLabel4;
        public Label DhuumKiteLabel4;
        public Label PylonLabel4;
        public Label PillarLabel4;
        public Label QadimKiteLabel4;
        public Label SwordLabel4;
        public Label ShieldLabel4;
        public Label GreenLabel4;
        public Label HandkiteLabel5;
        public Label OilKiteLabel5;
        public Label FlakKiteLabel5;
        public Label TankLabel5;
        public Label HealAlacLabel5;
        public Label HealQuickLabel5;
        public Label DPSAlacLabel5;
        public Label DPSQuickLabel5;
        public Label MushroomLabel5;
        public Label CannonLabel5;
        public Label ConstructPusherLabel5;
        public Label TowerLabel5;
        public Label ReflectLabel5;
        public Label LampLabel5;
        public Label SoullessHorrorPusherLabel5;
        public Label DhuumKiteLabel5;
        public Label PylonLabel5;
        public Label PillarLabel5;
        public Label QadimKiteLabel5;
        public Label SwordLabel5;
        public Label ShieldLabel5;
        public Label GreenLabel5;
        public Label HandkiteLabel6;
        public Label OilKiteLabel6;
        public Label FlakKiteLabel6;
        public Label TankLabel6;
        public Label HealAlacLabel6;
        public Label HealQuickLabel6;
        public Label DPSAlacLabel6;
        public Label DPSQuickLabel6;
        public Label MushroomLabel6;
        public Label CannonLabel6;
        public Label ConstructPusherLabel6;
        public Label TowerLabel6;
        public Label ReflectLabel6;
        public Label LampLabel6;
        public Label SoullessHorrorPusherLabel6;
        public Label DhuumKiteLabel6;
        public Label PylonLabel6;
        public Label PillarLabel6;
        public Label QadimKiteLabel6;
        public Label SwordLabel6;
        public Label ShieldLabel6;
        public Label GreenLabel6;
        public Label HandkiteLabel7;
        public Label OilKiteLabel7;
        public Label FlakKiteLabel7;
        public Label TankLabel7;
        public Label HealAlacLabel7;
        public Label HealQuickLabel7;
        public Label DPSAlacLabel7;
        public Label DPSQuickLabel7;
        public Label MushroomLabel7;
        public Label CannonLabel7;
        public Label ConstructPusherLabel7;
        public Label TowerLabel7;
        public Label ReflectLabel7;
        public Label LampLabel7;
        public Label SoullessHorrorPusherLabel7;
        public Label DhuumKiteLabel7;
        public Label PylonLabel7;
        public Label PillarLabel7;
        public Label QadimKiteLabel7;
        public Label SwordLabel7;
        public Label ShieldLabel7;
        public Label GreenLabel7;
        public Label HandkiteLabel8;
        public Label OilKiteLabel8;
        public Label FlakKiteLabel8;
        public Label TankLabel8;
        public Label HealAlacLabel8;
        public Label HealQuickLabel8;
        public Label DPSAlacLabel8;
        public Label DPSQuickLabel8;
        public Label MushroomLabel8;
        public Label CannonLabel8;
        public Label ConstructPusherLabel8;
        public Label TowerLabel8;
        public Label ReflectLabel8;
        public Label LampLabel8;
        public Label SoullessHorrorPusherLabel8;
        public Label DhuumKiteLabel8;
        public Label PylonLabel8;
        public Label PillarLabel8;
        public Label QadimKiteLabel8;
        public Label SwordLabel8;
        public Label ShieldLabel8;
        public Label GreenLabel8;
        public Label HandkiteLabel9;
        public Label OilKiteLabel9;
        public Label FlakKiteLabel9;
        public Label TankLabel9;
        public Label HealAlacLabel9;
        public Label HealQuickLabel9;
        public Label DPSAlacLabel9;
        public Label DPSQuickLabel9;
        public Label MushroomLabel9;
        public Label CannonLabel9;
        public Label ConstructPusherLabel9;
        public Label TowerLabel9;
        public Label ReflectLabel9;
        public Label LampLabel9;
        public Label SoullessHorrorPusherLabel9;
        public Label DhuumKiteLabel9;
        public Label PylonLabel9;
        public Label PillarLabel9;
        public Label QadimKiteLabel9;
        public Label SwordLabel9;
        public Label ShieldLabel9;
        public Label GreenLabel9;
        public Label HandkiteLabel10;
        public Label OilKiteLabel10;
        public Label FlakKiteLabel10;
        public Label TankLabel10;
        public Label HealAlacLabel10;
        public Label HealQuickLabel10;
        public Label DPSAlacLabel10;
        public Label DPSQuickLabel10;
        public Label MushroomLabel10;
        public Label CannonLabel10;
        public Label ConstructPusherLabel10;
        public Label TowerLabel10;
        public Label ReflectLabel10;
        public Label LampLabel10;
        public Label SoullessHorrorPusherLabel10;
        public Label DhuumKiteLabel10;
        public Label PylonLabel10;
        public Label PillarLabel10;
        public Label QadimKiteLabel10;
        public Label SwordLabel10;
        public Label ShieldLabel10;
        public Label GreenLabel10;
        #endregion




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

        }

        protected override void Initialize()
        {

        }

        protected override async Task LoadAsync()
        //Label Dimensions(width, height): (100, 25)
        //HoT Panel Dimensions(width, height): (510, 100)
        //PoF Panel Dimensions(width, height): (510, 75)
        {
            //Initialize Windows Here first, Then initialize panels, then labels and checkboxes
            #region HoT_FlowPanels
            HoT_PlayerRolesPanel1 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel2 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel3 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel4 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel5 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel6 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel7 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel8 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            HoT_PlayerRolesPanel9 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true,
            };
            HoT_PlayerRolesPanel10 = new FlowPanel() 
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            #endregion
            #region PoF_FlowPanels


            #endregion
            #region Checkbox Labels

            #endregion
            #region Checkboxes
            HandKitePlayer1 = new Checkbox { };
            HandKitePlayer2 = new Checkbox { };
            HandKitePlayer3 = new Checkbox { };
            HandKitePlayer4 = new Checkbox { };
            HandKitePlayer5 = new Checkbox { };
            HandKitePlayer6 = new Checkbox { };
            HandKitePlayer7 = new Checkbox { };
            HandKitePlayer8 = new Checkbox { };
            HandKitePlayer9 = new Checkbox { };
            HandKitePlayer10 = new Checkbox { };
            OilKitePlayer1 = new Checkbox { };
            OilKitePlayer2 = new Checkbox { };
            OilKitePlayer3 = new Checkbox { };
            OilKitePlayer4 = new Checkbox { };
            OilKitePlayer5 = new Checkbox { };
            OilKitePlayer6 = new Checkbox { };
            OilKitePlayer7 = new Checkbox { };
            OilKitePlayer8 = new Checkbox { };
            OilKitePlayer9= new Checkbox { };
            OilKitePlayer10 = new Checkbox { };
            FlakKitePlayer1 = new Checkbox { };
            FlakKitePlayer2 = new Checkbox { };
            FlakKitePlayer3 = new Checkbox { };
            FlakKitePlayer4 = new Checkbox { };
            FlakKitePlayer5 = new Checkbox { };
            FlakKitePlayer6 = new Checkbox { };
            FlakKitePlayer7 = new Checkbox { };
            FlakKitePlayer8 = new Checkbox { };
            FlakKitePlayer9 = new Checkbox { };
            FlakKitePlayer10 = new Checkbox { };
            TankPlayer1 = new Checkbox { };
            TankPlayer2 = new Checkbox { };
            TankPlayer3 = new Checkbox { };
            TankPlayer4 = new Checkbox { };
            TankPlayer5 = new Checkbox { };
            TankPlayer6 = new Checkbox { };
            TankPlayer7 = new Checkbox { };
            TankPlayer8 = new Checkbox { };
            TankPlayer9 = new Checkbox { };
            TankPlayer10 = new Checkbox { };
            HealAlacPlayer1 = new Checkbox { };
            HealAlacPlayer2 = new Checkbox { };
            HealAlacPlayer3 = new Checkbox { };
            HealAlacPlayer4 = new Checkbox { };
            HealAlacPlayer5 = new Checkbox { };
            HealAlacPlayer6 = new Checkbox { };
            HealAlacPlayer7 = new Checkbox { };
            HealAlacPlayer8 = new Checkbox { };
            HealAlacPlayer9 = new Checkbox { };
            HealAlacPlayer10 = new Checkbox { };

            HealQuickPlayer1 = new Checkbox { };
            HealQuickPlayer2 = new Checkbox { };
            HealQuickPlayer3 = new Checkbox { };
            HealQuickPlayer4 = new Checkbox { };
            HealQuickPlayer5 = new Checkbox { };
            HealQuickPlayer6 = new Checkbox { };
            HealQuickPlayer7 = new Checkbox { };
            HealQuickPlayer8 = new Checkbox { };
            HealQuickPlayer9 = new Checkbox { };
            HealQuickPlayer10 = new Checkbox { };

            DPSAlacPlayer1 = new Checkbox { };
            DPSAlacPlayer2 = new Checkbox { };
            DPSAlacPlayer3 = new Checkbox { };
            DPSAlacPlayer4 = new Checkbox { };
            DPSAlacPlayer5 = new Checkbox { };
            DPSAlacPlayer6 = new Checkbox { };
            DPSAlacPlayer7 = new Checkbox { };
            DPSAlacPlayer8 = new Checkbox { };
            DPSAlacPlayer9 = new Checkbox { };
            DPSAlacPlayer10 = new Checkbox { };

            DPSQuickPlayer1 = new Checkbox { };
            DPSQuickPlayer2 = new Checkbox { };
            DPSQuickPlayer3 = new Checkbox { };
            DPSQuickPlayer4 = new Checkbox { };
            DPSQuickPlayer5 = new Checkbox { };
            DPSQuickPlayer6 = new Checkbox { };
            DPSQuickPlayer7 = new Checkbox { };
            DPSQuickPlayer8 = new Checkbox { };
            DPSQuickPlayer9 = new Checkbox { };
            DPSQuickPlayer10 = new Checkbox { };

            MushroomPlayer1 = new Checkbox { };
            MushroomPlayer2 = new Checkbox { };
            MushroomPlayer3 = new Checkbox { };
            MushroomPlayer4 = new Checkbox { };
            MushroomPlayer5 = new Checkbox { };
            MushroomPlayer6 = new Checkbox { };
            MushroomPlayer7 = new Checkbox { };
            MushroomPlayer8 = new Checkbox { };
            MushroomPlayer9 = new Checkbox { };
            MushroomPlayer10 = new Checkbox { };

            TowerPlayer1 = new Checkbox { };
            TowerPlayer2 = new Checkbox { };
            TowerPlayer3 = new Checkbox { };
            TowerPlayer4 = new Checkbox { };
            TowerPlayer5 = new Checkbox { };
            TowerPlayer6 = new Checkbox { };
            TowerPlayer7 = new Checkbox { };
            TowerPlayer8 = new Checkbox { };
            TowerPlayer9 = new Checkbox { };
            TowerPlayer10 = new Checkbox { };

            ReflectPlayer1 = new Checkbox { };
            ReflectPlayer2 = new Checkbox { };
            ReflectPlayer3 = new Checkbox { };
            ReflectPlayer4 = new Checkbox { };
            ReflectPlayer5 = new Checkbox { };
            ReflectPlayer6 = new Checkbox { };
            ReflectPlayer7 = new Checkbox { };
            ReflectPlayer8 = new Checkbox { };
            ReflectPlayer9 = new Checkbox { };
            ReflectPlayer10 = new Checkbox { };

            CannonPlayer1 = new Checkbox { };
            CannonPlayer2 = new Checkbox { };
            CannonPlayer3 = new Checkbox { };
            CannonPlayer4 = new Checkbox { };
            CannonPlayer5 = new Checkbox { };
            CannonPlayer6 = new Checkbox { };
            CannonPlayer7 = new Checkbox { };
            CannonPlayer8 = new Checkbox { };
            CannonPlayer9 = new Checkbox { };
            CannonPlayer10 = new Checkbox { };

            LampPlayer1 = new Checkbox { };
            LampPlayer2 = new Checkbox { };
            LampPlayer3 = new Checkbox { };
            LampPlayer4 = new Checkbox { };
            LampPlayer5 = new Checkbox { };
            LampPlayer6 = new Checkbox { };
            LampPlayer7 = new Checkbox { };
            LampPlayer8 = new Checkbox { };
            LampPlayer9 = new Checkbox { };
            LampPlayer10 = new Checkbox { };

            PylonPlayer1 = new Checkbox { };
            PylonPlayer2 = new Checkbox { };
            PylonPlayer3 = new Checkbox { };
            PylonPlayer4 = new Checkbox { };
            PylonPlayer5 = new Checkbox { };
            PylonPlayer6 = new Checkbox { };
            PylonPlayer7 = new Checkbox { };
            PylonPlayer8 = new Checkbox { };
            PylonPlayer9 = new Checkbox { };
            PylonPlayer10 = new Checkbox { };

            PillarPlayer1 = new Checkbox { };
            PillarPlayer2 = new Checkbox { };
            PillarPlayer3 = new Checkbox { };
            PillarPlayer4 = new Checkbox { };
            PillarPlayer5 = new Checkbox { };
            PillarPlayer6 = new Checkbox { };
            PillarPlayer7 = new Checkbox { };
            PillarPlayer8 = new Checkbox { };
            PillarPlayer9 = new Checkbox { };
            PillarPlayer10 = new Checkbox { };

            GreenPlayer1 = new Checkbox { };
            GreenPlayer2 = new Checkbox { };
            GreenPlayer3 = new Checkbox { };
            GreenPlayer4 = new Checkbox { };
            GreenPlayer5 = new Checkbox { };
            GreenPlayer6 = new Checkbox { };
            GreenPlayer7 = new Checkbox { };
            GreenPlayer8 = new Checkbox { };
            GreenPlayer9 = new Checkbox { };
            GreenPlayer10 = new Checkbox { };

            SoullessPusherPlayer1 = new Checkbox { };
            SoullessPusherPlayer2 = new Checkbox { };
            SoullessPusherPlayer3 = new Checkbox { };
            SoullessPusherPlayer4 = new Checkbox { };
            SoullessPusherPlayer5 = new Checkbox { };
            SoullessPusherPlayer6 = new Checkbox { };
            SoullessPusherPlayer7 = new Checkbox { };
            SoullessPusherPlayer8 = new Checkbox { };
            SoullessPusherPlayer9 = new Checkbox { };
            SoullessPusherPlayer10 = new Checkbox { };

            ConstrucPusherPlayer1 = new Checkbox { };
            ConstrucPusherPlayer2 = new Checkbox { };
            ConstrucPusherPlayer3 = new Checkbox { };
            ConstrucPusherPlayer4 = new Checkbox { };
            ConstrucPusherPlayer5 = new Checkbox { };
            ConstrucPusherPlayer6 = new Checkbox { };
            ConstrucPusherPlayer7 = new Checkbox { };
            ConstrucPusherPlayer8 = new Checkbox { };
            ConstrucPusherPlayer9 = new Checkbox { };
            ConstrucPusherPlayer10 = new Checkbox { };

            DhuumKitePlayer1 = new Checkbox { };
            DhuumKitePlayer2 = new Checkbox { };
            DhuumKitePlayer3 = new Checkbox { };
            DhuumKitePlayer4 = new Checkbox { };
            DhuumKitePlayer5 = new Checkbox { };
            DhuumKitePlayer6 = new Checkbox { };
            DhuumKitePlayer7 = new Checkbox { };
            DhuumKitePlayer8 = new Checkbox { };
            DhuumKitePlayer9 = new Checkbox { };
            DhuumKitePlayer10 = new Checkbox { };

            QadimKitePlayer1 = new Checkbox { };
            QadimKitePlayer2 = new Checkbox { };
            QadimKitePlayer3 = new Checkbox { };
            QadimKitePlayer4 = new Checkbox { };
            QadimKitePlayer5 = new Checkbox { };
            QadimKitePlayer6 = new Checkbox { };
            QadimKitePlayer7 = new Checkbox { };
            QadimKitePlayer8 = new Checkbox { };
            QadimKitePlayer9 = new Checkbox { };
            QadimKitePlayer10 = new Checkbox { };

            SwordPlayer1 = new Checkbox { };
            SwordPlayer2 = new Checkbox { };
            SwordPlayer3 = new Checkbox { };
            SwordPlayer4 = new Checkbox { };
            SwordPlayer5 = new Checkbox { };
            SwordPlayer6 = new Checkbox { };
            SwordPlayer7 = new Checkbox { };
            SwordPlayer8 = new Checkbox { };
            SwordPlayer9 = new Checkbox { };
            SwordPlayer10 = new Checkbox { };

            ShieldPlayer1 = new Checkbox { };
            ShieldPlayer2 = new Checkbox { };
            ShieldPlayer3 = new Checkbox { };
            ShieldPlayer4 = new Checkbox { };
            ShieldPlayer5 = new Checkbox { };
            ShieldPlayer6 = new Checkbox { };
            ShieldPlayer7 = new Checkbox { };
            ShieldPlayer8 = new Checkbox { };
            ShieldPlayer9 = new Checkbox { };
            ShieldPlayer10 = new Checkbox { };
            #endregion
        }

        protected override void OnModuleLoaded(EventArgs e)
        {

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
        public void GenerateTank() 
        {
        
        }
        public void GenerateHealers() 
        {
        
        }
        public void GenerateHandKite() 
        {
        
        }
        public void GenerateOilKite() 
        {
        
        }
        public void GenerateFlakKite() 
        {
        
        }
        public void GenerateQuickDPS() 
        {
        
        }
        public void GenerateAlacDPS() 
        {
    
        }
    }
}
