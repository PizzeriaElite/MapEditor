using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TP_Map_Editor_PR_POB
{
    public enum EnnemyType
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

    class Ennemy: TileObject
    {
        private EnnemyType ennemy = EnnemyType.Random;
        private Direction direction = Direction.Random;

        public Ennemy(int x, int y)
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
            get { return "../../Resource/enemy.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[2][];

            string[] strEnum = Enum.GetNames(typeof(EnnemyType));
            properties[0] = new string[1 + strEnum.Length];
            properties[0][0] = "Type";
            strEnum.CopyTo(properties[0], 1);

            strEnum = Enum.GetNames(typeof(Direction));
            properties[1] = new string[1 + strEnum.Length];
            properties[1][0] = "Direction";
            strEnum.CopyTo(properties[1], 1);

            return properties;
        }

        public override bool ValidateObject()
        {
            return false;
        }
    }
}
