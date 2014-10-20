using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using TP_Map_Editor_PR_POB.Controller;

namespace TP_Map_Editor_PR_POB
{
    [Serializable]
    class EnemySpawner: TileObject
    {
        [Category("Option")]
        [Description("Le nombre d'ennemie qui apparaitra")]
        [DisplayName("Nombre d'ennemie")]
        public int maxEnemy { get; set; }

        [Category("Option")]
        [Description("Le temps en seconde entre chaque apparition d'ennemie")]
        [DisplayName("Temps d'apparition")]
        public int spawningtime { get; set; }

        [Category("Option")]
        [Description("Le type d'ennemy qui apparaitra")]
        [DisplayName("Ennemie")]
        public EnemyType enemy { get; set; }

        [Category("Option")]
        [Description("La direction que l'ennemie prendra lorsqu'il apparait")]
        [DisplayName("Direction")]
        public Direction direction { get; set; }

        public EnemySpawner()
        {
            this.type = TileTypes.EnemySpawner;
            this.path = "../../Resource/spawner.gif";
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
            get { return "../../Resource/spawner.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[5][];

            properties[0] = new string[1];
            properties[0][0] = "EnemySpawner";

            properties[1] = new string[2];
            properties[1][0] = "MaxEnemy";
            properties[1][1] = maxEnemy.ToString();

            properties[2] = new string[2];
            properties[2][0] = "SpawningTime";
            properties[2][1] = spawningtime.ToString();

            properties[3] = new string[2];
            properties[3][0] = "Enemy";
            properties[3][1] = enemy.ToString();

            properties[4] = new string[2];
            properties[4][0] = "Direction";
            properties[4][1] = direction.ToString();

            return properties;
        }

        public override bool ValidateObject(Tile haut, Tile bas)
        {
            return false;
        }

        public override Tile DeepCopy()
        {
            EnemySpawner tile = (EnemySpawner)this.MemberwiseClone();
            //tile.maxEnemy = this.maxEnemy;
            //tile.spawningtime = this.spawningtime;
            //tile.enemy = this.enemy;
            //tile.direction = this.direction;

            return tile;
        }
    }
}
