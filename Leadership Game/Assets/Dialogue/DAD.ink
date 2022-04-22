Dad:  Hey Peanut!
    * [Give Dad the cold shoulder....] ME:  Hello Father
        DAD:  I AM your Father… But that sounds quite formal little miss, call me dad
            ** [Don’t Call me little miss!] ME:  OK Dad, but only if you stop calling me little miss… It’s demeaning
                DAD:  Haha I’m so stupid… I’m sorry, that’s my bad.. I’m just a little bit stressed about being trapped down here…
                    *** [Motivate Dad] -> msMotivator
            ** [Fine..] -> fine
    * [Be nice…] ME:  Hey Dad!! How are you holding up?
        DAD:  Well.. If I’m being totally my dear I get a little bit claustrophobic.. and seasick…. And it’s quite chilly down here right? That’s not just me?? (Shivering)
            ** [Fine..] -> fine
            ** [Motivate Dad] -> msMotivator
    
=== msMotivator ===
ME:  That’s OK, Dad.. We’re all going to get through this, together
DAD:  You’ve got a plan? You’re going to SAVE ME?! – I mean.. US?!
//would ideally use this decision and others in points based system to see how motivated/ satisfied NPCs are by game end
    * [Take credit]
        ME:  Yes! I will lead us to VICTORY! But I need your help -> heCanTryHeGuesses 
    * [We’re all in this together, everyone!]
        ME:  I do. Like I said, we’re going to get through this together.. as a family. Which means we all need to work together- will you help, Dad? 
            ** [Will you not help us?] -> heCanTryHeGuesses
        
=== fine ===
ME:  Fine.. Dad!
    * [Motivate Dad] -> msMotivator

=== heCanTryHeGuesses ===    
DAD:  Um… OK.. I can try, I guess   
    * [ Ask for help (NICE)]
        ME:  Amazing!  Thank you! Now, I need you to tell me something you’re good at? -> OK
    * [Ask for help (NASTY)]
        ME:  Right so is there anything you can actually do? Have a real think…
        DAD:  Oh god no! There’s nothing… Thanks for speaking to me like that, you’re a really good leader, I feel worthless now
            ** [Be mean again…] ME:  Ohhh you’re upset. Self-pity will get you nowhere 
                DAD:  (Scratching his head) Hahaha I’m so stupid… I’m absolutely useless
                    *** [Be mean again…] ME:  Come on DAD! You’re supposed to be the man of the house!! There must be at least SOMETHING you can do! Surely even you aren’t that utterly useless!  
                        DAD:  (Agitated!) Fine! I guess if I’m the man of the house I guess I must be big and strong! That’s me – big, strong, stupid DAD! Maybe I can use my HULK-ish MANLY strength?
                            **** [Stop being so mean now] ME: Right then.. Thank you.. Sorry for snapping.. Maybe we can work your strength into the plan somehow... -> help
                        
            ** [Apologise] ME:  Oh Dad I’m really sorry, I don’t mean to snap! I’m a little bit stressed about leading everyone to safety, but I shouldn’t take that out on you. I’m sorry -> OK
        
=== OK ===
DAD:  It’s OK, it’s OK. Thanks though.. I can definitely help… I suppose I make quite a stable footrest for your mother when she watches TV… I’m very sturdy!
    * [Be supportive] ME:  Mmmm ‘kay maybe we can work that into the plan…. Somehow? -> help
    
=== help ===
DAD:  I’ll help in whatever way I can…
    * [Ask more about strengths & weaknesses]
        ME:  And just so I know… Have you got any weaknesses or anything else you want me to bear in mind?
            DAD:  Well, I have sensitive skin… I’m quite prone to splinters.. -> choiceTime
    * [I should make use of his brute strength]
        ME:  OK well then, I guess if you’re strong I could fine you something heavy to move…. I’m sure that would help is getting out of here! -> bigDumbBrute
            
-> DONE

=== bigDumbBrute ===
DAD:  (Sad noises) If you can tell me what to do… I don’t know what I’m good for in here, that’s for you to decide peanut.. I’m just a big dumb brute -> choiceTime
=== choiceTime ===
// here is where we would implement correct/ incorrect checks

* [DIRECTS TO RIGHT ACTION]
    DAD:  I can’t carry the key for you…but I can carry you!
        **[Give Dad credit] ME:  You did it Dad, you saved us
            DAD:  (Proud Dad moment) No kid… WE saved us. We ESCAPEZED as a FAMILY! -> END
        **[Give Family credit] ME:  Just like I said dad… We got out of this together
            DAD:  (Proud Dad moment) WE sure did kid. We ESCAPEZED as a FAMILY! -> END
        **[Take  credit] ME:  (Nasty nasty) You’re lucky to have a daughter like me to get us out of your mess!
            DAD:  (Sad Dad moment) Well I don’t know if you’re right to take all the credit! I think we got out of this together but suit yourself… I guess there’ll be no Capri-Sun in the ride home for you. You’ll be able to get some all by yourself I’m sure. -> END
* [DIRECTS TO WRONG ACTION] 
    DAD:  Oh I don’t know. I guess I could try…
        **[Console Dad] ME:  It’s OK Dad, we can try again… we just need to find something to suit your specific strengths…
           -> help 
        **[Scold Father] ME:  (Scornfully) You really are useless aren’t you… What a PATHETIC excuse for a father and for a man! Why can’t you do this on simple task I ask of you!?
            DAD:  Gee, I wish I do it… but…. I keep getting splinters see.. I am a FAILUURREEEE!! (Father is distraught)
            -> bigDumbBrute
       