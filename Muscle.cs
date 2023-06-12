public class Muscle : IRobber
{
    public Muscle(string name, int skill, int percent){
        Name = name;
        SkillLevel = skill;
        PercentageCut = percent;
    }
    public string Name {get; set;}
    public int SkillLevel {get; set;}
    public int PercentageCut {get; set;}
    public string Type {get;} = "Muscle";


    public void PerformSkill(Bank bank)
    {
        // Take the Bank parameter and decrement its appropriate security score by the SkillLevel. i.e. A Hacker with a skill level of 50 should decrement the bank's AlarmScore by 50.
        bank.SecurityGuardScore -= SkillLevel;
// Print to the console the name of the robber and what action they are performing. i.e. "Mr. Pink is hacking the alarm system. Decreased security 50 points"
        Console.WriteLine($"{Name} is handling the security guards. Decrease security {SkillLevel} points");
// If the appropriate security score has be reduced to 0 or below, print a message to the console, i.e. "Mr Pink has disabled the alarm system!"
        if(bank.SecurityGuardScore <= 0){
            Console.WriteLine($"{Name} has taken out the guards");
        }

    }


}