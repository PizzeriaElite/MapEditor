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
    enum TrapType
    {
        Arrow,
        Spike
    }

    enum Orientation
    {
        Left,
        Right,
        Up,
        Down
    }

    /// <summary>
    /// Un piège
    /// </summary>
    class Trap:TileObject
    {
        [Category("Option")]
        [Description("Le type de piège")]
        [DisplayName("Piège")]
        public TrapType trap { get; set; }

        [Category("Option")]
        [Description("L'orientation du piège")]
        [DisplayName("Orientation")]
        public Orientation orientation { get; set; }

        public Trap()
        {
            this.type = TileTypes.Trap;
            this.path = "../../Resource/trap.gif";
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
            get { return "../../Resource/trap.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[3][];

            properties[0] = new string[1];
            properties[0][0] = "Trap";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = trap.ToString();

            properties[2] = new string[2];
            properties[2][0] = "Orientation";
            properties[2][1] = orientation.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            Trap tile = new Trap();
            tile.trap = this.trap;
            tile.orientation = this.orientation;

            return tile;
        }
    }
}
