namespace GAME_PLANET
{
    partial class IfEliminarEmpleado
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
            this.btnNoDeleteCliente = new System.Windows.Forms.Button();
            this.btnDeleteCliente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNoDeleteCliente);
            this.panel1.Controls.Add(this.btnDeleteCliente);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 118);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "¿Esta seguro que desea Eliminar el Empleado..?";
            // 
            // btnNoDeleteCliente
            // 
            this.btnNoDeleteCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoDeleteCliente.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnNoDeleteCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnNoDeleteCliente.Location = new System.Drawing.Point(217, 56);
            this.btnNoDeleteCliente.Name = "btnNoDeleteCliente";
            this.btnNoDeleteCliente.Size = new System.Drawing.Size(134, 43);
            this.btnNoDeleteCliente.TabIndex = 8;
            this.btnNoDeleteCliente.Text = "NO";
            this.btnNoDeleteCliente.UseVisualStyleBackColor = true;
            this.btnNoDeleteCliente.Click += new System.EventHandler(this.btnNoDeleteCliente_Click_1);
            // 
            // btnDeleteCliente
            // 
            this.btnDeleteCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteCliente.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCliente.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnDeleteCliente.Location = new System.Drawing.Point(19, 56);
            this.btnDeleteCliente.Name = "btnDeleteCliente";
            this.btnDeleteCliente.Size = new System.Drawing.Size(134, 43);
            this.btnDeleteCliente.TabIndex = 7;
            this.btnDeleteCliente.Text = "Si";
            this.btnDeleteCliente.UseVisualStyleBackColor = true;
            this.btnDeleteCliente.Click += new System.EventHandler(this.btnDeleteCliente_Click_1);
            // 
            // IfEliminarEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(400, 142);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IfEliminarEmpleado";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IfEliminar";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNoDeleteCliente;
        private System.Windows.Forms.Button btnDeleteCliente;
    }
}