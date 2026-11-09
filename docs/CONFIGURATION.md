# Configuration Guide

The **Nothing Transparent Suite** is designed around a single centralized configuration architecture. All visual styling, operational parameters, and shortcuts are stored in a single unified include file:

```text
@Resources\Include\Variables.inc
```

You can customize the suite either using the **NothingConfig** GUI app or by editing `Variables.inc` directly in a text editor.

---

## 1. Using NothingConfig (GUI)

The suite includes a native WPF (.NET 9) configurator application styled in the authentic Nothing OS aesthetic.

### How to Launch NothingConfig
- **Method A:** Click the red accent dot in the top-right corner of the **Clock** widget.
- **Method B:** Click the **SETTINGS** button in the **Quick Launch Dock** widget.
- **Method C:** Double-click `NothingConfig.exe` on your Desktop or in `@Resources\Config\NothingConfig.exe`.

### Tabs & Capabilities

| Tab | Features |
| :--- | :--- |
| **WIDGETS** | Bento grid with toggle switches to turn individual widgets on/off in real-time. |
| **DESIGN & GLASS** | Toggle Windows Acrylic blur, adjust corner radius (0–24px), glass opacity (10–230), and live visual card preview. |
| **MODULES** | **Weather:** 1-click IP auto-detection button (`📍 ОПРЕДЕЛИТЬ АВТОМАТИЧЕСКИ`), city geocoding search (`НАЙТИ`), and quick city presets.<br>**Disks:** Assign drive letters (e.g. `C:`, `D:`, `E:`).<br>**Media Player:** Switch between `Web` (browser WebNowPlaying) and `Local` (Win32 NowPlaying). |
| **SHORTCUTS** | Configure labels and file paths / URLs for all 6 Quick Launch dock buttons, with a file picker dialog (`...`). |

---

## 2. Variables.inc Specification

If you prefer editing the configuration manually, open `@Resources\Include\Variables.inc` with an editor that preserves **UTF-8 with BOM** (such as VS Code or Notepad++):

```ini
[Variables]
; --- Appearance & Visual Effects ---
; 1 = Enable Windows Acrylic blur behind cards
; 0 = Pure Direct2D smooth glass cards (No rectangular blur halo)
EnableBlur=1

; --- Typography (Exact Windows Font Family Names) ---
FontDotBold=NDot 57
FontDotReg=NDot 55
FontUI=Inter
FontUIBold=Inter SemiBold

; --- Color Palette (R,G,B,A) ---
ColorPrimary=255,255,255,255      ; 100% white for clock, titles, active meters
ColorSecondary=255,255,255,160    ; 63% white for secondary labels and subtitles
ColorMuted=255,255,255,45         ; 18% white for progress bar background tracks
ColorGlassBg=14,14,14,120         ; Dark tinted translucent glass fill
ColorBorder=255,255,255,38        ; 1px subtle frosted card border
ColorAccent=215,25,32,255         ; Signature Nothing Red dot accent (#D71920)
ColorDone=255,255,255,90          ; Strikethrough/completed task color

; --- Widget Geometry ---
CardWidth=300                     ; Universal card width in pixels
CornerRadius=14                   ; Rounded corner radius in pixels
Padding=16                        ; Internal card padding

; --- Disks Settings ---
Disk1=C:
Disk2=D:

; --- Weather Settings (Open-Meteo) ---
WeatherLatitude=52.0901
WeatherLongitude=23.6836
WeatherCity=BREST
WeatherUnits=metric

; --- Media Player Settings ---
; PlayerMode: Web (WebNowPlaying for Chrome/Brave/Edge/Firefox)
;             Local (AIMP, foobar2000, WMP, Winamp)
PlayerMode=Web
PlayerName=WMP

; --- Quick Launcher Shortcuts ---
App1Name=BROWSER
App1Path=https://www.google.com
App2Name=EXPLORER
App2Path=shell:MyComputerFolder
App3Name=TERMINAL
App3Path=powershell.exe
App4Name=DISCORD
App4Path=discord.exe
App5Name=CODE
App5Path=code.exe
App6Name=SETTINGS
App6Path=#@#Config\NothingConfig.exe
```
