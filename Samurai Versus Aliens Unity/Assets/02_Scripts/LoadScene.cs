using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	private string levelName;
	private int index;
	public float timer;

	public void DelayedSceneLoader (int i) {
		index = i;
		Invoke ("SceneLoaderIndex", timer);
	}

	public void SceneLoaderIndex () {
		SceneManager.LoadScene(index);
	}


	public void DelayedSceneLoader (string lvl) {
		levelName = lvl;
		Invoke ("SceneLoaderString", timer);
	}

	public void SceneLoaderString () {
		SceneManager.LoadScene (levelName);
	}
}
