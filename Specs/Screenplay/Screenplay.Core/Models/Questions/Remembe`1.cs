﻿using Screenplay.Core.Models.Actors;

namespace Screenplay.Core.Models.Questions
{
    internal class Remember<T> : IQuestion<T>
    {
        private readonly string _key;
        internal Remember(string key)
        {
            _key = key;
        }
        public T AnsweredBy(Actor actor)
        {
            return actor.Recall<T>(this._key);
        }
    }
}