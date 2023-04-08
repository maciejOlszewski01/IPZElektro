using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zmien_scene1 : MonoBehaviour
{
    public void ZmienScene()

	{
	SceneManager.LoadScene(2);//numer w środku to numer sceny na którą zmieniamy w Build Settings
	}
 public void ZmienScene_opcje()

	{
	SceneManager.LoadScene(3);//numer w środku to numer sceny na którą zmieniamy w Build Settings
	}
public void ZmienScene_lekcje()

	{
	SceneManager.LoadScene(4);//numer w środku to numer sceny na którą zmieniamy w Build Settings
	}
public void ZmienScene_egzamin()

	{
	SceneManager.LoadScene(5);//numer w środku to numer sceny na którą zmieniamy w Build Settings
	}
	public void wyjdz()
{
	Application.Quit();
}
}
