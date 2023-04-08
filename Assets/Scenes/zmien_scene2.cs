using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zmien_scene2 : MonoBehaviour
{
    public void ZmienScene()

	{
	SceneManager.LoadScene(3);//numer w środku to numer sceny na którą zmieniamy w Build Settings
	}
	public void wyjdz()
{
	Application.Quit();
}
}
