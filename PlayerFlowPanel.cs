using Blish_HUD.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace Falson.SquadRoleRandomizer
{
    public class PlayerPanel : Blish_HUD.Controls.Panel
    {
        public PlayerPanel(string playerName, Container parent)
        {
            Title = playerName;
            Size = new Point(1050, 150);
            Parent = parent;
            ShowBorder = true;
            CanCollapse= true;
            Collapsed= true;
        }   
    }
}
