using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScrollManager
{
    private static string[] messages = {"Welcome to the tutorial room! During your long journey, you can find some pages very similar to the ones you are reading. Reading them you will be able to get to know the history of this majestic castle of Arnithlond in depth. Have fun out there!",
    "The majestic castle of the Arnithlond was finished in the year 725 of the fourth moon. The castle was built by the Arnmulfs' first ancestor, Tephye, a great king who has always been admired for the long period of peace and wealth he managed to bring within the region.",
    "The first heir to the throne, Witheard, reigned very little due to an illness that struck him as a young man and being late to the throne due to the longevity of the previous king, Tephye. He, therefore, ascended the throne to his son, very young, Symath.",
    "Symath was known for his particular sympathy. Right from the start, realizing that he had to somehow fill the lack of experience due to his young age, he undertook to form diplomatic alliances that led the kingdom to obtain strong security from a military point ",
    "After the death of the twelfth king, for the first time, the house has no male heir. It was unanimously agreed to have King Aldrer's eldest daughter, Kathil, ascend the throne. Kathil has always been at the centre of royal affairs as the family had already prepared for this eventuality.",
    "Her reign starts to show the first problems, Kathil has no intention of choosing another king as her husband wants to keep her reign independent of her, but her royal blood does not allow her to marry ordinary people either. She says she will remain married to the kingdom until death embraces her. ",
    "I have been writing the story of this royal family for centuries inside my tower. For this reason, I want to write this note to introduce myself, as I haven't done so until now. I am Eadwean, magician and court advisor, librarian and scholar at the immense Arnithlond castle library.",
    "It is necessary to find a worthy heir to the throne. Meanwhile, our ancient allies are fighting each other to choose who should have control over these lands in case there are no valid heirs. Everyone inside the castle is starting to worry, thinking that once the queen dies, we will be attacked by our neighbors to conquer our lands.",
    "The queen died a few days ago and was poisoned, a few days later she started attacking Burhiua, king of the nearby castle of Corna. We all know that it was a plan that he most likely concocted.",
    "My Queen, I will try to keep her promise and not let the castle fall into enemy hands. I will do everything to avoid this and will use my years of studies to summon an army to fight them.",
    "They have been attacking us for generations, now their dynasty is convinced that they are attacking us to regain a castle stolen from them by a necromancer, which would be me. History has been unfair to our home, we have brought peace to this kingdom and we have already been forgotten and regarded as barbarians using dark magic.",
    "They are coming, now the castle is under siege and they continue to send new and stronger soldiers. I don't know how long I will be able to keep my promise, but one thing is certain: I will defend the honor of the family to the death if necessary.",
    "He is here, coming to the doors of my room. I don't know if I'll be able to resist. Forgive me my queen if I have failed.",
    };
    private static string[] titles = {"",
    "1. The Origins",
    "2. The Young King",
    "3. The Alliances",
    "4. The First Queen",
    "5. The Wife of the Kingdom",
    "6. About me",
    "7. Court Problems",
    "8. The Poisoning",
    "9. The Promise",
    "10. The Lie",
    "11. The End",
    "",
    };

    public static void readTutorialText()
    {
        
    }
    public static string readTitle(int n)
    {
        return titles[n]; 
    }
    public static string readText(int n)
    {
        return messages[n]; 
    }

    public static bool isUnlockedSecretEnding()
    {
        if (PlayerStats.lastNoteRead >= 12)
        {
            return true; 
        } return false; 
    }
   
}
