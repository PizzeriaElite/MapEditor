using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TP_Map_Editor_PR_POB.Controller;
using System.ComponentModel;

namespace TP_Map_Editor_PR_POB
{
    class Chest: TileObject
    {
        [Category("Option")]
        [Description("Le type de Trésor contenue dans le coffre")]
        [DisplayName("Trésor")]
        public TreasureType treasure { get; set; }

        public Chest()
        {
            this.type = TileTypes.Chest;
            this.path = "../../Resource/chest.gif";
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
            get { return "../../Resource/chest.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            properties[0] = new string[1];
            properties[0][0] = "Chest";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = treasure.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            Chest tile = new Chest();
            tile.treasure = this.treasure;

            return tile;
        }
    }
}
