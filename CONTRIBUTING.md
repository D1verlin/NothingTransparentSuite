# Contributing to Nothing Transparent Suite

Thank you for your interest in contributing to **Nothing Transparent Suite**! We welcome contributions that maintain the strict Nothing OS design aesthetic, improve performance, or fix bugs.

---

## Design Principles (Strict Nothing OS Aesthetic)

1. **Monochrome First**: The interface is strictly monochrome (`#FFFFFF` text and shapes with varying opacity `255`, `160`, `45`, `14`) against a dark transparent frosted glass canvas.
2. **Nothing Red Accent (`#D71920`)**: Used exclusively as a singular micro-accent (e.g. status dots, active highlights, key action button). Never use red for large backgrounds or body text.
3. **Typography Rule**:
   - **NDot 57 / 55**: Strictly for numbers, clocks, and uppercase Latin headers/tags (`[ CPU ]`, `STORAGE & IO`). Do NOT use NDot for lowercase Cyrillic as it lacks glyphs.
   - **Inter / Inter SemiBold**: Used for all body text, Cyrillic descriptions, disk paths, and interactive elements.
4. **Hardware Acceleration**: All skins must enforce `UseD2D=1` and `AccurateText=1`.
5. **Card Bounding**: Always specify `SkinWidth=#CardWidth#` and explicit `SkinHeight` in `[Rainmeter]` to prevent Windows DWM Acrylic blur rectangular halo artifacts.

---

## Development Workflow

1. Fork the repository and create your branch from `main`:
   ```bash
   git checkout -b feature/my-new-feature
   ```
2. Make your edits in `src/Rainmeter/Skins/NothingTransparentSuite/`.
3. If modifying the configurator:
   - Solution located in `src/Rainmeter/Skins/NothingTransparentSuite/@Resources/Config/App/`.
   - Build with .NET 9 SDK:
     ```bash
     dotnet build -c Release
     ```
4. Verify all files are saved with **UTF-8 with BOM** (required for Russian Windows compatibility).
5. Open a Pull Request detailing the changes and screenshots of the visual output.
