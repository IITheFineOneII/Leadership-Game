using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Add Audio module so that we can use the Unity mixer
using UnityEngine.Audio;
// Add UI module to use the dropdown
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour
{

    public AudioMixer mixer;
    public Dropdown resolutionSelect;

    Resolution[] resolutions;

    public void VolumeSet(float volume)
    {
        // Set volume of mixer to volume of slider
        mixer.SetFloat("Volume", volume);
    }

    public void resolutionSet(int resolutionSelect)
    {
        // Get resolution from list of resolutions
        Resolution resolution = resolutions[resolutionSelect];
        // Set resolution to width and height, and choose if fullscreen
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void FullScreenSet(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
        // Clear dropdown of any options
        resolutionSelect.ClearOptions();

        List<string> resolutionStrings = new List<string>();

        // Turn resolutions into string to put into the select dropdown

        // Variable to get currently selected resolution
        int selectedResolution = 0;

        // Go through every resolution
        for (int i = 0; i < resolutions.Length; i++)
        {
            // Get only resolution width and height with an x between them
            string res = resolutions[i].width + " x " + resolutions[i].height;
            // Add to list of resolutions
            resolutionStrings.Add(res);

            // If the resolution we are adding is the same as the one that is being used, save that as the currently selected one
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                selectedResolution = i;
            }
        }

        // Add list of resolutions to dropdown as an option
        resolutionSelect.AddOptions(resolutionStrings);

        // Set current resolution as the selected one on the dropdown
        resolutionSelect.value = selectedResolution;
        // Refresh the drop down
        resolutionSelect.RefreshShownValue();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get resolutions that are available
        resolutions = Screen.resolutions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
