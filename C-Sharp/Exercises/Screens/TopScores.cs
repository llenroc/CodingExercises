using System;
using System.Collections.Generic;


/*
Microsoft Screen

Return always the Top MAX_SCORES (10) from the highest to the lowest
The scores are added/removed by passing a list of scores (int[])
if a score from the Top list is removed, then rest of the scores are move one spot up
if not scores, return a empty list
*/
public class TopScores
{
    int MAX_SCORES = 10;
    private int _availableSpots = 10;
    private int _higest = -1;
    private int _lowest = -1;
    private LinkedList<int> _additionalScores = new LinkedList<int>();
    private LinkedList<int> _topScores = new LinkedList<int>();

    private static TopScores instance=null;
    private static readonly object padlock = new object();

    private TopScores() {}

    public static TopScores Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null) instance = new TopScores();
                return instance;
            }
        }
    }

    public int[] Scores 
    { 
        get
        {
            int[] result = new int[_topScores.Count];
            var index = 0;
            foreach (var item in _topScores)
            {
                result[index++] = item;
            }
            return result;
        }
    }

    public void Insert(int[] newScores)
    {
        if (newScores == null || newScores.Length == 0) return;

        if (_higest == -1)
        {
            initialize(newScores);
            return;
        }

        foreach (int s in newScores)
        {
            if (_topScores.Count == 0 || s < _lowest)
            {
                if (_availableSpots == 0)
                {
                    MoveOut();
                    deleteTopScore(s);
                }
                insertTopScore(s);
            }
            else
            {
                insertAdditionalScore(s);
            }
        }
    }

    public void Delete(int[] scores)
    {
        if (scores == null || scores.Length == 0) return;

        foreach (int s in scores)
        {
            if (s >= _lowest)
            {
                deleteTopScore(s);
                MoveIn();
            }
            else
            {
                deleteAdditionalScore(s);
            }
        }
    }

    private void insertTopScore(int score)
    {
        if (_topScores.Count == 0 || score > _lowest)
        {
            foreach (var s in _topScores)
            {
                if (s < score)
                {
                    _topScores.AddBefore(_topScores.Find(s), score);
                }
            }
        }
        else
        {
            _topScores.AddLast(score);
        }

        _lowest = _topScores.Last.Value;
        _higest = _topScores.First.Value;
        _availableSpots--;
    }

    private void insertAdditionalScore(int score)
    {
        foreach (var s in _additionalScores)
        {
            if (s > score)
            {
                _additionalScores.AddBefore(_additionalScores.Find(s), score);
            }
        }
    }

    private void deleteTopScore(int score)
    {
        LinkedListNode<int> toDelete = _topScores.Find(score);
        if (toDelete != null)
        {
            _topScores.Remove(toDelete);
            _availableSpots++;

            if (_topScores.Count > 0)
            {
                _lowest = _topScores.Last.Value;
                _higest = _topScores.First.Value;
            }        
        }
    }

    private void deleteAdditionalScore(int score)
    {
        LinkedListNode<int> toDelete = _additionalScores.Find(score);
        if (toDelete != null)
        {
            _additionalScores.Remove(toDelete);
        }
    }

    private void MoveIn()
    {
        if (_additionalScores.Count > 0)
        {
            var toMoveIn = new LinkedListNode<int>(_additionalScores.First.Value);
            _additionalScores.RemoveFirst();
            _topScores.AddLast(toMoveIn);

            _availableSpots--;
            _lowest = _topScores.Last.Value;
            _higest = _topScores.First.Value;
        }
    }

    private void MoveOut()
    {
        var toMoveOut = new LinkedListNode<int>(_topScores.Last.Value);
        _topScores.RemoveLast();
        _additionalScores.AddFirst(toMoveOut);
    }

    private void initialize(int[] scores)
    {
        Array.Sort(scores);
        Array.Reverse(scores);

        for (int i = 0; i < Math.Min(scores.Length, MAX_SCORES); i++)
        {
            _topScores.AddLast(scores[i]);
            _availableSpots--;
        }
        _lowest = _topScores.Last.Value;
        _higest = _topScores.First.Value;

        if (scores.Length > MAX_SCORES)
        {
            for (int i = MAX_SCORES; i < scores.Length; i++)
            {
                _additionalScores.AddLast(scores[i]);
            }
        }
    }
}