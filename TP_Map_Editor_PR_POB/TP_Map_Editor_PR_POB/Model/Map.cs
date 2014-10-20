using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Map_Editor_PR_POB
{
    class Map
    {
        public Tile[][] tiles { get; set; }
        private LinkedList<Tile[][]> undoSaves;
        private LinkedList<Tile[][]> redoSaves;
        private const int maxSaves = 30;
        public int width { get; private set; }
        public int height { get; private set; }

        public Map()
        {
            tiles = null;
            this.undoSaves = new LinkedList<Tile[][]>();
            this.redoSaves = new LinkedList<Tile[][]>();
        }

        /// <summary>
        /// Crée une nouvelle piece de tuile null
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void CreateMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.undoSaves.Clear();
            this.redoSaves.Clear();
            tiles = new Tile[width][];
            for(int i = 0; i < width; i++)
            {
                tiles[i] = new Tile[height];
            }

            for(int i = 0; i < width; i++)
            {
                for(int y = 0; y < height; y++)
                {
                    tiles[i][y] = null;
                }
            }
            InitMap(this, new EventArgs());
        }

        /// <summary>
        /// détruit une piece
        /// </summary>
        public void DestructionMap()
        {
            tiles = null;
            DeleteMap(null, new EventArgs());
        }

        /// <summary>
        /// Crée une piece selon une piece deja existante
        /// </summary>
        /// <param name="tiles">la piece</param>
        public void UploadMap(Tile[][] tiles)
        {
            this.tiles = tiles;
            this.width = tiles.Length;
            this.height = tiles[0].Length;
            MapUpload(this, new EventArgs());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>   
        /// <param name="y"></param>
        /// <param name="newTileType"></param>
        public void SetTileValue(int x, int y, Tile newTileType)
        {
            SaveTiles();
            this.tiles[x][y] = newTileType;
            Changed(newTileType, new DataGridViewCellEventArgs(x, y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="newTileType"></param>
        public void SetTileValueNoSave(int x, int y, Tile newTileType)
        {
            this.tiles[x][y] = newTileType;
            Changed(newTileType, new DataGridViewCellEventArgs(x, y));
        }

        /// <summary>
        /// Annule une modification a la piece
        /// </summary>
        public void Undo()
        {
            if (this.undoSaves.Count > 0)
            {
                this.redoSaves.AddFirst(this.tiles);
                DestructionMap();
                this.UploadMap(this.undoSaves.First.Value);
                this.undoSaves.RemoveFirst();
            }
        }

        public void Redo()
        {
            if(this.redoSaves.Count > 0)
            {
                this.undoSaves.AddFirst(this.tiles);
                DestructionMap();
                this.UploadMap(this.redoSaves.First.Value);
                this.redoSaves.RemoveFirst();
            }
        }

        /// <summary>
        /// Sauvegarde la piece dans une liste
        /// </summary>
        public void SaveTiles()
        {
            Tile[][] save = new Tile[width][];

            for(int i = 0; i < width; i++)
            {
                save[i] = new Tile[height];

                for(int j = 0; j < height; j++)
                {
                    if(tiles[i][j] != null)
                    {
                        save[i][j] = tiles[i][j].DeepCopy();
                    }
                    else
                    {
                        save[i][j] = null;
                    }
                }
            }

            this.undoSaves.AddFirst(save);
            this.redoSaves.Clear();

            if(this.undoSaves.Count > maxSaves)
            {
                this.undoSaves.RemoveLast();
            }
        }

        /// <summary>
        /// Valide une piece
        /// </summary>
        /// <param name="x">parametre de sortie, la position en x de la tuile non valide</param>
        /// <param name="y">parametre de sortie, la position en y de la tuile non valide</param>
        /// <returns>true si la piece est valide, sinon false</returns>
        public bool ValidateTiles(out int x, out int y)
        {
            bool exit = false;
            bool spawn = false;
            x = -1;
            y = -1;
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if(tiles[i][j] == null)
                    {
                        x = i;
                        y = j;
                        return false;
                    }

                    Tile haut = null;
                    Tile bas = null;

                    if(j < height - 1)
                    {
                        bas = tiles[i][j + 1];
                    }
                    if(j > 0)
                    {
                        haut = tiles[i][j - 1];
                    }

                    if(!tiles[i][j].Validate(haut, bas))
                    {
                        x = i;
                        y = j;
                        return false;
                    }

                    if(tiles[i][j] is Exit)
                    {
                        exit = true;
                    }
                    else if(tiles[i][j] is Spawn)
                    {
                        spawn = true;
                    }

                }
            }

            if(!spawn || !exit)
            {
                return false;
            }
            return true;
        }

        public event EventHandler DeleteMap;
        public event EventHandler InitMap;
        public event EventHandler MapUpload;
        public event EventHandler Changed;
    }
}
