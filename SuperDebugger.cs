using Gw2Sharp.WebApi.V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using falson = Falson.SquadRoleRandomizer.RoleRandomizerMain;

namespace Falson.SquadRoleRandomizer
{
    public class SuperDebugger 
    {
        private static Random rand = new Random();
        private static int NumberOfAttempts = 0;
        public static void Debug() 
        {
            //Random rand = new Random();
            for (int i = 0; i<12; i++)
			{
                falson.CounterBoxesSettings[i].Value = rand.Next(0, falson.CounterBoxes[i].MaxValue);
			}
            for (int i = 0; i < 22; i++)
            {
                falson.RolesToGenerate[i].Value = rand.Next(2) == 1;
            }
            for (int i = 0; i < 10; i++)
            {
                falson.HandKiteRoles[i].Value = rand.Next(2) == 1;
                falson.OilKiteRoles[i].Value = rand.Next(2) == 1;
                falson.FlakKiteRoles[i].Value = rand.Next(2) == 1;
                falson.TankRoles[i].Value = rand.Next(2) == 1;
                falson.HealAlacRoles[i].Value = rand.Next(2) == 1;
                falson.HealQuickRoles[i].Value = rand.Next(2) == 1;
                falson.DPSAlacRoles[i].Value = rand.Next(2) == 1;
                falson.DPSQuickRoles[i].Value = rand.Next(2) == 1;
                falson.MushroomRoles[i].Value = rand.Next(2) == 1;
                falson.TowerRoles[i].Value = rand.Next(2) == 1;
                falson.ReflectRoles[i].Value = rand.Next(2) == 1;
                falson.CannonRoles[i].Value = rand.Next(2) == 1;
                falson.ConstrucPusherRoles[i].Value = rand.Next(2) == 1;
                falson.LampRoles[i].Value = rand.Next(2) == 1;
                falson.PylonRoles[i].Value = rand.Next(2) == 1;
                falson.PillarRoles[i].Value = rand.Next(2) == 1;
                falson.GreenRoles[i].Value = rand.Next(2) == 1;
                falson.SoullessPusherRoles[i].Value = rand.Next(2) == 1;
                falson.DhuumKiteRoles[i].Value = rand.Next(2) == 1;
                falson.QadimKiteRoles[i].Value = rand.Next(2) == 1;
                falson.SwordRoles[i].Value = rand.Next(2) == 1;
                falson.ShieldRoles[i].Value = rand.Next(2) == 1;
                NumberOfAttempts++;
            }
        }


    }
}
