namespace UnpackerPrototype
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
            GUI_tabs = new TabControl();
            GUI_tabs_tab1 = new TabPage();
            GUI_label_1 = new Label();
            GUI_button_choosepath = new Button();
            GUI_label_path = new Label();
            GUI_button_install = new Button();
            GUI_tabs_tab2 = new TabPage();
            GUI_progress_label = new Label();
            GUI_progress_bar = new ProgressBar();
            GUI_label_3 = new Label();
            GUI_label_2 = new Label();
            GUI_tabs_tab3 = new TabPage();
            GUI_checkbox_runwithexit = new CheckBox();
            GUI_checkbox_createdesktop = new CheckBox();
            GUI_button_exit = new Button();
            GUI_label_5 = new Label();
            GUI_label_4 = new Label();
            folderDialog = new FolderBrowserDialog();
            GUI_tabs.SuspendLayout();
            GUI_tabs_tab1.SuspendLayout();
            GUI_tabs_tab2.SuspendLayout();
            GUI_tabs_tab3.SuspendLayout();
            SuspendLayout();
            // 
            // GUI_tabs
            // 
            GUI_tabs.Controls.Add(GUI_tabs_tab1);
            GUI_tabs.Controls.Add(GUI_tabs_tab2);
            GUI_tabs.Controls.Add(GUI_tabs_tab3);
            GUI_tabs.Dock = DockStyle.Fill;
            GUI_tabs.Location = new Point(0, 0);
            GUI_tabs.Name = "GUI_tabs";
            GUI_tabs.SelectedIndex = 0;
            GUI_tabs.Size = new Size(503, 300);
            GUI_tabs.TabIndex = 0;
            // 
            // GUI_tabs_tab1
            // 
            GUI_tabs_tab1.Controls.Add(GUI_label_1);
            GUI_tabs_tab1.Controls.Add(GUI_button_choosepath);
            GUI_tabs_tab1.Controls.Add(GUI_label_path);
            GUI_tabs_tab1.Controls.Add(GUI_button_install);
            GUI_tabs_tab1.Location = new Point(4, 24);
            GUI_tabs_tab1.Name = "GUI_tabs_tab1";
            GUI_tabs_tab1.Padding = new Padding(3);
            GUI_tabs_tab1.Size = new Size(495, 272);
            GUI_tabs_tab1.TabIndex = 0;
            GUI_tabs_tab1.Text = "Настройка";
            GUI_tabs_tab1.UseVisualStyleBackColor = true;
            // 
            // GUI_label_1
            // 
            GUI_label_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GUI_label_1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GUI_label_1.Location = new Point(13, 16);
            GUI_label_1.Name = "GUI_label_1";
            GUI_label_1.Size = new Size(474, 122);
            GUI_label_1.TabIndex = 3;
            GUI_label_1.Text = "Добро пожаловать в мастер установки";
            // 
            // GUI_button_choosepath
            // 
            GUI_button_choosepath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GUI_button_choosepath.Location = new Point(8, 231);
            GUI_button_choosepath.Name = "GUI_button_choosepath";
            GUI_button_choosepath.Size = new Size(75, 33);
            GUI_button_choosepath.TabIndex = 2;
            GUI_button_choosepath.Text = "Выбрать";
            GUI_button_choosepath.UseVisualStyleBackColor = true;
            GUI_button_choosepath.Click += GUI_button_choosepath_Click;
            // 
            // GUI_label_path
            // 
            GUI_label_path.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GUI_label_path.AutoSize = true;
            GUI_label_path.ForeColor = SystemColors.ControlDarkDark;
            GUI_label_path.Location = new Point(89, 240);
            GUI_label_path.Name = "GUI_label_path";
            GUI_label_path.Size = new Size(114, 15);
            GUI_label_path.TabIndex = 1;
            GUI_label_path.Text = "Путь для установки";
            // 
            // GUI_button_install
            // 
            GUI_button_install.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GUI_button_install.Enabled = false;
            GUI_button_install.Location = new Point(367, 231);
            GUI_button_install.Name = "GUI_button_install";
            GUI_button_install.Size = new Size(120, 33);
            GUI_button_install.TabIndex = 0;
            GUI_button_install.Text = "Установить";
            GUI_button_install.UseVisualStyleBackColor = true;
            GUI_button_install.Click += GUI_button_install_Click;
            // 
            // GUI_tabs_tab2
            // 
            GUI_tabs_tab2.Controls.Add(GUI_progress_label);
            GUI_tabs_tab2.Controls.Add(GUI_progress_bar);
            GUI_tabs_tab2.Controls.Add(GUI_label_3);
            GUI_tabs_tab2.Controls.Add(GUI_label_2);
            GUI_tabs_tab2.Location = new Point(4, 24);
            GUI_tabs_tab2.Name = "GUI_tabs_tab2";
            GUI_tabs_tab2.Padding = new Padding(3);
            GUI_tabs_tab2.Size = new Size(495, 272);
            GUI_tabs_tab2.TabIndex = 1;
            GUI_tabs_tab2.Text = "Установка";
            GUI_tabs_tab2.UseVisualStyleBackColor = true;
            // 
            // GUI_progress_label
            // 
            GUI_progress_label.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            GUI_progress_label.AutoSize = true;
            GUI_progress_label.Location = new Point(13, 213);
            GUI_progress_label.Name = "GUI_progress_label";
            GUI_progress_label.Size = new Size(175, 15);
            GUI_progress_label.TabIndex = 6;
            GUI_progress_label.Text = "Идет установка... 0 MB из 0 MB";
            // 
            // GUI_progress_bar
            // 
            GUI_progress_bar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GUI_progress_bar.Location = new Point(13, 234);
            GUI_progress_bar.Name = "GUI_progress_bar";
            GUI_progress_bar.Size = new Size(469, 30);
            GUI_progress_bar.TabIndex = 5;
            // 
            // GUI_label_3
            // 
            GUI_label_3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GUI_label_3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            GUI_label_3.Location = new Point(13, 57);
            GUI_label_3.Name = "GUI_label_3";
            GUI_label_3.Size = new Size(469, 55);
            GUI_label_3.TabIndex = 4;
            GUI_label_3.Text = "Пожалуйста подождите, пока контент не распакуется на вашем компьютере\r\n";
            // 
            // GUI_label_2
            // 
            GUI_label_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GUI_label_2.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GUI_label_2.Location = new Point(8, 12);
            GUI_label_2.Name = "GUI_label_2";
            GUI_label_2.Size = new Size(474, 45);
            GUI_label_2.TabIndex = 4;
            GUI_label_2.Text = "Установка";
            // 
            // GUI_tabs_tab3
            // 
            GUI_tabs_tab3.Controls.Add(GUI_checkbox_runwithexit);
            GUI_tabs_tab3.Controls.Add(GUI_checkbox_createdesktop);
            GUI_tabs_tab3.Controls.Add(GUI_button_exit);
            GUI_tabs_tab3.Controls.Add(GUI_label_5);
            GUI_tabs_tab3.Controls.Add(GUI_label_4);
            GUI_tabs_tab3.Location = new Point(4, 24);
            GUI_tabs_tab3.Name = "GUI_tabs_tab3";
            GUI_tabs_tab3.Size = new Size(495, 272);
            GUI_tabs_tab3.TabIndex = 2;
            GUI_tabs_tab3.Text = "Зарвершение";
            GUI_tabs_tab3.UseVisualStyleBackColor = true;
            // 
            // GUI_checkbox_runwithexit
            // 
            GUI_checkbox_runwithexit.AutoSize = true;
            GUI_checkbox_runwithexit.Checked = true;
            GUI_checkbox_runwithexit.CheckState = CheckState.Checked;
            GUI_checkbox_runwithexit.Location = new Point(13, 118);
            GUI_checkbox_runwithexit.Name = "GUI_checkbox_runwithexit";
            GUI_checkbox_runwithexit.Size = new Size(176, 19);
            GUI_checkbox_runwithexit.TabIndex = 9;
            GUI_checkbox_runwithexit.Text = "Запустить после установки";
            GUI_checkbox_runwithexit.UseVisualStyleBackColor = true;
            // 
            // GUI_checkbox_createdesktop
            // 
            GUI_checkbox_createdesktop.AutoSize = true;
            GUI_checkbox_createdesktop.Checked = true;
            GUI_checkbox_createdesktop.CheckState = CheckState.Checked;
            GUI_checkbox_createdesktop.Location = new Point(13, 93);
            GUI_checkbox_createdesktop.Name = "GUI_checkbox_createdesktop";
            GUI_checkbox_createdesktop.Size = new Size(209, 19);
            GUI_checkbox_createdesktop.TabIndex = 8;
            GUI_checkbox_createdesktop.Text = "Создать ярлык на рабочем столе";
            GUI_checkbox_createdesktop.UseVisualStyleBackColor = true;
            // 
            // GUI_button_exit
            // 
            GUI_button_exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GUI_button_exit.Location = new Point(367, 231);
            GUI_button_exit.Name = "GUI_button_exit";
            GUI_button_exit.Size = new Size(120, 33);
            GUI_button_exit.TabIndex = 7;
            GUI_button_exit.Text = "Завершить";
            GUI_button_exit.UseVisualStyleBackColor = true;
            GUI_button_exit.Click += GUI_button_exit_Click;
            // 
            // GUI_label_5
            // 
            GUI_label_5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GUI_label_5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            GUI_label_5.Location = new Point(13, 57);
            GUI_label_5.Name = "GUI_label_5";
            GUI_label_5.Size = new Size(469, 55);
            GUI_label_5.TabIndex = 5;
            GUI_label_5.Text = "Установка контента успешно завершена, пожалуйста, выберите параметры";
            // 
            // GUI_label_4
            // 
            GUI_label_4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GUI_label_4.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GUI_label_4.Location = new Point(8, 12);
            GUI_label_4.Name = "GUI_label_4";
            GUI_label_4.Size = new Size(474, 45);
            GUI_label_4.TabIndex = 6;
            GUI_label_4.Text = "Завершение";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 300);
            Controls.Add(GUI_tabs);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Установщик Прототип";
            Load += Form1_Load;
            Shown += Form1_Shown;
            GUI_tabs.ResumeLayout(false);
            GUI_tabs_tab1.ResumeLayout(false);
            GUI_tabs_tab1.PerformLayout();
            GUI_tabs_tab2.ResumeLayout(false);
            GUI_tabs_tab2.PerformLayout();
            GUI_tabs_tab3.ResumeLayout(false);
            GUI_tabs_tab3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl GUI_tabs;
        private TabPage GUI_tabs_tab1;
        private TabPage GUI_tabs_tab2;
        private Button GUI_button_install;
        private TabPage GUI_tabs_tab3;
        private Button GUI_button_choosepath;
        private Label GUI_label_path;
        private Label GUI_label_1;
        private FolderBrowserDialog folderDialog;
        private Label GUI_label_2;
        private Label GUI_label_3;
        private Label GUI_progress_label;
        private ProgressBar GUI_progress_bar;
        private Label GUI_label_5;
        private Label GUI_label_4;
        private Button GUI_button_exit;
        private CheckBox GUI_checkbox_runwithexit;
        private CheckBox GUI_checkbox_createdesktop;
    }
}
