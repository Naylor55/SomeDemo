namespace WindowsForms
{
    partial class Print
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print));
            this.PrintDoc = new System.Drawing.Printing.PrintDocument();
            this.PrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.btn_DoPrint = new System.Windows.Forms.Button();
            this.btn_SetPrinter = new System.Windows.Forms.Button();
            this.lab_PrinterTip = new System.Windows.Forms.Label();
            this.lab_Printer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrintDoc
            // 
            this.PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc_PrintPage);
            // 
            // PrintPreviewDialog
            // 
            this.PrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.PrintPreviewDialog.Enabled = true;
            this.PrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("PrintPreviewDialog.Icon")));
            this.PrintPreviewDialog.Name = "PrintPreviewDialog";
            this.PrintPreviewDialog.Visible = false;
            // 
            // btn_DoPrint
            // 
            this.btn_DoPrint.Location = new System.Drawing.Point(34, 22);
            this.btn_DoPrint.Name = "btn_DoPrint";
            this.btn_DoPrint.Size = new System.Drawing.Size(75, 23);
            this.btn_DoPrint.TabIndex = 0;
            this.btn_DoPrint.Text = "打 印";
            this.btn_DoPrint.UseVisualStyleBackColor = true;
            this.btn_DoPrint.Click += new System.EventHandler(this.btn_DoPrint_Click);
            // 
            // btn_SetPrinter
            // 
            this.btn_SetPrinter.Location = new System.Drawing.Point(195, 22);
            this.btn_SetPrinter.Name = "btn_SetPrinter";
            this.btn_SetPrinter.Size = new System.Drawing.Size(75, 23);
            this.btn_SetPrinter.TabIndex = 1;
            this.btn_SetPrinter.Text = "设置打印机";
            this.btn_SetPrinter.UseVisualStyleBackColor = true;
            this.btn_SetPrinter.Click += new System.EventHandler(this.btn_SetPrinter_Click);
            // 
            // lab_PrinterTip
            // 
            this.lab_PrinterTip.AutoSize = true;
            this.lab_PrinterTip.Location = new System.Drawing.Point(296, 32);
            this.lab_PrinterTip.Name = "lab_PrinterTip";
            this.lab_PrinterTip.Size = new System.Drawing.Size(77, 12);
            this.lab_PrinterTip.TabIndex = 2;
            this.lab_PrinterTip.Text = "当前打印机：";
            // 
            // lab_Printer
            // 
            this.lab_Printer.AutoSize = true;
            this.lab_Printer.Location = new System.Drawing.Point(370, 33);
            this.lab_Printer.Name = "lab_Printer";
            this.lab_Printer.Size = new System.Drawing.Size(17, 12);
            this.lab_Printer.TabIndex = 2;
            this.lab_Printer.Text = "无";
            // 
            // Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 369);
            this.Controls.Add(this.lab_Printer);
            this.Controls.Add(this.lab_PrinterTip);
            this.Controls.Add(this.btn_SetPrinter);
            this.Controls.Add(this.btn_DoPrint);
            this.Name = "Print";
            this.Text = "Print";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument PrintDoc;
        private System.Windows.Forms.PrintPreviewDialog PrintPreviewDialog;
        private System.Windows.Forms.Button btn_DoPrint;
        private System.Windows.Forms.Button btn_SetPrinter;
        private System.Windows.Forms.Label lab_PrinterTip;
        private System.Windows.Forms.Label lab_Printer;
    }
}