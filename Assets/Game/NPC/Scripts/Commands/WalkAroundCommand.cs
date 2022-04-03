using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.NPC.Deer.Scripts.States
{
    public class WalkAroundCommand : Command, ITickable
    {
        private CharacterStorage _storage;
        private CharacterView _view;
        private TickableManager _tickableManager;
        private NavMeshPath _path;
        private Vector3 _destination;        

        public GUID ID;

        public WalkAroundCommand(TickableManager tickableManager, CharacterStorage storage, IInstantiator instantiator)
        {            
            _tickableManager = tickableManager;
            _storage = storage;            
            _path = new NavMeshPath();
        }

        public override CommandResult Do()
        {
            _view = _storage.GetCharacter(ID).View;
            GoToRandomPosition();
            _tickableManager.Add(this);
            return base.Do();
        }

        public override void Cancel()
        {
            Done?.Invoke(this, EventArgs.Empty);                        
        }

        private void GoToRandomPosition()
        {
            bool cond = false;            
            while (!cond)
            {
                NavMeshHit hit;
                NavMesh.SamplePosition(Random.insideUnitSphere * 100 + _view.Position, out hit, 100, NavMesh.AllAreas);
                _destination = hit.position;                
                
                var go = GameObject.Find("Goal");
                go.transform.position = _destination;
                
                _view.NavMeshAgent.CalculatePath(hit.position, _path);
                cond = _path.status == NavMeshPathStatus.PathComplete;
            }

            _view.NavMeshAgent.SetDestination(_destination);
        }

        public void Tick()
        {
            if (Vector3.Distance(_view.Position, _destination) <= 5f)
            {
                GoToRandomPosition();
            }
        }        
    }
}