# Stundenplan
Wir haben ein Stundenplan Tool erstellt mit dem man Daten einfügen kann und daraus einen Stundenplan anzeigen kann mit Fächern, Unterrichtszeiten etc. 


## Installation
Für die Ausführung des Programms benötigt man:
- MySql Workbench mit Login und Passwort
- Falls man noch kein Login hat, ist es am einfachsten direkt unser Passwort zu nehmen für den root Benutzer.
- Passwort: Luna07wenn!

Dieses Passwort muss man im Projekt auch angeben, 
und zwar einmal im Modules/Program.cs und im DatabaseConnection/TimeTableContext.cs

### Modules/Program.cs
```builder.Services.AddDbContextFactory<TimeTableContext>(opt =>
	opt.UseMySql(
         "server = localhost; database = timetable; persistsecurityinfo=True;  uid = root; pwd =PASSWORT_HIER",
		MySqlServerVersion.AutoDetect("server = localhost; database = timetable; persistsecurityinfo=True;  uid = root; pwd =PASSWORT_HIER")```
)
);

### DatabaseConnection/TimeTableContext.cs:
```string connectionstring = "server = localhost; database = timetable; persistsecurityinfo=True;  uid = root; pwd =PASSWORT_HIER";```
