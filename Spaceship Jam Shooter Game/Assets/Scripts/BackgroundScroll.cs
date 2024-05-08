using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assistance from this video: https://www.youtube.com/watch?v=A5YSbgqr3sc

public class BackgroundScroll : MonoBehaviour
{
    // Scroll speed range between -1 and 1
    [Range(-1f, 1f)]

    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // Get the material component attached to this object
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the offset based on time and scroll speed, divided by 10 for fine-tuning
        offset += (Time.deltaTime * scrollSpeed) / 10f;

        // Set the offset of the texture in the material and create a new Vector2 with the updated x-offset and 0 for y-offset
        mat.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
