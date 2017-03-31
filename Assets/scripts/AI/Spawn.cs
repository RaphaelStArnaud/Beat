/*
 * Copyright (c) 2015 Allan Pichardo
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *  http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */



using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public Transform player;

    private bool done = false;

    void Start()
    {
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
    }

    void onOnbeatDetected()
    {
        if (GameManager.alive)
        {
            float change;

            if (UnityEngine.Random.value < 0.5f)
                change = -0.01f;
            else
                change = 0.01f;

            int lowerBound = 6 - ((100 - GameManager.difficulty) / 50);
            int upperBound = (int) Math.Ceiling((decimal)(6 + (GameManager.difficulty / 25)));
            int speed = UnityEngine.Random.Range(lowerBound, upperBound);

            Vector3 location = new Vector3 (0,0,0);

            while (!done)
            {
                location = new Vector3(UnityEngine.Random.Range(-28.0f, 28.0f), 0.6f, UnityEngine.Random.Range(-22.0f, 20.0f));

                if (Math.Abs(location.x - player.position.x) > 10 && Math.Abs(location.z - player.position.z) > 8)
                    done = true;
            }

            if (change >= 0)
            {
                blue.GetComponent<AI>().change = 0.01f;
                blue.GetComponent<AI>().speed = speed;
                Instantiate(blue, location, Quaternion.identity);
            }
            else {
                red.GetComponent<AI>().change = -0.01f;
                red.GetComponent<AI>().speed = speed;
                Instantiate(red, new Vector3(UnityEngine.Random.Range(-28.0f, 28.0f), 0.6f, UnityEngine.Random.Range(-22.0f, 20.0f)), Quaternion.identity);
            }

            done = false;

        }
    }
}
