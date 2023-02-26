# GeonBit.UI

UI extension for MonoGame-based projects by Ronen Ness, original project location: [GeonBit.UI git](https://github.com/RonenNess/GeonBit.UI).

## What is this fork

This fork is for adding new features to GeonBit.UI for a game I am developing.

The following new features have been added:

- Can now set a specific render target size versus the existing behaviour where it will use the viewport width and height.  This allows you to create your game against a known screen resolution.  This can make game development much easier as you can render against a large render target then draw that render target against (ideally) a smaller viewport.  For basic games, scaling images down for basic games is hardly noticeable and the cost of larger images is negligible.  If the viewport has a different aspect ratio it does get squished or stretched, but this generally does not look too bad.  Many games use this technique e.g. "Griftlands".
- Can selectively disable special keys for text boxes.  E.g. if you're making console / command line interface for your game and you want to use the up and down arrows to recall history then the up and down arrows mess with your cursor position.  This change allows you to suppress GeonBit's cursor positioning behavior in this use case.
- Button paragraphs have word wrap disabled
- Images that don't have a texture do not draw anything rather than throwing an exception

The following changes have also been made
- Built against MonoGame.DirectX instead of OpenGL
