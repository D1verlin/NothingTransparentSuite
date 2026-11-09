# Installation Guide

This guide covers installing and configuring the **Nothing Transparent Suite** on Windows 10/11.

---

## Prerequisites

1. **Rainmeter 4.5+ or 5.0+ (64-bit)**
   - Download the latest release from [rainmeter.net](https://www.rainmeter.net/).
2. **.NET 9.0 Desktop Runtime** (for running the standalone `NothingConfig` app)
   - Download from [microsoft.com/net](https://dotnet.microsoft.com/download/dotnet/9.0).
3. **WebNowPlaying Browser Extension** (for Media Player tracking YouTube, Yandex Music, Spotify Web)
   - Chrome / Brave / Edge: [WebNowPlaying Companion on Chrome Web Store](https://chromewebstore.google.com/detail/webnowplaying-companion/jfakgfcdgpghbbefmfljkbdlibifomfo)
   - Firefox: [WebNowPlaying Companion for Firefox](https://addons.mozilla.org/en-US/firefox/addon/webnowplaying-companion/)

---

## Method 1: Automatic 1-Click Install (.rmskin) — Recommended

1. Download the latest `NothingTransparentSuite-v1.0.0.rmskin` from the [Releases](https://github.com/D1verlin/NothingTransparentSuite/releases) section.
2. Double-click the `.rmskin` file.
3. Rainmeter's Skin Installer will launch:
   - Ensure **Load included skins** is checked.
   - Click **Install**.
4. All skins, embedded fonts (`NDot 55`, `NDot 57`, `Inter`), and plugins (`FrostedGlass.dll`, `WebNowPlaying.dll`) will be installed automatically into your Rainmeter skins directory.

---

## Method 2: Manual Installation from Source

1. Clone or download this repository.
2. Copy the folder `src/Rainmeter/Skins/NothingTransparentSuite` into your Rainmeter skins directory:
   ```text
   %USERPROFILE%\Documents\Rainmeter\Skins\NothingTransparentSuite
   ```
3. Install the included fonts located in `@Resources\Fonts`:
   - `ndot_55.otf`
   - `ndot_57.otf`
   - `Inter-Regular.ttf`
   - `Inter-SemiBold.ttf`
   *(Right-click each font and select "Install for all users")*.
4. Open Rainmeter, right-click the Rainmeter tray icon, and click **Refresh All**.
5. Expand `NothingTransparentSuite` in the Rainmeter Manager and load the desired widgets (`Clock.ini`, `System.ini`, etc.).

---

## Enabling Windows Acrylic Blur (Frosted Glass)

By default, the suite utilizes the `FrostedGlass` plugin.
To toggle between Acrylic Blur and Clean Glass:
1. Open the **NothingConfig** configurator (click the red dot in the Clock widget, or run `NothingConfig.exe`).
2. Go to the **DESIGN & GLASS** tab.
3. Toggle the **Windows Acrylic Blur** switch on or off, or adjust the Glass Opacity slider.
4. Click **ПРИМЕНИТЬ И ПЕРЕЗАПУСТИТЬ** (Apply).
