using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;
using TP_Map_Editor_PR_POB.Controller;
using TP_Map_Editor_PR_POB.Model.Tile;

namespace TP_Map_Editor_PR_POB
{
    public partial class FormEditor
    {
        //On en fait une sous-classe: On doit passer explicitement par la référence de classe, mais on a accès à tout ce qui est privé.
        public class Controller
        {
            private const string TITLE_ATTENTION = "Attention!!";
            private const string TITLE_BRAVO = "Bravo!";
            private const string MSG_LOSE_MAP = "Si vous continuez, tout ce qui n'est pas enregistré sera perdu. Voulez-vous continuer?";
            private const string MSG_ERROR_SAVE = "Une erreur c'est produite lors de la sauvegarde.";
            private const string MSG_ERROR_UPLOAD = "Une erreur c'est produite lors de l'ouverture du fichier xml.";
            private const string MSG_MAP_VALID = "La pièce est valide";
            private const string MSG_MAP_INVALID = "La pièce n'est pas valide. Erreur sur la case:";
            private const string MSG_MAP_INVALID_DOOR = "La pièce n'est pas valide. Il manque l'entée et/ou la sortie";
            private const string TITLE_ABOUT = "À propos";
            private const string MSG_ABOUT = "Cet éditeur de pièce pour le jeu Spelunky à été créé par Philippe Rousseau et Pierre-Olivier Boulet";

            private DataGridViewCell drag_cell;

            private Rectangle dragBoxFromMouseDown;

            private Point mouseDownMultiSelect = new Point(-1, 0);

            private Tile tileToAdd;


            private readonly FormEditor vue;
            private NewMap newMap;


            public Controller(FormEditor vue)
            {
                this.vue = vue;

                //Les événements de la vue sont au niveau du contrôleur
                vue.menuCreate.Click += new EventHandler(this.menuCreate_Click);
                vue.menuQuit.Click += new EventHandler(this.menuQuit_Click);
                vue.menuSave.Click += menuSave_Click;
                vue.menuOpen.Click += menuOpen_Click;
                vue.menuClose.Click += menuClose_Click;
                vue.menuValidate.Click += menuValidate_Click;
                vue.menuAbout.Click += menuAbout_Click;
                vue.propertyGridTiles.PropertyValueChanged += propertyGridTiles_PropertyValueChanged;

                vue.dgvEdition.CellMouseDown += dgvEdition_CellMouseDown;
                vue.dgvEdition.CellMouseEnter += dgvEdition_CellMouseEnter;
                vue.dgvEdition.CellMouseLeave += dgvEdition_CellMouseLeave;
                vue.dgvEdition.CellMouseUp += dgvEdition_CellMouseUp;

                vue.KeyDown += vue_KeyDown;

                vue.dgvEdition.MouseUp += new MouseEventHandler(dgvEdition_MouseUp);
                vue.dgvEdition.MouseMove += new MouseEventHandler(dgvEdition_MouseMove);
                vue.dgvEdition.MouseLeave += new EventHandler(dgvEdition_MouseLeave);
                vue.dgvEdition.DragOver += new DragEventHandler(dgvEdition_DragOver);
                vue.dgvEdition.DragDrop += new DragEventHandler(dgvEdition_DragDrop);
                vue.dgvEdition.DragLeave += new EventHandler(dgvEdition_DragLeave);
            }

            void vue_KeyDown(object sender, KeyEventArgs e)
            {
                if(e.KeyCode == Keys.Delete)
                {
                    this.vue.map.SetTileValue(this.vue.dgvEdition.CurrentCell.ColumnIndex, this.vue.dgvEdition.CurrentCell.RowIndex, null);

                    this.vue.dgvEdition.Refresh();
                }

                if(e.Modifiers == Keys.Control)
                {
                    if(e.KeyCode == Keys.Z)
                    {
                        this.vue.map.Undo();
                    }
                    else if(e.KeyCode == Keys.Y)
                    {
                        this.vue.map.Redo();
                    }

                    
                }
            }

