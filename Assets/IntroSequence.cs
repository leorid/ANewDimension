using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour
{

	[SerializeField] TriggerFinish triggerFinish;
	[SerializeField] CanvasGroup[] sheets;
	[SerializeField] float transitionTime = 2;
	int currentSheetIndex = 0;
	float transitionTimer = 0;
	bool transitioning;
	bool finished;

	CanvasGroup currentSheet;
	CanvasGroup lastSheet;

	private void Start() {
		currentSheet = sheets[0];
		transitioning = true;
		transitionTimer = 0;
	}
	private void Update() {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		if (transitioning) {
			transitionTimer += Time.deltaTime / transitionTime;

			if (currentSheet) {
				currentSheet.alpha = -1f + transitionTimer * 2;
			}
			if (lastSheet) {
				lastSheet.alpha = 1 - transitionTimer * 2;
			}

			if (transitionTimer >= 1) {
				transitioning = false;
			}
		}
		if (!transitioning && finished) {
			triggerFinish.OnFinish();
		}
	}

	public void NextSheet() {
		if (transitioning) {
			return;
		}
		lastSheet = currentSheet;
		currentSheetIndex++;
		if (currentSheetIndex >= sheets.Length) {
			finished = true;
		} else {
			currentSheet = sheets[currentSheetIndex];
		}
		transitionTimer = 0;
		transitioning = true;
	}
}
