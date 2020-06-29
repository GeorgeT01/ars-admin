namespace DiplomaApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.EmailTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PswTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialCheckBox1 = new MaterialSkin.Controls.MaterialCheckBox();
            this.loginbtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Depth = 0;
            this.EmailTextBox.Hint = "Email";
            resources.ApplyResources(this.EmailTextBox, "EmailTextBox");
            this.EmailTextBox.MaxLength = 32767;
            this.EmailTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.PasswordChar = '\0';
            this.EmailTextBox.SelectedText = "";
            this.EmailTextBox.SelectionLength = 0;
            this.EmailTextBox.SelectionStart = 0;
            this.EmailTextBox.TabStop = false;
            this.EmailTextBox.UseSystemPasswordChar = false;
            // 
            // PswTextBox
            // 
            this.PswTextBox.Depth = 0;
            this.PswTextBox.Hint = "Password";
            resources.ApplyResources(this.PswTextBox, "PswTextBox");
            this.PswTextBox.MaxLength = 32767;
            this.PswTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.PswTextBox.Name = "PswTextBox";
            this.PswTextBox.PasswordChar = '\0';
            this.PswTextBox.SelectedText = "";
            this.PswTextBox.SelectionLength = 0;
            this.PswTextBox.SelectionStart = 0;
            this.PswTextBox.TabStop = false;
            this.PswTextBox.UseSystemPasswordChar = false;
            this.PswTextBox.Click += new System.EventHandler(this.PswTextBox_Click);
            // 
            // materialCheckBox1
            // 
            resources.ApplyResources(this.materialCheckBox1, "materialCheckBox1");
            this.materialCheckBox1.Depth = 0;
            this.materialCheckBox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckBox1.Name = "materialCheckBox1";
            this.materialCheckBox1.Ripple = true;
            this.materialCheckBox1.UseVisualStyleBackColor = true;
            // 
            // loginbtn
            // 
            resources.ApplyResources(this.loginbtn, "loginbtn");
            this.loginbtn.Depth = 0;
            this.loginbtn.Icon = null;
            this.loginbtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Primary = true;
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.materialCheckBox1);
            this.Controls.Add(this.PswTextBox);
            this.Controls.Add(this.EmailTextBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField EmailTextBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField PswTextBox;
        private MaterialSkin.Controls.MaterialCheckBox materialCheckBox1;
        private MaterialSkin.Controls.MaterialRaisedButton loginbtn;
    }
}

