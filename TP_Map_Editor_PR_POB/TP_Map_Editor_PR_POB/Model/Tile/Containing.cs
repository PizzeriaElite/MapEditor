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
    enum ContainingType
    {
        Crate,
        Vase,
        Random
    }

    enum Contain
    {
        Treasure,
        Enemy,
        Utilitie,
        None,
        Random
    }

    class Containing: TileObject
    {
        [Category("Option")]
        [Description("Le type de contenant")]
        [DisplayName("Contenant")]
        public  ContainingType containingType { get; set; }

        private Contain contain;

        [Category("Contenue")]
        [Description("L'objet contenue")]
        [DisplayName("Objet")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TileObject containObject { get; set; }

        public Containing()
        {
            containObject = new Treasure();
            this.type = TileTypes.Containing;
            this.path = "../../Resource/containing.gif";
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
            get { return "../../Resource/containing.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[3][];

            properties[0] = new string[1];
            properties[0][0] = "Containing";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = containingType.ToString();

            properties[2] = new string[2];
            properties[2][0] = "Contain";
            properties[2][1] = contain.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        [Category("Option")]
        [Description("Le type d'objet que le contenant contient")]
        [DisplayName("Contenue")]
        public Contain Contain
        {
            get
            {
                return contain;
            }
            set
            {
                contain = value;
                if(contain == Contain.Treasure)
                {
                    containObject = new Treasure();
                }
                else if(contain == Contain.Enemy)
                {
                    containObject = new Enemy();
                }
                else if(contain == Contain.Utilitie)
                {
                    containObject = new Utilities();
                }
                else
                {
                    containObject = null;
                }
            }
        }

        public override Tile DeepCopy()
        {
            Containing tile = new Containing();
            tile.containingType = this.containingType;
            tile.contain = this.contain;
            tile.containObject = (TileObject)this.containObject.DeepCopy();

            return tile;
        }
    }
}
