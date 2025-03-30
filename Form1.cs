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

        // Публичная переменная с путем для установки
        public string installPath_VAR = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

        // ===============================================

        // Папка которая будет создана для файлов
        // В ней не должно быть вложенной папки
        // НЕ ПРАВИЛЬНО: package/Stray/Stray.exe
        // ПРАВИЛЬНО: package/Stray.exe
        public string foldername = "Stray";

        // Путь к исполняемому файлу
        public string executable = "Stray.exe";

        // Имя для ярлыка на рабочем столе
        public string desktopname = "Запустить Stray";

        // ===============================================

        // Функция установки и распаковки
        private async void installMainFunc(string installPath_VAR)
        {

            try
            {

                // Проверяем, установлен ли уже контент
                if (Directory.Exists($"{installPath_VAR}/{foldername}"))
                {

                    // Спрашиваем пользователя
                    DialogResult result = MessageBox.Show("Контент который вы хотите установить, уже есть в выбранной вами папке, хотите ли вы сначала удалить его, а после установить?", "Наложение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    // Выбор ответа
                    switch (result)
                    {

                        // Если Да
                        case DialogResult.Yes:

                            // Удаление
                            Directory.Delete($"{installPath_VAR}/{foldername}", true);

                            break;
                    }
                }

                // Открываем архив для чтения
                using (var archive = ZipFile.OpenRead("package"))
                {

                    // Нужное количество распаковки
                    long totalBytes = archive.Entries.Sum(e => e.Length);

                    // Уже распакованное количество
                    long extractedBytes = 0;

                    // Таймер
                    var stopwatch = Stopwatch.StartNew();

                    // Инициализация прогресса
                    this.Invoke((MethodInvoker)(() =>
                    {
                        GUI_progress_bar.Maximum = 100;
                        GUI_progress_bar.Value = 0;
                        GUI_progress_label.Text = $"Идет установка... 0.0 MB из {totalBytes / (1024.0 * 1024.0):F1} MB";
                    }));

                    // Перебираем все файлы в архиве
                    foreach (var entry in archive.Entries)
                    {
                        // Пропускаем директории
                        if (entry.FullName.EndsWith("/"))
                        {

                            // Создаем директории
                            Directory.CreateDirectory(Path.Combine(installPath_VAR + $"/{foldername}/", entry.FullName));
                            continue;
                        }

                        // Нужный путь для распаковки
                        string destPath = Path.Combine(installPath_VAR + $"/{foldername}/", entry.FullName);

                        // Создаем начальную директорию
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        // Перебираем и копируем файлы
                        using (var entryStream = entry.Open())
                        using (var fileStream = File.Create(destPath))
                        {
                            byte[] buffer = new byte[8192];
                            int bytesRead;

                            while ((bytesRead = await entryStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                extractedBytes += bytesRead;

                                // Обновляем UI каждые 50ms или при завершении файла
                                if (stopwatch.ElapsedMilliseconds > 50 || bytesRead < buffer.Length)
                                {

                                    // Расчет прогресса для GUI_progress_bar
                                    int progress = (int)((extractedBytes * 100) / totalBytes);

                                    // Потокобезопасное обновление
                                    this.Invoke((MethodInvoker)(() =>
                                    {
                                        GUI_progress_bar.Value = Math.Min(progress, 100);
                                        GUI_progress_label.Text =
                                            $"Идет установка... {extractedBytes / (1024.0 * 1024.0):F1} MB " +
                                            $"из {totalBytes / (1024.0 * 1024.0):F1} MB ";

                                    }));

                                    // Перезапускаем таймер
                                    stopwatch.Restart();
                                }
                            }
                        }
                    }

                    // Конец распаковки
                    this.Invoke((MethodInvoker)(() =>
                    {

                        // Обновляем UI
                        GUI_progress_label.Text = "Распаковка завершена!";
                        GUI_progress_bar.Value = 100;

                        // Отключаем вкладку
                        GUI_tabs_tab2.Enabled = false; GUI_tabs_tab2.Hide();

                        // Включаем вкладку
                        GUI_tabs_tab3.Enabled = Enabled; GUI_tabs_tab3.Show();

                        // Переходим во вкладку
                        GUI_tabs.SelectedTab = GUI_tabs_tab3;

                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    GUI_progress_label.Text = $"Ошибка: {ex.Message}";
                }));
            }
        }

        // Нажатие на кнопку "Установить" в первой вкладке
        private void GUI_button_install_Click(object sender, EventArgs e)
        {

            // Скрываем первую вкладку с настройкой
            GUI_tabs_tab1.Enabled = false; GUI_tabs_tab1.Hide();

            // Включаем вторую вкладку с установкой
            GUI_tabs_tab2.Enabled = true; GUI_tabs_tab2.Show();

            // Переходим во вторую влкадку с установкой
            GUI_tabs.SelectedTab = GUI_tabs_tab2;

            // Начало установки
            installMainFunc(installPath_VAR);

        }

        // Когда форма со всеми элементами будет полностью загружена
        private void Form1_Shown(object sender, EventArgs e)
        {

            // Скрываем вторую вкладку с установкой
            GUI_tabs_tab2.Enabled = false; GUI_tabs_tab2.Hide();

            // Скрываем третью вкладку с завершением
            GUI_tabs_tab3.Enabled = false; GUI_tabs_tab3.Hide();

            // Показываем в label
            GUI_label_path.Text = installPath_VAR;

        }

        // Нажатие на кнопку выбора пути в первой вкладке с настройкой
        private void GUI_button_choosepath_Click(object sender, EventArgs e)
        {

            // Настройки диалога
            folderDialog.Description = "Выберите путь для установки";
            folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderDialog.ShowNewFolderButton = true;

            // Показываем диалог и проверяем результат
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {

                // Указываем в глобальную переменную выбранный путь
                installPath_VAR = folderDialog.SelectedPath;

                // Показываем в label
                GUI_label_path.Text = installPath_VAR;

                // Включаем кнопку установки
                GUI_button_install.Enabled = Enabled;

                // Выход из функции
                return;
            }
        }

        // Когда форма загрузилась и не показалась
        private void Form1_Load(object sender, EventArgs e)
        {

            // Ищем упаковый файл "ZIP", без рассширения
            if (!File.Exists("package"))
            {

                // Вызываем ошибку
                MessageBox.Show("Файлы установщика повреждены!", "Ошибка установки", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Закрываем программу
                Environment.Exit(0);
            }
        }

        // Кнопка выхода из приложения
        private void GUI_button_exit_Click(object sender, EventArgs e)
        {

            // Включено создание ярлыка на рабочем столе
            if (GUI_checkbox_createdesktop.Checked)
            {
                try
                {

                    // Создаем ярлык на рабочем столе
                    using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + $"/{desktopname}.url"))
                    {

                        // Вписываем значения для ярлыка
                        writer.WriteLine("[InternetShortcut]");
                        writer.WriteLine($"URL=file:///{installPath_VAR}/{foldername}/{executable}");
                        writer.WriteLine("IconIndex=0");
                        writer.WriteLine("IconFile=" + $"{installPath_VAR}/{foldername}/{executable}");
                        writer.WriteLine($"WorkingDirectory={installPath_VAR}/{foldername}");
                    }

                }
                catch (Exception ex)
                {

                    // Обработка ошибки
                    MessageBox.Show($"Произошла ошибка, не удалось создать ярлык на рабочем столе: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

            // Включено запуск после установки
            if (GUI_checkbox_runwithexit.Checked)
            {
                // Запускаем в отдельном процессе
                string programPath = $"{installPath_VAR}/{foldername}/{executable}";

                // Запуск программы
                Process.Start(new ProcessStartInfo(programPath) { UseShellExecute = true, WorkingDirectory = Path.GetDirectoryName(programPath) });
            }

            // Закрываем установщик
            Environment.Exit(0);
        }
    }
}
