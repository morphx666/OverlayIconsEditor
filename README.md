# OverlayIconsEditor
A small and simple tool to easily change the priority of the overlay icon handlers in Windows Explorer

**WARNING**: This program performs changes to the Windows Registry. Use it at your own risk!

Programs such as DropBox, OneDrive, [Link Shell Extension](http://schinagl.priv.at/nt/hardlinkshellext/linkshellextension.html) and TortoiseSVN, among many others, provide user feedback about a file status through icons overlays.
These overlays appear as small indicators over the files' default icons, indicating different states, such as if the file has been synchronized, backed up, updated or even that some error has occurred in whatever process the handler is responsible for.

Because Windows has a limit on the number of handlers that can used to display such overlays, this tool can be useful to define your own priorities and elevate or downgrade certain handlers based on your preferences.

![OverlayIconsEditor](https://xfx.net/stackoverflow/OverlayIconsEditor/OverlayIconsEditor.png)

Handlers that appear in bold (towards the top the of the list) will be guaranteed to be used by Explorer, while handlers towards the end of the list will be ignored.
