# Krankenhaus-grpupg
Överbelastat Sjukhus Simulator

Ni ska...Skapa en simulering av ett överbelastat sjukhus/sanatoriumdär patienterna har drabbats avgalopperande Martian Killer Krud förkortat MKK. 
Sjukhusetskall hantera patienter som anländer,genomgår en sjukdomsbehandling och förhoppningsvistillfrisknar, annars så hamnar de i afterlife
och klagar på behandlingen i after-yelp. Patienterna anmäls till sjukhuset och påbörjar sinvandring till hälsa eller ett afterlife genom flerasteg 
i kronologisk ordning. Under hela processen ändrasderas sjukdomsnivå. Om en patient får ensjukdomsnivå som är lika med 0 är de friska. 
Om defår en sjukdomsnivå som är lika med 10 är deavlidna och hamnar i afterlife.Simuleringen drivs av en ticker, mer information omdetta finns längre ner. 

_____________________________________________________________________________________________________________________________________________________________

Flödet i simuleringen serut enligt nedan: 

1.AnmälanSkapa ett patientobjekt med framslumpat namn, födelsedatumoch sjukdomsnivå (på enskala 0-10).
För sjukdomsnivå i hela simuleringen så gäller att en sjukdomsnivå som är <= 0 kan aldrighöjas, patienten är immun efter tillfrisknande. 
Depatienter nått sjukdomsnivå 10 kan aldrig sänka sin sjukdomsnivå och därmed inte heller lämna afterlife.


2.Kö för inläggningI denna kö så hamnar patientobjekten i den ordningde skapas. Köplatsen påverkas inte avsjukdomsnivå. 
För varje justering av sjukdomsnivånhar patienter i kön 80% risk för att få enhöjd sjukdomsnivå, 
15% chans att sjukdomsnivån kvarstår,5% att naturlig tillfriskning sker,det vill säga att sjukdomsnivån sjunker.


3. Inläggning till sanatorium eller iva i mån av platsNär en patient hämtas ut från kön läggs de in på IVAeller Sanatoriet, 
var man hamnar berorenbart på om det finns plats på Iva eller sanatorietoch påverkas inte av sjukdomsnivå. IVAhar 5 platser, 
5Sanatoriet har 10 platser.a.För varje justering av sjukdomsnivån har patienterpåSanatoriet50% risk för att fåen höjd sjukdomsnivå, 
15% chans att sjukdomsnivånkvarstår, 35% att behandlingenhjälper och att sjukdomsnivån minskar. 
på IVA så är chansen för tillfrisknande ett steg 70%, 20% att sjukdomsnivån äroförändrad och 10% att patienten blir sämre.


4. Eventuell tillförsel av extraläkareNär programmet startar så finns det 10 st extraläkareatt tillgå på IVA. 
Dessa extraläkare harett namn, en utmattningsnivå 0-20 som börjar på 0(noll) samt en kompetensnivå från -10(minus tio) till 30. 
Kompetensnivån slumpas fram.Beroende på kompetensnivå så sänkereller höjer en extraläkare en patients 
tillfriskningschansmed -10 till 30 procentenheter.Dessa extralägare skall finnas i en lista och tillförstill IVA 
tills dess att det inte finns flerextraläkare. Varje tidsenhet så ökar läkarnas utmattningsnivå,när den når 20 så är deutmattade 
och lämnar sin respektive avdelning. Omdet inte finns tillgängliga extraläkare såmåste avdelningarna och patienterna klara sig utandem.


5.Lägesrapport, för varje tidsenhet så vill vi veta,hur många personer som befinner sig i kö,samt på sanatoriet respektive IVA.  
Vi vill även vetahur många patienter som har tillfrisknatrespektive gått vidare till afterlife. 
Visa dettadata på skärmen samt i en loggfil. Loggfilen skallöppnas med APPEND så att den inte skrivs över av misstag.


6. Resultat: När simuleringen är klar, dvs när det intelängre finns några patienter kvar i vare sigkö, 
Sanatoriet eller IVA så skall resultat skrivasut.a.Rapportera när simuleringen kördes igång (Datetime)
samt hur lång tid den tog(antal ticks).
b.Rapportera hur många patienter som tillfrisknade respektive gick vidare till afterlife