            /// <summary>
            /// Evenement du click de sourie sur une cellule
            /// Pour ajouter plusieurs tuiles à la fois avec le bouton du millieu de la sourie
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void dgvEdition_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                if(TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl != null)
                {
                    if(e.Button == MouseButtons.Middle)
                    {
                        this.MultipleCreateCellInitialization(e.ColumnIndex, e.RowIndex);
                    }
                    else if(e.Button == MouseButtons.Left)
                    {
                        createTileOnMap(e.ColumnIndex, e.RowIndex);
                    }
                    else if(e.Button == MouseButtons.XButton1)
                    {
                        TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl = null;
                        this.vue.pbActiveControl.Image = null;
                    }
                }
                else
                {
                    this.vue.lblTilePosX.Text = e.ColumnIndex.ToString();
                    this.vue.lblTilePosY.Text = e.RowIndex.ToString();
                    this.vue.AddParam(this.vue.map.tiles[e.ColumnIndex][e.RowIndex]);
                }
                if(e.Button == MouseButtons.Right)
                {
                    this.initiateDragAndDrop(e.ColumnIndex, e.RowIndex);
                }
            }

            private void initiateDragAndDrop(int columnIndex, int rowIndex)
            {

                if(columnIndex != -1 && rowIndex != -1)
                {
                    if(vue.map.tiles[columnIndex][rowIndex] != null)
                    {
                        drag_cell = vue.dgvEdition[columnIndex, rowIndex];
                        // Proceed with the drag and drop, passing in the list item.                    
                        DragDropEffects dropEffect = vue.dgvEdition.DoDragDrop(drag_cell, DragDropEffects.Move);
                    }
                }


            }

            private void createTileOnMap(int columnIndex, int rowIndex)
            {
                if(TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl != null)
                {
                    System.Windows.Forms.Cursor.Current = Cursors.Cross;
                    this.vue.lblControl.Text = "Mode Création Simple";
                    Tile newTile = this.tileToAdd.DeepCopy();
                    if(newTile != null)
                    {
                        if(vue.map.tiles[columnIndex][rowIndex] != null)
                        {
                            if(newTile.type != vue.map.tiles[columnIndex][rowIndex].type)
                            {
                                vue.map.SetTileValue(columnIndex, rowIndex, this.tileToAdd.DeepCopy());
                            }
                        }
                        else
                        {
                            vue.map.SetTileValue(columnIndex, rowIndex, this.tileToAdd.DeepCopy());
                        }
                    }
                    if(columnIndex >= 0 && rowIndex >= 0)
                    {
                        vue.AddParam(vue.map.tiles[columnIndex][rowIndex]);
                    }
                }
            }
            private void MultipleCreateCellInitialization(int columnIndex, int rowIndex)
            {
                if(TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl != null)
                {
                    this.vue.lblControl.Text = "Mode Création Multiple";
                    Cursor.Current = Cursors.PanSE;
                    this.vue.dgvEdition.CurrentCell = null;
                    mouseDownMultiSelect = new Point(columnIndex, rowIndex);
                }
            }

            private void cancelMultipleCellCreation()
            {
                mouseDownMultiSelect.X = -1;
            }

            private void dgvEdition_MouseUp(object sender, MouseEventArgs e)
            {
                cancelMultipleCellCreation();
            }

            private void dgvEdition_MouseLeave(object sender, EventArgs e)
            {
                cancelCellDragAndDrop();
                cancelMultipleCellCreation();
            }

            /// <summary>
            /// Evenement losrque la sourie rentre dans une cellule
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void dgvEdition_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
            {
                createMultipleCellDisplay(e.ColumnIndex, e.RowIndex);
            }

            private void createMultipleCellDisplay(int columnIndex, int rowIndex)
            {
                if(mouseDownMultiSelect.X != -1)
                {
                    Point startRectanglePoint = findRectangleAddMultipleCellPointStart(columnIndex, rowIndex);
                    Point endRectanglePoint = findRectangleAddMultipleCellPointEnd(columnIndex, rowIndex);

                    for(int i = startRectanglePoint.X; i <= endRectanglePoint.X; i++)
                    {
                        for(int j = startRectanglePoint.Y; j <= endRectanglePoint.Y; j++)
                        {
                            this.vue.dgvEdition.Rows[j].Cells[i].Tag = "selected";
                            this.vue.dgvEdition.InvalidateCell(this.vue.dgvEdition.Rows[j].Cells[i]);
                        }
                    }
                }
            }

            private void createMultipleCellRemoveDisplay(int columnIndex, int rowIndex)
            {
                if(mouseDownMultiSelect.X != -1)
                {
                    Point startRectanglePoint = findRectangleAddMultipleCellPointStart(columnIndex, rowIndex);
                    Point endRectanglePoint = findRectangleAddMultipleCellPointEnd(columnIndex, rowIndex);

                    for(int i = startRectanglePoint.X; i <= endRectanglePoint.X; i++)
                    {
                        for(int j = startRectanglePoint.Y; j <= endRectanglePoint.Y; j++)
                        {
                            this.vue.dgvEdition.Rows[j].Cells[i].Tag = null;
                            this.vue.dgvEdition.InvalidateCell(this.vue.dgvEdition.Rows[j].Cells[i]);
                        }
                    }
                }
            }

