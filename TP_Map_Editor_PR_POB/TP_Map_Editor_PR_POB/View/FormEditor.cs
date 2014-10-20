using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Map_Editor_PR_POB.Controller;
using ToolBar = System.Windows.Forms.ToolBar;

namespace TP_Map_Editor_PR_POB
{
    public partial class FormEditor: Form
    {
        private DataGridViewCell drag_cell;

        public Point cellHover;
        private const int TILE_SIZE = 50;
        private Image none = Image.FromFile("../../Resource/default.gif");

        private Controller controller;
        private Map map = new Map();
        private XML_Manager xml = new XML_Manager();

        public FormEditor()
        {
            InitializeComponent();
            this.map = new Map();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.controller = new Controller(this);
            this.PopulateTileTypesPannel();

            this.dgvEdition.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEditor_CellMouseEnter);
            this.map.Changed += new EventHandler(this.map_changed);
            this.map.MapUpload += this.map_upload;
            this.map.InitMap += map_InitMap;
            this.map.DeleteMap += map_DeleteMap;
        }

        void map_DeleteMap(object sender, EventArgs e)
        {

            dgvEdition.Rows.Clear();
        }

        /// <summary>
        /// initialise une piece vide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void map_InitMap(object sender, EventArgs e)
        {
            Map initMap = (Map)sender;
            dgvEdition.ColumnCount = initMap.width;

            for(int y = 0; y < initMap.height; y++)
            {
                DataGridViewRow row = new DataGridViewRow();
                for(int x = 0; x < initMap.width; x++)
                {
                    DataGridViewImageCell cell = new DataGridViewImageCell();
                    cell.Value = none;
                    cell.ImageLayout = DataGridViewImageCellLayout.NotSet;
                    row.Cells.Add(cell);
                }
                this.dgvEdition.Rows.Add(row);
            }
            dgvEdition.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvEdition.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        //http://stackoverflow.com/questions/13772239/how-to-change-the-border-color-of-some-cells-in-datagridview
        private void dgvEdition_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if(this.dgvEdition.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using(SolidBrush brush = new SolidBrush(Color.FromArgb(80, 8, 32, 112)))
                    {
                        Rectangle rect = e.CellBounds;
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    e.Handled = true;
                }
                if (e.RowIndex == cellHover.Y && e.ColumnIndex == cellHover.X)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, 3, 93, 20)))
                    {
                        Rectangle rect = e.CellBounds;
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    e.Handled = true;
                }
                if(this.drag_cell != null)
                {
                    if(e.RowIndex == drag_cell.RowIndex && e.ColumnIndex == drag_cell.ColumnIndex)
                    {
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                        using(SolidBrush brush = new SolidBrush(Color.FromArgb(80, 176, 36, 10)))
                        {
                            Rectangle rect = e.CellBounds;
                            e.Graphics.FillRectangle(brush, rect);
                        }
                        e.Handled = true;
                    }
                }

                if((string)(this.dgvEdition.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag) == "selected")
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using(SolidBrush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 51)))
                    {
                        Rectangle rect = e.CellBounds;
                        e.Graphics.FillRectangle(brush, rect);
                    }
                    e.Handled = true;
                }
            }


        }

        private void map_changed(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs cellToModify = (DataGridViewCellEventArgs)e;
            if(((Tile)sender) != null)
            {
                Image image = Image.FromFile(((Tile)sender).path);
                dgvEdition.Rows[cellToModify.RowIndex].Cells[cellToModify.ColumnIndex].Value = image;
            }
            else
            {
                dgvEdition.Rows[cellToModify.RowIndex].Cells[cellToModify.ColumnIndex].Value = none;
            }
            dgvEdition.Rows[cellToModify.RowIndex].Cells[cellToModify.ColumnIndex].Selected = true;
        }

        private void PopulateTileTypesPannel()
        {
            TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().Changed += new EventHandler(toolbar_Changed);

            //CreateToolBarControls(TileTypes.Actor, Actor.Image);
            //CreateToolBarControls(TileTypes.Chest, Chest.image);
            //CreateToolBarControls(TileTypes.Containing, Containing.image);
            CreateToolBarControls(TileTypes.Empty, Empty.image);
            //CreateToolBarControls(TileTypes.Enemy, Enemy.image);
            //CreateToolBarControls(TileTypes.EnemySpawner, EnemySpawner.image);
            CreateToolBarControls(TileTypes.Spawn, Spawn.image);
            //CreateToolBarControls(TileTypes.Exit, Exit.image);
            CreateToolBarControls(TileTypes.Ladder, Ladder.image);
            //CreateToolBarControls(TileTypes.Movable, Movable.image);
            //CreateToolBarControls(TileTypes.Neutral, Neutral.image);
            //CreateToolBarControls(TileTypes.SpiderWeb, SpiderWeb.image);
            //CreateToolBarControls(TileTypes.Trap, Trap.image);
            //CreateToolBarControls(TileTypes.Treasure, Treasure.image);
            //CreateToolBarControls(TileTypes.Utilities, Utilities.image);
            CreateToolBarControls(TileTypes.Wall, Wall.image);
            //CreateToolBarControls(TileTypes.WallTreasure, WallTreasure.image);
        }

        private void toolbar_Changed(object sender, EventArgs e)
        {
            foreach(ToolBarControl control in TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().toolControls)
            {
                control.BorderStyle = BorderStyle.None;
            }
            if(TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl != null)
            {
                TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl.BorderStyle =
                    BorderStyle.Fixed3D;
                this.pbActiveControl.Image =
                    TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl.Image;
            }
        }

        private void activateControlsToolBar()
        {
            foreach (ToolBarControl control in TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().toolControls)
            {
                control.Enabled = true;
            }
        }
        private void deactivateControlsToolBar()
        {
            foreach (ToolBarControl control in TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().toolControls)
            {
                control.BorderStyle = BorderStyle.None;
                control.BackColor = Color.Transparent;
                control.Enabled = false;
            }
        }
        private void dgvEditor_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Skip the Column and Row headers
            if(e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            var dataGridView = (sender as DataGridView);
            //Check the condition as per the requirement casting the cell value to the appropriate type

            this.lblCursorPosX.Text = e.ColumnIndex.ToString();
            this.lblCursorPosY.Text = e.RowIndex.ToString();

            this.cellHover = new Point(e.ColumnIndex, e.RowIndex);
            this.dgvEdition.InvalidateCell(this.dgvEdition.Rows[e.RowIndex].Cells[e.ColumnIndex]);
        }

        private void AddParam(Tile tile)
        {
            propertyGridTiles.SelectedObject = tile;
        }

        private void CreateToolBarControls(TileTypes tileType, Image controleImage)
        {
            ToolBarControl newToolBarControl = new ToolBarControl(tileType);
            newToolBarControl.Image = controleImage;
            newToolBarControl.AutoSize = true;
            newToolBarControl.Dock = DockStyle.Fill;
            fPannel_Selection.Controls.Add(newToolBarControl);
            
            new ControllerToolBar(newToolBarControl, this.controller);
            TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().toolControls.Add(newToolBarControl);
        }

        /// <summary>
        /// Initialise une piece selon une piece deja existante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void map_upload(object sender, EventArgs e)
        {
            Tile[][] tiles = ((Map)sender).tiles;
            map_InitMap(sender, e);
            for(int i = 0; i < tiles.Length; i++)
            {
                for(int y = 0; y < tiles[0].Length; y++)
                {
                    if(tiles[i][y] != null)
                    {
                        Image image = Image.FromFile(tiles[i][y].path);
                        dgvEdition.Rows[y].Cells[i].Value = image;
                    }
                }
            }
        }
    }
}
