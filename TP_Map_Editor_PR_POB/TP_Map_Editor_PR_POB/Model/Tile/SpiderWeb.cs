﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TP_Map_Editor_PR_POB.Controller;

namespace TP_Map_Editor_PR_POB
{
    class SpiderWeb: TileObject
    {

        public SpiderWeb()
        {
            this.type = TileTypes.SpiderWeb;
            this.path = "../../Resource/web.gif";
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
            get { return "../../Resource/web.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[1][];

            properties[0] = new string[1];
            properties[0][0] = "Web";

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            return new SpiderWeb();
        }
    }
}
