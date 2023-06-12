public class Bank 
{
    
// An integer property for CashOnHand
public int CashOnHand {get; set;}
// An integer property for AlarmScore
public int AlarmScore {get; set;}
// An integer property for VaultScore
public int VaultScore {get; set;}

// An integer property for SecurityGuardScore
public int SecurityGuardScore {get; set;}

// A computed boolean property called IsSecure. If all the scores are less than or equal to 0, this should be false. If any of the scores are above 0, this should be true

public bool IsSecure { get {
    if( AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0 )
    {
        return true ; 
    }
    else {
        return false;
    }
}}
public void Report() {
// Let's do a little recon next. Print out a Recon Report to the user. This should tell the user what the bank's most secure system is, and what its least secure system is (don't print the actual integer scores--just the name, i.e. Most Secure: Alarm Least Secure: Vault

List<KeyValuePair<string, int>> scores = new List<KeyValuePair<string, int>>();
    scores.Add(new KeyValuePair<string, int>("Alarm Score", AlarmScore));
    scores.Add(new KeyValuePair<string, int>("Vault Score", VaultScore));
    scores.Add(new KeyValuePair<string, int>("Security Guard Score", SecurityGuardScore));
    
    var sortedList = scores.OrderBy(x => x.Value).ToList();
        
        Console.WriteLine("Here's what we scoped out");
        Console.WriteLine($"The most secure system is the {sortedList[2].Key} {sortedList[2].Value} ");
        Console.WriteLine($"The least secure system is the {sortedList[0].Key} {sortedList[0].Value} ");
    
}

}

