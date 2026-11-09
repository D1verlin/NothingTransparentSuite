# Nothing Transparent Suite v1.0.0

A unified transparent monochrome Rainmeter desktop suite crafted in the authentic Nothing OS aesthetic.

---

## Available Assets

| File | Purpose | Recommended For |
| :--- | :--- | :--- |
| `NothingTransparentSuite-v1.0.0.rmskin` | Complete package installer. Automatically installs all 8 widgets, required fonts, runtime plugins, and the NothingConfig utility. | All users (standard 1-click installation). |
| `NothingConfig.exe` | Standalone portable configuration utility (single-file executable, ~1.3 MB). | Users managing suite variables without reinstalling skins. |

---

## Prerequisites

1. **Rainmeter 4.5 or 5.0 (64-bit)**
   - Download and install from [rainmeter.net](https://www.rainmeter.net/).
2. **.NET 9.0 Desktop Runtime** (for running the NothingConfig utility)
   - Download from [microsoft.com/net](https://dotnet.microsoft.com/download/dotnet/9.0).
3. **WebNowPlaying Companion Browser Extension** (for YouTube, Spotify Web, and browser media tracking)
   - Chrome / Edge / Brave: [Chrome Web Store](https://chromewebstore.google.com/detail/webnowplaying-companion/jfakgfcdgpghbbefmfljkbdlibifomfo)
   - Firefox: [Firefox Add-ons](https://addons.mozilla.org/en-US/firefox/addon/webnowplaying-companion/)

---

## Installation

### Method A: Automated Installation (.rmskin) — Recommended

1. Download `NothingTransparentSuite-v1.0.0.rmskin` from the Assets section below.
2. Double-click the downloaded `.rmskin` file.
3. In the Rainmeter Skin Installer dialog:
   - Check **Apply included layout** (or **Load included skins**).
   - Click **Install**.
4. Rainmeter automatically extracts and places all files into the correct destination directory:
   ```text
   %USERPROFILE%\Documents\Rainmeter\Skins\NothingTransparentSuite
   ```

### Method B: Manual Installation from Source

If installing from the repository source archive:
1. Extract the `NothingTransparentSuite` directory to:
   ```text
   C:\Users\<YourUsername>\Documents\Rainmeter\Skins\NothingTransparentSuite
   ```
2. Navigate to `@Resources\Fonts` and install all four font files in Windows:
   - `ndot_55.otf`
   - `ndot_57.otf`
   - `Inter-Regular.ttf`
   - `Inter-SemiBold.ttf`
   *(Right-click each font file and select "Install for all users")*.
3. Right-click the Rainmeter tray icon and select **Refresh All**.

---

## Post-Installation Configuration

### 1. Launching the Configurator
Open the NothingConfig utility using any of the following methods:
- Click the red accent dot in the top-right corner of the **Clock** widget.
- Click the **SETTINGS** button in the **Quick Launch Dock** widget.
- Run `NothingConfig.exe` from your desktop or the `@Resources\Config` directory.

### 2. Weather and Geolocation Setup
1. In NothingConfig, select the **MODULES** tab.
2. In the **WEATHER** card, click **AUTO-DETECT LOCATION**. The utility resolves your city name, latitude, and longitude via IP lookup.
   - Alternatively, enter a city name into the **CITY** field and click **SEARCH**.
3. Click the red **APPLY AND RELOAD** button at the bottom of the window to save settings and refresh Rainmeter.

### 3. Media Player Setup
The Media Player widget uses the WebNowPlaying plugin to read media directly from web browsers and local players:
1. Ensure the **WebNowPlaying Companion** extension is enabled in your browser.
2. Start playing media on YouTube, Spotify, Soundcloud, or supported web services. Track information, progress bar, and controls will populate automatically.
3. For local media players (such as AIMP, foobar2000, or Winamp):
   - In NothingConfig -> **MODULES** -> switch media mode to **Local Player (NowPlaying)**.
   - Click **APPLY AND RELOAD**.

### 4. Background Glass and Blur Effects
The suite supports both Windows DWM Acrylic blur and Direct2D clean glass rendering:
- If Windows Acrylic renders cleanly on your hardware, keep **Windows Acrylic Blur** enabled.
- If your system exhibits rectangular halo artifacts around rounded corners (common on specific Windows 11 builds), open NothingConfig -> **DESIGN & GLASS** -> toggle **Windows Acrylic Blur** to **OFF** (`EnableBlur=0`) and click **APPLY AND RELOAD**. This activates hardware-accelerated Direct2D alpha blending with zero boundary artifacts.

### 5. Task List (Todo Widget)
- **Left-click on a task item:** Toggles completion status (strikethrough and dimmed text).
- **Right-click on a task item:** Deletes the item from the list.
- **Click [+] button:** Opens an input prompt to add a new task.
- **Click CLEAR COMPLETED:** Removes all finished tasks.
