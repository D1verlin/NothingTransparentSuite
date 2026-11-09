# ✦ Nothing Transparent Suite v1.0.0

Комплекс прозрачных монохромных виджетов для Rainmeter в аутентичной эстетике Nothing OS со встроенным конфигуратором NothingConfig.

---

## 📦 Что скачивать и в чем разница

| Файл | Для кого и зачем |
| :--- | :--- |
| **`NothingTransparentSuite-v1.0.0.rmskin`** *(Рекомендуется)* | **Полный комплект сюиты в 1 клик.** Устанавливает все 8 виджетов, встроенные шрифты (NDot 55, NDot 57, Inter), плагины (FrostedGlass, WebNowPlaying) и приложение-конфигуратор. Ничего вручную копировать не нужно. |
| **`NothingConfig.exe`** | **Автономное приложение для настройки.** Одиночный портативный `.exe` файл (~1.3 МБ). Нужен, если вы хотите иметь быстрый ярлык для настройки параметров виджетов или обновляете только программу конфигурации без переустановки скинов. |

---

## 🚀 Пошаговое руководство: что куда класть и как настроить

### Шаг 1. Автоматическая установка (1 клик)
1. Убедитесь, что у вас установлен **[Rainmeter 4.5+ или 5.0+](https://www.rainmeter.net/)** (64-bit).
2. Скачайте файл **`NothingTransparentSuite-v1.0.0.rmskin`** из блока Assets ниже.
3. Запустите скачанный файл двойным кликом мыши.
4. В открывшемся окне *Rainmeter Skin Installer* оставьте галочку **Apply included layout** (или Load included skins) и нажмите **Install**.
   > *Rainmeter сам автоматически распакует всё в правильную системную папку: `%USERPROFILE%\Documents\Rainmeter\Skins\NothingTransparentSuite`.*

### Шаг 1 (альтернативный). Если устанавливаете вручную из исходников
Если вы скачали исходный архив `.zip` с кодом:
1. Распакуйте папку `NothingTransparentSuite` в:
   ```text
   C:\Users\<ВашеИмя>\Documents\Rainmeter\Skins\NothingTransparentSuite
   ```
2. Откройте внутри папку `@Resources\Fonts` и установите 4 шрифта (`ndot_55.otf`, `ndot_57.otf`, `Inter-Regular.ttf`, `Inter-SemiBold.ttf`) в Windows (клик правой кнопкой мыши -> *Установить для всех пользователей*).
3. Правый клик по значку Rainmeter в трее -> **Обновить всё** (Refresh All).

---

### Шаг 2. Настройка погоды (в 1 клик)
1. Откройте приложение **NothingConfig** (кликните по **красной точке** в виджете часов или запустите `NothingConfig.exe`).
2. Перейдите на вкладку **«МОДУЛИ»**.
3. В блоке «ПОГОДА» нажмите кнопку **«📍 ОПРЕДЕЛИТЬ АВТОМАТИЧЕСКИ»** — программа сама найдет ваш город и точные координаты по IP.
   *Либо введите название города по-русски (например, «Москва» или «Минск») и нажмите кнопку **«НАЙТИ»**.*
4. Нажмите большую красную кнопку внизу: **«ПРИМЕНИТЬ И ПЕРЕЗАПУСТИТЬ»**.

---

### Шаг 3. Настройка медиаплеера (YouTube, Яндекс.Музыка, Spotify, VK)
Виджет плеера работает через плагин `WebNowPlaying` и считывает треки прямо из вашего браузера:
1. Установите бесплатное расширение **WebNowPlaying Companion** для вашего браузера:
   - **Chrome / Яндекс / Brave / Edge:** [Установить из Chrome Web Store](https://chromewebstore.google.com/detail/webnowplaying-companion/jfakgfcdgpghbbefmfljkbdlibifomfo)
   - **Firefox:** [Установить из Firefox Add-ons](https://addons.mozilla.org/en-US/firefox/addon/webnowplaying-companion/)
2. Включите любой трек в браузере — виджет отобразит название, автора, обложку и шкалу перемотки.
3. *Если вы слушаете музыку через Win32-плеер (AIMP, foobar2000, WMP):*
   В `NothingConfig` -> вкладка «МОДУЛИ» -> переключите плеер на **«Локальный плеер (NowPlaying)»**.

---

### Шаг 4. Настройка размытия стекла (Frosted Glass)
В разных версиях Windows 11 аппаратный эффект акрила DWM может вести себя по-разному:
- **Если стекло отображается красиво:** оставьте включенным.
- **Если вы видите прямоугольный ореол вокруг закругленных углов:**
  Откройте `NothingConfig` -> вкладка **«ДИЗАЙН И СТЕКЛО»** -> выключите тумблер **«Эффект Windows Acrylic Blur»** и нажмите **«Применить»**. Сюита переключится на идеально чистый Direct2D матовый режим без артефактов.

---

### Шаг 5. Список задач (Todo)
- **Левый клик по задаче:** вычеркнуть как выполненную.
- **Правый клик по задаче:** удалить задачу.
- **Кнопка `[+]`:** ввести новую задачу.
- **Кнопка `CLEAR COMPLETED`:** удалить все завершенные задачи.

---

## ✦ English Summary & Quick Start

1. **Install Rainmeter 4.5+ or 5.0+ (64-bit)**.
2. **Download & double-click `NothingTransparentSuite-v1.0.0.rmskin`** to auto-install all skins, fonts, plugins, and the configurator.
3. **Launch `NothingConfig.exe`** (or click the red dot in the Clock widget) to configure:
   - **Weather:** Click `📍 ОПРЕДЕЛИТЬ АВТОМАТИЧЕСКИ` to auto-detect coordinates by IP.
   - **Media Player:** Install the **WebNowPlaying Companion** browser extension for YouTube/Spotify/Yandex Music tracking.
   - **Design:** Toggle Windows Acrylic blur or adjust card corner radius and opacity.
