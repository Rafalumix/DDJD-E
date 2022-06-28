using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScrollManager
{
    private static string[] messages = {"Welcome to the tutorial room! During your long journey, you can find some pages very similar to the ones you are reading. Reading them you will be able to get to know the history of this majestic castle of Arnithlond in depth. Have fun out there!",
    "The majestic castle of the Arnithlond was finished in the year 725. The castle was built by the Arnith  first ancestor, Tephye, a great king who has always been admired for the long period of peace and wealth he managed to bring within the region.",
    "After the death of the twelfth king , Aldrer, for the first time, the house had no male heir. It was unanimously agreed  by the king’s counselors to have King Aldrer's  eldest daughter, Kathil, ascend the throne. Kathil had always been at the center of royal affairs, as the family had already prepared for this eventuality.",
    "As her reign started the big trouble occurred:  Kathil had no intention of choosing another king, as she wanted to keep her reign independent and by marrying another king this wouldn’t happen. For this reason, she said she shall instead remain married to the kingdom until death embraces her. ",
    "I have been writing the story of this royal family for centuries inside my tower. For this reason, I want to write this note to introduce myself, as I haven't done so until now. I am Eadwean, magician, court advisor, librarian, and scholar at the Arnithlond castle’s library.",
    "It is necessary to find a worthy heir to the throne. Meanwhile, our ancient allies  are fighting each other to choose who should have control over these lands in case there are no valid heirs. Everyone inside the castle is starting to worry, thinking that once the queen dies, we will be attacked by our neighbors to conquer our lands.",
    "The queen died a few days ago and was poisoned, a few days later our reign was attacked by  Burhiua, king of the nearby castle of Corna . We all know that it was a plan that he most likely concocted.",
    "My queen, I will try to keep your promis e and not let the castle fall into enemy hands. I will do everything I can to avoid this, and I will use my years of studies to summon an army to fight them.",
    "They have been attacking us for generations, now their dynasty is convinced that they are attacking us to regain a castle stolen from them by a necromancer, which would be me . History has been unfair to our home; we have brought peace to this kingdom, and we have already been forgotten and regarded as barbarians that use dark magic.",
    "To overcome the attackers, I had to draw heavily on dark arcane powers, as all our soldiers were lost in the first major battles. I feel that this magic is hurting my body, it seems that I am getting sick and that all my energies are no longer coming from my body but somewhere external.",
    "They are coming. Now the castle is under siege, and they continue to send stronger soldiers. I don't know how long I will be able to keep my promise, but one thing is certain: I will defend the honor of the family and give my life if necessary.",
    "Black magic has taken total power over my body. My skin is burning and corrupting. I am transforming beyond belief. I do not care. As long as I have energy in my body to exercise these dark arts. I will resist. They are the only way. I have to defend my word and my honor.",
    "He  is here, coming to the doors of my room. I don't know if I'll be able to resist. I can’t fight. Forgive me my queen, for I have failed .",
    };
    private static string[] titles = {"",
    "1. The Origins",
    "2. The First Queen",
    "3. The Wife of the Kingdom",
    "4. About me",
    "5. Court Problems",
    "6. The Poisoning",
    "7. The Promise",
    "8. The Lie",
    "9. The Sickness",
    "10. The End",
    "11. The Corruption",
    "",
    };

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
