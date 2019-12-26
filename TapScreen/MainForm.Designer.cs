namespace TapScreen
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.screen = new System.Windows.Forms.PictureBox();
            this.numSensability = new System.Windows.Forms.NumericUpDown();
            this.btnx1 = new System.Windows.Forms.Button();
            this.btnx05 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.screen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSensability)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 39);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.Play_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 69);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.White;
            this.screen.Location = new System.Drawing.Point(95, 13);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(693, 425);
            this.screen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.screen.TabIndex = 2;
            this.screen.TabStop = false;
            this.screen.Click += new System.EventHandler(this.Screen_Click);
            // 
            // numSensability
            // 
            this.numSensability.Location = new System.Drawing.Point(13, 123);
            this.numSensability.Name = "numSensability";
            this.numSensability.Size = new System.Drawing.Size(75, 21);
            this.numSensability.TabIndex = 3;
            this.numSensability.ValueChanged += new System.EventHandler(this.Sensability_Changed);
            // 
            // btnx1
            // 
            this.btnx1.Location = new System.Drawing.Point(13, 202);
            this.btnx1.Name = "btnx1";
            this.btnx1.Size = new System.Drawing.Size(45, 23);
            this.btnx1.TabIndex = 4;
            this.btnx1.Text = "x1";
            this.btnx1.UseVisualStyleBackColor = true;
            this.btnx1.Click += new System.EventHandler(this.Sizex1_Click);
            // 
            // btnx05
            // 
            this.btnx05.Location = new System.Drawing.Point(12, 173);
            this.btnx05.Name = "btnx05";
            this.btnx05.Size = new System.Drawing.Size(45, 23);
            this.btnx05.TabIndex = 5;
            this.btnx05.Text = "x 0.5";
            this.btnx05.UseVisualStyleBackColor = true;
            this.btnx05.Click += new System.EventHandler(this.SizeX05_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sensability";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Screen Size";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(13, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(72, 21);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "temp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 562);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnx05);
            this.Controls.Add(this.btnx1);
            this.Controls.Add(this.numSensability);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Name = "Form1";
            this.Text = "TapScreen";
            ((System.ComponentModel.ISupportInitialize)(this.screen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSensability)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox screen;
        private System.Windows.Forms.NumericUpDown numSensability;
        private System.Windows.Forms.Button btnx1;
        private System.Windows.Forms.Button btnx05;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
    }
}

