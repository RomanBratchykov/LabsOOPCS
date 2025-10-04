using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6;

public class Mood
{
    public virtual string Name { get; set; }
}

public class Angry : Mood { public override string Name => "Angry"; }
public class Sad : Mood { public override string Name => "Sad"; }
public class Happy : Mood { public override string Name => "Happy"; }
public class HeavenlyMood : Mood { public override string Name => "Heavenly"; }

public class MoodFactory
{
    public Mood CreateMood(int happiness)
    {
        if (happiness < -5) return new Angry();
        if (happiness >= -5 && happiness <= 0) return new Sad();
        if (happiness >= 1 && happiness <= 15) return new Happy();
        return new HeavenlyMood();
    }
}
