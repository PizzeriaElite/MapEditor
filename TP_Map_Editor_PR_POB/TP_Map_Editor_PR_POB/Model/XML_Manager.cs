using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace TP_Map_Editor_PR_POB
{
    class XML_Manager
    {

        /// <summary>
        /// Sauvegarde une piece dans un fichier XML
        /// </summary>
        /// <param name="stream">le stream de l'emplacement ou sauvegarder le fichier</param>
        /// <param name="tiles">Toutes les tuiles de la piece</param>
        /// <returns>true si la sauvegarde a fonctionner, sinon false</returns>
        public bool SaveMapToXml(Stream stream, Tile[][] tiles)
        {
            try
            {
                XmlDocument doc = new XmlDocument();

                XmlNode root = doc.CreateElement("Map");

                XmlAttribute attribute = doc.CreateAttribute("Width");
                attribute.Value = tiles.Length.ToString();
                root.Attributes.Append(attribute);

                attribute = doc.CreateAttribute("Height");
                attribute.Value = tiles[0].Length.ToString();
                root.Attributes.Append(attribute);

                doc.AppendChild(root);

                foreach(Tile[] row in tiles)
                {
                    foreach(Tile tile in row)
                    {
                        AddNodeTile(doc, root, tile);
                    }
                }

                doc.Save(stream);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Crée une tuile et l'ajoute a l'intérieur d'une node
        /// </summary>
        /// <param name="doc">le document XML</param>
        /// <param name="root">la node dans laquelle la tuile sera</param>
        /// <param name="tile">le tuile qui doit etre transform. en node XML</param>
        private void AddNodeTile(XmlDocument doc, XmlNode root, Tile tile)
        {
            if(tile != null)
            {
                string[][] properties = tile.GetProperties();

                XmlNode node = doc.CreateElement("Tile");
                XmlAttribute attribute = doc.CreateAttribute("Type");
                attribute.Value = properties[0][0];
                node.Attributes.Append(attribute);
                root.AppendChild(node);

                if(properties.Length > 1)
                {
                    XmlNode paramNode = doc.CreateElement("Param");
                    for(int i = 1; i < properties.Length; i++)
                    {
                        attribute = doc.CreateAttribute(properties[i][0]);
                        attribute.Value = properties[i][1];
                        paramNode.Attributes.Append(attribute);
                    }
                    node.AppendChild(paramNode);
                }
                if(tile is Containing)
                {
                    AddNodeTile(doc, node, ((Containing)tile).containObject);
                }
            }
            else
            {
                XmlNode node = doc.CreateElement("Tile");
                XmlAttribute attribute = doc.CreateAttribute("Type");
                attribute.Value = "null";
                node.Attributes.Append(attribute);
                root.AppendChild(node);
            }
        }

        /// <summary>
        /// Lit un fichier XML et crée une pièce
        /// </summary>
        /// <param name="stream">le stream du fichier à lire</param>
        /// <returns></returns>
        public Tile[][] ReadXML(Stream stream)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);

                XmlNode map = doc.SelectSingleNode("/Map");
                int width = Convert.ToInt32(map.Attributes.GetNamedItem("Width").Value);
                int height = Convert.ToInt32(map.Attributes.GetNamedItem("Height").Value);

                Tile[][] tiles = new Tile[width][];
                for(int i = 0; i < width; i++)
                {
                    tiles[i] = new Tile[height];
                }

                XmlNodeList nodeTiles = doc.SelectNodes("/Map/Tile");

                int x = 0;
                int y = 0;
                foreach(XmlNode node in nodeTiles)
                {
                    string typeTile = node.Attributes.GetNamedItem("Type").Value;

                    if(typeTile == "Actor")
                    {
                        tiles[x][y] = ReadActor(node);
                    }
                    else if(typeTile == "Chest")
                    {
                        tiles[x][y] = ReadChest(node);
                    }
                    else if(typeTile == "Containing")
                    {
                        tiles[x][y] = ReadContaining(node);
                    }
                    else if(typeTile == "Empty")
                    {
                        tiles[x][y] = ReadEmpty(node);
                    }
                    else if(typeTile == "Enemy")
                    {
                        tiles[x][y] = ReadEnemy(node);
                    }
                    else if(typeTile == "EnemySpawner")
                    {
                        tiles[x][y] = ReadEnemySpawner(node);
                    }
                    else if(typeTile == "Exit")
                    {
                        tiles[x][y] = ReadExit(node);
                    }
                    else if(typeTile == "Ladder")
                    {
                        tiles[x][y] = ReadLadder(node);
                    }
                    else if(typeTile == "Movable")
                    {
                        tiles[x][y] = ReadMovable(node);
                    }
                    else if(typeTile == "Neutral")
                    {
                        tiles[x][y] = ReadNeutral(node);
                    }
                    else if(typeTile == "Web")
                    {
                        tiles[x][y] = ReadWeb(node);
                    }
                    else if(typeTile == "Trap")
                    {
                        tiles[x][y] = ReadTrap(node);
                    }
                    else if(typeTile == "Treasure")
                    {
                        tiles[x][y] = ReadTreasure(node);
                    }
                    else if(typeTile == "Utilitie")
                    {
                        tiles[x][y] = ReadUtilitie(node);
                    }
                    else if(typeTile == "Wall")
                    {
                        tiles[x][y] = ReadWall(node);
                    }
                    else if(typeTile == "Spawn")
                    {
                        tiles[x][y] = ReadSpawn(node);
                    }
                    else if(typeTile == "null")
                    {
                        tiles[x][y] = null;
                    }

                    y++;
                    if(y >= height)
                    {
                        y = 0;
                        x++;
                    }
                }
                return tiles;
            }
            catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Crée une tuile avec les bonne valeur de paramtre selon le xml
        /// </summary>
        /// <param name="node">la node XML qui doit etre transformer en tuile</param>
        /// <returns>la tuile qui est créé</returns>

        private Tile ReadActor(XmlNode node)
        {
            Actor tile = new Actor();

            tile.typeActor = (TypeActor)Enum.Parse(typeof(TypeActor), node.FirstChild.Attributes.GetNamedItem("Type").Value);
            tile.direction = (Direction)Enum.Parse(typeof(Direction), node.FirstChild.Attributes.GetNamedItem("Direction").Value);

            return tile;
        }

        private Tile ReadChest(XmlNode node)
        {
            Chest tile = new Chest();

            tile.treasure = (TreasureType)Enum.Parse(typeof(TreasureType), node.FirstChild.Attributes.GetNamedItem("Type").Value);

            return tile;
        }

        private Tile ReadContaining(XmlNode node)
        {
            Containing tile = new Containing();

            tile.containingType = (ContainingType)Enum.Parse(typeof(ContainingType), node.FirstChild.Attributes.GetNamedItem("Type").Value);
            tile.Contain = (Contain)Enum.Parse(typeof(Contain), node.FirstChild.Attributes.GetNamedItem("Contain").Value);

            XmlNode containNode = node.SelectSingleNode("Tile");
            if(tile.Contain == Contain.Enemy)
            {
                tile.containObject = (TileObject)ReadEnemy(containNode);
            }
            else if(tile.Contain == Contain.Treasure)
            {
                tile.containObject = (TileObject)ReadTreasure(containNode);
            }
            else if(tile.Contain == Contain.Utilitie)
            {
                tile.containObject = (TileObject)ReadUtilitie(containNode);
            }
            else
            {
                tile.containObject = null;
            }

            return tile;
        }

        private Tile ReadEmpty(XmlNode node)
        {
            return new Empty();
        }

        private Tile ReadEnemy(XmlNode node)
        {
            Enemy tile = new Enemy();

            tile.enemy = (EnemyType)Enum.Parse(typeof(EnemyType), node.FirstChild.Attributes.GetNamedItem("Enemy").Value);
            tile.direction = (Direction)Enum.Parse(typeof(Direction), node.FirstChild.Attributes.GetNamedItem("Direction").Value);

            return tile;
        }

        private Tile ReadEnemySpawner(XmlNode node)
        {
            EnemySpawner tile = new EnemySpawner();

            tile.enemy = (EnemyType)Enum.Parse(typeof(EnemyType), node.FirstChild.Attributes.GetNamedItem("Enemy").Value);
            tile.direction = (Direction)Enum.Parse(typeof(Direction), node.FirstChild.Attributes.GetNamedItem("Direction").Value);
            tile.maxEnemy = Convert.ToInt32(node.FirstChild.Attributes.GetNamedItem("MaxEnemy").Value);
            tile.spawningtime = Convert.ToInt32(node.FirstChild.Attributes.GetNamedItem("SpawningTime").Value);

            return tile;
        }

        private Tile ReadExit(XmlNode node)
        {
            Exit tile = new Exit();

            tile.nextMap = node.FirstChild.Attributes.GetNamedItem("NextMap").Value;

            return tile;
        }

        private Tile ReadLadder(XmlNode node)
        {
            return new Ladder();
        }

        private Tile ReadSpawn(XmlNode node)
        {
            return new Spawn();
        }

        private Tile ReadMovable(XmlNode node)
        {
            return new Movable();
        }

        private Tile ReadNeutral(XmlNode node)
        {
            Neutral tile = new Neutral();

            tile.typeNeutral = (TypeNeutral)Enum.Parse(typeof(TypeNeutral), node.FirstChild.Attributes.GetNamedItem("Type").Value);

            return tile;
        }

        private Tile ReadWeb(XmlNode node)
        {
            return new SpiderWeb();
        }

        private Tile ReadTrap(XmlNode node)
        {
            Trap tile = new Trap();

            tile.trap = (TrapType)Enum.Parse(typeof(TrapType), node.FirstChild.Attributes.GetNamedItem("Type").Value);
            tile.orientation = (Orientation)Enum.Parse(typeof(Orientation), node.FirstChild.Attributes.GetNamedItem("Orientation").Value);

            return tile;
        }

        private Tile ReadTreasure(XmlNode node)
        {
            Treasure tile = new Treasure();

            tile.treasure = (TreasureType)Enum.Parse(typeof(TreasureType), node.FirstChild.Attributes.GetNamedItem("Type").Value);

            return tile;
        }

        private Tile ReadUtilitie(XmlNode node)
        {
            Utilities tile = new Utilities();

            tile.typeUtil = (UtilType)Enum.Parse(typeof(UtilType), node.FirstChild.Attributes.GetNamedItem("Type").Value);

            return tile;
        }

        private Tile ReadWall(XmlNode node)
        {
            Wall tile = new Wall();

            tile.typeWall = (WallType)Enum.Parse(typeof(WallType), node.FirstChild.Attributes.GetNamedItem("Type").Value);

            return tile;
        }

        private Tile ReadWallTreasure(XmlNode node)
        {
            WallTreasure tile = new WallTreasure();

            tile.treasure = (TreasureType)Enum.Parse(typeof(TreasureType), node.FirstChild.Attributes.GetNamedItem("Treasure").Value);

            return tile;
        }
    }
}
