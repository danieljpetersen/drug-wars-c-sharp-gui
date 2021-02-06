namespace WindowsFormsApplication1
{
    partial class Combat
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
            this.PlayerHealth = new System.Windows.Forms.Label();
            this.PlayerWeapon = new System.Windows.Forms.Label();
            this.PlayerVehicle = new System.Windows.Forms.Label();
            this.EnemyHealth = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.EnemyWeapon = new System.Windows.Forms.Label();
            this.PlayerInfo = new System.Windows.Forms.GroupBox();
            this.NumOfEnemies = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.PlayerInfo.SuspendLayout();
            this.NumOfEnemies.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerHealth
            // 
            this.PlayerHealth.AutoSize = true;
            this.PlayerHealth.Location = new System.Drawing.Point(6, 16);
            this.PlayerHealth.Name = "PlayerHealth";
            this.PlayerHealth.Size = new System.Drawing.Size(94, 13);
            this.PlayerHealth.TabIndex = 0;
            this.PlayerHealth.Text = "Health:  100 / 100";
            this.PlayerHealth.Click += new System.EventHandler(this.PlayerHealth_Click);
            // 
            // PlayerWeapon
            // 
            this.PlayerWeapon.AutoSize = true;
            this.PlayerWeapon.Location = new System.Drawing.Point(6, 42);
            this.PlayerWeapon.Name = "PlayerWeapon";
            this.PlayerWeapon.Size = new System.Drawing.Size(116, 13);
            this.PlayerWeapon.TabIndex = 1;
            this.PlayerWeapon.Text = "Weapon:  Baseball Bat";
            // 
            // PlayerVehicle
            // 
            this.PlayerVehicle.AutoSize = true;
            this.PlayerVehicle.Location = new System.Drawing.Point(6, 29);
            this.PlayerVehicle.Name = "PlayerVehicle";
            this.PlayerVehicle.Size = new System.Drawing.Size(92, 13);
            this.PlayerVehicle.TabIndex = 2;
            this.PlayerVehicle.Text = "Vehicle:  Mustang";
            // 
            // EnemyHealth
            // 
            this.EnemyHealth.AutoSize = true;
            this.EnemyHealth.Location = new System.Drawing.Point(6, 29);
            this.EnemyHealth.Name = "EnemyHealth";
            this.EnemyHealth.Size = new System.Drawing.Size(94, 13);
            this.EnemyHealth.TabIndex = 3;
            this.EnemyHealth.Text = "Health:  100 / 100";
            this.EnemyHealth.Click += new System.EventHandler(this.EnemyHealth_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Fight Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Try To Run";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EnemyWeapon
            // 
            this.EnemyWeapon.AutoSize = true;
            this.EnemyWeapon.Location = new System.Drawing.Point(6, 42);
            this.EnemyWeapon.Name = "EnemyWeapon";
            this.EnemyWeapon.Size = new System.Drawing.Size(82, 13);
            this.EnemyWeapon.TabIndex = 6;
            this.EnemyWeapon.Text = "Weapon:  Pistol";
            this.EnemyWeapon.Click += new System.EventHandler(this.EnemyWeapon_Click);
            // 
            // PlayerInfo
            // 
            this.PlayerInfo.Controls.Add(this.PlayerWeapon);
            this.PlayerInfo.Controls.Add(this.PlayerHealth);
            this.PlayerInfo.Controls.Add(this.PlayerVehicle);
            this.PlayerInfo.Location = new System.Drawing.Point(12, 12);
            this.PlayerInfo.Name = "PlayerInfo";
            this.PlayerInfo.Size = new System.Drawing.Size(255, 67);
            this.PlayerInfo.TabIndex = 7;
            this.PlayerInfo.TabStop = false;
            this.PlayerInfo.Text = "Player Info";
            this.PlayerInfo.Enter += new System.EventHandler(this.PlayerInfo_Enter);
            // 
            // NumOfEnemies
            // 
            this.NumOfEnemies.Controls.Add(this.label1);
            this.NumOfEnemies.Controls.Add(this.EnemyHealth);
            this.NumOfEnemies.Controls.Add(this.EnemyWeapon);
            this.NumOfEnemies.Location = new System.Drawing.Point(12, 85);
            this.NumOfEnemies.Name = "NumOfEnemies";
            this.NumOfEnemies.Size = new System.Drawing.Size(255, 66);
            this.NumOfEnemies.TabIndex = 8;
            this.NumOfEnemies.TabStop = false;
            this.NumOfEnemies.Text = "Enemy Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of Enemies:  1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 11;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 157);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(255, 171);
            this.richTextBox1.TabIndex = 25;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(192, 334);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Bribe";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Combat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 369);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumOfEnemies);
            this.Controls.Add(this.PlayerInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Combat";
            this.Text = "Combat";
            this.PlayerInfo.ResumeLayout(false);
            this.PlayerInfo.PerformLayout();
            this.NumOfEnemies.ResumeLayout(false);
            this.NumOfEnemies.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayerHealth;
        private System.Windows.Forms.Label PlayerWeapon;
        private System.Windows.Forms.Label PlayerVehicle;
        private System.Windows.Forms.Label EnemyHealth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label EnemyWeapon;
        private System.Windows.Forms.GroupBox PlayerInfo;
        private System.Windows.Forms.GroupBox NumOfEnemies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button3;
    }
}