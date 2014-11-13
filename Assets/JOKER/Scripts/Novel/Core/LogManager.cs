﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Novel{

	public class LogManager  {

		public List<string> arrLog = new List<string>();
		public int lognum = -1;
		GameManager gameManager ;

		public LogManager(GameManager gm){
			this.gameManager = gm;
		}

		public void addLog(string name,string name_color,string text){

			string str = "";
			str += "<color=#"+name_color+">"+name+"</color>\n"+text+""; 

			if (this.lognum == -1) {
				this.lognum = int.Parse(this.gameManager.getConfig ("backlogNum"));
			}

			this.arrLog.Add (str);

			//上限を超えていたら指定分の配列を削除する
			if (this.lognum+10 < this.arrLog.Count) {
				this.arrLog.RemoveRange (0, 10);
			}

		}

		public string getLogText(){

			string logtext = "";

			this.arrLog.Reverse();

			foreach (string item in this.arrLog)

			{

				logtext += item +"\n\n";

			}

			this.arrLog.Reverse();

			return logtext;
		}
	}


}