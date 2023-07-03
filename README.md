![Project Maintenance](https://img.shields.io/maintenance/yes/2023.svg?style=for-the-badge)
![Repository Size](https://img.shields.io/github/repo-size/MrFlapstaart/GameOCRTTS?style=for-the-badge)
![Total Downloads](https://img.shields.io/github/downloads/MrFlapstaart/GameOCRTTS/total)
# GameOCRTTS
Speak out text balloons in games without voice acting to use OCR on the screenshot and uses TTS to read it aloud.

## Errors
### Error opening image file
The image file is invalid. This means that the file has an extension for an image file, but it's content is not an image. The file might have the wrong file extension or it might be corrupt.
### Couldn’t register the hot key.
<p>The program cannot assign the ` key. There might already be a second instance of the program running or the ` key is already used by another program on your computer.</p>

## Hotkeys
### `
Point your mouse cursor at a text balloon in the game and press the key to make the program read it out loud.
### CTRL+`
Point your mouse cursor inside the text of the text balloon in the game. This is simply to let GameOCRTTS know what text color it should look for. You can use the key again if your mouse cursor was not right in the text of the text balloon. The program also reads the color it has detected out loud, so you will know if the color is correct while the program is running in the backgroud.
## Buttons
### Test OCR
This lets you choose an image file to test the OCR+TTS (the same as the ` key but with an image file for testing.
### TTS
This tests the TTS function. It reads everything in the "Recognized Text" field out loud. For debugging purposes only.
### Remove Garbage
This removes all the garbage from the Recognized Text field. This includes unnecessary spaces, letters, numbers and symbols.
### Select text color...
With this button, you can manually select the text color for the text balloon detection. This method is not recommended, see CTRL+` for the recommended option.
