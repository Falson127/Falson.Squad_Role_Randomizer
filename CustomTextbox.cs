﻿using Blish_HUD.Controls;
using Blish_HUD.Settings;
using Microsoft.Xna.Framework;
using System;
using System.Windows.Forms;
using System.Windows.Controls;

namespace Falson.SquadRoleRandomizer
{
    public class CustomTextbox : Blish_HUD.Controls.TextBox
    {
        private readonly SettingEntry<string> _settingEntry;
        private readonly PlayerFlowPanel _flowPanel;
        public CustomTextbox(SettingEntry<string> playerName, PlayerFlowPanel linkedPanel,Container parent,Point location) 
        {
            PlaceholderText = playerName.Value;
            Size = new Point(200, 25);
            Parent = parent;
            Location = location;
            _settingEntry = playerName;
            _flowPanel= linkedPanel;
        }
        protected virtual void OnTextChanged(EventArgs) 
        {
            if (this.Text == "")
                {
                    this.Text = "Enter Player Name...";
                }
                _flowPanel.Title = this.Text;
                _settingEntry.Value = this.Text;
        }

        //protected override void TextChanged(EventArgs e) 
        //{
        //    if (this.Text == "")
        //    {
        //        this.Text = "Enter Player Name...";
        //    }
        //    _flowPanel.Title = this.Text;
        //    _settingEntry.Value = this.Text;
        //}
    }
}
