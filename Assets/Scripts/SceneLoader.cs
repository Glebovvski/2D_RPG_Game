using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    public static Text sceneText;
    
    private static Image loadScene;

    private static string destination;

    private void Start()
    {
        loadScene = GameObject.FindGameObjectWithTag("LoadScene").GetComponent<Image>();
        sceneText = GameObject.FindGameObjectWithTag("LoadSceneName").GetComponent<Text>();
        Color c = loadScene.color;
        c.a = 0;
        loadScene.color = c;
    }

    public static void SetSceneName(string name)
    {
        sceneText = GameObject.FindGameObjectWithTag("LoadSceneName").GetComponent<Text>();
        sceneText.text = name;
    }

    static IEnumerator FadeIn(Color alpha)
    {
        while (alpha.a < 1.0f)
        {
            //fading = true;
            yield return new WaitForEndOfFrame();
            alpha.a = Mathf.Clamp01(alpha.a + Time.deltaTime / 2f);
            loadScene.color = alpha;
        }
        SetSceneName(destination);
        SceneManager.LoadScene(destination);
        while (alpha.a > 0.0f)
        {
            yield return new WaitForEndOfFrame();

            alpha.a = Mathf.Clamp01(alpha.a - Time.deltaTime / 2f);
            loadScene.color = alpha;
        }
        SetSceneName("");
    }

    public static void LoadScene(string name)
    {
        if (name != null)
        {
            destination = name;
            loadScene = GameObject.FindGameObjectWithTag("LoadScene").GetComponent<Image>();
            sceneText = GameObject.FindGameObjectWithTag("LoadSceneName").GetComponent<Text>();
            Color c = loadScene.color;
            //c.a = 1;
            //loadScene.color = c;
            loadScene.StartCoroutine(FadeIn(c));
            //loadScene.SetActive(false);
        }
    }
}
