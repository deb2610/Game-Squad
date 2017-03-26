﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GamePrototype.Classes
{
    class Clue
    {
        // TODO: This class should have a texture, which will be an image file of the clue information.
        // Should also have a string property for flavor/pickup text, and potentially a thumbnail image.
        Texture2D clueImg; // the clue itself to be displayed on screen
        String flavorText;

        // default constructor
        public Clue()
        {

        }
        // constructor with flavorText
        public Clue(string text)
        {
            flavorText = text;
        }

        // TODO: Caleb - Clue Dictionary should go here, it will be static
        private static Dictionary<string, Clue> clues = new Dictionary<string, Clue>
        {
            {"News1", new Clue("Details revealed about the disappearance of the wealthy widow Olivia Afton.")},
            {"News2", new Clue("Another body was pulled from the Humerus River with lacerations. The press begins to call the string a deaths a serial event, branding the killer “The Funnybone Killer”") },
            {"News3", new Clue("Reports of a missing girl have began to surface after deaths of Mr and Mrs. Edward Afton. The question on everyone's minds is: Where is Elizabeth Afton? ") },
            {"News4", new Clue("Reports that Afton Manor has been acquired by the state due to no live heirs") },
            {"News5", new Clue("A bed of remains have been found near the river yet again, this time with an unidentified number of victims. The repeated" /*TODO: Finish sentence */ ) },
            {"Bathroom Key", new Clue("It's a key to the bathroom") },
            {"Closet Key", new Clue("It's a key to the closet") },
            {"OldPhoto1", new Clue("It's a photo of the house, when it was constructed") },
            {"OldPhoto2", new Clue("It's a photo of Liz, and her parents Olivia and Edward") },
            {"OldPhoto3", new Clue("It's a photo of the cutlery rack in the kitchen, it has a spot missing.") },
            {"NewPhoto", new Clue("It's a stained polaroid of Olivia, unconscious on the floor.") },
            {"TenantDiary1", new Clue("Introduction to Deborah and Katie, the tenants that moved in after the house was taken over.") },
            {"TenantDiary2", new Clue("Deb confesses to the struggles of raising a moody teen singlehandedly. She even has to keep a hidden key to the closet for when Katie locks herself in.") },
            {"TenantDiary3", new Clue("Deb is scared. She found the lock to the house broken last night and the locksmith is booked out for another 3 days. She hopes that the chair under the handle tactic will work but still is anxious.") },
            // TODO: Caleb - I'm confused about the lamp/lampshade; is one of them a clue, or does it just lead to the blacklight?
            {"CrazyDiary1", new Clue("An unnerving account of how a crazy person disposed of a dead body") },
            {"CrazyDiary2", new Clue("An account of how to get blood out of clothing before a funeral") },
            {"CrazyDiary3", new Clue("The tale of how a little girl tortured and killed her neglectful parents") },
            {"Receipt", new Clue("Receipt from the local general store for bleach, hydrogen peroxide, gardening tools and other various food items. Payed for by card") },
            {"Ring", new Clue("A ring that use to belong to Olivia Afton") },
            {"Pendant", new Clue("It's a locket. It won't seem to open.") },
            {"Bones", new Clue("Unidentified bones found in the wastebin in the bathroom") },
            {"JaggedKnife", new Clue("Stained knife found in the bathtub. It's seems like a modified kitchen knife") },
            {"SpaCoupon", new Clue("It's an expired spa coupon... too bad.") },
            {"MedicineBottle", new Clue("It's a prescription for something called ”ARIPIPRAZOLE” the rest of the sicker is ripped.") },
            {"StickyNote", new Clue("It has some phone numbers on it. Some are scribbled out.") }
        };

        // Caleb accessor property for dictionary, call this in setups
        public static Dictionary<string, Clue> Clues
        {
            get { return clues; }
        }

    }
}
