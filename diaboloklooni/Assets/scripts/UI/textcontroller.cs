using UnityEngine;
using System.Collections;

public class textcontroller : MonoBehaviour {
	private static FloatingText popupText;
	private static GameObject canvas;


	public static void Initialize(){
	

		canvas = GameObject.Find ("Canvas");

		popupText = Resources.Load<FloatingText> ("Prefabs/PopupTextParent");

	}

	// Use this for initialization
	public static void CreateFloatingText(string text, Transform location){



		FloatingText instance = Instantiate (popupText);
		instance.transform.SetParent (canvas.transform, false);
		instance.SetText (text);

	}
}
