using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShell : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform turretBase;

    float bulletSpeed = 15f;
    float rotationSpeed = 4.5f;
    float moveSpeed = 1.5f;

    void CreateBullet()
    {
        GameObject newShell = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        newShell.GetComponent<Rigidbody>().velocity = bulletSpeed * turretBase.forward;
    }

    float? RotateTurret()
    {
        float? angle = CalculateAngle(true);
        if (angle != null)
        {
            turretBase.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);
        }
        return angle;
    }

    float? CalculateAngle(bool low)
    {
        Vector3 targetDir = enemy.transform.position - turret.transform.position;
        float y = targetDir.y;
        targetDir.y = 0f;

        float x = targetDir.magnitude;
        float gravity = 9.81f;
        float sSqr = bulletSpeed * bulletSpeed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underTheSqrRoot >= 0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if (low) { return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg); }
            else return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
        }
        else
            return null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (enemy.transform.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        float? angle = RotateTurret();

        if (angle != null)
        {
            CreateBullet();
        }
        else
        {
            this.transform.Translate(0f, 0f, moveSpeed * Time.deltaTime);
        }
    }
}
