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
    class Exit: TileObject
    {
        [Category("Option")]
        [Description("Le nom du fichier XML de la prochaine pièce lorsque le joueur passe par la porte")]
        [DisplayName("Prochaine pièce")]
        public string nextMap { get; set; }

        public Exit()
        {
            this.type = TileTypes.Exit;
            this.path = "../../Resource/exit.gif";
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
            get { return "../../Resource/exit.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            properties[0] = new string[1];
            properties[0][0] = "Exit";

            properties[1] = new string[2];
            properties[1][0] = "NextMap";
            properties[1][1] = nextMap;

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            Exit tile = new Exit();
            tile.nextMap = this.nextMap;

            return tile;
        }
    }
}
