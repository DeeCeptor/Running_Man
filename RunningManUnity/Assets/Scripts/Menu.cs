using UnityEngine;
using System.Collections;

// Handles switching of levels
public class Menu : MonoBehaviour
{
    int leftAlignment;
    int yStart = 100;
    int yOffset = 20;
    int buttonWidth;
    int buttonHeight;

    private string controlsString = "<b><color=red>Player One</color></b>\n AD: Movement \n S: Dodge " +
        "\n Left Control: Punch \n W or Spacebar: Jump \n\n " +
            "<b><color=white>Player Two</color></b>\n Left and Right Arrows: Movement \n Down Arrow: Dodge " +
            "\n Right Control: Punch \n Up Arrow: Jump \n\n" +
            " Escape to toggle Controls Menu\n\n" +
            " <b><color=white>Created by:\n William Selby \n Austin Black \n Mitchell Craig\n Michael Long</color></b>";


    void Start()
    {
        leftAlignment = Screen.width / 6;
        buttonWidth = Screen.width / 6;
        buttonHeight = Screen.height / 16;
    }


    public Texture btnTexture;
    void OnGUI()
    {
        GUI.Label(new Rect(leftAlignment, yStart, 100, 50), "Select a level");

        if (GUI.Button(new Rect(leftAlignment, yStart + yOffset, buttonWidth, buttonHeight), "The Citystate of New Madrid"))
            Application.LoadLevel("austinlevel2");
        if (GUI.Button(new Rect(leftAlignment, yStart + yOffset + buttonHeight * 1, buttonWidth, buttonHeight), "Lamenteur"))
            Application.LoadLevel("MitchellsLevel");

        // Display credits
        GUI.Label(new Rect((float)(leftAlignment + buttonWidth * 1.5f), yStart, 100, 50), "Controls");
        GUI.Box(new Rect((float)(leftAlignment + buttonWidth * 1.5f), yStart + yOffset, 400, 300), controlsString);
    }
}
