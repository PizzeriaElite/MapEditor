using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TP_Map_Editor_PR_POB.Controller;

namespace TP_Map_Editor_PR_POB
{
    class Empty: Tile
    {
        public Empty()
        {
            this.type = TileTypes.Empty;
            this.path = "../../Resource/empty.gif";
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
            get { return "../../Resource/empty.gif"; }
        }

        public override bool Validate(Tile haut, Tile bas)
        {
            return true;
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[1][];

            properties[0] = new string[1];
            properties[0][0] = "Empty";

            return properties;
        }

        public override Tile DeepCopy()
        {
            return new Empty();
        }
    }
}
