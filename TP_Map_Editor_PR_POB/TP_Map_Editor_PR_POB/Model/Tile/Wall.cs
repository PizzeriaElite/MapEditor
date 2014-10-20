using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using TP_Map_Editor_PR_POB.Controller;
using System.ComponentModel;

namespace TP_Map_Editor_PR_POB
{
    enum WallType
    {
        Destructible,
        Indestructible
    }

    /// <summary>
    /// Mur de base soit destructible ou indestructible
    /// </summary>
    class Wall: Tile
    {
        [Category("Option")]
        [Description("Le type de mur")]
        [DisplayName("Mur")]
        public WallType typeWall { get; set; }

        public Wall()
        {
            this.type = TileTypes.Wall;
            this.path = "../../Resource/wall.gif";
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
            get { return "../../Resource/wall.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            properties[0] = new string[1];
            properties[0][0] = "Wall";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = typeWall.ToString();

            return properties;
        }

        public override bool Validate(Tile haut, Tile bas)
        {
            return true;
        }

        public override Tile DeepCopy()
        {
            Wall tile = new Wall();
            tile.typeWall = this.typeWall;

            return tile;
        }
    }
}