            private Point findRectangleAddMultipleCellPointStart(int columnIndex, int rowIndex)
            {
                int startX = mouseDownMultiSelect.X;
                int startY = mouseDownMultiSelect.Y;

                if(mouseDownMultiSelect.X > columnIndex)
                {
                    startX = columnIndex;
                }
                if(mouseDownMultiSelect.Y > rowIndex)
                {
                    startY = rowIndex;
                }

                return new Point(startX, startY);
            }

            private Point findRectangleAddMultipleCellPointEnd(int columnIndex, int rowIndex)
            {
                int endX = columnIndex;
                int endY = rowIndex;

                if(mouseDownMultiSelect.X > columnIndex)
                {
                    endX = mouseDownMultiSelect.X;
                }

                if(mouseDownMultiSelect.Y > rowIndex)
                {
                    endY = mouseDownMultiSelect.Y;
                }
                return new Point(endX, endY);
            }
            /// <summary>
            /// Evenement losrque la sourie sort d'une cellule
            /// Pour enlever le foncé des cases ou l'on va pas ajouter des tuiles avec le bouton du millieu de la sourie
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void dgvEdition_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
            {
                createMultipleCellRemoveDisplay(e.ColumnIndex, e.RowIndex);
                if(cellExistsOnDataGrid(e.ColumnIndex, e.RowIndex))
                {
                    cancelCellHoverDisplay(e.ColumnIndex, e.RowIndex);
                }
            }

            bool cellExistsOnDataGrid(int columnIndex, int rowIndex)
            {
                if(columnIndex < 0 || rowIndex < 0)
                {
                    return false;
                }
                return true;
            }

            private void cancelCellHoverDisplay(int columnIndex, int rowIndex)
            {
                this.vue.cellHover = new Point(-1, -1);
                this.vue.dgvEdition.InvalidateCell(this.vue.dgvEdition.Rows[rowIndex].Cells[columnIndex]);
            }

            /// <summary>
            /// Evenement du relachement de la sourie sur une cellule
            /// Pour ajouter plusieurs tuiles à la fois avec le bouton du millieu de la sourie
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void dgvEdition_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
            {
                if(e.Button == MouseButtons.Middle)
                {
                    createMultipleCellOnGridView(e.ColumnIndex, e.RowIndex);
                }
            }

            private void createMultipleCellOnGridView(int columnIndex, int rowIndex)
            {
                if(mouseDownMultiSelect.X != -1)
                {
                    if(TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl != null)
                    {
                        Point startRectanglePoint = findRectangleAddMultipleCellPointStart(columnIndex, rowIndex);
                        Point endRectanglePoint = findRectangleAddMultipleCellPointEnd(columnIndex, rowIndex);

                        this.vue.map.SaveTiles();

                        for(int i = startRectanglePoint.X; i <= endRectanglePoint.X; i++)
                        {
                            for(int j = startRectanglePoint.Y; j <= endRectanglePoint.Y; j++)
                            {
                                this.vue.map.SetTileValueNoSave(i, j, this.tileToAdd.DeepCopy());
                                this.vue.dgvEdition.Rows[j].Cells[i].Tag = null;
                            }
                        }
                        mouseDownMultiSelect.X = -1;
                    }
                }
            }
            /// <summary>
            /// Rafraichie la grille losque que l'on chage une propriété.
            /// Sert pour Containing qui contient une classe en parametre qui ne se rafraichie pas.
            /// </summary>
            /// <param name="s"></param>
            /// <param name="e"></param>
            private void propertyGridTiles_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
            {
                vue.propertyGridTiles.Refresh();
            }

            /// <summary>
            /// Affiche une messagebox qui décrit l'application
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void menuAbout_Click(object sender, EventArgs e)
            {
                Interaction.MsgBox(MSG_ABOUT, MsgBoxStyle.OkOnly, TITLE_ABOUT);
            }

