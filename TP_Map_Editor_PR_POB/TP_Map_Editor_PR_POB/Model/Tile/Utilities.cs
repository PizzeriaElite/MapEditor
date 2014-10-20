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
    public enum UtilType
    {
        Rope,
        Bomb,
        Random
    }

    /// <summary>
    /// Tous les objets pouvant etre utilisés par le joueur
    /// </summary>
    class Utilities: TileObject
    {
        [Category("Option")]
        [Description("Le type d'utilitaires")]
        [DisplayName("Utilitaires")]
        public UtilType typeUtil { get; set; }

        public Utilities()
        {
            this.type = TileTypes.Utilities;
            this.path = "../../Resource/utilitie.gif";
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
            get { return "../../Resource/utilitie.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            properties[0] = new string[1];
            properties[0][0] = "Utilitie";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = typeUtil.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            Utilities tile = new Utilities();
            tile.typeUtil = this.typeUtil;

            return tile;
        }

    }
}
