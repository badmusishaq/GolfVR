//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Windows.Speech;
//
//public class KeywordRecognizer : MonoBehaviour {
//
//	KeywordRecognizer keyword;
//
//
//	public string [] keywordArray;
//
//	void Start ()
//	{
//		keywordArray = new string[2];
//		keywordArray [0] = "Hello";
//		keywordArray [1] = "Come over";
//
//		keyword = new KeywordRecognizer(keywordArray, ConfidenceLevel.Low);
//
//		keyword.OnPhraseRecognized += OnKeywordRecognized;
//
//	}
//
//	void OnKeywordRecognized (PhraseRecognizedEventArgs args)
//	{
//		Debug.Log ();
//	}
//
//
//	[SerializeField]
//	private string[] m_Keywords;
//
//	public KeywordRecognizer m_Recognizer;
//
//	void Start()
//	{
//		m_Keywords = new string[1];
//		m_Keywords [0] = "Hello";
//		m_Recognizer = new KeywordRecognizer(m_Keywords);
//		m_Recognizer.Recognizer_OnPhraseRecognized += Recognizer_OnPhraseRecognized;
//		m_Recognizer.Start();
//	}
//
//	private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
//	{
//		
//		Debug.Log("Over Here");
//	}
//}
