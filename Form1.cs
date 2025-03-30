using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

namespace UnpackerPrototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ��������� ���������� � ����� ��� ���������
        public string installPath_VAR = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

        // ===============================================

        // ����� ������� ����� ������� ��� ������
        // � ��� �� ������ ���� ��������� �����
        // �� ���������: package/Stray/Stray.exe
        // ���������: package/Stray.exe
        public string foldername = "Stray";

        // ���� � ������������ �����
        public string executable = "Stray.exe";

        // ��� ��� ������ �� ������� �����
        public string desktopname = "��������� Stray";

        // ===============================================

        // ������� ��������� � ����������
        private async void installMainFunc(string installPath_VAR)
        {

            try
            {

                // ���������, ���������� �� ��� �������
                if (Directory.Exists($"{installPath_VAR}/{foldername}"))
                {

                    // ���������� ������������
                    DialogResult result = MessageBox.Show("������� ������� �� ������ ����������, ��� ���� � ��������� ���� �����, ������ �� �� ������� ������� ���, � ����� ����������?", "���������", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // ����� ������
                    switch (result)
                    {

                        // ���� ��
                        case DialogResult.Yes:

                            // ��������
                            Directory.Delete($"{installPath_VAR}/{foldername}", true);

                            break;
                    }
                }

                // ��������� ����� ��� ������
                using (var archive = ZipFile.OpenRead("package"))
                {

                    // ������ ���������� ����������
                    long totalBytes = archive.Entries.Sum(e => e.Length);

                    // ��� ������������� ����������
                    long extractedBytes = 0;

                    // ������
                    var stopwatch = Stopwatch.StartNew();

                    // ������������� ���������
                    this.Invoke((MethodInvoker)(() =>
                    {
                        GUI_progress_bar.Maximum = 100;
                        GUI_progress_bar.Value = 0;
                        GUI_progress_label.Text = $"���� ���������... 0.0 MB �� {totalBytes / (1024.0 * 1024.0):F1} MB";
                    }));

                    // ���������� ��� ����� � ������
                    foreach (var entry in archive.Entries)
                    {
                        // ���������� ����������
                        if (entry.FullName.EndsWith("/"))
                        {

                            // ������� ����������
                            Directory.CreateDirectory(Path.Combine(installPath_VAR + $"/{foldername}/", entry.FullName));
                            continue;
                        }

                        // ������ ���� ��� ����������
                        string destPath = Path.Combine(installPath_VAR + $"/{foldername}/", entry.FullName);

                        // ������� ��������� ����������
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        // ���������� � �������� �����
                        using (var entryStream = entry.Open())
                        using (var fileStream = File.Create(destPath))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;

                            while ((bytesRead = await entryStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                extractedBytes += bytesRead;

                                // ��������� UI ������ 50ms ��� ��� ���������� �����
                                if (stopwatch.ElapsedMilliseconds > 50 || bytesRead < buffer.Length)
                                {

                                    // ������ ��������� ��� GUI_progress_bar
                                    int progress = (int)((extractedBytes * 100) / totalBytes);

                                    // ���������������� ����������
                                    this.Invoke((MethodInvoker)(() =>
                                    {
                                        GUI_progress_bar.Value = Math.Min(progress, 100);
                                        GUI_progress_label.Text =
                                            $"���� ���������... {extractedBytes / (1024.0 * 1024.0):F1} MB " +
                                            $"�� {totalBytes / (1024.0 * 1024.0):F1} MB ";

                                    }));

                                    // ������������� ������
                                    stopwatch.Restart();
                                }
                            }
                        }
                    }

                    // ����� ����������
                    this.Invoke((MethodInvoker)(() =>
                    {

                        // ��������� UI
                        GUI_progress_label.Text = "���������� ���������!";
                        GUI_progress_bar.Value = 100;

                        // ��������� �������
                        GUI_tabs_tab2.Enabled = false; GUI_tabs_tab2.Hide();

                        // �������� �������
                        GUI_tabs_tab3.Enabled = Enabled; GUI_tabs_tab3.Show();

                        // ��������� �� �������
                        GUI_tabs.SelectedTab = GUI_tabs_tab3;

                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    GUI_progress_label.Text = $"������: {ex.Message}";
                }));
            }
        }

        // ������� �� ������ "����������" � ������ �������
        private void GUI_button_install_Click(object sender, EventArgs e)
        {

            // �������� ������ ������� � ����������
            GUI_tabs_tab1.Enabled = false; GUI_tabs_tab1.Hide();

            // �������� ������ ������� � ����������
            GUI_tabs_tab2.Enabled = true; GUI_tabs_tab2.Show();

            // ��������� �� ������ ������� � ����������
            GUI_tabs.SelectedTab = GUI_tabs_tab2;

            // ������ ���������
            installMainFunc(installPath_VAR);

        }

        // ����� ����� �� ����� ���������� ����� ��������� ���������
        private void Form1_Shown(object sender, EventArgs e)
        {

            // �������� ������ ������� � ����������
            GUI_tabs_tab2.Enabled = false; GUI_tabs_tab2.Hide();

            // �������� ������ ������� � �����������
            GUI_tabs_tab3.Enabled = false; GUI_tabs_tab3.Hide();

            // ���������� � label
            GUI_label_path.Text = installPath_VAR;

        }

        // ������� �� ������ ������ ���� � ������ ������� � ����������
        private void GUI_button_choosepath_Click(object sender, EventArgs e)
        {

            // ��������� �������
            folderDialog.Description = "�������� ���� ��� ���������";
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderDialog.ShowNewFolderButton = true;

            // ���������� ������ � ��������� ���������
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {

                // ��������� � ���������� ���������� ��������� ����
                installPath_VAR = folderDialog.SelectedPath;

                // ���������� � label
                GUI_label_path.Text = installPath_VAR;

                // �������� ������ ���������
                GUI_button_install.Enabled = Enabled;

                // ����� �� �������
                return;
            }
        }

        // ����� ����� ����������� � �� ����������
        private void Form1_Load(object sender, EventArgs e)
        {

            // ���� �������� ���� "ZIP", ��� �����������
            if (!File.Exists("package"))
            {

                // �������� ������
                MessageBox.Show("����� ����������� ����������!", "������ ���������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // ��������� ���������
                Environment.Exit(0);
            }
        }

        // ������ ������ �� ����������
        private void GUI_button_exit_Click(object sender, EventArgs e)
        {

            // �������� �������� ������ �� ������� �����
            if (GUI_checkbox_createdesktop.Checked)
            {
                try
                {

                    // ������� ����� �� ������� �����
                    using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + $"/{desktopname}.url"))
                    {

                        // ��������� �������� ��� ������
                        writer.WriteLine("[InternetShortcut]");
                        writer.WriteLine($"URL=file:///{installPath_VAR}/{foldername}/{executable}");
                        writer.WriteLine("IconIndex=0");
                        writer.WriteLine("IconFile=" + $"{installPath_VAR}/{foldername}/{executable}");
                        writer.WriteLine($"WorkingDirectory={installPath_VAR}/{foldername}");
                    }

                }
                catch (Exception ex)
                {

                    // ��������� ������
                    MessageBox.Show($"��������� ������, �� ������� ������� ����� �� ������� �����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            // �������� ������ ����� ���������
            if (GUI_checkbox_runwithexit.Checked)
            {
                // ��������� � ��������� ��������
                string programPath = $"{installPath_VAR}/{foldername}/{executable}";

                // ������ ���������
                Process.Start(new ProcessStartInfo(programPath) { UseShellExecute = true, WorkingDirectory = Path.GetDirectoryName(programPath) });
            }

            // ��������� ����������
            Environment.Exit(0);
        }
    }
}
