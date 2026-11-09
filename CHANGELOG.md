# Changelog

All notable changes to the **Nothing Transparent Suite** project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [1.0.0] - 2026-11-10 (Initial Release)

### Features & Architecture
- **Monochrome Transparent Nothing OS Aesthetic**: Frosted glass surfaces (FrostedGlass Acrylic plugin), fine 1px borders, and signature Nothing Red (`#D71920`) accent.
- **Hardware Acceleration**: Full Direct2D (`UseD2D=1`, `AccurateText=1`) support across all widgets.
- **Official Teardrop Vector Icon**: Pure SVG and multi-resolution Windows Icon (.ico) based on authentic dot-matrix teardrop styling.
- **8 Modular Desktop Widgets**:
  - `Clock`: Matrix digital time (`NDot 57`), date, continuous uptime, and configurator launcher.
  - `System`: Real-time CPU%, RAM GB/%, and GPU 3D utilization with LED matrix dashed bars.
  - `Disks`: Storage usage and active auto-scaled IO throughput (`MB/s`, `KB/s`).
  - `Todo`: Interactive task list on Lua with persistent file storage and clear completed actions.
  - `Network`: Local IP, live download/upload counters, vector line history graph, and transfer stats.
  - `Player`: Browser media tracking (YouTube, Yandex Music, VK, Spotify Web) with vector controls and progress bar.
  - `Weather`: Live weather via Open-Meteo REST API (temperature, condition, feels like, wind, humidity).
  - `Launcher`: 2x3 customizable frosted rounded pill dock shortcuts.
- **NothingConfig**: Standalone WPF (.NET 9) configurator with Bento Grid layout, custom switches, live glass opacity/radius preview, and full Russian localization.
- **Smart Geolocation**: 1-click IP-based coordinate detection and instant city geocoding via Open-Meteo.
- **Package & Distribution**: Automated `.rmskin` generation for 1-click Rainmeter installation.
