# Contributing Guidelines
- Your contributions will be licensed under the [GNU AGPL 3.0 license](https://github.com/MrFlapstaart/GameOCRTTS/blob/master/LICENSE.md)
- Create PRs against the `master` branch.
- Test your changes first before opening a PR.
# Files
Quick explanation of what the .cs files are for. 
## ImageProc.cs
This file is for the image processing (removing unnecessary characters from the regognized text). The button "Remove Garbage" manually triggers this.
## KeyboardHook.cs
This file is used to assign the hotkeys to GameOCRTTS.
## LiveUpdate.cs
This is the Live Updater. It downloads and installs the updates when the Live Update item is clicked in the context menu (contextMenu).
## MainForm.cs
The main form.
## Logger.cs
Creates the log shown in the Log text box. For debugging purposes.
## OCR.cs
Captures a screenshot of the full screen.
## OCRResult.cs
Calls ImageProc to remove garbage, and it's the end result of all capturing and processing (which outputs the text that the TTS should read out loud.
## TTS.cs
Uses the Tesseract NuGet package to read the text out loud.
## SFXPlayer.cs
Plays the error sound effect if no text is detected.
## SpeechApiReflectionHelper.cs
Used for the voice selection.
