using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public float m_Delay = 2;

    public void LogoCompleted()
    {
        StartCoroutine(LoadMainApp());
    }

    IEnumerator LoadMainApp()
    {
        yield return new WaitForSeconds(m_Delay);
        SceneManager.LoadScene(1);
    }
}
