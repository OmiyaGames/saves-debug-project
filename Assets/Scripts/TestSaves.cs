using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using OmiyaGames.Saves;

public class TestSaves : MonoBehaviour
{
	[SerializeField]
	TMPro.TextMeshProUGUI label;
	[SerializeField]
	SaveInt version;

	[Header("Test Saves")]
	[SerializeField]
	TMPro.TMP_InputField input;
	[SerializeField]
	Button save;
	[SerializeField]
	SaveInt test;

	// Start is called before the first frame update
	IEnumerator Start()
	{
		// Disable everything
		label.text = "Setting up...";
		input.interactable = false;
		save.interactable = false;

		// Setup saves manager
		yield return SavesManager.Setup();
		
		// Setup label
		label.text = GetTestString();

		// Setup input
		input.text = test.Value.ToString();

		// Setup controls
		input.interactable = true;
		save.interactable = true;
		input.onEndEdit.AddListener(e => test.Value = int.Parse(e));
		save.onClick.AddListener(() => StartCoroutine(Save()));
	}

	string GetTestString() => $"Done setting up\nVersion: {version.Value}\nStored Value: {test.Value}";

	IEnumerator Save()
	{
		// Disable everything
		label.text = "Saving...";
		input.interactable = false;
		save.interactable = false;

		// Setup saves manager
		var status = SavesManager.Save();
		yield return status;

		// Setup label
		label.text = GetTestString() + (status.CurrentState == LoadState.Success ? "\nSave Succeeded" : "\nSave Failed");
		input.interactable = true;
		save.interactable = true;
	}
}
