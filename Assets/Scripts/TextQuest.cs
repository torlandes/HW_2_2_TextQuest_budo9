using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextQuest : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text _descriptionLabel;
    [SerializeField] private TMP_Text _answerLabel;
    [SerializeField] private TMP_Text _locationLabel;

    [SerializeField] private Step _startStep;
    [SerializeField] private Step _currentStep;

    [SerializeField] private Image _currentLocationImage;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        SetCurrentStepAndUpdateUi(_startStep);
    }

    private void Update()
    {
        for (int i = 1; i < 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                TryGoToNextStep(i);
            }
            else if (_currentStep.IsWin && Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
    }

    #endregion

    #region Private methods

    private void Restart()
    {
        SetCurrentStepAndUpdateUi(_startStep);
    }

    private void SetCurrentStepAndUpdateUi(Step step)
    {
        _currentStep = step;
        UpdateUi();
    }

    private void TryGoToNextStep(int number)
    {
        int nextStepsCount = _currentStep.NextSteps.Length;
        if (number > nextStepsCount)
        {
            return;
        }

        int nextStepIndex = number - 1;
        Step nextStep = _currentStep.NextSteps[nextStepIndex];
        SetCurrentStepAndUpdateUi(nextStep);
    }

    private void UpdateUi()
    {
        _descriptionLabel.text = _currentStep.Description;
        _answerLabel.text = _currentStep.Answers;
        _locationLabel.text = _currentStep.Location;
        _currentLocationImage.sprite = _currentStep.CurrentLocationImage;
    }

    #endregion
}