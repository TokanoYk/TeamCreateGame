using UnityEngine;
using System.Collections;

//	シーン遷移時のフェードインフェードアウト用
public class FadeManager : SingletonMonoBehaviour<FadeManager>
{
	/// <summary>黒い画像</summary>
	private Texture2D BrackTexture;
	/// <summary>フェード時の透明度</summary>
	private float FadeAlpha = 0;
	/// <summary>フェード中かどうか</summary>
	private bool IsFading = false;

	public void Awake()
	{
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
		//	ロードするときに破棄しない
		DontDestroyOnLoad (this.gameObject);

		//	黒テクスチャを作る
		this.BrackTexture = new Texture2D (32, 32, TextureFormat.RGB24, false);
		this.BrackTexture.ReadPixels (new Rect (0, 0, 32, 32), 0, 0, false);
		this.BrackTexture.SetPixel (0, 0, Color.white);
		this.BrackTexture.Apply ();
	}

	public void OnGUI()
	{
		float sw = Screen.width;
		float sh = Screen.height;

		if (!this.IsFading)return;

		//	透明度を更新して黒テクスチャを描画
		GUI.color = new Color (0, 0, 0, this.FadeAlpha);
		GUI.DrawTexture (new Rect (0, 0, sw, sh), this.BrackTexture);
	}

	/// <summary>
	/// 画面遷移
	/// </summary>
	/// <param name="scene">シーン名</param>
	/// <param name="interval">暗転にかかる時間（秒）</param>
	public void LoadLevel(string scene,float interval)
	{
		StartCoroutine (TransScene (scene, interval));
	}

	/// <summary>
	/// シーン遷移用コルーチン
	/// </summary>
	/// <param name="scene">シーン名</param>
	/// <param name="interval">名店にかかる時間（秒）</param>
	private IEnumerator TransScene(string scene,float interval)
	{
		//	だんだん暗く
		this.IsFading = true;
		float time = 0;
		while(time <= interval)
		{
			this.FadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}

		//	シーン切り替え
		Application.LoadLevel (scene);

		//	だんだん明るく
		time = 0;
		while(time <= interval)
		{
			this.FadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
			time += Time.deltaTime;
			yield return 0;
		}
		this.IsFading = false;
	}
}