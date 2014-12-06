using UnityEngine;
using System.Collections;

//	マウスカーソルの変更
public class MouseCursor : MonoBehaviour {

	public Texture2D cousorTexture;
	Vector2 MouseSpot;

	/*
    //	マウスポジションの取得
    private Vector2 MousePosition;
    //	スクリーン座標をワールド座標に変換した位置座標
    public Vector2 ScreenPointPosition;
	*/

    // Use this for initialization
    void Awake()
    {
        MouseSpot = new Vector2(12f, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse();
        ChangeMouse();
    }

	void ChangeMouse()
	{
		Cursor.SetCursor (cousorTexture, MouseSpot, CursorMode.Auto);

	}

	/*
    /// <summary>オブジェクトのマウス追従とマウス位置設定</summary>
    void Mouse()
    {
        // Vector3でマウス位置座標を取得する
        MousePosition = Input.mousePosition;

        // マウス位置座標をスクリーン座標からワールド座標に変換する
        ScreenPointPosition = Camera.main.ScreenToWorldPoint(MousePosition);
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = ScreenPointPosition;

    }
	*/
}
