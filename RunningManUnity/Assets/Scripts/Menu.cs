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

    private string controlsString = "<b><color=red>Runner</color></b>\n Movement: Arrow keys \n Sprint: Shift \n Space: Activate special \n Specials: Shield: Temporary invulnerability for 2 seconds Blink: Short range  " +
        "\n\n " +
            "<b><color=white>Enforcement</color></b>\n Use the mouse to kill the runner before reaching the end \n Left Mouse: Shoot Bullet " +
            "\n Middle Mouse: Middle Power \n Scroll Wheel: Change Middle Mouse Power\n Right Mouse: Use Pickup Power \n\n" +
            " \n Left click on powerups to gain Right Mouse abilities \n Right mouse abilities have limited uses \n You cannot click when too close to the Runner" +
            " <b><color=white>Created by:\n Michael Long \n William Selby \n Austin Black \n Mitchell Craig</color></b>";


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
        GUI.Label(new Rect((float)(leftAlignment + buttonWidth * 2.2f), yStart, 100, 50), "Controls");
        GUI.Box(new Rect((float)(leftAlignment + buttonWidth * 2.2f), yStart + yOffset, 500, 400), controlsString);
    }
}
