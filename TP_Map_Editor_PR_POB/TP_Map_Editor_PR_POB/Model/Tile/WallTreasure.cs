using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Map_Editor_PR_POB.Controller;
using System.Drawing;
using System.ComponentModel;

namespace TP_Map_Editor_PR_POB
{
    /// <summary>
    /// Mur Avec un trésor à l'intérieur
    /// </summary>
    class WallTreasure:Tile
    {
        [Category("Option")]
        [Description("Le type de Trésor contenue dans le mur")]
        [DisplayName("Trésor")]
        public TreasureType treasure { get; set; }

        public WallTreasure()
        {
            this.type = TileTypes.WallTreasure;
            this.path = "../../Resource/treasureWall.gif";
        }

        static public Bitmap image
        {
            get
            {
                Bitmap bitmap = new Bitmap(PathImage);
                return bitmap;
            }
        }

        static public string PathImage
        {
            get { return "../../Resource/treasureWall.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            properties[0] = new string[1];
            properties[0][0] = "WallTreasure";

            properties[1] = new string[2];
            properties[1][0] = "Treasure";
            properties[1][1] = treasure.ToString();

            return properties;
        }

        public override bool Validate(Tile haut, Tile bas)
        {
            return true;
        }

        public override Tile DeepCopy()
        {
            WallTreasure tile = new WallTreasure();
            tile.treasure = this.treasure;

            return tile;
        }
    }
}
