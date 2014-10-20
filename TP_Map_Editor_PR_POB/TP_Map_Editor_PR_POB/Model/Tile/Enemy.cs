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
    public enum EnemyType
    {
        Snake,
        Bat,
        Scorpion,
        Skeleton,
        Random
    }

    public enum Direction
    {
        Right,
        Left,
        Random
    }

    class Enemy: TileObject
    {
        [Category("Option")]
        [Description("Le type d'ennemie")]
        [DisplayName("Ennemie")]
        public EnemyType enemy { get; set; }

        [Category("Option")]
        [Description("La direction que prendra l'acteur lors de son apparition")]
        [DisplayName("Direction")]
        public Direction direction { get; set; }

        public Enemy()
        {
            this.type = TileTypes.Enemy;
            this.path = "../../Resource/enemy.gif";
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
            get { return "../../Resource/enemy.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[3][];

            properties[0] = new string[1];
            properties[0][0] = "Enemy";

            properties[1] = new string[2];
            properties[1][0] = "Enemy";
            properties[1][1] = enemy.ToString();

            properties[2] = new string[2];
            properties[2][0] = "Direction";
            properties[2][1] = direction.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            Enemy tile = new Enemy();
            tile.enemy = this.enemy;
            tile.direction = this.direction;

            return tile;
        }
    }
}
