namespace StreetsClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewStreets = new DataGridView();
            textBox1 = new TextBox();
            buttonFind = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStreets).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewStreets
            // 
            dataGridViewStreets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStreets.Location = new Point(12, 12);
            dataGridViewStreets.Name = "dataGridViewStreets";
            dataGridViewStreets.RowTemplate.Height = 25;
            dataGridViewStreets.Size = new Size(776, 391);
            dataGridViewStreets.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 415);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Postal Index to find";
            textBox1.Size = new Size(111, 23);
            textBox1.TabIndex = 1;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(129, 415);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(75, 23);
            buttonFind.TabIndex = 2;
            buttonFind.Text = "Find";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonFind);
            Controls.Add(textBox1);
            Controls.Add(dataGridViewStreets);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewStreets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewStreets;
        private TextBox textBox1;
        private Button buttonFind;
    }
}
