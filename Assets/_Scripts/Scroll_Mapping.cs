using UnityEngine;
using System.Collections;

public class Scroll_Mapping : MonoBehaviour
{
    [SerializeField]
    private float ScrollSpeed = 0.5f;

    private float Offset;

    void Update ()
	{
	
		Offset += Time.deltaTime * ScrollSpeed;
		gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Offset, 0.01f);
		
	}
}



