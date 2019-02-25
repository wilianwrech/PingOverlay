namespace PingOverlay
{
    partial class FrOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrOverlay));
            this.lblPing = new PingOverlay.CustomLabel();
            this.SuspendLayout();
            // 
            // lblPing
            // 
            this.lblPing.AutoSize = true;
            this.lblPing.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPing.Location = new System.Drawing.Point(12, 9);
            this.lblPing.Name = "lblPing";
            this.lblPing.OutlineForeColor = System.Drawing.Color.Black;
            this.lblPing.OutlineWidth = 2F;
            this.lblPing.Size = new System.Drawing.Size(25, 13);
            this.lblPing.TabIndex = 1;
            this.lblPing.Text = "000";
            // 
            // FrOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(134, 41);
            this.Controls.Add(this.lblPing);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrOverlay";
            this.LocationChanged += new System.EventHandler(this.FrOverlay_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomLabel lblPing;
    }
}