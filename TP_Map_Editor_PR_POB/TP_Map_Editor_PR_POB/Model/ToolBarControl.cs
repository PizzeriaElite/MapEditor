using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Map_Editor_PR_POB.Controller 
{
    public enum TileTypes { Actor, Chest, Containing, Empty, Enemy, EnemySpawner, Spawn, Exit, Ladder, Movable, Neutral, SelectMode, SpiderWeb, Trap, Treasure, Utilities, Wall, WallTreasure };

    public class ToolBarControl : PictureBox
    {
        public TileTypes AssociatedTileType { get; set; }

        public ToolBarControl(TileTypes type)
        {
            this.AssociatedTileType = type;
        }
    }
}
