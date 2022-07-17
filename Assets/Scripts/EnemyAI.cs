using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
	public Transform target;

	public float speed = 200f;
	public float nextWaypointDistance = 3f;

	public Transform enemyFacing;
	
	private Path _path;
	private int _currentWaypoint;
	public bool reachedEndOfPath;

	private Seeker _seeker;
	private Rigidbody2D _enemyRb2D;

	private void Start()
	{
		_seeker = GetComponent<Seeker>();
		_enemyRb2D = GetComponent<Rigidbody2D>();
		reachedEndOfPath = false;
		InvokeRepeating(nameof(UpdatePath), 0f, .5f);
		_seeker.StartPath(_enemyRb2D.position, target.position, OnPathComplete);
	}

	void UpdatePath()
	{
		if (_seeker.IsDone())
		{
			_seeker.StartPath(_enemyRb2D.position, target.position, OnPathComplete);
		}
	}
	void OnPathComplete(Path currentPath)
	{
		if (!currentPath.error)
		{
			_path = currentPath;
			_currentWaypoint = 0;
		}
	}

	public void FixedUpdate()
	{
		if (_path == null)
		{
			return;
		}

		if (_currentWaypoint >= _path.vectorPath.Count)
		{
			reachedEndOfPath = true;
			return;
		}
		else
		{
			reachedEndOfPath = false;
		}

		Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _enemyRb2D.position).normalized;
		Vector2 force = direction * (speed * Time.deltaTime);
		
		_enemyRb2D.AddForce(force);

		float distance = Vector2.Distance(_enemyRb2D.position, _path.vectorPath[_currentWaypoint]);

		if (distance < nextWaypointDistance)
		{
			_currentWaypoint++;
		}
		
		if (force.x >= 0.01f)
		{
			enemyFacing.localScale = new Vector3(-1f, 1f, 1f);
		} else if (force.x <= -0.01f)
		{
			enemyFacing.localScale = new Vector3(1f, 1f, 1f);
		}
	}
}
