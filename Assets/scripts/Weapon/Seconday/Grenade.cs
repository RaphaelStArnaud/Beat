using UnityEngine;

public class Grenade : SecondaryWeapon
{
    GameObject grenade;
    bool exploded = false;
    bool canExplode = false;

    // Use this for initialization
    void Start()
    {
        explosionTime = 1;
        aoe = 6;
        animationTime = 1;
    }

    void Update()
    {
        explosionTime -= Time.deltaTime;

        if (explosionTime <= 0 && !exploded && canExplode)
            explode();

        if (exploded)
        {
            animationTime -= Time.deltaTime;

            if(animationTime <= 0)
                Destroy(transform.root.gameObject);
        }
    }

    public override void fire()
    {
        var player = GameObject.Find("Player");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.2f, player.transform.position.z);
        GetComponent<Rigidbody>().AddForce(player.transform.forward * 700);

        canExplode = true;
    }

    private void explode()
    {
        GameObject.Find("BigExplosionEffect").GetComponent<ParticleSystem>().Play();
        exploded = true;

        Collider[] colliders = Physics.OverlapSphere(transform.position, aoe);
        foreach (var col in colliders)
        {
            if (col.GetComponent<Collider>().tag == "Enemy")
            {
                Destroy(col.GetComponent<Collider>().gameObject);
            }
        }
    }

    public override int getReloadSpeed()
    {
        return 10;
    }
}
