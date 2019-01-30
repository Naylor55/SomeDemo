namespace WindowsForms
{
    partial class Main
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
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_DgvPartialRender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Print
            // 
            this.btn_Print.Location = new System.Drawing.Point(46, 41);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 23);
            this.btn_Print.TabIndex = 0;
            this.btn_Print.Text = "打 印";
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_DgvPartialRender
            // 
            this.btn_DgvPartialRender.Location = new System.Drawing.Point(205, 41);
            this.btn_DgvPartialRender.Name = "btn_DgvPartialRender";
            this.btn_DgvPartialRender.Size = new System.Drawing.Size(75, 23);
            this.btn_DgvPartialRender.TabIndex = 0;
            this.btn_DgvPartialRender.Text = "DGV分部渲染";
            this.btn_DgvPartialRender.UseVisualStyleBackColor = true;
            this.btn_DgvPartialRender.Click += new System.EventHandler(this.btn_DgvPartialRender_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 505);
            this.Controls.Add(this.btn_DgvPartialRender);
            this.Controls.Add(this.btn_Print);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_DgvPartialRender;
    }
}