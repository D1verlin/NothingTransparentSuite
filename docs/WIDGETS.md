# Widgets Reference

The **Nothing Transparent Suite** includes 8 modular desktop widgets built with hardware-accelerated Direct2D vector graphics.

---

## 1. Clock & Date (`Clock\Clock.ini`)
- **Dimensions:** Width = 300px, Height = 132px.
- **Features:**
  - Extra-large 48pt matrix digital clock in `NDot 57`.
  - Uppercase day of week, day, and month in `Inter SemiBold`.
  - System continuous uptime counter (`D h m`).
  - Interactive **Nothing Red Dot** in the top right: clicking launches the `NothingConfig` app.

---

## 2. System Hardware Monitor (`System\System.ini`)
- **Dimensions:** Width = 300px, Height = 162px.
- **Measures & Metrics:**
  - **CPU Load:** Real-time percentage via native Rainmeter `CPU` measure.
  - **RAM Memory:** Consumed physical RAM (in GB) and percentage bar.
  - **GPU Engine:** GPU 3D engine utilization percentage calculated via `UsageMonitor` performance counters.
  - **Dotted Matrix Progress Bars:** Vector dashed shapes (`StrokeDashes 1,1.5`) mimicking physical LED matrix pixels.

---

## 3. Storage & IO (`Disks\Disks.ini`)
- **Dimensions:** Width = 300px, Height = 162px.
- **Measures & Metrics:**
  - Dual disk monitor (configurable drive letters, default `C:` and `D:`).
  - Free space formatted in GB and percentage of used space.
  - Disk Read and Write I/O activity rates with auto-scaling units (`MB/s`, `KB/s`, `B/s`) via `UsageMonitor`.
  - Interactive action: click on any drive line to open Windows File Explorer to that drive root.

---

## 4. Tasks & Todo List (`Todo\Todo.ini`)
- **Dimensions:** Width = 300px, Height = 252px.
- **Engine:** Driven by `@Resources\Scripts\Todo.lua` with persistent storage in `@Resources\UserData\tasks.txt`.
- **Features:**
  - 4 visible task slots with real-time completion counter `(Done/Total)`.
  - Left-click a task slot: toggles done state (strikethrough and dimmed text).
  - Right-click a task slot: deletes the task.
  - `[+]` button: prompts for a new task using Windows PowerShell input dialog.
  - `CLEAR COMPLETED`: cleans up all finished tasks in 1 click.
  - `RELOAD`: refreshes task list from disk.

---

## 5. Network Traffic (`Network\Network.ini`)
- **Dimensions:** Width = 300px, Height = 195px.
- **Measures & Metrics:**
  - Local IPv4 network adapter detection.
  - Real-time Download (`DL`) and Upload (`UL`) transfer speeds.
  - Continuous vector line histogram (`Meter=Line`) showing network activity over time.
  - Session cumulative bandwidth transfer counter (`TOTAL: ↓ ... ↑ ...`).
  - `RESET STATS`: resets cumulative bandwidth counters.

---

## 6. Media Player (`Player\Player.ini`)
- **Dimensions:** Width = 300px, Height = 172px.
- **Engine:** Powered by `WebNowPlaying.dll` (with browser companion extension) and `NowPlaying.dll` fallback.
- **Features:**
  - Supports YouTube, Yandex Music, VK, Soundcloud, Spotify (Web & Desktop), Tidal, Deezer.
  - Displays Album Art thumbnail, Track Title, and Artist with automatic text truncation.
  - Interactive dotted progress bar: click anywhere along the track bar to seek.
  - Sleek geometric vector buttons: Previous track, Play / Pause toggle, Next track with hover lighting effects.

---

## 7. Weather & Forecast (`Weather\Weather.ini`)
- **Dimensions:** Width = 300px, Height = 155px.
- **Engine:** Direct REST integration with Open-Meteo API (`api.open-meteo.com`) without requiring API keys.
- **Features:**
  - Current temperature in big matrix `NDot 57` font.
  - Dynamic weather condition mapping (e.g. `CLEAR SKY`, `OVERCAST`, `RAIN`, `SNOW`, `THUNDERSTORM`).
  - Secondary details: apparent "feels like" temperature, wind speed (`km/h`), and relative humidity (`%`).
  - `UPDATE` button to manually force-refresh weather data.

---

## 8. Quick Launch Dock (`Launcher\Launcher.ini`)
- **Dimensions:** Width = 300px, Height = 184px.
- **Features:**
  - 2x3 grid of frosted rounded pill buttons.
  - Fully customizable names and targets (web URLs, `.exe` executables, Windows shell shortcuts).
  - Hover highlight transitions.
  - Default presets: Browser, Explorer, Terminal, Discord, Code, Settings.
