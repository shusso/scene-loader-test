using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {
	string gameIdIOS = "1249251";
	string gameIdAndroid = "1249252";

	private void HandleShowResults(ShowResult result) {
		switch(result) {
			case ShowResult.Finished:
				Debug.Log("Ads Finished");
				break;
			case ShowResult.Skipped:
				Debug.Log("Ads skipped");
				break;
			case ShowResult.Failed:
				Debug.Log("Ads failed");
				break;
		}
	}

	public void ShowAds() {
		if (Advertisement.IsReady()) {
			var options = new ShowOptions{resultCallback = HandleShowResults };
			Advertisement.Show("video", options);
		}
		else {
			Debug.Log("No Ads to show..");
		}
	}

	void Start () {
#if UNITY_IOS
		Debug.Log("Initialized Ads for iOS");
		Advertisement.Initialize(gameIdIOS);
#elif UNITY_ANDROID
		Debug.Log("Initialized Ads for Android");
		Advertisement.Initialize(gameIdAndroid);
#endif

	}

	void Update () {

	}
}
