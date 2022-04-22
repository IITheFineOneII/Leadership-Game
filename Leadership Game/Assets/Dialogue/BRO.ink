BRO:  ‘Sup sis? 
    * [Nice sister]
        ME:  Hey bro… how you doing?
        BRO:  I’m alright! You, sis? We should think about getting out of here soon - eh?
        ME:  Right on brother! Lets get out of here!
            -> help
            
    * [Nasty sister]
        ME:  “Sup”? Stop trying to be cool! We’re stuck in here.. can you not be serious for once!
        BRO:  I’m not trying to be cool, I’m just a natural… Anyway you’re mean! You’re a mean, old, nasty cotton-headed ninny-muggins!
            **[Apologise] -> Apologise
            **[Be meaner] ME:  (Harshly) Ahahaha “cotton-headed ninny-muggins”! You aren’t cool, and you never will be cool! Never!! CAPEESH!? Now are you gonna help us get out of here or what?
                BRO:  Well to be honest I don’t know if I want to help someone who talks to me like that. I might be younger than you but that doesn’t mean you get to treat me like a sausage.
                    ***[Apologise] -> Apologise
                    ***[HELP ME!] ME:  (Ferociously) As your superior I DEMAND you help me!  
                        BRO:  No. No I don’t think I will. After all why should I?
                            ****[Demand help again] ME:  (Ferociously) I DEMAND you help me!
                                BRO:  Eat my shorts!
                                    *****[Apologise] -> Apologise
                            ****[Apologise] -> Apologise
=== slingshot ===
BRO:  (Indignantly) I’m NOTHING without my slingshot! BUT… with it… I can do anything
    *[Understood!]
        -> preBiz
    *[Ask weaknesses] ME:  And is there anything you can’t do.. or do have any weaknesses I should know about?
        BRO:  I’m allergic to peanuts, tree nuts, eggs and milk.
            **[Umm.. OK] ME:  Ummm.. no peanuts, tree nuts, eggs or milk.. OK, I’ll bear that in mind...
                -> preBiz

=== Apologise ===
    ME:  I’m sorry I’m sorry. You are cool… sometimes… It’d be cool if you could help me get us out of here?
        -> help

=== help ===
BRO:  Alright..What can I do to help?
    ** [Ask for help (NASTY)]
                ME:  (Scornfully) I’d imagine not… but do you have any skills or talents? Any at all?
                BRO:  (Very sad) Ummm… no I don’t think so… You’re right about me… (snuffles)
                    ***[Shame Bro] ME:  (Nastily) God you really are useless!
                        BRO:  (Sad noises) I am useless!
                                ****[Show some empathy] -> itsOKBRO
                                ****[Shame! SHAME!] ME:  (Nasty) Useless! You’re worthless! You’re nothing! SHAME! SHAME!
                                    BRO:  (Crying hysterically) You’re right… I can’t do anything!
                                        *****[Show some empathy] -> itsOKBRO

                    ***[Show some empathy] -> itsOKBRO
            ** [Ask for help (NICE)]
                ME:  (Encouragingly) So how can you help us! I know that brother of mine has a trick or two hidden up his sleeve… 
                    -> slingshot
                    
=== itsOKBRO ===
ME:  (Kindly) It’s ok BRO! There’s something you’re good at, definitely! You just have to believe in yourself a little more!
-> slingshot

=== preBiz ===
ME:  (Encouraging) So you want to do something with your slingshot! Interesting…
BRO:  Give me somethin' to break! Give me somethin' to break! Just give me somethin' to break! I'll do my best!
    *[Rock!] 
        OK chocolate starfish.. I'll find you something to break 
            -> DONE
    *[Anime!]
        For humanity's sake, dedicate your hearts!
            -> DONE
        //Need to figure out how to pause dialogue here for player to solve action
        
=== youDidIt ===
BRO:  I did it! I can’t believe I did it!
    * [Give Bro credit] ME:  You did it Bro, what a shot! You’ve saved us all!!
        BRO:  (Gratefully) I wouldn’t have made that shot if it wasn’t for you sis! I needed you to believe in me! I would have followed you, my sister… my Captain… my Leader
            ->END
    * [Take  credit] ME:  I am good… We would never escape if it wasn’t for me telling you all what to do!
        BRO:  (Upset little brother) Sure sis… You save us all…
            ->END

    
