void main()
{
    chestState chest = chestState.locked;
    string action;

    do
    {
        Console.Write($"The chest is {chest}. What do you want to do? ");
        action = Console.ReadLine();

        if (action == "open" && chest == chestState.unlocked)
        {
            chest = chestState.open;
        }
        else if (action == "close" && chest == chestState.open)
        {
            chest = chestState.unlocked;
        }
        else if (action == "unlock" && chest == chestState.locked)
        {
            chest = chestState.unlocked;
        }
        else if (action == "lock" && chest == chestState.unlocked)
        {
            chest = chestState.locked;
        }
    }
    while (true);
}
main();

enum chestState {locked, unlocked, open}
