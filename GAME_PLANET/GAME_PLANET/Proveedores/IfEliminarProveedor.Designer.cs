namespace GAME_PLANET
{
    partial class IfEliminarProveedor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNoEliminarProveedor = new System.Windows.Forms.Button();
            this.btnSiEliminarProvedor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNoEliminarProveedor);
            this.panel1.Controls.Add(this.btnSiEliminarProvedor);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 118);
            this.panel1.TabIndex = 0;
            // 
            // btnNoEliminarProveedor
            // 
            this.btnNoEliminarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoEliminarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoEliminarProveedor.ForeColor = System.Drawing.Color.Red;
            this.btnNoEliminarProveedor.Location = new System.Drawing.Point(217, 56);
            this.btnNoEliminarProveedor.Name = "btnNoEliminarProveedor";
            this.btnNoEliminarProveedor.Size = new System.Drawing.Size(134, 43);
            this.btnNoEliminarProveedor.TabIndex = 17;
            this.btnNoEliminarProveedor.Text = "NO";
            this.btnNoEliminarProveedor.UseVisualStyleBackColor = true;
            this.btnNoEliminarProveedor.Click += new System.EventHandler(this.btnNoEliminarProveedor_Click_1);
            // 
            // btnSiEliminarProvedor
            // 
            this.btnSiEliminarProvedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiEliminarProvedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiEliminarProvedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSiEliminarProvedor.Location = new System.Drawing.Point(19, 56);
            this.btnSiEliminarProvedor.Name = "btnSiEliminarProvedor";
            this.btnSiEliminarProvedor.Size = new System.Drawing.Size(134, 43);
            this.btnSiEliminarProvedor.TabIndex = 16;
            this.btnSiEliminarProvedor.Text = "SI";
            this.btnSiEliminarProvedor.UseVisualStyleBackColor = true;
            this.btnSiEliminarProvedor.Click += new System.EventHandler(this.btnSiEliminarProvedor_Click_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "¿Esta seguro que desea Eliminar el Proveedor..?";
            // 
            // IfEliminarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(400, 142);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IfEliminarProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IfEliminarProveedor";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNoEliminarProveedor;
        private System.Windows.Forms.Button btnSiEliminarProvedor;
        private System.Windows.Forms.Label label1;
    }
}