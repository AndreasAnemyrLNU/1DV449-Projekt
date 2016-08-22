# 1DV449-Projekt
---
###Använda API:er		
[OpenWeatherMap API](http://openweathermap.org/)		
[Google Maps Javascript API](https://developers.google.com/maps/documentation/javascript/tutorial/)		
[Grain Of Gold](https://grain-of-gold.anemyr.me)        	

Api:et skapades för att möta approachen offline-first.           
Grain Of Gold har ett publikt ("read-only") api,       
som svara med strukturerad ***JSON***.		
JSON-datat är *speglingar* av applikationens modeller.		

>URL: http://grain-of-gold/app.anemyr.me		
>>Http GET: /apps/GetApps/
>>>Code: 200 Ok.
>>>Code: 404 Not Found.     

>>Http GET: /apps/GetPlaceForecasts/                        
>>>>Code: 200 Ok.       
>>>>Code: 400 Bad Request.      
>>>>Code: 404 Not Found     
	
>>Http GET: /apps/GetCategoryPlaces/id      
>>>>Code: 200 Ok.       
>>>>Code: 400 Bad Request.      
>>>>Code: 404 Not Found     
		
>>Http GET: /apps/GetAppCategories/id       		
>>>Code: 200 Ok.        
>>>Code: 400 Bad Request.       
>>>Code: 404 Not Found.     

###Rapport
####Inledning 
#####Teknik:
Backend: MVC5 (C#)      
Frontend: HTML, CSS, JS (pluging jquery mustach).       
Webhotell: Binero.      

###Publicerad
Userinterface:  [ui    grain-of-gold](http://grain-of-gold.anemyr.me/ui)        
Admininterface: [admin grain-of-gold](http://grain-of-gold.anemyr.me)

###Applikationsidé
Visionen för denna webbapplikationen är att det ska vara möjligt		
att inom små specifika kategorier, kunna skapa minnesmärken		
både för sitt eget intresse. På sikt är tanken att flera kategorier     
kan inkluderas under subkategorier. Man skulle på så vis kunna få       
likasinnade personer att dela med sig av likande intresseområden.       
Ett krav är att varje minnesmärke ska generera en automatisk centrrerad     
google karta. Applikationens namn är tillsvidare Grain Of Gold.     
Syftet är alltså att det är individers minnesvärda guldkorn     
som webbapplikationen är tänkt att hantera via ett socialt media.        
      
Domänmodelleringen för backendsystemet ska vara generellt.      
Trots detta ska det vara möjligt att skapa sin egna app.        

###Domämodellering
Domänmodellen består i utvecklingen av två many-to-many relationer.     

######Här en skiss på domänen!

###Databasmodellering
Databasen har genererats med entity framework 6,		
med code first approach.

###Säkerhet & Prestandaoptimering
Applikationens backend är byggt med ASP.NET MVC 5.                   
Validering av data sker genom data annotations.          
På detta sätt stödj validering i tre steg.            
Anledningen till detta är att klienten valideras                    
hos klienten med javscript. Kommer klinenten genom            
den valideringen väntas en ny validering när        
modellens status kontrolleras. Det görs mot      
angivna data annotation attribute i modelklassen.       
Dessutom förhindras att bindningar kan ske till          
samtliga egenskaper i klassen. Detta är möjligt genom att              
använda attributet bind med en inkluderingslista för         
godkända bindningar.

###Offline-first
Grain of Gold har utvecklats med et tydligt mål.        
Att strukturen från domänmodellen bibehålls intakt,     
i sin struktur, ända ut på klienten. På detta vis                       
är det möjligt att koda metoder, de som kan behövas,        
lika både på backend och frontend. De metoder som       
syftas är de som har med någon for av persistent     
lagring att göra.        

Ett stort dilemma när det gäller tillvägagångssättet         
offline first, är att man måste hitta ett effektivt     
sätt att behålla status efter en användares interaktion.        

Grain of Gold har i sin nuvarande for ett objeckt       
som är en wrapper för applikationens status. Objektet                       
heter State dessutom. Objektet state sparas ned automatiskt     
till localstorate inom en rekursiv timeout. Intervallerna       
på detta skulle man alltså enkelt kunna ändra.

I nuvarande version finns det stöd för t.ex tappat wifi.                
Man kan således att fortsätta att navigera i menyer,              
trots att man förlorat sin uppkoppling.     
Däremot finns ej stöd för att man stänger ned sin klient        
för att återuppta interaktionen.      

Webbapplikationen ger kontinuerlig feedback till användaren              
för enhetens status gällande uppkopplingen. Troligtvis kommer      
nuvarande implementering att mätas för att se om det är     
éventuellt är för täta anrop. vilket eventuellt kan ses som negativt.       
Man skulle dessutom kunna optimera anropet för att minska
den totala mängden konsumerad trafik i ändmålet.      

###Risker med din applikation
En etisk risk skulle eventuellt kunna vara om       
användarens syfte är att lagra information som
har med kriminell verksamhet att göra. Även om      
webbapplikationen har ett syfte och ändamål,
att lagra guldkorn, så skulle den redan i nuvarande     
version kunna användas för att planera flykter gömmor etc. 


