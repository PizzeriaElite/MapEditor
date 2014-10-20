using System.Windows.Forms;

namespace TP_Map_Editor_PR_POB
{
    partial class FormEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuEditor = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuValidate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.fPannel_Status = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCursorPosY = new System.Windows.Forms.Label();
            this.lblCursorPosSeparation = new System.Windows.Forms.Label();
            this.lblCursorPosX = new System.Windows.Forms.Label();
            this.lblCursorPos = new System.Windows.Forms.Label();
            this.lblTilePosY = new System.Windows.Forms.Label();
            this.lblTilePosSeparation = new System.Windows.Forms.Label();
            this.lblTilePosX = new System.Windows.Forms.Label();
            this.lblTilePos = new System.Windows.Forms.Label();
            this.lblControl = new System.Windows.Forms.Label();
            this.dgvEdition = new System.Windows.Forms.DataGridView();
            this.propertyGridTiles = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbActiveControl = new System.Windows.Forms.PictureBox();
            this.fPannel_Selection = new System.Windows.Forms.FlowLayoutPanel();
            this.menuEditor.SuspendLayout();
            this.fPannel_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbActiveControl)).BeginInit();
            this.fPannel_Selection.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuEditor
            // 
            this.menuEditor.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.menuEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuHelp});
            this.menuEditor.Location = new System.Drawing.Point(0, 0);
            this.menuEditor.Name = "menuEditor";
            this.menuEditor.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuEditor.Size = new System.Drawing.Size(1036, 24);
            this.menuEditor.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreate,
            this.menuOpen,
            this.menuSave,
            this.menuClose,
            this.menuValidate,
            this.menuQuit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(54, 20);
            this.menuFile.Text = "Fichier";
            // 
            // menuCreate
            // 
            this.menuCreate.Name = "menuCreate";
            this.menuCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuCreate.Size = new System.Drawing.Size(200, 22);
            this.menuCreate.Text = "Créer une pièce";
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(200, 22);
            this.menuOpen.Text = "Ouvir un pièce";
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(200, 22);
            this.menuSave.Text = "Sauvegarder";
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.menuClose.Size = new System.Drawing.Size(200, 22);
            this.menuClose.Text = "Fermer la pièce";
            // 
            // menuValidate
            // 
            this.menuValidate.Name = "menuValidate";
            this.menuValidate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.menuValidate.Size = new System.Drawing.Size(200, 22);
            this.menuValidate.Text = "Valider la pièce";
            // 
            // menuQuit
            // 
            this.menuQuit.Name = "menuQuit";
            this.menuQuit.Size = new System.Drawing.Size(200, 22);
            this.menuQuit.Text = "Quitter";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(24, 20);
            this.menuHelp.Text = "?";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(122, 22);
            this.menuAbout.Text = "À propos";
            // 
            // fPannel_Status
            // 
            this.fPannel_Status.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fPannel_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fPannel_Status.Controls.Add(this.lblCursorPosY);
            this.fPannel_Status.Controls.Add(this.lblCursorPosSeparation);
            this.fPannel_Status.Controls.Add(this.lblCursorPosX);
            this.fPannel_Status.Controls.Add(this.lblCursorPos);
            this.fPannel_Status.Controls.Add(this.lblTilePosY);
            this.fPannel_Status.Controls.Add(this.lblTilePosSeparation);
            this.fPannel_Status.Controls.Add(this.lblTilePosX);
            this.fPannel_Status.Controls.Add(this.lblTilePos);
            this.fPannel_Status.Controls.Add(this.lblControl);
            this.fPannel_Status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fPannel_Status.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.fPannel_Status.Location = new System.Drawing.Point(0, 587);
            this.fPannel_Status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fPannel_Status.Name = "fPannel_Status";
            this.fPannel_Status.Size = new System.Drawing.Size(1036, 25);
            this.fPannel_Status.TabIndex = 1;
            // 
            // lblCursorPosY
            // 
            this.lblCursorPosY.AutoSize = true;
            this.lblCursorPosY.BackColor = System.Drawing.Color.Transparent;
            this.lblCursorPosY.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCursorPosY.Location = new System.Drawing.Point(944, 0);
            this.lblCursorPosY.Margin = new System.Windows.Forms.Padding(0, 0, 75, 0);
            this.lblCursorPosY.Name = "lblCursorPosY";
            this.lblCursorPosY.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCursorPosY.Size = new System.Drawing.Size(13, 21);
            this.lblCursorPosY.TabIndex = 6;
            this.lblCursorPosY.Text = "0";
            // 
            // lblCursorPosSeparation
            // 
            this.lblCursorPosSeparation.AutoSize = true;
            this.lblCursorPosSeparation.BackColor = System.Drawing.Color.Transparent;
            this.lblCursorPosSeparation.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCursorPosSeparation.Location = new System.Drawing.Point(934, 0);
            this.lblCursorPosSeparation.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursorPosSeparation.Name = "lblCursorPosSeparation";
            this.lblCursorPosSeparation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCursorPosSeparation.Size = new System.Drawing.Size(10, 21);
            this.lblCursorPosSeparation.TabIndex = 7;
            this.lblCursorPosSeparation.Text = ",";
            // 
            // lblCursorPosX
            // 
            this.lblCursorPosX.AutoSize = true;
            this.lblCursorPosX.BackColor = System.Drawing.Color.Transparent;
            this.lblCursorPosX.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCursorPosX.Location = new System.Drawing.Point(921, 0);
            this.lblCursorPosX.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursorPosX.Name = "lblCursorPosX";
            this.lblCursorPosX.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblCursorPosX.Size = new System.Drawing.Size(13, 21);
            this.lblCursorPosX.TabIndex = 5;
            this.lblCursorPosX.Text = "0";
            // 
            // lblCursorPos
            // 
            this.lblCursorPos.AutoSize = true;
            this.lblCursorPos.BackColor = System.Drawing.Color.Transparent;
            this.lblCursorPos.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCursorPos.Location = new System.Drawing.Point(865, 0);
            this.lblCursorPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCursorPos.Name = "lblCursorPos";
            this.lblCursorPos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblCursorPos.Size = new System.Drawing.Size(54, 21);
            this.lblCursorPos.TabIndex = 4;
            this.lblCursorPos.Text = "Curseur:";
            // 
            // lblTilePosY
            // 
            this.lblTilePosY.AutoSize = true;
            this.lblTilePosY.BackColor = System.Drawing.Color.Transparent;
            this.lblTilePosY.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTilePosY.Location = new System.Drawing.Point(775, 0);
            this.lblTilePosY.Margin = new System.Windows.Forms.Padding(0, 0, 75, 0);
            this.lblTilePosY.Name = "lblTilePosY";
            this.lblTilePosY.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblTilePosY.Size = new System.Drawing.Size(13, 21);
            this.lblTilePosY.TabIndex = 11;
            this.lblTilePosY.Text = "0";
            // 
            // lblTilePosSeparation
            // 
            this.lblTilePosSeparation.AutoSize = true;
            this.lblTilePosSeparation.BackColor = System.Drawing.Color.Transparent;
            this.lblTilePosSeparation.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTilePosSeparation.Location = new System.Drawing.Point(765, 0);
            this.lblTilePosSeparation.Margin = new System.Windows.Forms.Padding(0);
            this.lblTilePosSeparation.Name = "lblTilePosSeparation";
            this.lblTilePosSeparation.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblTilePosSeparation.Size = new System.Drawing.Size(10, 21);
            this.lblTilePosSeparation.TabIndex = 12;
            this.lblTilePosSeparation.Text = ",";
            // 
            // lblTilePosX
            // 
            this.lblTilePosX.AutoSize = true;
            this.lblTilePosX.BackColor = System.Drawing.Color.Transparent;
            this.lblTilePosX.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTilePosX.Location = new System.Drawing.Point(752, 0);
            this.lblTilePosX.Margin = new System.Windows.Forms.Padding(0);
            this.lblTilePosX.Name = "lblTilePosX";
            this.lblTilePosX.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.lblTilePosX.Size = new System.Drawing.Size(13, 21);
            this.lblTilePosX.TabIndex = 10;
            this.lblTilePosX.Text = "0";
            // 
            // lblTilePos
            // 
            this.lblTilePos.AutoSize = true;
            this.lblTilePos.BackColor = System.Drawing.Color.Transparent;
            this.lblTilePos.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTilePos.Location = new System.Drawing.Point(688, 0);
            this.lblTilePos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTilePos.Name = "lblTilePos";
            this.lblTilePos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTilePos.Size = new System.Drawing.Size(62, 21);
            this.lblTilePos.TabIndex = 9;
            this.lblTilePos.Text = "Sélection:";
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblControl.Location = new System.Drawing.Point(565, 0);
            this.lblControl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblControl.Name = "lblControl";
            this.lblControl.Padding = new System.Windows.Forms.Padding(0, 0, 38, 0);
            this.lblControl.Size = new System.Drawing.Size(119, 21);
            this.lblControl.TabIndex = 16;
            this.lblControl.Text = "Mode Sélection";
            this.lblControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvEdition
            // 
            this.dgvEdition.AllowDrop = true;
            this.dgvEdition.AllowUserToAddRows = false;
            this.dgvEdition.AllowUserToDeleteRows = false;
            this.dgvEdition.AllowUserToResizeColumns = false;
            this.dgvEdition.AllowUserToResizeRows = false;
            this.dgvEdition.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEdition.ColumnHeadersHeight = 4;
            this.dgvEdition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEdition.ColumnHeadersVisible = false;
            this.dgvEdition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEdition.Location = new System.Drawing.Point(151, 24);
            this.dgvEdition.MultiSelect = false;
            this.dgvEdition.Name = "dgvEdition";
            this.dgvEdition.RowHeadersVisible = false;
            this.dgvEdition.RowHeadersWidth = 4;
            this.dgvEdition.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEdition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvEdition.Size = new System.Drawing.Size(660, 563);
            this.dgvEdition.TabIndex = 5;
            this.dgvEdition.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvEdition_CellPainting);
            // 
            // propertyGridTiles
            // 
            this.propertyGridTiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.propertyGridTiles.Location = new System.Drawing.Point(811, 24);
            this.propertyGridTiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.propertyGridTiles.Name = "propertyGridTiles";
            this.propertyGridTiles.Size = new System.Drawing.Size(225, 563);
            this.propertyGridTiles.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 87);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(112, 0);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // pbActiveControl
            // 
            this.pbActiveControl.Location = new System.Drawing.Point(6, 2);
            this.pbActiveControl.Margin = new System.Windows.Forms.Padding(2);
            this.pbActiveControl.Name = "pbActiveControl";
            this.pbActiveControl.Size = new System.Drawing.Size(75, 81);
            this.pbActiveControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbActiveControl.TabIndex = 4;
            this.pbActiveControl.TabStop = false;
            // 
            // fPannel_Selection
            // 
            this.fPannel_Selection.AutoScroll = true;
            this.fPannel_Selection.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.fPannel_Selection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fPannel_Selection.Controls.Add(this.pbActiveControl);
            this.fPannel_Selection.Controls.Add(this.splitContainer1);
            this.fPannel_Selection.Dock = System.Windows.Forms.DockStyle.Left;
            this.fPannel_Selection.Location = new System.Drawing.Point(0, 24);
            this.fPannel_Selection.Margin = new System.Windows.Forms.Padding(2);
            this.fPannel_Selection.Name = "fPannel_Selection";
            this.fPannel_Selection.Padding = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.fPannel_Selection.Size = new System.Drawing.Size(151, 563);
            this.fPannel_Selection.TabIndex = 2;
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 612);
            this.Controls.Add(this.dgvEdition);
            this.Controls.Add(this.propertyGridTiles);
            this.Controls.Add(this.fPannel_Selection);
            this.Controls.Add(this.fPannel_Status);
            this.Controls.Add(this.menuEditor);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuEditor;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Editor - By Philippe Rousseau & Pierre-Olivier Boulet";
            this.menuEditor.ResumeLayout(false);
            this.menuEditor.PerformLayout();
            this.fPannel_Status.ResumeLayout(false);
            this.fPannel_Status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbActiveControl)).EndInit();
            this.fPannel_Selection.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuEditor;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuCreate;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripMenuItem menuValidate;
        private System.Windows.Forms.ToolStripMenuItem menuQuit;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.FlowLayoutPanel fPannel_Status;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.DataGridView dgvEdition;
        private System.Windows.Forms.PropertyGrid propertyGridTiles;
        private Label lblCursorPosY;
        private Label lblCursorPosSeparation;
        private Label lblCursorPosX;
        private Label lblCursorPos;
        private Label lblTilePosY;
        private Label lblTilePosSeparation;
        private Label lblTilePosX;
        private Label lblTilePos;
        private Label lblControl;
        private SplitContainer splitContainer1;
        private PictureBox pbActiveControl;
        private FlowLayoutPanel fPannel_Selection;
    }
}

