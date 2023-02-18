using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHp;
    [SerializeField] protected int _currentHp;
    [SerializeField] protected int _deathTime;

    // public event Action<float> OnHealthChanged;
    
    protected bool _isAlive = true;
    protected bool _canFinished = false;
    protected TemporaryDialogue _temporaryDialogue;

    public bool CanFinished
    {
        get
        {
            return _canFinished;
        }
    }

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
    }
    public void Start(){
        _temporaryDialogue = gameObject.GetComponent<TemporaryDialogue>();
    }
    virtual public void TakeHit(int damage)
    {
        _currentHp -= damage;

        // OnHealthChanged?.Invoke(_currentHp);

        // OnHealthChanged += Handler;

        if (_currentHp <= 0)
        {
            _isAlive = false;
            _currentHp = 0;
        }
        if (_temporaryDialogue)
            _temporaryDialogue.StartDialogue();
            
        if ((float) _currentHp / _maxHp <= 0.25f)
        {
            _canFinished = true;
        }
    }

    // private void Handler(float damage) {
    //     ///
    // }

    virtual public void Heal(int healHp)
    {
        _currentHp += healHp;

        if (_currentHp > _maxHp)
        {
            _currentHp = _maxHp;
        }
    }

    virtual public void Death(){

        Destroy(gameObject, _deathTime);
    }
}
