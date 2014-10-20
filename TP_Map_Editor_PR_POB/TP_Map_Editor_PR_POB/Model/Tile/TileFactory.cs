using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Map_Editor_PR_POB.Controller;

namespace TP_Map_Editor_PR_POB.Model.Tile
{
    class TileFactory
    {
        public static TP_Map_Editor_PR_POB.Tile CreateTile(TileTypes type)
        {
            switch (type)
            {
                case (TileTypes.Actor):
                    {
                        return new Actor();
                    }
                case (TileTypes.Chest):
                    {
                        return new Chest();
                    }
                case (TileTypes.Containing):
                    {
                        return new Containing();
                    }
                case (TileTypes.Empty):
                    {
                        return new Empty();
                    }
                case (TileTypes.Enemy):
                    {
                        return new Enemy();
                    }
                case (TileTypes.EnemySpawner):
                    {
                        return new EnemySpawner();
                    }
                case (TileTypes.Exit):
                    {
                        return new Exit();
                    }
                case (TileTypes.Ladder):
                    {
                        return new Ladder();
                    }
                case (TileTypes.Movable):
                    {
                        return new Movable();
                    }
                case (TileTypes.Neutral):
                    {
                        return new Neutral();
                    }
                case (TileTypes.Spawn):
                    {
                        return new Spawn();
                    }
                case (TileTypes.SpiderWeb):
                    {
                        return new SpiderWeb();
                    }
                case (TileTypes.Trap):
                    {
                        return new Trap();
                    }
                case (TileTypes.Treasure):
                    {
                        return new Treasure();
                    }
                case (TileTypes.Utilities):
                    {
                        return new Utilities();
                    }
                case (TileTypes.Wall):
                    {
                        return new Wall();
                    }
                case (TileTypes.WallTreasure):
                    {
                        return new WallTreasure();
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
