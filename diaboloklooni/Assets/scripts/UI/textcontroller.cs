using UnityEngine;
using System.Collections;

public class textcontroller : MonoBehaviour {
	private static FloatingText popupText;
	private static GameObject canvas;


	public static void Initialize()
    {

        Debug.Log("Kjeh");
        canvas = GameObject.Find ("Canvas");
        if (!popupText)
        {
            popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
        }
        //popupText = Resources.Load("Prefabs/PopupTextParent") as FloatingText;

    }


	public static void CreateFloatingText(string text, Transform location){

        //JOSSAI VÄLISSÄ JOKU PAREMPI RATKASU KU INIT TÄSSÄ
        //Initialize();

        Debug.Log("Kjeh kjeh");

        FloatingText instance = Instantiate (popupText);
        //Vector2 screenPosition = Camera.main.WorldToScreenPoint(new Vector2(location.position.x + Random.Range(-.2f, .2f), location.position.y + Random.Range(-.2f, .2f)));
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        instance.transform.SetParent (canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText (text);

	}
}
