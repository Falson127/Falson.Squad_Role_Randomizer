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
        private StandardWindow _randomizerResultsWindow;
        private StandardWindow _randomizerSettingsWindow;
        private CornerIcon _randomizerSettingIcon;
        private SettingCollection InternalPlayerRolesSettings;
        private SettingEntry<string>[] _base64strings = new SettingEntry<string>[3]; //allow up to 3 statics
        private List<SettingEntry<bool>[]> _listofRolesSettings;
        public static FlowPanel ResultsFlowPanel;
        private int NumberOfAttempts = 0;



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
            for (int i = 0; i < 3; i++)
            {
                _base64strings[i] = InternalPlayerRolesSettings.DefineSetting($"base64string {i + 1}", "default");
            }
        }


      
    

        protected override async Task LoadAsync()
        {
            _randomizerSettingsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Randomization Settings",
                Subtitle = "Define Roles to Randomize",
                Parent = GameService.Graphics.SpriteScreen,
                Size = new Point(1050, 800),
                SavesPosition = true,
                Id = "Falson.RoleRandomizer.SettingsWindow",
                Emblem = ContentsManager.GetTexture("Emblem.png")
            };
            _randomizerResultsWindow = new StandardWindow(ContentsManager.GetTexture("155985.png"), new Rectangle(40, 26, 913, 691), new Rectangle(70, 71, 839, 605))
            {
                Title = "Results",
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
                Parent = _randomizerResultsWindow,
                FlowDirection = ControlFlowDirection.SingleTopToBottom,
                HeightSizingMode = SizingMode.AutoSize,
                WidthSizingMode = SizingMode.AutoSize,
                CanScroll = true
            };
            #region ListsOf: Box Arrays, Role Arrays, and Valid Lists
            //ListofCheckboxArrays = new List<CustomCheckbox[]> {_handKiteBoxArray,_oilKiteBoxArray,_flakKiteBoxArray,_tankBoxArray,_healAlacBoxArray,_healQuickBoxArray,_dpsAlacBoxArray,_dpsQuickBoxArray,_mushroomBoxArray,_towerBoxArray,_reflectBoxArray,_cannonBoxArray,_construcPusherBoxArray,_lampBoxArray,_pylonBoxArray,_pillarBoxArray,_greenBoxArray,_soullessPusherBoxArray,_dhuumKiteBoxArray,_qadimKiteBoxArray,_swordBoxArray,_shieldBoxArray };
            //_listofRolesSettings = new List<SettingEntry<bool>[]> {_handKiteRoles,_oilKiteRoles,_flakKiteRoles,_tankRoles,_healAlacRoles,_healQuickRoles,_dpsAlacRoles,_dpsQuickRoles,_mushroomRoles,_towerRoles,_reflectRoles,_cannonRoles,_construcPusherRoles,_lampRoles,_pylonRoles,_pillarRoles,_greenRoles,_soullessPusherRoles,_dhuumKiteRoles,_qadimKiteRoles,_swordRoles,_shieldRoles };
            #endregion
        }
        protected override void OnModuleLoaded(EventArgs e)
        {
            _randomizerSettingIcon = new CornerIcon 
            {
                Icon = ContentsManager.GetTexture("Emblem.png"),
                BasicTooltipText = "Click to open settings window"
            };
            _randomizerSettingIcon.Click += _randomizerSettingIcon_Click;

            // Base handler must be called
            base.OnModuleLoaded(e);
        }
        private void _randomizerSettingIcon_Click(object sender, Blish_HUD.Input.MouseEventArgs e)
        {
            _randomizerSettingsWindow.ToggleWindow();
        }



        protected override void Update(GameTime gameTime)
        {

        }

        /// <inheritdoc />
        protected override void Unload()
        {
            #region Disposables
            _randomizerSettingIcon?.Dispose();
            _randomizerResultsWindow?.Dispose();
            _randomizerSettingsWindow?.Dispose();
            ResultsFlowPanel?.Dispose();
            #endregion
            ResultsFlowPanel = null;
            #region Events
            _randomizerSettingIcon.Click -= _randomizerSettingIcon_Click;
            #endregion
        }
    }
}

