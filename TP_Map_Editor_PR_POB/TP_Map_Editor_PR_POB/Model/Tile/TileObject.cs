using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TP_Map_Editor_PR_POB
{
    [Serializable]
    abstract class TileObject: Tile
    {

        public TileObject()
        {

        }

        abstract public override string[][] GetProperties();

        public override bool Validate(Tile haut, Tile bas)
        {
            if(bas is Wall || bas is WallTreasure || bas == null || ValidateObject(haut, bas))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// validationn spécifique d'une tuile 
        /// </summary>
        /// <param name="haut">la tuile au dessus</param>
        /// <param name="bas">la tuile en dessous</param>
        /// <returns>true si valide sinon false</returns>
        abstract public bool ValidateObject(Tile haut, Tile bas);

        abstract public override Tile DeepCopy();
    }
}
