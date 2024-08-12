using UnityEngine;

public class Step : MonoBehaviour
{
    #region Variables

    [TextArea(5, 10)]
    [SerializeField] private string _answers;
    [TextArea(3, 10)]
    [SerializeField] private string _description;

    [SerializeField] private Step[] _nextStep;
    
    [SerializeField] private string _locationName;
    
    [SerializeField] private Sprite _currentLocationImage;
    
    public bool isWin;


    #endregion

    #region Properties

    public string Answers => _answers;
    public string Description => _description;
    
    public string Location => _locationName;

    public Step[] NextSteps => _nextStep;
    
    public Sprite CurrentLocationImage => _currentLocationImage;
    
    #endregion
}