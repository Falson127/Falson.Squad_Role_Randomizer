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
        {

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
