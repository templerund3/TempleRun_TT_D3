using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCameraAuto : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        // set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)




        float targetaspect = 16.0f / 9.0f;
        float widthscreen = Screen.width;
        float heightscreen = Screen.height;
        if (Screen.width == 2436 && Screen.height == 1125)
        {
            widthscreen = 2172;
            heightscreen = 1062;
        }


        // determine the game window's current aspect ratio
        float windowaspect = widthscreen / heightscreen;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();
        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
        if (Screen.width == 2436 && Screen.height == 1125)
        {
            float scalewidth = 1.0f / scaleheight;
            Rect rect = camera.rect;

            rect.width = 0.82f;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }


}
