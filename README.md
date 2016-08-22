# 1DV449-Projekt
---
###Använda API:er		
[OpenWeatherMap API](http://openweathermap.org/)		
[Google Maps Javascript API](https://developers.google.com/maps/documentation/javascript/tutorial/)		
[Grain Of Gold](https://grain-of-gold.anemyr.me)	
>Api:et skapades för att möta approachen offline-first.
>Grain Of Gold har ett publikt ("read-only") api som svara med strukturerad ***JSON***.		
>(JSON-datat är *speglingar* av applikationens modeller.)		
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


