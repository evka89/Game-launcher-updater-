namespace Launcher
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.prgCheck = new System.Windows.Forms.ProgressBar();
            this.prgInstall = new System.Windows.Forms.ProgressBar();
            this.lbCheck = new System.Windows.Forms.Label();
            this.lbInstall = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prgCheck
            // 
            this.prgCheck.Location = new System.Drawing.Point(12, 40);
            this.prgCheck.Name = "prgCheck";
            this.prgCheck.Size = new System.Drawing.Size(395, 23);
            this.prgCheck.TabIndex = 0;
            // 
            // prgInstall
            // 
            this.prgInstall.Location = new System.Drawing.Point(12, 111);
            this.prgInstall.Name = "prgInstall";
            this.prgInstall.Size = new System.Drawing.Size(395, 23);
            this.prgInstall.TabIndex = 1;
            // 
            // lbCheck
            // 
            this.lbCheck.AutoSize = true;
            this.lbCheck.Location = new System.Drawing.Point(12, 9);
            this.lbCheck.Name = "lbCheck";
            this.lbCheck.Size = new System.Drawing.Size(98, 13);
            this.lbCheck.TabIndex = 2;
            this.lbCheck.Text = "Проверка файлов";
            // 
            // lbInstall
            // 
            this.lbInstall.AutoSize = true;
            this.lbInstall.Location = new System.Drawing.Point(12, 77);
            this.lbInstall.Name = "lbInstall";
            this.lbInstall.Size = new System.Drawing.Size(125, 13);
            this.lbInstall.TabIndex = 3;
            this.lbInstall.Text = "Установка обновления";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 148);
            this.Controls.Add(this.lbInstall);
            this.Controls.Add(this.lbCheck);
            this.Controls.Add(this.prgInstall);
            this.Controls.Add(this.prgCheck);
            this.Name = "Main";
            this.Text = "Подготовка...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgCheck;
        private System.Windows.Forms.ProgressBar prgInstall;
        private System.Windows.Forms.Label lbCheck;
        private System.Windows.Forms.Label lbInstall;
    }
}

