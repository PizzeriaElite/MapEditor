using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TP_Map_Editor_PR_POB.Controller;

namespace TP_Map_Editor_PR_POB
{
    class Ladder: TileObject
    {

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
            string[][] properties = new string[1][];

            properties[0] = new string[1];
            properties[0][0] = "Ladder";

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
            return new Ladder();
        }
    }

}
