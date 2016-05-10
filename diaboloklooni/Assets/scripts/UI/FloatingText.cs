using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {


	public Animator animator;
	private Text damageText;

	// Use this for initialization
	void Start () {
	
		//animator = animator.GetComponentInChildren <Animator>();
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo (0);
		Destroy(gameObject, clipInfo [0].clip.length);
		damageText = GetComponent<Text> ();


	}

	public void SetText(string text){
	
		damageText.text = text;
	


	
	}
	
	// Update is called once per frame

}
