using UnityEngine;
using System.Collections;

public class WordBook : MonoBehaviour {

	public GUIStyle LabelStyle;

	public int page = 0;

	public AudioClip book;

	//	------------------------------------------------------------
	//	絵本
	//	------------------------------------------------------------
	string[] Words = {
		//	タイトル
		"親愛のおはなし\n",
		"←キー、→キーでページ移動\n",

		"これは遠い昔のお話です。\n\n" +
		"人里から離れた森の中ほどで\n【ミリア】という【少女】が一人、\n暮らしておりました。\n" +
		"幼い頃から一人だった【ミリア】は、\n人と接することがあまりありません\nでした。\n\n" +
		"そんなある日の事です。\n【ミリア】の暮らす森に一人の\n【少年】が迷いこんできました。\n" +
		"【少年】は涙を【ぽろぽろ】零し\nながら、大きな声で【母親】を\n呼び続けます。\n\n" +
		"「…うぅ…！【お母さぁん】…！\n【お母さぁん】！どこぉ？」\n\n" +
		"泣きながら声を上げて歩く\n【少年】の姿を見かけた【少女】は\n困りました。\n",

		//	２ページ目（右ページ）
		"森にずっと一人で人と接することの\nなかった【ミリア】には、\nどう対応すればよいのか\n解らなかったのです。\n" +
		"そして何よりも、【少年】の求める\n「【母親】」というものが\n【ミリア】には解りませんでした。\n\n" +
		"どうすることもできずに\n立ち尽くしていると、【ミリア】の\n耳に【少年】とは別の優しい声が\n聞こえてきました。\n\n" +
		"「【アルス】、【アルス】！\nどこに居るの？」\n\n" +
		"誰かを探す【女性】の声です。\n" +
		"【女性】の優しい声が聞こえたのか、\n俯き涙を【ぽろぽろ】零していた\n【少年】は顔をすぐに上げると\n優しい声の方へと走りだしました。\n",


		//	３ページ目（左ページ）
		"「【お母さぁん！】」\n\n" +
		"「ああ、【アルス】！\nこんなところに居たのね。\n心配したのよ」\n\n" +
		"【女性】は【草陰】から\n飛び出してきた【少年】を力強く\n抱きしめました。\n" +
		"【少年】は【女性】に抱きしめられ\nながら大きな声で泣き、\n【女性】は【少年】を宥めるように\n優しい顔で抱きしめていました。\n\n" +
		"しばらくすると、\n【女性】は泣き止んだ【少年】を\n抱き上げて、笑いあいながら\n森から去って行きました。\n\n" +
		"二人の後ろ姿を離れた場所から\n見送った【ミリア】はぼうっと\n立ち尽くしていました。\n",

		//	４ページ目（右ページ）
		"（今のは、何だろう？\nあの二人から伝わってきた\n【温かいもの】は何？）\n\n" +
		"何故か温かくなった胸に\n【ミリア】は不思議そうな顔で\n手を当てます。\n" +
		"ずっと一人で過ごしてきた\n【ミリア】には【親子】の見せた\n【親愛】が解らなかったのです。\n\n" +
		"それからしばらくしたある日。\n" +
		"一冊の本から【愛】というものを\n知った【ミリア】は街へ出かける\nことを決意しました。\n\n" +
		"自分には与えられていない、\n【愛】というものを求めての\n行動です。\n" +
		"森を出た【ミリア】の【首元】で、\n【フリージア】の花の\n【ネックレス】が小さく揺れました。\n\n" +
		"　　　　『親愛のおはなし』ＥＮＤ"

		//26行
	};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//	→キーかエンターを押すと次のページヘ
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{

			if(page == 0 || page == 1 || page == 2)
			{
				//	サウンドでページをめくる音
				audio.PlayOneShot(book);
				page ++;
			}

			if(page == 3)
			{
				//	スタッフロールへ
				FadeManager.Instance.LoadLevel("StaffRoll",2.0f);
			}
		}

		//	←キーを押すと１ページ戻る
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if(page > 0)
			{
				//	サウンドでページをめくる音
				audio.PlayOneShot(book);
				page --;
			}
		}
	}

	void OnGUI()
	{	
		float sw = Screen.width;
		float sh = Screen.height;

		//	タイトル
		Rect BookTitle = new Rect (sw / 2 - 250, sh / 2 , sw / 2, sh / 2);
		Rect Operation = new Rect (sw / 2 - 250, sh / 2 + 100 , sw / 2, sh / 2);

		//	左ページ１行目
		Rect LeftTopLine = new Rect (sw / 2 - 270, sh / 2 - 180, sw / 2, sh / 2);
		//	右ページ２行目
		Rect RightTopLine = new Rect (sw / 2 + 25, sh / 2 - 180, sw / 2, sh / 2);

		if(page == 0)
		{
			LabelStyle.fontSize = 30;
			GUI.Label (BookTitle, Words[0], LabelStyle);

			//	操作説明
			LabelStyle.fontSize = 16;
			GUI.Label (Operation, Words[1], LabelStyle);

			//	１ページ
			GUI.Label (RightTopLine, Words[2], LabelStyle);
		}

		if(page == 1)
		{
			GUI.Label (LeftTopLine, Words[3], LabelStyle);
			GUI.Label (RightTopLine, Words[4], LabelStyle);
		}

		if(page == 2)
		{
			GUI.Label (LeftTopLine, Words[5], LabelStyle);
		}

	}
	
}
