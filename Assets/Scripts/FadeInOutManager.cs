using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOutManager : Singleton<FadeInOutManager> {
    
    protected FadeInOutManager() { }

    [SerializeField]
    private Material fadeMaterial;

    private float fadeOutTime, fadeInTime;
    private Color fadeColor;

    private string navigateToLevelName = "";
    private int navigateToLevelIndex = 0;

    private bool fading = false;
    public static bool Fading
    {
        get { return Instance.fading; }
        private set { Instance.fading = value; }
    }

    private void Awake()
    {
        fadeMaterial = Resources.Load("Fade") as Material;//new Material("Shader \"Plane/No zTest\" {" + "SubShader { Pass { " + " Blend SrcAlpha OneMinusSrcAlpha " + "ZWrite Off Cull Off Fog { Mode Off } " + "BindChannels {" + " Bind \"color\", color }" + "} } }");
    }

    private void StartFade(float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        fading = true;
        Instance.fadeOutTime = aFadeOutTime;
        Instance.fadeInTime = aFadeInTime;
        Instance.fadeColor = aColor;
        StopAllCoroutines();
        StartCoroutine("Fade");
    }

    private IEnumerator Fade()
    {
        string destination= NavigationManager.RouteInformation[navigateToLevelName].RouteDescription;
        GUIStyle style = new GUIStyle();
        style.fontSize = 22;
        style.fontStyle = FontStyle.Italic;
        style.normal.textColor = Color.white;
        float t = 0.0f;
        while (t < 1.0f)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 1000, 1000), destination,style);
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t + Time.deltaTime / fadeOutTime);
            DrawingUtilities.DrawQuad(fadeMaterial, fadeColor, t);
        }

        if (navigateToLevelName != "")
        {
            
            SceneManager.LoadScene(navigateToLevelName);
        }
        else
            SceneManager.LoadScene(navigateToLevelIndex);

        while (t > 0.0f)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 1000, 1000), destination, style);
            yield return new WaitForEndOfFrame();
            t = Mathf.Clamp01(t - Time.deltaTime / fadeInTime);

            DrawingUtilities.DrawQuad(fadeMaterial, fadeColor, t);
        }
        Fading = false;
    }

    public static void FadeToLevel(string aLevelName, float aFadeOutTime, float aFadeInTime, Color aColor)
    {
        if (Fading) return;
        Instance.navigateToLevelName = aLevelName;
        Instance.StartFade(aFadeOutTime, aFadeInTime, aColor);
    }
}

public static class DrawingUtilities
{
    public static void DrawQuad(Material aMaterial, Color aColor, float aAlpha)
    {
        aColor.a = aAlpha;
        aMaterial.SetPass(0);
        GL.PushMatrix();
        GL.LoadOrtho();
        GL.Begin(GL.QUADS);
        GL.Color(aColor);
        GL.Vertex3(0, 0, -1);
        GL.Vertex3(0, 1, -1);
        GL.Vertex3(1, 1, -1);
        GL.Vertex3(1, 0, -1);
        GL.End();
        GL.PopMatrix();
    }
}
