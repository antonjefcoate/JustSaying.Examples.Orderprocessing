namespace Restaurant
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.OrderItems = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IdBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RejectButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OrderItems);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.NameBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.IdBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RejectButton);
            this.panel1.Controls.Add(this.AcceptButton);
            this.panel1.Location = new System.Drawing.Point(379, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 279);
            this.panel1.TabIndex = 0;
            // 
            // OrderItems
            // 
            this.OrderItems.Location = new System.Drawing.Point(108, 115);
            this.OrderItems.Name = "OrderItems";
            this.OrderItems.Size = new System.Drawing.Size(291, 26);
            this.OrderItems.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Items";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(108, 83);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(291, 26);
            this.NameBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name";
            // 
            // IdBox
            // 
            this.IdBox.Location = new System.Drawing.Point(108, 51);
            this.IdBox.Name = "IdBox";
            this.IdBox.Size = new System.Drawing.Size(291, 26);
            this.IdBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Incoming Order...";
            // 
            // RejectButton
            // 
            this.RejectButton.Location = new System.Drawing.Point(249, 202);
            this.RejectButton.Name = "RejectButton";
            this.RejectButton.Size = new System.Drawing.Size(128, 46);
            this.RejectButton.TabIndex = 1;
            this.RejectButton.Text = "REJECT";
            this.RejectButton.UseVisualStyleBackColor = true;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(53, 202);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(128, 46);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "ACCEPT";
            this.AcceptButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 675);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button RejectButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.TextBox IdBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OrderItems;
        private System.Windows.Forms.Label label4;
    }
}

