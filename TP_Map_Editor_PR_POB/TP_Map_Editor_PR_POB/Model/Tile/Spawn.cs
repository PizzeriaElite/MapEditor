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
    class Spawn: TileObject
    {
        public Spawn()
        {
            this.type = TileTypes.Spawn;
            this.path = "../../Resource/spawn.gif";
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
            get { return "../../Resource/spawn.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[1][];

            properties[0] = new string[1];
            properties[0][0] = "Spawn";

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            return new Spawn();
        }
    }
}
