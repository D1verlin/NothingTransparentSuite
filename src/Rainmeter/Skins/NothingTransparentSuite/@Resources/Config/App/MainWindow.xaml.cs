using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace NothingTransparentSuite.Config {
    public partial class MainWindow : Window {
        private string variablesPath = "";
        private string rainmeterIniPath = "";
        private string rainmeterExePath = @"C:\Program Files\Rainmeter\Rainmeter.exe";

        private TextBox[] txtAppNames = new TextBox[6];
        private TextBox[] txtAppPaths = new TextBox[6];
        private static readonly HttpClient httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };

        public MainWindow() {
            InitializeComponent();
            InitializePaths();
            BuildShortcutsRows();
            LoadConfiguration();
        }

        private void InitializePaths() {
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            variablesPath = Path.Combine(docs, @"Rainmeter\Skins\NothingTransparentSuite\@Resources\Include\Variables.inc");
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            rainmeterIniPath = Path.Combine(appData, @"Rainmeter\Rainmeter.ini");
        }

        private void BuildShortcutsRows() {
            PnlShortcutsRows.Children.Clear();
            PnlShortcutsRows.RowDefinitions.Clear();
            PnlShortcutsRows.ColumnDefinitions.Clear();

            PnlShortcutsRows.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(28) });
            PnlShortcutsRows.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(140) });
            PnlShortcutsRows.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(12) });
            PnlShortcutsRows.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            PnlShortcutsRows.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10) });
            PnlShortcutsRows.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(90) });

            string[] defaultNames = { "BROWSER", "EXPLORER", "TERMINAL", "DISCORD", "CODE", "CONFIG" };
            string[] defaultPaths = { "https://www.google.com", "shell:MyComputerFolder", "powershell.exe", "discord.exe", "code.exe", "#@#Config\\NothingConfig.exe" };

            Style tbStyle = (Style)FindResource("NothingTextBox");
            Style btnStyle = (Style)FindResource("NothingSecondaryButton");

            for (int i = 0; i < 6; i++) {
                PnlShortcutsRows.RowDefinitions.Add(new RowDefinition { Height = new GridLength(46) });

                TextBlock lblNum = new TextBlock {
                    Text = (i + 1).ToString() + ".",
                    FontFamily = (FontFamily)FindResource("FontNDot57"),
                    FontSize = 12,
                    Foreground = (Brush)FindResource("BrushTextSecondary"),
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetRow(lblNum, i);
                Grid.SetColumn(lblNum, 0);
                PnlShortcutsRows.Children.Add(lblNum);

                txtAppNames[i] = new TextBox {
                    Text = defaultNames[i],
                    Style = tbStyle,
                    Margin = new Thickness(0, 4, 0, 4)
                };
                Grid.SetRow(txtAppNames[i], i);
                Grid.SetColumn(txtAppNames[i], 1);
                PnlShortcutsRows.Children.Add(txtAppNames[i]);

                txtAppPaths[i] = new TextBox {
                    Text = defaultPaths[i],
                    Style = tbStyle,
                    Margin = new Thickness(0, 4, 0, 4)
                };
                Grid.SetRow(txtAppPaths[i], i);
                Grid.SetColumn(txtAppPaths[i], 3);
                PnlShortcutsRows.Children.Add(txtAppPaths[i]);

                int index = i;
                Button btnBrowse = new Button {
                    Content = "ОБЗОР...",
                    Style = btnStyle,
                    Margin = new Thickness(0, 4, 0, 4)
                };
                btnBrowse.Click += (s, e) => {
                    var dlg = new OpenFileDialog {
                        Title = "Выберите приложение или файл",
                        Filter = "Программы и ярлыки (*.exe;*.lnk;*.bat)|*.exe;*.lnk;*.bat|Все файлы (*.*)|*.*"
                    };
                    if (dlg.ShowDialog() == true) {
                        txtAppPaths[index].Text = dlg.FileName;
                        if (string.IsNullOrWhiteSpace(txtAppNames[index].Text)) {
                            txtAppNames[index].Text = Path.GetFileNameWithoutExtension(dlg.FileName).ToUpper();
                        }
                    }
                };
                Grid.SetRow(btnBrowse, i);
                Grid.SetColumn(btnBrowse, 5);
                PnlShortcutsRows.Children.Add(btnBrowse);
            }
        }

        private void Header_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void NavTab_Click(object sender, RoutedEventArgs e) {
            TabWidgets.Visibility = Visibility.Collapsed;
            TabDesign.Visibility = Visibility.Collapsed;
            TabModules.Visibility = Visibility.Collapsed;
            TabShortcuts.Visibility = Visibility.Collapsed;

            if (TabWidgetsBtn.IsChecked == true) TabWidgets.Visibility = Visibility.Visible;
            if (TabDesignBtn.IsChecked == true) TabDesign.Visibility = Visibility.Visible;
            if (TabModulesBtn.IsChecked == true) TabModules.Visibility = Visibility.Visible;
            if (TabShortcutsBtn.IsChecked == true) TabShortcuts.Visibility = Visibility.Visible;
        }

        private void TrkCornerRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (LblRadiusVal != null) {
                int r = (int)TrkCornerRadius.Value;
                LblRadiusVal.Text = r + " px";
                if (PnlLivePreview != null) {
                    PnlLivePreview.CornerRadius = new CornerRadius(r);
                }
            }
        }

        private void TrkGlassAlpha_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (LblAlphaVal != null) {
                byte a = (byte)TrkGlassAlpha.Value;
                LblAlphaVal.Text = a.ToString();
                if (PnlLivePreview != null) {
                    PnlLivePreview.Background = new SolidColorBrush(Color.FromArgb(a, 20, 20, 20));
                }
            }
        }

        private async void BtnAutoDetect_Click(object sender, RoutedEventArgs e) {
            try {
                TxtGeoStatus.Text = "Определение местоположения по IP...";
                TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));

                string jsonStr = await httpClient.GetStringAsync("http://ip-api.com/json");
                using var doc = JsonDocument.Parse(jsonStr);
                var root = doc.RootElement;

                if (root.TryGetProperty("status", out var st) && st.GetString() == "success") {
                    string city = root.GetProperty("city").GetString() ?? "MOSCOW";
                    double lat = root.GetProperty("lat").GetDouble();
                    double lon = root.GetProperty("lon").GetDouble();
                    string country = root.TryGetProperty("country", out var c) ? c.GetString() ?? "" : "";

                    TxtCity.Text = city.ToUpper();
                    TxtLat.Text = lat.ToString("F4", CultureInfo.InvariantCulture);
                    TxtLon.Text = lon.ToString("F4", CultureInfo.InvariantCulture);

                    TxtGeoStatus.Text = $"✓ Автоопределение успешно: {city}, {country} ({lat:F2}, {lon:F2})";
                    TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(76, 217, 100));
                } else {
                    TxtGeoStatus.Text = "Не удалось определить по IP, введите город в поиск";
                    TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(215, 25, 32));
                }
            } catch (Exception ex) {
                TxtGeoStatus.Text = "Ошибка сети: " + ex.Message;
                TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(215, 25, 32));
            }
        }

        private void TxtCity_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                SearchCityCoordinates(TxtCity.Text.Trim());
            }
        }

        private void BtnSearchCity_Click(object sender, RoutedEventArgs e) {
            SearchCityCoordinates(TxtCity.Text.Trim());
        }

        private async void SearchCityCoordinates(string query) {
            if (string.IsNullOrWhiteSpace(query)) return;
            try {
                TxtGeoStatus.Text = $"Поиск координат для «{query}»...";
                TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));

                string url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(query)}&count=1&language=ru";
                string jsonStr = await httpClient.GetStringAsync(url);
                using var doc = JsonDocument.Parse(jsonStr);

                if (doc.RootElement.TryGetProperty("results", out var results) && results.GetArrayLength() > 0) {
                    var first = results[0];
                    string name = first.GetProperty("name").GetString() ?? query;
                    double lat = first.GetProperty("latitude").GetDouble();
                    double lon = first.GetProperty("longitude").GetDouble();
                    string country = first.TryGetProperty("country", out var c) ? c.GetString() ?? "" : "";

                    TxtCity.Text = name.ToUpper();
                    TxtLat.Text = lat.ToString("F4", CultureInfo.InvariantCulture);
                    TxtLon.Text = lon.ToString("F4", CultureInfo.InvariantCulture);

                    TxtGeoStatus.Text = $"✓ Найдено: {name}, {country} ({lat:F2}, {lon:F2})";
                    TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(76, 217, 100));
                } else {
                    TxtGeoStatus.Text = $"Город «{query}» не найден, проверьте название";
                    TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(215, 25, 32));
                }
            } catch (Exception ex) {
                TxtGeoStatus.Text = "Ошибка геокодера: " + ex.Message;
                TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(215, 25, 32));
            }
        }

        private void PresetCity_Click(object sender, RoutedEventArgs e) {
            if (sender is Button btn && btn.Tag is string tag) {
                string[] parts = tag.Split('|');
                if (parts.Length == 3) {
                    TxtCity.Text = parts[0];
                    TxtLat.Text = parts[1];
                    TxtLon.Text = parts[2];
                    TxtGeoStatus.Text = $"✓ Выбран пресет: {parts[0]}";
                    TxtGeoStatus.Foreground = new SolidColorBrush(Color.FromRgb(76, 217, 100));
                }
            }
        }

        private void LoadConfiguration() {
            try {
                // Read Variables.inc
                if (File.Exists(variablesPath)) {
                    string[] lines = File.ReadAllLines(variablesPath, Encoding.UTF8);
                    foreach (var line in lines) {
                        string tr = line.Trim();
                        if (tr.StartsWith("EnableBlur=")) ChkEnableBlur.IsChecked = (tr.Split('=')[1].Trim() == "1");
                        if (tr.StartsWith("CornerRadius=")) {
                            if (double.TryParse(tr.Split('=')[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double r)) {
                                TrkCornerRadius.Value = Math.Min(24, Math.Max(0, r));
                            }
                        }
                        if (tr.StartsWith("ColorGlassBg=")) {
                            var parts = tr.Split('=')[1].Trim().Split(',');
                            if (parts.Length >= 4 && double.TryParse(parts[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double a)) {
                                TrkGlassAlpha.Value = Math.Min(230, Math.Max(20, a));
                            }
                        }
                        if (tr.StartsWith("Disk1=")) TxtDisk1.Text = tr.Split('=')[1].Trim();
                        if (tr.StartsWith("Disk2=")) TxtDisk2.Text = tr.Split('=')[1].Trim();
                        if (tr.StartsWith("WeatherCity=")) TxtCity.Text = tr.Split('=')[1].Trim();
                        if (tr.StartsWith("WeatherLatitude=")) TxtLat.Text = tr.Split('=')[1].Trim();
                        if (tr.StartsWith("WeatherLongitude=")) TxtLon.Text = tr.Split('=')[1].Trim();
                        if (tr.StartsWith("PlayerMode=")) {
                            bool isLocal = tr.Split('=')[1].Trim().Equals("Local", StringComparison.OrdinalIgnoreCase);
                            RadPlayerLocal.IsChecked = isLocal;
                            RadPlayerWeb.IsChecked = !isLocal;
                        }

                        for (int i = 0; i < 6; i++) {
                            if (tr.StartsWith("App" + (i + 1) + "Name=")) txtAppNames[i].Text = tr.Split('=')[1].Trim();
                            if (tr.StartsWith("App" + (i + 1) + "Path=")) txtAppPaths[i].Text = tr.Substring(("App" + (i + 1) + "Path=").Length).Trim();
                        }
                    }
                }

                // Read Rainmeter.ini active states
                if (File.Exists(rainmeterIniPath)) {
                    string iniText = File.ReadAllText(rainmeterIniPath, Encoding.Unicode);
                    ChkClock.IsChecked = IsSkinActive(iniText, "Clock");
                    ChkSystem.IsChecked = IsSkinActive(iniText, "System");
                    ChkDisks.IsChecked = IsSkinActive(iniText, "Disks");
                    ChkTodo.IsChecked = IsSkinActive(iniText, "Todo");
                    ChkNetwork.IsChecked = IsSkinActive(iniText, "Network");
                    ChkPlayer.IsChecked = IsSkinActive(iniText, "Player");
                    ChkWeather.IsChecked = IsSkinActive(iniText, "Weather");
                    ChkLauncher.IsChecked = IsSkinActive(iniText, "Launcher");
                }
            } catch (Exception ex) {
                TxtStatus.Text = "ОШИБКА ЧТЕНИЯ: " + ex.Message;
                TxtStatus.Foreground = new SolidColorBrush(Color.FromRgb(255, 140, 0));
            }
        }

        private bool IsSkinActive(string iniText, string skin) {
            var match = Regex.Match(iniText, @"\[NothingTransparentSuite\\" + skin + @"\][\r\n\s]*Active=(\d)", RegexOptions.IgnoreCase);
            return match.Success && match.Groups[1].Value == "1";
        }

        private void SetSkinActive(ref string iniText, string skin, bool active) {
            string pattern = @"(\[NothingTransparentSuite\\" + skin + @"\][\r\n\s]*Active=)\d";
            if (Regex.IsMatch(iniText, pattern, RegexOptions.IgnoreCase)) {
                iniText = Regex.Replace(iniText, pattern, "$1" + (active ? "1" : "0"), RegexOptions.IgnoreCase);
            } else if (active) {
                iniText += "\r\n[NothingTransparentSuite\\" + skin + "]\r\nActive=1\r\nWindowX=840\r\nWindowY=100\r\n";
            }
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e) {
            try {
                // 1. Write Variables.inc
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("[Variables]");
                sb.AppendLine("; ===================================================================");
                sb.AppendLine("; NothingTransparentSuite - Configured via NothingConfig");
                sb.AppendLine("; ===================================================================");
                sb.AppendLine("EnableBlur=" + (ChkEnableBlur.IsChecked == true ? "1" : "0"));
                sb.AppendLine("FontDotBold=NDot 57");
                sb.AppendLine("FontDotReg=NDot 55");
                sb.AppendLine("FontUI=Inter");
                sb.AppendLine("FontUIBold=Inter SemiBold");
                sb.AppendLine("ColorPrimary=255,255,255,255");
                sb.AppendLine("ColorSecondary=255,255,255,160");
                sb.AppendLine("ColorMuted=255,255,255,45");
                sb.AppendLine("ColorGlassBg=14,14,14," + ((int)TrkGlassAlpha.Value));
                sb.AppendLine("ColorBorder=255,255,255,38");
                sb.AppendLine("ColorAccent=215,25,32,255");
                sb.AppendLine("ColorDone=255,255,255,90");
                sb.AppendLine("CardWidth=300");
                sb.AppendLine("CornerRadius=" + ((int)TrkCornerRadius.Value));
                sb.AppendLine("Padding=16");
                sb.AppendLine("Disk1=" + TxtDisk1.Text.Trim());
                sb.AppendLine("Disk2=" + TxtDisk2.Text.Trim());
                sb.AppendLine("WeatherLatitude=" + TxtLat.Text.Trim());
                sb.AppendLine("WeatherLongitude=" + TxtLon.Text.Trim());
                sb.AppendLine("WeatherCity=" + TxtCity.Text.Trim().ToUpper());
                sb.AppendLine("WeatherUnits=metric");
                sb.AppendLine("PlayerMode=" + (RadPlayerLocal.IsChecked == true ? "Local" : "Web"));
                sb.AppendLine("PlayerName=WMP");

                for (int i = 0; i < 6; i++) {
                    sb.AppendLine("App" + (i + 1) + "Name=" + txtAppNames[i].Text.Trim());
                    sb.AppendLine("App" + (i + 1) + "Path=" + txtAppPaths[i].Text.Trim());
                }

                File.WriteAllText(variablesPath, sb.ToString(), new UTF8Encoding(true));

                // 2. Write Rainmeter.ini
                if (File.Exists(rainmeterIniPath)) {
                    string iniText = File.ReadAllText(rainmeterIniPath, Encoding.Unicode);
                    SetSkinActive(ref iniText, "Clock", ChkClock.IsChecked == true);
                    SetSkinActive(ref iniText, "System", ChkSystem.IsChecked == true);
                    SetSkinActive(ref iniText, "Disks", ChkDisks.IsChecked == true);
                    SetSkinActive(ref iniText, "Todo", ChkTodo.IsChecked == true);
                    SetSkinActive(ref iniText, "Network", ChkNetwork.IsChecked == true);
                    SetSkinActive(ref iniText, "Player", ChkPlayer.IsChecked == true);
                    SetSkinActive(ref iniText, "Weather", ChkWeather.IsChecked == true);
                    SetSkinActive(ref iniText, "Launcher", ChkLauncher.IsChecked == true);
                    File.WriteAllText(rainmeterIniPath, iniText, Encoding.Unicode);
                }

                // 3. Refresh Rainmeter
                if (File.Exists(rainmeterExePath)) {
                    Process.Start(rainmeterExePath, "!RefreshApp");
                }

                TxtStatus.Text = "✓ НАСТРОЙКИ УСПЕШНО ПРИМЕНЕНЫ И СОХРАНЕНЫ";
                TxtStatus.Foreground = new SolidColorBrush(Color.FromRgb(76, 217, 100));
            } catch (Exception ex) {
                TxtStatus.Text = "ОШИБКА: " + ex.Message;
                TxtStatus.Foreground = new SolidColorBrush(Color.FromRgb(215, 25, 32));
            }
        }
    }
}
