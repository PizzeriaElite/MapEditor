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

    enum LadderType
    {
        Middle,
        Top,
        Bottom
    }

    class Ladder: TileObject
    {


        [Category("Option")]
        [Description("Le type de d'échelle")]
        [DisplayName("Échelle")]
        public LadderType typeLadder
        {
            get;
            set;
        }

        public Ladder()
        {
            this.type = TileTypes.Ladder;
            this.path = "../../Resource/ladder.gif";
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
            get { return "../../Resource/ladder.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            properties[0] = new string[1];
            properties[0][0] = "Ladder";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = typeLadder.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            if(haut is Ladder || haut is Empty || haut == null)
            {
                if(bas is Ladder || bas is Wall || bas is WallTreasure || bas == null)
                {
                    return true;
                }
            }
            return false;
        }

        public override Tile DeepCopy()
        {
            Ladder tile = new Ladder();
            tile.typeLadder = this.typeLadder;

            return tile;
        }
    }

}
