﻿using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class RankingSystem
{
    public int Id { get; set; }

    public string SystemName { get; set; }

    public virtual ICollection<RankingCriterion> RankingCriteria { get; set; } = new List<RankingCriterion>();
}
