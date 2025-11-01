If you remember a video game but just can't remember the name, Gamefinder finds it for you with the game characteristics you rembember.

# Credits

1. Made by Veaizy and Feddas
2. [Grand9k Pixel font](https://fontstruct.com/fontstructions/show/2264309/scratch-pixel-1) with [Unity pixel font import help](https://discussions.unity.com/t/how-to-set-up-crisp-ttf-otf-pixel-font-rendering-with-textmesh-pro/947258).

# How to add a new game

1. In the **Hierarchy**, go to **Canvas > Scroll View > Viewport > GameIcons** This will show you all of the games in Gamefinder.
2. Right click any of the games and **duplicate** it.
3. Select the duplikit (Left click it) and rename it to the game you are adding.
4. Drag the game to be in alphabetical order with all the other games.
5. Navigate to the Inspector on the right of the screen. Click **Mixed...** (under **Filters Enable (Script)**) and change the properties to describe the game you are adding.
6. In the **Hierarchy**, open your game and click **Icon**.
7. Import the icon for your game:
   1. Go to google and search for an icon you like. It should be square(if it isn't, you can crop it in paint after you save it).
   2. Right click on the image and click **save image as...**. Rename the file to the name of the game. - save in the video games file in pictures.
   3. Go back to Unity and go to **Assets > Sprites** in the **Project** window at the bottom of the screen.
7d. Open file explorer and drag the saved icon image into the open **Sprites** window in Unity.
8. Make sure **Icon** under your game in the Hierarchy is still selected. Drag your game from the **Sprites** window to the **Source Image** in the **Inspector** to replace the previous game icon.
9. Click **Title** under your game in the **Hierarchy**
10. In the **Inspector**, Click on the text box under **TextMeshPro - Text (UI)**.
11. Replace the text in the box with the name of your game.
12. use **Ctrl + S** to save your work
13. Commit the changes:
    1. Open **Github Desktop** - app on desktop.
    2. Write a short summary for your changes.
    3. check that your changes are what you want them to be.
    4. Click the blue button, **Commit [#] files to master**.
    5. Click **Push Github**

# Amend commit
1. Click on the **History** tab.
2. Right click the newest commit.
3. Select **Amend commit...**.
4. Click **Amend last commit** in the bottom left.