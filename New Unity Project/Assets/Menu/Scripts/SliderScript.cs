using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

	private float masterVolume = 1f;
	private float sfxVolume = 1f;

	void Start()
	{
		masterVolume = AudioListener.volume;
	}

	void OnGUI()
	{
		float groupWidth = Screen.width * 7 /8;
		float groupHeight = 70;

		float groupX = Screen.width / 16;
		float groupY = Screen.height / 3;

		GUI.BeginGroup (new Rect (groupX, groupY, groupWidth, groupHeight));
		GUI.Box (new Rect (0, 0, groupWidth, groupHeight), "Volume");

		masterVolume = GUI.HorizontalSlider (new Rect (10, 35, groupWidth - 20, 30), masterVolume, 0f, 1f);
		AudioListener.volume = masterVolume;

		GUI.EndGroup ();
	}
}