            /// <summary>
            /// Affiche une messagebox disant si la piece est valide ou non
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void menuValidate_Click(object sender, EventArgs e)
            {
                if(vue.map.tiles != null)
                {
                    int x, y;
                    if(vue.map.ValidateTiles(out x, out y))
                    {
                        Interaction.MsgBox(MSG_MAP_VALID, MsgBoxStyle.OkOnly, TITLE_BRAVO);
                    }
                    else
                    {
                        if(x == -1)
                        {
                            Interaction.MsgBox(MSG_MAP_INVALID_DOOR, MsgBoxStyle.OkOnly, TITLE_ATTENTION);
                        }
                        else
                        {
                            string msg = MSG_MAP_INVALID + "(" + x.ToString() + ", " + y.ToString() + ")";
                            Interaction.MsgBox(msg, MsgBoxStyle.OkOnly, TITLE_ATTENTION);
                        }
                    }
                }
            }

            /// <summary>
            /// Demande une confirmation et ferme la piece
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void menuClose_Click(object sender, EventArgs e)
            {
                if(vue.map.tiles != null)
                {
                    MsgBoxResult result = Interaction.MsgBox(MSG_LOSE_MAP, MsgBoxStyle.YesNo, TITLE_ATTENTION);

                    if(result == MsgBoxResult.Yes)
                    {
                        vue.map.DestructionMap();
                    }
                }
            }

            /// <summary>
            /// Si une piece est déja ouverte, il demande une confimation et ouvre une fenetre pour téléchargé un XML
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void menuOpen_Click(object sender, EventArgs e)
            {
                if(vue.map.tiles != null)
                {
                    MsgBoxResult result = Interaction.MsgBox(MSG_LOSE_MAP, MsgBoxStyle.YesNo, TITLE_ATTENTION);

                    if(result == MsgBoxResult.Yes)
                    {
                        vue.map.DestructionMap();
                        OpenFile();
                    }
                }
                else
                {
                    OpenFile();
                }
            }

