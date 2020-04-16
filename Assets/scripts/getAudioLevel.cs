using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getAudioLevel : MonoBehaviour {

	public AudioSource audioSource;
	public float updateStep = 0.1f;
	public int sampleDataLength = 1024;

	private float currentUpdateTime = 0f;

	private float clipLoudness;
	private float[] clipSampleData;

	public Text dBUI;

	// Use this for initialization
	void Awake () {

		if (!audioSource) {
			Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
		}
		clipSampleData = new float[sampleDataLength];
		dBUI.text = "00.0";

	}

	// Update is called once per frame
	void Update () {

		currentUpdateTime += Time.deltaTime;
		if (currentUpdateTime >= updateStep) {
			currentUpdateTime = 0f;
			//audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
			audioSource.GetOutputData(clipSampleData, 0); 
			clipLoudness = 0f;
			foreach (var sample in clipSampleData) {
				clipLoudness += Mathf.Abs(sample);
			}
			clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
			dBUI.text = Mathf.Round(getDB(clipLoudness)).ToString();
			//print(Mathf.Round(getDB(clipLoudness)));
			//print(clipLoudness);
		}

	}

	float getDB(float valor){
		var dBlin = valor * 65536;
		float dB = 10 * Mathf.Log10(Mathf.Pow(dBlin/65536,2));
		return dB;
	}

    public void ejemploboton() {

        print("usando botón");
    }
}
