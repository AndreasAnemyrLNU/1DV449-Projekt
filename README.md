# 1DV449-Projekt


###Teknik:
Backend: MVC5 (C#)
Frontend: HTML, CSS, JS (pluging jquery mustach).

###Applikationsidé
Visionen för denna app är att det ska vara möjligt		
att inom små specifika kategorier kunna skapa minnesmärken		
både för sig själv eller annan användare av system.

###Domämodellering
Domänmodellen består i utvecklingen av två many-to-many relationer.

######Här en skiss på domänen!

###Databasmodellering
Databasen har genererats med entity framework 6,		
med code first approach.

###Använda API:er		
[OpenWeatherMap API](http://openweathermap.org/)		
[Google Maps Javascript API](https://developers.google.com/maps/documentation/javascript/tutorial/)		
[Grain Of Gold](https://grain-of-gold.anemyr.me)	
>Api:et skapades för att möta approachen offline-first.
>Grain Of Gold har ett publikt ("read-only") api som svara med strukturerad ***JSON***.		
>(JSON-datat är *speglingar* av applikationens modeller.)		
>URL: http://www.grain-of-gold/app.anemyr.me		
>>Http GET: /apps/GetApps/
>>>Code: 200 Ok.
>>>Code: 404 Not Found.     

>>Http GET: /apps/GetPlaceForecasts/        
	
>>Http GET: /apps/GetCategoryPlaces/id      
>>>>Code: 200 Ok.
>>>>Code: 400 Bad Request.
>>>>Code: 404 Not Found
		
>>Http GET: /apps/GetAppCategories/id		
>>>Code: 200 Ok.
>>>Code: 400 Bad Request.
>>>Code: 404 Not Found.
