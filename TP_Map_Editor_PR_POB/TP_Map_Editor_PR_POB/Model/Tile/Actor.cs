﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TP_Map_Editor_PR_POB.Controller;
using System.ComponentModel;

namespace TP_Map_Editor_PR_POB
{
    public enum TypeActor
    {
        Princess,
        Mice
    }

    class Actor: TileObject
    {

        [Category("Option")]
        [Description("Le type d'acteur")]
        [DisplayName("Acteur")]
        public TypeActor typeActor { get; set; }

        [Category("Option")]
        [Description("La direction que prendra l'acteur lors de son apparition")]
        [DisplayName("Direction")]
        public Direction direction { get; set; }
        public Actor()
        {
            this.type = TileTypes.Actor;
            this.path = "../../Resource/actor.gif";
        }

        static public Bitmap Image
        {
            get
            {
                Bitmap bitmap = new Bitmap(PathImage);
                return bitmap;
            }
        }

        static public string PathImage
        {
            get { return "../../Resource/actor.gif"; }
        }

        public override string[][] GetProperties()
        {
            string[][] properties = new string[3][];

            properties[0] = new string[1];
            properties[0][0] = "Actor";

            properties[1] = new string[2];
            properties[1][0] = "Type";
            properties[1][1] = typeActor.ToString();

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
            Actor tile = new Actor();
            tile.typeActor = this.typeActor;
            tile.direction = this.direction;

            return tile;
        }
    }
}
