namespace GAME_PLANET
{
    partial class IfEliminarPedido
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnNoEliminarProdcuto = new System.Windows.Forms.Button();
            this.btnSiEliminarProdcuto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNoEliminarProdcuto);
            this.panel1.Controls.Add(this.btnSiEliminarProdcuto);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 118);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 26);
            this.label1.TabIndex = 14;
            this.label1.Text = "¿Esta seguro que deseaCancelar el pedido?";
            // 
            // btnNoEliminarProdcuto
            // 
            this.btnNoEliminarProdcuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoEliminarProdcuto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNoEliminarProdcuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnNoEliminarProdcuto.Location = new System.Drawing.Point(221, 59);
            this.btnNoEliminarProdcuto.Name = "btnNoEliminarProdcuto";
            this.btnNoEliminarProdcuto.Size = new System.Drawing.Size(140, 38);
            this.btnNoEliminarProdcuto.TabIndex = 13;
            this.btnNoEliminarProdcuto.Text = "NO";
            this.btnNoEliminarProdcuto.UseVisualStyleBackColor = true;
            this.btnNoEliminarProdcuto.Click += new System.EventHandler(this.btnNoEliminarProdcuto_Click);
            // 
            // btnSiEliminarProdcuto
            // 
            this.btnSiEliminarProdcuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSiEliminarProdcuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiEliminarProdcuto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSiEliminarProdcuto.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnSiEliminarProdcuto.Location = new System.Drawing.Point(19, 59);
            this.btnSiEliminarProdcuto.Name = "btnSiEliminarProdcuto";
            this.btnSiEliminarProdcuto.Size = new System.Drawing.Size(132, 38);
            this.btnSiEliminarProdcuto.TabIndex = 12;
            this.btnSiEliminarProdcuto.Text = "SI";
            this.btnSiEliminarProdcuto.UseVisualStyleBackColor = true;
            this.btnSiEliminarProdcuto.Click += new System.EventHandler(this.btnSiEliminarProdcuto_Click);
            // 
            // IfEliminarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(400, 142);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IfEliminarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IfEliminarPedido";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoEliminarProdcuto;
        private System.Windows.Forms.Button btnSiEliminarProdcuto;
    }
}