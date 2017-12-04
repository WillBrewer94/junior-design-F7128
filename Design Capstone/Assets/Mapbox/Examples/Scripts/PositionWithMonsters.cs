	using Mapbox.Utils;
	using Mapbox.Unity.Location;
	using Mapbox.Unity.Utilities;
	using Mapbox.Unity.Map;
	using UnityEngine;

	public class PositionWithMonsters : MonoBehaviour
	{
		[SerializeField]
		private AbstractMap _map;

		/// <summary>
		/// The rate at which the transform's position tries catch up to the provided location.
		/// </summary>
		[SerializeField]
		float _positionFollowFactor = 0.5f;

		[SerializeField]
		Transform[] _monsters;

		bool _isInitialized;
		int _count;
		Vector3[] _targetPositions;

		void Start()
		{
			_map.OnInitialized += () => _isInitialized = true;
			_map.OnInitialized += Query;
		}

		void OnDestroy()
		{
			_map.OnInitialized -= Query;
		}

		void Query()
		{
			_map.OnInitialized -= Query;
			if (_isInitialized)
			{
				_count = _monsters.Length;
				Vector2d[] positions = { new Vector2d{x=33.777435,y=-84.397321}, 
                         				 new Vector2d{x=33.772566,y=-84.392874},
                         				 new Vector2d{x=33.775944,y=-84.395149}
                         			  };
                 _targetPositions = new Vector3[_count]; 
                for (int i = 0; i < _count; i++){
                 	 _targetPositions[i] = Conversions.GeoToWorldPosition(positions[i],
																 _map.CenterMercator,
																 _map.WorldRelativeScale).ToVector3xz();
                 	 _targetPositions[i].y = 1;
                }
				for (int i = 0; i < _count; i++)
				{
					_monsters[i].position = Vector3.Lerp(_monsters[i].position, _targetPositions[i], Time.deltaTime * _positionFollowFactor);
				}
			}
		}

		void Update()
		{
			for (int i = 0; i < _count; i++)
				{
					_monsters[i].position = Vector3.Lerp(_monsters[i].position, _targetPositions[i], Time.deltaTime * _positionFollowFactor);
				}
	    }
	}
