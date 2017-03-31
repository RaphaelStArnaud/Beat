using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingControl : MonoBehaviour {

    public Transform loadingIndicator;

	// Use this for initialization
	void Start () {
        SceneManager.LoadSceneAsync("Level");
	}
	
	// Update is called once per frame
	void Update () {
        loadingIndicator.Rotate(0, 0, loadingIndicator.rotation.z - 7, Space.World);
    }
}
