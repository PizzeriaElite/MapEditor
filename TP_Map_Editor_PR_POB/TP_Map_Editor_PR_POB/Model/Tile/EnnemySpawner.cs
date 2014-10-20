using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TP_Map_Editor_PR_POB
{
    class EnnemySpawner:TileObject
    {
        private int maxEnnemy = 0;
        private int spawningtime = 60;
        private EnnemyType ennemy = EnnemyType.Random;
        private Direction direction = Direction.Random;
        

        public EnnemySpawner(int x, int y)
            : base(x, y)
        {
           
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
            string[][] properties = new string[4][];

            string[] strEnum = Enum.GetNames(typeof(EnnemyType));
            properties[0] = new string[1 + strEnum.Length];
            properties[0][0] = "Type ennemies";
            strEnum.CopyTo(properties[0], 1);

            strEnum = Enum.GetNames(typeof(Direction));
            properties[1] = new string[1 + strEnum.Length];
            properties[1][0] = "Direction";
            strEnum.CopyTo(properties[1], 1);

            properties[2] = new string[1];
            properties[2][0] = "Maximun d'ennemies";

            properties[3] = new string[1];
            properties[3][0] = "Temps de réaparition";

            return properties;
        }

        public override bool ValidateObject()
        {
            return false;
        }
    }
}
