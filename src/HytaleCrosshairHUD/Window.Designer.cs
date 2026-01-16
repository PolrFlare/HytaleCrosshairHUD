namespace HytaleCrosshairHUD
{
    partial class Window
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
            this.extractStatus = new System.Windows.Forms.Label();
            this.default_btn = new System.Windows.Forms.Button();
            this.default_label = new System.Windows.Forms.Label();
            this.melee_label = new System.Windows.Forms.Label();
            this.melee_btn = new System.Windows.Forms.Button();
            this.apply_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // extractStatus
            // 
            this.extractStatus.AutoSize = true;
            this.extractStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extractStatus.Location = new System.Drawing.Point(139, 144);
            this.extractStatus.Name = "extractStatus";
            this.extractStatus.Size = new System.Drawing.Size(170, 25);
            this.extractStatus.TabIndex = 0;
            this.extractStatus.Text = "extracting assets...";
            this.extractStatus.Visible = false;
            // 
            // default_btn
            // 
            this.default_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.default_btn.Location = new System.Drawing.Point(130, 24);
            this.default_btn.Name = "default_btn";
            this.default_btn.Size = new System.Drawing.Size(124, 28);
            this.default_btn.TabIndex = 1;
            this.default_btn.Text = "choose file";
            this.default_btn.UseVisualStyleBackColor = true;
            this.default_btn.Visible = false;
            this.default_btn.Click += new System.EventHandler(this.default_btn_Click);
            // 
            // default_label
            // 
            this.default_label.AutoSize = true;
            this.default_label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.default_label.Location = new System.Drawing.Point(12, 28);
            this.default_label.Name = "default_label";
            this.default_label.Size = new System.Drawing.Size(112, 21);
            this.default_label.TabIndex = 2;
            this.default_label.Text = "default reticle";
            this.default_label.Visible = false;
            // 
            // melee_label
            // 
            this.melee_label.AutoSize = true;
            this.melee_label.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.melee_label.Location = new System.Drawing.Point(12, 73);
            this.melee_label.Name = "melee_label";
            this.melee_label.Size = new System.Drawing.Size(105, 21);
            this.melee_label.TabIndex = 4;
            this.melee_label.Text = "melee reticle";
            this.melee_label.Visible = false;
            // 
            // melee_btn
            // 
            this.melee_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.melee_btn.Location = new System.Drawing.Point(130, 69);
            this.melee_btn.Name = "melee_btn";
            this.melee_btn.Size = new System.Drawing.Size(124, 28);
            this.melee_btn.TabIndex = 3;
            this.melee_btn.Text = "choose file";
            this.melee_btn.UseVisualStyleBackColor = true;
            this.melee_btn.Visible = false;
            this.melee_btn.Click += new System.EventHandler(this.melee_btn_Click);
            // 
            // apply_btn
            // 
            this.apply_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apply_btn.Location = new System.Drawing.Point(16, 113);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(238, 28);
            this.apply_btn.TabIndex = 5;
            this.apply_btn.Text = "apply";
            this.apply_btn.UseVisualStyleBackColor = true;
            this.apply_btn.Visible = false;
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 321);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.melee_label);
            this.Controls.Add(this.melee_btn);
            this.Controls.Add(this.default_label);
            this.Controls.Add(this.default_btn);
            this.Controls.Add(this.extractStatus);
            this.Name = "Window";
            this.ShowIcon = false;
            this.Text = "HytaleCrosshairHUD";
            this.Load += new System.EventHandler(this.Window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label extractStatus;
        private System.Windows.Forms.Button default_btn;
        private System.Windows.Forms.Label default_label;
        private System.Windows.Forms.Label melee_label;
        private System.Windows.Forms.Button melee_btn;
        private System.Windows.Forms.Button apply_btn;
    }
}

