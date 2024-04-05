using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class GunShootAngle : GunShootLimits
{
    public int amountPerShoot = 4;
    public float angle = 15;

    public override void Atirar()
    {
        int mult = 0;


        for (int i = 0; i < amountPerShoot; i++)
        {
            if (i % 2 == 0)
            {
                mult++;
            }
            var projectile = Instantiate(prefabProjectil,posInicialTiro);

            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i%2==0?angle:-angle);

            projectile.velProjectil = speed;
            projectile.transform.parent = null;

        }
    }
}
