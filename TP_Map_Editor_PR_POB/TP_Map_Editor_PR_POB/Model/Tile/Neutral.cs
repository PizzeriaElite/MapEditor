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
    public enum TypeNeutral
    {
        Stone,
        Skull
    }

    class Neutral: TileObject
    {
        [Category("Option")]
        [Description("Le type d'élément neutre")]
        [DisplayName("Type")]
        public TypeNeutral typeNeutral { get; set; }

        public Neutral()
        {
            this.type = TileTypes.Neutral;
            this.path = "../../Resource/neutral.gif";
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
            get { return "../../Resource/neutral.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            properties[0] = new string[1];
            properties[0][0] = "Neutral";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = typeNeutral.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            Neutral tile = new Neutral();
            tile.typeNeutral = this.typeNeutral;

            return tile;
        }
    }
}
