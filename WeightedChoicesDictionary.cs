﻿using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Base {
  public class WeightedChoices<T> : Dictionary<T, double> {
    public WeightedChoices(IDictionary<T, double> dict) : base(dict) { }

    public WeightedChoices(IEnumerable<ObjectChancePair<T>> chances) :
      this(chances.ToDictionary(pair => pair.Key,
                    pair => pair.Chance)) { }
  }

  public class ObjectChancePair<T> {
    public ObjectChancePair(T key, double chance) {
      Key = key;
      Chance = chance;
    }

    public T Key { get; private set; }
    public double Chance { get; private set; }
  }
}
