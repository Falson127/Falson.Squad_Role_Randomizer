using Blish_HUD.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Falson.SquadRoleRandomizer
{
    public class PlayerFlowPanel : FlowPanel 
    {
        public PlayerFlowPanel(string playerName, Container parent)
        {
            Title = playerName;
            Size = new Point(1050, 150);
            Parent = parent;
            ShowBorder = true;
            CanCollapse= true;
            Collapsed= true;
            FlowDirection = ControlFlowDirection.LeftToRight;
        }
    
    }
}
