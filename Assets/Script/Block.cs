using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] AudioClip[] breakSounds;
	[SerializeField] GameObject blockSparklesVFX;
	[SerializeField] Sprite[] hitSprites;

	Level level;
	GameStatus gameStatus;
	SpriteRenderer spriteRenderer;

	[SerializeField] int timesHit;

	private void Start()
	{
		level = FindObjectOfType<Level>();
		gameStatus = FindObjectOfType<GameStatus>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (tag == "Breakable")
		{
			level.CountBreakableBlocks();
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		int maxHit = hitSprites.Length + 1;
		if (tag == "Breakable")
		{
			timesHit++;
			if (timesHit >= maxHit)
			{
				DestroyBlock();
			}
			else ShowNextHitSprite();
		}
	}

	private void ShowNextHitSprite()
	{
		if (hitSprites[timesHit - 1] != null)
		{
			spriteRenderer.sprite = hitSprites[timesHit - 1];
		}
		else
		{
			Debug.LogError("Block sprite is missing from array for object " + gameObject.name);
			
		}
	}

	private void DestroyBlock()
	{
		AudioSource.PlayClipAtPoint(breakSounds[Random.Range(0, breakSounds.Length)], Camera.main.transform.position);
		level.BlockDestroyed();
		gameStatus.AddToScore();
		TriggerSparklesVFX();
		Destroy(gameObject);
	}

	private void TriggerSparklesVFX()
	{
		GameObject particles = Instantiate(blockSparklesVFX, transform.position, Quaternion.identity);
		Destroy(particles, 2);
	}
}
