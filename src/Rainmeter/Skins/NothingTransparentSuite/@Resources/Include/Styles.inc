[MeasureFrostedGlass]
Measure=Plugin
Plugin=FrostedGlass
Type=(#EnableBlur# = 1 ? "Acrylic" : "None")
Border=None
DynamicVariables=1

; ===================================================================
; Meter Styles - Typography and Visuals
; ===================================================================

[StyleHeaderNdot]
FontFace=#FontDotReg#
FontSize=11
FontColor=#ColorSecondary#
AntiAlias=1
StringCase=Upper
CharacterSpacing=1.5

[StyleValueBigNdot]
FontFace=#FontDotBold#
FontSize=38
FontColor=#ColorPrimary#
AntiAlias=1

[StyleValueMidNdot]
FontFace=#FontDotBold#
FontSize=20
FontColor=#ColorPrimary#
AntiAlias=1

[StyleBodyInter]
FontFace=#FontUI#
FontSize=10
FontColor=#ColorPrimary#
AntiAlias=1
ClipString=1

[StyleBodyInterBold]
FontFace=#FontUIBold#
FontSize=10
FontColor=#ColorPrimary#
AntiAlias=1
ClipString=1

[StyleSubTextInter]
FontFace=#FontUI#
FontSize=9
FontColor=#ColorSecondary#
AntiAlias=1
ClipString=1
