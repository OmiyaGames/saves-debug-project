using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmiyaGames.Saves;

[CreateAssetMenu(menuName = "Omiya Games/Test/Upgrader", fileName = "Test Upgrader")]
public class TestUpgrader : SavesUpgrader
{
	public override IEnumerator Upgrade(SavesSettings sourcer, IAsyncSettingsRecorder recorder)
	{
		CurrentState = LoadState.Loading;
		yield return null;
		Debug.Log("It worked!");
		yield return null;
		CurrentState = LoadState.Success;
	}
}
