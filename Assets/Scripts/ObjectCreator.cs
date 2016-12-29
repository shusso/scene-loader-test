using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ObjectCreator : MonoBehaviour {

	private Vector3 m_SpawnPoint;
	public GameObject m_SpawnObject;
	public int m_SpawnCount = 50;

	private int m_SpawnedObjects = 0;
	public GameObject UITextComponent;
	public InputField UISpawnCountComponent;
	private Text UIText;

	public Vector3 GetRandomSpawnPoint() {
		var spawnPoint = new Vector3(UnityEngine.Random.Range(0,Screen.width), UnityEngine.Random.Range(0,Screen.height), Camera.main.farClipPlane/2);
		return Camera.main.ScreenToWorldPoint(spawnPoint);
	}

	public void UIWriteSpawnCount() {
		UIText.text = "Spawned Objects: " + m_SpawnedObjects;
	}

	public void SpawnObject() {
		Debug.Log("Spawn item to screen");

		var location = GetRandomSpawnPoint();

		Instantiate(m_SpawnObject, location, Quaternion.identity);

		m_SpawnedObjects += 1;

	}

	public void SpawnObjects() {
		for (int i = 1; i <= m_SpawnCount; i++) {
			var location = GetRandomSpawnPoint();
			Instantiate(m_SpawnObject, location, Quaternion.identity);
		}
		m_SpawnedObjects += m_SpawnCount;
	}

	public void UISetSpawnCount(string arg0) {
		var count = Convert.ToInt32(arg0);
		Debug.Log("SpawnCount changed to " + count.ToString());
		m_SpawnCount = count;
	}

	void Start() {
		UIText = UITextComponent.GetComponent<Text>();
		UISpawnCountComponent.onEndEdit.AddListener(UISetSpawnCount);
	}
}