            /// <summary>
            /// Ouvre la boite de dialogue pour choisir le fichier XML à ouvrir
            /// </summary>
            private void OpenFile()
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "E:\\Utilisateur\\Philippe\\Document\\Cégep\\Projet synthèse\\Projet\\Unity\\ProjetSynthese\\Assets\\Levels";
                openFileDialog1.Filter = "Fichiers XML (*.xml)|*.xml";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    myStream = openFileDialog1.OpenFile();
                    if(myStream != null)
                    {
                        Tile[][] tiles = vue.xml.ReadXML(myStream);

                        if(tiles == null)
                        {
                            Interaction.MsgBox(MSG_ERROR_UPLOAD, MsgBoxStyle.OkOnly, TITLE_ATTENTION);
                        }
                        else
                        {
                            vue.map.UploadMap(tiles);
                        }
                    }
                }
            }


            private void dgvEdition_MouseMove(object sender, MouseEventArgs e)
            {
                if(dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    DataGridView.HitTestInfo hti = vue.dgvEdition.HitTest(e.X, e.Y); //Obtient la cell du datagrid sous le curseur.
                    DragDropEffects dropEffect = vue.dgvEdition.DoDragDrop(
                        vue.dgvEdition.Rows[hti.RowIndex],
                        DragDropEffects.Move);
                }
            }

            private void dgvEdition_DragLeave(object sender, EventArgs e)
            {
                this.cancelCellDragAndDrop();
            }

            private void cancelCellDragAndDrop()
            {
                if(this.vue.drag_cell != null)
                {
                    DataGridViewCell dragCellToInvalidate = this.vue.drag_cell;
                    this.vue.drag_cell = null;
                    this.vue.dgvEdition.InvalidateCell(dragCellToInvalidate);
                }
            }

            private void dgvEdition_DragOver(object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Move;
                Point clientPoint = vue.dgvEdition.PointToClient(new Point(e.X, e.Y));

                DataGridViewCell cellUnderMouse = getCellUnderMouse(clientPoint.X, clientPoint.Y);

                if(cellUnderMouse != null)
                {
                    displayDragAndDrop(cellUnderMouse);
                }
                else
                {
                    this.cancelCellDragAndDrop();
                }
            }

            private DataGridViewCell getCellUnderMouse(int mousePositionX, int mousePositionY)
            {
                DataGridView.HitTestInfo hti = vue.dgvEdition.HitTest(mousePositionX, mousePositionY);

                if(hti.ColumnIndex >= 0 && hti.RowIndex >= 0)
                {
                    DataGridViewCell targetCell = vue.dgvEdition[hti.ColumnIndex, hti.RowIndex];
                    return targetCell;
                }
                return null;
            }

            private void displayDragAndDrop(DataGridViewCell cellUnderMouse)
            {
                if(this.vue.drag_cell != null)
                {
                    if(this.vue.drag_cell != cellUnderMouse)
                    {
                        this.vue.dgvEdition.InvalidateCell(this.vue.drag_cell);
                        this.vue.drag_cell = cellUnderMouse;
                        this.vue.dgvEdition.InvalidateCell(this.vue.drag_cell);
                    }
                }
                else
                {
                    this.vue.drag_cell = cellUnderMouse;
                    this.vue.dgvEdition.InvalidateCell(this.vue.drag_cell);
                }
            }

            private void dgvEdition_DragDrop(object sender, DragEventArgs e)
            {
                // The mouse locations are relative to the screen, so they must be 
                // converted to client coordinates.
                Point clientPoint = vue.dgvEdition.PointToClient(new Point(e.X, e.Y));

                // Get the row index of the item the mouse is below. 

                DataGridViewCell cellUnderMouse = getCellUnderMouse(clientPoint.X, clientPoint.Y);

                if(drag_cell != cellUnderMouse && cellUnderMouse != null)
                {
                    if(e.Effect == DragDropEffects.Move)
                    {
                        this.moveDragAndDropCell(cellUnderMouse);
                    }
                }

            }

            private void moveDragAndDropCell(DataGridViewCell targetCell)
            {
                //On transfert le contenu dans la nouvelle cellule.
                vue.map.SetTileValue(targetCell.ColumnIndex, targetCell.RowIndex, vue.map.tiles[drag_cell.ColumnIndex][drag_cell.RowIndex]);

                //On efface le contenu dans l'ancienne cellule.
                vue.map.SetTileValue(drag_cell.ColumnIndex, drag_cell.RowIndex, null);
                targetCell.Selected = true;

                this.cancelCellDragAndDrop();
            }


            public void createNewTile()
            {
                this.tileToAdd = TileFactory.CreateTile(TP_Map_Editor_PR_POB.Controller.ToolBar.GetInstance().ActiveToolBarControl.AssociatedTileType);
                this.vue.AddParam(this.tileToAdd);
            }

            /// <summary>
            /// Ouvre une boite de dialogue pour choisir l'endroit ou sauvegarder la piece et la sauvegarde en format XML
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void menuSave_Click(object sender, EventArgs e)
            {
                if(vue.map.tiles != null)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Xml files (*.xml)|*.xml";
                    save.FilterIndex = 2;
                    save.RestoreDirectory = true;

                    if(save.ShowDialog() == DialogResult.OK)
                    {
                        Stream myStream;
                        if((myStream = save.OpenFile()) != null)
                        {
                            if(!vue.xml.SaveMapToXml(myStream, vue.map.tiles))
                            {
                                Interaction.MsgBox(MSG_ERROR_SAVE, MsgBoxStyle.OkOnly, TITLE_ATTENTION);
                            }
                            myStream.Close();
                        }
                    }
                }
            }

            /// <summary>
            /// Ferme l'application 
            /// demande une confirmation si une piece est ouverte
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void menuQuit_Click(object sender, EventArgs e)
            {
                if(vue.map.tiles != null)
                {
                    MsgBoxResult result = Interaction.MsgBox(MSG_LOSE_MAP, MsgBoxStyle.YesNo, TITLE_ATTENTION);

                    if(result == MsgBoxResult.Yes)
                    {
                        vue.Close();
                    }
                }
                else
                {
                    vue.Close();
                }
            }

            /// <summary>
            /// Ouvre une fenetre pour créer une nouvelle piece.
            /// demande une confirmation si une piece est deja ouverte
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void menuCreate_Click(object sender, EventArgs e)
            {
                bool create = false;

                if(vue.map.tiles != null)
                {
                    MsgBoxResult result = Interaction.MsgBox(MSG_LOSE_MAP, MsgBoxStyle.YesNo, TITLE_ATTENTION);

                    if(result == MsgBoxResult.Yes)
                    {
                        newMap.FormClosed -= this.newMap_FormClosed;
                        vue.map.DestructionMap();
                        create = true;
                    }
                }
                else
                {
                    create = true;
                }

                if(create)
                {
                    newMap = new NewMap();
                    newMap.FormClosed += this.newMap_FormClosed;
                    newMap.Show();
                }
            }

            /// <summary>
            /// crée une nouvelle piece selon la hauteur et largeur deamnder
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void newMap_FormClosed(Object sender, FormClosedEventArgs e)
            {
                if(NewMap.WIDTH >= 10 && NewMap.HEIGHT >= 3)
                {
                    vue.map.CreateMap(NewMap.WIDTH, NewMap.HEIGHT);
                }
            }

        }
    }
}
