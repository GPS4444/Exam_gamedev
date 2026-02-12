using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTitleManager : MonoBehaviour
{
    [SerializeField] Transform title3;
    [SerializeField] float scaleSpeed = 2;

    private Vector3 defaultScale;

    void Start()
    {
        defaultScale = title3.transform.localScale;
    }

    void Update()
    {
        title3.transform.localScale = defaultScale * ((MathF.Sin(Time.time * scaleSpeed) + 1) / 8f + 0.75f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
