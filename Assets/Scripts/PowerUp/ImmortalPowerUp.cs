using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="MinerRunner/Power/Immortal")]
public sealed class ImmortalPowerUp : PowerUp
{
    public override IEnumerator Apply(PlayerMediator playerMediator)
    {
        playerMediator.ToggleInvulnerability(true);
        yield return new WaitForSeconds(5);
        playerMediator.ToggleInvulnerability(false);
    }
}
