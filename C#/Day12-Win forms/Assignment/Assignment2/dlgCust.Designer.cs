namespace Assignment2
{
    partial class dlgCust
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
            btnOk = new Button();
            textInput = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(30, 215);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // textInput
            // 
            textInput.Location = new Point(30, 69);
            textInput.Name = "textInput";
            textInput.Size = new Size(745, 27);
            textInput.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(681, 215);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dlgCust
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 287);
            ControlBox = false;
            Controls.Add(btnCancel);
            Controls.Add(textInput);
            Controls.Add(btnOk);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "dlgCust";
            ShowInTaskbar = false;
            Text = "dlgCust";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private TextBox textInput;
        private Button btnCancel;
    }
}