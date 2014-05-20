using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

	private float masterVolume = 1f;
	public GUISkin SliderSkin;

	void Start()
	{
		masterVolume = AudioListener.volume;
	}

	void OnGUI()
	{
		float groupWidth = Screen.width * 7 /8;
		float groupHeight = 120;

		float groupX = Screen.width / 16;
		float groupY = Screen.height / 3;

		GUI.skin = SliderSkin;
		GUI.BeginGroup (new Rect (groupX, groupY, groupWidth, groupHeight));
		GUI.Box (new Rect (0, 0, groupWidth, groupHeight), "Volume");

		masterVolume = GUI.HorizontalSlider (new Rect (10, 50, groupWidth - 20, 70), masterVolume, 0f, 1f);
		AudioListener.volume = masterVolume;

		GUI.EndGroup ();
	}
}
