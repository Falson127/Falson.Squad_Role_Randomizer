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
        public List<Checkbox[]> ListofCheckboxArrays;
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
        public Checkbox[] HandKiteBoxArray;
        public Checkbox[] OilKiteBoxArray;
        public Checkbox[] FlakKiteBoxArray;
        public Checkbox[] TankBoxArray;
        public Checkbox[] HealAlacBoxArray;
        public Checkbox[] HealQuickBoxArray;
        public Checkbox[] DPSAlacBoxArray;
        public Checkbox[] DPSQuickBoxArray;
        public Checkbox[] MushroomBoxArray;
        public Checkbox[] TowerBoxArray;
        public Checkbox[] ReflectBoxArray;
        public Checkbox[] CannonBoxArray;
        public Checkbox[] ConstrucPusherBoxArray;
        public Checkbox[] LampBoxArray;
        public Checkbox[] PylonBoxArray;
        public Checkbox[] PillarBoxArray;
        public Checkbox[] GreenBoxArray;
        public Checkbox[] SoullessPusherBoxArray;
        public Checkbox[] DhuumKiteBoxArray;
        public Checkbox[] QadimKiteBoxArray;
        public Checkbox[] SwordBoxArray;
        public Checkbox[] ShieldBoxArray;
        public static Checkbox[] RolestoRandomizeSelectionCheckboxesArray;
        public Label[] HandKiteLabelArray;
        public Label[] OilKiteLabelArray;
        public Label[] FlakKiteLabelArray;
        public Label[] TankLabelArray;
        public Label[] HealAlacLabelArray;
        public Label[] HealQuickLabelArray;
        public Label[] DPSAlacLabelArray;
        public Label[] DPSQuickLabelArray;
        public Label[] MushroomLabelArray;
        public Label[] TowerLabelArray;
        public Label[] ReflectLabelArray;
        public Label[] CannonLabelArray;
        public Label[] ConstrucPusherLabelArray;
        public Label[] LampLabelArray;
        public Label[] PylonLabelArray;
        public Label[] PillarLabelArray;
        public Label[] GreenLabelArray;
        public Label[] SoullessPusherLabelArray;
        public Label[] DhuumKiteLabelArray;
        public Label[] QadimKiteLabelArray;
        public Label[] SwordLabelArray;
        public Label[] ShieldLabelArray;
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
        {   InternalPlayerRolesSettings = new SettingCollection();
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
            RandomizerSettingsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(30, 30, 700, 930), new Rectangle(50, 50, 640, 890)) 
            {
                Title = "Randomization Settings",
                Subtitle = "Define Roles to Randomize",
                Parent = GameService.Graphics.SpriteScreen
            };
            RandomizerResultsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(30, 30, 700, 930), new Rectangle(50, 50, 640, 890))
            {
                Title = "Randomized Roles",
                Parent = GameService.Graphics.SpriteScreen
            };
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
            PoF_PlayerRolesPanel1 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel2 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel3 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel4 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel5 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel6 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel7 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel8 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel9 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            PoF_PlayerRolesPanel10 = new FlowPanel()
            {
                Size = new Point(510, 100),
                Parent = RandomizerSettingsWindow,
                CanCollapse = true,
                Collapsed = true
            };
            #endregion
            #region Checkbox Labels

            #endregion
        }
        protected void CheckboxCheckedFunctions() 
        {
            //Tempcounter increments once per foreach, allowing us to cycle through the same settings bool array 10 times per item, but move to the next settings array for the next corresponding item.
            //ListofCheckboxArrays contains a list of all the arrays of checkboxes for each role. We cycle through these one item at a time to delegate their checkedchanged functions.
            //ListofRolesSettings contains the settings bool arrays that we are connecting to each checkbox. We need to cycle cycle only once per item, but cycle through each of the contained arrays 10 times to hit all settings.
            IDictionary<int,Checkbox> integer_to_CheckboxDictionary = new Dictionary<int,Checkbox> { };
            int tempcounter = 0;
            for (int s = 0; s < 22; s++)
            {
                for (int i = 0; i < 10; i++)
                {
                    ListofCheckboxArrays[s][i].CheckedChanged += delegate  //Essentially for example this would first produce | HandKiteBoxArray[i].CheckedChanged += delegate (for all 10 checkboxes)
                    {
                        ListofRolesSettings[tempcounter][i].Value = !ListofRolesSettings[tempcounter][i].Value; //Then the delegated function is to check HandKiteRoles[i].Value and invert it, where i corresponds to linked checkboxes and checkbox settings for a given role.
                    };
                }
                tempcounter++; //We then increment the tempcounter by 1 to move the ListofRolesSettings[tempcounter] output to be the next in the list and cycle through those settings arrays with their corresponding checkboxes.
            }

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
            HandKiteBoxArray = new Checkbox[10] {HandKitePlayer1, HandKitePlayer2, HandKitePlayer3, HandKitePlayer4, HandKitePlayer5, HandKitePlayer6, HandKitePlayer7, HandKitePlayer8, HandKitePlayer9, HandKitePlayer10};
            OilKiteBoxArray = new Checkbox[10] {OilKitePlayer1, OilKitePlayer2, OilKitePlayer3, OilKitePlayer4, OilKitePlayer5,OilKitePlayer6,OilKitePlayer7,OilKitePlayer8,OilKitePlayer9,OilKitePlayer10};
            FlakKiteBoxArray = new Checkbox[10] {FlakKitePlayer1,FlakKitePlayer2,FlakKitePlayer3,FlakKitePlayer4,FlakKitePlayer5,FlakKitePlayer6,FlakKitePlayer7,FlakKitePlayer8,FlakKitePlayer9,FlakKitePlayer10};
            TankBoxArray = new Checkbox[10] {TankPlayer1,TankPlayer2,TankPlayer3,TankPlayer4,TankPlayer5,TankPlayer6,TankPlayer7,TankPlayer8,TankPlayer9,TankPlayer10};
            HealAlacBoxArray = new Checkbox[10] {HealAlacPlayer1,HealAlacPlayer2,HealAlacPlayer3,HealAlacPlayer4,HealAlacPlayer5,HealAlacPlayer6,HealAlacPlayer7,HealAlacPlayer8,HealAlacPlayer9,HealAlacPlayer10};
            HealQuickBoxArray = new Checkbox[10] {HealQuickPlayer1,HealQuickPlayer2,HealQuickPlayer3,HealQuickPlayer4,HealQuickPlayer5,HealQuickPlayer6,HealQuickPlayer7,HealQuickPlayer8,HealQuickPlayer9,HealQuickPlayer10};
            DPSAlacBoxArray = new Checkbox[10] {DPSAlacPlayer1,DPSAlacPlayer2,DPSAlacPlayer3,DPSAlacPlayer4,DPSAlacPlayer5,DPSAlacPlayer6,DPSAlacPlayer7,DPSAlacPlayer8,DPSAlacPlayer9,DPSAlacPlayer10};
            DPSQuickBoxArray = new Checkbox[10] {DPSQuickPlayer1,DPSQuickPlayer2,DPSQuickPlayer3,DPSQuickPlayer4,DPSQuickPlayer5,DPSQuickPlayer6,DPSQuickPlayer7,DPSQuickPlayer8,DPSQuickPlayer9,DPSQuickPlayer10};
            MushroomBoxArray = new Checkbox[10] {MushroomPlayer1,MushroomPlayer2,MushroomPlayer3,MushroomPlayer4,MushroomPlayer5,MushroomPlayer6,MushroomPlayer7,MushroomPlayer8,MushroomPlayer9,MushroomPlayer10};
            TowerBoxArray = new Checkbox[10] {TowerPlayer1,TowerPlayer2,TowerPlayer3,TowerPlayer4,TowerPlayer5,TowerPlayer6,TowerPlayer7,TowerPlayer8,TowerPlayer9,TowerPlayer10};
            ReflectBoxArray = new Checkbox[10] {ReflectPlayer1,ReflectPlayer2,ReflectPlayer3,ReflectPlayer4,ReflectPlayer5,ReflectPlayer6,ReflectPlayer7,ReflectPlayer8,ReflectPlayer9,ReflectPlayer10};
            CannonBoxArray = new Checkbox[10] {CannonPlayer1,CannonPlayer2,CannonPlayer3,CannonPlayer4,CannonPlayer5,CannonPlayer6,CannonPlayer7,CannonPlayer8,CannonPlayer9,CannonPlayer10};
            ConstrucPusherBoxArray = new Checkbox[10] {ConstrucPusherPlayer1,ConstrucPusherPlayer2,ConstrucPusherPlayer3,ConstrucPusherPlayer4,ConstrucPusherPlayer5,ConstrucPusherPlayer6,ConstrucPusherPlayer7,ConstrucPusherPlayer8,ConstrucPusherPlayer9,ConstrucPusherPlayer10};
            LampBoxArray = new Checkbox[10] {LampPlayer1,LampPlayer2,LampPlayer3,LampPlayer4,LampPlayer5,LampPlayer6,LampPlayer7,LampPlayer8,LampPlayer9,LampPlayer10};
            PylonBoxArray = new Checkbox[10] {PylonPlayer1,PylonPlayer2,PylonPlayer3,PylonPlayer4,PylonPlayer5,PylonPlayer6,PylonPlayer7,PylonPlayer8,PylonPlayer9,PylonPlayer10};
            PillarBoxArray = new Checkbox[10] {PillarPlayer1,PillarPlayer2,PillarPlayer3,PillarPlayer4,PillarPlayer5,PillarPlayer6,PillarPlayer7,PillarPlayer8,PillarPlayer9,PillarPlayer10};
            GreenBoxArray = new Checkbox[10] {GreenPlayer1,GreenPlayer2,GreenPlayer3,GreenPlayer4,GreenPlayer5,GreenPlayer6,GreenPlayer7,GreenPlayer8,GreenPlayer9,GreenPlayer10};
            SoullessPusherBoxArray = new Checkbox[10] {SoullessPusherPlayer1,SoullessPusherPlayer2,SoullessPusherPlayer3,SoullessPusherPlayer4,SoullessPusherPlayer5,SoullessPusherPlayer6,SoullessPusherPlayer7,SoullessPusherPlayer8,SoullessPusherPlayer9,SoullessPusherPlayer10};
            DhuumKiteBoxArray = new Checkbox[10] {DhuumKitePlayer1,DhuumKitePlayer2,DhuumKitePlayer3,DhuumKitePlayer4,DhuumKitePlayer5,DhuumKitePlayer6,DhuumKitePlayer7,DhuumKitePlayer8,DhuumKitePlayer9,DhuumKitePlayer10};
            QadimKiteBoxArray = new Checkbox[10] {QadimKitePlayer1,QadimKitePlayer2,QadimKitePlayer3,QadimKitePlayer4,QadimKitePlayer5,QadimKitePlayer6,QadimKitePlayer7,QadimKitePlayer8,QadimKitePlayer9,QadimKitePlayer10};
            SwordBoxArray = new Checkbox[10] {SwordPlayer1,SwordPlayer2,SwordPlayer3,SwordPlayer4,SwordPlayer5,SwordPlayer6,SwordPlayer7,SwordPlayer8,SwordPlayer9,SwordPlayer10};
            ShieldBoxArray = new Checkbox[10] {ShieldPlayer1,ShieldPlayer2,ShieldPlayer3,ShieldPlayer4,ShieldPlayer5,ShieldPlayer6,ShieldPlayer7,ShieldPlayer8,ShieldPlayer9,ShieldPlayer10};
            HandKiteLabelArray = new Label[10] { HandkiteLabel1, HandkiteLabel2, HandkiteLabel3, HandkiteLabel4, HandkiteLabel5, HandkiteLabel6, HandkiteLabel7, HandkiteLabel8, HandkiteLabel9, HandkiteLabel10 };
            OilKiteLabelArray = new Label[10] { OilKiteLabel1, OilKiteLabel2, OilKiteLabel3, OilKiteLabel4, OilKiteLabel5, OilKiteLabel6, OilKiteLabel7, OilKiteLabel8, OilKiteLabel9, OilKiteLabel10 };
            FlakKiteLabelArray = new Label[10] { FlakKiteLabel1, FlakKiteLabel2, FlakKiteLabel3, FlakKiteLabel4, FlakKiteLabel5, FlakKiteLabel6, FlakKiteLabel7, FlakKiteLabel8, FlakKiteLabel9, FlakKiteLabel10 };
            TankLabelArray = new Label[10] { TankLabel1, TankLabel2, TankLabel3, TankLabel4, TankLabel5, TankLabel6, TankLabel7, TankLabel8, TankLabel9, TankLabel10 };
            HealAlacLabelArray = new Label[10] { HealAlacLabel1, HealAlacLabel2, HealAlacLabel3, HealAlacLabel4, HealAlacLabel5, HealAlacLabel6, HealAlacLabel7, HealAlacLabel8, HealAlacLabel9, HealAlacLabel10 };
            HealQuickLabelArray = new Label[10] { HealQuickLabel1, HealQuickLabel2, HealQuickLabel3, HealQuickLabel4, HealQuickLabel5, HealQuickLabel6, HealQuickLabel7, HealQuickLabel8, HealQuickLabel9, HealQuickLabel10 };
            DPSAlacLabelArray = new Label[10] { DPSAlacLabel1, DPSAlacLabel2, DPSAlacLabel3, DPSAlacLabel4, DPSAlacLabel5, DPSAlacLabel6, DPSAlacLabel7, DPSAlacLabel8, DPSAlacLabel9, DPSAlacLabel10 };
            DPSQuickLabelArray = new Label[10] { DPSQuickLabel1, DPSQuickLabel2, DPSQuickLabel3, DPSQuickLabel4, DPSQuickLabel5, DPSQuickLabel6, DPSQuickLabel7, DPSQuickLabel8, DPSQuickLabel9, DPSQuickLabel10 };
            MushroomLabelArray = new Label[10] { MushroomLabel1, MushroomLabel2, MushroomLabel3, MushroomLabel4, MushroomLabel5, MushroomLabel6, MushroomLabel7, MushroomLabel8, MushroomLabel9, MushroomLabel10 };
            TowerLabelArray = new Label[10] { TowerLabel1, TowerLabel2, TowerLabel3, TowerLabel4, TowerLabel5, TowerLabel6, TowerLabel7, TowerLabel8, TowerLabel9, TowerLabel10 };
            ReflectLabelArray = new Label[10] { ReflectLabel1, ReflectLabel2, ReflectLabel3, ReflectLabel4, ReflectLabel5, ReflectLabel6, ReflectLabel7, ReflectLabel8, ReflectLabel9, ReflectLabel10 };
            CannonLabelArray = new Label[10] { CannonLabel1, CannonLabel2, CannonLabel3, CannonLabel4, CannonLabel5, CannonLabel6, CannonLabel7, CannonLabel8, CannonLabel9, CannonLabel10 };
            ConstrucPusherLabelArray = new Label[10] { ConstructPusherLabel1, ConstructPusherLabel2, ConstructPusherLabel3, ConstructPusherLabel4, ConstructPusherLabel5, ConstructPusherLabel6, ConstructPusherLabel7, ConstructPusherLabel8, ConstructPusherLabel9, ConstructPusherLabel10 };
            LampLabelArray = new Label[10] { LampLabel1, LampLabel2, LampLabel3, LampLabel4, LampLabel5, LampLabel6, LampLabel7, LampLabel8, LampLabel9, LampLabel10 };
            PylonLabelArray = new Label[10] { PylonLabel1, PylonLabel2, PylonLabel3, PylonLabel4, PylonLabel5, PylonLabel6, PylonLabel7, PylonLabel8, PylonLabel9, PylonLabel10 };
            PillarLabelArray = new Label[10] { PillarLabel1, PillarLabel2, PillarLabel3, PillarLabel4, PillarLabel5, PillarLabel6, PillarLabel7, PillarLabel8, PillarLabel9, PillarLabel10 };
            GreenLabelArray = new Label[10] { GreenLabel1, GreenLabel2, GreenLabel3, GreenLabel4, GreenLabel5, GreenLabel6, GreenLabel7, GreenLabel8, GreenLabel9, GreenLabel10 };
            SoullessPusherLabelArray = new Label[10] { SoullessHorrorPusherLabel1, SoullessHorrorPusherLabel2, SoullessHorrorPusherLabel3, SoullessHorrorPusherLabel4, SoullessHorrorPusherLabel5, SoullessHorrorPusherLabel6, SoullessHorrorPusherLabel7, SoullessHorrorPusherLabel8, SoullessHorrorPusherLabel9, SoullessHorrorPusherLabel10 };
            DhuumKiteLabelArray = new Label[10] { DhuumKiteLabel1, DhuumKiteLabel2, DhuumKiteLabel3, DhuumKiteLabel4, DhuumKiteLabel5, DhuumKiteLabel6, DhuumKiteLabel7, DhuumKiteLabel8, DhuumKiteLabel9, DhuumKiteLabel10 };
            QadimKiteLabelArray = new Label[10] { QadimKiteLabel1, QadimKiteLabel2, QadimKiteLabel3, QadimKiteLabel4, QadimKiteLabel5, QadimKiteLabel6, QadimKiteLabel7, QadimKiteLabel8, QadimKiteLabel9, QadimKiteLabel10 };
            SwordLabelArray = new Label[10] { SwordLabel1, SwordLabel2, SwordLabel3, SwordLabel4, SwordLabel5, SwordLabel6, SwordLabel7, SwordLabel8, SwordLabel9, SwordLabel10 };
            ShieldLabelArray = new Label[10] { ShieldLabel1, ShieldLabel2, ShieldLabel3, ShieldLabel4, ShieldLabel5, ShieldLabel6, ShieldLabel7, ShieldLabel8, ShieldLabel9, ShieldLabel10 };
            ListofCheckboxArrays = new List<Checkbox[]> {HandKiteBoxArray,OilKiteBoxArray,FlakKiteBoxArray,TankBoxArray,HealAlacBoxArray,HealQuickBoxArray,DPSAlacBoxArray,DPSQuickBoxArray,MushroomBoxArray,TowerBoxArray,ReflectBoxArray,CannonBoxArray,ConstrucPusherBoxArray,LampBoxArray,PylonBoxArray,PillarBoxArray,GreenBoxArray,SoullessPusherBoxArray,DhuumKiteBoxArray,QadimKiteBoxArray,SwordBoxArray,ShieldBoxArray };
            ListofRolesSettings = new List<SettingEntry<bool>[]> {HandKiteRoles,OilKiteRoles,FlakKiteRoles,TankRoles,HealAlacRoles,HealQuickRoles,DPSAlacRoles,DPSQuickRoles,MushroomRoles,TowerRoles,ReflectRoles,CannonRoles,ConstrucPusherRoles,LampRoles,PylonRoles,PillarRoles,GreenRoles,SoullessPusherRoles,DhuumKiteRoles,QadimKiteRoles,SwordRoles,ShieldRoles };
            ListofRoleValidLists = new List<List<string>> { HandKiteValid,OilKiteValid,FlakKiteValid,TankValid,HealAlacValid,HealQuickValid,DPSAlacValid,DPSQuickValid,MushroomValid,TowerValid,ReflectValid,CannonValid,ConstrucPusherValid,LampValid,PylonValid,PillarValid,GreenValid,SoullessPusherValid,DhuumKiteValid,QadimKiteValid,SwordValid,ShieldValid};
            #endregion
            #region Checkboxes
            HoTPannelArray = new Panel[10] { HoT_PlayerRolesPanel1, HoT_PlayerRolesPanel2, HoT_PlayerRolesPanel3, HoT_PlayerRolesPanel4, HoT_PlayerRolesPanel5, HoT_PlayerRolesPanel6, HoT_PlayerRolesPanel7, HoT_PlayerRolesPanel8, HoT_PlayerRolesPanel9, HoT_PlayerRolesPanel10 };
            PoFPannelArray = new Panel[10] { PoF_PlayerRolesPanel1, PoF_PlayerRolesPanel2, PoF_PlayerRolesPanel3, PoF_PlayerRolesPanel4, PoF_PlayerRolesPanel5, PoF_PlayerRolesPanel6, PoF_PlayerRolesPanel7, PoF_PlayerRolesPanel8, PoF_PlayerRolesPanel9, PoF_PlayerRolesPanel10 };

            for (int i = 0; i < 10; i++)
            {
                HandKiteBoxArray[i] = new Checkbox 
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
                OilKiteBoxArray[i] = new Checkbox
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
                FlakKiteBoxArray[i] = new Checkbox 
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
                TankBoxArray[i] = new Checkbox 
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
                HealAlacBoxArray[i] = new Checkbox 
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
                HealQuickBoxArray[i] = new Checkbox 
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
                DPSAlacBoxArray[i] = new Checkbox 
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
                DPSQuickBoxArray[i] = new Checkbox 
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
                MushroomBoxArray[i] = new Checkbox 
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
                TowerBoxArray[i] = new Checkbox 
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
                ReflectBoxArray[i] = new Checkbox 
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
                CannonBoxArray[i] = new Checkbox 
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
                ConstrucPusherBoxArray[i] = new Checkbox 
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
                LampBoxArray[i] = new Checkbox 
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
                PylonBoxArray[i] = new Checkbox 
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
                PillarBoxArray[i] = new Checkbox 
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
                GreenBoxArray[i] = new Checkbox 
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
                SoullessPusherBoxArray[i] = new Checkbox 
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
                DhuumKiteBoxArray[i] = new Checkbox 
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
                QadimKiteBoxArray[i] = new Checkbox 
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
                SwordBoxArray[i] = new Checkbox 
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
                ShieldBoxArray[i] = new Checkbox 
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
                    Parent = RandomizerSettingsWindow,
                    Checked = true
                };
            }
            
            //Make dropdown lists with int options 1-3 to apply to both Pylon and Lamp. Then make one that is 1-5 to apply to pillars.
            //Greens: Dropdown for 1-2 (tank always takes one green, and one person is dedicated green, but may want to randomize a second dedicated and let kiter do their thing alone
            #endregion
        }
        protected override void OnModuleLoaded(EventArgs e)
        {
            CheckboxCheckedFunctions();
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

                Debug.WriteLine(item.ToString() + "Invoked");
            }
        }
        public static void GenerateHandKite() 
        {
        
        }
        public static void GenerateOilKite() 
        {
        
        }
        public static void GenerateFlakKite() 
        {
        
        }
        public static void GenerateTank() 
        {
        
        }
        public static void GenerateHealers() 
        {
        
        }
        public static void GenerateAlacrity() 
        {
    
        }
        public static void GenerateQuickness() 
        {
        
        }
        public static void GenerateMushroom() 
        {
            
        }
        public static void GenerateTower() 
        {
            
        }
        public static void GenerateReflect() 
        {
            
        }
        public static void GenerateCannon() 
        {
            
        }
        public static void GenerateConstrucPusher() 
        {
            
        }
        public static void GenerateLamp() 
        {
            
        }
        public static void GeneratePylon() 
        {
            
        }
        public static void GeneratePillar() 
        {
            
        }
        public static void GenerateGreen() 
        {
            
        }
        public static void GenerateSoullessPusher() 
        {
            
        }
        public static void GenerateDhuumKite() 
        {
            
        }
        public static void GenerateQadimKite() 
        {
            
        }
        public static void GenerateSword() 
        {
            
        }
        public static void GenerateShield() 
        {
            
        }
    }
}

