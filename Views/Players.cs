using Blish_HUD.Controls;
using Blish_HUD.Graphics.UI;
using Blish_HUD.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SharpDX.MediaFoundation;
using System.Windows.Forms.VisualStyles;
using Falson.SquadRoleRandomizer.Randomizer_Utils;
using System.Runtime.CompilerServices;

namespace Falson.SquadRoleRandomizer.Views
{
    public class Players : View
    {
        private readonly string _base64string;
        private readonly FalsonSettings _deserializedSettings;
        public Checkbox[] PlayerDisableBoxes;
        private bool _buildComplete = new bool();
        private TaskCompletionSource<bool> _buildCompleteTCS = new TaskCompletionSource<bool>();

        public Players(string base64SettingsString) 
        {
            _base64string = base64SettingsString;
            SettingsEncoder localEncoder = new SettingsEncoder(_base64string);
            _deserializedSettings = localEncoder.GetSettings();
            PlayerDisableBoxes = new Checkbox[10];

            
        }

        protected override void Build(Container buildPanel)
        {
            _buildComplete = false;
            for (int i = 0; i < 10; i++)
            {
                int xpos;
                int ypos;
                if (i < 5)
                {
                    xpos = 0;
                    ypos = (i * 25);
                }
                else
                {
                    xpos = 150;
                    ypos = (25 * (i - 5));
                }
                PlayerDisableBoxes[i] = new Checkbox
                {
                    Text = $"Disable {_deserializedSettings._playerNames[i]}",
                    BasicTooltipText = $"Check this box to prevent {_deserializedSettings._playerNames[i]} from being included in the randomization",
                    Checked = false,
                    Parent = buildPanel,
                    Location = new Point(xpos, ypos)
                };
                //var j = i;
                //PlayerDisableBoxes[j].CheckedChanged += delegate
                //{
                //    _playersToInclude[j] = !_playerDisableBoxes[j].Checked;
                //};
            }
            base.Build(buildPanel);
            _buildComplete = true;
            _buildCompleteTCS.SetResult(true);
        }
        public async Task WaitForBuildComplete() 
        {
            await _buildCompleteTCS.Task;
        }
    }


}
