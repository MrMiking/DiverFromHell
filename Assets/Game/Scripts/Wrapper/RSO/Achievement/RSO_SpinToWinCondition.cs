using UnityEngine;

[CreateAssetMenu(fileName = "RSO_SpinToWinCondition", menuName = "RSO/RSO_SpinToWinCondition")]
public class RSO_SpinToWinCondition : BT.ScriptablesObject.RuntimeScriptableObject<bool>
{
    public RSO_PlayerRotation rsoPlayerRotation;
    public RSO_PlayerShooting rsoPlayerShooting;

    public SSO_Achievement ssoSpinToWinAchievement;
    public float continuousShootingTime = 0f;

    public void EvaluateCondition()
    {
        Debug.Log(rsoPlayerShooting.Value + " + " + rsoPlayerRotation.Value.isRotating);
        if(rsoPlayerShooting.Value && rsoPlayerRotation.Value.isRotating)
        {
            continuousShootingTime += Time.deltaTime;

            if(continuousShootingTime >= ssoSpinToWinAchievement.value)
            {
                Value = true;
            }
        }
        else
        {
            continuousShootingTime = 0f;
            Value = false;
        }
    }
}