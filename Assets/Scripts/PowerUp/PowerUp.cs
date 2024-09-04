using System.Collections;
using System.Globalization;
using UnityEngine;

public abstract class PowerUp : ScriptableObject, IPowerUp
{
    public abstract IEnumerator Apply(PlayerMediator playerMediator);
}
