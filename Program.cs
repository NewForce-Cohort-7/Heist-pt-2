// See https://aka.ms/new-console-template for more information

List<IRobber> rolodex = new List<IRobber>(){
    new Hacker("Henry", 50, 9),
    new Hacker("Harriet", 50, 15),
    new LockSpecialist("Luke", 55, 10),
    new LockSpecialist("Lucy", 50, 10),
    new Muscle("Mark", 50, 10),
    new Muscle("Mary", 50, 10)
};

while(true){
Console.WriteLine($"Let's plan a heist. You currently have {rolodex.Count} contacts in the rolodex.");
Console.WriteLine($"-----------------------------------");
Console.WriteLine($"Add a new contact:");
string name = Console.ReadLine();

if(name == ""){
    break;
}

Console.WriteLine($"Select their Specality");
Console.WriteLine($"-----------------------------------");
Console.WriteLine($"1) Hacker (Disables alarms)");
Console.WriteLine($"2) Muscle (Disarms guards)");
Console.WriteLine($"3) Lock Specialist (cracks vault)");
string specialty = Console.ReadLine();
Console.WriteLine($"What's their skill level? ( 1-100 )");
string skillLevel = Console.ReadLine();
Console.WriteLine($"What's their cut? ( 1-100 ) ");
string cut = Console.ReadLine();

if(specialty == "1"){
    Hacker newMember = new Hacker(name, int.Parse(skillLevel), int.Parse(cut));
    rolodex.Add(newMember);
}
else if ( specialty == "2" ){
    Muscle newMember = new Muscle(name, int.Parse(skillLevel), int.Parse(cut));
    rolodex.Add(newMember);
}
else if ( specialty == "3" ){
    LockSpecialist newMember = new LockSpecialist(name, int.Parse(skillLevel), int.Parse(cut));
    rolodex.Add(newMember);
}

}

Bank bank = new Bank()
     {
        CashOnHand = new Random().Next(50000, 1000000),
        AlarmScore = new Random().Next(0, 100),
        VaultScore = new Random().Next(0, 100),
        SecurityGuardScore = new Random().Next(0, 100)
    };


 bank.Report();

Console.WriteLine("Time to select our crew.");

List<IRobber> crew = new List<IRobber>();
int totalCut = 0;
while(true){

for(int i = 0; i < rolodex.Count; i++){

    if(!crew.Contains(rolodex[i]) && (rolodex[i].PercentageCut + totalCut) <= 100){

    Console.WriteLine("---------------------------");
    Console.WriteLine($"Press {i + 1} to choose member :");
    Console.WriteLine($"Name: {rolodex[i].Name}");
    Console.WriteLine($"Speciality: {rolodex[i].Type}");
    Console.WriteLine($"Skill Level: {rolodex[i].SkillLevel}");
    Console.WriteLine($"Cut: {rolodex[i].PercentageCut}");
    Console.WriteLine($"---------------------------");
    }
    Console.WriteLine("Select a member or press enter to start Heist:");

}

string selection = Console.ReadLine();

if(selection == ""){
    break;
}

crew.Add(rolodex[int.Parse(selection)-1]);

totalCut = crew.Sum(x => x.PercentageCut);
Console.WriteLine(totalCut );
}

foreach(IRobber crewMember in crew){
    crewMember.PerformSkill(bank);
}

if(bank.IsSecure)
{
    Console.WriteLine("The heist was a faiure");
}
else{
    Console.WriteLine("The heist was a success");
    int myCut = 100 - crew.Sum(x => x.PercentageCut);

    crew.ForEach(x => Console.WriteLine($"Well done {x.Name}. Your take is {(bank.CashOnHand * x.PercentageCut)/100}"));
    Console.WriteLine($"Ourtake is {(bank.CashOnHand * myCut)/100}");

}





// If the heist was a success, print out a report of each members' take, along with how much money is left for yourself.



