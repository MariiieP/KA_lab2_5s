namespace travelingSalesman
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gridMatrix = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnRandomly = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.increaseVertex = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnPathFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.increaseVertex)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMatrix
            // 
            this.gridMatrix.AllowUserToAddRows = false;
            this.gridMatrix.AllowUserToDeleteRows = false;
            this.gridMatrix.AllowUserToResizeColumns = false;
            this.gridMatrix.AllowUserToResizeRows = false;
            this.gridMatrix.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gridMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridMatrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatrix.ColumnHeadersVisible = false;
            this.gridMatrix.Location = new System.Drawing.Point(225, 27);
            this.gridMatrix.MultiSelect = false;
            this.gridMatrix.Name = "gridMatrix";
            this.gridMatrix.RowHeadersVisible = false;
            this.gridMatrix.Size = new System.Drawing.Size(323, 306);
            this.gridMatrix.TabIndex = 0;
            this.gridMatrix.TabStop = false;
            this.gridMatrix.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridMatrix_CellBeginEdit);
            this.gridMatrix.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridMatrix_CellMouseClick);
            this.gridMatrix.SelectionChanged += new System.EventHandler(this.gridMatrix_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnRandomly);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.increaseVertex);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 320);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control panel";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Location = new System.Drawing.Point(6, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(189, 171);
            this.textBox1.TabIndex = 14;
            this.textBox1.TabStop = false;
            // 
            // btnRandomly
            // 
            this.btnRandomly.Location = new System.Drawing.Point(105, 58);
            this.btnRandomly.Name = "btnRandomly";
            this.btnRandomly.Size = new System.Drawing.Size(93, 23);
            this.btnRandomly.TabIndex = 14;
            this.btnRandomly.TabStop = false;
            this.btnRandomly.Text = "Randomly";
            this.btnRandomly.UseVisualStyleBackColor = true;
            this.btnRandomly.Click += new System.EventHandler(this.btnRandomly_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Number of vertices:";
            // 
            // increaseVertex
            // 
            this.increaseVertex.Location = new System.Drawing.Point(6, 32);
            this.increaseVertex.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.increaseVertex.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.increaseVertex.Name = "increaseVertex";
            this.increaseVertex.Size = new System.Drawing.Size(192, 20);
            this.increaseVertex.TabIndex = 0;
            this.increaseVertex.TabStop = false;
            this.increaseVertex.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.increaseVertex.ValueChanged += new System.EventHandler(this.increaseVertex_ValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(123, 310);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPathFind
            // 
            this.btnPathFind.Location = new System.Drawing.Point(12, 310);
            this.btnPathFind.Name = "btnPathFind";
            this.btnPathFind.Size = new System.Drawing.Size(93, 23);
            this.btnPathFind.TabIndex = 0;
            this.btnPathFind.TabStop = false;
            this.btnPathFind.Text = "Find a way";
            this.btnPathFind.UseVisualStyleBackColor = true;
            this.btnPathFind.Click += new System.EventHandler(this.btnPathFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Adjacency matrix:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(585, 374);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnPathFind);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridMatrix);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.increaseVertex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown increaseVertex;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnRandomly;
        private System.Windows.Forms.Button btnPathFind;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView gridMatrix;
    }
}

