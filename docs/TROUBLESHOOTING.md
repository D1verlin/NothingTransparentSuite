# Troubleshooting & FAQ

This document addresses common questions and troubleshooting steps for the **Nothing Transparent Suite**.

---

## 1. Blurred Halos or Rectangular Boxes Behind Cards

### Symptom
On certain versions of Windows 11 with DWM Acrylic enabled, you may notice a faint rectangular blurred area extending beyond the rounded card corners.

### Cause & Solution
Rainmeter's `FrostedGlass` plugin tells Windows DWM to blur the entire OS window handle (HWND).
1. We have already mitigated this by specifying `SkinWidth=#CardWidth#` and `SkinHeight=...` on all skins.
2. If your GPU or Windows build still exhibits minor DWM halo bleeding:
   - Open **NothingConfig**.
   - Navigate to **DESIGN & GLASS**.
   - Toggle **Windows Acrylic Blur** to **OFF** (`EnableBlur=0`).
   - Click **Apply**.
   - This switches the suite to Direct2D hardware alpha blending, producing razor-sharp rounded corners with zero halo effect.

---

## 2. Media Player Shows "No Web Media Playing"

### Cause
The `WebNowPlaying` plugin communicates with your web browser via a local websocket port (`8974`). If the browser companion extension is not active, the player cannot receive track info.

### Solution
1. Ensure you have installed the **WebNowPlaying Companion** extension in your browser:
   - [Chrome / Brave / Edge Extension](https://chromewebstore.google.com/detail/webnowplaying-companion/jfakgfcdgpghbbefmfljkbdlibifomfo)
   - [Firefox Extension](https://addons.mozilla.org/en-US/firefox/addon/webnowplaying-companion/)
2. Open YouTube, Yandex Music, or Spotify Web and start playback.
3. If using local media players (e.g. AIMP, foobar2000, Winamp):
   - Open **NothingConfig** -> **MODULES**.
   - Select **Локальный плеер (Win32 NowPlaying)**.
   - Click **Apply**.

---

## 3. Fonts Look Default or Misaligned (Arial / Segoe UI)

### Cause
Rainmeter requires fonts to be registered in the Windows font cache or placed in `@Resources\Fonts`.

### Solution
1. In Windows Explorer, open `@Resources\Fonts`.
2. Select all four font files:
   - `ndot_55.otf`
   - `ndot_57.otf`
   - `Inter-Regular.ttf`
   - `Inter-SemiBold.ttf`
3. Right-click and choose **Install for all users** (or **Install**).
4. Right-click the Rainmeter tray icon and select **Refresh All**.

---

## 4. Weather Fails to Load or Shows Blank

### Cause
1. Internet connectivity issue or invalid coordinates.
2. Open-Meteo API query was rate-limited or blocked by firewall.

### Solution
1. Open **NothingConfig** -> **MODULES**.
2. Click **📍 ОПРЕДЕЛИТЬ АВТОМАТИЧЕСКИ** to refresh your exact coordinates.
3. Click **ПРИМЕНИТЬ И ПЕРЕЗАПУСТИТЬ**.
4. In the Weather widget, click the **UPDATE** button in the lower-right corner to force a refresh.

---

## 5. System Monitor GPU Percentage Shows 0%

### Cause
Windows Performance Counter for `GPU Engine` requires an active 3D application or hardware acceleration enabled in Windows Display Settings.

### Solution
The `System.ini` widget reads `GPU Engine(*3D*)\Utilization Percentage`. When the desktop is idle, GPU 3D utilization is naturally near 0%. Launch a video in a browser or a 3D game to verify that the GPU meter responds dynamically.
