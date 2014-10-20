using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml;
using TP_Map_Editor_PR_POB.Controller;

namespace TP_Map_Editor_PR_POB
{
    [Serializable]
    public abstract class Tile
    {
        public string path;
        public TileTypes type;

            protected Tile()
        {

        }

        /// <summary>
        /// obtient un tableau de string contenant les propriétés de la tuile
        /// </summary>
        /// <returns></returns>
        abstract public string[][] GetProperties();

        /// <summary>
        /// valide si la tuile est valide
        /// </summary>
        /// <param name="haut">la tuile au dessus</param>
        /// <param name="bas">la tuile en dessous</param>
        /// <returns>true si valide sinon false</returns>
        abstract public bool Validate(Tile haut, Tile bas);

        abstract public Tile DeepCopy();
    }
}
